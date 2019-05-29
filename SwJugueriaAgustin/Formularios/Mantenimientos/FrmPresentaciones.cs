using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Mantenimientos;
using SwJugueriaAgustin.Formularios.Mantenimientos.Atributos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class FrmPresentaciones : Form
    {
        Funciones fn = new Funciones();
        bool editar = false;
        public static string IDProducto;
        string IDPresentacion;
        public FrmPresentaciones()
        {
            InitializeComponent();
            KeyPreview = true;

            this.KeyDown += load_KeyDown;

        }


        private void load_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmPresentaciones_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal", "IDSucursal", "Sucursal", cboSucursal);
            mostarGid();
            txtPresentacion.Focus();
            bloquear();
        }

        private void bloquear()
        {
            gbxProducto.Enabled = false;
            btnNUEVO.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validacionGuardar() == false)
            {
                return;
            }

            eGuardar();
        }

        private bool validacionGuardar()
        {
            if (string.IsNullOrWhiteSpace(txtPresentacion.Text) == true)
            {
                MessageBox.Show("Ingresar nombre de la Presentacion", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                if (Convert.ToDecimal(txtCosto.Text) < 0)
                {
                    MessageBox.Show("Costo Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Costo Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            try
            {
                if (Convert.ToDecimal(txtPrecio.Text) < 0)
                {
                    MessageBox.Show("Precio Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Precio Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void eGuardar()
        {

            if (!editar)
            {
                fn.RegistrarOficial("Presentacion", "IDSucursal,IDProducto,Presentacion,Costo,Precio,Activo,Combo",
                    "'"+cboSucursal.SelectedValue+"','" + IDProducto + "','" + txtPresentacion.Text + "','" + txtCosto.Text + "','" + txtPrecio.Text + "','True','"+chbxCombo.Checked+"'");
            }
            else
            {
                fn.Modificar("Presentacion",
                    "Presentacion='" + txtPresentacion.Text + "',Costo='" + txtCosto.Text + "',Precio='" + txtPrecio.Text + "',IDSucursal='"+cboSucursal.SelectedValue+"',Combo = '"+chbxCombo.Checked+"'", 
                    "IDPresentacion='" + IDPresentacion + "'");
                editar = false;

            }
            limpiar();
            mostarGid();
            txtPresentacion.Focus();
            bloquear();
        }

        private void limpiar()
        {
            txtCosto.Text = "0";
            txtPrecio.Text = "0";
            txtPresentacion.Text = "";
        }

        private void mostarGid()
        {
            try
            {
                fn.MostrarGri("IDPresentacion as CODIGO,s.IDSucursal,s.Sucursal,Presentacion,Costo,Precio,Combo", "Presentacion p left join sucursal s on p.IDSucursal=s.IDSucursal", "IDProducto='" + IDProducto + "'", dgvPresentacion, "Presentacion");
                dgvPresentacion.Columns["CODIGO"].Visible = false;
                dgvPresentacion.Columns["IDSucursal"].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCosto.Focus();
            }
        }

        private void txtCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrecio.Focus();
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                eGuardar();
                txtPresentacion.Focus();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReceta_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNUEVO_Click(object sender, EventArgs e)
        {
            desbloquear();
        }

        private void desbloquear()
        {
            gbxProducto.Enabled = true;
            btnNUEVO.Enabled = false;
            btnGuardar.Enabled = true;
            
            btnCancelar.Enabled = true;
            txtPresentacion.Focus();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bloquear();
            editar = false;
            limpiar();
        }

        private void especificarRecetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvPresentacion.Rows.Count > 0)
                {
                    frmReceta frm = new frmReceta();
                    frmReceta.IDPresentacion = dgvPresentacion.CurrentRow.Cells["Codigo"].Value.ToString();
                    frm.lblPresentacion.Text = dgvPresentacion.CurrentRow.Cells["Presentacion"].Value.ToString();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ediatrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                editar = true;
                IDPresentacion = dgvPresentacion.CurrentRow.Cells["Codigo"].Value.ToString();
                cboSucursal.Text = dgvPresentacion.CurrentRow.Cells["Sucursal"].Value.ToString();
                txtPresentacion.Text = dgvPresentacion.CurrentRow.Cells["Presentacion"].Value.ToString();
                txtCosto.Text = dgvPresentacion.CurrentRow.Cells["Costo"].Value.ToString();
                txtPrecio.Text = dgvPresentacion.CurrentRow.Cells["Precio"].Value.ToString();
                chbxCombo.Checked = Convert.ToBoolean(dgvPresentacion.CurrentRow.Cells["Combo"].Value);
                txtPresentacion.Focus();
                desbloquear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDPresentacion = dgvPresentacion.CurrentRow.Cells["Codigo"].Value.ToString();
            fn.Delete("Presentacion","IDPresentacion='"+IDPresentacion+"'",true);
            mostarGid();
        }

        private void especificarComboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool combo = Convert.ToBoolean(dgvPresentacion.CurrentRow.Cells["Combo"].Value);

            if (!combo)
            {
                MessageBox.Show("Presentacion Seleccionada no es un combo", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmComboPresentacion frm = new FrmComboPresentacion();
            frm.idSucursal = dgvPresentacion.CurrentRow.Cells["IDSucursal"].Value.ToString();
            frm.IDPresentacionCombo = dgvPresentacion.CurrentRow.Cells["Codigo"].Value.ToString();
            frm.lblPresentacionCombo.Text = dgvPresentacion.CurrentRow.Cells["Presentacion"].Value.ToString();
            frm.ShowDialog();
        }
    }
}
