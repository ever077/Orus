using Orus.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
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
                da.SelectCommand.CommandTimeout = 120;
                da.Fill(dt);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(ex.StackTrace + "\n\n" + ex.Message);
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

        public int contarUsuarios()
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("SELECT COUNT(Id_usuario) FROM Usuario", ConexionMaestra.conectar);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
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

        public void VerificarUsuario(ref string indicador)
        {
            try
            {
                int idUser;
                ConexionMaestra.abrir();
                SqlCommand da = new SqlCommand("Select Id_usuario From Usuario", ConexionMaestra.conectar);
                idUser = Convert.ToInt32(da.ExecuteScalar());
                indicador = "Correcto";
            }
            catch (Exception)
            {
                indicador = "Incorrecto";
            }
            finally
            {
                if (indicador == "Correcto")
                {
                    ConexionMaestra.cerrar();
                }
            }
        }

        public void ValidarUsuario(Lusuario parametros, ref int id)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("validar_usuario", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Password", parametros.Password);
                cmd.Parameters.AddWithValue("@Login", parametros.Login);
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                id = 0;
            }
            finally
            {
                ConexionMaestra.cerrar();
            }
        }

        public bool RestaurarUsuario(Lusuario parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("restaurar_usuario", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_usuario", parametros.Id_usuario);
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

        public bool EditarUsuario(Lusuario parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("editar_usuario", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_usuario", parametros.Id_usuario);
                cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                cmd.Parameters.AddWithValue("@Login", parametros.Login);
                cmd.Parameters.AddWithValue("@Password", parametros.Password);
                cmd.Parameters.AddWithValue("@Icono", parametros.Icono);
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

        public bool EliminarUsuario(Lusuario parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("eliminar_usuario", ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_usuario", parametros.Id_usuario);
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

        public void buscarUsuarios(ref DataTable dt, string buscador)
        {
            try
            {
                ConexionMaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_usuario_nombre", ConexionMaestra.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                da.SelectCommand.CommandTimeout = 100;
                da.Fill(dt);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(ex.StackTrace + "\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n\n" + ex.Message);
            }
            finally
            {
                ConexionMaestra.cerrar();
            }
        }
    }
}
