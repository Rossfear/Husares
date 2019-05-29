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
    public partial class FrmListaEntradaInsumo : Form
    {
        public FrmListaEntradaInsumo()
        {
            InitializeComponent();
        }
        Funciones fn = new Funciones();
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fn.ActualizarGrid(dgvSalida, "select te.TipoEntrada,i.Insumo,SUM(de.Cantidad) as Cantidad from EntradaInsumo ei  inner join Almacen a on ei.IDAlmacenReceptor = a.IDAlmacen inner join TipoEntrada te on ei.IDTipoEntrada = te.IDTipoEntrada  inner join DetalleEntradaInsumo de on ei.IDEntrada = de.IDEntradaInsumo  inner join Insumo i on de.IDInsumo = i.IDInsumo  inner join Usuario u on ei.IDUsuario = u.IDUsuario  where i.Insumo like '%" + txtInsumo.Text+"%' and a.IDAlmacen = '"+cbxAlmacen.SelectedValue+"' and ei.Fecha between '"+dtpFechaInicio.Value.ToShortDateString()+"' and '"+dtpFechaFin.Value.ToShortDateString()+ "' and ei.Anulada='False' and te.TipoEntrada like '%"+cbxTipoEntrada.Text+"%' GROUP BY i.Insumo,te.TipoEntrada");
        }

        private void FrmListaEntradaInsumo_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("TipoEntrada", "IDTipoEntrada", "TipoEntrada", cbxTipoEntrada);
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen", cbxAlmacen);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            ex.ExportExcelTimer(dgvSalida, "ENTRADA DE INSUMO", 12, progressBar1, "Salida Insumo " + dtpFechaInicio.Value.ToShortDateString() + " - " + dtpFechaFin.Value.ToShortDateString());
        }
    }
}
