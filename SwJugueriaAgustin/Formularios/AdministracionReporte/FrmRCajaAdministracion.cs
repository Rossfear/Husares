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

namespace SwJugueriaAgustin.Formularios.AdministracionReporte
{
    public partial class FrmRCajaAdministracion : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmRCajaAdministracion()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;

                bool tipoOperacion = false;

                if (cboAgrupacion.Text == "Tipo Operación") tipoOperacion = true;

                DataTable dt = new DataTable();
                SqlCommand cmd = fn.procedimientoAlmacenado("spReporteAdministracion");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@año", txtAño.Text);
                cmd.Parameters.AddWithValue("@mes", cbxMes.Text);
                cmd.Parameters.AddWithValue("@tipoOperacion", tipoOperacion);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                calcularTotales();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void calcularTotales()
        {
            double abono = 0, cargo = 0, saldoInicial = 0;

            saldoInicial = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select SaldoInicial from RegistroAdministracion where Mes = '" + cbxMes.Text + "' and Año='" + txtAño.Text + "'")));
            lblSaldoInicial.Text = saldoInicial.ToString("#,#.00");


            foreach (DataGridViewRow rowCuadre in dataGridView1.Rows)
            {
                abono += Convert.ToDouble(rowCuadre.Cells["Abono"].Value);
                cargo += Convert.ToDouble(rowCuadre.Cells["Cargo"].Value);
            }

            lblAbono.Text = abono.ToString("#,#.00");
            lblCargo.Text = cargo.ToString("#,#.00");
            lblSaldo.Text = (saldoInicial + abono - cargo).ToString("#,#.00");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ex.exportaraexcelTimer(dataGridView1, progressBar1);
        }
    }
}
