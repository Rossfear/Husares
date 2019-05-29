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
    
    public partial class frmAddCantidad : Form
    {
        public bool Cancelado;
        public string idPresentacion;
        public frmAddCantidad()
        {
            InitializeComponent();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double cantidad = Convert.ToDouble(txtCantidad.Text);
                if (string.IsNullOrWhiteSpace(txtCantidad.Text) == false)
                {

                    Cancelado = false;
                    this.Close();
                }
            }
            catch
            { }


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "2";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "3";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "4";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "7";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "8";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "9";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancelado = true;
            this.Close();
        }



        private void frmAddCantidad_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            FrmAddIngredintes frm = new FrmAddIngredintes();
            frm.idPresentacion = idPresentacion;
            frm.ShowDialog();

            if (frm.Cancelado == false)
            {
                txtDescr.Text = frm.txtProducto.Text;
            }
        }

        private void pbx1_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "1";
        }

        private void pbx2_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "2";
        }

        private void pbx3_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "3";
        }

        private void pbx4_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "4";
        }

        private void pbx5_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "5";
        }

        private void pbx6_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "6";
        }

        private void pbx7_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "7";
        }

        private void pbx8_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "8";
        }

        private void pbx9_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "9";
        }

        private void pbxAsterisco_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += ".";
        }

        private void pbx0_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "0";
        }

        private void pbxNumeral_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                txtCantidad.Text = txtCantidad.Text.Remove(txtCantidad.TextLength - 1, 1);
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double cantidad = Convert.ToDouble(txtCantidad.Text);
                    if (string.IsNullOrWhiteSpace(txtCantidad.Text) == false)
                    {
                        Cancelado = false;
                        this.Close();
                    }
                }
                catch
                { }
            }
        }
    }
}
