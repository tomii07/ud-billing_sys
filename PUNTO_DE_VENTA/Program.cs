using System;
using System.Windows.Forms;

namespace PUNTO_DE_VENTA_CODIGO369_CSHARP
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new usuariosok());
            Application.Run(new MODULOS.LOGIN());
        }
    }
}
