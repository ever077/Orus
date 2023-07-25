using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orus.Datos
{
    public class Dmodulo
    {
        public void MostrarModulos(ref DataTable dt)
        {
			SqlCommand cmd = new SqlCommand();

			try
			{
				ConexionMaestra.abrir();
				SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Modulo", ConexionMaestra.conectar);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace);
			}
			finally
			{
				ConexionMaestra.cerrar();
			}
        }
    }
}
