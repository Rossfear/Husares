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
    public partial class FrmVentaInsumo : Form
    {
        Funciones fn = new Funciones();
        public FrmVentaInsumo()
        {
            InitializeComponent();
        }

        private void FrmVentaInsumo_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Insumo", "sa.IDInsumo", "StockAlmacen  sa,Insumo i  where sa.IDInsumo = i.IDInsumo and IDAlmacen =(select IDAlmacen from almacen where almacen = 'ALMACEN TIENDA SAN AGUSTIN')", cbxInsumo);

            
        }
        private void agregarHora(ComboBox combohora, ComboBox comboMinutos)
        {
            for (short i = 0; i <= 23; i++)
            {
                combohora.Items.Add(i.ToString("00"));
            }

            for (short i = 0; i <= 59; i++)
            {
                comboMinutos.Items.Add(i.ToString("00"));
            }


        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fn.ActualizarGrid(dgvGeneral, "select i.Insumo,CAST(sum(r.Cantidad * dv.Cantidad) AS DECIMAL(18,2)) as Cantidad from venta v inner join CAJA c on v.IDCaja = c.id inner join VentaDetalle dv on v.IDVenta = dv.IDVenta inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion inner join Receta r on p.IDPresentacion = r.IDPresentacion inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen inner join Insumo i on sa.IDInsumo = i.IDInsumo  inner join Almacen a on sa.IDAlmacen = a.IDAlmacen  where i.Insumo like '%" + cbxInsumo.Text + "%' and v.Anulada = 'False' and cast(c.fecha_hora as date) between '" + dtpFechaInicio.Value.ToShortDateString() + "' and '" + dtpFechaFin.Value.ToShortDateString() + "' group by i.Insumo");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            ex.ExportExcelTimer(dgvGeneral, "", 20, progressBar1, "VENTAS POR INSUMO");
        }
    }
}
