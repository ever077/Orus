using Orus.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Orus.Datos
{
    public class DcopiaBd
    {
        SqlCommand cmd;

        public void MostrarNombreBd(ref string nombreBd)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("mostrar_nombre_bd", ConexionMaestra.conectar);
                nombreBd = Convert.ToString(cmd.ExecuteScalar());
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

        public bool InsertarCopiaBd(string nombreBd, string subCarpeta, string nombreRespaldo)
        {
            try
            {
                /* ---> Hace el Backup manual.
                   ConexionMaestra.abrir();
                   cmd = new SqlCommand("BACKUP DATABASE " + nombreBd + " TO DISK = '" + subCarpeta + @"\" + nombreRespaldo + "'", ConexionMaestra.conectar);
                   cmd.ExecuteNonQuery();
                   return true;
                */
                
                // ---> Hace el Backup mediante una procedura.
                ConexionMaestra.abrir();
                cmd = new SqlCommand("sp_insertar_copia_bd", ConexionMaestra.conectar);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_bd", nombreBd);
                cmd.Parameters.AddWithValue("@Sub_carpeta", subCarpeta);
                cmd.Parameters.AddWithValue("@Nombre_respaldo", nombreRespaldo);
                cmd.ExecuteNonQuery();
                return true;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                ConexionMaestra.cerrar();
            }
        }

        public bool RestaurarBd(LcopiaBd parametros, string nombreBd, string servidor)
        {
            SqlConnection conexion = new SqlConnection("Server=" + servidor + "; database=master; integrated security=yes");
            string proceso = "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'" + nombreBd + "' USE [master] ALTER DATABASE [" + nombreBd + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [" + nombreBd + "] RESTORE DATABASE " + nombreBd + " FROM DISK = N'" + parametros.ruta + "' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10";
            try
            {
                conexion.Open();
                cmd = new SqlCommand(proceso, conexion);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public bool InsertarRutaCopiaBd(LcopiaBd parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("insertar_ruta_copia_bd", ConexionMaestra.conectar);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ruta", parametros.ruta);
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
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                ConexionMaestra.cerrar();
            }
        }

        public bool EditarRutaCopiaBd(LcopiaBd parametros)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("editar_ruta_copia_bd", ConexionMaestra.conectar);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ruta", parametros.ruta);
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
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                ConexionMaestra.cerrar();
            }
        }

        public void MostrarRutaCopiaBd(ref string ruta)
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("select Ruta from CopiaBd", ConexionMaestra.conectar);
                ruta = Convert.ToString(cmd.ExecuteScalar());
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

        public int obtenerEdicionDeSql()
        {
            try
            {
                ConexionMaestra.abrir();
                cmd = new SqlCommand("select serverproperty('EditionID')", ConexionMaestra.conectar);
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
    }
}
