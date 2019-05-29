using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class FrmContraseña : Form
    {
        Funciones fn = new Funciones();
        public bool cancel = true;
        string contraseña;
        public FrmContraseña()
        {
            InitializeComponent();
        }

        private void FrmContraseña_Load(object sender, EventArgs e)
        {
            contraseña = fn.selectValue("select ContraseñaSeguridad from DatosImpresion");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(contraseña == txtPAss.Text)
            {
                cancel = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPAss.Focus();
            }
        }

        private void txtPAss_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (contraseña == txtPAss.Text)
                {
                    cancel = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPAss.Focus();
                }
            }
        }
    }
}
