using Orus.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Orus.Presentacion.AsistenteInstalacion
{
    public partial class ConexionRemota : Form
    {
        private string cadenaDeConexion;
        private bool hayConexion;
        private AES aes = new AES();
        // Aca se coloca el nombre de la Base de Datos que existe remotamente.
        private const string _nombreBdConexion = "ORUS";
        // Aca se coloca el nombre del usuario de la Base de Datos que existe remotamente.
        private const string _idUsuarioBdConexion = "orus";
        // Aca se coloca la contraseña de la Base de Datos que existe remotamente.
        private const string _passBdConexion = "orus";

        public ConexionRemota()
        {
            InitializeComponent();
        }

        private void ConexionRemota_Load(object sender, EventArgs e)
        {
            centrarPanelConexion();
        }

        private void centrarPanelConexion()
        {
            panel_Conexion.Location = new Point((Width - panel_Conexion.Width) / 2, panel_Conexion.Height);
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_Ip.Text))
            {
                conectarManualmente();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una IP", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void conectarManualmente()
        {
            string ip = textBox_Ip.Text;
            cadenaDeConexion = "Data Sourse =" + ip + ";Initial Catalog=" + _nombreBdConexion + ";Integrated Security=False;User Id=" + _idUsuarioBdConexion + ";Password=" + _passBdConexion;
            comprobarConexion();
            if (hayConexion == true)
            {
                saveToXML(aes.Encrypt(cadenaDeConexion, Desencriptacion.appPwdUnique, int.Parse("256")));
                MessageBox.Show("Conexión establecida.\nPor favor vuelva a abrir el Sistema", "Conexión establecida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
        }

        private void comprobarConexion()
        {
            SqlConnection conexionManual = new SqlConnection(cadenaDeConexion);
            try
            {
                conexionManual.Open();
                SqlCommand cmd = new SqlCommand("select Login from Usuario", conexionManual);
                string result = cmd.ExecuteScalar().ToString();
                hayConexion = true;
            }
            catch (Exception ex)
            {
                hayConexion = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionManual.Close();
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
    }
}
