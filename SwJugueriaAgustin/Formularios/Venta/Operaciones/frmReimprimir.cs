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
    public partial class frmReimprimir : Form
    {
        Funciones fn = new Funciones();
        Conversion CONVERSION = new Conversion();
        Impresion im = new Impresion();
        public frmReimprimir()
        {
            InitializeComponent();
        }

        private void frmReimprimir_Load(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Convert.ToDecimal(txtNumero.Text).ToString("00000000");

            try
            {
                string idVenta = txtSerie.Text + lblguion.Text + txtNumero.Text;

                SqlDataReader lector = fn.selectMultiValues("select V.PagoCon,v.TipoVenta,v.Vuelto,v.CodigoComanda,v.DescuentoSoles,v.igv,v.subtotal,mo.Usuario,tc.NombreComprobante, tp.TipoPago, v.Total, c.Numero, c.Telefono, v.NombreCliente, c.Direccion, c.Referencia,v.Hora,v.Fecha,m.Mesa,z.Zona,iif(v.TipoImpresion='C','CONSUMO','DETALLADO') AS TipoImpresion  from Venta v   inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante  inner join TipoPago tp on v.IDTipoPago = tp.IDTipoPago  inner join Cliente c on v.IDCliente = c.IDCliente   inner join Mesa m on v.IDMesa = m.IDMesa  inner join Zona z on m.IDZona = z.IDZona inner join Mozo mo on v.IDMozo = mo.IDMozo where IDVenta = '" + idVenta + "'");
                lector.Read();

                //OBTENEMOS LOS DATOS
                lblTipoComprobante.Text = lector["NombreComprobante"].ToString();
                lblVuelto.Text = lector["Vuelto"].ToString();
                cboTipoPago.Text = lector["TipoPago"].ToString();
                lblTotal.Text = lector["Total"].ToString();
                txtDescuentoSoles.Text = lector["DescuentoSoles"].ToString();
                lblSubTotal.Text = lector["SubTotal"].ToString();
                lblIgv.Text = lector["igv"].ToString();
                txtNroCliente.Text = lector["Numero"].ToString();
                lblTelefono.Text = lector["Telefono"].ToString();
                txtCliente.Text = lector["NombreCliente"].ToString();
                txtDireccion.Text = lector["Direccion"].ToString();
                txtReferencia.Text = lector["Referencia"].ToString();
                lblHora.Text = Convert.ToDateTime(lector["Hora"].ToString()).ToShortTimeString();
                lblFecha.Text = Convert.ToDateTime(lector["Fecha"].ToString()).ToShortDateString();
                cboTipoImpresion.Text = lector["TipoImpresion"].ToString();
                lblComanda.Text = lector["CodigoComanda"].ToString();
                lblMesa.Text = lector["Mesa"].ToString();
                lblZona.Text = lector["Zona"].ToString();
                lblMozo.Text = lector["Usuario"].ToString();
                lblTipoVenta.Text = lector["TipoVenta"].ToString();
                lblPagoCon.Text = lector["PagoCon"].ToString();


                //SHOW GRID
                DataTable tabla = new DataTable();
                SqlCommand cmd = fn.procedimientoAlmacenado("Venta_VentaDetalle_Listar");
                cmd.Parameters.AddWithValue("@IDVenta",idVenta);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                dgvPedido.DataSource = tabla;

                if (lblTipoVenta.Text == "VD")
                {
                    chbxComandaDelivery.Visible = true;
                }
                else
                {
                    chbxComandaDelivery.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pdTicketVentaT_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion



            e.Graphics.DrawString(Datos.RazonSocial, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(50, 20));
            e.Graphics.DrawString("RUC " + Datos.Ruc, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 40));
            e.Graphics.DrawString(Datos.Direccion, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 52));
            e.Graphics.DrawString(Datos.Departmaneto, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(30, 64));
            e.Graphics.DrawString("PRECUENTA", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(98, 80));

            e.Graphics.DrawString(txtSerie.Text + "-" + txtNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(98, 94));

            string direccion1 = "", direccion2 = "";

            if (txtDireccion.Text.Trim().Length >= 33)
            {
                direccion1 = txtDireccion.Text.Trim().Substring(0, 33);
                direccion2 = txtDireccion.Text.Trim().Substring(33);
            }
            else
            {
                direccion1 = txtDireccion.Text.Trim().Substring(0);
            }

            e.Graphics.DrawString("SR(A): " + txtCliente.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 121));
            //e.Graphics.DrawString("" + cliente2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 133));
            e.Graphics.DrawString("DNI: " + txtNroCliente.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 146));
            e.Graphics.DrawString("DIR: " + direccion1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 159));
            e.Graphics.DrawString("" + direccion2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(28, 169));

            e.Graphics.DrawString("TP: " + cboTipoPago.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 184));

            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 197));

            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 213));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 213));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 213), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 213), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 226));


            int SUMATORIA = 0;
            //DETALLADO
            if (cboTipoImpresion.Text == "DETALLADO")
            {
                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    string descri = row.Cells["cnPlato"].Value.ToString();

                    string cantidad = row.Cells["cnCantidad"].Value.ToString();
                    double precio = Convert.ToDouble(row.Cells["cnPrecio"].Value);
                    double importe = Convert.ToDouble(row.Cells["cnImporte"].Value);

                    e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 242 + SUMATORIA));
                    e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 242 + SUMATORIA));
                    e.Graphics.DrawString("" + precio.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 252 + SUMATORIA), alineacion);
                    e.Graphics.DrawString("" + importe.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 252 + SUMATORIA), alineacion);
                    e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 260 + SUMATORIA));
                    SUMATORIA = SUMATORIA + 30;
                }
            }
            else
            {
                e.Graphics.DrawString("1", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 242 + SUMATORIA));
                e.Graphics.DrawString("POR CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 242 + SUMATORIA + 5));
                e.Graphics.DrawString(Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 250 + SUMATORIA), alineacion);
                e.Graphics.DrawString(Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 250 + SUMATORIA), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 260 + SUMATORIA));
                SUMATORIA = SUMATORIA + 30;
            }

            e.Graphics.DrawString("DESCUENTO:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 244 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 244 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(txtDescuentoSoles.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 244 + SUMATORIA), alineacion);

            e.Graphics.DrawString("OP INAFECTA:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 257 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 257 + SUMATORIA));
            e.Graphics.DrawString("" + "0.00", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 257 + SUMATORIA), alineacion);

            e.Graphics.DrawString("OP GRAVADA:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 270 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 270 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(lblSubTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 270 + SUMATORIA), alineacion);

            e.Graphics.DrawString("IGV:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 283 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 283 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(lblIgv.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 283 + SUMATORIA), alineacion);

            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 296 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 296 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 296 + SUMATORIA), alineacion);

            string letras1 = "", letras2 = "";
            string letras = "SON: " + CONVERSION.enletras(lblTotal.Text.ToString()) + " SOLES";

            if (letras.Length >= 43)
            {
                letras1 = letras.Substring(0, 43);
                letras2 = letras.Substring(43);
            }
            else
                letras1 = letras.Substring(0);




            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 311 + SUMATORIA));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 324 + SUMATORIA));



            e.Graphics.DrawString("MESA: " + lblMesa.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 339 + SUMATORIA));
            e.Graphics.DrawString("Moso: " + lblMozo.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 352 + SUMATORIA));
            if (lblMesa.Text == "LLEVAR A" || lblMesa.Text == "LLEVAR B")
            {
                e.Graphics.DrawString("Comanda: " + txtSerie.Text + " - " + txtNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 365 + SUMATORIA));
            }
            else
            {
                e.Graphics.DrawString("Comanda: " + lblComanda.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 365 + SUMATORIA));
            }



            e.Graphics.DrawString("C*", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(10, 380 + SUMATORIA));
            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 380 + SUMATORIA));
            e.Graphics.DrawString("Canjeable por Comprobante", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(67, 395 + SUMATORIA));
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 405 + SUMATORIA));
            e.Graphics.DrawString("F: " + DateTime.Now.ToShortDateString() + "  -  H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(10, 415 + SUMATORIA));
        }



        private void pdFacturaT_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion



            e.Graphics.DrawString(Datos.RazonSocial, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(50, 20));
            e.Graphics.DrawString("RUC " + Datos.Ruc, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 40));
            e.Graphics.DrawString(Datos.Direccion, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 52));
            e.Graphics.DrawString(Datos.Departmaneto, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(30, 64));
            e.Graphics.DrawString("FACTURA DE VENTA ELECTRONICA", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(40, 80));

            e.Graphics.DrawString(txtSerie.Text + "-" + txtNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(98, 94));

            string direccion1 = "", direccion2 = "";

            if (txtDireccion.Text.Trim().Length >= 33)
            {
                direccion1 = txtDireccion.Text.Trim().Substring(0, 33);
                direccion2 = txtDireccion.Text.Trim().Substring(33);
            }
            else
            {
                direccion1 = txtDireccion.Text.Trim().Substring(0);
            }

            e.Graphics.DrawString("RAZ: " + txtCliente.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 121));
            //e.Graphics.DrawString("" + cliente2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 133));
            e.Graphics.DrawString("RUC: " + txtNroCliente.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 146));
            e.Graphics.DrawString("DIR: " + direccion1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 159));
            e.Graphics.DrawString("" + direccion2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(28, 169));

            e.Graphics.DrawString("TP: " + cboTipoPago.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 184));

            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 197));

            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 213));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 213));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 213), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 213), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 226));


            int SUMATORIA = 0;
            //DETALLADO
            if (cboTipoImpresion.Text == "DETALLADO")
            {
                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    string descri = row.Cells["cnPlato"].Value.ToString();

                    string cantidad = row.Cells["cnCantidad"].Value.ToString();
                    double precio = Convert.ToDouble(row.Cells["cnPrecio"].Value);
                    double importe = Convert.ToDouble(row.Cells["cnImporte"].Value);

                    e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 242 + SUMATORIA));
                    e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 242 + SUMATORIA));
                    e.Graphics.DrawString("" + precio.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 252 + SUMATORIA), alineacion);
                    e.Graphics.DrawString("" + importe.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 252 + SUMATORIA), alineacion);
                    e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 260 + SUMATORIA));
                    SUMATORIA = SUMATORIA + 30;
                }
            }
            else
            {
                e.Graphics.DrawString("1", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 242 + SUMATORIA));
                e.Graphics.DrawString("POR CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 242 + SUMATORIA + 5));
                e.Graphics.DrawString(Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 250 + SUMATORIA), alineacion);
                e.Graphics.DrawString(Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 250 + SUMATORIA), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 260 + SUMATORIA));
                SUMATORIA = SUMATORIA + 30;
            }

            e.Graphics.DrawString("DESCUENTO:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 244 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 244 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(txtDescuentoSoles.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 244 + SUMATORIA), alineacion);

            e.Graphics.DrawString("OP INAFECTA:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 257 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 257 + SUMATORIA));
            e.Graphics.DrawString("" + "0.00", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 257 + SUMATORIA), alineacion);

            e.Graphics.DrawString("OP GRAVADA:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 270 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 270 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(lblSubTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 270 + SUMATORIA), alineacion);

            e.Graphics.DrawString("IGV:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 283 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 283 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(lblIgv.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 283 + SUMATORIA), alineacion);

            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 296 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 296 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 296 + SUMATORIA), alineacion);

            string letras1 = "", letras2 = "";
            string letras = "SON: " + CONVERSION.enletras(lblTotal.Text.ToString()) + " SOLES";

            if (letras.Length >= 43)
            {
                letras1 = letras.Substring(0, 43);
                letras2 = letras.Substring(43);
            }
            else
                letras1 = letras.Substring(0);




            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 311 + SUMATORIA));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 324 + SUMATORIA));



            e.Graphics.DrawString("MESA: " + lblMesa.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 339 + SUMATORIA));
            e.Graphics.DrawString("Moso: " + lblMozo.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 352 + SUMATORIA));
            if (lblMesa.Text == "LLEVAR A" || lblMesa.Text == "LLEVAR B")
            {
                e.Graphics.DrawString("Comanda: " + txtSerie.Text + " - " + txtNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 365 + SUMATORIA));
            }
            else
            {
                e.Graphics.DrawString("Comanda: " + lblComanda.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 365 + SUMATORIA));
            }

            string t1 = "Representación automática de Factura de Venta";
            string t2 = "Electrónica puede ser descargado en";
            string t3 = Datos.rutaDescarga;

            e.Graphics.DrawString(t1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(25, 385 + SUMATORIA));
            e.Graphics.DrawString(t2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(45, 398 + SUMATORIA));
            e.Graphics.DrawString(t3, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 411 + SUMATORIA));

            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 431 + SUMATORIA));
            e.Graphics.DrawString("C*", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(10, 431 + SUMATORIA));
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 441 + SUMATORIA));
            e.Graphics.DrawString("F: " + Convert.ToDateTime(lblFecha.Text).ToShortDateString() + "  -  H: " + Convert.ToDateTime(lblHora.Text).ToShortTimeString(), new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(10, 454 + SUMATORIA));
        }

        private void pdBoletaT_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string tipoComprobante = "", tipoDocumento; bool ticket;

            if (lblTipoComprobante.Text == "BOLETA")
            {
                tipoComprobante = "BOLETA ELECTRONICA";
                tipoDocumento = "DNI";
                ticket = false;
            }
            else if(lblTipoComprobante.Text == "FACTURA")
            {
                tipoComprobante = "FACTURA ELECTRONICA";
                tipoDocumento = "RUC";
                ticket = false;
            }
            else
            {
                tipoComprobante = "PRECUENTA CONTROL";
                tipoDocumento = "DNI";
                ticket = true;
            }

            bool delivery = lblTipoVenta.Text.ToUpper().Equals("VD");

            im.Comprobante(tipoComprobante,tipoDocumento,e,lblFecha.Text,lblHora.Text,txtSerie.Text,txtNumero.Text,txtDireccion.Text,txtCliente.Text,txtNroCliente.Text,cboTipoPago.Text,cboTipoImpresion.Text,dgvPedido,lblTotal.Text,txtDescuentoSoles.Text,lblSubTotal.Text,lblIgv.Text,lblMesa.Text,lblMozo.Text,lblComanda.Text,true,delivery,lblPagoCon.Text,lblVuelto.Text,ticket);
        }



        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (validationImprimir() == false)
            {
                return;
            }

            try
            {
                if (chbxComprobante.Checked == true)
                {
                    pdComprobante.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Comprobante: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                if (chbxComandaDelivery.Checked == true && lblTipoVenta.Text == "VD")
                {
                    pdComandaDelivery.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Comanda: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (chbxPrintBar_Cocina.Checked == true)
            {
                try
                {
                    bool existsBar = false, existsCocina = false,existsHorno= false;

                    for (int i = 0; i < dgvPedido.Rows.Count; i++)
                    {
                        string idPresentation = dgvPedido.Rows[i].Cells["cnCodigo"].Value.ToString();
                        dgvPedido.Rows[i].Cells["cnImprimido"].Value = true;
                        //GET CATEGORY OF THE PRESENTATION
                        string category = fn.selectValue("select c.Categoria from Presentacion p,Categoria c,Producto pr,SubCategoria s where p.IDProducto = pr.IDProducto and pr.IDSubcategoria = s.IDSubCategoria and c.IDCategoria = s.IDCategoria and p.IDPresentacion = '" + idPresentation + "'");

                        if (category == "BAR")
                        {
                            existsBar = true;
                        }
                        else if (category == "HORNO")
                        {
                            existsBar = true;
                        }
                        else
                        {
                            existsCocina = true;
                        }

                        //EXISTS TWO
                        if (existsBar == true && existsCocina == true)
                        {
                            break;
                        }
                    }



                    if (existsBar == true)
                    {
                        pdBar.PrinterSettings.PrinterName = Datos.impresoraBar;
                        pdBar.Print();
                    }

                    if (existsCocina == true)
                    {
                        pdBar.PrinterSettings.PrinterName = Datos.impresoraCocina;
                        pdCocina.Print();
                    }
                    if (existsHorno == true)
                    {
                        pdBar.PrinterSettings.PrinterName = Datos.impresoraHorno;
                        pdHorno.Print();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Print Cocina: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            MessageBox.Show("Operación Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private bool validationImprimir()
        {
            if (fn.Existencia("*", "Venta", "IDVenta='" + txtSerie.Text + lblguion.Text + txtNumero.Text + "'") == false)
            {
                MessageBox.Show("Venta No Existente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (validationImprimir() == false)
            {
                return;
            }


            try
            {
                if (chbxComprobante.Checked == true)
                {
                        ppDialog.Document = pdComprobante;
                        ppDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Comprobante: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (chbxPrintBar_Cocina.Checked == true)
            {
                try
                {
                    bool existsBar = false, existsCocina = false, existsHorno = false;

                    for (int i = 0; i < dgvPedido.Rows.Count; i++)
                    {
                        string idPresentation = dgvPedido.Rows[i].Cells["cnCodigo"].Value.ToString();

                        //GET CATEGORY OF THE PRESENTATION
                        string category = fn.selectValue("select c.Categoria from Presentacion p,Categoria c,Producto pr,SubCategoria s where p.IDProducto = pr.IDProducto and pr.IDSubcategoria = s.IDSubCategoria and c.IDCategoria = s.IDCategoria and p.IDPresentacion = '" + idPresentation + "'");

                        if (category == "BAR")
                        {
                            existsBar = true;
                        }
                        else if (category == "HORNO")
                        {
                            existsHorno = true;
                        }
                        else
                        {
                            existsCocina = true;
                        }

                        //EXISTS TWO
                        if (existsBar == true && existsCocina == true)
                        {
                            break;
                        }
                        else if (existsBar == true && existsHorno == true)
                        {
                            break;
                        }
                        else if (existsCocina == true && existsHorno == true)
                        {
                            break;
                        }
                        else if (existsCocina == true && existsCocina == true == existsHorno == true)
                        {
                            break;
                        }
                    }

                    if (existsBar == true)
                    {
                        ppDialog.Document = pdBar;
                        ppDialog.ShowDialog();

                    }

                    if (existsCocina == true)
                    {
                        ppDialog.Document = pdCocina;
                        ppDialog.ShowDialog();
                    }
                    if (existsHorno == true)
                    {
                        ppDialog.Document = pdHorno;
                        ppDialog.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Print Cocina: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            try
            {
                if (chbxComandaDelivery.Checked == true && lblTipoVenta.Text == "VD")
                {
                    ppDialog.Document = pdComandaDelivery;
                    ppDialog.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Comanda: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void pdBar_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool llevar = false;
            if(lblMesa.Text == "LLEVAR A" || lblMesa.Text == "LLEVAR B")
            {
                llevar = true;
            }

            im.comanda("BAR", e, lblMesa.Text, lblMozo.Text,lblComanda.Text,dgvPedido,true,llevar);
        }

        private void pdCocina_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool llevar = false;
            if (lblMesa.Text == "LLEVAR A" || lblMesa.Text == "LLEVAR B")
            {
                llevar = true;
            }

            im.comanda("COCINA", e, lblMesa.Text, lblMozo.Text, lblComanda.Text, dgvPedido, true, llevar);
        }

        private void txtNumero_Click(object sender, EventArgs e)
        {

        }

        private void pdPreCuenta_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            im.comandaDelivery(false,txtReferencia.Text,lblTelefono.Text,lblTipoComprobante.Text,"DNI",e,lblFecha.Text,lblHora.Text,txtSerie.Text,txtNumero.Text,txtDireccion.Text,txtCliente.Text,txtNroCliente.Text,cboTipoPago.Text,cboTipoImpresion.Text,dgvPedido,lblTotal.Text,lblMesa.Text,lblMozo.Text,lblComanda.Text);
        }

        private void pdHorno_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool llevar = false;
            if (lblMesa.Text == "LLEVAR A" || lblMesa.Text == "LLEVAR B")
            {
                llevar = true;
            }

            im.comanda("HORNO", e, lblMesa.Text, lblMozo.Text, lblComanda.Text, dgvPedido, true, llevar);
        }
    }
}
