using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Punto_de_Venta
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.          new Login.Login()
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login.Login());
        }
    }
}
