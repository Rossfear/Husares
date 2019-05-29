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
    public partial class FrmCambiarPass : Form
    {
        Funciones fn = new Funciones(); 
        public FrmCambiarPass()
        {
            InitializeComponent();
        }

        private void FrmCambiarPass_Load(object sender, EventArgs e)
        {
            lblusuario.Text = Datos.Usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passActual = fn.selectValue("select contraseña from usuario where idusuario = '" + Datos.idUsuario + "'");

            if(txtpassActual.Text != passActual)
            {
                MessageBox.Show("Contraseña Actual Incorrecta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(txtconfrimar.Text != txtnueva.Text)
            {
                MessageBox.Show("Contraseñas no coinciden", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            fn.Modificar("Usuario", "Contraseña='" + txtnueva.Text + "'", "IDUsuario='" + Datos.idUsuario + "'");
            MessageBox.Show("Contraseña Actualizada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
