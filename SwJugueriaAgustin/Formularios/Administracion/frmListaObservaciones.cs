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

namespace SwJugueriaAgustin.Formularios
{
    public partial class frmListaObservaciones : Form
    {

        Funciones fn = new Funciones();

        public frmListaObservaciones()
        {
            InitializeComponent();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvListaObservaciones.Rows.Count > 0)
            {
                string idVenta = dgvListaObservaciones.CurrentRow.Cells[2].Value.ToString();

                fn.MostrarGri("p.IDPresentacion,s.SubCategoria,p.Presentacion,dv.Cantidad,dv.Precio,dv.Cantidad * dv.Precio as SubTotal",
                "Presentacion p,DetalleVenta dv,Categoria c,Venta v,Producto pr,SubCategoria s",
                "dv.IDPresentacion = p.IDPresentacion and dv.IDVenta = v.IDVenta and p.IDProducto = pr.IDProducto and pr.IDSubcategoria = s.IDSubCategoria and c.IDCategoria = s.IDCategoria and dv.IDVenta = '" + idVenta + "'", dgvDetalleVenta, "DetalleVenta");
            }
            else
            {
                MessageBox.Show("No se Selecciono Ninguna Observación", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void MostrarGrid()
        {
            fn.ActualizarGrid(dgvListaObservaciones, "SELECT * FROM Observacion WHERE Atendido='False' and FechaSolicitud between '" + dtpFecha1.Value.ToShortDateString() + "' and '" + dtpFecha2.Value.ToShortDateString() + "'");

        }
        private void frmListaObservaciones_Load(object sender, EventArgs e)
        {

            MostrarGrid();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvListaObservaciones.Rows.Count <= 0)
            {
                MessageBox.Show("Seleccione Observacion", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            DialogResult msj = MessageBox.Show("Seguro que SI Desea Anular Esta Venta?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (msj == DialogResult.OK)
            {

                if (dgvListaObservaciones.Rows.Count > 0)
                {
                    string idVenta = dgvListaObservaciones.CurrentRow.Cells[2].Value.ToString();
                    string idObservacion = dgvListaObservaciones.CurrentRow.Cells[0].Value.ToString();

                    RegresarStock(idVenta);

                    //ANULAMOS VENTA
                    fn.Modificar("Venta", "Anulada='True'", "IDVenta='" + dgvListaObservaciones.CurrentRow.Cells[2].Value.ToString() + "'");

                    //ATENDEMOS OBSERVACION
                    fn.Modificar("Observacion", "Atendido='True'", "IDObservacion='" + idObservacion + "'");




                    //REGISTRAMOS ANULACION
                    fn.RegistrarOficial("[Venta.Seguridad]", "Fecha,Hora,IDVenta,IDUsuario,Movimiento", "'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToLongTimeString() + "','" + idVenta + "','" + Datos.idUsuario + "','VENTA ANULADA'");

                    MessageBox.Show("Venta Anulada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarGrid();

                    if (dgvListaObservaciones.Rows.Count == 0)
                    {
                        this.Close();
                    }
                }
            }

        }






        private void RegresarStock(string idventa)
        {
            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                SqlConnection conexion = new SqlConnection(Funciones.preconex);
                string oncod = "select IDStockAlmacen,Cantidad from Receta WHERE IDPresentacion = '" + row.Cells[0].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(oncod, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    string idStockAlmacen = lector["IDStockAlmacen"].ToString();

                    //Descontando receta de producto paraventa
                    float devolucion = Convert.ToSingle(lector["Cantidad"].ToString()) * Convert.ToSingle(row.Cells["CANTIDAD"].Value.ToString());
                    fn.Modificar("StockAlmacen", "stock=stock+(" + devolucion + ")", "IDStockAlmacen='" + idStockAlmacen + "'");

                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.Rows.Count <= 0)
            {
                MessageBox.Show("Seleccionar VER PRODUCTOS DE LA VENTA", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult msj = MessageBox.Show("Seguro que NO Desea Anular Esta Venta?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (msj == DialogResult.OK)
            {
                if (dgvListaObservaciones.Rows.Count > 0)
                {
                    string idVenta = dgvListaObservaciones.CurrentRow.Cells[2].Value.ToString();
                    string idObservacion = dgvListaObservaciones.CurrentRow.Cells[0].Value.ToString();
                    fn.Modificar("Observacion", "Atendido='True'", "IDObservacion='" + idObservacion + "'");


                    //REGISTRAMOS ANULACION
                    fn.RegistrarOficial("[Venta.Seguridad]", "Fecha,Hora,IDVenta,IDUsuario,Movimiento", "'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToLongTimeString() + "','" + idVenta + "','" + Datos.idUsuario + "','VENTA NO ANULADA'");
                    MessageBox.Show("Venta NO Anulada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarGrid();
                }
            }

        }

        private void dgvListaObservaciones_RowEnter(object sender, DataGridViewCellEventArgs e)
        {







        }

        private void dtpFecha1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFecha2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvListaObservaciones_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarGrid();
        }

        private void dgvListaObservaciones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            foreach (DataGridViewRow row in dgvListaObservaciones.SelectedRows)
            {
                string idVenta = dgvListaObservaciones.CurrentRow.Cells["IDVenta"].Value.ToString();
                fn.ActualizarGrid(dgvDetalleVenta, "select pr.IDPresentacion,pro.Producto + ' '+pr.Presentacion as [Presentacion],pd.Cantidad,pd.Precio,cast(pd.Cantidad * pd.Precio as decimal(18,2)) as Importe from venta v  inner join VentaDetalle pd on v.IDVenta = pd.IDVenta inner join presentacion pr on pd.IDPresentacion = pr.IDPresentacion  inner join Producto pro on pr.IDProducto = pro.IDProducto  where v.IDVenta = '" + idVenta + "'");
            }
        }
    }
}
