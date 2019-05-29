using SwJugueriaAgustin.Clases;
using System;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Mantenimientos.Atributos
{
    public partial class FrmTipoOperacion : Form
    {
        bool update;
        string ID;
        Funciones fn = new Funciones();
        public FrmTipoOperacion()
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
            fn.ActualizarGrid(dgvDocumento, "select * from TipoOperacion where TipoOperacion like '%" + txtBuscar.Text + "%' order by IDTipoOperacion desc");
            dgvDocumento.Columns["IDTipoOperacion"].Visible = false;
            
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
            txtTipoOperacion.Focus();
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
            txtTipoOperacion.Text = "";

        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("TipoOperacion", "TipoOperacion='" + txtTipoOperacion.Text + "'", "IDTipoOperacion='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("TipoOperacion", "TipoOperacion", "'" + txtTipoOperacion.Text + "'");
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
            if (string.IsNullOrWhiteSpace(txtTipoOperacion.Text) == true)
            {
                MessageBox.Show("Especificar Tipo de Operacion", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipoOperacion.Focus();
                return false;
            }

            if (update == false)
            {
                if (fn.Existencia("*", "TipoOperacion", "TipoOperacion='" + txtTipoOperacion.Text + "'") == true)
                {
                    MessageBox.Show("El Tipo de Operacion ya se Encuentra Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string TipoOperacion = dgvDocumento.CurrentRow.Cells["TipoOperacion"].Value.ToString();
                if (TipoOperacion == "TRASLADO" || TipoOperacion == "COMPRA")
                {
                    MessageBox.Show("Por Seguridad el Tipo de Operacion 'Traslado' ó 'Compra' no se Deben Modificar", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                update = true;
                txtTipoOperacion.Text = TipoOperacion;
                ID = dgvDocumento.CurrentRow.Cells["IDTipoOperacion"].Value.ToString();
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
