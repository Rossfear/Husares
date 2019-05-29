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
    public partial class FDetallePedido : Form
    {
                public FDetallePedido()
        {
            InitializeComponent();
        }

        Clases.Funciones fn = new Clases.Funciones();
        public string IDPedido;
        private void FDetallePedido_Load(object sender, EventArgs e)
        {
            DataTable Tabla = new DataTable();
            SqlCommand Comando = fn.procedimientoAlmacenado("sp_PedidoDetalle_Listar");
            Comando.Parameters.AddWithValue("@IDPedido", IDPedido);
            SqlDataAdapter da = new SqlDataAdapter(Comando);

            da.Fill(Tabla);
            dgvDatos.DataSource = Tabla;
        }
    }
}
