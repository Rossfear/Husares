using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Operaciones
{
    public partial class FrmCargarMozo : Form
    {
        public static bool cancel;
        Funciones fn = new Funciones();
        public bool reimprimir = false;
        public string condicion = "";

        public FrmCargarMozo()
        {
            InitializeComponent();
            KeyPreview = true;

            KeyDown += FrmCargarMozo_KeyDown;
        }

        private void FrmCargarMozo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cancel = true;
                this.Close();
            }
        }

        private void FrmCargarMozo_Load(object sender, EventArgs e)
        {
            cancel = true;

            if (reimprimir == false)
            {
                fn.añadir_ddl("Usuario", "IDMozo", "mozo WHERE Administrador != 1 and CajaSalon != 1 and CajaDelivery != 1 and IDSucursal='"+Datos.idSucursal+ "' and Habilitado=1 " + condicion + " order by Usuario ", cboMozo);
            }
            else
            {
                fn.añadir_ddl("Usuario", "IDMozo", "mozo where Administrador = 1 and IDSucursal='"+Datos.idSucursal+"'", cboMozo);
            }

        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                accept();
            }

        }

        private void accept()
        {


            if (fn.Existencia("*", "Mozo", "Usuario='" + cboMozo.Text + "' and Pass='" + txtPass.Text + "' and Habilitado='True'") == true)
            {
                cancel = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.SelectAll();
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            accept();
        }

        private void cboMozo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtPass.Focus();
        }

        private void pbx1_Click(object sender, EventArgs e)
        {
            txtPass.Text += "1";
        }

        private void pbx2_Click(object sender, EventArgs e)
        {
            txtPass.Text += "2";
        }

        private void pbx3_Click(object sender, EventArgs e)
        {
            txtPass.Text += "3";
        }

        private void pbx4_Click(object sender, EventArgs e)
        {
            txtPass.Text += "4";
        }

        private void pbx5_Click(object sender, EventArgs e)
        {
            txtPass.Text += "5";
        }

        private void pbx6_Click(object sender, EventArgs e)
        {
            txtPass.Text += "6";
        }

        private void pbx7_Click(object sender, EventArgs e)
        {
            txtPass.Text += "7";
        }

        private void pbx8_Click(object sender, EventArgs e)
        {
            txtPass.Text += "8";
        }

        private void pbx9_Click(object sender, EventArgs e)
        {
            txtPass.Text += "9";
        }

        private void pbxAsterisco_Click(object sender, EventArgs e)
        {
            txtPass.Text += ".";
        }

        private void pbx0_Click(object sender, EventArgs e)
        {
            txtPass.Text += "0";
        }

        private void pbxNumeral_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != "")
            {
                txtPass.Text = txtPass.Text.Remove(txtPass.TextLength - 1, 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
