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
    public partial class FrmTipoEntrada : Form
    {
        bool update;
        string ID;
        Funciones fn = new Funciones();
        public FrmTipoEntrada()
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
            fn.ActualizarGrid(dgvDocumento, "select IDTipoEntrada,TipoEntrada,Estado as ParaTienda from TipoEntrada where TipoEntrada like '%"+txtBuscar.Text+"%' order by IDTipoEntrada desc");
            dgvDocumento.Columns["IDTipoEntrada"].Visible = false;
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
            txtTipoEntrada.Focus();
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
            txtTipoEntrada.Text = "";
            
        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("TipoEntrada", "TipoEntrada='" + txtTipoEntrada.Text + "',Estado='"+chbxParaTienda.Checked+"'", "IDTipoEntrada='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("TipoEntrada", "TipoEntrada,Estado", "'" + txtTipoEntrada.Text + "','"+chbxParaTienda.Checked+"'");
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
            if (string.IsNullOrWhiteSpace(txtTipoEntrada.Text) == true)
            {
                MessageBox.Show("Especificar Tipo de Entrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipoEntrada.Focus();
                return false;
            }

            if(update == false)
            {
                if (fn.Existencia("*", "TipoEntrada","TipoEntrada='"+txtTipoEntrada.Text+"'") == true)
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
                
                string tipoEntrada = dgvDocumento.CurrentRow.Cells["TipoEntrada"].Value.ToString();
                if (tipoEntrada == "TRASLADO" || tipoEntrada == "COMPRA" || tipoEntrada == "ENTRADA PRESTAMO")
                {
                    MessageBox.Show("Por Seguridad el Tipo de Entrada 'Traslado' - 'Compra' - 'Entrada Prestamo' no se Deben Modificar", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                update = true;
                txtTipoEntrada.Text = tipoEntrada;
                chbxParaTienda.Checked = (bool)dgvDocumento.CurrentRow.Cells["ParaTienda"].Value;
                ID = dgvDocumento.CurrentRow.Cells["IDTipoEntrada"].Value.ToString();
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
            try
            {
                string tipoEntrada = dgvDocumento.CurrentRow.Cells["TipoEntrada"].Value.ToString();
                if (tipoEntrada == "TRASLADO" || tipoEntrada == "COMPRA" || tipoEntrada == "ENTRADA PRESTAMO")
                {
                    MessageBox.Show("Por Seguridad el Tipo de Entrada 'Traslado' - 'Compra' - 'Entrada Prestamo' no se Deben Eliminar", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                
                ID = dgvDocumento.CurrentRow.Cells["IDTipoEntrada"].Value.ToString();
                fn.Delete("TipoEntrada","IDTipoEntrada = '"+ID+"'",true);
                showData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
