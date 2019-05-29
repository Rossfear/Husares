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

namespace SwJugueriaAgustin.Formularios.VentaReporte
{
    public partial class FrmRVentaConciliacion : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmRVentaConciliacion()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = fn.procedimientoAlmacenado("spConciliacionVenta");
            cmd.Parameters.AddWithValue("@mes", (cbxMes.SelectedIndex + 1));
            cmd.Parameters.AddWithValue("@año", (txtAño.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ex.exportaraexcelTimer(dataGridView1,progressBar1);
        }
    }
}
