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

namespace SwJugueriaAgustin.Formularios.ReporteVenta
{
    public partial class FrmVentaCliente : Form
    {
        Funciones fn = new Funciones();
        exportador ex;
        public FrmVentaCliente()
        {
            InitializeComponent();
        }

        private void FrmVentaCliente_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Funciones.preconex);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("sp_VentaxCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechaInicio", dtpFecha.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@fechaFin", dtpFin.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@Cliente", "");
            cmd.ExecuteNonQuery();

            //crear data set
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            

            Da.Fill(Dt);

            

            dgVentas.DataSource = Dt;

            double total = 0;
            foreach(DataGridViewRow row in dgVentas.Rows)
            {
                double venta = Convert.ToDouble(row.Cells["Venta"].Value);
                total += venta;
            }

            lblIngresoTotal.Text = total.ToString("#,#.00");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ex = new exportador();
            ex.ExportExcelTimer(dgVentas, "", 10, progressBar1, "VENTAS POR CLIENTE " + dtpFecha.Value.ToShortDateString() + " - " + dtpFin.Value.ToShortDateString() + "");
        }
    }
}
