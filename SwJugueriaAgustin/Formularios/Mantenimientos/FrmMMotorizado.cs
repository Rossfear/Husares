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
    public partial class FrmMMotorizado : Form
    {
        bool update;
        string idRepartidor;
        Funciones fn = new Funciones();
        public FrmMMotorizado()
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
            fn.ActualizarGrid(dgvComprobante, "select r.IDRepartidor as Codigo,r.Nombres,r.NroIdentidad,r.Celular from Repartidor r where Nombres like '%"+txtBuscar.Text+"%' and Nombres	 != '' order by IDRepartidor desc");
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
            txtCelular.Text = "";
            txtNombre.Text = "";
            txtNroIdentidad.Text = "";
        }

        private void save()
        {
            if (update == true)
            {
                fn.Modificar("Repartidor", "Nombres='" + txtNombre.Text.Trim() + "',NroIdentidad='" + txtNroIdentidad.Text.Trim()+ "',Celular='"+txtCelular.Text.Trim()+"'", "IDRepartidor='" +idRepartidor + "'");
            }
            else
            {
                fn.RegistrarOficial("Repartidor", "Nombres,NroIdentidad,Celular",
                    "'" + txtNombre.Text.Trim() + "','" + txtNroIdentidad.Text.Trim()+ "','"+txtCelular.Text+"'");
            }

            update = false;
        }

        private bool validationSave()
        {
            if(string.IsNullOrEmpty(txtNombre.Text) == true)
            {
                MessageBox.Show("Especifique Repartidor", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }


            if(update == false)
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
                txtNombre.Text = dgvComprobante.CurrentRow.Cells["Nombres"].Value.ToString();
                txtNroIdentidad.Text = dgvComprobante.CurrentRow.Cells["NroIdentidad"].Value.ToString();
                txtCelular.Text = dgvComprobante.CurrentRow.Cells["Celular"].Value.ToString();
                idRepartidor = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
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

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fn.Delete("Repartidor", "IDRepartidor='" + dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString() + "'",true);
            showData();
        }
    }
}
