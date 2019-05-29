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

namespace SwJugueriaAgustin.Formularios.VentaReporte
{
    public partial class FrmVentaManual : Form
    {
        Funciones fn = new Funciones();
        public FrmVentaManual()
        {
            InitializeComponent();
        }

        private void btnBusacar_Click(object sender, EventArgs e)
        {
            mostrarGrid();
            calcularTotales();
        }

        void mostrarGrid()
        {
            fn.ActualizarGrid(dgvListas, "select cm.IDCuadre,cm.NroComprobante,cm.Descripcion,cm.CantidadPollo,cm.GaseosaLitroMedio as 'Gaseosa 1.5',cm.GaseosaMedioLitro as 'Gaseosa 1/2',cm.Agua,cm.Monto from CuadreManual cm inner join caja c on cm.IDCaja = c.ID where cast(c.Fecha_Hora as date) = '" + dtpFecha.Value.ToShortDateString() + "' and Tipo='"+cboTipoVenta.Text+"' and IDSucursal = '"+cboSucursal.SelectedValue+"' order by IDCuadre desc");
            dgvListas.Columns["IDCuadre"].Visible = false;
        }

        private void FrmVentaManual_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal", "IDSucursal", "Sucursal", cboSucursal);
        }

        void calcularTotales()
        {
            double cantidadPollo = 0, gaseosaLitroMedio = 0, gaseosaMedioLitro = 0, agua = 0, monto = 0;

            foreach (DataGridViewRow grid in dgvListas.Rows)
            {
                cantidadPollo += Convert.ToDouble(grid.Cells["CantidadPollo"].Value);
                gaseosaLitroMedio += Convert.ToDouble(grid.Cells["Gaseosa 1.5"].Value);
                gaseosaMedioLitro += Convert.ToDouble(grid.Cells["Gaseosa 1/2"].Value);
                agua += Convert.ToDouble(grid.Cells["Agua"].Value);
                monto += Convert.ToDouble(grid.Cells["Monto"].Value);
            }

            txtIAgua.Text = agua.ToString("#,#.00");
            txtICantidadPollo.Text = cantidadPollo.ToString("#,#.000");
            txtIGaseosaMedioLitro.Text = gaseosaMedioLitro.ToString("#,#.000");
            txtIGaseosaLitroMedio.Text = gaseosaLitroMedio.ToString("#,#.000");
            txtIMonto.Text = monto.ToString("#,#.000");

        }
    }
}
