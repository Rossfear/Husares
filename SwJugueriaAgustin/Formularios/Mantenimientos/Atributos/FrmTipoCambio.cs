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
    public partial class FrmTipoCambio : Form
    {
        bool update;
        string idTipoCambio;
        Funciones fn = new Funciones();
        public FrmTipoCambio()
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
            fn.ActualizarGrid(dgvComprobante, "select top(10) IDTipoCambio as Item,Fecha,TipoCambio from TipoCambio where Fecha = '" + dtpBuscar.Value.ToShortDateString() + "' order by IDTipoCambio desc");
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
            dtpFecha.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTipoCambio.Focus();
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

            txtTipoCambio.Text = "";
        }

        private void save()
        {
            if (update == true)
            {
                fn.Modificar("TipoCambio", "Fecha='" + dtpFecha.Value.ToShortDateString() + "',TipoCambio='" + txtTipoCambio.Text + "'", "IDTipoCambio='" + idTipoCambio + "'");
            }
            else
            {
                fn.RegistrarOficial("TipoCambio", "Fecha,TipoCambio", "'" + dtpFecha.Value.ToShortDateString() + "','" + txtTipoCambio.Text + "'");
            }

            update = false;
        }

        private bool validationSave()
        {
            try
            {
                if (Convert.ToSingle(txtTipoCambio.Text) < 0)
                {
                    MessageBox.Show("Tipo de Cambio Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTipoCambio.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Tipo de Cambio Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipoCambio.Focus();
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
                dtpFecha.Value = Convert.ToDateTime(dgvComprobante.CurrentRow.Cells["Fecha"].Value);
                txtTipoCambio.Text = dgvComprobante.CurrentRow.Cells["TipoCambio"].Value.ToString();
                idTipoCambio = dgvComprobante.CurrentRow.Cells["Item"].Value.ToString();
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
    }
}
