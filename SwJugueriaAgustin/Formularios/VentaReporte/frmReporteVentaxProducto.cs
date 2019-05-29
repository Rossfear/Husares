using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class frmReporteVentaxProducto : Form
    {
        public frmReporteVentaxProducto()
        {
            InitializeComponent();
        }
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        private void frmReporteVentaxProducto_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal", "IDSucursal", "SUCURSAL", cboSucursal);
        }


        private void mostrarGrid()
        {
            SqlCommand cmd = fn.procedimientoAlmacenado("Reporte_VentaxProducto_Listar");
            cmd.Parameters.AddWithValue("@FechaInicio", dtpFechaInicio.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@FechaFin", dtpFechaFin.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@Presentacion", txtPresentacion.Text);
            cmd.Parameters.AddWithValue("@IDSucursal", cboSucursal.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

            dgvReporte.DataSource = tabla;
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void txtPresentacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ex.ExportExcelTimer(dgvReporte, "Venta por Presentacion", -1, progressBar1, "Venta por Presentacion " + dtpFechaInicio.Value.ToShortDateString() + " - " + dtpFechaFin.Value.ToShortDateString() + "");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostrarGrid();
        }
    }
}
