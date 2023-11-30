using Orus.Datos;
using Orus.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orus.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public Lusuario usuarioLogueado { get; set; }
        private string nombreBd;
        private string rutaArchivoCopiaBd;
        private const string _servidorSqlExpress = @".\SQLEXPRESS";
        private const string _servidorNoSqlExpress = ".";
        private const int _edicionSqlExpress = -1592396055;

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panel_Bienvenida.Dock = DockStyle.Fill;
            validarPermisos();
            mostrarUsuarioLogueado();
        }

        private void validarPermisos()
        {
            Lpermiso parametros = new Lpermiso();
            Dpermiso funcion = new Dpermiso();
            DataTable dtPermisos = new DataTable();

            parametros.Id_Usuario = usuarioLogueado.Id_usuario;
            funcion.MostrarPermiso(ref dtPermisos, parametros);

            // Inhabilito todos los botones del Menu Principal.
            btn_Consultas.Enabled = false;
            btn_Personal.Enabled = false;
            btn_Registro.Enabled = false;
            btn_Usuarios.Enabled = false;
            btn_RestaurarBd.Enabled = false;
            btn_Respaldos.Enabled = false;
            btn_Estaciones.Enabled = false;

            foreach (DataRow rowPermiso in dtPermisos.Rows)
            {
                string modulo = Convert.ToString(rowPermiso["Modulo"]);

                if (modulo == "PrePlanillas")
                {
                    btn_Consultas.Enabled = true;
                }
                if (modulo == "Personal")
                {
                    btn_Personal.Enabled = true;
                }
                if (modulo == "Registro")
                {
                    btn_Registro.Enabled = true;
                }
                if (modulo == "Usuarios")
                {
                    btn_Usuarios.Enabled = true;
                }
                if (modulo == "RestauracionBD")
                {
                    btn_RestaurarBd.Enabled = true;
                }
                if (modulo == "Respaldos")
                {
                    btn_Respaldos.Enabled = true;
                }
                if (modulo == "Estaciones")
                {
                    btn_Estaciones.Enabled = true;
                }
            }
        }

        private void mostrarUsuarioLogueado()
        {
            lbl_Login.Text = usuarioLogueado.Login;
            MemoryStream ms = new MemoryStream(usuarioLogueado.Icono);
            pictureBox_IconoUsuario.Image = Image.FromStream(ms);
        }

        private void btn_Consultas_Click(object sender, EventArgs e)
        {
            panel_Padre.Controls.Clear();
            PrePlanilla controlPrePlanilla = new PrePlanilla();
            controlPrePlanilla.Dock = DockStyle.Fill;
            panel_Padre.Controls.Add(controlPrePlanilla);
        }

        private void btn_Personal_Click(object sender, EventArgs e)
        {
            panel_Padre.Controls.Clear();
            Personal controlPersonal = new Personal();
            controlPersonal.Dock = DockStyle.Fill;
            panel_Padre.Controls.Add(controlPersonal);
        }

        private void btn_Registro_Click(object sender, EventArgs e)
        {
            Dispose();
            Asistencia frmAsistencia = new Asistencia();
            frmAsistencia.set_hayUsuarioLogueado(true, usuarioLogueado);
            frmAsistencia.ShowDialog();
        }

        private void btn_Usuarios_Click(object sender, EventArgs e)
        {
            panel_Padre.Controls.Clear();
            ControlUsuarios controlUsuario = new ControlUsuarios();
            controlUsuario.set_usuarioLogueado(usuarioLogueado);
            controlUsuario.Dock = DockStyle.Fill;
            panel_Padre.Controls.Add(controlUsuario);
        }

        private void btn_RestaurarBd_Click(object sender, EventArgs e)
        {
            restaurarBd();
        }

        private void btn_Respaldos_Click(object sender, EventArgs e)
        {
            panel_Padre.Controls.Clear();
            CopiaBd controlCopiaBd = new CopiaBd();
            controlCopiaBd.Dock = DockStyle.Fill;
            panel_Padre.Controls.Add(controlCopiaBd);
        }

        private void restaurarBd()
        {
            obtenerNombreBd();

            openFileDialog_SeleccionCopiaBd.InitialDirectory = "";
            openFileDialog_SeleccionCopiaBd.Filter = "Backup " + nombreBd + "|*.bak";
            openFileDialog_SeleccionCopiaBd.FilterIndex = 1;
            openFileDialog_SeleccionCopiaBd.Title = "Cargador de Backup";

            if (openFileDialog_SeleccionCopiaBd.ShowDialog() == DialogResult.OK)
            {
                rutaArchivoCopiaBd = Path.GetFullPath(openFileDialog_SeleccionCopiaBd.FileName);

                DialogResult confirmacion = MessageBox.Show("Usted está por restaurar la Base de Datos, asegurese de que el archivo \".bak\" sea reciente, de lo contrario podría perder informacion y NO se podrá recuperar. ¿Desea continuar?", "Restauración de Base de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    LcopiaBd parametros = new LcopiaBd();
                    DcopiaBd funcion = new DcopiaBd();

                    parametros.ruta = rutaArchivoCopiaBd;

                    int edicionSql = funcion.obtenerEdicionDeSql();

                    bool seRestauro = false;
                    if (edicionSql == _edicionSqlExpress)
                    {
                        // El servidor es SQLEXPRESS
                        seRestauro = funcion.RestaurarBd(parametros, nombreBd, _servidorSqlExpress);
                    }
                    else
                    {
                        // El servidor NO es SQLEXPRESS
                        seRestauro = funcion.RestaurarBd(parametros, nombreBd, _servidorNoSqlExpress);
                    }

                    if (seRestauro == true)
                    {
                        MessageBox.Show("La Base de Datos ha sido restaurada satisfactoriamente! Vuelve a iniciar el programa", "Restauración de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dispose();
                    }
                }
            }
        }

        private void obtenerNombreBd()
        {
            DcopiaBd funcion = new DcopiaBd();
            funcion.MostrarNombreBd(ref nombreBd);
        }

        private void pictureBox_MenuDesplegable_Click(object sender, EventArgs e)
        {
            if (panel_MenuDesplegable.Visible == false)
            {
                panel_MenuDesplegable.Visible = true;
            }
            else
            {
                panel_MenuDesplegable.Visible = false;
            }
        }

        private void label_CerrarAplicacion_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion =  MessageBox.Show("¿Está seguro que quiere Salir de la aplicación?", "Cerrar Aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                Dispose();
            }
            else
            {
                panel_MenuDesplegable.Visible = false;
            }
        }

        private void label_CerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Está seguro que quiere cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                Dispose();
                Login frm = new Login();
                frm.ShowDialog();
            }
            else
            {
                panel_MenuDesplegable.Visible = false;
            }
        }
    }
}
