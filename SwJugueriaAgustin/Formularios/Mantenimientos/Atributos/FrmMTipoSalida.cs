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
    public partial class FrmMTipoSalida : Form
    {
        bool update;
        string ID;
        Funciones fn = new Funciones();
        public FrmMTipoSalida()
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
            fn.ActualizarGrid(dgvDocumento, "select IDTipoSalida,TipoSalida,Estado as ParaTienda from TipoSalida where TipoSalida like '%" + txtBuscar.Text + "%' order by IDTipoSalida desc");
            dgvDocumento.Columns["IDTipoSalida"].Visible = false;
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
            txtTipoSalida.Focus();
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
            txtTipoSalida.Text = "";

        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("TipoSalida", "TipoSalida='" + txtTipoSalida.Text + "',Estado='"+chbxParaTienda.Checked+"'", "IDTipoSalida='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("TipoSalida", "TipoSalida,Estado", "'" + txtTipoSalida.Text + "','"+chbxParaTienda.Checked+"'");
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
            if (string.IsNullOrWhiteSpace(txtTipoSalida.Text) == true)
            {
                MessageBox.Show("Especificar Tipo de Salida", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipoSalida.Focus();
                return false;
            }

            if (update == false)
            {
                if (fn.Existencia("*", "TipoSalida", "TipoSalida='" + txtTipoSalida.Text + "'") == true)
                {
                    MessageBox.Show("El Tipo de Salida ya se Encuentra Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string TipoSalida = dgvDocumento.CurrentRow.Cells["TipoSalida"].Value.ToString();
                if (TipoSalida == "TRASLADO")
                {
                    MessageBox.Show("Por Seguridad el Tipo de Salida 'Traslado' ó 'Venta' no se Deben Modificar", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                update = true;
                txtTipoSalida.Text = TipoSalida;
                ID = dgvDocumento.CurrentRow.Cells["IDTipoSalida"].Value.ToString();
                chbxParaTienda.Checked = (bool)dgvDocumento.CurrentRow.Cells["ParaTienda"].Value;
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
            string TipoSalida = dgvDocumento.CurrentRow.Cells["TipoSalida"].Value.ToString();
            if (TipoSalida == "TRASLADO")
            {
                MessageBox.Show("Por Seguridad el Tipo de Salida 'Traslado' no se Deben Eliminar", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            ID = dgvDocumento.CurrentRow.Cells["IDTipoSalida"].Value.ToString();
            fn.Delete("TipoSalida","IDTipoSalida='"+ID+"'",true);
            showData();
        }
    }
}
