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

namespace SwJugueriaAgustin.Formularios.AdministracionReporte
{
    public partial class FrmCuadreCompraVenta : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmCuadreCompraVenta()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string sunat;

            if (cboSunat.Text == "SUNAT")
                sunat = " AND tc.Sunat = 1";
            else if (cboSunat.Text == "NO SUNAT")
                sunat = " AND tc.Sunat = 0";
            else
                sunat = "";
            


            if(chbxFecha.Checked == true)
            {
                //MOSTRAMOS GRID DE COMPRA DE GOLF
                fn.ActualizarGrid(dgvIngreso, "select i.IDInsumo,i.Insumo,'0' as CantidadCompra,CAST(sum(r.Cantidad * dv.Cantidad) AS DECIMAL(18,3)) as CantidadVenta,'' as Diferencia  from venta v  inner join CAJA c on v.IDCaja = c.id  inner join VentaDetalle dv on v.IDVenta = dv.IDVenta  inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion  inner join Receta r on p.IDPresentacion = r.IDPresentacion  inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen  inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante  where v.Anulada = 'False' and v.Fecha between '" + dtpFechaInicio.Value.ToShortDateString() + "' and '"+dtpFechaFin.Value.ToShortDateString()+"' "+sunat+" group by i.Insumo,i.IDInsumo");
                dgvIngreso.Columns["IDInsumo"].Visible = false;

                SqlDataReader lector = fn.selectMultiValues("select i.IDInsumo,i.Insumo,sum(dc.Cantidad) as CantidadCompra  from Compra c  inner join DetalleCompra dc on c.IDCompra = dc.IDCompra  INNER join Insumo i on dc.IDInsumo = i.IDInsumo inner join TipoComprobante tc on c.IDTipoComprobante = tc.IDTipoComprobante  where c.FechaEmision between '" + dtpFechaInicio.Value.ToShortDateString() + "' and '"+dtpFechaFin.Value.ToShortDateString()+"' "+sunat+" group by i.IDInsumo,i.Insumo");
                while (lector.Read())
                {
                    string idInsumo = lector["IDInsumo"].ToString();
                    string cantidadCompra = lector["CantidadCompra"].ToString();

                    foreach (DataGridViewRow row in dgvIngreso.Rows)
                    {
                        string vidInsumo = row.Cells["IDInsumo"].Value.ToString();
                        if (idInsumo == vidInsumo)
                        {
                            row.Cells["CantidadCompra"].Value = cantidadCompra;
                        }
                    }
                }
                lector.Close();


                //DIFERENCIA
                foreach (DataGridViewRow row in dgvIngreso.Rows)
                {
                    double cantidadCompra = Convert.ToDouble(row.Cells["CantidadCompra"].Value);
                    double cantidadVenta = Convert.ToDouble(row.Cells["CantidadVenta"].Value);
                    row.Cells["Diferencia"].Value = (cantidadCompra - cantidadVenta);
                }
            }
            else
            {
                //MOSTRAMOS GRID DE COMPRA DE GOLF
                fn.ActualizarGrid(dgvIngreso, "select i.IDInsumo,i.Insumo,'0' as CantidadCompra,CAST(sum(r.Cantidad * dv.Cantidad) AS DECIMAL(18,3)) as CantidadVenta,'' as Diferencia  from venta v  inner join CAJA c on v.IDCaja = c.id  inner join VentaDetalle dv on v.IDVenta = dv.IDVenta  inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion  inner join Receta r on p.IDPresentacion = r.IDPresentacion  inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen  inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante  where v.Anulada = 'False' and MONTH(v.Fecha) = '" + (cbxMes.SelectedIndex + 1) + "' and YEAR(v.Fecha) = '" + txtAño.Text + "' "+sunat+" group by i.Insumo,i.IDInsumo");
                dgvIngreso.Columns["IDInsumo"].Visible = false;

                SqlDataReader lector = fn.selectMultiValues("select i.IDInsumo,i.Insumo,sum(dc.Cantidad) as CantidadCompra  from Compra c  inner join DetalleCompra dc on c.IDCompra = dc.IDCompra  INNER join Insumo i on dc.IDInsumo = i.IDInsumo inner join TipoComprobante tc on c.IDTipoComprobante = tc.IDTipoComprobante where MONTH(c.FechaEmision) = '" + (cbxMes.SelectedIndex + 1) + "' and YEAR(c.FechaEmision) = '" + txtAño.Text + "' "+sunat+" group by i.IDInsumo,i.Insumo");
                while (lector.Read())
                {
                    string idInsumo = lector["IDInsumo"].ToString();
                    string cantidadCompra = lector["CantidadCompra"].ToString();

                    foreach (DataGridViewRow row in dgvIngreso.Rows)
                    {
                        string vidInsumo = row.Cells["IDInsumo"].Value.ToString();
                        if (idInsumo == vidInsumo)
                        {
                            row.Cells["CantidadCompra"].Value = cantidadCompra;
                        }
                    }
                }
                lector.Close();


                //DIFERENCIA
                foreach (DataGridViewRow row in dgvIngreso.Rows)
                {
                    double cantidadCompra = Convert.ToDouble(row.Cells["CantidadCompra"].Value);
                    double cantidadVenta = Convert.ToDouble(row.Cells["CantidadVenta"].Value);
                    row.Cells["Diferencia"].Value = (cantidadCompra - cantidadVenta);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ex.exportaraexcelTimer(dgvIngreso,progressBar1);
        }

        private void chbxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if(chbxFecha.Checked == true)
            {
                labelAño.Visible = false;
                labelMes.Visible = false;
                cbxMes.Visible = false;
                txtAño.Visible = false;

                labelFecha.Visible = true;
                dtpFechaInicio.Visible = true;
                dtpFechaFin.Visible = true;
            }
            else
            {
                labelAño.Visible = true;
                labelMes.Visible = true;
                cbxMes.Visible = true;
                txtAño.Visible = true;

                labelFecha.Visible = false;
                dtpFechaInicio.Visible = false;
                dtpFechaFin.Visible = false;
            }
        }

        private void FrmCuadreCompraVenta_Load(object sender, EventArgs e)
        {
            cboSunat.Text = "SUNAT";
        }
    }
}
