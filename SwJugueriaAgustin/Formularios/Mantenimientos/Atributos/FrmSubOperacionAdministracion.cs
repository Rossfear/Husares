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
    public partial class FrmSubOperacionAdministracion : Form
    {
        public string idOperacion;
        bool update;
        string ID;
        Funciones fn = new Funciones();
        public FrmSubOperacionAdministracion()
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
            fn.ActualizarGrid(dgvDocumento, "select * from SubOperacionAdministracion where IDOperacion='"+idOperacion+"' order by IDSubOperacionAdministracion desc");
            dgvDocumento.Columns["IDSubOperacionAdministracion"].Visible = false;
            dgvDocumento.Columns["IDOperacion"].Visible = false;
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
            txtSubOperacionAdministracion.Focus();
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
            txtSubOperacionAdministracion.Text = "";
            chbxContable.Checked = true;
        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("SubOperacionAdministracion", "SubOperacionAdministracion='" + txtSubOperacionAdministracion.Text + "',Contable='"+chbxContable.Checked+"'", "IDSubOperacionAdministracion='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("SubOperacionAdministracion", "SubOperacionAdministracion,Contable,IDOperacion", "'" + txtSubOperacionAdministracion.Text + "','"+chbxContable.Checked+"','"+idOperacion+"'");
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
            if (string.IsNullOrWhiteSpace(txtSubOperacionAdministracion.Text) == true)
            {
                MessageBox.Show("Especificar Tipo de Entrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubOperacionAdministracion.Focus();
                return false;
            }

            if (update == false)
            {
                if (fn.Existencia("*", "SubOperacionAdministracion", "SubOperacionAdministracion='" + txtSubOperacionAdministracion.Text + "'") == true)
                {
                    MessageBox.Show("El Tipo de Entrada ya se Encuentra Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }


            

            if (update == true)
            {
                DialogResult msj = MessageBox.Show("Desea Actualizar los datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msj == DialogResult.Cancel)
                {
                    return false;
                }
            }
           

            


            return true;
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string SubOperacionAdministracion = dgvDocumento.CurrentRow.Cells["SubOperacionAdministracion"].Value.ToString();
                chbxContable.Checked = Convert.ToBoolean(dgvDocumento.CurrentRow.Cells["Contable"].Value);
                update = true;
                txtSubOperacionAdministracion.Text = SubOperacionAdministracion;
                ID = dgvDocumento.CurrentRow.Cells["IDSubOperacionAdministracion"].Value.ToString();
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
            DialogResult msj = MessageBox.Show("Desea Eliminar el Dato", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(msj == DialogResult.OK)
            {
                string IDSubOperacionAdministracion = dgvDocumento.CurrentRow.Cells["IDSubOperacionAdministracion"].Value.ToString();
                fn.Eliminar("SubOperacionAdministracion", "IDSubOperacionAdministracion='" + IDSubOperacionAdministracion + "'");
                showData();
            }
        }
    }
}
