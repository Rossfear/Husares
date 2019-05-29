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

namespace SwJugueriaAgustin.Formularios.VentaReporte.Caja
{
    public partial class FrmRespuestasCaja : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmRespuestasCaja()
        {
            InitializeComponent();
        }

        private void FrmRespuestasCaja_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Usuario","IDCajera", "Cajera",cboUsuario);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DataTable dt = new DataTable();

            SqlCommand cmd =  fn.procedimientoAlmacenado("spRRespuestaCajas");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCajera",cboUsuario.SelectedValue);
            cmd.Parameters.AddWithValue("@contraseña", txtContraseña.Text);
            cmd.Parameters.AddWithValue("@año", txtAño.Text);
            cmd.Parameters.AddWithValue("@mes", (cbxMes.SelectedIndex + 1));

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
