using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Reportes
{
    public partial class FrmRPresentacionSemanal : Form
    {
        Funciones fn = new Funciones();
        public FrmRPresentacionSemanal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DateTime fecha1 = Convert.ToDateTime(dtpFecha1.Value.ToShortDateString());
            DateTime fecha2 = fecha1.AddDays(1);
            DateTime fecha3 = fecha2.AddDays(1);
            DateTime fecha4 = fecha3.AddDays(1);
            DateTime fecha5 = fecha4.AddDays(1);
            DateTime fecha6 = fecha5.AddDays(1);
            DateTime fecha7 = fecha6.AddDays(1);

            string condicionCortesia;
            if(chbxCortesia.Checked == true)
            {
                condicionCortesia = "";
            }
            else
            {
                condicionCortesia = "and v.TipoPago != 'CORTESIA'";
            }

            fn.ActualizarGrid(dgVentas, "select p.IDPresentacion,sc.SubCategoria,p.Presentacion, (select sum(dv.Cantidad) from  DetalleVenta dv inner join Venta v on dv.IDVenta = v.IDVenta   inner join  CAJA c on v.IDCaja = c.ID inner join Presentacion  p1 on dv.IDPresentacion = p1.IDPresentacion where p1.IDPresentacion = p.IDPresentacion and cast(c.FECHA_HORA as date)= '" + fecha1.ToShortDateString() + "' and v.Anulada = 'False' "+condicionCortesia+")  as [" + fecha1.ToString("dddd(dd)-MM-yyyy") + "], (select sum(dv.Cantidad) from  DetalleVenta dv inner join Venta v on dv.IDVenta = v.IDVenta   inner join  CAJA c on v.IDCaja = c.ID inner join Presentacion  p1 on dv.IDPresentacion = p1.IDPresentacion where p1.IDPresentacion = p.IDPresentacion and cast(c.FECHA_HORA as date)= '" + fecha2.ToShortDateString() + "' and v.Anulada = 'False' "+condicionCortesia+") as [" + fecha2.ToString("dddd(dd)-MM-yyyy") + "], (select sum(dv.Cantidad) from  DetalleVenta dv inner join Venta v on dv.IDVenta = v.IDVenta   inner join  CAJA c on v.IDCaja = c.ID inner join Presentacion  p1 on dv.IDPresentacion = p1.IDPresentacion where p1.IDPresentacion = p.IDPresentacion and cast(c.FECHA_HORA as date)= '" + fecha3.ToShortDateString() + "' and v.Anulada = 'False' "+condicionCortesia+") as [" + fecha3.ToString("dddd(dd)-MM-yyyy") + "], (select sum(dv.Cantidad) from  DetalleVenta dv inner join Venta v on dv.IDVenta = v.IDVenta   inner join  CAJA c on v.IDCaja = c.ID inner join Presentacion  p1 on dv.IDPresentacion = p1.IDPresentacion where p1.IDPresentacion = p.IDPresentacion and cast(c.FECHA_HORA as date)= '" + fecha4.ToShortDateString()+ "' and v.Anulada = 'False' "+condicionCortesia+") as [" + fecha4.ToString("dddd(dd)-MM-yyyy") + "],( select sum(dv.Cantidad) from  DetalleVenta dv inner join Venta v on dv.IDVenta = v.IDVenta   inner join  CAJA c on v.IDCaja = c.ID inner join Presentacion  p1 on dv.IDPresentacion = p1.IDPresentacion where p1.IDPresentacion = p.IDPresentacion and cast(c.FECHA_HORA as date)= '" + fecha5.ToShortDateString() + "' and v.Anulada = 'False' "+condicionCortesia+") as [" + fecha5.ToString("dddd(dd)-MM-yyyy") + "], ( select sum(dv.Cantidad) from  DetalleVenta dv inner join Venta v on dv.IDVenta = v.IDVenta   inner join  CAJA c on v.IDCaja = c.ID inner join Presentacion  p1 on dv.IDPresentacion = p1.IDPresentacion where p1.IDPresentacion = p.IDPresentacion and cast(c.FECHA_HORA as date)= '" + fecha6.ToShortDateString() + "' and v.Anulada = 'False' "+condicionCortesia+") as '" + fecha6.ToString("dddd(dd)-MM-yyyy") + "',( select sum(dv.Cantidad) from  DetalleVenta dv inner join Venta v on dv.IDVenta = v.IDVenta   inner join CAJA c on v.IDCaja = c.ID inner join Presentacion p1 on dv.IDPresentacion = p1.IDPresentacion where p1.IDPresentacion = p.IDPresentacion and cast(c.FECHA_HORA as date)= '" + fecha7.ToShortDateString() + "' and v.Anulada = 'False' "+condicionCortesia+") as [" + fecha7.ToString("dddd(dd)-MM-yyyy") + "] from Presentacion p inner join Producto pr on p.IDProducto = pr.IDProducto inner join SubCategoria sc on pr.IDSubcategoria = sc.IDSubCategoria group by p.Presentacion,p.IDPresentacion,sc.SubCategoria");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            ex.ExportExcelTimer(dgVentas, "", 50, progressBar1, "");
        }
    }
}
