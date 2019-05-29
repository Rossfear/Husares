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
    public partial class FrmMUnidadMedida : Form
    {
        bool update;
        string ID;
        Funciones fn = new Funciones();
        public FrmMUnidadMedida()
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
            fn.ActualizarGrid(dgvDocumento, "select * from UnidadMedida where UniMedida like '%" + txtBuscar.Text + "%' order by IDUniMedida desc");
            dgvDocumento.Columns["IDUniMedida"].Visible = false;
            
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
            txtUnidadMedida.Focus();
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
            txtUnidadMedida.Text = "";

        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("UnidadMedida", "UniMedida='" + txtUnidadMedida.Text + "'", "IDUniMedida='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("UnidadMedida", "UniMedida", "'" + txtUnidadMedida.Text + "'");
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
            if (string.IsNullOrWhiteSpace(txtUnidadMedida.Text) == true)
            {
                MessageBox.Show("Especificar Unidad de Medida", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnidadMedida.Focus();
                return false;
            }

            if (update == false)
            {
                if (fn.Existencia("*", "UnidadMedida", "UniMedida='" + txtUnidadMedida.Text + "'") == true)
                {
                    MessageBox.Show("La Unidad de Medida ya se Encuentra Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string tipoEntrada = dgvDocumento.CurrentRow.Cells["UniMedida"].Value.ToString();
                
                update = true;
                txtUnidadMedida.Text = tipoEntrada;
                ID = dgvDocumento.CurrentRow.Cells["IDUniMedida"].Value.ToString();
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
    }
}
