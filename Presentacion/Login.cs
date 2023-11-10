using Orus.Datos;
using Orus.Logica;
using Orus.Presentacion.AsistenteInstalacion;
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
            ValidarConexion();
        }

        private void ValidarConexion()
        {
            VerificarConexion();

            if (indicador == "Correcto")
            {
                MostrarUsuario();

                if (contador == 0)
                {
                    Dispose();
                    UsuarioPrincipal frm = new UsuarioPrincipal();
                    frm.ShowDialog();
                }
                else
                {
                    DibujarUsuarios();
                }
            }
            else
            {
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

        private void MostrarUsuario()
        {
            DataTable dt = new DataTable();
            Dusuario funcion = new Dusuario();

            funcion.MostrarUsuario(ref dt);
            contador = dt.Rows.Count;
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

                    flowLayoutPanel_Usuarios.Controls.Add(pan1);

                    lbl.Click += eventoLabelUsuario_Click;
                    img1.Click += eventoImagenUsuario_Click;

                    pan1.Click += eventoPanelUsuario_Click;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eventoPanelUsuario_Click(object sender, EventArgs e)
        {
            List<PictureBox> listaPictureBox = (List<PictureBox>)((Panel)sender).Controls.OfType<PictureBox>();
            usuario = (listaPictureBox[0]).Tag.ToString();
            iconoUsuario = (listaPictureBox[0]).Image;
            mostrarPanelPass();
        }

        private void eventoLabelUsuario_Click(object sender, EventArgs e)
        {
            usuario = ((Label)sender).Text;
            mostrarPanelPass();
        }

        private void eventoImagenUsuario_Click(object sender, EventArgs e)
        {
            usuario = ((PictureBox)sender).Tag.ToString();
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
                frm.set_idUsuario(idUsuario);
                frm.set_loginV(usuario);
                frm.set_iconoUsuario(iconoUsuario);
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


    }
}
