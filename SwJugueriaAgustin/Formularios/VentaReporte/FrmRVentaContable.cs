using SwJugueriaAgustin.Clases;
using System;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.VentaReporte
{
    public partial class FrmRVentaContable : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmRVentaContable()
        {
            InitializeComponent();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ex.exportaraexcelTimer(dgvDatos,progressBar1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            showData();
            calcularMontos();
        }

        private void calcularMontos()
        {
            decimal inafecto = 0, gravada = 0, igv = 0, total = 0;

            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                decimal vInafecto = Convert.ToDecimal(fila.Cells["Inafecta"].Value);
                decimal vGravada = Convert.ToDecimal(fila.Cells["BaseImpOpGravada"].Value);
                decimal vIgv = Convert.ToDecimal(fila.Cells["IGV"].Value);
                decimal vTotal = Convert.ToDecimal(fila.Cells["ImporteTotal"].Value);

                inafecto += vInafecto;
                gravada += vGravada;
                igv += vIgv;
                total += vTotal;
            }

            lblBase.Text = gravada.ToString("#,#.00");
            lblIGV.Text = igv.ToString("#,#.00");
            lblInafecto.Text = inafecto.ToString("#,#.00");
            lblTotal.Text = total.ToString("#,#.00");
        }

        private void showData()
        {
            dgvDatos.DataSource = null;
            SqlCommand cmd = fn.procedimientoAlmacenado("sp_RVentaContable");
            cmd.Parameters.AddWithValue("@año", txtAño.Text);
            cmd.Parameters.AddWithValue("@mes", cbxMes.SelectedIndex + 1);
            cmd.ExecuteNonQuery();


            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);

            Da.Fill(Dt);

            dgvDatos.DataSource = Dt;
        }

        private void txtAño_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                showData();
            }
        }

        private void FrmRVentaContable_Load(object sender, EventArgs e)
        {

        }
    }
}
