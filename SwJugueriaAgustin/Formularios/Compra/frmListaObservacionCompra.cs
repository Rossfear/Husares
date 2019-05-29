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
    public partial class frmListaObservacionCompra : Form
    {
        Funciones fn = new Funciones();
        public frmListaObservacionCompra()
        {
            InitializeComponent();
        }

        private void frmListaObservacionCompra_Load(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void mostrarGrid()
        {
            fn.ActualizarGrid(dgvListaObservaciones, "select c.IDTipoComprobante,co.IDObservacionCompra,c.IDCompra,c.IDAlmacen,co.FechaSolicitud,c.Serie,c.Numero,p.RazonSocial,c.Total,co.Observacion from compraObservacion co inner join Compra c on co.IDCompra = c.IDCompra inner join Proveedor p on c.IDProveedor = p.IDProveedor  where co.FechaSolicitud between '" + dtpFecha1.Value.ToShortDateString()+"' and '"+dtpFecha2.Value.ToShortDateString()+"' and Atendido = 'False'");
            dgvListaObservaciones.Columns["IDObservacionCompra"].Visible = false;
            dgvListaObservaciones.Columns["IDCompra"].Visible = false;
            dgvListaObservaciones.Columns["IDAlmacen"].Visible = false;
            dgvListaObservaciones.Columns["IDTipoComprobante"].Visible = false;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //VALIDAMOS AL ELIMINAR
            if(validacionEliminar() == false)
            {
                return;
            }

            if (dgvDetalleVenta.Rows.Count > 0)
            {

                string idCompra = dgvListaObservaciones.CurrentRow.Cells["IDCompra"].Value.ToString();
                string IDAlmacen = dgvListaObservaciones.CurrentRow.Cells["IDAlmacen"].Value.ToString();

                
                bool antiguoAumentaStock = Convert.ToBoolean(fn.selectValue("select AumentaStock FROM compra where IDCompra = '" + idCompra + "'"));

                //SI EN LA COMPRA ANTERIOR SE AUMENTO EL STOCK - LO DESMINUIMOS
                if (antiguoAumentaStock == true)
                {
                    //DEVOLVEMOS EL STOCK GENERAL
                    for (short i = 0; i < dgvDetalleVenta.Rows.Count; i++)
                    {
                        string idInsumo = dgvDetalleVenta.Rows[i].Cells["CodInsumo"].Value.ToString();
                        string cantidad = dgvDetalleVenta.Rows[i].Cells["Cantidad"].Value.ToString();
                        fn.Modificar("StockAlmacen", "Stock=Stock-" + cantidad, "IDInsumo='" + idInsumo + "' and IDAlmacen='"+IDAlmacen+"'");

                        fn.RegistrarOficial("Kardex", "Fecha,Proceso,CodProceso,Entrada,Salida,Saldo,IDStockAlmacen", "'" + DateTime.Now.ToShortDateString() + "','ANULACION COMPRA','" + idCompra + "','0','" + cantidad + "',(Select Stock from StockAlmacen where IDAlmacen = '" + IDAlmacen + "' and IDInsumo = '" + idInsumo + "'),(select IDStockAlmacen from StockAlmacen where IDAlmacen = '" + IDAlmacen + "' and IDInsumo='" + idInsumo + "')");
                    }
                }

                


                string IDEntrada = fn.selectValue("select IDEntrada from EntradaCompra where IDCompra = '" + idCompra + "' ");

                fn.Eliminar("DetalleCompra", "IDCompra='" + idCompra + "'");
                fn.Eliminar("DetalleEntradaInsumo", "IDEntradaInsumo='" + IDEntrada + "'");
                fn.Eliminar("EntradaInsumo", "IDEntrada='" + IDEntrada + "'");
                fn.Eliminar("EntradaTienda", "IDEntrada='" + IDEntrada + "'");
                fn.Eliminar("Compra", "IDCompra='" + idCompra + "'");

                //REGISTRAMOS ELIMINACIOND DE LA COMPRA
                string IDTipoComprobante = dgvListaObservaciones.CurrentRow.Cells["IDTipoComprobante"].Value.ToString();
                string serie = dgvListaObservaciones.CurrentRow.Cells["serie"].Value.ToString();
                string numero = dgvListaObservaciones.CurrentRow.Cells["numero"].Value.ToString();
                string proveedor = dgvListaObservaciones.CurrentRow.Cells["RazonSocial"].Value.ToString();
                string total = dgvListaObservaciones.CurrentRow.Cells["Total"].Value.ToString();

                fn.RegistrarOficial("CompraEliminada", "Fecha,Hora,IDTipoComprobante,Serie,Numero,Proveedor,Total,IDUsuario",
                    "'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + IDTipoComprobante + "','" + serie + "','" + numero + "','" + proveedor + "','" + total + "','" + Datos.idUsuario + "'");

                //Atendemos la observacion
                fn.Modificar("CompraObservacion", "Atendido='True'", "IDObservacionCompra='" + dgvListaObservaciones.CurrentRow.Cells["IDObservacionCompra"].Value.ToString() + "'");
                mostrarGrid();


                


                MessageBox.Show("Compra Eliminada", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (dgvListaObservaciones.Rows.Count == 0)
                {
                    this.Close();
                }
            }
        }

        private bool validacionEliminar()
        {
            if(dgvListaObservaciones.Rows.Count == 0)
            {
                MessageBox.Show("Seleccionar Compra", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            DialogResult msj = MessageBox.Show("¿Desea Eliminar la Compra?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (msj == DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }

        private void anulamosEntrada(string idEntrada,string idCompra)
        {
            //ANULAMOS ENTRADA COMPRA
            fn.Modificar("EntradaCompra", "Anulada='True'", "IDCompra='" + idCompra + "'");

            //ANULAMOS LA ENTRADA
            fn.Modificar("EntradaInsumo", "Anulada='True'", "IDEntrada='" + idEntrada + "'");


        }

        private void dgvListaObservaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaObservaciones.Rows.Count > 0)
            {
                fn.MostrarGri("i.IDInsumo as CodInsumo,i.Insumo,dc.Cantidad,dc.Costo", "DetalleCompra dc,insumo i", "dc.IDInsumo = i.IDInsumo and  IDCompra = '" + dgvListaObservaciones.CurrentRow.Cells["IDCompra"].Value.ToString() + "'", dgvDetalleVenta, "DetalleCompra");
                dgvDetalleVenta.Columns["CodInsumo"].Visible = false;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvListaObservaciones.Rows.Count > 0)
            {
                if (dgvDetalleVenta.Rows.Count > 0)
                {
                    string idCompra = dgvListaObservaciones.CurrentRow.Cells[2].Value.ToString();
                    DialogResult msj = MessageBox.Show("Desea NO Cancelar la Compra " + idCompra + " ?", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (msj == DialogResult.OK)
                    {
                        //Atendemos la observacion
                        fn.Modificar("CompraObservacion", "Atendido='True'", "IDObservacionCompra='" + dgvListaObservaciones.CurrentRow.Cells[0].Value.ToString() + "'");

                        //Actualizamos ]Grid
                        mostrarGrid();


                       

                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mostrarGrid();
        }
    }
}
