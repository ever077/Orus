using Orus.Datos;
using Orus.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orus.Presentacion
{
    public partial class CopiaBd : UserControl
    {
        private string rutaAlmacenada;
        private string nombreSoftware = "Orus";
        private string nombreBd;
        private Thread hilo;
        private bool procesoTerminado = false;
        public const string _rutaInicialCopiaDb = "-";

        public CopiaBd()
        {
            InitializeComponent();
        }

        private void CopiaBd_Load(object sender, EventArgs e)
        {
            centrarPanel();
            mostrarRutaCopiaBd();
            mostrarNombreBd();
        }

        private void centrarPanel()
        {
            panel_GenerarCopiaBd.Location = new Point(((Width - panel_GenerarCopiaBd.Width)/2), ((Height - panel_GenerarCopiaBd.Height)/2));
        }

        private void mostrarRutaCopiaBd()
        {
            DcopiaBd funcion = new DcopiaBd();
            funcion.MostrarRutaCopiaBd(ref rutaAlmacenada);
            textBox_Ruta.Text = rutaAlmacenada;
        }

        private void mostrarNombreBd()
        {
            DcopiaBd funcion = new DcopiaBd();
            funcion.MostrarNombreBd(ref nombreBd);
        }

        private void btn_GenerarCopia_Click(object sender, EventArgs e)
        {
            generarCopia();
        }

        private void generarCopia()
        {
            if (!string.IsNullOrEmpty(textBox_Ruta.Text))
            {
                hilo = new Thread(new ThreadStart(ejecucionDeCopia));
                hilo.Start();
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Seleccione una ruta donde se guardará la Copia de Seguridad", "Ruta no especificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Ruta.Focus();
            }
        }

        private void ejecucionDeCopia()
        {
            DcopiaBd funcion = new DcopiaBd();

            string miCarpeta = @"\Copias_de_seguridad_de_" + nombreSoftware;
            string rutaCompleta = textBox_Ruta.Text + miCarpeta;
            string subCarpeta = rutaCompleta + @"\Respaldo_al_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute;

            // Creacion de carpetas
            try
            {
                if (!(System.IO.Directory.Exists(rutaCompleta)))
                {
                    // Si no existe la carpeta en la ruta seleccionada por el usuario creo la carpeta Raiz de los respaldos.
                    System.IO.Directory.CreateDirectory(rutaCompleta);
                }

                // Creo la sub carpeta del respaldo actual
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(rutaCompleta, subCarpeta));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

            // Creacion del respaldo
            string nombreRespaldo = nombreBd + ".bak";
            procesoTerminado = funcion.InsertarCopiaBd(nombreBd, subCarpeta, nombreRespaldo);
        }

        private void pictureBox_BuscarRuta_Click(object sender, EventArgs e)
        {
            obtenerRuta();
        }

        private void lbl_BuscarRuta_Click(object sender, EventArgs e)
        {
            obtenerRuta();
        }

        private void obtenerRuta()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_Ruta.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (procesoTerminado == true)
            {
                timer1.Stop();
                editarRutaCopiaBd();
                procesoTerminado = false;
            }
        }

        private void editarRutaCopiaBd()
        {
            LcopiaBd parametros = new LcopiaBd();
            DcopiaBd funcion = new DcopiaBd();

            parametros.ruta = textBox_Ruta.Text;
            if (funcion.EditarRutaCopiaBd(parametros) == true)
            {
                MessageBox.Show("Se ha creado la Copia de Seguridad", "Generacion de Copia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
