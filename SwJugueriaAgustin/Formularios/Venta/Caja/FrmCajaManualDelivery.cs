using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Venta.Caja
{
    public partial class FrmCajaManualDelivery : Form
    {
        string idCaja;
        string id;
        bool editar = false;
        string estado = "";
        Funciones fn = new Funciones();
        public FrmCajaManualDelivery()
        {
            InitializeComponent();
        }

        private void FrmCuadreCajaManual_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            enable(false);
            SqlDataReader lectorCaja = fn.selectMultiValues("select top(1) * from Caja where Tipo='DELIVERY' and IDSucursal = '"+Datos.idSucursal+"' order by ID Desc");
            while (lectorCaja.Read())
            {
                lblFechaCaja.Text = Convert.ToDateTime(lectorCaja["Fecha_Hora"].ToString()).ToShortDateString();
                idCaja = lectorCaja["ID"].ToString();
                estado = lectorCaja["Estado"].ToString();
            }
            lectorCaja.Close();

            mostrarGrid();

            calcularTotales();
        }

        void mostrarGrid()
        {
            fn.ActualizarGrid(dgvListas, "select cm.IDCuadre,cm.NroComprobante,cm.Descripcion,cm.CantidadPollo,cm.GaseosaLitroMedio as 'Gaseosa 1.5',cm.GaseosaMedioLitro as 'Gaseosa 1/2',cm.Agua,cm.Monto from CuadreManual cm where cm.IDCaja = '" + idCaja + "' order by IDCuadre desc");
            dgvListas.Columns["IDCuadre"].Visible = false;
        }

        void enable(bool estado)
        {
            groupBox1.Enabled = estado;
            btnNuevo.Enabled = !estado;
            btnGuardar.Enabled = estado;
            btnCancelar.Enabled = estado;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            enable(true);
            txtNroComprobante.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            enable(false);
            editar = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            eGuardar();
        }

        void calcularTotales()
        {
            double cantidadPollo = 0, gaseosaLitroMedio = 0, gaseosaMedioLitro = 0, agua = 0, monto = 0;

            foreach (DataGridViewRow grid in dgvListas.Rows)
            {
                cantidadPollo += Convert.ToDouble(grid.Cells["CantidadPollo"].Value);
                gaseosaLitroMedio += Convert.ToDouble(grid.Cells["Gaseosa 1.5"].Value);
                gaseosaMedioLitro += Convert.ToDouble(grid.Cells["Gaseosa 1/2"].Value);
                agua += Convert.ToDouble(grid.Cells["Agua"].Value);
                monto += Convert.ToDouble(grid.Cells["Monto"].Value);
            }

            txtIAgua.Text = agua.ToString("#,#.00");
            txtICantidadPollo.Text = cantidadPollo.ToString("#,#.000");
            txtIGaseosaMedioLitro.Text = gaseosaMedioLitro.ToString("#,#.000");
            txtIGaseosaLitroMedio.Text = gaseosaLitroMedio.ToString("#,#.000");
            txtIMonto.Text = monto.ToString("#,#.000");

        }

        private void eGuardar()
        {
            if (validacion() == false)
            {
                return;
            }

            registrar();

            finalRegistro();
        }

        private void finalRegistro()
        {
            limpiar();
            mostrarGrid();
            calcularTotales();
            txtNroComprobante.Focus();
        }

        private void registrar()
        {
            if (editar == false)
            {
                fn.RegistrarOficial("CuadreManual", "IDCaja,NroComprobante,Descripcion,CantidadPollo,GaseosaLitroMedio,GaseosaMedioLitro,Agua,Monto,IDUsuario",
                "'" + idCaja + "','" + txtNroComprobante.Text + "','" + txtDescripcion.Text.Trim() + "','" + fn.remplazarNulo(txtCantidadPollo.Text) + "','" + fn.remplazarNulo(txtGaseosaLitroMedio.Text) + "','" + fn.remplazarNulo(txtGaseosaMedioLitro.Text) + "','" + fn.remplazarNulo(txtAgua.Text) + "','" + fn.remplazarNulo(txtMonto.Text) + "','" + Datos.idUsuario + "'");
            }
            else
            {
                fn.Modificar("CuadreManual", "NroComprobante='" + txtNroComprobante.Text + "',Descripcion='" + txtDescripcion.Text + "',CantidadPollo='" + fn.remplazarNulo(txtCantidadPollo.Text) + "',GaseosaLitroMedio='" + fn.remplazarNulo(txtGaseosaLitroMedio.Text) + "',GaseosaMedioLitro='" + fn.remplazarNulo(txtGaseosaMedioLitro.Text) + "',Agua='" + fn.remplazarNulo(txtAgua.Text) + "',Monto='" + fn.remplazarNulo(txtMonto.Text) + "',IDUsuario='" + Datos.idUsuario + "'", "IDCuadre='" + id + "'");
            }
        }

        private bool validacion()
        {
            if (string.IsNullOrEmpty(txtNroComprobante.Text) == true)
            {
                MessageBox.Show("Ingrese N° Comprobante", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroComprobante.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text) == true)
            {
                MessageBox.Show("Ingrese Descripcion", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMonto.Text) == true)
            {
                MessageBox.Show("Ingrese Monto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            if(estado == "CERRADA")
            {
                MessageBox.Show("Caja Especificada del Día " + lblFechaCaja.Text + "Esta Cerrada. Si ya Aperturo caja cierre este formulario y vuela abrir", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (editar == true)
            {
                DialogResult msj = MessageBox.Show("Deseas Actualizar los Datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msj == DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }

        void limpiar()
        {
            txtNroComprobante.Text = "";
            txtDescripcion.Text = "";
            txtCantidadPollo.Text = "";
            txtGaseosaLitroMedio.Text = "";
            txtGaseosaMedioLitro.Text = "";
            txtAgua.Text = "";
            txtMonto.Text = "";
        }

        private void txtNroComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                eGuardar();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = dgvListas.CurrentRow.Cells["IDCuadre"].Value.ToString();
            txtNroComprobante.Text = dgvListas.CurrentRow.Cells["NroComprobante"].Value.ToString();
            txtDescripcion.Text = dgvListas.CurrentRow.Cells["Descripcion"].Value.ToString();
            txtCantidadPollo.Text = dgvListas.CurrentRow.Cells["CantidadPollo"].Value.ToString();
            txtGaseosaLitroMedio.Text = dgvListas.CurrentRow.Cells["Gaseosa 1.5"].Value.ToString();
            txtGaseosaMedioLitro.Text = dgvListas.CurrentRow.Cells["Gaseosa 1/2"].Value.ToString();
            txtAgua.Text = dgvListas.CurrentRow.Cells["Agua"].Value.ToString();
            txtMonto.Text = dgvListas.CurrentRow.Cells["Monto"].Value.ToString();
            editar = true;
            enable(true);
            txtNroComprobante.Focus();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Deseas Eliminar El registro Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (msj == DialogResult.OK)
            {
                string idCuadre = dgvListas.CurrentRow.Cells["IDCuadre"].Value.ToString();
                fn.Eliminar("CuadreManual", "IDCuadre='" + idCuadre + "'");
                mostrarGrid();
                calcularTotales();
            }
        }
    }
}
