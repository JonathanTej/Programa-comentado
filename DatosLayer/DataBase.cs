using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;  // Biblioteca para manejar configuraciones, como cadenas de conexión
using System.Xml.Linq;
using System.Data.SqlClient;  // Biblioteca para manejar conexiones a bases de datos SQL
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    public class DataBase
    {
        // Propiedad estática que devuelve la cadena de conexión configurada con posibles ajustes dinámicos.
        public static string ConnectionString
        {
            get
            {
                // Obtener la cadena de conexión del archivo de configuración usando la clave "NWConnection"
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Utiliza SqlConnectionStringBuilder para modificar aspectos específicos de la cadena de conexión
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Si ApplicationName está configurado, reemplaza el valor en la cadena de conexión
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Si ConnectionTimeout tiene un valor mayor a 0, lo usa, si no, mantiene el valor original
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Devuelve la cadena de conexión completa como una cadena
                return conexionBuilder.ToString();
            }
        }

        // Propiedad para establecer o obtener el tiempo de espera de la conexión (en segundos)
        public static int ConnectionTimeout { get; set; }

        // Propiedad para establecer o obtener el nombre de la aplicación que utiliza la conexión
        public static string ApplicationName { get; set; }

        // Método estático que abre una nueva conexión SQL usando la cadena de conexión configurada
        public static SqlConnection GetSqlConnection()
        {
            // Crea una nueva conexión SQL usando la cadena de conexión obtenida de la propiedad ConnectionString
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión
            conexion.Open();

            // Devuelve la conexión abierta
            return conexion;
        }
    }
}
