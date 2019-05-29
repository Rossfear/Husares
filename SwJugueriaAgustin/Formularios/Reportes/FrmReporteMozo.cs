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

namespace SwJugueriaAgustin.Formularios.Reportes
{
    public partial class FrmReporteMozo : Form
    {
        Funciones fn = new Funciones();
        public FrmReporteMozo()
        {
            InitializeComponent();
        }

        private void MostrarGrid()
        {
            SqlCommand cmd = fn.procedimientoAlmacenado("sp_ReportProductosMozo");
            cmd.Parameters.AddWithValue("@FechaInicio", dtpFechaInicio.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@FechaFin", dtpFechaFin.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@Presentacion", txtPresentacion.Text);
            cmd.Parameters.AddWithValue("@IDMozo", cboMozo.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

            dgvDatos.DataSource = tabla;
        }


        private void FrmReporteMozo_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Nombres", "IDMozo", "Mozo", cboMozo);
            //fn.CargarCombo("Producto", "IDProducto", "Producto", cboProducto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MostrarGrid();
        }
    }
}
