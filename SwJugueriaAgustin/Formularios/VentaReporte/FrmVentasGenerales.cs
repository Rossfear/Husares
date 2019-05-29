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
    public partial class FrmVentasGenerales : Form
    {
        Funciones fn = new Funciones();
        public FrmVentasGenerales()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string comprobante;

            if (cbxTipoComp.Text == "TODOS")
            {
                comprobante = "";
            }
            else if (cbxTipoComp.Text == "BOLETA")
            {
                comprobante = "and tc.NombreComprobante = 'BOLETA'";
            }
            else if (cbxTipoComp.Text == "FACTURA")
            {
                comprobante = "and tc.NombreComprobante = 'FACTURA'";
            }
            else if (cbxTipoComp.Text == "FACTURA Y BOLETA")
            {
                comprobante = "and tc.NombreComprobante != 'TICKET'";
            }
            else
            {
                comprobante = "and tc.NombreComprobante = 'TICKET'";
            }


            fn.ActualizarGrid(dgVentas, "select CAST(c.FECHA_HORA as date) as Fecha,sum(v.IGV) as IGV,sum(v.SubTotal) as SUBTotal,sum(v.total) as TotalVenta,sum(v.pasaje) as TotalPasaje,sum(v.total) + sum(v.pasaje) as IngresoTotal from Venta v inner join  CAJA c on v.IDCaja = c.ID inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante where v.anulada = 'False' " + comprobante + " group by CAST(c.FECHA_HORA as date) having CAST(c.FECHA_HORA as date) between '" + dtpFecha.Value.ToShortDateString() + "' and '" + dtpFin.Value.ToShortDateString() + "' order by Fecha");


            //CALCULAMOS MONTOS
            SqlDataReader lector = fn.selectMultiValues("select sum(v.IGV) as IGV,sum(v.SubTotal) as SUBTotal,sum(v.total) as Total,sum(v.pasaje) as Pasaje,sum(v.total) + sum(v.pasaje) as IngresoTotal from Venta v inner join  CAJA c on v.IDCaja = c.ID inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante where v.anulada = 'False' " + comprobante + " and CAST(c.FECHA_HORA as date) between '" + dtpFecha.Value.ToShortDateString() + "' and '" + dtpFin.Value.ToShortDateString() + "'");
            lector.Read();

            lblIGV.Text = lector["IGV"].ToString();
            lblSubTotal.Text = lector["SubTotal"].ToString();
            lblTotal.Text = lector["Total"].ToString();

            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Clases.exportador lemonis = new Clases.exportador();
            lemonis.ExportExcelTimer(dgVentas, "", 0, progressBar1, "REPORTE GENERAL DE VENTAS " + dtpFecha.Value.ToShortDateString() + " - " + dtpFin.Value.ToShortDateString() + "");
        }
    }
}
