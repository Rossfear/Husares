using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Mantenimientos.Entidades
{
    public partial class FrmMMozo : Form
    {
        bool update;
        string IDMozo;
        Funciones fn = new Funciones();
        public FrmMMozo()
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
            fn.ActualizarGrid(dgvComprobante, "select IDMozo as Codigo,S.IDSucursal,s.Sucursal,Nombres,Usuario,Pass,Habilitado,CajaSalon,CajaDelivery,Administrador  from Mozo m left join sucursal s on m.IDSucursal = s.IDSucursal where Nombres like '%" + txtBuscar.Text + "%' order by S.Sucursal desc");
            dgvComprobante.Columns["Pass"].Visible = false;
            dgvComprobante.Columns["IDSucursal"].Visible = false;
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
            txtNombre.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombre.Focus();
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
            txtContraseña.Text = "";
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtConfirmarPass.Text = "";
        }

        private void save()
        {
            if (update == true)
            {
                fn.Modificar("Mozo", "Nombres='" + txtNombre.Text.Trim() + "',Usuario='" + txtUsuario.Text.Trim() + "',Pass='" + txtContraseña.Text.Trim() + "',IDSucursal='"+cboSucursal.SelectedValue+"'", "IDMozo='" + IDMozo + "'");
            }
            else
            {
                fn.RegistrarOficial("Mozo", "Nombres,Usuario,Pass,Habilitado,IDSucursal,Administrador",
                    "'" + txtNombre.Text.Trim() + "','" + txtUsuario.Text.Trim() + "','" + txtContraseña.Text + "','True','"+cboSucursal.SelectedValue+"',0");
            }

            update = false;
        }

        private bool validationSave()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) == true)
            {
                MessageBox.Show("Especifique Nombre", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(txtUsuario.Text) == true || string.IsNullOrEmpty(txtContraseña.Text) == true)
            {
                MessageBox.Show("Especificar Usuario o Contraseña", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(txtConfirmarPass.Text != txtContraseña.Text)
            {
                MessageBox.Show("Las Contraseñas no Coinciden", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (update == false)
            {
                if (fn.Existencia("*", "Repartidor", "Nombres='" + txtNombre.Text + "'") == true)
                {
                    MessageBox.Show("El Repartidor ya Existe", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return false;
                }
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
                cboSucursal.Text = dgvComprobante.CurrentRow.Cells["Sucursal"].Value.ToString();
                txtNombre.Text = dgvComprobante.CurrentRow.Cells["Nombres"].Value.ToString();
                txtUsuario.Text = dgvComprobante.CurrentRow.Cells["Usuario"].Value.ToString();
                txtContraseña.Text = dgvComprobante.CurrentRow.Cells["Pass"].Value.ToString();
                cboSucursal.Text = dgvComprobante.CurrentRow.Cells["Sucursal"].Value.ToString();
                txtConfirmarPass.Text = txtContraseña.Text;
                IDMozo = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
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
            fn.CargarCombo("Sucursal", "IDSucursal", "Sucursal",cboSucursal);
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

        private void hABILITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idMozo = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
            fn.Modificar("Mozo", "Habilitado='True'", "IDMozo='" + idMozo + "'");
            showData();
        }

        private void dESHABILITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idMozo = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
            fn.Modificar("Mozo", "Habilitado='False'", "IDMozo='" + idMozo + "'");
            showData();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idMozo = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
            fn.Delete("Mozo", "IDMozo='" + idMozo + "'",true);
            showData();
        }

        private void cajeroPredeterminadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cajeroNOPredeterminadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ventaSalonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idMozo = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
            string idSucursal = dgvComprobante.CurrentRow.Cells["IDSucursal"].Value.ToString();

            fn.Modificar("Mozo", "CajaSalon='False'", "IDSucursal='"+idSucursal+"'");
            fn.Modificar("Mozo", "CajaSalon='True'", "IDMozo='" + idMozo + "'");
            showData();
        }

        private void ventaDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idMozo = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
            string idSucursal = dgvComprobante.CurrentRow.Cells["IDSucursal"].Value.ToString();

            fn.Modificar("Mozo", "CajaDelivery='False'", "IDSucursal = '"+idSucursal+"'");
            fn.Modificar("Mozo", "CajaDelivery='True'", "IDMozo='" + idMozo + "'");
            showData();
        }

        private void ventaSalonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string idMozo = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
            fn.Modificar("Mozo", "CajaSalon='False'", "IDMozo='" + idMozo + "'");
            showData();
        }

        private void ventaDeliveryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string idMozo = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
            fn.Modificar("Mozo", "CajaDelivery='False'", "IDMozo='" + idMozo + "'");
            showData();
        }

        private void especificarAAdministradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idMozo = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
            string idSucursal = dgvComprobante.CurrentRow.Cells["IDSucursal"].Value.ToString();

            fn.Modificar("Mozo", "Administrador='False'", "IDSucursal = '"+idSucursal+"'");
            fn.Modificar("Mozo", "Administrador='True'", "IDMozo='" + idMozo + "'");
            showData();
        }
    }
}
