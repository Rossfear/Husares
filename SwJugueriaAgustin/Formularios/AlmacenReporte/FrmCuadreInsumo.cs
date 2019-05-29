using SwJugueriaAgustin.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.AdministracionReporte
{
    public partial class FrmCuadreInsumo : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmCuadreInsumo()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblInsumo.Text = cbxInsumo.Text;
                string idInsumo = cbxInsumo.SelectedValue.ToString();


                //GENERAL
                fn.ActualizarGrid(dgvDatos, "select '' as Item,cast(c.FECHA_HORA as date) as Fecha,'0' as SaldoInicial,'0' as Compra,'0' as PrestamoEntrada,'0' as IngresoTotal,CAST(sum(r.Cantidad * dv.Cantidad) AS DECIMAL(18,3)) as Salon,'0' as Delivery,'0' as VentaManual,'0' as Jugueria,'0' as Cena,'0' as Descarte,'0' AS Traslado,'0' as Tequeños,'0' as Almuerzo,'0' as DescuentoPersonal,'0' as Credito,'0' as Cortesia,'0' as PrestamoSalida,'0' as SalidaTotal,'0' as SaldoSistema,'0' as SaldoReal,'' as Estado,'0' as Diferencia  from venta v  inner join CAJA c on v.IDCaja = c.id  inner join VentaDetalle dv on v.IDVenta = dv.IDVenta  inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion  inner join Receta r on p.IDPresentacion = r.IDPresentacion  inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen   inner join Insumo i on sa.IDInsumo = i.IDInsumo   inner join TipoPago tp on v.IDTipoPago = tp.IDTipoPago  where v.Anulada = 'False' and MONTH(c.FECHA_HORA) = '" + (cbxMes.SelectedIndex + 1)+"' and YEAR(c.FECHA_HORA) = '"+txtAño.Text+"'  and v.TipoVenta = 'VS' and i.IDInsumo = '"+cbxInsumo.SelectedValue+"' and c.IDSucursal = '"+cboSucursal.SelectedValue+"' and tp.TipoPago != 'CORTESIA' and TP.TipoPago != 'DESCUENTO PERSONAL' and tp.TipoPago != 'CREDITO' group by i.Insumo,c.FECHA_HORA");



                byte cantidad = 0;
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    string fecha = Convert.ToDateTime(row.Cells["Fecha"].Value.ToString()).ToShortDateString();
                    cantidad++;
                    row.Cells["Item"].Value = cantidad;

                    double saldoFinal = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select aad.CantidadFinal  from AperturaAlmacen aa  inner join [AperturaAlmacen.Detalle] aad on aa.IDApertura = aad.IDApertura  inner join StockAlmacen sa on aad.IDStockAlmacen = sa.IDStockAlmacen  inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  where i.IDInsumo = '" + idInsumo + "' and AA.FechaApertura = '" + fecha + "' and aa.IDSucursal = '"+ cboSucursal.SelectedValue + "'")));

                    //TOTAL INGRESO
                    double saldoInicial = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select aad.CantidadInicial  from AperturaAlmacen aa  inner join [AperturaAlmacen.Detalle] aad on aa.IDApertura = aad.IDApertura  inner join StockAlmacen sa on aad.IDStockAlmacen = sa.IDStockAlmacen  inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  where  i.IDInsumo = '" + idInsumo + "' and AA.FechaApertura = '" + fecha + "' and aa.IDSucursal = '" + cboSucursal.SelectedValue  + "'")));
                    double compra = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleEntradaInsumo de inner join EntradaInsumo ei on de.IDEntradaInsumo = ei.IDEntrada inner join Almacen a on ei.IDAlmacenReceptor = a.IDAlmacen inner join EntradaTienda et on ei.IDEntrada = et.IDEntrada inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura  inner join Insumo i on de.IDInsumo = i.IDInsumo inner join TipoEntrada te on ei.IDTipoEntrada = te.IDTipoEntrada where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + lblInsumo.Text + "' and aa.FechaApertura = '" + fecha + "' and te.TipoEntrada = 'COMPRA' and aa.IDSucursal = '"+cboSucursal.SelectedValue+"' AND de.Anulado = '0'")));
                    double prestamoEntrada = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleEntradaInsumo de inner join EntradaInsumo ei on de.IDEntradaInsumo = ei.IDEntrada inner join Almacen a on ei.IDAlmacenReceptor = a.IDAlmacen inner join EntradaTienda et on ei.IDEntrada = et.IDEntrada inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura  inner join Insumo i on de.IDInsumo = i.IDInsumo inner join TipoEntrada te on ei.IDTipoEntrada = te.IDTipoEntrada where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + lblInsumo.Text + "' and aa.FechaApertura = '" + fecha + "' and te.TipoEntrada = 'ENTRADA PRESTAMO' and aa.IDSucursal = '"+ cboSucursal.SelectedValue + "' and de.Anulado = '0'")));
                    double totalIngreso = saldoInicial + compra + prestamoEntrada;

                    row.Cells["SaldoInicial"].Value = saldoInicial.ToString("0.000");
                    row.Cells["Compra"].Value = compra.ToString("0.000");
                    row.Cells["PrestamoEntrada"].Value = prestamoEntrada.ToString("0.000");
                    row.Cells["IngresoTotal"].Value = totalIngreso.ToString("0.000");

                    //EGRESOS

                    //Tipo Pago
                    double Cortesia = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select CAST(sum(r.Cantidad * dv.Cantidad) AS DECIMAL(18,3)) as Cantidad from venta v  inner join CAJA c on v.IDCaja = c.id  inner join VentaDetalle dv on v.IDVenta = dv.IDVenta  inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion  inner join Receta r on p.IDPresentacion = r.IDPresentacion  inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen   inner join Insumo i on sa.IDInsumo = i.IDInsumo    inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  inner join TipoPago tp on v.IDTipoPago = tp.IDTipoPago where v.Anulada = 'False' and MONTH(c.FECHA_HORA) = '" + (cbxMes.SelectedIndex + 1) + "' and YEAR(c.FECHA_HORA) = '" + txtAño.Text + "' and tp.TipoPago = 'CORTESIA' and i.IDInsumo = '" + idInsumo + "' and cast(c.FECHA_HORA as date) = '" + fecha + "' and c.IDSucursal = '"+cboSucursal.SelectedValue+"' group by i.Insumo,c.FECHA_HORA")));
                    double Credito = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select CAST(sum(r.Cantidad * dv.Cantidad) AS DECIMAL(18,3)) as Cantidad from venta v  inner join CAJA c on v.IDCaja = c.id  inner join VentaDetalle dv on v.IDVenta = dv.IDVenta  inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion  inner join Receta r on p.IDPresentacion = r.IDPresentacion  inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen   inner join Insumo i on sa.IDInsumo = i.IDInsumo    inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  inner join TipoPago tp on v.IDTipoPago = tp.IDTipoPago where v.Anulada = 'False' and MONTH(c.FECHA_HORA) = '" + (cbxMes.SelectedIndex + 1) + "' and YEAR(c.FECHA_HORA) = '" + txtAño.Text + "' and tp.TipoPago = 'CREDITO' and i.IDInsumo = '" + idInsumo + "' and cast(c.FECHA_HORA as date) = '" + fecha + "'  and c.IDSucursal = '" + cboSucursal.SelectedValue + "' group by i.Insumo,c.FECHA_HORA")));
                    double DescuentoPersonal = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select CAST(sum(r.Cantidad * dv.Cantidad) AS DECIMAL(18,3)) as Cantidad from venta v  inner join CAJA c on v.IDCaja = c.id  inner join VentaDetalle dv on v.IDVenta = dv.IDVenta  inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion  inner join Receta r on p.IDPresentacion = r.IDPresentacion  inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen   inner join Insumo i on sa.IDInsumo = i.IDInsumo    inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  inner join TipoPago tp on v.IDTipoPago = tp.IDTipoPago where v.Anulada = 'False' and MONTH(c.FECHA_HORA) = '" + (cbxMes.SelectedIndex + 1) + "' and YEAR(c.FECHA_HORA) = '" + txtAño.Text + "' and tp.TipoPago = 'DESCUENTO PERSONAL' and i.IDInsumo = '" + idInsumo + "' and cast(c.FECHA_HORA as date) = '" + fecha + "'  and c.IDSucursal = '" + cboSucursal.SelectedValue + "' group by i.Insumo,c.FECHA_HORA")));

                    //Tipo de Salida
                    double cena = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura   inner join Insumo i on de.IDInsumo = i.IDInsumo   inner join TipoSalida ts on ei.IDTipoSalida = ts.IDTipoSalida where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + lblInsumo.Text + "' and aa.FechaApertura = '" + fecha + "' and ts.TipoSalida = 'CENA' and aa.IDSucursal = '"+cboSucursal.SelectedValue+"' and de.Anulado = '0'")));
                    double jugueria = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura   inner join Insumo i on de.IDInsumo = i.IDInsumo   inner join TipoSalida ts on ei.IDTipoSalida = ts.IDTipoSalida where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + lblInsumo.Text + "' and aa.FechaApertura = '" + fecha + "' and ts.TipoSalida = 'JUGUERIA' and aa.IDSucursal = '" + cboSucursal.SelectedValue + "' and de.Anulado = '0'")));
                    double ventaManual = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura   inner join Insumo i on de.IDInsumo = i.IDInsumo   inner join TipoSalida ts on ei.IDTipoSalida = ts.IDTipoSalida where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + lblInsumo.Text + "' and aa.FechaApertura = '" + fecha + "' and ts.TipoSalida = 'VENTA MANUAL' and aa.IDSucursal = '" + cboSucursal.SelectedValue + "' and de.Anulado = '0'")));
                    double traslado = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura   inner join Insumo i on de.IDInsumo = i.IDInsumo   inner join TipoSalida ts on ei.IDTipoSalida = ts.IDTipoSalida where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + lblInsumo.Text + "' and aa.FechaApertura = '" + fecha + "' and ts.TipoSalida = 'TRASLADO'  and aa.IDSucursal = '" + cboSucursal.SelectedValue + "' and de.Anulado = '0'")));
                    double descarte = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura   inner join Insumo i on de.IDInsumo = i.IDInsumo   inner join TipoSalida ts on ei.IDTipoSalida = ts.IDTipoSalida where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + lblInsumo.Text + "' and aa.FechaApertura = '" + fecha + "' and ts.TipoSalida = 'DESCARTE' and aa.IDSucursal = '" + cboSucursal.SelectedValue + "' AND de.Anulado = '0'")));
                    double tequeños = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura   inner join Insumo i on de.IDInsumo = i.IDInsumo   inner join TipoSalida ts on ei.IDTipoSalida = ts.IDTipoSalida where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + lblInsumo.Text + "' and aa.FechaApertura = '" + fecha + "' and ts.TipoSalida = 'TEQUEÑOS' and aa.IDSucursal = '" + cboSucursal.SelectedValue + "' AND de.Anulado = '0'")));
                    double almuerzo = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura   inner join Insumo i on de.IDInsumo = i.IDInsumo   inner join TipoSalida ts on ei.IDTipoSalida = ts.IDTipoSalida where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + lblInsumo.Text + "' and aa.FechaApertura = '" + fecha + "' and ts.TipoSalida = 'ALMUERZO' and aa.IDSucursal = '" + cboSucursal.SelectedValue + "' AND de.Anulado = '0'")));
                    double prestamo = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(de.Cantidad)  from DetalleSalidaInsumo de inner join SalidaInsumo ei on de.IDSalidaInsumo = ei.IDSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join SalidaTienda et on ei.IDSalida = et.IDSalida inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura   inner join Insumo i on de.IDInsumo = i.IDInsumo   inner join TipoSalida ts on ei.IDTipoSalida = ts.IDTipoSalida where a.PermiteVender = 'True' and ei.Anulada = 'False' and i.Insumo = '" + lblInsumo.Text + "' and aa.FechaApertura = '" + fecha + "' and ts.TipoSalida = 'SALIDA PRESTAMO' and aa.IDSucursal = '" + cboSucursal.SelectedValue + "' AND de.Anulado = '0'")));
                    double delivery = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select CAST(sum(r.Cantidad * dv.Cantidad) AS DECIMAL(18,3)) as Delivery from venta v  inner join CAJA c on v.IDCaja = c.id  inner join VentaDetalle dv on v.IDVenta = dv.IDVenta  inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion  inner join Receta r on p.IDPresentacion = r.IDPresentacion  inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen  inner join Insumo i on sa.IDInsumo = i.IDInsumo   inner join Almacen a on sa.IDAlmacen = a.IDAlmacen inner join TipoPago tp on v.IDTipoPago = tp.IDTipoPago where v.Anulada = 'False' and MONTH(c.FECHA_HORA) = '" + (cbxMes.SelectedIndex + 1) + "' and YEAR(c.FECHA_HORA) = '" + txtAño.Text + "' and v.TipoVenta = 'VD' and i.IDInsumo = '" + idInsumo + "' and tp.TipoPago != 'CORTESIA' and TP.TipoPago != 'DESCUENTO PERSONAL' and tp.TipoPago != 'CREDITO' and cast(c.FECHA_HORA as date) = '" + fecha + "' and c.IDSucursal = '"+cboSucursal.SelectedValue+"' group by i.Insumo,c.FECHA_HORA")));
                    double salon = Convert.ToDouble(row.Cells["Salon"].Value);

                    double totalSalida = Cortesia + Credito + DescuentoPersonal + cena + jugueria +ventaManual + traslado + descarte + tequeños + almuerzo + prestamo + delivery + salon;
                    double saldoSistema = (totalIngreso - totalSalida);

                    //TIPO DE PAGO
                    row.Cells["Delivery"].Value = delivery.ToString("0.000");
                    row.Cells["Cortesia"].Value = Cortesia.ToString("0.000");
                    row.Cells["Credito"].Value = Credito.ToString("0.000");
                    row.Cells["DescuentoPersonal"].Value = DescuentoPersonal.ToString("0.000");

                    //TIPO DE SALIDA
                    row.Cells["Cena"].Value = cena.ToString("0.000");
                    row.Cells["Jugueria"].Value = jugueria.ToString("0.000");
                    row.Cells["Traslado"].Value = traslado.ToString("0.000");
                    row.Cells["Descarte"].Value = descarte.ToString("0.000");
                    row.Cells["Tequeños"].Value = tequeños.ToString("0.000");
                    row.Cells["Almuerzo"].Value = almuerzo.ToString("0.000");
                    row.Cells["PrestamoSalida"].Value = prestamo.ToString("0.000");
                    row.Cells["VentaManual"].Value = ventaManual.ToString("0.000");

                    //TOTAL
                    row.Cells["SalidaTotal"].Value = totalSalida.ToString("0.000");
                    row.Cells["SaldoSistema"].Value = saldoSistema.ToString("0.000");
                    row.Cells["SaldoReal"].Value = saldoFinal.ToString("0.000");

                    if (saldoSistema == saldoFinal)
                    {
                        row.Cells["Estado"].Value = "CUADRA";
                    }
                    else
                    {
                        row.Cells["Estado"].Value = "NO CUADRA";
                        row.Cells["Estado"].Style.BackColor = Color.LightCoral;
                    }

                    row.Cells["Diferencia"].Value = (saldoSistema - saldoFinal);
                }

                dgvDatos.Columns["SaldoInicial"].DefaultCellStyle.BackColor = Color.BurlyWood;
                dgvDatos.Columns["IngresoTotal"].DefaultCellStyle.BackColor = Color.BurlyWood;
                dgvDatos.Columns["SalidaTotal"].DefaultCellStyle.BackColor = Color.BurlyWood;
                dgvDatos.Columns["SaldoSistema"].DefaultCellStyle.BackColor = Color.BurlyWood;
                dgvDatos.Columns["Estado"].DefaultCellStyle.BackColor = Color.BurlyWood;
                dgvDatos.Columns["Diferencia"].DefaultCellStyle.BackColor = Color.BurlyWood;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void FrmCuadreInsumo_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal", "IDSucursal", "Sucursal", cboSucursal);
            fn.CargarCombo("i.Insumo","i.IDInsumo", "StockAlmacen sa  inner join Insumo i on sa.IDInsumo = i.IDInsumo  where sa.PermitirControl = 1 group by i.Insumo,i.IDInsumo", cbxInsumo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ex.exportaraexcelTimer(dgvDatos, progressBar1);
        }
    }
}
