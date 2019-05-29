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

namespace SwJugueriaAgustin.Formularios.Mantenimientos
{
    public partial class FrmSucursal : Form
    {
        bool update;
        string ID;
        Funciones fn = new Funciones();

        public FrmSucursal()
        {
            InitializeComponent();

            KeyPreview = true;

            KeyDown += FrmTipoComprobante_KeyDown;
        }

        private void FrmTipoComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                enable(false);
                clean();
            }
        }

        private void FrmTipoComprobante_Load(object sender, EventArgs e)
        {
            enable(false);
            showData();
        }

        private void showData()
        {
            fn.ActualizarGrid(dgvDocumento, "select * from Sucursal where Sucursal like '%" + txtBuscar.Text + "%' order by IDSucursal desc");
            dgvDocumento.Columns["IDSucursal"].Visible = false;
        }

        void enable(bool state)
        {
            gbxDatos.Enabled = state;
            btnGuardar.Enabled = state;
            btnNuevo.Enabled = !state;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            enable(true);
            txtSucursal.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validationSave() == false)
            {
                return;
            }

            save();

            endSave();


        }

        private void endSave()
        {
            clean();
            showData();
            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clean()
        {
            txtSucursal.Text = "";
            txtDireccion.Text = "";
            txtResponsable.Text = "";
            txtSucursal.Text = "";
            txtTelefono.Text = "";
        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("Sucursal", "Sucursal='" + txtSucursal.Text + "',Responsable='"+txtResponsable.Text+ "',Direccion='"+txtDireccion.Text+ "',Telefono='"+txtTelefono.Text+"'",
                        "IDSucursal='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("Sucursal", "Sucursal,Responsable,Direccion,Telefono",
                        "'" + txtSucursal.Text + "','"+txtResponsable.Text+"','"+ txtDireccion.Text+ "','"+txtTelefono.Text+"'");
                }

                update = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private bool validationSave()
        {
            if (string.IsNullOrWhiteSpace(txtSucursal.Text) == true)
            {
                MessageBox.Show("Especificar Sucursal", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSucursal.Focus();
                return false;
            }

           


            DialogResult msj;

            if (update == true)
            {
                msj = MessageBox.Show("Desea Actualizar los datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                msj = MessageBox.Show("Desea Registrar los datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            if (msj == DialogResult.Cancel)
            {
                return false;
            }


            return true;
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                update = true;
                ID = dgvDocumento.CurrentRow.Cells["IDSucursal"].Value.ToString();
                txtSucursal.Text= dgvDocumento.CurrentRow.Cells["Sucursal"].Value.ToString();
                txtResponsable.Text = dgvDocumento.CurrentRow.Cells["Responsable"].Value.ToString();
                txtDireccion.Text = dgvDocumento.CurrentRow.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = dgvDocumento.CurrentRow.Cells["Telefono"].Value.ToString();

                enable(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            showData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            update = false;
            enable(false);
            clean();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar la Sucursal", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if(msj == DialogResult.OK)
            {
                ID = dgvDocumento.CurrentRow.Cells["IDSucursal"].Value.ToString();

                fn.Eliminar("Sucursal", "IDSucursal='" + ID + "'");
                showData();
            }
        }
    }
}
