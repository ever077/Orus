using Orus.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Orus.Presentacion.AsistenteInstalacion
{
    public partial class InstalacionBD : Form
    {
        private string nombreDelEquipo_Usuario;
        private AES aes = new AES();
        private string ruta;
        public static int milisegundos;
        public static int segundos;

        public InstalacionBD()
        {
            InitializeComponent();
        }

        private void InstalacionBD_Load(object sender, EventArgs e)
        {
            CentrarPaneles();
            Reemplazar();
            comprobar_si_ya_hay_servidor_instalado_SQL_EXPRESS();
        }

        private void CentrarPaneles()
        {
            panel_Instalacion.Location = new Point((Width - panel_Instalacion.Width) / 2, (Height - panel_Instalacion.Height) / 2);
            nombreDelEquipo_Usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Cursor = Cursors.WaitCursor;
            panel_Instalando.Visible = false;
            panel_Instalando.Dock = DockStyle.None;
        }

        private void Reemplazar()
        {
            // Solo modificr este campo
            textBox_CrearProcedimientos.Text = textBox_CrearProcedimientos.Text.Replace("ORUS", textBox_BaseDeDatos.Text);
            // ************************
            textBox_EliminarBaseDeDatos.Text = textBox_EliminarBaseDeDatos.Text.Replace("BASEADACURSO", textBox_BaseDeDatos.Text);
            textBox_CrearUsuarioDB.Text = textBox_CrearUsuarioDB.Text.Replace("ada369", textBox_Usuario.Text);
            textBox_CrearUsuarioDB.Text = textBox_CrearUsuarioDB.Text.Replace("BASEADA", textBox_BaseDeDatos.Text);
            textBox_CrearUsuarioDB.Text = textBox_CrearUsuarioDB.Text.Replace("softwarereal", textBox_Pass.Text);
            // Adjustanto al TextBox que contiene los procedimientos almacenados
            textBox_CrearProcedimientos.Text = textBox_CrearProcedimientos.Text + Environment.NewLine + textBox_CrearUsuarioDB.Text;
        }

        private void comprobar_si_ya_hay_servidor_instalado_SQL_EXPRESS()
        {
            txtServidor.Text = @".\" + textBox_NombreInstancia.Text;
            ejecutar_script_EliminarBase_comprobacion_de_inicio();
            ejecutar_script_CrearBase_comprobacion_de_inicio();
        }

        private void ejecutar_script_EliminarBase_comprobacion_de_inicio()
        {
            string str;
            SqlConnection myConn = new SqlConnection("Data source=" + txtServidor.Text + ";Initial Catalog=master;Integrated Security=True");
            str = textBox_EliminarBaseDeDatos.Text;
            SqlCommand myCommand = new SqlCommand(str, myConn);

            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        private void ejecutar_script_CrearBase_comprobacion_de_inicio()
        {
            SqlConnection myConn = new SqlConnection("Server=" + txtServidor.Text + "; " + "database=master; integrated security=yes");
            string str = "CREATE DATABASE " + textBox_BaseDeDatos.Text;
            SqlCommand myCommand = new SqlCommand(str, myConn);

            try
            {
                // Creo la base de datos
                myConn.Open();
                myCommand.ExecuteNonQuery();

                // Encripto el archivo XML con la ruta de conexion
                saveToXML(aes.Encrypt("Data Source=" + txtServidor.Text + ";Initial Catalog=" + textBox_BaseDeDatos.Text + ";Integrated Security=True", Desencriptacion.appPwdUnique, int.Parse("256")));

                ejecutarScript();

 //               btn_InstalarServidor.Visible = false;
                panel_Instalando.Visible = true;
                panel_Instalando.Dock = DockStyle.Fill;
                label_InfoInstalacion.Text = @"Instancia Encontrada...
No cierre ésta ventana, se cerrará automáticamente cuando todo este listo.";
                panel_Temporizador.Visible = false;

                timer4.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        private void saveToXML(object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }

        private void ejecutarScript()
        {
            // Creo un archivo encriptado que tenga el script de las tablas y procedimientos de la BD
            ruta = Path.Combine(Directory.GetCurrentDirectory(), textBox_NombreScript.Text + ".txt");
          /* 
           * Crear archivo
           * FileInfo fi = new FileInfo(ruta);
          */
            StreamWriter sw;
            try
            {
                if (File.Exists(ruta) == false)
                {
                    sw = File.CreateText(ruta);
                    sw.WriteLine(textBox_CrearProcedimientos.Text);
                    sw.Flush();
                    sw.Close();
                }
                else if (File.Exists(ruta) == true)
                {
                    File.Delete(ruta);
                    sw = File.CreateText(ruta);
                    sw.WriteLine(textBox_CrearProcedimientos.Text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "sqlcmd";
                proc.StartInfo.Arguments = (" -S " + txtServidor.Text + " -i " + textBox_NombreScript.Text + ".txt");
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            milisegundos += 1;
            label_miliseg.Text = milisegundos.ToString();
            if (milisegundos == 60)
            {
                segundos += 1;
                label_seg.Text = segundos.ToString();
                milisegundos = 0;
            }
            if (segundos == 15)
            {
                timer4.Stop();
                try
                {
                    File.Delete(ruta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
                Dispose();
            }
        }
    }
}
