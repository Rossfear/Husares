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

namespace SwJugueriaAgustin.Formularios.Mantenimientos.Atributos
{
    public partial class FrmMSubOperaciones : Form
    {
        public string idTipoOperacion;
        bool update;
        string ID;
        Funciones fn = new Funciones();
        public FrmMSubOperaciones()
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
            fn.añadir_ddl("TipoOperacion","IDTipoOperacion","TipoOperacion",cbxTipoOperacion);
            enable(false);
            showData();
        }

        private void showData()
        {
            try
            {
                fn.ActualizarGrid(dgvDocumento, "select so.IDSubOperacion,o.TipoOperacion,so.SubOperacion from SubOperacion so inner join TipoOperacion o on so.IDOperacion = o.IDTipoOperacion where o.IDTipoOperacion = '" + cbxTipoOperacion.SelectedValue + "' and so.SubOperacion like '%" + txtBuscar.Text + "%'  order by so.IDSubOperacion desc");
                dgvDocumento.Columns["IDSubOperacion"].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            txtSubOperacion.Focus();
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
            enable(false);
            btnNuevo.Focus();
        }

        private void clean()
        {
            txtSubOperacion.Text = "";

        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("SubOperacion", "IDOperacion='"+cbxTipoOperacion.SelectedValue+"',SubOperacion='" + txtSubOperacion.Text + "'", "IDSubOperacion='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("SubOperacion", "IDOperacion,SubOperacion", "'"+cbxTipoOperacion.SelectedValue+"','" + txtSubOperacion.Text + "'");
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
            if (string.IsNullOrWhiteSpace(txtSubOperacion.Text) == true)
            {
                MessageBox.Show("Especificar Tipo de Sub_Operacion", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubOperacion.Focus();
                return false;
            }

            if(cbxTipoOperacion.SelectedValue == null)
            {
                MessageBox.Show("Tipo de Operación Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (update == false)
            {
                if (fn.Existencia("*", "SubOperacion", "SubOperacion='" + txtSubOperacion.Text + "'") == true)
                {
                    MessageBox.Show("El Tipo de Sub_Operacion ya se Encuentra Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string SubOperacion = dgvDocumento.CurrentRow.Cells["SubOperacion"].Value.ToString();
                cbxTipoOperacion.Text = dgvDocumento.CurrentRow.Cells["TipoOperacion"].Value.ToString();
                update = true;
                txtSubOperacion.Text = SubOperacion;
                ID = dgvDocumento.CurrentRow.Cells["IDSubOperacion"].Value.ToString();
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



        private void cbxTipoOperacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            showData();
        }
    }
}
