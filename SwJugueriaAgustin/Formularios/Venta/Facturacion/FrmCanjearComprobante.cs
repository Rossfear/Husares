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

namespace SwJugueriaAgustin.Formularios.Operaciones
{
    public partial class FrmCanjearComprobante : Form
    {
        FrmClientes frmCliente = new FrmClientes();
        Empresas myInfo;
        frmMensaje _frmMesaje = new frmMensaje();
        Funciones fn = new Funciones();
        FrmTeclado frmTeclado = new FrmTeclado();
        private string impresora = Datos.impresoraComprobante;

        public FrmCanjearComprobante()
        {
            InitializeComponent();
        }

        private void txtSerie_Click(object sender, EventArgs e)
        {
            frmAddCantidad frm = new frmAddCantidad();
            frm.ShowDialog();
        }

        private void FrmCanjearComprobante_Load(object sender, EventArgs e)
        {
            if (Datos.sinTicket == true)
            {
                btnTickeB.Visible = false;
                btnTicket.Visible = false;
                txtSerie.Text = "";
            }
            else
            {
                btnTickeB.Visible = true;
                btnTicket.Visible = true;

                selectComprobanteBuscar(btnTickeB, btnBoletaB, btnFacturaB);
                
            }

            selectComprobante(btnBoleta, btnFactura, btnTicket);

            txtNumero.Text = "";
            lblSerieActual.Text = "00";
            lblNumeroActual.Text = "00000000";
            lblTotal.Text = "0.00";
            lblTipoPago.Text = "";
            txtNroDocumento.Text = "0";
            txtCliente.Text = "CLIENTES VARIOS";
            dgvDetalleVenta.DataSource = null;
            chbxPorConsumo.Checked = false;
        }



        void selectComprobanteBuscar(Button btnSelect, Button btnNoSelect1, Button btnNoSelect2)
        {
            try
            {
                btnSelect.BackColor = Color.Lime;
                btnNoSelect1.BackColor = Color.Gainsboro;
                btnNoSelect2.BackColor = Color.Gainsboro;


                if (btnSelect.Text == "T")
                {
                    txtSerie.Text = fn.selectValue("select NON_TABLA FROM GENERADOR WHERE COMPROBANTE ='TICKET'");
                }
                else if (btnSelect.Text == "B")
                {
                    txtSerie.Text = fn.selectValue("select NON_TABLA FROM GENERADOR WHERE COMPROBANTE ='COMPROBANTE'");
                }
                else if (btnSelect.Text == "F")
                {
                    txtSerie.Text = fn.selectValue("select NON_TABLA FROM GENERADOR WHERE COMPROBANTE ='COMPROBANTE'");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        void selectComprobante(Button btnSelect, Button btnNoSelect1, Button btnNoSelect2)
        {
            btnSelect.BackColor = Color.Lime;
            btnNoSelect1.BackColor = Color.Gainsboro;
            btnNoSelect2.BackColor = Color.Gainsboro;

            //CARGAMOS SERIE - CORRELATIVO
            string consulta = "";
            if (btnSelect.Text == "T")
            {
                lblComprobante.Tag = fn.selectValue("select IDTipoComprobante from TipoComprobante where NombreComprobante = 'TICKET'");
                labelDNIRUC.Text = "D.N.I:";
                consulta = "select NON_TABLA as Serie,(NUMERO +1) as Numero from Generador WHERE COMPROBANTE = 'TICKET'";
            }
            else if (btnSelect.Text == "B")
            {
                lblComprobante.Tag = fn.selectValue("select IDTipoComprobante from TipoComprobante where NombreComprobante = 'BOLETA'");
                labelDNIRUC.Text = "D.N.I:";
                consulta = "select NON_TABLA as Serie,(NUMERO +1) as Numero from Generador WHERE COMPROBANTE = 'COMPROBANTE'";
            }
            else if (btnSelect.Text == "F")
            {
                lblComprobante.Tag = fn.selectValue("select IDTipoComprobante from TipoComprobante where NombreComprobante = 'FACTURA'");
                labelDNIRUC.Text = "R.U.C:";
                consulta = "select NON_TABLA as Serie,(NUMERO +1) as Numero from Generador WHERE COMPROBANTE = 'COMPROBANTE'";
            }

            SqlDataReader readerTalonario = fn.selectMultiValues(consulta);
            readerTalonario.Read();
            lblSerie.Text = readerTalonario["Serie"].ToString();
            lblNumero.Text = Convert.ToDecimal(readerTalonario["Numero"].ToString()).ToString("00000000");
            readerTalonario.Close();

            lblComprobante.Text = btnSelect.Text;
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            selectComprobante(btnFactura, btnBoleta, btnTicket);
        }

        private void btnBoleta_Click(object sender, EventArgs e)
        {
            selectComprobante(btnBoleta, btnFactura, btnTicket);
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            selectComprobante(btnTicket, btnBoleta, btnFactura);
        }

       
        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddCantidad frmCantidad = new frmAddCantidad();
                frmCantidad.ShowDialog();

                if (frmCantidad.Cancelado == false)
                {
                    txtNumero.Text = Convert.ToDecimal(frmCantidad.txtCantidad.Text).ToString("00000000");
                    


                    string idVenta = txtSerie.Text + " - " + txtNumero.Text;

                    SqlDataReader readerVenta = fn.selectMultiValues("select tp.IDTipoPago,tp.TipoPago,v.Total,v.NombreCliente,c.Numero,v.Anulada,v.NroComanda  from venta v  inner join Cliente c on v.IDCliente = c.IDCliente  inner join TipoPago tp on v.IDTipoPago = tp.IDTipoPago where v.IDVenta = '"+idVenta+"'");
                    readerVenta.Read();
                    bool anulada = Convert.ToBoolean(readerVenta["Anulada"].ToString());
                    if(anulada == true)
                    {
                        MessageBox.Show("No se Puede Cangear el comprobante "+idVenta+". Por que se Encuentra Anulado.", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    lblSerieActual.Text = txtSerie.Text;
                    lblNumeroActual.Text = txtNumero.Text;
                    lblTipoPago.Tag = readerVenta["IDTipoPago"].ToString();
                    lblTipoPago.Text = readerVenta["TipoPago"].ToString();
                    lblTotal.Text = readerVenta["Total"].ToString();
                    txtCliente.Text = readerVenta["NombreCliente"].ToString();
                    txtNroDocumento.Text = readerVenta["Numero"].ToString();
                    lblNroComanda.Text = readerVenta["NroComanda"].ToString();
                    readerVenta.Close();


                    

                    fn.ActualizarGrid(dgvDetalleVenta, "select dv.IDPresentacion as cnCodigo,dv.Presentacion as cnPresentacion,dv.Cantidad as cnCantidad,Precio as cnPrecio,(Cantidad * Precio) as cnImporte from DetalleVenta dv where IDVenta = '" + idVenta + "'");

                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            //VALIDAMOS
            if(validacionGuardar()  == false)
            {
                return;
            }

            //GUARDAMOS VENTA
            save();

            //IMPRIMIR
            print();

            //FINAL DEL CANJE
            end();
        }

        private void end()
        {
            fn.Modificar("Generador", "Numero=Numero+1", "NON_TABLA='" + lblSerie.Text + "'");
            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void print()
        {
            try
            {
                if (lblComprobante.Text == "F")
                {
                    //IMPRIME FACTURA
                    pdFacturaT.PrinterSettings.PrinterName = impresora;
                    pdFacturaT.Print();

                }
                else if (lblComprobante.Text == "B")
                {
                    //IMPRIME EL COMPROBANTE BOLETA
                    pdBoletaT.PrinterSettings.PrinterName =impresora;
                    pdBoletaT.Print();
                }
                else
                {
                    //IMPRIME TICKET
                    //pdTicketVentaT.PrinterSettings.PrinterName =impresora;
                    pdTicketVentaT.Print();
                    pdTicketVentaT.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool validacionGuardar()
        {
            if (dgvDetalleVenta.Rows.Count == 0)
            {
                MessageBox.Show("Especifique Productos a la Venta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fn.Existencia("*", "Cliente", "Numero='" + txtNroDocumento.Text + "'") == false)
            {
                MessageBox.Show("Cliente no Existe", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToSingle(lblTotal.Text) >= 700 && txtCliente.Text == "0" && lblComprobante.Text == "B")
            {
                MessageBox.Show("Cuando la venta Sea igual o mayor a S./700.00 debe ingresar el D.N.I del Cliente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lblTipoPago.Text == "MASTERC." || lblTipoPago.Text == "VISA")
            {
                if (lblComprobante.Text == "T")
                {
                    MessageBox.Show("Cuando El tipo de Pago, sea MASTERCARD Ó VISA. Se debe registrar mediante un comprobante. BOLETA O FACTURA", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (lblTipoPago.Text == "CORTESIA" && (txtCliente.Text == "CLIENTES VARIOS" || string.IsNullOrWhiteSpace(txtCliente.Text)))
            {
                MessageBox.Show("Ingrese el Nombre de la Persona a quien va dirigida la cortesia", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //HALLAMOS EL TIPO DE COMPROBANTE
            if (lblComprobante.Text == "F")
            {
                if (fn.Existencia("*", "Cliente", "Numero='" + txtNroDocumento.Text + "'") == false || txtNroDocumento.TextLength != 11)
                {
                    MessageBox.Show("Estas Emitiendo Una Factura. RUC No Existente", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if(lblComprobante.Text != "F" && txtNroDocumento.Text.Length == 11)
            {
                MessageBox.Show("Esta Emitiendo una Boleta. Verificar N° de Documento.", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (fn.Existencia("*", "Venta", "Serie='" + lblSerie.Text + "' and Numero='" + lblNumero.Text + "'") == true)
            {
                DialogResult msj = MessageBox.Show("La Venta con la Serie y el Correlativo ya se encuentra Registrada. Seleccion Aceptar para Actualizar", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msj == DialogResult.OK)
                {
                    string nuevoNumero = fn.select_one_value("max(Numero)", "venta", "serie = '" + lblSerie.Text + "' and len(Numero) = 8", 0);
                    fn.Modificar("GENERADOR", "NUMERO='" + nuevoNumero + "'", "NON_TABLA='" + lblSerie.Text + "'");

                    if (lblComprobante.Text == "T")
                    {
                        selectComprobante(btnTicket, btnBoleta, btnFactura);
                    }
                    else if (lblComprobante.Text == "B")
                    {
                        selectComprobante(btnBoleta, btnTicket, btnFactura);
                    }
                    else
                    {
                        selectComprobante(btnFactura, btnBoleta, btnTicket);
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void save()
        {
            try
            {
                

                string idCaja = fn.select_one_value("MAX(ID)", "Caja", "ID>0", 0);
                string IDVenta = lblSerie.Text + " - " + lblNumero.Text;
                string date = DateTime.Now.ToShortDateString();
                DateTime time = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                string idCliente = fn.selectValue("select IDCliente from Cliente where Numero = '" + txtNroDocumento.Text + "'");

                float total = Convert.ToSingle(lblTotal.Text);
                float subTotal = total / 1.18f;
                float igv = subTotal * 0.18f;

                //REGISTRAMOS LA VENTA
                fn.RegistrarOficial("Venta", "IDVenta,Fecha,Hora,Igv,SubTotal,Total,IDProcesoTienda,Pagado,IDCliente,IDEmpleado,NombreCliente,Serie,Numero,IDTipoCom,Anulada,IDTipoPago,Pasaje,IDCaja,NroComanda",
                "'" + IDVenta + "','" + date + "','" + time.ToString("HH:mm") + "','" + igv + "','" + subTotal + "','" + total + "','VentaDirecta','1','" + idCliente + "','" + Datos.idUsuario + "','" + txtCliente.Text + "','" + lblSerie.Text + "','" + lblNumero.Text + "','" + lblComprobante.Tag + "','0','" + lblTipoPago.Tag + "','0','" + idCaja + "','" + lblNroComanda.Text + "'");
                //REGISTRAMOS DETALLE DE VENTA
                foreach (DataGridViewRow rowDetalle in dgvDetalleVenta.Rows)
                {
                    string idPresentacion = rowDetalle.Cells["cnCodigo"].Value.ToString();
                    string presentacion = rowDetalle.Cells["cnPresentacion"].Value.ToString();
                    string cantidad = rowDetalle.Cells["cnCantidad"].Value.ToString();
                    string costo = fn.selectValue("select Costo from Producto where IDProducto = '" + idPresentacion + "'");
                    string precio = rowDetalle.Cells["cnPrecio"].Value.ToString();

                    //REGISTRAMOS DETALLE DE VENTA
                    fn.RegistrarOficial("DetalleVenta", "IDVenta,IDPresentacion,Presentacion,Cantidad,Costo,Precio",
                        "'" + IDVenta + "','" + idPresentacion + "','" + presentacion + "','" + cantidad + "','" + costo + "','" + precio + "'");
                }




                //ANULAMOS LA VENTA POR TICKET
                fn.Modificar("Venta", "Anulada='True'", "IDVenta='" + lblSerieActual.Text + " - " + lblNumeroActual.Text + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Save: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void txtNroDocumento_Click(object sender, EventArgs e)
        {
            frmAddCantidad frmCantidad = new frmAddCantidad();
            frmCantidad.txtCantidad.Text = "";
            frmCantidad.ShowDialog();

            if (frmCantidad.Cancelado == false)
            {
                txtNroDocumento.Text = frmCantidad.txtCantidad.Text;
                BuscarCliente(txtNroDocumento.Text);
            }

            
        }


        private void BuscarCliente(string Numero)
        {
            try
            {
                if (Numero.Length == 8 || Numero.Length == 11 || Numero == "0")
                {
                    //VERIFICAMOS EXISTENCIA DEL CLIENTE
                    if (fn.Existencia("*", "Cliente", "Numero='" + Numero + "'") == true)
                    {
                        txtCliente.Text = fn.select_one_value("Nombre", "Cliente", "Numero='" + Numero + "'", 0);
                    }
                    //SI NO EXISTE - REGISTRAMOS
                    else
                    {
                        if (Numero.Length == 8)
                        {
                            frmBuscarDni FRM = new frmBuscarDni();
                            frmBuscarDni.ConTeclado = true;
                            frmBuscarDni.DNI = Numero;
                            txtNroDocumento.Clear();
                            txtCliente.Text = "CLIENTES VARIOS";
                            FRM.ShowDialog();

                            if (FRM.existe == true)
                            {
                                txtNroDocumento.Text = FRM.txt_dni.Text;
                                if (Numero != "")
                                {
                                    if (fn.Existencia("Numero", "Cliente", "Numero='" + txtNroDocumento.Text + "'") == true)
                                    {
                                        txtCliente.Text = fn.select_one_value("Nombre", "Cliente", "Numero='" + txtNroDocumento.Text + "'", 0);
                                    }
                                }
                            }
                        }
                        //SUNAT
                        else if (Numero.Length == 11)
                        {
                            try
                            {
                                while (noExisteRegistre() == false)
                                {
                                    DialogResult msj = MessageBox.Show("Error Consulta Sunat. Verificar R.U.C. Desea Reintentar?", "FactuTED", MessageBoxButtons.RetryCancel);

                                    if (msj == DialogResult.Retry)
                                    {
                                        noExisteRegistre();
                                    }
                                    else if (msj == DialogResult.Cancel)
                                    {
                                        break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            if (fn.Existencia("Numero", "Cliente", "Numero='" + Numero + "'") == true)
                            {
                                txtCliente.Text = fn.select_one_value("Nombre", "Cliente", "Numero='" + Numero + "'", 0);
                            }
                        }
                    }
                }
                else
                {
                    _frmMesaje.lblmensaje.Text = "NUMERO DE DOCUMENTO INCORRECTO";
                    _frmMesaje.ShowDialog();

                    txtNroDocumento.Text = "0";
                    txtCliente.Text = "CLIENTES VARIOS";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private bool noExisteRegistre()
        {
            try
            {
                if (myInfo == null)
                {
                    myInfo = new Empresas();
                }

                string codigoCatcher = myInfo.UseTesseract();
                myInfo.GetInfo(txtNroDocumento.Text, codigoCatcher);
                string direccion = myInfo.ApeMaterno;
                string razonSocial = myInfo.Nombres;

                if (razonSocial != "Error!")
                {
                    fn.RegistrarOficial("Cliente", "Nombre,Numero,Telefono,Direccion,Referencia", "'" + razonSocial + "','" + txtNroDocumento.Text + "','','" + direccion + "',''");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        private void pdFacturaT_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion



            e.Graphics.DrawString(Datos.nombreComercial, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(35, 12));
            e.Graphics.DrawString(Datos.RazonSocial, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(95, 27));
            e.Graphics.DrawString("RUC: " + Datos.Ruc, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 40));
            e.Graphics.DrawString(Datos.Direccion, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 52));
            e.Graphics.DrawString(Datos.Departmaneto, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(40, 64));
            e.Graphics.DrawString("TICKET FACTURA", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(70, 80));

            //nÚMERO COMPROBANTE
            e.Graphics.DrawString(lblSerie.Text + " - " + lblNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(75, 93));

            //DAtos PErsona
            e.Graphics.DrawString("RAZ: " + txtCliente.Text, new Font("Courier New Condensada", 6, FontStyle.Regular), Brushes.Black, new Point(10, 113));
            e.Graphics.DrawString("RUC: " + txtNroDocumento.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 126));
            e.Graphics.DrawString("DIRECCION: " + fn.select_one_value("Direccion", "Cliente", "Numero='" + txtNroDocumento.Text + "'", 0), new Font("Courier New Condensada", 6, FontStyle.Regular), Brushes.Black, new Point(10, 139));
            e.Graphics.DrawString("T. Pago: " + lblTipoPago.Text + " - F:" + DateTime.Now.ToShortDateString() + " / H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 152));

            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 175));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 175));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 175), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 175), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 183));


            int SUMATORIA = 0;

            //FALSE REMPLAZAR POR CONSUMO(CONSULTAR)
            if (chbxPorConsumo.Checked == false)
            {
                foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
                {

                    decimal untario, costo;
                    decimal can_2;
                    int cantidad;
                    string descri;

                    descri = fn.select_one_value("Presentacion", "Presentacion", "IDPresentacion='" + row.Cells[0].Value.ToString() + "'", 0);
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
                e.Graphics.DrawString("CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 189 + SUMATORIA + 5));

                e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 202 + SUMATORIA + 8), alineacion);
                e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 202 + SUMATORIA + 8), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 215 + SUMATORIA));
                SUMATORIA = SUMATORIA + 30;
            }





            double sub_total2 = 0, igv2 = 0, total2 = 0;

            sub_total2 = Convert.ToDouble(lblTotal.Text) / 1.18;
            igv2 = sub_total2 * 0.18;
            total2 = Convert.ToDouble(lblTotal.Text);

            Conversion CONVERSION = new Conversion();
            string letras = CONVERSION.enletras(lblTotal.Text.ToString());


            e.Graphics.DrawString("SUBTOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 230 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + Math.Round(sub_total2, 2).ToString(), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 230 + SUMATORIA - 25), alineacion);


            e.Graphics.DrawString("IGV:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 243 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + Math.Round(igv2, 2).ToString(), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 243 + SUMATORIA - 25), alineacion);


            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 256 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 256 + SUMATORIA - 25), alineacion);

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


            e.Graphics.DrawString("N° Control: " + lblNroComanda.Text, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(5, 292 + SUMATORIA - 25));

            //e.Graphics.DrawString("Consulta Comprobante: www.innovated.pe/micomprobante", new Font("Courier New Condensada", 6, FontStyle.Bold), Brushes.Black, new Point(5, 292 + SUMATORIA - 5));
            e.Graphics.DrawString("Wifi: "+Datos.wifi, new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(5, 302 + SUMATORIA));
            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 317 + SUMATORIA));
        }

        private void pdBoletaT_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion



            e.Graphics.DrawString(Datos.nombreComercial, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(35, 12));
            e.Graphics.DrawString(Datos.RazonSocial, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(95, 27));
            e.Graphics.DrawString("RUC: " + Datos.Ruc, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 40));
            e.Graphics.DrawString(Datos.Direccion, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 52));
            e.Graphics.DrawString(Datos.Departmaneto, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(40, 64));
            e.Graphics.DrawString("TICKET BOLETA", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(70, 80));

            //nÚMERO COMPROBANTE
            e.Graphics.DrawString(lblSerie.Text + " - " + lblNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 94));

            if (txtCliente.TextLength > 30)
            {
                string persona1 = txtCliente.Text.Substring(0, 30);
                string persona2 = txtCliente.Text.Substring(30);

                //DAtos PErsona
                e.Graphics.DrawString("SR(A): " + persona1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 120 - 13));
                e.Graphics.DrawString(persona2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 120));
            }
            else
            {
                e.Graphics.DrawString("SR(A): " + txtCliente.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 120));
            }


            e.Graphics.DrawString("DNI: " + txtNroDocumento.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 133));
            e.Graphics.DrawString("T. Pago: " + lblTipoPago.Text + " - F:" + DateTime.Now.ToShortDateString() + " / H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 146));



            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 179));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 179));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 179 + 3), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 179 + 3), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 192));

            int SUMATORIA = 0;
            //CONSULTAR SI EXISTE EL POR CONSUMO(CAMBAIR FALSE)
            if (chbxPorConsumo.Checked == false)
            {
                foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
                {

                    float untario, costo;
                    byte cantidad;


                    string descri = fn.select_one_value("Presentacion", "Presentacion", "IDPresentacion='" + row.Cells["cnCodigo"].Value.ToString() + "'", 0);

                    cantidad = Convert.ToByte(row.Cells["cnCantidad"].Value);
                    untario = Convert.ToSingle(row.Cells["cnPrecio"].Value);
                    costo = Convert.ToSingle(row.Cells["cnImporte"].Value);







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
                e.Graphics.DrawString("CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 205 + SUMATORIA + 5));

                e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 218 + SUMATORIA + 8), alineacion);
                e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 218 + SUMATORIA + 8), alineacion);
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




            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(70, 245 + SUMATORIA - 25));//276
            e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 245 + SUMATORIA - 25), alineacion);

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

            e.Graphics.DrawString("N° Control: " + lblNroComanda.Text, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(5, 294 + SUMATORIA - 25));
            e.Graphics.DrawString("Wifi: " + Datos.wifi, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(5, 304 + SUMATORIA - 25));

            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 317 + SUMATORIA));
        }

        private void pdTicketVentaT_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion



            e.Graphics.DrawString(Datos.nombreComercial, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(35, 12));
            e.Graphics.DrawString(Datos.RazonSocial, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(95, 27));
            e.Graphics.DrawString("RUC: " + Datos.Ruc, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 40));
            e.Graphics.DrawString(Datos.Direccion, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 52));
            e.Graphics.DrawString(Datos.Departmaneto, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(40, 64));
            e.Graphics.DrawString("TICKET CONTROL", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(70, 80));

            //nÚMERO COMPROBANTE
            e.Graphics.DrawString(lblSerie.Text + " - " + lblNumero.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 94));



            //DAtos PErsona
            e.Graphics.DrawString("SR(A): " + txtCliente.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 120));
            e.Graphics.DrawString("DNI: " + txtNroDocumento.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 133));
            e.Graphics.DrawString("T. Pago: " + lblTipoPago.Text + " - F:" + DateTime.Now.ToShortDateString() + " / H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 146));


            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 179));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 179));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 179), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 179), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 192));


            int SUMATORIA = 0;

            //CONSULTAR SI EXISTE EL POR CONSUMO
            if (chbxPorConsumo.Checked == false)
            {
                foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
                {

                    decimal untario, costo;
                    byte cantidad;


                    string descri = fn.select_one_value("Presentacion", "Presentacion", "IDPresentacion='" + row.Cells[0].Value.ToString() + "'", 0);

                    cantidad = Convert.ToByte(row.Cells["cnCantidad"].Value);
                    untario = Convert.ToDecimal(row.Cells["cnPrecio"].Value);
                    costo = Convert.ToDecimal(row.Cells["cnImporte"].Value);


                    e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5));
                    e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5));

                    e.Graphics.DrawString("" + untario.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 231 - 13 + SUMATORIA + 8), alineacion);
                    e.Graphics.DrawString("" + costo.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 231 - 13 + SUMATORIA + 8), alineacion);
                    e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 245 - 13 + SUMATORIA));
                    SUMATORIA = SUMATORIA + 30;

                }
            }
            else
            {
                e.Graphics.DrawString("1", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5));
                e.Graphics.DrawString("CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5));

                e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 231 - 13 + SUMATORIA + 8), alineacion);
                e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 231 - 13 + SUMATORIA + 8), alineacion);
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
            e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 268 - 13 + SUMATORIA - 25), alineacion);

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


            e.Graphics.DrawString("Wifi: "+Datos.wifi, new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(5, 283 - 13 + SUMATORIA));
            e.Graphics.DrawString("N° Control: " + lblNroComanda.Text, new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(5, 283 + 15 - 13 + SUMATORIA));
            e.Graphics.DrawString("Canjear por Comprobante", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(85, 298 + 15 - 13 + SUMATORIA));
            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(85, 298 + 15 + SUMATORIA));

        }

        private void btnTickeB_Click(object sender, EventArgs e)
        {
            selectComprobanteBuscar(btnTickeB, btnBoletaB, btnFacturaB);
        }

        private void btnBoletaB_Click(object sender, EventArgs e)
        {
            selectComprobanteBuscar(btnBoletaB, btnTickeB, btnFacturaB);
        }

        private void btnFacturaB_Click(object sender, EventArgs e)
        {
            selectComprobanteBuscar(btnFacturaB, btnBoletaB, btnTickeB);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblComprobante.Text == "F")
                {
                    //IMPRIME FACTURA
                    ppdVer.Document = pdFacturaT;
                    ppdVer.ShowDialog();

                }
                else if (lblComprobante.Text == "B")
                {
                    //IMPRIME EL COMPROBANTE BOLETA
                    ppdVer.Document = pdBoletaT;
                    ppdVer.ShowDialog();
                }
                else
                {
                    //IMPRIME TICKET
                    ppdVer.Document = pdTicketVentaT;
                    ppdVer.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresion: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCliente_Click(object sender, EventArgs e)
        {
            frmTeclado.txtTexto.Text = "";
            frmTeclado.ShowDialog();

            txtCliente.Text = frmTeclado.txtTexto.Text;
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FrmClientes.conTeclado = true;

            //if (txtNroDocumento.Text != "0")
            //{
            //    frmCliente.txtnumero.Text = txtNroDocumento.Text;
            //}
            //frmCliente.ShowDialog();



            //if (FrmClientes.cancelado == false)
            //{
            //    txtNroDocumento.Text = frmCliente.txtnumero.Text;
            //    txtCliente.Text = frmCliente.txtnombre.Text;
            //}


            ////LIMPIAMOS LA INSTANCIA
            //frmCliente.txtdireccion.Text = "";
            
            //frmCliente.txtnombre.Text = "";
            //frmCliente.txtnumero.Text = "";
            //frmCliente.txtReferencia.Text = "";
            //frmCliente.txttelefono.Text = "";

        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {
            fn.llamarTeclado();
            
            if (txtCliente.Text == "CLIENTES VARIOS")
            {
                txtCliente.Text = "";
                txtCliente.Focus();
            }
            
        }
    }
}
