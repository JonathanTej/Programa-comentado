using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Clase que maneja la lógica de acceso a datos para la tabla "Customers"
    public class CustomerRepository
    {
        // Método para obtener todos los registros de la tabla "Customers"
        public List<Customers> ObtenerTodos()
        {
            // Usando una conexión SQL obtenida de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construcción de la consulta SQL para seleccionar todos los campos de la tabla "Customers"
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [CustomerID] " + "\n";
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Customers]";

                // Creación de un comando SQL con la consulta y la conexión
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    // Ejecución del comando y obtención de un SqlDataReader para leer los resultados
                    SqlDataReader reader = comando.ExecuteReader();
                    // Lista para almacenar los registros obtenidos
                    List<Customers> Customers = new List<Customers>();

                    // Iterar sobre los registros obtenidos
                    while (reader.Read())
                    {
                        // Leer los datos del lector y convertirlos en un objeto "Customers"
                        var customers = LeerDelDataReader(reader);
                        // Añadir el objeto a la lista
                        Customers.Add(customers);
                    }
                    // Retornar la lista de registros
                    return Customers;
                }
            }
        }

        // Método para obtener un registro específico de la tabla "Customers" por su ID
        public Customers ObtenerPorID(string id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construcción de la consulta SQL con un parámetro para el ID del cliente
                String selectForID = "";
                selectForID = selectForID + "SELECT [CustomerID] " + "\n";
                selectForID = selectForID + "      ,[CompanyName] " + "\n";
                selectForID = selectForID + "      ,[ContactName] " + "\n";
                selectForID = selectForID + "      ,[ContactTitle] " + "\n";
                selectForID = selectForID + "      ,[Address] " + "\n";
                selectForID = selectForID + "      ,[City] " + "\n";
                selectForID = selectForID + "      ,[Region] " + "\n";
                selectForID = selectForID + "      ,[PostalCode] " + "\n";
                selectForID = selectForID + "      ,[Country] " + "\n";
                selectForID = selectForID + "      ,[Phone] " + "\n";
                selectForID = selectForID + "      ,[Fax] " + "\n";
                selectForID = selectForID + "  FROM [dbo].[Customers] " + "\n";
                selectForID = selectForID + $"  WHERE CustomerID = @customerId";

                // Creación de un comando SQL con la consulta y la conexión
                using (SqlCommand comando = new SqlCommand(selectForID, conexion))
                {
                    // Asignación del parámetro ID en el comando
                    comando.Parameters.AddWithValue("customerId", id);

                    // Ejecución del comando y obtención de un SqlDataReader para leer los resultados
                    var reader = comando.ExecuteReader();
                    Customers customers = null;

                    // Si se encuentra un registro, leer los datos y convertirlos en un objeto "Customers"
                    if (reader.Read())
                    {
                        customers = LeerDelDataReader(reader);
                    }
                    // Retornar el objeto "Customers" correspondiente al ID, o null si no se encontró
                    return customers;
                }
            }
        }

        // Método para leer un registro del SqlDataReader y convertirlo en un objeto "Customers"
        public Customers LeerDelDataReader(SqlDataReader reader)
        {
            Customers customers = new Customers();
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"];
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];
            return customers;
        }

        // Método para insertar un nuevo registro en la tabla "Customers"
        public int InsertarCliente(Customers customer)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construcción de la consulta SQL para insertar un nuevo registro en "Customers"
                String insertInto = "";
                insertInto = insertInto + "INSERT INTO [dbo].[Customers] " + "\n";
                insertInto = insertInto + "           ([CustomerID] " + "\n";
                insertInto = insertInto + "           ,[CompanyName] " + "\n";
                insertInto = insertInto + "           ,[ContactName] " + "\n";
                insertInto = insertInto + "           ,[ContactTitle] " + "\n";
                insertInto = insertInto + "           ,[Address] " + "\n";
                insertInto = insertInto + "           ,[City]) " + "\n";
                insertInto = insertInto + "     VALUES " + "\n";
                insertInto = insertInto + "           (@CustomerID " + "\n";
                insertInto = insertInto + "           ,@CompanyName " + "\n";
                insertInto = insertInto + "           ,@ContactName " + "\n";
                insertInto = insertInto + "           ,@ContactTitle " + "\n";
                insertInto = insertInto + "           ,@Address " + "\n";
                insertInto = insertInto + "           ,@City)";

                // Creación de un comando SQL con la consulta y la conexión
                using (var comando = new SqlCommand(insertInto, conexion))
                {
                    // Llamada al método para añadir los parámetros y ejecutar la consulta
                    int insertados = parametrosCliente(customer, comando);
                    // Retornar el número de registros insertados
                    return insertados;
                }
            }
        }

        // Método para actualizar un registro existente en la tabla "Customers"
        public int ActualizarCliente(Customers customer)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construcción de la consulta SQL para actualizar un registro en "Customers" por ID
                String ActualizarCustomerPorID = "";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "UPDATE [dbo].[Customers] " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "   SET [CustomerID] = @CustomerID " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[CompanyName] = @CompanyName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactName] = @ContactName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactTitle] = @ContactTitle " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[Address] = @Address " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[City] = @City " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + " WHERE CustomerID= @CustomerID";

                // Creación de un comando SQL con la consulta y la conexión
                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion))
                {
                    // Llamada al método para añadir los parámetros y ejecutar la consulta
                    int actualizados = parametrosCliente(customer, comando);
                    // Retornar el
