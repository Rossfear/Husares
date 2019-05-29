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
    public partial class FrmTipoComprobante : Form
    {
        bool update;
        string idTipoComprobante;
        Funciones fn = new Funciones();
        public FrmTipoComprobante()
        {
            InitializeComponent();

            KeyPreview = true;

            KeyDown += FrmTipoComprobante_KeyDown;
        }

        private void FrmTipoComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
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
            fn.ActualizarGrid(dgvComprobante, "select * from TipoComprobante where NombreComprobante like '%"+txtBuscar.Text+"%' order by IDTipoComprobante desc");
            dgvComprobante.Columns["IDTipoComprobante"].Visible = false;
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
            if(e.KeyCode == Keys.Enter)
            {
                txtTipoComprobante.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validationSave() == false)
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
            txtTipoComprobante.Text = "";
            chbxSunat.Checked = false;
        }

        private void save()
        {
            if(update == true)
            {
                fn.Modificar("TipoComprobante", "Codigo='"+txtCodigo.Text+"',NombreComprobante='"+txtTipoComprobante.Text+"',Sunat='"+chbxSunat.Checked+"'", "IDTipoComprobante='"+idTipoComprobante+"'");
            }
            else
            {
                fn.RegistrarOficial("TipoComprobante", "Codigo,NombreComprobante,Sunat", "'"+txtCodigo.Text+"','"+txtTipoComprobante.Text+"','"+chbxSunat.Checked+"'");
            }

            update = false;
        }

        private bool validationSave()
        {
            if(string.IsNullOrWhiteSpace(txtTipoComprobante.Text) == true)
            {
                MessageBox.Show("Especificar Tipo de Comprobante", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipoComprobante.Focus();
                return false;
            }

            DialogResult msj;

            if(update == true)
            {
                msj = MessageBox.Show("Desea Actualizar los datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                msj = MessageBox.Show("Desea Registrar los datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            if(msj == DialogResult.Cancel)
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
                enable(true);
                idTipoComprobante = dgvComprobante.CurrentRow.Cells["IDTipoComprobante"].Value.ToString();
                txtCodigo.Text = dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
                txtTipoComprobante.Text = dgvComprobante.CurrentRow.Cells["NombreComprobante"].Value.ToString();
                chbxSunat.Checked = (bool)dgvComprobante.CurrentRow.Cells["Sunat"].Value;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            showData();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (validacionEliminar() == false) return;

            fn.Delete("TipoComprobante","IDTipoComprobante='"+ dgvComprobante.CurrentRow.Cells["Codigo"].Value.ToString()+"'",true);
            showData();
        }

        private bool validacionEliminar()
        {
            string comprobante = dgvComprobante.CurrentRow.Cells["NombreComprobante"].Value.ToString();
            if (comprobante == "BOLETA" || comprobante == "FACTURA" || comprobante == "TICKET")
            {
                MessageBox.Show("No se puede Eliminar los siguientes Comprobantes", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update = false;
            clean();
            enable(false);
        }
    }
}
