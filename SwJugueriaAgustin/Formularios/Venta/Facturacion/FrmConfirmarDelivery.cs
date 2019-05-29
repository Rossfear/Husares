using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Operaciones
{
    public partial class FrmConfirmarDelivery : Form
    {
        Funciones fn = new Funciones();
        public string IDVenta;
        public FrmConfirmarDelivery()
        {
            InitializeComponent();
        }

        private void FrmConfirmarDelivery_Load(object sender, EventArgs e)
        {
            SqlDataReader lector = fn.selectMultiValues("select m.Mesa,v.NombreCliente,v.TipoImpresion,v.Fecha,tc.NombreComprobante,v.Serie,v.Numero,cl.Numero,cl.Nombre,cl.Telefono,cl.Direccion,cl.Referencia,tp.TipoPago,v.SubTotal,v.Igv,v.Total from Venta v   inner join CAJA c on v.IDCaja = c.ID inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante  inner join Cliente cl on v.IDCliente = cl.IDCliente  inner join TipoPago tp on v.IDTipoPago = tp.IDTipoPago inner join Mesa m on v.IDMesa = m.IDMesa where v.IDVenta = '"+IDVenta+"'");
            lector.Read();
            lblMesa.Text = lector["Mesa"].ToString();
            lblTipoImpresion.Text = lector["TipoImpresion"].ToString();
            txtFecha.Text = lector["Fecha"].ToString();
            cboComprobante.Text = lector["NombreComprobante"].ToString();
            txtSerie.Text = lector["Serie"].ToString();
            txtNumero.Text = lector["Numero"].ToString();
            txtNroIdentidad.Text = lector["Numero"].ToString();
            txtCliente.Text = lector["NombreCliente"].ToString();
            txtTelefono.Text = lector["Telefono"].ToString();
            txtDireccion.Text = lector["Direccion"].ToString();
            txtReferencia.Text = lector["Referencia"].ToString();
            cboTipoPago.Text = lector["TipoPago"].ToString();
            lblSubTotal.Text = lector["SubTotal"].ToString();
            lblIgv.Text = lector["Igv"].ToString();
            lblTotal.Text = lector["Total"].ToString();
            lector.Close();

            fn.ActualizarGrid(dgvPedido, "select p.IDPresentacion as cnCodigo,pr.Producto +' '+ p.Presentacion as cnPlato,vd.Cantidad AS cnCantidad,vd.Precio AS cnPrecio ,CAST((vd.Cantidad * vd.Precio) as decimal(18,2)) as cnImporte from VentaDetalle vd  inner join Presentacion p on vd.IDPresentacion = p.IDPresentacion inner join Producto pr on p.IDProducto = pr.IDProducto where vd.IDVenta = '" + IDVenta + "'");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //SE PAGA LA VENTA - ATENDEMOS DELIVERY
            fn.Modificar("Venta", "Pagado='True',ESTADO='CONFIRMADO'", "IDVenta = '" + IDVenta + "'");
            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnNoPago_Click(object sender, EventArgs e)
        {
            if (validacionNoPago() == false)
            {
                return;
            }
            
            

            //SE PAGA LA VENTA - ATENDEMOS DELIVERY
            fn.Modificar("Venta", "Pagado='False',ESTADO='CONFIRMADO',MotivoNoPago='" + txtMotivoNoPago.Text + "'", "IDVenta = '" + IDVenta + "'");
            MessageBox.Show("Operación Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private bool validacionNoPago()
        {
            if (string.IsNullOrEmpty(txtMotivoNoPago.Text) == true)
            {
                MessageBox.Show("Ingrese Motivo de Anulacion", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DialogResult msj = MessageBox.Show("Desea Registrar Venta como no pagada", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (msj == DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            print();
        }

        private void print()
        {
            try
            {
                //IMPRIMIR COMPROBANTES
                if (cboComprobante.Text == "FACTURA")
                {
                    pdFacturaTDelivery.PrinterSettings.PrinterName = Datos.impresoraComprobante;
                    pdFacturaTDelivery.Print();
                }
                else if (cboComprobante.Text == "BOLETA")
                {
                    pdBoletaDelivery.PrinterSettings.PrinterName = Datos.impresoraComprobante;
                    pdBoletaDelivery.Print();
                }
                else
                {
                  
                        
                        pdTicketDelivery.Print();

                        
                        pdTicketDelivery.Print();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Comprobante: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            //IMPRIMIRMOS COMESTIBLE - BEBILBLE
            if(true == true)
            {
                try
                {
                    bool existsBar = false, existsCocina = false;

                    for (int i = 0; i < dgvPedido.Rows.Count; i++)
                    {
                        
                            string idPresentation = dgvPedido.Rows[i].Cells["cnCodigo"].Value.ToString();

                            //GET CATEGORY OF THE PRESENTATION
                            string category = fn.selectValue("select c.Categoria from Presentacion p,Categoria c,Producto pr,SubCategoria s where p.IDProducto = pr.IDProducto and pr.IDSubcategoria = s.IDSubCategoria and c.IDCategoria = s.IDCategoria and p.IDPresentacion = '" + idPresentation + "'");

                            if (category == "BAR")
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
                        
                            
                            pdBar.Print();
                        
                    }

                    if (existsCocina == true)
                    {
                        
                        pdCocina.Print();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Impresion Platos: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            //IMPRIMIR COMANDA
            if(Datos.conPrecuenta == true)
            {
                pdComanda.Print();
            }
            
        }

        private void pdFacturaTDelivery_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion



            e.Graphics.DrawString(Datos.nombreComercial, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(15, 12));
            e.Graphics.DrawString(Datos.RazonSocial, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(110, 27));
            e.Graphics.DrawString("RUC: " + Datos.Ruc, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 40));
            e.Graphics.DrawString(Datos.Direccion, new Font("Courier New Condensada", 6, FontStyle.Regular), Brushes.Black, new Point(20, 52));
            e.Graphics.DrawString(Datos.Departmaneto, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(0, 64));
            e.Graphics.DrawString("TICKET FACTURA", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(90, 80));

            //nÚMERO COMPROBANTE
            e.Graphics.DrawString(txtSerie.Text + " - " + txtNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(110, 94));



            //DAtos PErsona
            e.Graphics.DrawString("RAZ: " + txtCliente.Text, new Font("Courier New Condensada", 6, FontStyle.Regular), Brushes.Black, new Point(10, 112));
            e.Graphics.DrawString("RUC: " + txtNroIdentidad.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 122));
            e.Graphics.DrawString("DIRECCION: " + txtDireccion.Text, new Font("Courier New Condensada", 6, FontStyle.Regular), Brushes.Black, new Point(10, 135));
            e.Graphics.DrawString("T. Pago: " + cboTipoPago.Text + " - F:" + DateTime.Now.ToShortDateString() + " / H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 148));


            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 175));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 175));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 175), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 175), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 186));

            int SUMATORIA = 0;
            //DETALLADO
            if (lblTipoImpresion.Text == "D")
            {
                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    decimal untario, costo;
                    decimal can_2;
                    int cantidad;
                    string descri;

                    descri = fn.selectValue("select p.Producto +' '+ pr.Presentacion as Presentacion from Presentacion pr INNER JOIN producto p on pr.IDProducto = p.IDProducto where IDPresentacion ='" + row.Cells["cnCodigo"].Value.ToString() + "'");

                    can_2 = Convert.ToDecimal(row.Cells["cnCantidad"].Value);
                    untario = Convert.ToDecimal(row.Cells["cnPrecio"].Value);
                    costo = Convert.ToDecimal(row.Cells["cnImporte"].Value);


                    can_2 = Math.Round(can_2, 0);
                    untario = Math.Round(untario, 2);
                    costo = Math.Round(costo, 2);
                    cantidad = Convert.ToInt16(can_2);



                    e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 189 + SUMATORIA + 5));
                    e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 189 + SUMATORIA + 5));

                    e.Graphics.DrawString("" + untario.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 202 + SUMATORIA + 8), alineacion);
                    e.Graphics.DrawString("" + costo.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 202 + SUMATORIA + 8), alineacion);
                    e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 215 + SUMATORIA));
                    SUMATORIA = SUMATORIA + 30;
                }
            }
            else
            {
                e.Graphics.DrawString("1", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 189 + SUMATORIA + 5));
                e.Graphics.DrawString("POR CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 189 + SUMATORIA + 5));
                e.Graphics.DrawString(Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 202 + SUMATORIA + 8), alineacion);
                e.Graphics.DrawString(Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 202 + SUMATORIA + 8), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 215 + SUMATORIA));
                SUMATORIA = SUMATORIA + 30;
            }


            string letras;
            double sub_total2 = 0, igv2 = 0, total2 = 0;

            sub_total2 = Convert.ToDouble(lblTotal.Text) / 1.18;

            igv2 = sub_total2 * 0.18;

            total2 = Convert.ToDouble(lblTotal.Text);
            Clases.Conversion CONVERSION = new Conversion();
            letras = CONVERSION.enletras(lblTotal.Text.ToString());


            e.Graphics.DrawString("SUBTOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 230 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + sub_total2.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 230 + SUMATORIA - 25), alineacion);


            e.Graphics.DrawString("IGV:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 243 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + igv2.ToString("#,#.00").ToString(), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 243 + SUMATORIA - 25), alineacion);


            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 256 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + total2.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 256 + SUMATORIA - 25), alineacion);

            string letras_ofi, mon, moneda = "Soles";
            if (moneda == "Soles")
            { mon = "SOLES"; }
            else
            { mon = "DOLARES"; }

            letras_ofi = "SON: " + letras + " " + mon;

            string letras1 = "", letras2 = "";
            int indice_letras = -1, indiceletras2 = 46;

            while (indice_letras <= 45)
            {
                indice_letras += 1;

                if (indice_letras < letras_ofi.Length)
                {
                    letras1 += letras_ofi[indice_letras];
                }
            }
            while (indiceletras2 < letras_ofi.Length - 1)
            {
                indiceletras2 += 1;
                letras2 += letras_ofi[indiceletras2];
            }

            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 269 + SUMATORIA - 25));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 279 + SUMATORIA - 25));


            string l1, l2;

            l1 = "Número de Autorización:	" + Datos.nroAutorizacion + "";
            l2 = "Serie de Impresora: " + Datos.serieImpresora + "";


            e.Graphics.DrawString("" + l1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 272 + SUMATORIA));
            e.Graphics.DrawString("" + l2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 285 + SUMATORIA));
            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 300 + SUMATORIA));
        }

        private void pdBar_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion


            //DATOS PRINCEIPALES
            e.Graphics.DrawString("BAR", new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(70, 0));
            e.Graphics.DrawString("MESA: " + lblMesa.Text, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(10, 40));
            e.Graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString() + " - Hora: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 53));


            //ENCABEZADO
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 105 - 13));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(50, 105 - 13));
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 118 - 13));

            //  SE AGREGA LOS PRODUCTOS
            int SUMATORIA = 0;
            foreach (DataGridViewRow row in dgvPedido.Rows)
            {
                string idPresentacion = Convert.ToString(row.Cells["cnCodigo"].Value);
                decimal untario, costo;
                decimal can_2;
                int cantidad;
                string descri;
          



                descri = Convert.ToString(row.Cells["cnPlato"].Value);

                string productoP1 = "", productoP2 = "", productoP3 = "", productoP4 = "";
                int indece_pro1 = -1, indice_pro2 = 23, indece_pro3 = 46, indece_pro4 = 69;


                //LINEA 1
                while (indece_pro1 <= 22)
                {
                    indece_pro1 += 1;

                    if (indece_pro1 < descri.Length)
                    {
                        productoP1 += descri[indece_pro1];
                    }
                }
                //LINEA 2
                while (indice_pro2 <= 45)
                {
                    indice_pro2 += 1;
                    if (descri.Length > indice_pro2)
                    {
                        productoP2 += descri[indice_pro2];
                    }

                }
                //LINEA3
                while (indece_pro3 <= 68)
                {
                    indece_pro3 += 1;
                    if (descri.Length > indece_pro3)
                    {
                        productoP3 += descri[indece_pro3];
                    }

                }
                //LINEA 4
                while (indece_pro4 <= 91)
                {
                    indece_pro4 += 1;

                    if (descri.Length > indece_pro4)
                    {
                        productoP4 += descri[indece_pro4];
                    }
                }
                
                can_2 = Convert.ToDecimal(row.Cells["cnCantidad"].Value);
                untario = Convert.ToDecimal(row.Cells["cnPrecio"].Value);
                costo = Convert.ToDecimal(row.Cells["cnImporte"].Value);


                can_2 = Math.Round(can_2, 0);
                untario = Math.Round(untario, 2);
                costo = Math.Round(costo, 2);
                cantidad = Convert.ToInt16(can_2);

                //SOLO AGREGA LOS COMESTIBLES
                if (fn.select_one_value("c.Categoria", "Presentacion p,Categoria c,Producto pr,SubCategoria s", "p.IDProducto = pr.IDProducto and pr.IDSubcategoria = s.IDSubCategoria and c.IDCategoria = s.IDCategoria and p.IDPresentacion = '" + idPresentacion + "'", 0) == "BAR")
                {
                    e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(10, 131 - 13 + SUMATORIA));
                    e.Graphics.DrawString("" + productoP1, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    if (productoP2 != "")
                    {
                        SUMATORIA = SUMATORIA + 13;
                        e.Graphics.DrawString("" + productoP2, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    }
                    if (productoP3 != "")
                    {
                        SUMATORIA = SUMATORIA + 13;
                        e.Graphics.DrawString("" + productoP3, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    }
                    if (productoP4 != "")
                    {
                        SUMATORIA = SUMATORIA + 13;
                        e.Graphics.DrawString("" + productoP4, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    }
                    e.Graphics.DrawString("-----------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 144 - 13 + SUMATORIA));
                    SUMATORIA = SUMATORIA + 25;
                }
            }


            e.Graphics.DrawString("*************************************************", new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(0, 170 - 13 + SUMATORIA));
        }

        private void pdTicketDelivery_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion



            e.Graphics.DrawString(Datos.nombreComercial, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(15, 12));
            e.Graphics.DrawString(Datos.RazonSocial, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(110, 27));
            e.Graphics.DrawString("RUC: " + Datos.Ruc, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 40));
            e.Graphics.DrawString(Datos.Direccion, new Font("Courier New Condensada", 6, FontStyle.Regular), Brushes.Black, new Point(20, 52));
            e.Graphics.DrawString(Datos.Departmaneto, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(0, 64));
            e.Graphics.DrawString("--TICKET--", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(90, 80));

            //nÚMERO COMPROBANTE
            e.Graphics.DrawString(txtSerie.Text + " - " + txtNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(110, 94));


            //DAtos PErsona
            e.Graphics.DrawString("SR(A): " + txtCliente.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 123));
            e.Graphics.DrawString("DNI: " + txtNroIdentidad.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 138));
            e.Graphics.DrawString("T. Pago:" + cboTipoPago.Text + "- F: " + DateTime.Now.ToShortDateString() + " / H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 153));

            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 179));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 179));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 179 + 3), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 179 + 3), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 192));


            int SUMATORIA = 0;
            //DETALLADO
            if (lblTipoImpresion.Text == "D")
            {
                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    
                        decimal untario, costo;
                        decimal can_2;
                        int cantidad;
                        string descri;
                        descri = fn.selectValue("select p.Producto +' '+ pr.Presentacion as Presentacion from Presentacion pr INNER JOIN producto p on pr.IDProducto = p.IDProducto where IDPresentacion ='" + row.Cells["cnCodigo"].Value.ToString() + "'");
                        can_2 = Convert.ToDecimal(row.Cells["cnCantidad"].Value);
                        untario = Convert.ToDecimal(row.Cells["cnPrecio"].Value);
                        costo = Convert.ToDecimal(row.Cells["cnImporte"].Value);


                        can_2 = Math.Round(can_2, 0);
                        untario = Math.Round(untario, 2);
                        costo = Math.Round(costo, 2);
                        cantidad = Convert.ToInt16(can_2);



                        e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5));
                        e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5));

                        e.Graphics.DrawString("" + untario.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 231 - 13 + SUMATORIA + 8), alineacion);
                        e.Graphics.DrawString("" + costo.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 231 - 13 + SUMATORIA + 8), alineacion);
                        e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 245 - 13 + SUMATORIA));
                        SUMATORIA = SUMATORIA + 30;
                    
                }
            }
            //POR CONSUMO
            else
            {
                e.Graphics.DrawString("1", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5));
                e.Graphics.DrawString("POR CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5));

                e.Graphics.DrawString("" + Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 231 - 13 + SUMATORIA + 8), alineacion);
                e.Graphics.DrawString("" + Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 231 - 13 + SUMATORIA + 8), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 245 - 13 + SUMATORIA));
                SUMATORIA = SUMATORIA + 30;
            }


            string letras;
            double sub_total2 = 0, igv2 = 0, total2 = 0;

            sub_total2 = Convert.ToDouble(lblTotal.Text) / 1.18;

            igv2 = sub_total2 * 0.18;

            total2 = Convert.ToDouble(lblTotal.Text);
            Conversion CONVERSION = new Conversion();
            letras = CONVERSION.enletras(lblTotal.Text.ToString());

            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 268 - 13 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 268 - 13 + SUMATORIA - 25), alineacion);

            string letras_ofi, mon, moneda = "Soles";
            if (moneda == "Soles")
            { mon = "SOLES"; }
            else
            { mon = "DOLARES"; }

            letras_ofi = "SON: " + letras + " " + mon;

            string letras1 = "", letras2 = "";
            int indice_letras = -1, indiceletras2 = 46;

            while (indice_letras <= 45)
            {
                indice_letras += 1;

                if (indice_letras < letras_ofi.Length)
                {
                    letras1 += letras_ofi[indice_letras];
                }
            }
            while (indiceletras2 < letras_ofi.Length - 1)
            {
                indiceletras2 += 1;
                letras2 += letras_ofi[indiceletras2];
            }

            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 281 - 13 + SUMATORIA - 25));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 173 - 13 + SUMATORIA - 25));

            e.Graphics.DrawString("Canjear por Comprobante", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 283 + 13 - 13 + SUMATORIA));
            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(85, 298 + 13 - 13 + SUMATORIA));
        }

        private void pdBoletaDelivery_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion



            e.Graphics.DrawString(Datos.nombreComercial, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(15, 12));
            e.Graphics.DrawString(Datos.RazonSocial, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(110, 27));
            e.Graphics.DrawString("RUC: " + Datos.Ruc, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 40));
            e.Graphics.DrawString(Datos.Direccion, new Font("Courier New Condensada", 6, FontStyle.Regular), Brushes.Black, new Point(20, 52));
            e.Graphics.DrawString(Datos.Departmaneto, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(0, 64));
            e.Graphics.DrawString("TICKET BOLETA", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(90, 80));

            //nÚMERO COMPROBANTE
            e.Graphics.DrawString(txtSerie.Text + " - " + txtNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(110, 94));



            //DAtos PErsona
            e.Graphics.DrawString("SR(A): " + txtCliente.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 127));
            e.Graphics.DrawString("DNI: " + txtNroIdentidad.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 140));
            e.Graphics.DrawString("T. Pago: " + cboTipoPago.Text + " - F:" + DateTime.Now.ToShortDateString() + " / H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 153));


            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 179));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 179));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 179), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 179), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 192));


            int SUMATORIA = 0;
            //DETALLADO
            if (lblTipoImpresion.Text == "D")
            {
                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    decimal untario, costo;
                    decimal can_2;
                    int cantidad;
                    string descri;

                    descri = fn.selectValue("select p.Producto +' '+ pr.Presentacion as Presentacion from Presentacion pr INNER JOIN producto p on pr.IDProducto = p.IDProducto where IDPresentacion ='" + row.Cells["cnCodigo"].Value.ToString() + "'");

                    can_2 = Convert.ToDecimal(row.Cells["cnCantidad"].Value);
                    untario = Convert.ToDecimal(row.Cells["cnPrecio"].Value);
                    costo = Convert.ToDecimal(row.Cells["cnImporte"].Value);


                    can_2 = Math.Round(can_2, 0);
                    untario = Math.Round(untario, 2);
                    costo = Math.Round(costo, 2);
                    cantidad = Convert.ToInt16(can_2);



                    e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5));
                    e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 205 + SUMATORIA + 5));

                    e.Graphics.DrawString("" + untario.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 218 + SUMATORIA + 8), alineacion);
                    e.Graphics.DrawString("" + costo.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 218 + SUMATORIA + 8), alineacion);
                    e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 232 + SUMATORIA));
                    SUMATORIA = SUMATORIA + 30;
                }
            }
            else
            {
                e.Graphics.DrawString("1", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 205 + SUMATORIA + 5));
                e.Graphics.DrawString("POR CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 205 + SUMATORIA + 5));

                e.Graphics.DrawString(Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 218 + SUMATORIA + 8), alineacion);
                e.Graphics.DrawString(Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 218 + SUMATORIA + 8), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 232 + SUMATORIA));
                SUMATORIA = SUMATORIA + 30;
            }


            string letras;
            double sub_total2 = 0, igv2 = 0, total2 = 0;

            sub_total2 = Convert.ToDouble(lblTotal.Text) / 1.18;

            igv2 = sub_total2 * 0.18;

            total2 = Convert.ToDouble(lblTotal.Text);
            Conversion CONVERSION = new Conversion();
            letras = CONVERSION.enletras(lblTotal.Text.ToString());


            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 245 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 245 + SUMATORIA - 25), alineacion);

            string letras_ofi, mon, moneda = "Soles";
            if (moneda == "Soles")
            { mon = "SOLES"; }
            else
            { mon = "DOLARES"; }

            letras_ofi = "SON: " + letras + " " + mon;

            string letras1 = "", letras2 = "";
            int indice_letras = -1, indiceletras2 = 46;

            while (indice_letras <= 45)
            {
                indice_letras += 1;

                if (indice_letras < letras_ofi.Length)
                {
                    letras1 += letras_ofi[indice_letras];
                }
            }
            while (indiceletras2 < letras_ofi.Length - 1)
            {
                indiceletras2 += 1;
                letras2 += letras_ofi[indiceletras2];
            }

            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 258 + SUMATORIA - 25));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 268 + SUMATORIA - 25));


            string l1, l2;

            l1 = "Número de Autorización:	" + Datos.nroAutorizacion + "";
            l2 = "Serie de Impresora: " + Datos.serieImpresora + "";


            e.Graphics.DrawString("" + l1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 254 + SUMATORIA));
            e.Graphics.DrawString("" + l2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 269 + SUMATORIA));


            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 290 + SUMATORIA));
        }

        private void pdCocina_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion


            //DATOS PRINCEIPALES
            e.Graphics.DrawString("COCINA", new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(70, 0));
            e.Graphics.DrawString("MESA: " + lblMesa.Text, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(10, 40));
            e.Graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString() + " - Hora: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 53));



            //ENCABEZADO

            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 105 - 13));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(50, 105 - 13));
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 118 - 13));

            //  SE AGREGA LOS PRODUCTOS
            int SUMATORIA = 0;
            foreach (DataGridViewRow row in dgvPedido.Rows)
            {
                string idPresentacion = Convert.ToString(row.Cells["cnCodigo"].Value);
                decimal untario, costo;
                decimal can_2;
                int cantidad;
                string descri, und_medida, cod;
                cod = "";



                descri = Convert.ToString(row.Cells["cnPlato"].Value);

                string productoP1 = "", productoP2 = "", productoP3 = "", productoP4 = "";
                int indece_pro1 = -1, indice_pro2 = 23, indece_pro3 = 46, indece_pro4 = 69;


                //LINEA 1
                while (indece_pro1 <= 22)
                {
                    indece_pro1 += 1;

                    if (indece_pro1 < descri.Length)
                    {
                        productoP1 += descri[indece_pro1];
                    }
                }
                //LINEA 2
                while (indice_pro2 <= 45)
                {
                    indice_pro2 += 1;
                    if (descri.Length > indice_pro2)
                    {
                        productoP2 += descri[indice_pro2];
                    }

                }
                //LINEA3
                while (indece_pro3 <= 68)
                {
                    indece_pro3 += 1;
                    if (descri.Length > indece_pro3)
                    {
                        productoP3 += descri[indece_pro3];
                    }

                }
                //LINEA 4
                while (indece_pro4 <= 91)
                {
                    indece_pro4 += 1;

                    if (descri.Length > indece_pro4)
                    {
                        productoP4 += descri[indece_pro4];
                    }
                }
                und_medida = "UND";
                can_2 = Convert.ToDecimal(row.Cells["cnCantidad"].Value);
                untario = Convert.ToDecimal(row.Cells["cnPrecio"].Value);
                costo = Convert.ToDecimal(row.Cells["cnImporte"].Value);


                can_2 = Math.Round(can_2, 0);
                untario = Math.Round(untario, 2);
                costo = Math.Round(costo, 2);
                cantidad = Convert.ToInt16(can_2);

                //SOLO AGREGA LOS COMESTIBLES
                if (fn.select_one_value("c.Categoria", "Presentacion p,Categoria c,Producto pr,SubCategoria s", "p.IDProducto = pr.IDProducto and pr.IDSubcategoria = s.IDSubCategoria and c.IDCategoria = s.IDCategoria and p.IDPresentacion = '" + idPresentacion + "'", 0) == "COCINA")
                {
                    e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(10, 131 - 13 + SUMATORIA));
                    e.Graphics.DrawString("" + productoP1, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    if (productoP2 != "")
                    {
                        SUMATORIA = SUMATORIA + 13;
                        e.Graphics.DrawString("" + productoP2, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    }
                    if (productoP3 != "")
                    {
                        SUMATORIA = SUMATORIA + 13;
                        e.Graphics.DrawString("" + productoP3, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    }
                    if (productoP4 != "")
                    {
                        SUMATORIA = SUMATORIA + 13;
                        e.Graphics.DrawString("" + productoP4, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    }
                    e.Graphics.DrawString("-----------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 144 - 13 + SUMATORIA));
                    SUMATORIA = SUMATORIA + 25;
                }
            }
            e.Graphics.DrawString("*************************************************", new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(0, 170 - 13 + SUMATORIA));

        }

        private void pdPreCuenta_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion



            
            e.Graphics.DrawString("COMANDA DELIVERY", new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(50, 19));

            e.Graphics.DrawString(cboComprobante.Text+": " + txtSerie.Text + " - " + txtNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(5, 49));

            
            


            //DAtos PErsona
            e.Graphics.DrawString("SR(A): " + txtCliente.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 75));
            e.Graphics.DrawString("DNI: " + txtNroIdentidad.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 88));
            e.Graphics.DrawString("TELEFONO: " + txtTelefono.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 101));


            //VERIFICAMOS EL TAMAÑO DE DIRECCION
            string direccion1 = "", direccion2 = "", direccion3 = "", direccion4 = "";

            int maximoCaracteres = 35;
            int filas = txtDireccion.TextLength / maximoCaracteres;

            //FILA **1** DE DIRECCION
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (txtDireccion.TextLength > i)
                {
                    direccion1 += txtDireccion.Text[i];
                }
                else
                {
                    break;
                }
            }

            //FILA **2** DIRECCION
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (txtDireccion.TextLength > i + maximoCaracteres)
                {
                    direccion2 += txtDireccion.Text[i + maximoCaracteres];
                }
                else
                {
                    break;
                }
            }

            //FILA **3** DIRECCION
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (txtDireccion.TextLength > i + (maximoCaracteres * 2))
                {
                    direccion3 += txtDireccion.Text[i + (maximoCaracteres * 2)];
                }
                else
                {
                    break;
                }
            }

            //FILA **4** DIRECCION
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (txtDireccion.TextLength > i + (maximoCaracteres * 2))
                {
                    direccion4 += txtDireccion.Text[i + (maximoCaracteres * 2)];
                }
                else
                {
                    break;
                }
            }



            e.Graphics.DrawString("DIRECCIÓN:", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 127));

            int plusDireccion = 13;
            if (direccion1 != "")
            {
                e.Graphics.DrawString(direccion1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 127 + plusDireccion));
                plusDireccion += 13;
            }

            if (direccion2 != "")
            {
                e.Graphics.DrawString(direccion2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 127 + plusDireccion));
                plusDireccion += 13;
            }

            if (direccion3 != "")
            {
                e.Graphics.DrawString(direccion3, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 127 + plusDireccion));
                plusDireccion += 13;
            }

            if (direccion4 != "")
            {
                e.Graphics.DrawString(direccion4, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 127 + plusDireccion));
            }



            //VERIFICAMOS EL TAMAÑO DE ***REFERENCIA***
            string referencia1 = "", referencia2 = "", referencia3 = "", referencia4 = "";


            //FILA **1** DE REFERENCIA
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (txtReferencia.TextLength > i)
                {
                    referencia1 += txtReferencia.Text[i];
                }
                else
                {
                    break;
                }
            }

            //FILA **2** REFERENCIA
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (txtReferencia.TextLength > i + maximoCaracteres)
                {
                    referencia2 += txtReferencia.Text[i + maximoCaracteres];
                }
                else
                {
                    break;
                }
            }

            //FILA **3** REFERENCIA
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (txtReferencia.TextLength > i + (maximoCaracteres * 2))
                {
                    referencia3 += txtReferencia.Text[i + (maximoCaracteres * 2)];
                }
                else
                {
                    break;
                }
            }

            //FILA **4** REFERENCIA
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (txtReferencia.TextLength > i + (maximoCaracteres * 2))
                {
                    referencia4 += txtReferencia.Text[i + (maximoCaracteres * 2)];
                }
                else
                {
                    break;
                }
            }


            int plusReferencia = 0;


            e.Graphics.DrawString("REFERENCIA:", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(5, 140 + plusDireccion + plusReferencia));

            if (referencia1 != "")
            {
                e.Graphics.DrawString(referencia1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 140 + 13 + plusDireccion + plusReferencia));
                plusReferencia += 13;
            }


            if (referencia2 != "")
            {
                e.Graphics.DrawString(referencia2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 140 + 13 + plusDireccion + plusReferencia));
                plusReferencia += 13;
            }

            if (referencia3 != "")
            {
                e.Graphics.DrawString(referencia3, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 13 + 140 + plusDireccion + plusReferencia));
                plusReferencia += 13;
            }

            if (referencia4 != "")
            {
                e.Graphics.DrawString(referencia4, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 140 + 13 + plusDireccion + plusReferencia));

            }




            e.Graphics.DrawString("T. Pago:" + cboTipoPago.Text + "- F: " + DateTime.Now.ToShortDateString() + " / H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 13 + 153 + plusDireccion + plusReferencia));



            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 179 + 13 + plusDireccion + plusReferencia));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 179 + 13 + plusDireccion + plusReferencia));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 179 + 13 + 3 + plusDireccion + plusReferencia), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 179 + 13 + 3 + plusDireccion + plusReferencia), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 192 + 13 + plusDireccion + plusReferencia));


            int SUMATORIA = 0;
            if (lblTipoImpresion.Text == "D")
            {
                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    decimal untario, costo;
                    decimal can_2;
                    int cantidad;
                    string descri;

                    descri = fn.selectValue("select p.Producto +' '+ pr.Presentacion as Presentacion from Presentacion pr INNER JOIN producto p on pr.IDProducto = p.IDProducto where IDPresentacion ='" + row.Cells["cnCodigo"].Value.ToString() + "'");

                    can_2 = Convert.ToDecimal(row.Cells["cnCantidad"].Value);
                    untario = Convert.ToDecimal(row.Cells["cnPrecio"].Value);
                    costo = Convert.ToDecimal(row.Cells["cnImporte"].Value);


                    can_2 = Math.Round(can_2, 0);
                    untario = Math.Round(untario, 2);
                    costo = Math.Round(costo, 2);
                    cantidad = Convert.ToInt16(can_2);



                    e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5 + 13 + plusDireccion + plusReferencia));
                    e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5 + 13 + plusDireccion + plusReferencia));

                    e.Graphics.DrawString("" + untario.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 231 + 13 - 13 + SUMATORIA + 8 + plusDireccion + plusReferencia), alineacion);
                    e.Graphics.DrawString("" + costo.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 231 + 13 - 13 + SUMATORIA + 8 + plusDireccion + plusReferencia), alineacion);
                    e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 245 + 13 - 13 + SUMATORIA + plusDireccion + plusReferencia));
                    SUMATORIA = SUMATORIA + 30;
                }
            }
            else
            {
                e.Graphics.DrawString("1", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5 + 13 + plusDireccion + plusReferencia));
                e.Graphics.DrawString("POR CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5 + 13 + plusDireccion + plusReferencia));

                e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 231 + 13 - 13 + SUMATORIA + 8 + plusDireccion + plusReferencia), alineacion);
                e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 231 + 13 - 13 + SUMATORIA + 8 + plusDireccion + plusReferencia), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 245 + 13 - 13 + SUMATORIA + plusDireccion + plusReferencia));
                SUMATORIA = SUMATORIA + 30;
            }


            string letras;
            double sub_total2 = 0,  igv2 = 0, total2 = 0;

            sub_total2 = Convert.ToDouble(lblTotal.Text) / 1.18;
            igv2 = sub_total2 * 0.18;
            
            total2 = Convert.ToDouble(lblTotal.Text);
            Clases.Conversion CONVERSION = new Conversion();
            
            letras = CONVERSION.enletras(lblTotal.Text);




            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 268 - 13 + SUMATORIA - 25 + 13 + plusDireccion + plusReferencia));//276
            e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 268 - 13 + SUMATORIA - 25 + 13 + plusDireccion + plusReferencia), alineacion);

           

            string letras_ofi, mon, moneda = "Soles";
            if (moneda == "Soles")
            { mon = "SOLES"; }
            else
            { mon = "DOLARES"; }

            letras_ofi = "SON: " + letras + " " + mon;

            string letras1 = "", letras2 = "";
            int indice_letras = -1, indiceletras2 = 46;

            while (indice_letras <= 45)
            {
                indice_letras += 1;

                if (indice_letras < letras_ofi.Length)
                {
                    letras1 += letras_ofi[indice_letras];
                }
            }
            while (indiceletras2 < letras_ofi.Length - 1)
            {
                indiceletras2 += 1;
                letras2 += letras_ofi[indiceletras2];
            }

            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 281 + SUMATORIA - 25 + 26 + plusDireccion + plusReferencia));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 173 + SUMATORIA - 25 + 26 + plusDireccion + plusReferencia));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //IMPRIMIR COMPROBANTES
                if (cboComprobante.Text == "FACTURA")
                {
                    ppDialog.Document = pdFacturaTDelivery;
                    ppDialog.ShowDialog();
                }
                else if (cboComprobante.Text == "BOLETA")
                {
                    ppDialog.Document = pdBoletaDelivery;
                    ppDialog.ShowDialog();
                }
                else
                {
                    ppDialog.Document = pdTicketDelivery;
                    ppDialog.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Comprobante: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



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
                        if (existsBar == true && existsCocina == true && existsHorno == true)
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
                MessageBox.Show("Impresion Platos: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                ppDialog.Document = pdComanda;
                ppDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresora Comanda Delivery: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pdHorno_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion


            //DATOS PRINCEIPALES
            e.Graphics.DrawString("HORNO", new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(70, 0));
            e.Graphics.DrawString("MESA: " + lblMesa.Text, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(10, 40));
            e.Graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString() + " - Hora: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 53));



            //ENCABEZADO

            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 105 - 13));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(50, 105 - 13));
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 118 - 13));

            //  SE AGREGA LOS PRODUCTOS
            int SUMATORIA = 0;
            foreach (DataGridViewRow row in dgvPedido.Rows)
            {
                string idPresentacion = Convert.ToString(row.Cells["cnCodigo"].Value);
                decimal untario, costo;
                decimal can_2;
                int cantidad;
                string descri, und_medida, cod;
                cod = "";



                descri = Convert.ToString(row.Cells["cnPlato"].Value);

                string productoP1 = "", productoP2 = "", productoP3 = "", productoP4 = "";
                int indece_pro1 = -1, indice_pro2 = 23, indece_pro3 = 46, indece_pro4 = 69;


                //LINEA 1
                while (indece_pro1 <= 22)
                {
                    indece_pro1 += 1;

                    if (indece_pro1 < descri.Length)
                    {
                        productoP1 += descri[indece_pro1];
                    }
                }
                //LINEA 2
                while (indice_pro2 <= 45)
                {
                    indice_pro2 += 1;
                    if (descri.Length > indice_pro2)
                    {
                        productoP2 += descri[indice_pro2];
                    }

                }
                //LINEA3
                while (indece_pro3 <= 68)
                {
                    indece_pro3 += 1;
                    if (descri.Length > indece_pro3)
                    {
                        productoP3 += descri[indece_pro3];
                    }

                }
                //LINEA 4
                while (indece_pro4 <= 91)
                {
                    indece_pro4 += 1;

                    if (descri.Length > indece_pro4)
                    {
                        productoP4 += descri[indece_pro4];
                    }
                }
                und_medida = "UND";
                can_2 = Convert.ToDecimal(row.Cells["cnCantidad"].Value);
                untario = Convert.ToDecimal(row.Cells["cnPrecio"].Value);
                costo = Convert.ToDecimal(row.Cells["cnImporte"].Value);


                can_2 = Math.Round(can_2, 0);
                untario = Math.Round(untario, 2);
                costo = Math.Round(costo, 2);
                cantidad = Convert.ToInt16(can_2);

                //SOLO AGREGA LOS COMESTIBLES
                if (fn.select_one_value("c.Categoria", "Presentacion p,Categoria c,Producto pr,SubCategoria s", "p.IDProducto = pr.IDProducto and pr.IDSubcategoria = s.IDSubCategoria and c.IDCategoria = s.IDCategoria and p.IDPresentacion = '" + idPresentacion + "'", 0) == "HORNO")
                {
                    e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(10, 131 - 13 + SUMATORIA));
                    e.Graphics.DrawString("" + productoP1, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    if (productoP2 != "")
                    {
                        SUMATORIA = SUMATORIA + 13;
                        e.Graphics.DrawString("" + productoP2, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    }
                    if (productoP3 != "")
                    {
                        SUMATORIA = SUMATORIA + 13;
                        e.Graphics.DrawString("" + productoP3, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    }
                    if (productoP4 != "")
                    {
                        SUMATORIA = SUMATORIA + 13;
                        e.Graphics.DrawString("" + productoP4, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(46, 131 - 13 + SUMATORIA));
                    }
                    e.Graphics.DrawString("-----------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 144 - 13 + SUMATORIA));
                    SUMATORIA = SUMATORIA + 25;
                }
            }
            e.Graphics.DrawString("*************************************************", new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(0, 170 - 13 + SUMATORIA));

        }
    }
}
