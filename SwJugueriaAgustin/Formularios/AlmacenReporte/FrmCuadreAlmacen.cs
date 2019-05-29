using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Reportes
{
    public partial class FrmCuadreAlmacen : Form
    {
        Funciones fn = new Funciones();
        public FrmCuadreAlmacen()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostraGrid();

            foreach (DataGridViewRow row in dgvMañana.Rows)
            {
                row.Height = 30;
            }
        }





        private void mostraGrid()
        {
            dgvMañana.Rows.Clear();
            

            string fechaApertura = dtpFecha.Value.ToShortDateString();
            string IDAperturaM = fn.selectValue("select IDApertura from AperturaAlmacen where FechaApertura = '"+fechaApertura+ "' and Turno='MAÑANA' and IDSucursal = '"+cboSucursal.SelectedValue+"'");


            bool cerradoM = false;

            if (fn.selectValue("select Estado from AperturaAlmacen where IDApertura = '" + IDAperturaM + "' and IDSucursal = '"+cboSucursal.SelectedValue+"'") == "C")
            {
                cerradoM = true;
            }
            else
            {
                cerradoM = false;
            }

            //OBTENEMOS INSUMOS PARA EL CONTROL
            SqlDataReader lectorInsumos = fn.selectMultiValues("SELECT sa.IDStockAlmacen,i.Insumo FROM StockAlmacen sa  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen inner join Insumo i on sa.IDInsumo = i.IDInsumo WHERE a.PermiteVender = 'True' and sa.PermitirControl = '1' and a.IDSucursal = '"+cboSucursal.SelectedValue+"'");
            while (lectorInsumos.Read())
            {
                string idStockAlmacen = lectorInsumos["IDStockAlmacen"].ToString();
                string insumo = lectorInsumos["Insumo"].ToString();

                //string fecha = Convert.ToDateTime(lblFechaApertura.Text).ToShortDateString();
                float cantidadApertura = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select aad.CantidadInicial  from AperturaAlmacen aa  inner join [AperturaAlmacen.Detalle] aad on aa.IDApertura = aad.IDApertura  inner join StockAlmacen sa on aad.IDStockAlmacen = sa.IDStockAlmacen  inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  where sa.IDStockAlmacen = '" + idStockAlmacen + "' and AA.FechaApertura = '" + fechaApertura + "' and aa.Turno = 'MAÑANA' and aa.IDSucursal = '"+cboSucursal.SelectedValue+"'")));
                float cantidadEntrada = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleEntradaInsumo de inner join EntradaInsumo ei on de.IDEntradaInsumo = ei.IDEntrada inner join Almacen a on ei.IDAlmacenReceptor = a.IDAlmacen inner join EntradaTienda et on ei.IDEntrada = et.IDEntrada inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura inner join Insumo i on de.IDInsumo = i.IDInsumo where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + insumo + "' and aa.FechaApertura = '" + fechaApertura + "' and aa.Turno  = 'MAÑANA' and aa.IDSucursal='"+cboSucursal.SelectedValue+"' AND de.Anulado = 0")));
                float cantidadSalida = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura  inner join Insumo i on de.IDInsumo = i.IDInsumo  where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + insumo + "' and aa.FechaApertura = '" + fechaApertura + "' and aa.Turno  = 'MAÑANA' and aa.IDSucursal = '"+cboSucursal.SelectedValue+"' and de.Anulado = 0")));
                float cantidadVenta = Convert.ToSingle(fn.remplazarNulo(fn.selectValue("select sum(r.Cantidad * dv.Cantidad) as CantidadVenta from venta v inner join CAJA c on v.IDCaja = c.id inner join VentaDetalle dv on v.IDVenta = dv.IDVenta inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion inner join Receta r on p.IDPresentacion = r.IDPresentacion inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  where sa.IDStockAlmacen = '" + idStockAlmacen + "' and v.Anulada = 'False' and cast(c.fecha_hora as date) = '"+fechaApertura + "' and c.IDSucursal = '"+cboSucursal.SelectedValue+"' group by i.Insumo")));
                float saldoSistema = (cantidadApertura + cantidadEntrada) - (cantidadSalida + cantidadVenta);

                if (cerradoM == true)
                {
                    float saldoFinal = Convert.ToSingle(fn.remplazarNulo((fn.selectValue("select CantidadFinal from [AperturaAlmacen.Detalle] where IDApertura = '" + IDAperturaM + "' and IDStockAlmacen = '" + idStockAlmacen + "'"))));
                    double faltante = saldoSistema - saldoFinal;

                    dgvMañana.Rows.Add(idStockAlmacen, insumo, cantidadApertura, cantidadEntrada, cantidadSalida, cantidadVenta, saldoSistema, saldoFinal, faltante);
                }
                else
                {
                    dgvMañana.Rows.Add(idStockAlmacen, insumo, cantidadApertura, cantidadEntrada, cantidadSalida, cantidadVenta, saldoSistema, "", "");
                }

            }

            lectorInsumos.Close();
        }

        private void FrmCuadreAlmacen_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal", "IDSucursal", "Sucursal", cboSucursal);
        }
    }
}
