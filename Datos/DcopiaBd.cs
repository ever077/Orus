using Orus.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orus.Datos
{
    public class DcopiaBd
    {
        SqlCommand cmd = new SqlCommand();

        public bool InsertarCopiaBd(Lpersonal parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("insertar_copia_bd", ConexionMaestra.conectar);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Muestra el mensaje que figura en el procedimiento SQL
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionMaestra.cerrar();
            }
        }
    }
}
