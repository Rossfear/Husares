    using SwJugueriaAgustin.FormAdmin;
using SwJugueriaAgustin.Formularios;
using SwJugueriaAgustin.Formularios.Apariencia;
using SwJugueriaAgustin.Formularios.Operaciones;
using SwJugueriaAgustin.Formularios.Reportes;
using SwJugueriaAgustin.Formularios.Venta.Caja;
using SwJugueriaAgustin.Formularios.Venta.Delivery;
using SwJugueriaAgustin.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin
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
            Application.Run(new FrmLoginAdmin());
            //Application.Run(new FrmLoginVenta());//FrmLoginAdmin FrmLoginAdmin
        }
    }
}
