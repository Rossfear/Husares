using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class frmListaSalidaInsumo : Form
    {
        public frmListaSalidaInsumo()
        {
            InitializeComponent();
        }

        Funciones fn = new Funciones();
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostrarGrid();    
        }

        private void mostrarGrid()
        {
            fn.ActualizarGrid(dgvSalida, "select ts.TipoSalida,i.Insumo,sum(de.Cantidad) from salidaInsumo ei  inner join TipoSalida ts on ei.IDTipoSalida = ts.IDTipoSalida inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join DetalleSalidaInsumo de on ei.IDsalida = de.IDSalidaInsumo  inner join Insumo i on de.IDInsumo = i.IDInsumo  inner join Usuario u on ei.IDUsuario = u.IDUsuario  where i.Insumo like '%" + txtInsumo.Text+ "%' and ts.TipoSalida = '"+cbxTipoSalida.Text+"' and a.IDAlmacen = '" + cbxAlmacen.SelectedValue+"' and ei.Fecha between '"+dtpFechaInicio.Value.ToShortDateString()+"' and '"+dtpFechaFin.Value.ToShortDateString()+ "' and ei.Anulada='False' group by i.Insumo,ts.TipoSalida");
        }

        private void frmListaSalidaInsumo_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen", cbxAlmacen);
            fn.añadir_ddl("TipoSalida", "IDTipoSalida", "TipoSalida", cbxTipoSalida);

        }

        private void txtInsumo_TextChanged(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            ex.ExportExcelTimer(dgvSalida, "SALIDA DE INSUMO",15, progressBar1, "Salida Insumo " + dtpFechaInicio.Value.ToShortDateString() + " - " + dtpFechaFin.Value.ToShortDateString());
        }
    }
}
