using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Compra.Mantenimiento
{
    public partial class FrmTipoDocumento : Form
    {
        bool update;
        string IDTipoDocumento;
        Funciones fn = new Funciones();
        public FrmTipoDocumento()
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
            fn.ActualizarGrid(dgvDocumento, "select IDTipoDocumento,Tipo,Descripcion from TipoDocumento where Descripcion like '%" + txtBuscar.Text + "%' order by IDTipoDocumento desc");
            dgvDocumento.Columns["IDTipoDocumento"].Visible = false;
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
            txtCodigo.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTipoDocumento.Focus();
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
            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clean()
        {
            txtCodigo.Text = "";
            txtTipoDocumento.Text = "";
        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("TipoDocumento", "Tipo='" + txtCodigo.Text + "',Descripcion='" + txtTipoDocumento.Text + "'", "IDTipoDocumento='" + IDTipoDocumento + "'");
                }
                else
                {
                    fn.RegistrarOficial("TipoDocumento", "Tipo,Descripcion", "'" + txtCodigo.Text + "','" + txtTipoDocumento.Text + "'");
                }

                update = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Guardar: "+ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private bool validationSave()
        {
            if (string.IsNullOrWhiteSpace(txtTipoDocumento.Text) == true)
            {
                MessageBox.Show("Especificar Tipo de Documento", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipoDocumento.Focus();
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
                txtCodigo.Text = dgvDocumento.CurrentRow.Cells["Tipo"].Value.ToString();
                txtTipoDocumento.Text = dgvDocumento.CurrentRow.Cells["Descripcion"].Value.ToString();
                IDTipoDocumento = dgvDocumento.CurrentRow.Cells["IDTipoDocumento"].Value.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            clean();
            update = false;
            enable(false);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fn.Delete("TipoDocumento","IDTipoDocumento='"+ dgvDocumento.CurrentRow.Cells["IDTipoDocumento"].Value.ToString()+"'",true);
            showData();
        }
    }
}
