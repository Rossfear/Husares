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

namespace SwJugueriaAgustin.Formularios.Venta.Facturar
{
    public partial class FrmAtenderDelivery : Form
    {
        Funciones fn = new Funciones();
        Impresion im = new Impresion();
        public string idVenta;
        public FrmAtenderDelivery()
        {
            InitializeComponent();
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
            if (cboTipoImpresion.Text == "D")
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


            e.Graphics.DrawString("Descuento:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 230 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + txtDescuentoSoles.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 230 + SUMATORIA - 25), alineacion);

            e.Graphics.DrawString("SubTotal:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 243 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + lblSubTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 243 + SUMATORIA - 25), alineacion);


            e.Graphics.DrawString("Igv:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 256 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + lblIgv.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 256 + SUMATORIA - 25), alineacion);


            e.Graphics.DrawString("Total:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 269 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 269 + SUMATORIA - 25), alineacion);

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

            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 282 + SUMATORIA - 25));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 292 + SUMATORIA - 25));


            string l1, l2;

            l1 = "Número de Autorización:	" + Datos.nroAutorizacion + "";
            l2 = "Serie de Impresora: " + Datos.serieImpresora + "";


            e.Graphics.DrawString("" + l1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 305 + SUMATORIA));
            e.Graphics.DrawString("" + l2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 318 + SUMATORIA));




            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 331 + SUMATORIA));





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
            if (cboTipoImpresion.Text == "D")
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


            e.Graphics.DrawString("Descuento:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 245 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + Convert.ToDecimal(txtDescuentoSoles.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 245 + SUMATORIA - 25), alineacion);

            e.Graphics.DrawString("Total:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 258 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + Convert.ToDecimal(lblTotal.Text).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 258 + SUMATORIA - 25), alineacion);

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

            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 271 + SUMATORIA - 25));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 271 + SUMATORIA - 25));


            string l1, l2;

            l1 = "Número de Autorización:	" + Datos.nroAutorizacion + "";
            l2 = "Serie de Impresora: " + Datos.serieImpresora + "";


            e.Graphics.DrawString("" + l1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 271 + SUMATORIA));
            e.Graphics.DrawString("" + l2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 284 + SUMATORIA));


            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 297 + SUMATORIA));
        }

        private void pdTicketDelivery_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            im.Comprobante("PRECUENTA CONTROL","DNI",e,DateTime.Now.ToShortDateString(),DateTime.Now.ToShortTimeString(),txtSerie.Text,txtNumero.Text,txtDireccion.Text,txtCliente.Text,txtNroIdentidad.Text,cboTipoPago.Text,cboTipoImpresion.Text,dgvPedido,lblTotal.Text,txtDescuentoSoles.Text,lblSubTotal.Text,lblIgv.Text,"DELIVERY  - REP: "+cbxRepartidor.Text,"--",txtSerie.Text+"-"+txtNumero.Text,false,true,lblPagoCon.Text,lblVuelto.Text,true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAtenderDelivery_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Nombres","IDRepartidor", "Repartidor where Nombres != ''",cbxRepartidor);
            cbxRepartidor.Text = "";

            SqlDataReader lectoVenta = fn.selectMultiValues("select tc.NombreComprobante,c.Nombre,c.Numero as NroDocumento,c.Direccion,tp.TipoPago,v.Serie,v.Numero,iif(v.TipoImpresion='D','DETALLADO','POR CONSUMO') as TipoImpresion,v.DescuentoSoles,v.SubTotal,v.Igv,v.Total,v.PagoCon,v.Vuelto from Venta v inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante left join Cliente c on v.IDCliente = c.IDCliente inner join TipoPago tp on v.IDTipoPago = tp.IDTipoPago where v.IDVenta = '" + idVenta+ "'");
            while (lectoVenta.Read())
            {
                cboComprobante.Text = lectoVenta["NombreComprobante"].ToString();
                txtSerie.Text = lectoVenta["Serie"].ToString();
                txtNumero.Text = lectoVenta["Numero"].ToString();
                txtCliente.Text = lectoVenta["Nombre"].ToString();
                txtNroIdentidad.Text = lectoVenta["NroDocumento"].ToString();
                txtDireccion.Text = lectoVenta["Direccion"].ToString();
                cboTipoPago.Text = lectoVenta["TipoPago"].ToString();
                cboTipoImpresion.Text = lectoVenta["TipoImpresion"].ToString();
                txtDescuentoSoles.Text = lectoVenta["DescuentoSoles"].ToString();
                lblSubTotal.Text = lectoVenta["SubTotal"].ToString();
                lblIgv.Text = lectoVenta["Igv"].ToString();
                lblTotal.Text = lectoVenta["Total"].ToString();
                lblPagoCon.Text = lectoVenta["PagoCon"].ToString();
                lblVuelto.Text = lectoVenta["Vuelto"].ToString();
            }
            lectoVenta.Close();


            fn.ActualizarGrid(dgvPedido, "select pr.IDPresentacion as cnCodigo,vd.Presentacion as cnPlato,vd.Cantidad as cnCantidad,vd.Precio as cnPrecio,cast(vd.Cantidad * vd.Precio as decimal(18,2)) as cnImporte  from venta v  inner join VentaDetalle vd on v.IDVenta = vd.IDVenta inner join presentacion pr on vd.IDPresentacion = pr.IDPresentacion  inner join Producto pro on pr.IDProducto = pro.IDProducto  where v.Serie = '" + txtSerie.Text + "' and Numero = '" + txtNumero.Text + "'");
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
            if (validacion() == false)
            {
                return;
            }

            atenderDelivery();

            imprimir();

            this.Close();
        }

        private void imprimir()
        {
            try
            {
                
                    pdComprobante.Print();
                    pdComprobante.Print();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Comprobante: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void atenderDelivery()
        {
            fn.Modificar("Venta","IDRepartidor='"+cbxRepartidor.SelectedValue+"',Estado='ATENDIDO'","Serie='"+ txtSerie.Text + "' and Numero = '"+txtNumero.Text+"'");
        }

        private bool validacion()
        {
            if (string.IsNullOrEmpty(cbxRepartidor.Text) == true)
            {
                MessageBox.Show("Seleccione Repartidor", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if(fn.Existencia("*","Venta","Serie = '"+ txtSerie.Text + "' and Numero = '"+txtNumero.Text+"'") == false)
            {
                MessageBox.Show("No Existe Venta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbxRepartidor.SelectedValue == null)
            {
                MessageBox.Show("Seleccione Repartidor", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printDialog = new PrintPreviewDialog();
            printDialog.Document = pdComprobante;
            printDialog.ShowDialog();

            
        }
    }
}
