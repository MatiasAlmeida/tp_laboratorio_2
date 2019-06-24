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

        /// <summary>
        /// Metodo que inserta los datos del paquete agregado en la base de datos correo-sp-2017.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Constructor de clase de PaqueteDAO que inicializa las conexiones con la base de datos MySQL.
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.Conexion_bd);
            comando = new SqlCommand();
            comando.Connection = conexion;
        }
    }
}
