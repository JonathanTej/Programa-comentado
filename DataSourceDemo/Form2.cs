using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    public partial class Form2 : Form // Clase Form2 que hereda de Form, representando otro formulario de la aplicación.
    {
        public Form2()
        {
            InitializeComponent(); // Inicializa los componentes del formulario, como controles y eventos.
        }

        // Evento que se ejecuta cuando se hace clic en el botón para guardar datos de los clientes.
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate(); // Valida los datos del formulario.
            this.customersBindingSource.EndEdit(); // Finaliza la edición de los datos vinculados al origen de datos.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Actualiza la base de datos con los cambios realizados.
        }

        // Evento que se ejecuta cuando el formulario se carga.
        private void Form2_Load(object sender, EventArgs e)
        {
            // Carga los datos en la tabla 'northwindDataSet.Customers' al iniciar el formulario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Evento que se ejecuta cuando se hace clic en el cuadro de texto `cajaTextoID`.
        private void cajaTextoID_Click(object sender, EventArgs e)
        {
            // Método actualmente vacío, puede ser utilizado para implementar alguna funcionalidad específica cuando se hace clic en el cuadro de texto.
        }

        // Evento que se ejecuta cuando se presiona una tecla en el cuadro de texto `cajaTextoID`.
        private void cajaTextoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Si se presiona la tecla Enter (código ASCII 13).
            {
                // Busca el índice del cliente en el origen de datos utilizando el valor de `cajaTextoID`.
                var index = customersBindingSource.Find("customerID", cajaTextoID.Text);

                if (index > -1) // Si se encuentra el cliente.
                {
                    customersBindingSource.Position = index; // Establece la posición del origen de datos en el cliente encontrado.
                    return;
                }
                else
                {
                    MessageBox.Show("Elemento no encontrado"); // Muestra un mensaje si no se encuentra el cliente.
                }
            }
        }
    }
}
