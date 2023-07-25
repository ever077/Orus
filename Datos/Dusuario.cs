using Orus.Logica;
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
    public class Dusuario
    {
        SqlCommand cmd = new SqlCommand();

        public bool InsertarUsuario(Lusuario parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("insertar_usuario", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                cmd.Parameters.AddWithValue("@Login", parametros.Login);
                cmd.Parameters.AddWithValue("@Password", parametros.Password);
                cmd.Parameters.AddWithValue("@Icono", parametros.Icono);
                cmd.ExecuteNonQuery();
                return true;
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

        public void MostrarUsuario(ref DataTable dt)
        {
            try
            {
                ConexionMaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from Usuario", ConexionMaestra.conectar);
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

        public void ObtenerIdUsuario(ref int idUsuario, string Login)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("obtener_id_usuario", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login", Login);
                idUsuario = Convert.ToInt32(cmd.ExecuteScalar());
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
