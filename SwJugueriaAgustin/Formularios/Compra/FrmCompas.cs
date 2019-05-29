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

namespace SwJugueriaAgustin.Formularios.Compra
{
    public partial class FrmCompas : Form
    {
        Funciones fn = new Funciones();
        public FrmCompas()
        {
            InitializeComponent();
        }

        private void FrmCompraLogistica_Load(object sender, EventArgs e)
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
                    bool existe = fn.Existencia("*", "RegistroCompraLogistica", "MES='" + cbxMes.Text + "' AND AÑO='" + txtAño.Text + "'");

                    //SI EXISTE MOSTRAMOS EL DATAGRID ELSE -> REGISTRARLO
                    if (existe == true)
                    {
                        lblMes.Text = cbxMes.Text;
                        lblAño.Text = txtAño.Text;

                        //MOSTRAMOS EL DATADRIG
                        string codRegistro = fn.select_one_value("IDRegistroCompraLogistica", "RegistroCompraLogistica", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
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
                            fn.Registrar("RegistroCompraLogistica", "'" + cbxMes.Text + "','" + txtAño.Text + "'");

                            lblMes.Text = cbxMes.Text;
                            lblAño.Text = txtAño.Text;

                            //MUESTRA GRID
                            string codRegistro = fn.select_one_value("IDRegistroCompraLogistica", "RegistroCompraLogistica", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
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
            

            fn.ActualizarGrid(dgvDetalle, "select c.IDCompra as CodSistema,ROW_NUMBER() over(order by c.IDCompra) as Item,a.Almacen,c.FechaEmision,c.FechaVencimiento,tc.NombreComprobante as TipoComprobante,tc.Codigo,c.Serie,c.Numero as Correlativo,td.Tipo,p.Numero,p.RazonSocial as Denominacion,c.Moneda,c.TipoCambio,c.Impuesto,c.BaseGravada,c.Igv,c.BaseNoGravada,c.ISC,c.OtrosTributos,c.Descuento,c.Total,c.AumentaStock,c.ConIGV  from Compra c  inner join TipoComprobante tc on c.IDTipoComprobante = tc.IDTipoComprobante  left join Proveedor p on c.IDProveedor = p.IDProveedor  left join TipoDocumento td on p.IDTipoDocumento = td.IDTipoDocumento inner join Almacen a on c.IDAlmacen = a.IDAlmacen where c.IDRegistroCompra = '"+codRegistro+"' and c.Cancelada = 'False'");

            dgvDetalle.Columns["CodSistema"].Visible = false;
        }

        private void btnAddCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if(fn.Existencia("*", "RegistroCompraLogistica","MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'") == true)
                {
                    string codRegistro = fn.select_one_value("IDRegistroCompraLogistica", "RegistroCompraLogistica", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);

                    FrmAddCompra frm = new FrmAddCompra();
                    frm.lblMes.Text = lblMes.Text;
                    frm.lblAño.Text = lblAño.Text;
                    frm.idRegistro = codRegistro;
                    frm.editar = false;
                    frm.ShowDialog();

                    MostrarGrid(codRegistro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxMes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAño.Focus();
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _editar();
        }

        private void _editar()
        {

            

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            MessageBox.Show("Esto Puede Tardar unos minutos. Seleccione Aceptar para Continuar con la Exportación", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ex.exportaraexcel(dgvDetalle);
        }

        private void cbxTipoExportacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(fn.Existencia("*", "RegistroCompraLogistica", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'") == true)
            {
                //MOSTRAMOS EL DATADRIG
                string codRegistro = fn.select_one_value("IDRegistroCompraLogistica", "RegistroCompraLogistica", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
                MostrarGrid(codRegistro);
            }
        }

        private void eDITARCOMPRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddCompra frm = new FrmAddCompra();
            //CONTROLES COMUNES
            frm.editar = true;
            frm.lblAño.Text = lblAño.Text;
            frm.lblMes.Text = lblMes.Text;
            string idCompra = dgvDetalle.CurrentRow.Cells["CodSistema"].Value.ToString();
            frm.lblIDComproEditada.Text = idCompra;
            

            //AGREGAMOS DETALLE DE COMPRA
            SqlDataReader lector = fn.selectMultiValues("select i.IDInsumo,i.Insumo,dc.Cantidad,dc.Costo,CAST(dc.Cantidad * dc.Costo as decimal(18,2)) as Importe,dc.Afecto from DetalleCompra dc inner join Insumo i on dc.IDInsumo = i.IDInsumo where IDCompra = '"+idCompra+"'");
            while(lector.Read())
            {
                string IDInsumo = lector["IDInsumo"].ToString();
                string insumo = lector["Insumo"].ToString();
                string cantidad = lector["Cantidad"].ToString();
                string costo = lector["Costo"].ToString();
                string importe = lector["Importe"].ToString();
                bool afecto = Convert.ToBoolean(lector["Afecto"].ToString());

                frm.dgvDetalle.Rows.Add(IDInsumo,insumo,cantidad,costo,importe,afecto);
            }
            lector.Close();

            //DATOS COMPROBANTE
            frm.cbxAlmacen.Text = dgvDetalle.CurrentRow.Cells["Almacen"].Value.ToString();
            frm.dtpFechaComprobante.Value = Convert.ToDateTime(dgvDetalle.CurrentRow.Cells["FechaEmision"].Value);
            frm.dtpFechaVencimiento.Value = Convert.ToDateTime(dgvDetalle.CurrentRow.Cells["FechaVencimiento"].Value);
            frm.cbxTipoComprobante.Text = dgvDetalle.CurrentRow.Cells["TipoComprobante"].Value.ToString();
            frm.txtSerie.Text = dgvDetalle.CurrentRow.Cells["Serie"].Value.ToString();
            frm.txtCorrelativo.Text = dgvDetalle.CurrentRow.Cells["Correlativo"].Value.ToString();
            frm.txtNumero.Text = dgvDetalle.CurrentRow.Cells["Numero"].Value.ToString();
            frm.txtNombre.Text = dgvDetalle.CurrentRow.Cells["Denominacion"].Value.ToString();
            frm.cbxMoneda.Text = dgvDetalle.CurrentRow.Cells["Moneda"].Value.ToString();
            frm.txtTipoCambio.Text = dgvDetalle.CurrentRow.Cells["TipoCambio"].Value.ToString();
            frm.lblImpuesto.Text = dgvDetalle.CurrentRow.Cells["Impuesto"].Value.ToString();
            frm.chbxAumentarStock.Checked = Convert.ToBoolean(dgvDetalle.CurrentRow.Cells["AumentaStock"].Value);
            frm.txtISC.Text = dgvDetalle.CurrentRow.Cells["ISC"].Value.ToString();
            frm.txtOtrosTributos.Text = dgvDetalle.CurrentRow.Cells["OtrosTributos"].Value.ToString();
            frm.txtDescuento.Text = dgvDetalle.CurrentRow.Cells["Descuento"].Value.ToString();
            
            frm.chbxConIGV.Checked = Convert.ToBoolean(dgvDetalle.CurrentRow.Cells["ConIGV"].Value);
            frm.ShowDialog();

            string codRegistro = fn.select_one_value("IDRegistroCompraLogistica", "RegistroCompraLogistica", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
            MostrarGrid(codRegistro);

        }

        private void solicitarEliminaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            DialogResult msj = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (msj == DialogResult.OK)
            {
                if (DateTime.Now.Month == (cbxMes.SelectedIndex + 1) && DateTime.Now.Year == Convert.ToInt32(lblAño.Text))
                {
                    eliminarCompra();
                }
                else
                {
                        eliminarCompra();
                    
                }
            }
        }

        private void eliminarCompra()
        {
            string idCompra = dgvDetalle.CurrentRow.Cells["CodSistema"].Value.ToString();

            fn.Delete("Compra", "IDCompra='" + idCompra + "'", false);
            fn.Delete("DetalleCompra", "IDCompra='" + idCompra + "'", false);

            MessageBox.Show("Dato Eliminado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string codRegistro = fn.select_one_value("IDRegistroCompraLogistica", "RegistroCompraLogistica", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
            MostrarGrid(codRegistro);
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetalleCompra frm = new FrmDetalleCompra();
            string idcompra  = dgvDetalle.CurrentRow.Cells["CodSistema"].Value.ToString();
            frm.IDCompra = idcompra;
            frm.ShowDialog();
        }
    }
}
