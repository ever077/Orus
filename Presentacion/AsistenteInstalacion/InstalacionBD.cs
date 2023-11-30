using Orus.Datos;
using Orus.Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
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
        public static int segundos;
        public static int minutos;
        private const int _edicionSqlExpress = -1592396055;

        public InstalacionBD()
        {
            InitializeComponent();
            segundos = 0;
            minutos = 0;
        }

        private void InstalacionBD_Load(object sender, EventArgs e)
        {
            CentrarPaneles();
            Reemplazar();
            bool estaInstalado = comprobarSiSqlEstaInstalado();
            if (estaInstalado == true)
            {
                instalarServidorYBd();
            }
            else
            {
                // La instalacion de SQL EXPRESS se ejecutara una vez que el usuario presione el boton de Instalar.
                txtServidor.Text = @".\" + textBox_NombreInstancia.Text;

                btn_InstalarServidor.Visible = true;
                panel_Instalando.Visible = true;
                panel_Cargando.Visible = false;
                panel_Temporizador.Visible = true;
                label_InfoInstalacion.Text = "Haga click en el botón \"INSTALAR SERVIDOR\", luego presione que \"SI\" cuando se lo pida, y por ultimo, haga click en \"ACEPTAR\" y espere por favor";
            }
        }

        private void resetContadores(int seg, int min)
        {
            segundos = seg;
            minutos = min;
        }

        private bool comprobarSiSqlEstaInstalado()
        {
            /* 
             * Primera forma:
             * 
             * RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MICROSOFT\Microsoft SQL Server");
             * if (registryKey == null)
             * {
             *      return false;
             * }
             * else
             * {
             *      return true;
             * }
            */

            SqlDataSourceEnumerator sqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance;
            DataTable dt = sqlDataSourceEnumerator.GetDataSources();
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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

        private void instalarServidorYBd()
        {
            // Instalo segun la version de SQL instalada.
            int edicionSql = obtenerEdicionDeSql();
            if (edicionSql == _edicionSqlExpress)
            {
                txtServidor.Text = @".\" + textBox_NombreInstancia.Text;
            }
            else
            {
                txtServidor.Text = ".";
            }
            // Ejecuto la instalacion directamente sin que el usuario presione el boton.
            ejecutar_script_EliminarBase_comprobacion_de_inicio();
            ejecutar_script_CrearBase_comprobacion_de_inicio();
        }

        public int obtenerEdicionDeSql()
        {
            try
            {
                ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("select serverproperty('EditionID')", ConexionMaestra.conectar);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return 0;
            }
            finally
            {
                ConexionMaestra.cerrar();
            }
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

                panel_Instalando.Visible = true;
                panel_Instalando.Dock = DockStyle.Fill;
                label_InfoInstalacion.Text = @"Instancia Encontrada... No cierre ésta ventana, se cerrará automáticamente cuando todo este listo.";
                panel_Temporizador.Visible = false;

                resetContadores(0,0);
                timer_EliminarScriptCreacionBd.Start();
            }
            catch (Exception)
            {
                /*
                 * No muestro la excepcion para que no detenga el programa y se vuelva a ejecutar en los timers 2 y 3.
                 * Esto significaria que no puede crear la base de datos con sus tablas porque todavia no ha
                 * terminado de insralarse el SQL EXPRESS.
                */

                // MessageBox.Show(ex.StackTrace);
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
            
            StreamWriter sw;
            try
            {
                if (File.Exists(ruta) == true)
                {
                    File.Delete(ruta);
                }
                sw = File.CreateText(ruta);
                sw.WriteLine(textBox_CrearProcedimientos.Text);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

            // Ejecuto el script que crea la base de datos.
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

        private void timer_EliminarScriptCreacionBd_Tick(object sender, EventArgs e)
        {
            // Este Timer se encarga de contar 15 segundos y luego Elimina el script que se creo para instalar la base de datos.

            timer3.Stop();

            segundos += 1;
            label_seg.Text = segundos.ToString();
            if (segundos == 15)
            {
                timer_EliminarScriptCreacionBd.Stop();
                try
                {
                    File.Delete(ruta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
                MessageBox.Show("La Base de Datos se ha instalado correctamente", "Fin de instalacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
        }

        private void btn_InstalarServidor_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ArgumentosIni.Text = textBox_ArgumentosIni.Text.Replace("PRUEBAFINAL22", textBox_NombreInstancia.Text);
                timer_CrearArchivoConfigIni.Start();
                ejecutarArchivoExe();
                resetContadores(0, 0);
                timer2.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void timer_CrearArchivoConfigIni_Tick(object sender, EventArgs e)
        {
            /*
             * Este Timer se encarga de crear el archivo ConfigurationFile.ini
             * Siempre intentara crearlo hasta que se logre hacerlo.
            */

            string rutaConfig;
            StreamWriter sw;
            rutaConfig = Path.Combine(Directory.GetCurrentDirectory(), "ConfigurationFile.ini");
            rutaConfig = rutaConfig.Replace("ConfigurationFile.ini", @"SQLEXPR_x86_ESN\ConfigurationFile.ini");
            if (File.Exists(rutaConfig) == true)
            {
                timer_CrearArchivoConfigIni.Stop();
            }

            try
            {
                sw = File.CreateText(rutaConfig);
                sw.WriteLine(textBox_ArgumentosIni.Text);
                sw.Flush();
                sw.Close();
                timer_CrearArchivoConfigIni.Stop();
            }
            catch (Exception)
            {
                // No se creo el archivo. Intentara nuevamente.
            }
        }

        private void ejecutarArchivoExe()
        {
            try
            {
                Process pross = new Process();
                //pross.StartInfo.FileName = "SQLEXPR_x86_ENU.exe"; -> Asi lo puso en el curso, creo que esta mal y lo corrijo en la linea siguiente.
                pross.StartInfo.FileName = "SQLEXPR_x86_ESN.exe";
                pross.StartInfo.Arguments = "/ConfigurationFile=ConfigurationFile.ini /ACTION=Install /IACCEPTSQLSERVERLICENSETERMS /SECURITYMODE=SQL /SAPWD=" + textBox_Pass.Text + " /SQLSYSADMINACCOUNTS=" + nombreDelEquipo_Usuario;
                pross.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                pross.Start();

                btn_InstalarServidor.Visible = false;
                panel_Instalando.Visible = true;
                panel_Cargando.Visible = true;
                panel_Temporizador.Visible = true;
                label_InfoInstalacion.Text = "Instalando Servidor...\n\nNo cierre esta Ventana, se cerrará automáticamente cuando todo este listo.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Tiempo estipulado para instalar el motor: 6 min.
            
            segundos += 1;
            label_seg.Text = Convert.ToString(segundos);
            if (segundos == 60)
            {
                minutos += 1;
                label_min.Text = Convert.ToString(minutos);
                segundos = 0;
            }
            if (minutos == 6)
            {
                timer2.Stop();
                ejecutar_script_EliminarBase_comprobacion_de_inicio();
                ejecutar_script_CrearBase_comprobacion_de_inicio();
                resetContadores(0, 6);
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            // Pasados los 6 minutos voy verificando cada 1 minuto si ya se termino de ejecutar
            
            segundos += 1;
            label_seg.Text = Convert.ToString(segundos);
            if (segundos == 60)
            {
                minutos += 1;
                label_min.Text = Convert.ToString(minutos);
                segundos = 0;
                ejecutar_script_EliminarBase_comprobacion_de_inicio();
                ejecutar_script_CrearBase_comprobacion_de_inicio();
            }
        }

        private void InstalacionBD_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            timer_CrearArchivoConfigIni.Stop();
            timer_EliminarScriptCreacionBd.Stop();
        }
    }
}
