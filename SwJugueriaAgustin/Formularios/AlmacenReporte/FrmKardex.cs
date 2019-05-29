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
    public partial class FrmKardex : Form
    {
        Funciones fn = new Funciones();
        public FrmKardex()
        {
            InitializeComponent();
        }

       

        private void mostrarGrid()
        {
            fn.ActualizarGrid(dgvKardex, "select k.Fecha,a.Almacen,k.Proceso,k.CodProceso,i.Insumo,k.Entrada,k.Salida,k.Saldo from kardex k inner join StockAlmacen sa on k.IDStockAlmacen = sa.IDStockAlmacen inner join Almacen a on sa.IDAlmacen = a.IDAlmacen inner join Insumo i on sa.IDInsumo = i.IDInsumo where k.Fecha between '"+dtpInicio.Value.ToShortDateString()+"' and '"+dtpFechaFin.Value.ToShortDateString()+"' and i.IDInsumo = '"+cbxInsumo.SelectedValue+"' and a.IDAlmacen = '"+cbxAlmacen.SelectedValue+"' order by k.IDKardex");
        }

        private void FrmKardex_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where PermiteEntrada='True'", cbxAlmacen);
            
        }

       

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            ex.ExportExcelTimer(dgvKardex, "KARDEX", 0, progressBar1, "KARDEX");
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void cbxAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            fn.añadir_ddl("Insumo", "i.IDInsumo", "StockAlmacen  sa,Insumo i  where sa.IDInsumo = i.IDInsumo and IDAlmacen =(select IDAlmacen from almacen where almacen = '" + cbxAlmacen.Text + "')", cbxInsumo);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
