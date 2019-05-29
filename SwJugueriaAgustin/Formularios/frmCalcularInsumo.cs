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
    public partial class frmCalcularInsumo : Form
    {
        public static bool cancelado;
        public frmCalcularInsumo()
        {
            InitializeComponent();
        }

        private void frmCalcularInsumo_Load(object sender, EventArgs e)
        {
            
            txtcantidadPro.Text = "0";
            txtGasto.Text = "0";
            txtcantidadPro.Focus();
            
        }

        private void txtcantidadPro_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtGasto.Focus();
            }
        }

        private void txtGasto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                aceptar();
            }
            
        }

        private void aceptar()
        {
            try
            {
                if (Convert.ToSingle(txtcantidadPro.Text) <= 0 || Convert.ToSingle(txtGasto.Text) <= 0)
                {
                    MessageBox.Show("No puede Especificar un valor '0' ó Negativo", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
                else
                {
                    cancelado = false;
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ingreso de Datos Incorrectos", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CalcularInsumo()
        {
            try
            {
                float cantidad = Convert.ToSingle(txtcantidadPro.Text);
                float gasto = Convert.ToSingle(txtGasto.Text);

                float gastoUni = (1 * gasto / cantidad);

                lblGastouni.Text = Math.Round(gastoUni,2).ToString();
            }
            catch(Exception ex)
            {
                if(txtcantidadPro.Text == ""||txtGasto.Text == "")
                {
                    
                }
                else
                {
                    MessageBox.Show(ex.Message, "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void txtcantidadPro_TextChanged(object sender, EventArgs e)
        {
            CalcularInsumo();
        }

        private void txtGasto_TextChanged(object sender, EventArgs e)
        {
            CalcularInsumo();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
            
        }

        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToSingle(txtcantidadPro.Text) > 0 || Convert.ToSingle(txtGasto.Text)>0)
                {
                    cancelado = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No puede Especificar la Cantidad '0'", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Ingreso de Datos Incorrectos", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
        }
    }
}
