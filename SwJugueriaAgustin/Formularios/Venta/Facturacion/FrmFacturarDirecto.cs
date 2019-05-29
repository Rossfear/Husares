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
    public partial class FrmFacturarDirecto : Form
    {
        Funciones fn = new Funciones();
        Impresion im = new Impresion();
        bool existecliente;
        public bool existsOrder, facturado;
        public string IDRequest;
        Clases.Conversion CONVERSION = new Conversion();



        public FrmFacturarDirecto()
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
            if (!save()) return;

            //PRINT
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
                fn.RegistrarOficial("PedidoDetalle", "IDPedido,IDPresentacion,Presentacion,Cantidad,Precio,Imprimido,Costo", "'" + vidpedido + "','" + idPresentacion + "','" + presentacion + "','" + quantity + "','" + price + "','True','" + cost + "'");
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
            txtCliente.Text = "CLIENTES VARIOS";
            txtDireccion.Text = "";
            txtNroCliente.Text = "0";
            lblSubTotal.Text = "0.00";
            lblIgv.Text = "0.00";
            lblTotal.Text = "0.00";
            txtEfectivo.Text = "";
            lblCambio.Text = "0.00";
            txtSerie.Text = "";
            txtNumero.Text = "";
            facturado = true;


            if (dgvPedido.Rows.Count == 0)
            {
                this.Close();
            }

        }

        private void cleanNotExists()
        {
            cboComprobante.SelectedIndex = -1;
            cboTipoPago.SelectedIndex = -1;
            dgvPedido.DataSource = null;
            txtCliente.Text = "CLIENTES VARIOS";
            txtNroCliente.Text = "0";
            lblSubTotal.Text = "0.00";
            lblIgv.Text = "0.00";
            lblTotal.Text = "0.00";
            txtEfectivo.Text = "";
            lblCambio.Text = "0.00";
            txtSerie.Text = "";
            txtNumero.Text = "";
        }

        private void increaseCode()
        {
            fn.Modificar("Talonario", "Numero=Numero+1", "Serie='" + txtSerie.Text + "'");
        }

        private void print()
        {
            try
            {
                if(Datos.cantidadComprobante == 1)
                {
                    pdComprobante.Print();
                }
                else
                {
                    pdComprobante.Print();
                    pdComprobante.Print();
                }
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
                    bool existsBar = false, existsCocina = false,existsHorno = false;

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
                        pdBar.PrinterSettings.PrinterName = Datos.impresorallevarBar;
                        pdBar.Print();
                    }

                    if (existsCocina == true)
                    {
                        pdCocina.PrinterSettings.PrinterName = Datos.impresorallevarCocina;
                        pdCocina.Print();
                    }

                    if (existsCocina == true)
                    {
                        pdCocina.PrinterSettings.PrinterName = Datos.impresorallevarHorno;
                        pdHorno.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion Platos: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool save()
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

                string idVenta = txtSerie.Text + "-" + txtNumero.Text;
                string codigoComanda;
                if (existsOrder == true)
                    codigoComanda = lblComanda.Text;
                else
                    codigoComanda = idVenta;


                //DATOS GUARDAR
                
                string idBox = fn.select_one_value("MAX(ID)", "Caja", "Tipo = 'VENTA SALON' and IDSucursal='"+Datos.idSucursal+"'", 0);
                string idClient = fn.selectValue("select IDCliente from cliente where Numero='" + txtNroCliente.Text + "'");
                DateTime time = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

                //GUARDAMOS VENTA
                fn.RegistrarOficial("Venta", "IDVenta,Fecha,Hora,IDTipoCom,Serie,Numero,IDCliente,NombreCliente,IDTipoPago,Igv,SubTotal,Total,IDEmpleado,Anulada,IDCaja,TipoImpresion,TipoVenta,IDRepartidor,IDMesa,IDMozo,DescuentoPorcentaje,DescuentoSoles,CodigoComanda",
                "'" + idVenta + "','" + DateTime.Now.ToShortDateString() + "','" + time.ToString("HH:mm") + "','" + cboComprobante.SelectedValue + "','" + txtSerie.Text + "','" + txtNumero.Text + "','" + idClient + "','" + txtCliente.Text + "','" + cboTipoPago.SelectedValue + "','" + lblIgv.Text + "','" + lblSubTotal.Text + "','" + lblTotal.Text + "','" + Datos.idUsuario + "','False','" + idBox + "','" + cboTipoImpresion.ValueMember + "','VS','1','" + lblMesa.Tag + "','" + lblMozo.Tag + "','" + fn.remplazarNulo(txtDescuentoPorc.Text) + "','" + fn.remplazarNulo(txtDescuentoSoles.Text) + "','"+codigoComanda+"'");

                //GUARDAMOS EL DETALLE DE VENTA
                foreach (DataGridViewRow rowDetalle in dgvPedido.Rows)
                {
                    if ((bool)rowDetalle.Cells["cnImprimido"].Value == true)
                    {
                        string idPresentacion = rowDetalle.Cells["cnCodigo"].Value.ToString();
                        string presentacion = rowDetalle.Cells["cnPlato"].Value.ToString();
                        string descripcion = rowDetalle.Cells["cnDescripcion"].Value.ToString();
                        string cantidad = rowDetalle.Cells["cnCantidad"].Value.ToString();
                        string costo = rowDetalle.Cells["cnCosto"].Value.ToString();
                        string precio = rowDetalle.Cells["cnPrecio"].Value.ToString();
                        string IDDetallePedido = rowDetalle.Cells["cnIDPedido"].Value.ToString();
                        bool combo = Convert.ToBoolean(rowDetalle.Cells["cnCombo"].Value);
                        string IDPresentacionCombo = rowDetalle.Cells["cnIDPresentacionCombo"].Value.ToString();

                        //DETALLE DE VENTA
                        fn.RegistrarOficial("VentaDetalle", "IDVenta,IDPresentacion,Presentacion,Descripcion,Cantidad,Costo,Precio,Combo,IDPresentacionCombo",
                            "'" + idVenta + "','" + idPresentacion + "','" + presentacion + "','" + descripcion + "','" + cantidad + "','" + costo + "','" + precio + "','"+combo+"','"+IDPresentacionCombo+"'");

                        if (existsOrder == true)
                        {
                            fn.Modificar("PedidoDetalle", "Vendido='True'", "IDDetallePedido='" + IDDetallePedido + "'");
                        }
                    }
                }

                DescontarReceta(idVenta);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar: Ocurrio un error inesperado al guardar. Verificar si se registro la venta. " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void DescontarReceta(string IDVenta)
        {
            SqlDataReader lectorDetalle = fn.selectMultiValues("select r.IDStockAlmacen,r.Cantidad * dv.Cantidad as devolucion from Venta v inner join VentaDetalle dv on v.IDVenta = dv.IDVenta inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion inner join Receta r on p.IDPresentacion = r.IDPresentacion inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen where v.IDVenta = '"+IDVenta+"'");
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

            if (fn.Existencia("*", "Cliente", "Numero='" + txtNroCliente.Text + "'") == false)
            {
                MessageBox.Show("Nro de Cliente no Exite", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboComprobante.Text == "FACTURA" && txtNroCliente.Text.Length != 11)
            {
                MessageBox.Show("Esta Especificando una Factura. Ruc Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboComprobante.Text == "BOLETA")
            {
                if (txtNroCliente.Text.Length != 8 && txtNroCliente.Text != "0")
                {
                    MessageBox.Show("Esta Especificando una Boleta. Nro de Identificacion del Cliente Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


                if (Convert.ToDouble(lblTotal.Text) > 700)
                {
                    string nombreClient = fn.selectValue("select Nombre from cliente where Numero = '" + txtNroCliente.Text + "'");
                    if (nombreClient == "CLIENTES VARIOS" || string.IsNullOrEmpty(nombreClient) == true)
                    {
                        MessageBox.Show("La Venta Supera los S./ 700.00. Especificar Cliente!", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

            }

            //VALIDAMOS CORTESIA
            if ((cboTipoPago.Text == "CORTESIA" || cboTipoPago.Text == "DESCUENTO PERSONAL" || cboTipoPago.Text == "CREDITO") && cboComprobante.Text != "TICKET")
            {
                MessageBox.Show("Tipo de Pago (Cortesia - Descuento Personal - Credito) se imprimen en el comprobante TICKET", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ((cboTipoPago.Text == "CORTESIA" || cboTipoPago.Text == "DESCUENTO PERSONAL" || cboTipoPago.Text == "CREDITO") && (txtCliente.Text == "CLIENTES VARIOS" || string.IsNullOrWhiteSpace(txtCliente.Text)))
            {
                MessageBox.Show("Tipo de Pago (Cortesia - Descuento Personal - Credito) se Especifica el Nombre del Cliente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                
                BuscarCliente(txtNroCliente.Text);
            }

        }
        private void BuscarCliente(string Numero)
        {
            if (Numero.Length == 8 || Numero.Length == 11 || Numero == "0")
            {
                if (Numero == "")
                {
                    MessageBox.Show("Ingrese DNI del cliente", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCliente.Text = "CLIENTES VARIOS";
                    return;
                }

                if (fn.Existencia("*", "Cliente", "Numero='" + Numero + "'") == true)
                {
                    existecliente = true;
                    SqlDataReader lectorCliente = fn.selectMultiValues("select * from cliente where Numero='" + Numero + "'");
                    while (lectorCliente.Read())
                    {
                        txtCliente.Text = lectorCliente["Nombre"].ToString();
                        txtDireccion.Text = lectorCliente["Direccion"].ToString();
                    }
                    lectorCliente.Close();
                }
                else
                {
                    if (Numero.Length == 8)
                    {
                        string nombre = fn.obtenerClienteDNI(txtNroCliente.Text);

                        if (string.IsNullOrWhiteSpace(nombre))
                        {
                            MessageBox.Show("DNI no encontrado");
                            return;
                        }

                        fn.RegistrarOficial("Cliente", "Nombre,Numero,Telefono,Telefono2,Direccion,Referencia, IDTipoDocumento",
                        "'" + nombre + "','" + Numero + "','','','" + txtDireccion.Text.Trim() + "','',(select IDTipoDocumento from TipoDocumento where Descripcion  ='DNI')");

                        txtCliente.Text = nombre;
                    }
                    else if (Numero.Length == 11)
                    {
                        using (ConsultaRuc.WsConsultaClient consulta = new ConsultaRuc.WsConsultaClient())
                        {
                            var empresa = consulta.ObtenerEmpresa(Numero);

                            if (empresa.RazonSocial != "Error")
                            {
                                fn.RegistrarOficial("Cliente", "Nombre,Numero,Telefono,Telefono2,Direccion,Referencia, IDTipoDocumento",
                                "'" + empresa.RazonSocial.Replace("'","''") + "','" + Numero + "','','','" + empresa.Direccion + "','',(select IDTipoDocumento from TipoDocumento where Descripcion  ='RUC')");

                                txtCliente.Text = empresa.RazonSocial;
                                txtDireccion.Text = empresa.Direccion;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Numero de identificación incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCliente.Text = "CLIENTES VARIOS";
            }
        }

        private void FrmFacturar_Load(object sender, EventArgs e)
        {
            cboTipoPago.Text = "EFECTIVO";

            string condicionST = "";
            if (Datos.sinTicket == true)
            {
                condicionST = " and NombreComprobante != 'TICKET'";
            }

            //COMBOBOX
            fn.añadir_ddl("NombreComprobante", "IDTipoComprobante", "TipoComprobante where NombreComprobante = 'BOLETA' or NombreComprobante = 'FACTURA' or NombreComprobante = 'TICKET'" + condicionST + "", cboComprobante);


            fn.añadir_ddl("TipoPago", "IDTipoPago", "TipoPago", cboTipoPago);


            cboTipoPago.SelectedIndex = -1;
            cboComprobante.Text = "BOLETA";
            cargarSerie(cboComprobante.Text);
            cboTipoImpresion.Text = "DETALLADO";

            //BOX DATE
            string ultimaFechaCaja = fn.select_one_value("top(1)cast(FECHA_HORA as Date)", "Caja", "ID>=0 order by ID Desc", 0);
            lblFechaCaja.Text = Convert.ToDateTime(ultimaFechaCaja).ToShortDateString();

            OcultarCombos();


            calculateTotal();


        }


        private void OcultarCombos()
        {
            foreach (DataGridViewRow fila in dgvPedido.Rows)
            {
                string idPedido = fila.Cells["cnIDPresentacionCombo"].Value.ToString();

                if (!string.IsNullOrWhiteSpace(idPedido))
                {
                    fila.Visible = false;
                }
            }
        }
        private void pdBoletaT_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string comprobante = "",tipoDocumento;bool ticket;
            if (cboComprobante.Text == "BOLETA")
            {
                comprobante = "BOLETA DE VENTA ELECTRÓNICA";
                tipoDocumento = "DNI";
                ticket = false;
            }
            else if (cboComprobante.Text == "FACTURA")
            {
                comprobante = "FACTURA DE VENTA ELECTRÓNICA";
                tipoDocumento = "RUC";
                ticket = false;
            }
            else
            {
                comprobante = "PRECUENTA CONTROL";
                tipoDocumento = "DNI";
                ticket = true;
            }
                


            im.Comprobante(comprobante,tipoDocumento,e,DateTime.Now.ToShortDateString(),DateTime.Now.ToShortTimeString(),txtSerie.Text,txtNumero.Text,txtDireccion.Text,txtCliente.Text,txtNroCliente.Text,cboTipoPago.Text,cboTipoImpresion.Text,dgvPedido,lblTotal.Text,txtDescuentoSoles.Text,lblSubTotal.Text,lblIgv.Text,lblMesa.Text,lblMozo.Text,lblComanda.Text,false,false,txtEfectivo.Text,lblCambio.Text,ticket);
        }


        private void cboTipoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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

        private void btnVista_Click(object sender, EventArgs e)
        {
            try
            {
                ppDialog.Document = pdComprobante;
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
                            string category = dgvPedido.Rows[i].Cells["cnCategoria"].Value.ToString();

                            if (category == "BAR")
                            {
                                existsBar = true;
                            }
                            if (category == "HORNO")
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
        }

        private void cboComprobante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarSerie(cboComprobante.Text);
        }

        private void pdBar_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool cliente = (lblMesa.Text.Equals("LLEVAR A") || lblMesa.Text.Equals("LLEVAR B"));

            im.comanda("BAR",e,lblMesa.Text,lblMozo.Text,txtSerie.Text+"-"+txtNumero.Text,dgvPedido,false,true,cliente,txtCliente.Text);
        }

        private void pdCocina_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool cliente = (lblMesa.Text.Equals("LLEVAR A") || lblMesa.Text.Equals("LLEVAR B"));

            im.comanda("COCINA",e,lblMesa.Text,lblMozo.Text,txtSerie.Text+"-"+txtNumero.Text,dgvPedido,false,true,cliente,txtCliente.Text);
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
                    Query = "select t.Serie,(t.Numero +1) as Numero from Talonario t where COMPROBANTE = 'TICKET' AND IDSucursal='"+Datos.idSucursal+"'";
                }
                else if (comprobante == "BOLETA")
                {
                    Query = "select t.Serie,(t.Numero +1) as Numero from Talonario t where COMPROBANTE = 'BOLETA' and IDSucursal = '"+Datos.idSucursal+"'";
                }
                else if (comprobante == "FACTURA")
                {
                    Query = "select t.Serie,(t.Numero +1) as Numero from Talonario t where COMPROBANTE = 'FACTURA' and IDSucursal = '"+Datos.idSucursal+"'";
                }

                SqlDataReader lector = fn.selectMultiValues(Query);
                lector.Read();

                txtSerie.Text = lector["Serie"].ToString();
                txtNumero.Text = Convert.ToDecimal(lector["Numero"].ToString()).ToString("00000000");

                lector.Close();


                txtNroCliente.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

            lblTotal.Text = total.ToString("0.00");
            lblIgv.Text = igv.ToString("0.00");
            lblSubTotal.Text = subTotal.ToString("0.00");

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
                    if ((bool)row.Cells["cnImprimido"].Value == true)
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



            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 380 + SUMATORIA));
            e.Graphics.DrawString("Canjeable por Comprobante", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(67, 395 + SUMATORIA));
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 405 + SUMATORIA));
            e.Graphics.DrawString("F: " + DateTime.Now.ToShortDateString() + "  -  H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(10, 415 + SUMATORIA));
        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && string.IsNullOrEmpty(cboComprobante.Text) == false)
            {
                txtNroCliente.Focus();
            }
        }

        private void txtDescuentoGlobal_TextChanged(object sender, EventArgs e)
        {

            //calculateTotal();
        }

        private void cboComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuentoSoles_TextChanged(object sender, EventArgs e)
        {


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

        private void pdHorno_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool cliente = (lblMesa.Text.Equals("LLEVAR A") || lblMesa.Text.Equals("LLEVAR B"));

            im.comanda("HORNO", e, lblMesa.Text, lblMozo.Text, txtSerie.Text + "-" + txtNumero.Text, dgvPedido, false, true, cliente, txtCliente.Text);
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double total = Convert.ToDouble(lblTotal.Text);
                double efectivo = Convert.ToDouble(txtEfectivo.Text);

                lblCambio.Text = (efectivo - total).ToString("0.00");
            }
            catch
            {
                lblCambio.Text = "0.00";
            }
        }

    }
}
