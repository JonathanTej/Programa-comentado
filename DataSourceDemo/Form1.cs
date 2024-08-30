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
    public partial class Form1 : Form  // Clase Form1 que hereda de Form, representando el formulario principal de la aplicación.
    {
        public Form1()
        {
            InitializeComponent();  // Inicializa los componentes del formulario, como controles y eventos.
        }

        // Evento que se ejecuta cuando se hace clic en el botón para guardar datos de los clientes (versión 1).
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();  // Valida los datos del formulario.
            this.customersBindingSource.EndEdit();  // Finaliza la edición de los datos vinculados al origen de datos.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);  // Actualiza la base de datos con los cambios realizados.
        }

        // Evento que se ejecuta cuando se hace clic en el botón para guardar datos de los clientes (versión 2).
        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();  // Valida los datos del formulario.
            this.customersBindingSource.EndEdit();  // Finaliza la edición de los datos vinculados al origen de datos.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);  // Actualiza la base de datos con los cambios realizados.
        }

        // Evento que se ejecuta cuando se hace clic en el botón para guardar datos de los clientes (versión 3).
        private void customersBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();  // Valida los datos del formulario.
            this.customersBindingSource.EndEdit();  // Finaliza la edición de los datos vinculados al origen de datos.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);  // Actualiza la base de datos con los cambios realizados.
        }

        // Evento que se ejecuta cuando el formulario se carga.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Carga los datos en la tabla 'northwindDataSet.Customers' al iniciar el formulario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Evento que se ejecuta cuando se hace clic en una celda del DataGridView de clientes.
        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Este método está vacío, pero se puede utilizar para manejar eventos al hacer clic en celdas específicas.
        }
    }
}
