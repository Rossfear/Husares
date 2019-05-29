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

namespace SwJugueriaAgustin.Formularios.Venta.Delivery
{
    public partial class FListaDetallePedido : Form
    {
        Funciones fn = new Funciones();
        public string IDPedido;
        public FListaDetallePedido()
        {
            InitializeComponent();
        }

        private void FListaDetallePedido_Load(object sender, EventArgs e)
        {
            listargrid();
        }
        private void listargrid()
        {
            SqlCommand cmd = fn.procedimientoAlmacenado("PedidoDetalle_Listar");
            cmd.Parameters.AddWithValue("@IDPedido",IDPedido);
            SqlDataAdapter dta = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dta.Fill(dt);

            dgvLista.DataSource = dt;
        }
    }
}
