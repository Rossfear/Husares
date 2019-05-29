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
    public partial class FrmTipoOperacionAdministracion : Form
    {
        bool update;
        string ID;
        Funciones fn = new Funciones();
        public FrmTipoOperacionAdministracion()
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
            fn.ActualizarGrid(dgvDocumento, "select * from TipoOperacionAdministracion where TipoOperacionAdministracion like '%" + txtBuscar.Text + "%' order by IDTipoOperacionAdministracion desc");
            dgvDocumento.Columns["IDTipoOperacionAdministracion"].Visible = false;

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
            txtTipoOperacionAdministracion.Focus();
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
            txtTipoOperacionAdministracion.Text = "";
            
        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("TipoOperacionAdministracion", "TipoOperacionAdministracion='" + txtTipoOperacionAdministracion.Text + "'", "IDTipoOperacionAdministracion='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("TipoOperacionAdministracion", "TipoOperacionAdministracion", "'" + txtTipoOperacionAdministracion.Text + "'");
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
            if (string.IsNullOrWhiteSpace(txtTipoOperacionAdministracion.Text) == true)
            {
                MessageBox.Show("Especificar Tipo de Entrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipoOperacionAdministracion.Focus();
                return false;
            }

            if (update == false)
            {
                if (fn.Existencia("*", "TipoOperacionAdministracion", "TipoOperacionAdministracion='" + txtTipoOperacionAdministracion.Text + "'") == true)
                {
                    MessageBox.Show("El Tipo de Entrada ya se Encuentra Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string TipoOperacionAdministracion = dgvDocumento.CurrentRow.Cells["TipoOperacionAdministracion"].Value.ToString();
                
                update = true;
                txtTipoOperacionAdministracion.Text = TipoOperacionAdministracion;
                ID = dgvDocumento.CurrentRow.Cells["IDTipoOperacionAdministracion"].Value.ToString();
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

        private void subOperacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSubOperacionAdministracion frm = new FrmSubOperacionAdministracion();
                frm.idOperacion = dgvDocumento.CurrentRow.Cells["IDTipoOperacionAdministracion"].Value.ToString();
                frm.ShowDialog();
            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.Message,"FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar el Tipo de Operacion Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(msj == DialogResult.OK)
            {
                string IDTipoOperacionAdministracion = dgvDocumento.CurrentRow.Cells["IDTipoOperacionAdministracion"].Value.ToString();
                fn.Eliminar("TipoOperacionAdministracion", "IDTipoOperacionAdministracion='" + IDTipoOperacionAdministracion + "'");
                fn.Eliminar("SubOperacionAdministracion", "IDOperacion='"+IDTipoOperacionAdministracion+"'");
                showData();
            }
        }
    }
}
