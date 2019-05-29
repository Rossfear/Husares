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
    public partial class FrmReporteCuadre : Form
    {
        Funciones fn = new Funciones();
        public FrmReporteCuadre()
        {
            InitializeComponent();
        }

        private void FrmReporteCuadre_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where PermiteEntrada='True'", cbxAlmacen);
            fn.añadir_ddl("Usuario", "IDUsuario", "Usuario", cbxUsuario);
            fn.añadir_ddl("Insumo", "IDInsumo", "Insumo", cbxInsumo);
            mostrarGrid();
        }

        private void mostrarGrid()
        {
            string cuadra;
            if(chbxCuadra.Checked == true)
            {
                cuadra = "0";
            }
            else
            {
                cuadra = "";
            }

            fn.ActualizarGrid(dgvSalida, "select cast(c.FECHA_HORA as date) as Fecha,ci.Hora,a.Almacen,i.Insumo,ci.SaldoReal,ci.SaldoSistema,ci.Cuadra,(ci.SaldoReal - ci.SaldoSistema) as Merma, u.Usuario from CuadreInsumo ci inner join CAJA c on ci.IDCaja = c.ID inner join StockAlmacen sa on ci.IDStockAlmacen = sa.IDStockAlmacen inner join Insumo i on sa.IDInsumo = i.IDInsumo inner join Almacen a on sa.IDAlmacen = a.IDAlmacen inner join Usuario u on ci.IDUsuario = u.IDUsuario where a.Almacen like '%"+cbxAlmacen.Text+"%' and i.Insumo like '%"+cbxInsumo.Text+"%' and u.Usuario like '%"+cbxUsuario.Text+"%' and ci.Cuadra like '%"+cuadra+"%'");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            ex.ExportExcelTimer(dgvSalida, "Reporte de Cuadre", -1, progressBar1, "CUADRE");
        }
    }
}
