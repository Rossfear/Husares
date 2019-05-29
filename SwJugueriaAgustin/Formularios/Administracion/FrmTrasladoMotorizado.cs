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

namespace SwJugueriaAgustin.Formularios.Administracion
{
    public partial class FrmTrasladoMotorizado : Form
    {
        bool update;
        string ID;
        Funciones fn = new Funciones();
        public FrmTrasladoMotorizado()
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
            fn.añadir_ddl("Nombres", "IDRepartidor", "Repartidor where Nombres != ''", cboRepartidor);
            enable(false);
            showData();
        }

        private void showData()
        {
            fn.ActualizarGrid(dgvDocumento, "select mm.IDMovimiento,mm.Fecha,mm.Hora,r.Nombres as Motorizado,mm.Descripcion,u.Usuario from MovimientoMotorizado mm left join Repartidor r on mm.IDMotorizado = r.IDRepartidor left join Usuario u on mm.IDUsuario = u.IDUsuario where mm.Fecha = '"+dtpFechaBusqueda.Value.ToShortDateString()+ "' order by mm.IDMovimiento desc");
            dgvDocumento.Columns["IDMovimiento"].Visible = false;
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

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            eGuardar();
        }

        private void eGuardar()
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
            cboRepartidor.Text = "";
            txtDescripcion.Text = "";
        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("MovimientoMotorizado", "Fecha='" + dtpFecha.Value.ToShortDateString() + "',Hora='"+DateTime.Now.ToShortTimeString()+"',IDMotorizado='" + cboRepartidor.SelectedValue + "',Descripcion='" + txtDescripcion.Text.Trim() + "',IDUsuario='" + Datos.idUsuario+ "'", "IDMovimiento='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("MovimientoMotorizado", "Fecha,Hora,IDMotorizado,Descripcion,IDUsuario",
                        "'" + dtpFecha.Value.ToShortDateString() + "','"+DateTime.Now.ToShortTimeString()+"','" + cboRepartidor.SelectedValue + "','" + txtDescripcion.Text.Trim() + "','" + Datos.idUsuario + "'");
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
            if (cboRepartidor.SelectedValue == null)
            {
                MessageBox.Show("Repartidor No Existente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }


            if(string.IsNullOrEmpty(txtDescripcion.Text) == true)
            {
                MessageBox.Show("Especifique Descripción del Movimiento", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
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
                dtpFecha.Value = Convert.ToDateTime(dgvDocumento.CurrentRow.Cells["Fecha"].Value);
                cboRepartidor.Text = dgvDocumento.CurrentRow.Cells["Motorizado"].Value.ToString();
                txtDescripcion.Text = dgvDocumento.CurrentRow.Cells["Descripcion"].Value.ToString();
                ID = dgvDocumento.CurrentRow.Cells["IDMovimiento"].Value.ToString();

                update = true;

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

        private void dtpFechaBusqueda_ValueChanged(object sender, EventArgs e)
        {
            showData();
        }

        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) SendKeys.Send("{TAB}");
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                eGuardar();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (msj == DialogResult.OK)
            {
                fn.Eliminar("MovimientoMotorizado", "IDMovimiento='" + dgvDocumento.CurrentRow.Cells["IDMovimiento"].Value.ToString() + "'");
                MessageBox.Show("Dato Eliminado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showData();
            }

        }

        private void dtpFechaBusqueda_ValueChanged_1(object sender, EventArgs e)
        {
            showData();
        }
    }
}
