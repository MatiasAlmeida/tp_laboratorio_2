using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        public static bool Insertar(Paquete p)
        {
            bool flag = false;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO [correo-sp-2017].dbo.Paquetes" +
                                  "(direccionEntrega, trackingID, alumno)" +
                                  "values" +
                                  "('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Almeida, Matias')";

            try
            {
                conexion.Open();

                if (comando.ExecuteNonQuery() > 0)
                    flag = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }

            return flag;
        }

        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.Conexion_bd);
            comando = new SqlCommand();
            comando.Connection = conexion;
        }
    }
}
