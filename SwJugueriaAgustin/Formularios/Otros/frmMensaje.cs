using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class frmMensaje : Form
    {
        public frmMensaje()
        {
            InitializeComponent();
        }

        private void frmMensaje_Load(object sender, EventArgs e)
        {
            tmrCierre.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tmrCierre.Stop();
            this.Close();
        }
    }
}
