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
    public partial class FrmFacturaDelivery : Form
    {
        Funciones fn = new Funciones();
        Impresion im = new Impresion();
        bool existecliente;
        public bool existsOrder, facturado;
        public string IDRequest;
        string impresoraDelivery;
        public string idCliente;

        

        public FrmFacturaDelivery()
        {
            InitializeComponent();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //VALIDACION
            if (validationSave() == false)
            {
                return;
            }

            //Guarda Venta
            save();

            //Imprimir
            print();

            //AUMENTAR NUMERO
            increaseCode();

            //CLEAN
            clean();
        }

        private void saveOrder()
        {
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();

            //REGISTRAMOS PEDIDO
            fn.RegistrarOficial("Pedido", "Fecha,Hora,IDMesa,IDMozo,Total,Vendido,Anulado", "'" + date + "','" + time + "','" + lblMesa.Tag + "','" + lblMozo.Tag + "','" + lblTotal.Text + "','False','False'");

            IDRequest = fn.selectValue("select Max(IDPedido) from pedido");

            //REGISTRAMOS SU DETALLE DE PEDIDO
            registryDetail(IDRequest);

            //CAMBIAMOS ESTADO DE MESA
            fn.Modificar("Mesa", "Estado='LIBRE'", "IDMesa='" + lblMesa.Tag + "'");

        }

        private void registryDetail(string vidpedido)
        {
            //REGISTRY DETAIL ORDER
            for (int i = 0; i < dgvPedido.Rows.Count; i++)
            {
                string idPresentacion = dgvPedido.Rows[i].Cells["cnCodigo"].Value.ToString();
                string quantity = dgvPedido.Rows[i].Cells["cnCantidad"].Value.ToString();
                string presentacion = dgvPedido.Rows[i].Cells["cnPlato"].Value.ToString();
                string price = dgvPedido.Rows[i].Cells["cnPrecio"].Value.ToString();
                string cost = fn.selectValue("select Costo from Presentacion where IDPresentacion = '" + idPresentacion + "'");
                fn.RegistrarOficial("PedidoDetalle", "IDPedido,IDPresentacion,Presentacion,Cantidad,Precio,Imprimido,Costo", "'" + vidpedido + "','" + idPresentacion + "','" + presentacion + "','" + quantity + "','" + price + "','True','"+cost+"'");
            }
        }

        private void clean()
        {
            //QUITAMOS LOS PLATOS ATENDIDOS(CHECK)
            for (byte i = 0; i < dgvPedido.Rows.Count; i++)
            {
                if ((bool)dgvPedido.Rows[i].Cells["cnImprimido"].Value == true)
                {
                    dgvPedido.Rows.Remove(dgvPedido.Rows[i]);
                    i--;
                }
            }

            if (dgvPedido.Rows.Count == 0)
            {
                if (existsOrder == true)
                {
                    //DESOCUPAMOS MESA
                    fn.Modificar("Mesa", "Estado='LIBRE'", "IDMesa=(select IDMesa from Pedido where IDPedido = '" + IDRequest + "')");

                    //ATENDEMOS PEDIDO
                    fn.Modificar("Pedido", "Vendido='True'", "IDPedido='" + IDRequest + "'");
                }
            }

            cboComprobante.SelectedIndex = -1;
            cboTipoPago.SelectedIndex = -1;
            dgvPedido.DataSource = null;
            txtCliente.Text = "CLIENTES VARIOS";
            txtTelefono1.Text = "0";
            lblSubTotal.Text = "0.00";
            lblIgv.Text = "0.00";
            lblTotal.Text = "0.00";
            txtEfectivo.Text = "";
            lblCambio.Text = "0.00";
            txtSerie.Text = "";
            txtNumero.Text = "";
            facturado = true;
            MessageBox.Show("Venta Registrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (dgvPedido.Rows.Count == 0)
            {
                this.Close();
            }

            
           
        }

        private void cleanNotExists()
        {
           
        }

        private void increaseCode()
        {

            fn.Modificar("Talonario", "Numero=Numero+1", "Serie='" + txtSerie.Text + "'");
        }

        private void print()
        {

            try
            {
                //SI NO EXISTE PEDIDO IMPRIME COCINA Y BAR
                if (existsOrder == false)
                {
                    bool existsBar = false, existsCocina = false, existsHorno = false;

                    for (int i = 0; i < dgvPedido.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvPedido.Rows[i].Cells["cnImprimido"].Value) == true)
                        {
                            //GET CATEGORY OF THE PRESENTATION
                            string category = dgvPedido.Rows[i].Cells["cnCategoria"].Value.ToString();

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
                    }

                    if (existsBar == true)
                    {
                        pdBar.PrinterSettings.PrinterName = Datos.impresoraDeliveryBar;
                        pdBar.Print();
                    }

                    if (existsCocina == true)
                    {
                        pdCocina.PrinterSettings.PrinterName = Datos.impresoraDeliveryCocina;
                        pdCocina.Print();
                    }

                    if (existsHorno == true)
                    {
                        pdHorno.PrinterSettings.PrinterName = Datos.impresoraDeliveryHorno;
                        pdHorno.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Platos: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                pdComandaDelivery.Print();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Impresora Comanda Delivery: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void save()
        {
            try
            {
                if (cboTipoImpresion.Text == "DETALLADO")
                {
                    cboTipoImpresion.ValueMember = "D";
                }
                else
                {
                    cboTipoImpresion.ValueMember = "C";
                }

                //DATOS GUARDAR
                string idVenta = txtSerie.Text + "-" + txtNumero.Text;
                string idBox = fn.select_one_value("MAX(ID)", "Caja", "Tipo='DELIVERY' and IDSucursal = '"+Datos.idSucursal+"'", 0);
                
                DateTime time = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

                //GUARDAMOS VENTA
                fn.RegistrarOficial("Venta", "IDVenta,Fecha,Hora,IDTipoCom,Serie,Numero,IDCliente,NombreCliente,IDTipoPago,Igv,SubTotal,Total,IDEmpleado,Anulada,IDCaja,TipoImpresion,TipoVenta,IDMesa,IDMozo,Pagado,Estado,DescuentoPorcentaje,DescuentoSoles,PagoCon,Vuelto,CodigoComanda",
                "'" + idVenta + "','" + DateTime.Now.ToShortDateString() + "','" + time.ToString("HH:mm") + "','" + cboComprobante.SelectedValue + "','" + txtSerie.Text + "','" + txtNumero.Text + "','" + idCliente + "','" + txtCliente.Text + "','" + cboTipoPago.SelectedValue + "','" + lblIgv.Text + "','" + lblSubTotal.Text + "','" + lblTotal.Text + "','" + Datos.idUsuario + "','False','" + idBox + "','" + cboTipoImpresion.ValueMember + "','VD','" + lblMesa.Tag + "','" + lblMozo.Tag + "','False','SOLICITADO','"+fn.remplazarNulo(txtDescuentoPorc.Text)+"','"+fn.remplazarNulo(txtDescuentoSoles.Text)+"','"+txtEfectivo.Text+"','"+lblCambio.Text+"','"+idVenta+"'");

                //GUARDAMOS EL DETALLE DE VENTA
                foreach (DataGridViewRow rowDetalle in dgvPedido.Rows)
                {
                    if ((bool)rowDetalle.Cells["cnImprimido"].Value == true)
                    {
                        string idPresentacion = rowDetalle.Cells["cnCodigo"].Value.ToString();
                        string presentacion = rowDetalle.Cells["cnPlato"].Value.ToString();
                        string cantidad = rowDetalle.Cells["cnCantidad"].Value.ToString();
                        string costo = fn.selectValue("select costo from Presentacion where IDPresentacion = '" + idPresentacion + "'");
                        string precio = rowDetalle.Cells["cnPrecio"].Value.ToString();
                        string IDDetallePedido = rowDetalle.Cells["cnIDPedido"].Value.ToString();

                        //DETALLE DE VENTA
                        fn.RegistrarOficial("VentaDetalle", "IDVenta,IDPresentacion,Presentacion,Cantidad,Costo,Precio",
                            "'" + idVenta + "','" + idPresentacion + "','" + presentacion + "','" + cantidad + "','" + costo + "','" + precio + "'");

                        if(existsOrder == true)
                        {
                            fn.Modificar("PedidoDetalle", "Vendido='True'", "IDDetallePedido='" + IDDetallePedido + "'");
                        }
                    }
                }

                DescontarReceta(idVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DescontarReceta(string IDVenta)
        {
            SqlDataReader lectorDetalle = fn.selectMultiValues("select r.IDStockAlmacen,r.Cantidad * dv.Cantidad as devolucion from Venta v inner join VentaDetalle dv on v.IDVenta = dv.IDVenta inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion inner join Receta r on p.IDPresentacion = r.IDPresentacion inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen where v.IDVenta = '" + IDVenta + "'");
            while (lectorDetalle.Read())
            {
                string idStockAlmacen = lectorDetalle["IDStockAlmacen"].ToString();
                string cantidadUsada = lectorDetalle["devolucion"].ToString();

                fn.Modificar("StockAlmacen", "stock=stock-(" + cantidadUsada + ")", "IDStockAlmacen='" + idStockAlmacen + "'");
            }
            lectorDetalle.Close();
        }

        private bool validationSave()
        {
            byte seleccionados = 0;
            foreach (DataGridViewRow rowDetalle in dgvPedido.Rows)
            {
                if ((bool)rowDetalle.Cells["cnImprimido"].Value == true)
                {
                    seleccionados++;
                    break;
                }
            }

            if (seleccionados == 0)
            {
                MessageBox.Show("Seleccione Platos para le venta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(cboComprobante.Text) == true)
            {
                MessageBox.Show("Seleccione Comprobante", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(cboTipoImpresion.Text) == true)
            {
                MessageBox.Show("Seleccione Tipo de Impresión", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            if (string.IsNullOrEmpty(cboTipoPago.Text) == true)
            {
                MessageBox.Show("Seleccione Tipo de Pago", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboTipoPago.Text == "MASTERCARD" || cboTipoPago.Text == "VISA")
            {
                if (cboComprobante.Text == "TICKET")
                {
                    MessageBox.Show("Cuando El tipo de Pago, sea MASTERCARD Ó VISA. Se debe registrar mediante un comprobante. BOLETA O FACTURA", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (fn.Existencia("*", "Cliente", "Telefono='" + txtTelefono1.Text + "'") == false)
            {
                MessageBox.Show("Nro de Cliente no Exite", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboComprobante.Text == "FACTURA" && txtNroIdentidad.Text.Length != 11)
            {
                MessageBox.Show("Esta Especificando una Factura. Ruc Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboComprobante.Text == "BOLETA")
            {
                if (txtNroIdentidad.Text.Length != 8 && txtNroIdentidad.Text != "0" && string.IsNullOrEmpty(txtNroIdentidad.Text) == false)
                {
                    MessageBox.Show("Esta Especificando una Boleta. Nro de Identificacion del Cliente Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


                if (Convert.ToDouble(lblTotal.Text) > 700)
                {
                    string nombreClient = fn.selectValue("select Nombre from cliente where Numero = '" + txtNroIdentidad.Text + "'");
                    if (nombreClient == "CLIENTES VARIOS" || string.IsNullOrEmpty(nombreClient) == true)
                    {
                        MessageBox.Show("La Venta Supera los S./ 700.00. Especificar Cliente!", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

            }

            //VALIDAMOS CORTESIA
            if (cboTipoPago.Text == "CORTESIA" && cboComprobante.Text != "TICKET")
            {
                MessageBox.Show("Las cortesias se imprimen en el comprobante TICKET", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboTipoPago.Text == "CORTESIA" && (txtCliente.Text == "CLIENTES VARIOS" || string.IsNullOrWhiteSpace(txtCliente.Text)))
            {
                MessageBox.Show("Ingrese el Nombre de la Persona a quien va dirigida la cortesia", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvPedido.Rows.Count == 0)
            {
                MessageBox.Show("No asignó productos a esta venta", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }



            if (fn.Existencia("*", "Venta", "Serie='" + txtSerie.Text + "' and Numero='" + txtNumero.Text + "'") == true)
            {
                DialogResult msje = MessageBox.Show("La Venta con la Serie y el Correlativo ya Existe. Desea Actualizarla?", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (msje == DialogResult.OK)
                {
                    string nuevoNumero = fn.selectValue("select Max(numero) from venta where Serie = '" + txtSerie.Text + "'");
                    fn.Modificar("Talonario", "Numero='" + nuevoNumero + "'", "Serie='" + txtSerie.Text + "'");

                    MessageBox.Show("Operacion Correcta. Seleccione Nuevamente el Tipo de Documento y Vuelva a registrar", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboComprobante.SelectedIndex = -1;
                    return false;
                }
                else
                {
                    return false;
                }
            }

           


            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //print();
            this.Close();
        }

        private void txtNroCliente_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtTelefono1.Text) == false)
                {
                    if (fn.Existencia("*", "cliente", "Telefono = '" + txtTelefono1.Text + "'") == true)
                    {
                        SqlDataReader lectorCliente = fn.selectMultiValues("select * from cliente where Telefono = '" + txtTelefono1.Text + "'");
                        lectorCliente.Read();
                        idCliente = lectorCliente["IDCliente"].ToString();
                        txtCliente.Text = lectorCliente["Nombre"].ToString();
                        txtNroIdentidad.Text = lectorCliente["Numero"].ToString();
                        txtTelefono1.Text = lectorCliente["Telefono"].ToString();
                        txtTelefono2.Text = lectorCliente["Telefono2"].ToString();
                        txtDireccion.Text = lectorCliente["Direccion"].ToString();
                        txtReferencia.Text = lectorCliente["Referencia"].ToString();
                        lectorCliente.Close();
                    }
                    else if (fn.Existencia("*", "cliente", "Telefono2 = '" + txtTelefono1.Text + "'") == true)
                    {
                        SqlDataReader lectorCliente = fn.selectMultiValues("select * from cliente where Telefono = '" + txtTelefono1.Text + "'");
                        lectorCliente.Read();
                        idCliente = lectorCliente["IDCliente"].ToString();
                        txtCliente.Text = lectorCliente["Nombre"].ToString();
                        txtNumero.Text = lectorCliente["Numero"].ToString();
                        txtTelefono1.Text = lectorCliente["Telefono"].ToString();
                        txtTelefono2.Text = lectorCliente["Telefono2"].ToString();
                        txtDireccion.Text = lectorCliente["Direccion"].ToString();
                        txtReferencia.Text = lectorCliente["Referencia"].ToString();
                        lectorCliente.Close();
                    }
                    else
                    {
                        DialogResult msj = MessageBox.Show("El Cliente no se Encuentra Registrado. Desea Registrarlo", "FactuTEd", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (msj == DialogResult.OK)
                        {
                            FrmClientes frm = new FrmClientes();
                            frm.ShowDialog();
                        }
                    }
                }

            }
            else if(e.KeyCode == Keys.F5)
            {
                FrmClientes frm = new FrmClientes();
                frm.ShowDialog();
            }
        }
        //private void BuscarCliente(string Numero)
        //{
        //    if (fn.Existencia("*", "Cliente", "Telefono='" + Numero + "'") == true)
        //    {
        //        SqlDataReader readerClient = fn.selectMultiValues("select * from cliente where Telefono = '" + Numero + "'");
        //        readerClient.Read();
        //        txtCliente.Text = readerClient["Nombre"].ToString();

        //        txtNroIdentidad.Text = readerClient["Numero"].ToString();

        //        txtDireccion.Text = readerClient["Direccion"].ToString();
        //        txtReferencia.Text = readerClient["Referencia"].ToString();
        //        existecliente = true;
        //        readerClient.Close();
        //    }
        //    else
        //    {
        //        DialogResult msj = MessageBox.Show("Cliente no existe. Desea Registrarlo?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //        if (msj == DialogResult.OK)
        //        {
        //            FrmClientes frm = new FrmClientes();
        //            frm.DesBloquear();
        //            frm.txttelefono.Text = txtTelefono1.Text;
        //            frm.txtnombre.Focus();
        //            //FrmClientes.venta = true;
        //            frm.ShowDialog();

        //            if (FrmClientes.cancelado == false)
        //            {
        //                //BuscarCliente(txtTelefono1.Text);
        //            }

        //        }
        //    }
        //}

        private void FrmFacturar_Load(object sender, EventArgs e)
        {
            //DATOS DEL CLIENTE
            SqlDataReader lector = fn.selectMultiValues("select * from cliente where IDCliente = '"+idCliente+"'");
            lector.Read();
            txtCliente.Text = lector["Nombre"].ToString();
            txtNumero.Text = lector["Numero"].ToString();
            txtTelefono1.Text = lector["Telefono"].ToString();
            txtTelefono2.Text = lector["Telefono2"].ToString();
            txtDireccion.Text = lector["Direccion"].ToString();
            txtReferencia.Text = lector["Referencia"].ToString();
            lector.Close();

            
            
            

            //COMBOBOX
            fn.añadir_ddl("NombreComprobante", "IDTipoComprobante", "TipoComprobante where NombreComprobante != 'SIN COMPROBANTE' and NombreComprobante = 'TICKET'", cboComprobante);
            fn.añadir_ddl("TipoPago", "IDTipoPago", "TipoPago", cboTipoPago);
            //fn.CargarCombo("Nombres", "IDRepartidor", "Repartidor where IDRepartidor != '1'", cboRepartidor);


            cboTipoPago.SelectedIndex = -1;
            cboComprobante.SelectedIndex = -1;
            cboTipoImpresion.Text = "DETALLADO";

            //BOX DATE
            string ultimaFechaCaja = fn.select_one_value("top(1)cast(FECHA_HORA as Date)", "Caja", "ID>=0 order by ID Desc", 0);
            lblFechaCaja.Text = Convert.ToDateTime(ultimaFechaCaja).ToShortDateString();


            cboComprobante.Text = "TICKET";
            cargarSerie(cboComprobante.Text);

            calculateTotal();
        }

        private void pdBoletaT_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            if (cboTipoImpresion.Text == "DETALLADO")
            {
                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    if ((bool)row.Cells["cnImprimido"].Value == true)
                    {
                        decimal untario, costo;
                        decimal can_2;
                        int cantidad;
                        string descri;

                        descri = row.Cells["cnDescripcion"].Value.ToString();

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

        private void pdFacturaT_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            e.Graphics.DrawString("DIRECCION: " +txtDireccion.Text, new Font("Courier New Condensada", 6, FontStyle.Regular), Brushes.Black, new Point(10, 135));
            e.Graphics.DrawString("T. Pago: " + cboTipoPago.Text + " - F:" + DateTime.Now.ToShortDateString() + " / H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 148));


            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 175));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 175));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 175), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 175), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 186));

            int SUMATORIA = 0;
            //DETALLADO
            if (cboTipoImpresion.Text == "DETALLADO")
            {
                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    if ((bool)row.Cells["cnImprimido"].Value == true)
                    {
                        decimal untario, costo;
                        decimal can_2;
                        int cantidad;
                        string descri;

                        descri = row.Cells["cnDescripcion"].Value.ToString();

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

        private void cboTipoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDescuentoPorc.Text = fn.selectValue("select Descuento from TipoPago where IDTipoPago = '" + cboTipoPago.SelectedValue + "'");
            if (Convert.ToDouble(txtDescuentoPorc.Text) > 0)
            {
                txtDescuentoPorc.Enabled = false;
                txtDescuentoSoles.Enabled = false;
            }
            else
            {
                txtDescuentoPorc.Enabled = true;
                txtDescuentoSoles.Enabled = true;
            }

            double DescuentoPorc, total;

            total = obtenerTotal();
            DescuentoPorc = Convert.ToDouble(fn.remplazarNulo(txtDescuentoPorc.Text));
            txtDescuentoSoles.Text = (DescuentoPorc * total / 100).ToString("0.00");


            calculateTotal();
        }

        private void dgvPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPedido.Columns["cnImprimido"].Index && e.RowIndex >= 0)
            {
                bool estado = (bool)dgvPedido.CurrentRow.Cells["cnImprimido"].Value;

                if (estado == true)
                {
                    dgvPedido.CurrentRow.Cells["cnImprimido"].Value = false;

                }
                else
                {
                    dgvPedido.CurrentRow.Cells["cnImprimido"].Value = true;
                }

                calculateTotal();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                ppDialog.Document = pdComandaDelivery;
                ppDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Comprobante: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            try
            {
                //SI NO EXISTE PEDIDO IMPRIME COCINA Y BAR
                if (existsOrder == false)
                {
                    bool existsBar = false, existsCocina = false, existsHorno = false;

                    for (int i = 0; i < dgvPedido.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvPedido.Rows[i].Cells["cnImprimido"].Value) == true)
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

                            if (existsCocina == true && existsBar == true && existsHorno == true)
                            {
                                break;
                            }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Platos: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                ppDialog.Document = pdComandaDelivery;
                ppDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresora Comanda Delivery: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pdPreCuenta_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            im.comandaDelivery(true,txtReferencia.Text.Trim(),txtTelefono1.Text.Trim() + " : "+txtTelefono2.Text,cboComprobante.Text,"DNI",e,DateTime.Now.ToShortDateString(),DateTime.Now.ToShortTimeString(),txtSerie.Text,txtNumero.Text,txtDireccion.Text,txtCliente.Text,txtNroIdentidad.Text,cboTipoPago.Text,cboTipoImpresion.Text,dgvPedido,lblTotal.Text,lblMesa.Text,lblMozo.Text,txtSerie.Text+"-"+txtNumero.Text);

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void cboComprobante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarSerie(cboComprobante.Text);
        }

        private void pdBar_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            im.comanda("BAR", e, lblMesa.Text, lblMozo.Text, txtSerie.Text + " - " + txtNumero.Text, dgvPedido, false, true,true,txtCliente.Text);
        }

        private void pdCocina_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            im.comanda("COCINA", e, lblMesa.Text, lblMozo.Text, txtSerie.Text + " - " + txtNumero.Text, dgvPedido,false, true,true,txtCliente.Text);
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            frmReimprimir frm = new frmReimprimir();
            frm.ShowDialog();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            FrmObservacion frm = new FrmObservacion();
            frm.ShowDialog();
        }



        private void cargarSerie(string comprobante)
        {
            try
            {
                string Query = "";
                if (comprobante == "TICKET")
                {
                    Query = "select t.Serie,(t.Numero +1) as Numero from Talonario t where COMPROBANTE = 'TICKET' AND IDSucursal = '"+Datos.idSucursal+"'";
                }
                //else if (comprobante == "BOLETA" || comprobante == "FACTURA")
                //{
                //    Query = "select t.Serie,(t.Numero +1) as Numero from usuario u inner join TalonarioUsuario tu on u.IDUsuario = tu.IDUsuario inner join Talonario t on tu.IDTalonario = t.IDTalonario where COMPROBANTE = 'COMPROBANTE' and u.IDUsuario = '" + Datos.idUsuario + "'";
                //}

                SqlDataReader lector = fn.selectMultiValues(Query);
                lector.Read();

                txtSerie.Text = lector["Serie"].ToString();
                txtNumero.Text = Convert.ToDecimal(lector["Numero"].ToString()).ToString("00000000");

                lector.Close();
            }
            catch
            {

            }

        }



        private void calculateTotal()
        {

            double total = 0, igv = 0, subTotal = 0, descuentoSoles = 0;

            descuentoSoles = Convert.ToDouble(fn.remplazarNulo(txtDescuentoSoles.Text));


            total = obtenerTotal();
            total = total - descuentoSoles;



            subTotal = total / 1.18;
            igv = subTotal * 0.18;

            lblTotal.Text = total.ToString("00.00");
            lblIgv.Text = igv.ToString("00.00");
            lblSubTotal.Text = subTotal.ToString("00.00");
        }

        private void pdTicketVentaT_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            e.Graphics.DrawString("--TICKET CONTROL--", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(90, 80));

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
            if (cboTipoImpresion.Text == "DETALLADO")
            {
                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    if ((bool)row.Cells["cnImprimido"].Value == true)
                    {
                        decimal untario, costo;
                        decimal can_2;
                        int cantidad;
                        string descri;
                        descri = row.Cells["cnPlato"].Value.ToString();
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

        private void txtDescuentoPorc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double DescuentoPorc, total;

                total = obtenerTotal();
                DescuentoPorc = Convert.ToDouble(fn.remplazarNulo(txtDescuentoPorc.Text));
                txtDescuentoSoles.Text = (DescuentoPorc * total / 100).ToString("0.00");

                calculateTotal();
            }
        }

        private void txtDescuentoSoles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double DescuentoSoles, total;
                DescuentoSoles = Convert.ToDouble(fn.remplazarNulo(txtDescuentoSoles.Text));
                total = obtenerTotal();
                txtDescuentoPorc.Text = (DescuentoSoles * 100 / total).ToString("0.00");

                calculateTotal();
            }
        }
        double obtenerTotal()
        {
            double total = 0;

            for (int i = 0; i < dgvPedido.Rows.Count; i++)
            {
                if ((bool)dgvPedido.Rows[i].Cells["cnImprimido"].Value == true)
                {
                    double importe = Convert.ToDouble(dgvPedido.Rows[i].Cells["cnImporte"].Value.ToString());
                    total = total + importe;
                }
            }

            return total;
        }

        private void pdHorno_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            im.comanda("HORNO", e, lblMesa.Text, lblMozo.Text, txtSerie.Text + " - " + txtNumero.Text, dgvPedido, false, true, true, txtCliente.Text);
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double total = Convert.ToDouble(lblTotal.Text);
                double efectivo = Convert.ToDouble(txtEfectivo.Text);

                lblCambio.Text = Math.Round((efectivo - total), 2).ToString();
            }
            catch
            {

            }
        }

    }
}
