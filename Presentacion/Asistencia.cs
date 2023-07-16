using Orus.Datos;
using Orus.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orus.Presentacion
{
    public partial class Asistencia : Form
    {
        string identificacion;
        int idPersonal;
        int contador;
        DateTime fechaRegistro;

        public Asistencia()
        {
            InitializeComponent();
        }

        private void Asistencia_Load(object sender, EventArgs e)
        {
            LocalizarEnCentroDePantalla(panel_RegistroAsistencia);
            panel_Observacion.Visible = false;
            txt_Identificacion.Focus();
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

        private void BuscarPersonalIdentidad()
        {
            DataTable dt = new DataTable();
            Dpersonal funcion = new Dpersonal();

            funcion.BuscarPersonalIdentidad(ref dt, txt_Identificacion.Text);

            if (dt.Rows.Count > 0 )
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
            Lasistencia parametros = new Lasistencia();
            Dasistencia funcion = new Dasistencia();

            parametros.Id_personal = idPersonal;
            parametros.Fecha_salida = DateTime.Now;
            parametros.Horas = Configuraciones.DateDiff(Configuraciones.DateInterval.Hour, fechaRegistro, DateTime.Now);

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
    }
}
