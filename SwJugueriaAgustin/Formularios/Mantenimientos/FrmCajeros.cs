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

namespace SwJugueriaAgustin.Formularios.Mantenimientos
{
    public partial class FrmCajeros : Form
    {
        bool update;
        string idCajera;
        Funciones fn = new Funciones();

        public FrmCajeros()
        {
            InitializeComponent();

            KeyPreview = true;

            KeyDown += FrmCajera_KeyDown;
        }

        private void FrmCajera_KeyDown(object sender, KeyEventArgs e)
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
            try
            {
                fn.ActualizarGrid(dgvComprobante, "select * from Cajera where Nombres like '%" + txtBuscar.Text + "%' order by IDCajera desc");
                dgvComprobante.Columns["IDCajera"].Visible = false;
                dgvComprobante.Columns["Contraseña"].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            txtNombres.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombres.Focus();
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
            enable(false);
            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clean()
        {
            txtNombres.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Clear();
            txtContraseña.Clear();
        }

        private void save()
        {
            if (update == true)
            {
                fn.Modificar("Cajera", "Nombres='" + txtNombres.Text + "',Telefono='"+txtTelefono.Text+"',Usuario='"+txtUsuario.Text+"',Contraseña='"+txtContraseña.Text+"'", "IDCajera='" + idCajera + "'");
            }
            else
            {
                fn.RegistrarOficial("Cajera", "Nombres,Telefono,Usuario,Contraseña,Habilitado", 
                    "'" + txtNombres.Text + "','"+txtTelefono.Text+"','"+txtUsuario.Text+"','"+txtContraseña.Text+"','1'");
            }

            update = false;
        }

        private bool validationSave()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) == true || string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Verificar el Ingreso de Nombres - Usuario y Contraseña", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return false;
            }

            if(txtContraseña.Text != txtConfirmarContraseña.Text)
            {
                MessageBox.Show("Contraseñas no coinciden", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarContraseña.Focus();
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

                txtNombres.Text = dgvComprobante.CurrentRow.Cells["Nombres"].Value.ToString();
                txtTelefono.Text = dgvComprobante.CurrentRow.Cells["Telefono"].Value.ToString();
                txtUsuario.Text = dgvComprobante.CurrentRow.Cells["Usuario"].Value.ToString();
                txtContraseña.Text = dgvComprobante.CurrentRow.Cells["Contraseña"].Value.ToString();
                txtConfirmarContraseña.Text = txtContraseña.Text;
                idCajera = dgvComprobante.CurrentRow.Cells["idCajera"].Value.ToString();
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

        private void eLIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar cajero(a) Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (msj == DialogResult.OK)
            {
                fn.Eliminar("Cajera", "IDCajera='" + dgvComprobante.CurrentRow.Cells["idCajera"].Value.ToString() + "'");
                showData();
                MessageBox.Show("Operacion Correcta");
            }
        }

        private void hABILITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fn.Modificar("Cajera", "Habilitado=1", "IDCajera='" + dgvComprobante.CurrentRow.Cells["idCajera"].Value.ToString() + "'");
            showData();
        }

        private void dESHABILITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fn.Modificar("Cajera", "Habilitado=0", "IDCajera='" + dgvComprobante.CurrentRow.Cells["idCajera"].Value.ToString() + "'");
            showData();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clean();
            enable(false);
            update = false;
        }

        private void especificarLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCajeroLocal frm = new FrmCajeroLocal();
                string nombre = dgvComprobante.CurrentRow.Cells["Nombres"].Value.ToString();
                string idCajera = dgvComprobante.CurrentRow.Cells["IDCajera"].Value.ToString();
                frm.txtNombres.Text = nombre;
                frm.IDCajero = idCajera;
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
