using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Compra;
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

namespace SwJugueriaAgustin.Formularios.Login
{
    public partial class FrmRCompraContable : Form
    {
        Funciones fn = new Funciones();
        public FrmRCompraContable()
        {
            InitializeComponent();
        }

        private void FrmCompraLogistica_Load(object sender, EventArgs e)
        {
            
            
        }

        private void txtAño_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar();

            }

        }

        private void buscar()
        {
            try
            {
                //MOSTRAMOS EL DATADRIG
                string codRegistroLogistica = fn.select_one_value("IDRegistroCompraLogistica", "RegistroCompraLogistica", "MES='" + cbxMes.Text + "' AND AÑO='" + txtAño.Text + "'", 0);
                string codRegistroContable = fn.select_one_value("IDRegistroCompra", "RegistroCompra", "MES='" + cbxMes.Text + "' AND AÑO='" + txtAño.Text + "'", 0);
                MostrarGrid(codRegistroContable, codRegistroLogistica);

                obtenerDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarGrid(string idRegistroContable, string idRegistroLogistica)
        {
            SqlCommand cmd = fn.procedimientoAlmacenado("sp_RCompraContable");
            cmd.Parameters.AddWithValue("@idRegistroContable", idRegistroContable);
            cmd.Parameters.AddWithValue("@idRegistroLogistica", idRegistroLogistica);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dgvDetalle.DataSource = dt;
        }



        private void cbxMes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAño.Focus();
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _editar();
        }

        private void _editar()
        {



        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            
            ex.exportaraexcelTimer(dgvDetalle,progressBar1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
            
        }

        private void obtenerDatos()
        {
            lblNroCompras.Text = dgvDetalle.Rows.Count.ToString();
            Int32 i = 0;
            decimal afecto = 0, inafecto = 0, igv = 0, total = 0;

            
            foreach(DataGridViewRow row in dgvDetalle.Rows)
            {
                i++;
                row.Cells["Item"].Value = i;
                afecto += Convert.ToDecimal(row.Cells["AGOG_Base"].Value);
                inafecto += Convert.ToDecimal(row.Cells["VA_NOGravada"].Value);
                igv += Convert.ToDecimal(row.Cells["AGOG_Igv"].Value);
                total += Convert.ToDecimal(row.Cells["Total"].Value);
            }

            lblInafecto.Text = inafecto.ToString("#,#.00");
            lblBase.Text = afecto.ToString("#,#.00");
            lblIGV.Text = igv.ToString("#,#.00");
            lblTotal.Text = total.ToString("#,#.00");
        }
    }
}
