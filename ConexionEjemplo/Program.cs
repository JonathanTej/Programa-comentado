using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionEjemplo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread] // Indica que el modelo de subprocesos de la aplicación es STA (Single Threaded Apartment), necesario para aplicaciones de Windows Forms.
        static void Main()
        {
            // Habilita estilos visuales para la aplicación, asegurando que la UI utilice el estilo del sistema operativo actual.
            Application.EnableVisualStyles();

            // Establece que las formas y controles de Windows Forms usen el motor de renderizado de texto compatible.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicación y muestra el formulario principal `Form1`.
            Application.Run(new Form1());
        }
    }
}
