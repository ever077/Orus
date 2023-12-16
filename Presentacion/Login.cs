using Orus.Datos;
using Orus.Logica;
using Orus.Presentacion.AsistenteInstalacion;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Orus.Presentacion
{
    public partial class Login : Form
    {

        private string usuario;
        private int idUsuario;
        private Image iconoUsuario;
        private int contador;
        private string indicador;
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            /*
             * Esto hago para verificar si hay Base de Datos instalada
             * y Usuario Principal creado.
             * Lo comento porque ahora la aplicacion comienza en Asistencia, entonces
             * lo valido alli.
            */
            //ValidarConexion();

            DibujarUsuarios();
        }

        private void ValidarConexion()
        {
            // Verifico si hay conexion con la base de datos
            VerificarConexion();

            if (indicador == "Correcto")
            {
                // Hay conexion => Existe la base de datos
                
                contador = contarUsuarios();
                if (contador == 0)
                {
                    // No hay ningun usuario registrado -> Creo el Usuario Principal.
                    Dispose();
                    UsuarioPrincipal frm = new UsuarioPrincipal();
                    frm.ShowDialog();
                }
                else if (contador > 0)
                {
                    DibujarUsuarios();
                }
                else
                {
                    MessageBox.Show("Hubo un error de conexión con el servidor. Verifique su conexión e intentelo nuevamente.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Dispose();
                }
            }
            else
            {
                // No hay conexion => No existe la base de datos => La creo
                Dispose();
                EleccionServidor frm = new EleccionServidor();

                frm.ShowDialog();
            }
        }

        private void VerificarConexion()
        {
            Dusuario funcion = new Dusuario();
            funcion.VerificarUsuario(ref indicador);
        }

        private int contarUsuarios()
        {
            DataTable dt = new DataTable();
            Dusuario funcion = new Dusuario();

            return funcion.contarUsuarios();
        }

        private void DibujarUsuarios()
        {
            try
            {
                panel_Usuarios.Visible = true;
                panel_Usuarios.Dock = DockStyle.Fill;
                panel_Usuarios.BringToFront();

                DataTable dt = new DataTable();
                Dusuario funcion = new Dusuario();
                funcion.MostrarUsuario(ref dt);

                foreach (DataRow row in dt.Rows)
                {
                    if (row["Estado"].ToString() == "ACTIVO")
                    {
                        Panel pan1 = new Panel();
                        PictureBox img1 = new PictureBox();
                        Label lbl = new Label();

                        pan1.Size = new Size(155, 167);
                        pan1.BorderStyle = BorderStyle.None;
                        pan1.BackColor = Color.FromArgb(20, 20, 20);

                        img1.Size = new Size(175, 132);
                        img1.Dock = DockStyle.Top;
                        img1.BackgroundImage = null;
                        byte[] b = (Byte[])row["Icono"];
                        MemoryStream ms = new MemoryStream(b);
                        img1.Image = Image.FromStream(ms);
                        img1.SizeMode = PictureBoxSizeMode.Zoom;
                        img1.Tag = row["Login"].ToString();
                        img1.Cursor = Cursors.Hand;

                        lbl.Text = row["Login"].ToString();
                        lbl.Name = row["Id_usuario"].ToString();
                        lbl.Size = new Size(175, 25);
                        lbl.Font = new Font("Microsoft Sans Serif", 13);
                        lbl.BackColor = Color.Transparent;
                        lbl.ForeColor = Color.White;
                        lbl.Dock = DockStyle.Bottom;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Cursor = Cursors.Hand;

                        pan1.Controls.Add(img1);
                        pan1.Controls.Add(lbl);
                        lbl.BringToFront();
                        pan1.BringToFront();

                        flowLayoutPanel_Usuarios.Controls.Add(pan1);

                        lbl.Click += eventoLabelUsuario_Click;
                        img1.Click += eventoImagenUsuario_Click;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eventoLabelUsuario_Click(object sender, EventArgs e)
        {
            usuario = ((Label)sender).Text;
            PictureBox iconU = ((Panel)((Label)sender).Parent).Controls.OfType<PictureBox>().FirstOrDefault();
            iconoUsuario = iconU.Image;
            mostrarPanelPass();
        }

        private void eventoImagenUsuario_Click(object sender, EventArgs e)
        {
            usuario = ((PictureBox)sender).Tag.ToString();
            iconoUsuario = ((PictureBox)sender).Image;
            mostrarPanelPass();
        }

        private void mostrarPanelPass()
        {
            panel_IngresoDePass.Visible = true;
            panel_IngresoDePass.Location = new Point(((Width - panel_IngresoDePass.Width) / 2), ((Height - panel_IngresoDePass.Height) / 2));
            panel_IngresoDePass.BringToFront();
            panel_Usuarios.Visible = false;
            txt_Pass.Focus();
        }

        private void txt_Pass_TextChanged(object sender, EventArgs e)
        {
            validarUsuario();
        }

        private void validarUsuario()
        {
            Lusuario parametros = new Lusuario();
            Dusuario funcion = new Dusuario();

            parametros.Login = usuario;
            parametros.Password = txt_Pass.Text;

            funcion.ValidarUsuario(parametros, ref idUsuario);

            if (idUsuario > 0)
            {
                Dispose();
                MenuPrincipal frm = new MenuPrincipal();

                Lusuario usuarioLogueado = new Lusuario();
                usuarioLogueado.Id_usuario = idUsuario;
                usuarioLogueado.Login = usuario;
                MemoryStream ms = new MemoryStream();
                iconoUsuario.Save(ms, iconoUsuario.RawFormat);
                usuarioLogueado.Icono = ms.GetBuffer();
                frm.usuarioLogueado = usuarioLogueado;

                frm.ShowDialog(); 
            }
        }

        private void btn_IniciarSeccion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña erronea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            txt_Pass.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            txt_Pass.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            txt_Pass.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            txt_Pass.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            txt_Pass.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            txt_Pass.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            txt_Pass.Text += "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            txt_Pass.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            txt_Pass.Text += "9";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            txt_Pass.Text += "0";
        }

        private void btn_BorrarCaracter_Click(object sender, EventArgs e)
        {
            int contador = txt_Pass.Text.Count();

            if (contador > 0)
            {
                txt_Pass.Text = txt_Pass.Text.Substring(0, (txt_Pass.Text.Count() - 1));
            }
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            txt_Pass.Clear();
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            Dispose();
            Asistencia frm = new Asistencia();
            frm.set_hayUsuarioLogueado(false);
            frm.ShowDialog();
        }
    }
}
