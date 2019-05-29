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
    public partial class FrmRSalidaDinero : Form
    {
        Funciones fn = new Funciones();
        public FrmRSalidaDinero()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = fn.procedimientoAlmacenado("Reporte_MovimientoCajaxFecha_Listar");
            cmd.Parameters.AddWithValue("@FechaInicio",dtpFecha.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@FechaFin", dtpFin.Value.ToShortDateString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

            dgvSalida.DataSource = tabla;


            double ingreso = 0, salida = 0;
            foreach (DataGridViewRow fila in dgvSalida.Rows)
            {
                double monto = Convert.ToDouble(fila.Cells["Monto"].Value);
                string movimiento = fila.Cells["Movimiento"].Value.ToString();

                if(movimiento.Equals("ENTRADA"))
                {
                    ingreso += monto;
                }
                else
                {
                    salida += monto;
                }
            }

            lblIngresoTotal.Text = ingreso.ToString("#,#.00");
            lblSalidaTotal.Text = salida.ToString("#,#.00");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportador lemonis = new exportador();
            lemonis.ExportExcelTimer(dgvSalida, "", 0, progressBar1, "SALIDA DE DINERO " + dtpFecha.Value.ToShortDateString() + " - " + dtpFin.Value.ToShortDateString() + "");
        }
    }
}
