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
    public partial class FrmIngresoAdministrativo : Form
    {
        bool update;
        string ID;
        Funciones fn = new Funciones();
        public FrmIngresoAdministrativo()
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
            fn.añadir_ddl("TipoIngreso", "IDTipoIngreso", "TipoIngreso", cbxTipoIngreso);
            enable(false);
            showData();
        }

        private void showData()
        {
            fn.ActualizarGrid(dgvDocumento, "select e.IDIngreso,te.TipoIngreso,e.Fecha,e.Motivo,e.Monto,e.IngresoDe,u.Usuario from Ingreso e left join TipoIngreso te on e.IDTipoIngreso = te.IDTipoIngreso left join Usuario u on e.IDUsuario = u.IDUsuario where e.Fecha = '" + dtpFechaBusqueda.Value.ToShortDateString() + "' order by e.IDIngreso desc");
            dgvDocumento.Columns["IDIngreso"].Visible = false;


            lblIngresos.Text = fn.selectValue("select sum(monto) from Ingreso e where e.Fecha = '" + dtpFechaBusqueda.Value.ToShortDateString() + "'");

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
            cbxTipoIngreso.Text = "";
            txtMotivo.Text = "";
            txtIngresoDe.Text = "";
            txtMonto.Text = "0";
        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("Ingreso", "Fecha='" + dtpFecha.Value.ToShortDateString() + "',IDTipoIngreso='" + cbxTipoIngreso.SelectedValue + "',Motivo='" + txtMotivo.Text.Trim() + "',IngresoDe='" + txtIngresoDe.Text + "',Monto='" + txtMonto.Text + "',IDUsuario='" + Datos.idUsuario + "'", "IDIngreso='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("Ingreso", "Fecha,IDTipoIngreso,Motivo,IngresoDe,Monto,IDUsuario",
                        "'" + dtpFecha.Value.ToShortDateString() + "','" + cbxTipoIngreso.SelectedValue + "','" + txtMotivo.Text.Trim() + "','" + txtIngresoDe.Text + "','" + txtMonto.Text + "','" + Datos.idUsuario + "'");
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
            

            if (cbxTipoIngreso.SelectedValue == null)
            {
                MessageBox.Show("Tipo de Ingreso No Existente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return false;
            }

            try
            {
                if (Convert.ToDouble(txtMonto.Text) < 0)
                {
                    MessageBox.Show("Monto Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMonto.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Monto Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
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
                cbxTipoIngreso.Text = dgvDocumento.CurrentRow.Cells["TipoIngreso"].Value.ToString();
                txtMotivo.Text = dgvDocumento.CurrentRow.Cells["Motivo"].Value.ToString();
                txtIngresoDe.Text = dgvDocumento.CurrentRow.Cells["IngresoDe"].Value.ToString();
                txtMonto.Text = dgvDocumento.CurrentRow.Cells["Monto"].Value.ToString();
                ID = dgvDocumento.CurrentRow.Cells["IDIngreso"].Value.ToString();

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
                FrmContraseña frm = new FrmContraseña();
                frm.ShowDialog();

                if (frm.cancel == false)
                {
                    fn.Eliminar("Ingreso", "IDIngreso='" + dgvDocumento.CurrentRow.Cells["IDIngreso"].Value.ToString() + "'");
                }
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
