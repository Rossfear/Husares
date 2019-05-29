using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Apariencia
{
    public partial class FrmSeleccionEmpresa : Form
    {
        Funciones fn = new Funciones();
        public FrmSeleccionEmpresa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string servidorRemoto = ConfigurationManager.AppSettings["ServidorRemoto"];
            string baseHusares = ConfigurationManager.AppSettings["baseHusares"];


            fn.cambiarConexion("Data Source=" + servidorRemoto + ";Initial Catalog=" + baseHusares + ";Uid=innovated;Pwd=123");



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string servidorRemoto = ConfigurationManager.AppSettings["ServidorRemoto"];
            string baseGolf = ConfigurationManager.AppSettings["baseGolf"];
            

            fn.cambiarConexion("Data Source="+servidorRemoto+";Initial Catalog=" + baseGolf + ";Uid=innovated;Pwd=123");
        }
    }
}
