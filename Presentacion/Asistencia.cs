using Orus.Datos;
using Orus.Logica;
using Orus.Presentacion.AsistenteInstalacion;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Orus.Presentacion
{
    public partial class Asistencia : Form
    {
        private string identificacion;
        private int idPersonal;
        private int contador;
        DateTime fechaRegistro;
        private bool hayUsuarioLogueado;
        private Lusuario usuarioLogueado;
        private string indicadorDeConexion;

        public void set_hayUsuarioLogueado(bool hayusrLogueado)
        {
            hayUsuarioLogueado = hayusrLogueado;
        }

        public void set_hayUsuarioLogueado(bool hayusrLogueado, Lusuario usrLogueado)
        {
            hayUsuarioLogueado = hayusrLogueado;
            usuarioLogueado = usrLogueado;
        }

        public Asistencia()
        {
            InitializeComponent();
            hayUsuarioLogueado = false;
            indicadorDeConexion = "";
        }

        private void Asistencia_Load(object sender, EventArgs e)
        {
            if (hayUsuarioLogueado)
            {
                btn_IniciarSeccion.Visible = false;
                btn_Volver.Visible = true;
            }
            else
            {
                // Es cuando inicia la aplicacion.
                validarConexion();
            }
            LocalizarEnCentroDePantalla(panel_RegistroAsistencia);
            panel_Observacion.Visible = false;
            txt_Identificacion.Focus();
        }

        private void validarConexion()
        {
            // Verifico si hay conexion con la base de datos
            verificarConexion();
            if (indicadorDeConexion == "Correcto")
            {
                // Hay conexion => Existe la base de datos

                if (contarUsuarios() == 0)
                {
                    // No hay ningun usuario registrado -> Creo el Usuario Principal.
                    Dispose();
                    UsuarioPrincipal frm = new UsuarioPrincipal();
                    frm.ShowDialog();
                }
            }
            else
            {
                /*
                 * No hay conexion => No existe la base de datos => La creo
                 * O puede ser que el archivo ConnectionString se haya modificado.
                */
                Dispose();
                EleccionServidor frm = new EleccionServidor();
                frm.ShowDialog();
            }
        }

        private void verificarConexion()
        {
            Dusuario funcion = new Dusuario();
            funcion.VerificarUsuario(ref indicadorDeConexion);
        }

        private int contarUsuarios()
        {
            DataTable dt = new DataTable();
            Dusuario funcion = new Dusuario();

            return funcion.contarUsuarios();
        }

        private void LocalizarEnCentroDePantalla(Panel panel)
        {
            /*
             * Localiza el panel recibido en el centro de la pantalla.
            */
            int altura = panel.Height;
            int anchura = panel.Width;

            int nuevaAltura = (this.Height - altura) / 2;
            int nuevaAnchura = (this.Width - anchura) / 2;

            panel.Location = new Point(nuevaAnchura,nuevaAltura);
        }

        private void timer_Hora_Tick(object sender, EventArgs e)
        {
            lbl_Hora.Text = DateTime.Now.ToString("hh:mm:ss");
            lbl_Fecha.Text = DateTime.Now.ToShortDateString();
        }

        private void txt_Identificacion_TextChanged(object sender, EventArgs e)
        {
            BuscarPersonalIdentidad();

            if (identificacion == txt_Identificacion.Text)
            {
                BuscarAsistenciaId();

                if (contador == 0)
                {
                    // No hay entradas registradas aun --> Registro una ENTRADA.
                    DialogResult dialogResult = MessageBox.Show("¿Desea agregar una observacion?", "Observaciones", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.OK)
                    {
                        panel_Observacion.Visible = true;
                        panel_Observacion.Location = new Point(panel_RegistroAsistencia.Location.X, panel_RegistroAsistencia.Location.Y);
                        panel_Observacion.Size = new Size(panel_RegistroAsistencia.Width, panel_RegistroAsistencia.Height);
                        btn_Confirmar.Location = new Point((panel_BtnConfirmar.Width - btn_Confirmar.Width) / 2, (panel_BtnConfirmar.Height - btn_Confirmar.Height) / 2);
                        panel_Observacion.BringToFront();
                        txt_Observacion.Clear();
                        txt_Observacion.Focus();
                    }
                    else
                    {
                        txt_Observacion.Clear();
                        InsertarAsistencia();
                    }
                }
                else
                {
                    // Hay una entrasa registrada --> Registro una SALIDA.
                    ConfirmarSalidaAsistencia();
                }
            }
        }

        private void txt_Identificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Valido que la entrada sean solo digitos.

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void BuscarPersonalIdentidad()
        {
            DataTable dt = new DataTable();
            Dpersonal funcion = new Dpersonal();

            funcion.BuscarPersonalIdentidad(ref dt, txt_Identificacion.Text);

            if (dt.Rows.Count > 0)
            {
                identificacion = dt.Rows[0]["Identificacion"].ToString();
                idPersonal = Convert.ToInt32(dt.Rows[0]["Id_personal"]);
                lbl_NombreUsuario.Text = dt.Rows[0]["Nombres"].ToString();
            }
        }

        private void BuscarAsistenciaId()
        {
            DataTable dt = new DataTable();
            Dasistencia funcion = new Dasistencia();

            funcion.BuscarAsistenciaId(ref dt, idPersonal);
            contador = dt.Rows.Count;

            if (contador > 0)
            {
                // Hay una entrada registrada.
                fechaRegistro = Convert.ToDateTime(dt.Rows[0]["Fecha_entrada"]);
            }
        }

        private void InsertarAsistencia()
        {
            Lasistencia parametros = new Lasistencia();
            Dasistencia funcion = new Dasistencia();

            if (string.IsNullOrEmpty(txt_Observacion.Text))
            {
                txt_Observacion.Text = "-";
            }

            parametros.Id_personal = idPersonal;
            parametros.Fecha_entrada = DateTime.Now;
            parametros.Fecha_salida = DateTime.Now;
            parametros.Estado = "ENTRADA";
            parametros.Horas = 0;
            parametros.Observacion = txt_Observacion.Text;

            if (funcion.InsertarAsistencia(parametros) == true)
            {
                lbl_Aviso.Text = "ENTRADA REGISTRADA";
                txt_Identificacion.Clear();
                txt_Identificacion.Focus();
                panel_Observacion.Visible = false;
            }
        }

        private void ConfirmarSalidaAsistencia()
        {
            /*
             * Las horas trabajadas se cuentan por minuto.
            */ 

            Lasistencia parametros = new Lasistencia();
            Dasistencia funcion = new Dasistencia();

            parametros.Id_personal = idPersonal;
            parametros.Fecha_salida = DateTime.Now;
            // -> Esto lo hacia para calcular solamenta las horas trabajadas, sin incluir los minutos.
            //parametros.Horas = Configuraciones.DateDiff(Configuraciones.DateInterval.Hour, fechaRegistro, DateTime.Now);
            DateTime timeNow = DateTime.Now;
            parametros.Horas = (timeNow - fechaRegistro).TotalHours;

            // -> Esto es para saber las horas y minutos trabajados en formato hh:mm
            //TimeSpan span1 = TimeSpan.FromHours(parametros.Horas);

            if (funcion.ConfirmarSalidaAsistencia(parametros) == true)
            {
                lbl_Aviso.Text = "SALIDA REGISTRADA";
                txt_Identificacion.Clear();
                txt_Identificacion.Focus();
            }
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            InsertarAsistencia();
        }

        private void btn_IniciarSeccion_Click(object sender, EventArgs e)
        {
            Dispose();
            Login frm = new Login();
            frm.ShowDialog();
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            Dispose();
            MenuPrincipal frm = new MenuPrincipal();
            frm.usuarioLogueado = usuarioLogueado;
            frm.ShowDialog();
        }
    }
}
