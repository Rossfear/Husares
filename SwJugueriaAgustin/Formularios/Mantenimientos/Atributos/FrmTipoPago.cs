using SwJugueriaAgustin.Clases;
using System;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Mantenimientos.Atributos
{
    public partial class FrmTipoPago : Form
    {
        bool update;
        string idTipoComprobante;
        Funciones fn = new Funciones();
        public FrmTipoPago()
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
            fn.ActualizarGrid(dgvTipoPago, "select IDTipoPago,TipoPago,Descuento from TipoPago where TipoPago like '%" + txtBuscar.Text + "%' order by IDTipoPago desc");
            dgvTipoPago.Columns["IDTipoPago"].Visible = false;
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
            txtDescuento.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTipoPago.Focus();
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
            txtDescuento.Text = "";
            txtTipoPago.Text = "";
        }

        private void save()
        {
            if (update == true)
            {
                fn.Modificar("TipoPago", "Descuento='" + txtDescuento.Text + "',TipoPago='" + txtTipoPago.Text + "'", "IDTipoPago='" + idTipoComprobante + "'");
            }
            else
            {
                fn.RegistrarOficial("TipoPago", "Descuento,TipoPago", "'" + txtDescuento.Text + "','" + txtTipoPago.Text + "'");
            }

            update = false;
        }

        private bool validationSave()
        {
            try
            {
                Convert.ToDouble(txtDescuento.Text);
            }
            catch
            {
                MessageBox.Show("Descuento Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescuento.Focus();
            }
            if (string.IsNullOrWhiteSpace(txtTipoPago.Text) == true)
            {
                MessageBox.Show("Especificar Tipo de Pago", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipoPago.Focus();
                return false;
            }

            if(update == false)
            {
                if(fn.Existencia("*","TipoPago","TipoPago='"+txtTipoPago.Text.Trim()+"'") == true)
                {
                    MessageBox.Show("el Tipo de Pago Especificado ya se Encuentra Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                txtDescuento.Text = dgvTipoPago.CurrentRow.Cells["Descuento"].Value.ToString();
                txtTipoPago.Text = dgvTipoPago.CurrentRow.Cells["TipoPago"].Value.ToString();
                idTipoComprobante = dgvTipoPago.CurrentRow.Cells["IDTipoPago"].Value.ToString();
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
            enable(false);
            clean();
            update = false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = dgvTipoPago.CurrentRow.Cells["IDTipoPago"].Value.ToString();
            fn.Delete("TipoPago","IDTipoPago='"+id+"'",true);
            showData();
        }
    }
}
