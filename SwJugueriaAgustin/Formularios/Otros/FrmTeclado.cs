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
    public partial class FrmTeclado : Form
    {
        public bool cancelado = true;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }

        public FrmTeclado()
        {
            InitializeComponent();
        }
       

        private void FrmClientesTactil_Load(object sender, EventArgs e)
        {

        }
        
        private void btnQ_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SendKeys.Send(btn.Text);
            //txtTexto.Text += btn.Text;

        }

        private void button40_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SendKeys.Send(" ");
            //txtTexto.Text += btn.Text;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            cancelado = false;
            this.Close();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DELETE}");
            //int c = txtTexto.TextLength - 1;
            //string text = "";
            //for (int i = 0; i < c; i++)
            //{
            //    text += txtTexto.Text[i];
            //}
            //txtTexto.Text = text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelado = true;
            this.Close();
        }
    }
}
