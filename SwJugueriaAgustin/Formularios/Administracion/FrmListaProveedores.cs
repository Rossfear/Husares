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
    public partial class FrmListaProveedores : Form
    {
        Funciones fn = new Funciones();
        public bool cancel = true;
        public FrmListaProveedores()
        {
            InitializeComponent();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void mostrarGrid()
        {
            fn.ActualizarGrid(dgvListaProveedores, "select top(10) IDProveedor,Numero,RazonSocial from proveedor where RazonSocial like '%"+txtBuscar.Text+"%'");
            dgvListaProveedores.Columns["IDProveedor"].Visible = false;
        }

        private void FrmListaProveedores_Load(object sender, EventArgs e)
        {
            txtBuscar.Focus();
        }

        private void dgvListaProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvListaProveedores.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione Proveedor", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cancel = false;
            this.Close();
        }
    }
}
