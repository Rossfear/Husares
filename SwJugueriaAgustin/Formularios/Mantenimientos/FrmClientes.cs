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

namespace SwJugueriaAgustin.Formularios
{
    public partial class FrmClientes : Form
    {
        bool update;
        string idCliente;
        string numero;
        Funciones fn = new Funciones();
        public FrmClientes()
        {
            InitializeComponent();

            KeyPreview = true;

            KeyDown += FrmTipoCambio_KeyDown;
        }

        private void FrmTipoCambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                enable(false);
                clean();
            }
        }


        private void showData()
        {
            fn.ActualizarGrid(dgvComprobante, "select c.IDCliente as Codigo,c.Nombre,c.Numero,c.Telefono,c.Telefono2,c.Direccion,c.Referencia from Cliente c where Nombre like '%" + txtBuscar.Text + "%' order by IDCliente desc");
        }

        void enable(bool state)
        {
            gbxDatos.Enabled = state;
            btnGuardar.Enabled = state;
            btnNuevo.Enabled = !state;
            btnCancelar.Enabled = state;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            enable(true);
            txtnombre.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtnombre.Focus();
            }
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
            enable(false);
            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clean()
        {
            txttelefono.Text = "";
            txtnombre.Text = "";
            txtNroIdentidad.Text = "";
            txtTelefono2.Clear();
            txtDireccion.Clear();
            txtReferencia.Clear();

        }

        private void save()
        {
            if (update == true)
            {
                fn.Modificar("Cliente", "Nombre='" + txtnombre.Text.Trim() + "',Numero='" + txtNroIdentidad.Text.Trim() + "',Telefono='" + txttelefono.Text.Trim() + "',Telefono2='" + txtTelefono2.Text + "',Direccion='" + txtDireccion.Text.Trim() + "',Referencia='" + txtReferencia.Text.Trim() + "'", "IDCliente='" + idCliente + "'");
            }
            else
            {
                fn.RegistrarOficial("Cliente", "Nombre,Numero,Telefono,Telefono2,Direccion,Referencia",
                    "'" + txtnombre.Text.Trim() + "','" + txtNroIdentidad.Text.Trim() + "','" + txttelefono.Text + "','" + txtTelefono2.Text + "','" + txtDireccion.Text.Trim() + "','" + txtReferencia.Text.Trim() + "'");
            }

            update = false;
        }

        private bool validationSave()
        {
            if (string.IsNullOrEmpty(txtnombre.Text) == true)
            {
                MessageBox.Show("Especifique Cliente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnombre.Focus();
                return false;
            }








            if (update == true)
            {
                DialogResult msj = MessageBox.Show("Desea Actualizar los datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msj == DialogResult.Cancel)
                {
                    return false;
                }

                if (numero != txtNroIdentidad.Text)
                {
                    if (fn.Existencia("*", "Cliente", "Numero = '" + txtNroIdentidad.Text + "'") == true && string.IsNullOrWhiteSpace(txtNroIdentidad.Text) == false)
                    {
                        MessageBox.Show("Cliente ya se encuentra Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            else
            {
                if (fn.Existencia("*", "Cliente", "Numero = '" + txtNroIdentidad.Text + "'") == true && string.IsNullOrWhiteSpace(txtNroIdentidad.Text) == false)
                {
                    MessageBox.Show("Cliente ya se encuentra Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                update = true;
                txtnombre.Text = dgvComprobante.CurrentRow.Cells["Nombre"].Value.ToString();
                numero = dgvComprobante.CurrentRow.Cells["Numero"].Value.ToString();
                txtNroIdentidad.Text = numero;
                txttelefono.Text = dgvComprobante.CurrentRow.Cells["Telefono"].Value.ToString();
                txtTelefono2.Text = dgvComprobante.CurrentRow.Cells["Telefono2"].Value.ToString();
                txtDireccion.Text = dgvComprobante.CurrentRow.Cells["Direccion"].Value.ToString();
                txtReferencia.Text = dgvComprobante.CurrentRow.Cells["Referencia"].Value.ToString();
                idCliente = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
                enable(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void dtpBuscar_ValueChanged(object sender, EventArgs e)
        {
            showData();
        }

        private void FrmTipoCambio_Load_1(object sender, EventArgs e)
        {
            enable(false);
            showData();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            update = false;
            enable(false);
            clean();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            showData();
        }

        private void eLIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar Cliente Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (msj == DialogResult.OK)
            {
                fn.Eliminar("Cliente", "IDCliente='" + dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString() + "'");
                showData();
            }
        }
    }
}
