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

namespace SwJugueriaAgustin.Formularios.Compra
{
    public partial class FrmSolicitarEliminacionC : Form
    {
        public string idCompra;
        Funciones fn = new Funciones();
        public FrmSolicitarEliminacionC()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSolicitarEliminacionC_Load(object sender, EventArgs e)
        {

        }

        private void btnSolicitarAnulacion_Click(object sender, EventArgs e)
        {
            if(validacionSolicitud() == false)
            {
                return;
            }
           

            fn.RegistrarOficial("CompraObservacion", "FechaSolicitud,IDCompra,Observacion,IDEmpleado,Atendido","'"+DateTime.Now.ToShortDateString()+"','"+idCompra+"','"+txtMotivo.Text.Trim()+"','"+Datos.idUsuario+"','False'");
            MessageBox.Show("Solicitud Enviada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private bool validacionSolicitud()
        {
            if (string.IsNullOrEmpty(txtMotivo.Text) == true)
            {
                MessageBox.Show("Especifique Motivo de Anulacion", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return false;
            }

            if(fn.Existencia("*", "CompraObservacion","IDCompra='"+idCompra+"' and Atendido='False'") == true)
            {
                MessageBox.Show("La Compra ya se Encuentra solicitada Para Anulación", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            return true;

        }
    }
}
