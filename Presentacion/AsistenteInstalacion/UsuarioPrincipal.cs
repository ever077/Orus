using Orus.Datos;
using Orus.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Orus.Presentacion.AsistenteInstalacion
{
    public partial class UsuarioPrincipal : Form
    {
        int idUsuario;

        public UsuarioPrincipal()
        {
            InitializeComponent();
        }

        private void UsuarioPrincipal_Load(object sender, EventArgs e)
        {
            centrarPanel();
        }

        private void centrarPanel()
        {
            panel_UsuarioPrincipal.Location = new Point((Width - panel_UsuarioPrincipal.Width) / 2, (Height - panel_UsuarioPrincipal.Height) / 2);
        }

        private void btn_Siguiente_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_Nombre.Text))
            {
                if (!string.IsNullOrEmpty(textBox_Pass.Text))
                {
                    if (textBox_Pass.Text == textBox_ConfirmacionPass.Text)
                    {
                        insertarUsuarioPorDefecto();
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Falta ingresar la contraseña", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Falta ingresar el nombre", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertarUsuarioPorDefecto()
        {
            Lusuario parametros = new Lusuario();
            Dusuario funcion = new Dusuario();

            parametros.Nombres = textBox_Nombre.Text;
            parametros.Login = textBox_Usuario.Text;
            parametros.Password = textBox_Pass.Text;

            MemoryStream ms = new MemoryStream();
            pictureBox_Icono.Image.Save(ms, pictureBox_Icono.Image.RawFormat);
            parametros.Icono = ms.GetBuffer();

            if (funcion.InsertarUsuario(parametros) == true)
            {
                insertarModulos();
                obtenerIdUsuario();
                insertarPermisos();
                insertarCopiaBdDefault();
            }
        }

        private void insertarModulos()
        {
            Lmodulo parametros = new Lmodulo();
            Dmodulo funcion = new Dmodulo();

            var modulos = new List <string> { "PrePlanillas", "Personal", "Registro", "Usuarios", "RestauracionBD", "Respaldos", "Estaciones" };
            foreach (var modulo in modulos )
            {
                parametros.Modulo = modulo;
                funcion.InsertarModulo(parametros);
            }
        }

        private void insertarPermisos()
        {
            Lpermiso parametros = new Lpermiso();
            Dpermiso funcion = new Dpermiso();

            DataTable dt = new DataTable();
            Dmodulo funcionModulo = new Dmodulo();

            funcionModulo.MostrarModulos(ref dt);

            foreach (DataRow row in dt.Rows)
            {
                int idModulo = Convert.ToInt32(row["Id_modulo"]);

                parametros.Id_modulo = idModulo;
                parametros.Id_Usuario = idUsuario;

                funcion.InsertarPermiso(parametros);
            }

            MessageBox.Show("¡LISTO! Recuerda que para Iniciar Sesión tu Usuario es: " + textBox_Usuario.Text + " y tu Contraseña es: " + textBox_Pass.Text, "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Dispose();

            Login frm = new Login();
            frm.ShowDialog();
        }

        private void obtenerIdUsuario()
        {
            Dusuario funcion = new Dusuario();

            funcion.ObtenerIdUsuario(ref idUsuario, textBox_Usuario.Text);
        }

        private void insertarCopiaBdDefault()
        {
            LcopiaBd parametros = new LcopiaBd();
            DcopiaBd funcion = new DcopiaBd();

            parametros.ruta = CopiaBd._rutaInicialCopiaDb;
            funcion.InsertarRutaCopiaBd(parametros);
        }
    }
}
