using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Compra.Operacion
{
    public partial class FrmCompraContable : Form
    {
        Funciones fn = new Funciones();
        public FrmCompraContable()
        {
            InitializeComponent();
        }

        private void FrmCompraContable_Load(object sender, EventArgs e)
        {
            cbxMes.Focus();
        }

        private void txtAño_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //VRIFICAMOS SI EL REGISTRO ESPECIFICADO EXISTE
                    bool existe = fn.Existencia("*", "RegistroCompra", "MES='" + cbxMes.Text + "' AND AÑO='" + txtAño.Text + "'");

                    //SI EXISTE MOSTRAMOS EL DATAGRID ELSE -> REGISTRARLO
                    if (existe == true)
                    {
                        lblMes.Text = cbxMes.Text;
                        lblAño.Text = txtAño.Text;

                        //MOSTRAMOS EL DATADRIG
                        string codRegistro = fn.select_one_value("IDRegistroCompra", "registrocompra", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
                        MostrarGrid(codRegistro);
                        btnAddCompra.Select();
                    }
                    else
                    {
                        //PREGUNTAMOS SI DESEA REGISTRAR 
                        var msj = MessageBox.Show("El Registro de Compra especificado no se encuentra registrada. Desea Registrarlo?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (msj == DialogResult.OK)
                        {
                            //REGISTRA
                            fn.Registrar("RegistroCompra", "'" + cbxMes.Text + "','" + txtAño.Text + "'");

                            lblMes.Text = cbxMes.Text;
                            lblAño.Text = txtAño.Text;

                            //MUESTRA GRID
                            string codRegistro = fn.select_one_value("IDRegistroCompra", "RegistroCompra", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
                            MostrarGrid(codRegistro);
                            btnAddCompra.Select();
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void MostrarGrid(string codRegistro)
        {
            fn.ActualizarGrid(dgvDetalle, "select cc.IDCompraContable,cc.FechaEmision,cc.FechaVencimiento, tc.NombreComprobante,tc.Codigo,cc.Serie,cc.Numero as Correlativo,td.Tipo,pr.Numero,pr.RazonSocial as Denominacion,cc.moneda,cc.TipoCambio,cc.Impuesto,cc.BaseGravada,cc.IGV,cc.BaseNoGravada,cc.isc,cc.OtrosTributos,cc.Descuento,cc.Total,cc.ConIGV  from compraContable cc  inner join TipoComprobante tc on cc.IDTipoComprobante = tc.IDTipoComprobante  inner join Proveedor pr on cc.IDProveedor = pr.IDProveedor  left join TipoDocumento td on pr.IDTipoDocumento = td.IDTipoDocumento where cc.IDRegistroCompra = '" + codRegistro+ "' and cc.cancelada = 'False' order by cc.IDCompraContable desc");
            dgvDetalle.Columns["IDCompraContable"].Visible = false;
        }

        private void btnAddCompra_Click(object sender, EventArgs e)
        {
            try
            {

                FrmAddCompraContable frm = new FrmAddCompraContable();
                FrmAddCompraContable.Codregistro = fn.select_one_value("IDRegistroCompra", "RegistroCompra", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
                FrmAddCompraContable.editar = false;
                frm.lblTitulo.Text = lblMes.Text + " - " + lblAño.Text;
                frm.ShowDialog();

                string codRegistro = fn.select_one_value("IDRegistroCompra", "RegistroCompra", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
                MostrarGrid(codRegistro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxMes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtAño.Focus();
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void _editar()
        {
            try
            {
                string idRegistro = fn.select_one_value("IDRegistroCompra", "RegistroCompra", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
                FrmAddCompraContable frm = new FrmAddCompraContable();
                FrmAddCompraContable.Codregistro = idRegistro;
                FrmAddCompraContable.editar = true;
                frm.lblTitulo.Text = lblMes.Text + " - " + lblAño.Text;

                float tipoCambio = Convert.ToSingle(dgvDetalle.CurrentRow.Cells["TipoCambio"].Value.ToString());
                frm.lblImpuesto.Text = dgvDetalle.CurrentRow.Cells["Impuesto"].Value.ToString();

                //VARIABLES FACTURACION
                double afecto = Convert.ToDouble(dgvDetalle.CurrentRow.Cells["BaseGravada"].Value.ToString()) / tipoCambio;
                double inafecto = Convert.ToDouble(dgvDetalle.CurrentRow.Cells["BaseNoGravada"].Value.ToString()) / tipoCambio;
                double igv = Convert.ToDouble(dgvDetalle.CurrentRow.Cells["IGV"].Value.ToString()) / tipoCambio;
                double isc = Convert.ToDouble(dgvDetalle.CurrentRow.Cells["isc"].Value.ToString()) / tipoCambio;
                double otros = Convert.ToDouble(dgvDetalle.CurrentRow.Cells["OtrosTributos"].Value.ToString()) / tipoCambio;
                double descuento = Convert.ToDouble(dgvDetalle.CurrentRow.Cells["Descuento"].Value.ToString()) / tipoCambio;
                double total = Convert.ToDouble(dgvDetalle.CurrentRow.Cells["Total"].Value.ToString()) / tipoCambio;



                //PASAMOS DETALLE DE COMPRA

                string IDCompraContable = dgvDetalle.CurrentRow.Cells["IDCompraContable"].Value.ToString();
                


                frm.idCompraContable = IDCompraContable;
                frm.dtpFecha.Value = Convert.ToDateTime(dgvDetalle.CurrentRow.Cells["FechaEmision"].Value);
                frm.dtpFechaVcto.Value = Convert.ToDateTime(dgvDetalle.CurrentRow.Cells["FechaVencimiento"].Value);
                frm.cbxTipoComprobante.Text = dgvDetalle.CurrentRow.Cells["NombreComprobante"].Value.ToString();
                frm.txtSerie.Text = dgvDetalle.CurrentRow.Cells["Serie"].Value.ToString();
                frm.txtCorrelativo.Text = dgvDetalle.CurrentRow.Cells["Correlativo"].Value.ToString();
                frm.txtNumero.Text = dgvDetalle.CurrentRow.Cells["Numero"].Value.ToString();
                
                frm.txtNombre.Text = dgvDetalle.CurrentRow.Cells["Denominacion"].Value.ToString();
                frm.cbxMoneda.Text = dgvDetalle.CurrentRow.Cells["Moneda"].Value.ToString();
                frm.txtAfecto.Text = afecto.ToString("0.00");
                frm.txtInafecto.Text = inafecto.ToString("0.00");
                frm.txtIGV.Text = igv.ToString("0.00");
                frm.txtISC.Text = isc.ToString("0.00");
                frm.txtOtros.Text = otros.ToString("0.00");
                frm.txtDescuento.Text = descuento.ToString("0.00");
                frm.txtTotal.Text = total.ToString("0.00");
                frm.txtTipoCambio.Text = tipoCambio.ToString();
                


                frm.ShowDialog();

                string codRegistro = fn.select_one_value("IDRegistroCompra", "RegistroCompra", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
                MostrarGrid(codRegistro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            ex.exportaraexcel(dgvDetalle);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _editar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (msj == DialogResult.OK)
            {
               
                        eliminarCompra();
                    
            }
        }

        private void eliminarCompra()
        {
            string idcompraContable = dgvDetalle.CurrentRow.Cells["IDCompraContable"].Value.ToString();

            fn.Eliminar("CompraContable", "IDCompraContable='" + idcompraContable + "'");
            fn.Eliminar("CompraContableDetalle", "IDCompraContable='" + idcompraContable + "'");

            string codRegistro = fn.select_one_value("IDRegistroCompra", "registrocompra", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
            MostrarGrid(codRegistro);

            MessageBox.Show("Compra Eliminada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
