using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Administracion
{
    public partial class FModificarCajaAdmin : Form
    {
        Funciones fn = new Funciones();
        public FModificarCajaAdmin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Actualizar los datos","FactuTED",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if(msj == DialogResult.OK)
            {
                string estado = rbtnAbrir.Checked ? "ABIERTA" : "CERRADA";
                fn.Modificar("RegistroAdministracion","Mes='"+cbxMes.Text+"',Año='"+txtAño.Text+"',Estado='"+estado+"',SaldoInicial='"+txtSaldoInicial.Text+"',SaldoReal='"+txtSaldoReal.Text+"',IDUsuario='"+ Datos.idUsuario+ "'","IDRegistroAdministracion='"+txtCodigo.Text+"'");
                MessageBox.Show("Datos modificados");
                this.Close();
            }
        }
    }
}
