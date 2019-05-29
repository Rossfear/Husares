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
    public partial class FVentaRepartidor : Form
    {
        Funciones fn = new Funciones();
        public FVentaRepartidor()
        {
            InitializeComponent();
        }

        private void FVentaRepartidor_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Nombres","IDRepartidor", "Repartidor",cboRepartidor);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = fn.procedimientoAlmacenado("Venta_Repartidor_Listar");
            cmd.Parameters.AddWithValue("@FechaEmision",dtpFechaInicio.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@FechaFin", dtpFechaFin.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@IDRepartidor", cboRepartidor.SelectedValue);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            adaptador.Fill(tabla);


            dgvDatos.DataSource = tabla;


            lblCantidad.Text = dgvDatos.Rows.Count.ToString(); ;
        }
    }
}
