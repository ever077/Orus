using System;
using System.Data;
using System.Data.SqlClient;

namespace Orus.Datos
{
    internal static class ConexionMaestra
    {
        //public static string conexion = "Data source=LAPTOP-PMUGS5GJ\\SQLEXPRESS; Initial catalog=ORUS; Integrated Security=true";
        public static string conexion = Convert.ToString(Logica.Desencriptacion.checkServer());
        public static SqlConnection conectar = new SqlConnection(conexion);

        public static void abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }

        public static void cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
