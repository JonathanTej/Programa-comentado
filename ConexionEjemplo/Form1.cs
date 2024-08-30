using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosLayer;  // Se importa la capa de datos donde se maneja la conexión y operaciones con la base de datos.
using System.Net;
using System.Reflection;

namespace ConexionEjemplo
{
    public partial class Form1 : Form  // Se define la clase Form1 que hereda de Form, representando el formulario principal.
    {
        // Se crea una instancia del repositorio de clientes para manejar las operaciones de datos.
        CustomerRepository customerRepository = new CustomerRepository();

        public Form1()
        {
            InitializeComponent();  // Inicializa los componentes del formulario, como controles y eventos.
        }

        // Evento que se ejecuta cuando se presiona el botón 'Cargar'.
        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Obtiene todos los clientes a través del repositorio.
            var Customers = customerRepository.ObtenerTodos();
            // Asigna los datos obtenidos al DataGrid para mostrarlos en la interfaz.
            dataGrid.DataSource = Customers;
        }

        // Evento que se ejecuta cuando cambia el texto en el TextBox.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Código comentado para filtrar los clientes basados en el texto ingresado en el TextBox.
            // var filtro = Customers.FindAll( X => X.CompanyName.StartsWith(tbFiltro.Text));
            // dataGrid.DataSource = filtro;
        }

        // Evento que se ejecuta cuando el formulario se carga.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Código comentado que configura la base de datos y obtiene la conexión.
            /*  DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
                DatosLayer.DataBase.ConnectionTimeout = 30;
                string cadenaConexion = DatosLayer.DataBase.ConnectionString;
                var conxion = DatosLayer.DataBase.GetSqlConnection();
            */
        }

        // Evento que se ejecuta cuando se presiona el botón 'Buscar'.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Busca un cliente por su ID usando el repositorio.
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);
            // Asigna los datos del cliente a los TextBox correspondientes.
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text = cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;
        }

        // Evento que se ejecuta cuando se hace clic en el label4 (generalmente se ignora).
        private void label4_Click(object sender, EventArgs e)
        {
            // Este método no tiene funcionalidad en el código proporcionado.
        }

        // Evento que se ejecuta cuando se presiona el botón 'Insertar'.
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0;  // Variable para almacenar el resultado de la operación de inserción.

            // Se obtiene un nuevo cliente desde los controles del formulario.
            var nuevoCliente = ObtenerNuevoCliente();

            // Código comentado para validar si los campos están completos y luego insertar.
            /*  if (tboxCustomerID.Text != "" || 
                  tboxCompanyName.Text !="" ||
                  tboxContacName.Text != "" ||
                  tboxContacName.Text != "" ||
                  tboxAddress.Text != ""    ||
                  tboxCity.Text != "")
              {
                  resultado = customerRepository.InsertarCliente(nuevoCliente);
                  MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
              }
              else {
                  MessageBox.Show("Debe completar los campos por favor");
              }
            */

            // Código comentado para validar cada campo individualmente.
            /*
            if (nuevoCliente.CustomerID == "") {
                MessageBox.Show("El Id en el usuario debe de completarse");
                return;    
            }

            if (nuevoCliente.ContactName == "")
            {
                MessageBox.Show("El nombre de usuario debe de completarse");
                return;
            }
            
            if (nuevoCliente.ContactTitle == "")
            {
                MessageBox.Show("El contacto de usuario debe de completarse");
                return;
            }
            if (nuevoCliente.Address == "")
            {
                MessageBox.Show("la direccion de usuario debe de completarse");
                return;
            }
            if (nuevoCliente.City == "")
            {
                MessageBox.Show("La ciudad de usuario debe de completarse");
                return;
            }

            */

            // Valida si algún campo es nulo antes de insertar el nuevo cliente.
            if (validarCampoNull(nuevoCliente) == false)
            {
                // Si no hay campos nulos, se inserta el cliente en la base de datos.
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
            }
            else
            {
                // Si hay campos nulos, se muestra un mensaje de advertencia.
                MessageBox.Show("Debe completar los campos por favor");
            }
        }

        // Método que valida si algún campo de un objeto es nulo.
        public Boolean validarCampoNull(Object objeto)
        {
            // Itera sobre todas las propiedades del objeto.
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                // Obtiene el valor de la propiedad.
                object value = property.GetValue(objeto, null);
                // Si alguna propiedad es una cadena vacía, retorna true.
                if ((string)value == "")
                {
                    return true;
                }
            }
            // Si ninguna propiedad es nula o vacía, retorna false.
            return false;
        }

        // Evento que se ejecuta cuando se hace clic en el label5 (generalmente se ignora).
        private void label5_Click(object sender, EventArgs e)
        {
            // Este método no tiene funcionalidad en el código proporcionado.
        }

        // Evento que se ejecuta cuando se presiona el botón 'Modificar'.
        private void btModificar_Click(object sender, EventArgs e)
        {
            // Se obtiene el cliente actualizado desde los controles del formulario.
            var actualizarCliente = ObtenerNuevoCliente();
            // Se actualiza el cliente en la base de datos y se obtiene el número de filas afectadas.
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente);
            // Muestra un mensaje con la cantidad de filas actualizadas.
            MessageBox.Show($"Filas actualizadas = {actualizadas}");
        }

        // Método que obtiene un nuevo cliente basado en los valores de los TextBox.
        private Customers ObtenerNuevoCliente()
        {
            // Crea una nueva instancia de 'Customers' con los datos de los TextBox.
            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            return nuevoCliente;  // Retorna el nuevo cliente.
        }

        // Evento que se ejecuta cuando se presiona el botón 'Eliminar'.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Elimina el cliente especificado por su ID y obtiene el número de filas eliminadas.
            int elimindas = customerRepository.EliminarCliente(tboxCustomerID.Text);
            // Muestra un mensaje con la cantidad de filas eliminadas.
            MessageBox.Show("Filas eliminadas = " + elimindas);
        }
    }
}
