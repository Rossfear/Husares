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
    public partial class FListaDelivery : Form
    {
        Funciones fn = new Funciones();
        public FListaDelivery()
        {
            InitializeComponent();
        }

        private void FListaDelivery_Load(object sender, EventArgs e)
        {
            listargrid();
        }
        private void listargrid()
        {
            SqlCommand cmd = fn.procedimientoAlmacenado("Pedido_Listar");
            cmd.Parameters.AddWithValue("@FechaInicio",dtpFInicio.Value);
            cmd.Parameters.AddWithValue("@FechaFinal",dtpFFinal.Value);
            SqlDataAdapter dta = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dta.Fill(dt);

            dgvLista.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listargrid();
        }

        private void cancelarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string idpedido = dgvLista.CurrentRow.Cells["IDPedido"].Value.ToString();
                fn.Ejecutar("UPDATE PEDIDO SET ANULADO = 1 WHERE IDPEDIDO = '"+ idpedido +"'", false);
                listargrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void pedidoRealizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string idpedido = dgvLista.CurrentRow.Cells["IDPedido"].Value.ToString();
                fn.Ejecutar("UPDATE PEDIDO SET Vendido = 1 WHERE IDPEDIDO = '" + idpedido + "'", false);
                listargrid();
            }
            catch (Exception)
            {

                throw;
            }            
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FListaDetallePedido detalle = new FListaDetallePedido();
            detalle.IDPedido = dgvLista.CurrentRow.Cells["IDPedido"].Value.ToString();
            detalle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FPedidoCentral pedido = new FPedidoCentral();
            pedido.ShowDialog();
            listargrid();
        }
    }
}