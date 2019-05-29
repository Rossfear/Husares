using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Compra;
using SwJugueriaAgustin.Formularios.Mantenimientos.Atributos;
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
    public partial class FrmAddCompra : Form
    {
        Funciones fn = new Funciones();
        public string idRegistro;
        public bool editar = false;

        public FrmAddCompra()
        {
            InitializeComponent();
            KeyPreview = true;
            dgvDetalle.Columns["cnAfecto"].ReadOnly = false;

            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where PermiteEntrada='True'", cbxAlmacen);
            fn.añadir_ddl("NombreComprobante", "IDTipoComprobante", "TipoComprobante where NombreComprobante != 'TICKET'", cbxTipoComprobante);
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvProductos.Focus();
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            MostrarGridProducto();
        }

        private void MostrarGridProducto()
        {
            fn.MostrarGri("IDInsumo as Cod,Insumo,u.UniMedida,p.Costo",
                           "Insumo p, UnidadMedida u",
                           "p.IDUniMedida = u.IDUniMedida and Insumo like '%" + txtProducto.Text + "%'", dgvProductos, "Insumo");
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string codProducto = dgvProductos.CurrentRow.Cells["cod"].Value.ToString();
                    string Producto = dgvProductos.CurrentRow.Cells["Insumo"].Value.ToString();

                  




                    frmAddCantidad f = new frmAddCantidad();
                    f.lblCantidad.Text = "CANTIDAD";
                    f.ShowDialog();

                    if (f.Cancelado == true) { return; }
                    float cantidad = Convert.ToSingle(f.txtCantidad.Text);
                    f.txtCantidad.Text = "";
                    f.lblCantidad.Text = "IMPORTE";
                    f.ShowDialog();

                    if (f.Cancelado == true) { return; }
                    float importe = Convert.ToSingle(f.txtCantidad.Text);
                    if (f.Cancelado == true) { return; }
                    //float cosTotalNuevo = cantidad * PrecioNuevo;

                    //float costoTotal = cosTotalAntiguo + cosTotalNuevo;
                    //float cantidadTotal = stocktotal + cantidad;

                    //float costoPromedio = costoTotal / cantidadTotal;

                    //float subTotal = costoPromedio * cantidad;

                    dgvDetalle.Rows.Add(codProducto, Producto, cantidad, (importe / cantidad).ToString("0.00"), importe.ToString("0.00"), true, "x");

                    calcularFacturacion();
                    txtProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmCompra_Load(object sender, EventArgs e)
        {
            cbxAlmacen.SelectedValue = Datos.IDAlmacen;
            chbxAumentarStock.Checked = Datos.AumentarStock;
        }

        

        private void AumentarCodigo()
        {
            fn.Modificar("Ayuda", "IDAyuda=IDAyuda+1", "Descripcion='COMPRA'");

        }

       

        //private void GenerarCodVenta()
        //{
        //    int codVenta = Convert.ToInt32(fn.select_one_value("IDAyuda", "Ayuda", "Descripcion='Compra'", 0));
        //    lblCodCompra.Text = (codVenta + 1).ToString();
        //}



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void limpiar()
        {
            txtProducto.Text = "";
            editar = false;

            dgvDetalle.Rows.Clear();
            
            
            txtSerie.Text = "";
            txtCorrelativo.Text = "";
            txtNumero.Text = "";
            txtNombre.Text = "";
            

            

            txtBaseNoGravada.Text = "0";
            txtBaseGravada.Text = "0";
            lblIGV.Text = "0";
            txtDescuento.Text = "0";
            txtOtrosTributos.Text = "0";
            txtDescuento.Text = "0";
            txtOtrosTributos.Text = "0";
            txtISC.Text = "0";
            lblTotal.Text = "0.00";
            
            
            txtNombre.Focus();
            
        }

        private void Guardar()
        {
            if (validacionGuardar() == false)
            {
                return;
            }

            save();


            endSave();
        }

        private void endSave()
        {
            
            limpiar();
            
        }

        private void save()
        {
            string aumentaStock;

            //OBTENEMOS DATOS
            if (chbxAumentarStock.Checked == true)
            { aumentaStock = "True"; }
            else
            { aumentaStock = "False"; }


            string idProveedor;
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            { idProveedor = fn.selectValue("select IDProveedor from proveedor where Numero = '0'"); }
            else
            { idProveedor = fn.selectValue("select IDProveedor from proveedor where Numero = '" + txtNumero.Text + "'"); }



            //VARIABLES
            float tipoCambio = Convert.ToSingle(txtTipoCambio.Text);
            string fechaRegistro = DateTime.Now.ToShortDateString();
            string horaRegistro = DateTime.Now.ToShortTimeString();
            


            //VARIABLES FACTURACION
            double afecto = Convert.ToDouble(txtBaseGravada.Text) * tipoCambio;
            double inafecto = Convert.ToDouble(txtBaseNoGravada.Text) * tipoCambio;
            double igv = Convert.ToDouble(lblIGV.Text) * tipoCambio;
            double isc = Convert.ToDouble(fn.remplazarNulo(txtISC.Text)) * tipoCambio;
            double otros = Convert.ToDouble(fn.remplazarNulo(txtOtrosTributos.Text)) * tipoCambio;
            double descuento = Convert.ToDouble(fn.remplazarNulo(txtDescuento.Text)) * tipoCambio;
            double total = Convert.ToDouble(lblTotal.Text) * tipoCambio;

            string fecha = DateTime.Now.ToShortDateString();


            

            if (editar == true)
            {
                string idAlmacenAntiguo = fn.selectValue("select IDAlmacen FROM compra where IDCompra = '" + lblIDComproEditada.Text + "'");
                bool antiguoAumentaStock = Convert.ToBoolean(fn.selectValue("select AumentaStock FROM compra where IDCompra = '" + lblIDComproEditada.Text + "'"));


                //REGISTRAMOS EDICION DE COMPRA
                fn.RegistrarOficial("CompraEdicion", "IDUsuario,IDCompra", "'" + Datos.idUsuario + "','" + lblIDComproEditada.Text + "'");


                //SI EN LA COMPRA ANTERIOR SE AUMENTO EL STOCK - LO DESMINUIMOS
                if (antiguoAumentaStock == true)
                {
                    //DESCONTAMOS LA ENTRADA DE INSUMO DEL ANTERIOR COMPRA
                    SqlDataReader lectorDetalle = fn.selectMultiValues("select * from DetalleCompra where IDCompra = '" + lblIDComproEditada.Text + "'");
                    while (lectorDetalle.Read())
                    {
                        string idInsumo = lectorDetalle["IDInsumo"].ToString();
                        string cantidad = lectorDetalle["Cantidad"].ToString();

                        string idStockAlmacen = fn.selectValue("select IDStockAlmacen from StockAlmacen where IDAlmacen = '" + idAlmacenAntiguo + "' and IDInsumo = '" + idInsumo + "'");

                        fn.Modificar("StockAlmacen", "Stock=Stock-" + cantidad, "IDStockAlmacen  = '" + idStockAlmacen + "'");

                        string stockActual = fn.selectValue("select Stock from StockAlmacen where IDStockAlmacen = '" + idStockAlmacen + "'");

                        //REGISTRAMOS KARDEX
                        fn.RegistrarOficial("Kardex", "Fecha,Proceso,CodProceso,Entrada,Salida,Saldo,IDStockAlmacen",
                            "'" + fechaRegistro + "','EDICION COMPRA','" + lblIDComproEditada.Text + "','0','" + cantidad + "','" + stockActual + "','" + idStockAlmacen + "'");
                    }
                    lectorDetalle.Close();
                }

                //EDITAMOS COMPRA
                fn.Modificar("Compra", "FechaRegistro='" + fechaRegistro + "',HoraRegistro='" + horaRegistro + "',FechaEmision='" + dtpFechaComprobante.Value.ToShortDateString() + "',FechaVencimiento='" + dtpFechaVencimiento.Value.ToShortDateString() + "',IDTipoComprobante='" + cbxTipoComprobante.SelectedValue + "',Serie='" + txtSerie.Text + "',Numero='" + txtCorrelativo.Text + "',IDProveedor='" + idProveedor + "',Moneda='" + cbxMoneda.Text + "',ConIGV='"+chbxConIGV.Checked+"',BaseNoGravada='" + txtBaseNoGravada.Text + "',BaseGravada='" + txtBaseGravada.Text + "',IGV='" + lblIGV.Text + "',ISC='" + txtISC.Text + "',OtrosTributos='" + txtOtrosTributos.Text + "',Descuento='" + txtDescuento.Text + "',Total='" + lblTotal.Text + "',TipoCambio='" + txtTipoCambio.Text + "',Impuesto='" + lblImpuesto.Text + "',IDUsuario='" + Datos.idUsuario + "',IDAlmacen='" + cbxAlmacen.SelectedValue + "',AumentaStock='" + aumentaStock + "'", "IDCompra='" + lblIDComproEditada.Text + "'");


                string IDEntrada = fn.selectValue("select IDEntrada from EntradaCompra where IDCompra = '" + lblIDComproEditada.Text + "' ");

                fn.Eliminar("DetalleCompra", "IDCompra='" + lblIDComproEditada.Text + "'");
                fn.Eliminar("DetalleEntradaInsumo", "IDEntradaInsumo='" + IDEntrada + "'");
                fn.Eliminar("EntradaInsumo", "IDEntrada='" + IDEntrada + "'");
                fn.Eliminar("EntradaTienda", "IDEntrada='" + IDEntrada + "'");

                registroDetalle(lblIDComproEditada.Text);


                MessageBox.Show("Compra Actualizada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            else
            {
                //REGITRAMOS LA COMPRA
                fn.RegistrarOficial("Compra", "FechaRegistro,HoraRegistro,FechaEmision,FechaVencimiento,IDTipoComprobante,Serie,Numero,IDProveedor,Moneda,BaseNoGravada,BaseGravada,Igv,ISC,OtrosTributos,Descuento,Total,TipoCambio,Impuesto,IDUsuario,Cancelada,IDAlmacen,AumentaStock,IDRegistroCompra,ConIGV",
                    "'" + fechaRegistro + "','" + horaRegistro + "','" + dtpFechaComprobante.Value.ToShortDateString() + "','" + dtpFechaVencimiento.Value.ToShortDateString() + "','" + cbxTipoComprobante.SelectedValue + "','" + txtSerie.Text + "','" + txtCorrelativo.Text + "','" + idProveedor + "','" + cbxMoneda.Text + "','" + inafecto + "','" + afecto + "','" + igv + "','" + isc + "','" + otros + "','" + descuento + "','" + total + "','" + tipoCambio + "','" + lblImpuesto.Text + "','" + Datos.idUsuario + "','False','" + cbxAlmacen.SelectedValue + "','" + aumentaStock + "','" + idRegistro + "','"+chbxConIGV.Checked+"'");


                string IDCompra = fn.select_one_value("max(IDCompra)", "Compra", "IDCompra!=0", 0);

                registroDetalle(IDCompra);

                MessageBox.Show("Compra Registrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }

        private void registroDetalle(string IDCompra)
        {
            string IDEntrada = "";
            //VERIFICA SI SE AUMENTA EL STOCK
            if (chbxAumentarStock.Checked == true)
            {
                //REGISTRAMOS ENTRADA
                fn.RegistrarOficial("EntradaInsumo", "Fecha,IDTipoEntrada,IDAlmacenReceptor,Anulada,IDUsuario", 
                    "'" + DateTime.Now.ToShortDateString() + "',(SELECT IDTipoEntrada from TipoEntrada where TipoEntrada ='COMPRA'),'" + cbxAlmacen.SelectedValue + "','False','" + Datos.idUsuario + "'");


                IDEntrada = fn.select_one_value("MAX(IDEntrada)", "EntradaInsumo", "IDEntrada>0", 0);

                fn.RegistrarOficial("EntradaCompra","IDCompra,IDEntrada","'"+IDCompra+"','"+IDEntrada+"'");

                if(fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '"+cbxAlmacen.SelectedValue+"'") == "True")
                {
                    fn.RegistrarOficial("EntradaTienda", "IDEntrada,IDApertura", "'" + IDEntrada + "',(select max(IDApertura) from AperturaAlmacen)");
                }
            }

            //DETALLE
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                string dafecto = row.Cells["cnAfecto"].Value.ToString();
                string IDInsumo = row.Cells["cnCodigo"].Value.ToString();
                string cantidad = row.Cells["cnCantidad"].Value.ToString();

                //REGISTRAMOS EL DETALLE DE COMPRA
                fn.Registrar("DetalleCompra", "'" + IDCompra + "','" + IDInsumo + "','" + row.Cells["cnCantidad"].Value.ToString() + "','" + row.Cells["cPreCompra"].Value.ToString() + "','" + dafecto + "'");

                //VERIFICAMOS SI SE AUMENTA EL STOCK
                if (chbxAumentarStock.Checked == true)
                {
                    //REGISTRAMOS LA ENTRADA
                    fn.RegistrarOficial("DetalleEntradaInsumo", "IDEntradaInsumo,IDInsumo,Cantidad", "'" + IDEntrada + "','" + IDInsumo + "','" + cantidad + "'");

                    //Verificamos si existe el insumo en el almacen
                    if (fn.Existencia("*", "StockAlmacen", "IDAlmacen='" + cbxAlmacen.SelectedValue + "' and IDInsumo='" + IDInsumo + "'") == true)
                    {
                        //AUMENTAMOS STOCK
                        fn.Modificar("StockAlmacen", "Stock=Stock+" + cantidad, "IDAlmacen='" + cbxAlmacen.SelectedValue + "' and IDInsumo='" + IDInsumo + "'");
                    }
                    else
                    {
                        //REGISTRAMOS CON LA CANTIDAD COMPLETA
                        fn.RegistrarOficial("StockAlmacen", "IDInsumo,IDAlmacen,Stock,PermitirControl", "'" + IDInsumo + "','" + cbxAlmacen.SelectedValue + "','" + cantidad + "','0'");
                    }

                    //REGISTRAMOS EL KARDEX
                    fn.Registrar("Kardex", "'" + DateTime.Now.ToShortDateString() + "','COMPRA','" + IDCompra + "','" + cantidad + "','0',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + cbxAlmacen.SelectedValue + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + cbxAlmacen.SelectedValue + "' and IDInsumo='" + IDInsumo + "')");
                }
                //Modificamos el Costo
                fn.Modificar("Insumo", "Costo='" + row.Cells["cPreCompra"].Value.ToString() + "'", "IDInsumo='" + IDInsumo + "'");
            }
            
        }

        private bool validacionGuardar()
        {
            

            //si no hay productos
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("No agregó producto a la compra", ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //SI EL TIPO DE COMPROBANTE ESTA VACIO
            if (cbxTipoComprobante.SelectedValue == null)
            {
                MessageBox.Show("Verificar Tipo de Pago", ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbxAlmacen.SelectedValue == null)
            {
                MessageBox.Show("Verificar Almacen", ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(chbxAumentarStock.Checked == true)
            {
                
                if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" + cbxAlmacen.SelectedValue + "'") == "True")
                {
                    SqlDataReader lector = fn.selectMultiValues("select top(1) * from aperturaAlmacen order by IDApertura desc");
                    while(lector.Read())
                    {
                        DateTime fecha = Convert.ToDateTime(lector["FechaApertura"].ToString());
                        string estado = lector["Estado"].ToString();

                        if (estado == "C")
                        {
                            MessageBox.Show("El Almacen de Venta se Encuentra Cerrado. Abrir para continuar con el Registro de Compra", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lector.Close();
                            return false;
                        }

                        if (fecha != Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                        {
                            DialogResult msj = MessageBox.Show("La fecha de Apertura del Almacen de Venta se Encuentra abierta con la fecha (" + fecha.ToShortDateString() + ") siento diferente a la de Hoy : " + DateTime.Now.ToShortDateString() + ". Si Continua Afectara al Cuadre de Almacen con le Fecha: " + fecha.ToShortDateString() + ". Desea Continuar con el Registro?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                            if (msj == DialogResult.Cancel)
                            {
                                return false;
                            }
                        }
                        
                    }
                    lector.Close();
                }
            }
           
            if(!editar)
            {
                string idProveedor = fn.selectValue("select IDProveedor from proveedor where Numero = '" + txtNumero.Text + "'");

                if(fn.Existencia("*", "Compra" ,"IDProveedor = '"+idProveedor+"' and Serie = '"+txtSerie.Text+"' and Numero = '"+txtCorrelativo.Text+"' and IDTipoComprobante = '"+cbxTipoComprobante.SelectedValue+"'"))
                {
                    MessageBox.Show("La Compra con el proveedor especificado que tiene la serie y numero ya existe","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }
            }


            //SI EL COMPROBANTE ES DIFERENTE DE "SIN COMPROBANTE" TIENE QUE INGRESAR SERIE Y NUMERO
            if (cbxTipoComprobante.Text != "SIN COMPROBANTE")
            {
                if (txtSerie.Text == "")
                {
                    error.SetError(txtSerie, "Debe ingresar serie de comprobante");
                    txtSerie.Focus(); return false;
                }
                if (txtCorrelativo.Text == "")
                {
                    error.SetError(txtCorrelativo, "Debe ingresar numero de comprobante");
                    txtCorrelativo.Focus(); return false;
                }
                if (txtNumero.Text == "")
                {
                    error.SetError(txtNumero, "Debe ingresar numero de identificación proveedor");
                    txtNumero.Focus(); return false;
                }
                if (txtNombre.Text == "")
                {
                    error.SetError(txtNombre, "No cargó el nombre de proveedor o no está registrado ");
                    txtNombre.Focus(); return false;
                }
                if (fn.Existencia("*", "Proveedor", "Numero='" + txtNumero.Text + "'") == false)
                {
                    error.SetError(txtNumero, "El proveedor NO está registrado ");
                    txtNumero.Focus(); return false;
                }
            }

            if (editar == true)
            {
                DialogResult msj = MessageBox.Show("Desea ACTUALIZAR la Compra?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msj == DialogResult.Cancel)
                {
                    return false;
                }
            }
            else
            {
                DialogResult msj = MessageBox.Show("Desea Registar la Compra \nAlmacen: " + cbxAlmacen.Text + " \nTipo De Comprobante: " + cbxTipoComprobante.Text, "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msj == DialogResult.Cancel)
                {
                    return false;
                }
            }
           
            return true;
        }

        private void AumentarCodCompra()
        {
            int codCompra = Convert.ToInt32(fn.select_one_value("IDAyuda", "Ayuda", "Descripcion='Compra'", 0)) + 1;
            fn.Modificar("Ayuda", "IDAyuda='" + codCompra + "'", "Descripcion='Compra'");
        }




        private void dgvDeatalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //    float Total = Convert.ToSingle(lblTotal.Text);
                //    float efectivo = Convert.ToSingle(txtEfectivo.Text);

                //    float cambio = efectivo - Total;
                //    lblCambio.Text = Math.Round(cambio, 2).ToString();

            }
            catch (Exception ex)
            {
                //if (txtEfectivo.Text != "")
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNumero.Text != "")
                {
                    if (fn.Existencia("*", "Proveedor", "Numero='" + txtNumero.Text + "'") == true)
                    {
                        txtNombre.Text = fn.select_one_value("RazonSocial", "Proveedor", "Numero='" + txtNumero.Text + "'", 0);
                        cbxMoneda.Focus();
                    }
                    else
                    {
                        if (txtNumero.TextLength == 11)
                        {

                            FrmBuscarRucAdmin frmRuc = new FrmBuscarRucAdmin();
                            frmRuc.txtruc.Text = txtNumero.Text;
                            frmRuc.ShowDialog();

                            if(frmRuc.registrado == true)
                            {
                                txtNombre.Text = frmRuc.txtrazonsocial.Text;
                                cbxMoneda.Focus();
                            }
                        }
                        else if (txtNumero.TextLength == 8)
                        {
                            FrmBuscarDNIAdmin frmDni = new FrmBuscarDNIAdmin();
                            FrmBuscarDNIAdmin.DNI = txtNumero.Text;
                            frmDni.ShowDialog();

                            if(frmDni.registrado == true)
                            {
                                txtNombre.Text = frmDni.txt_cliente.Text;
                                cbxMoneda.Focus();
                            }
                            
                        }
                    }
                }

            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtcontacto.Focus();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (fn.Existencia("*", "Proveedor", "Numero='" + txtNumero.Text + "'") == false)
                {
                    DialogResult msj = MessageBox.Show("Debe Registrar al Proveedor. Por que no se encuentra en su Base de Datos", ".::San Agustin::.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (msj == DialogResult.OK)
                    {
                        //fn.Registrar("Proveedor", "'" + txtNumero.Text + "','" + txtNombre.Text + "','" + txtTelefono.Text + "','" + txtDireccion.Text + "','"+txtcontacto.Text+"'");
                        MessageBox.Show("Proveedor Registrado", ".::San Agustin::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSerie.Focus();
                    }
                }
            }
        }

        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Guardar();
            }
        }

        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCorrelativo.Focus();
            }
        }

        private void txtnum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumero.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        private void dtpFechaComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpFechaVencimiento.Focus();
            }
        }

        private void dtpFechaVencimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxAlmacen.Focus();
            }
        }

        private void cbxTipoComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            string tipo;
            if (e.KeyCode == Keys.Enter)
            {
                if (fn.Existencia("*", "TipoComprobante", "NombreComprobante='" + cbxTipoComprobante.Text + "'") == true)
                {
                    txtSerie.Focus();
                }

            }
        }

        private void cbxTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoComprobante.Text == "SIN COMPROBANTE")
            {
                txtSerie.Enabled = false;
                txtCorrelativo.Enabled = false;
                lblIGV.Text = "0.00";
                txtBaseGravada.Text = "0.00";
            }
            else
            {
                txtSerie.Enabled = true;
                txtCorrelativo.Enabled = true;
                calcularFacturacion();
                
            }

        }

        private void btnAnulrCompra_Click(object sender, EventArgs e)
        {
            frmObservacionCompra frm = new frmObservacionCompra();
            frm.ShowDialog();
        }

        private void cbxTienda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxTipoComprobante.Focus();
            }
        }

        private void cbxMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMoneda.SelectedIndex == 1)
            {
                txtTipoCambio.Visible = true;
                bool existeTipo = fn.Existencia("*", "TipoCambio", "Fecha = '" + dtpFechaComprobante.Value.ToShortDateString() + "'");

                if (existeTipo == true)
                {
                    txtTipoCambio.Text = fn.selectValue("select TipoCambio from tipocambio where Fecha = '" + dtpFechaComprobante.Value.ToShortDateString() + "'");
                }
                else
                {
                    txtTipoCambio.Text = "";
                    DialogResult msj = MessageBox.Show("Tipo de Cambio con la Fecha " + dtpFechaComprobante.Value.ToShortDateString() + " del comprobante No se Encuentra Registrada. Desea Registrarlo?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (msj == DialogResult.OK)
                    {
                        FrmTipoCambio frm = new FrmTipoCambio();
                        frm.ShowDialog();
                    }

                    return;
                }
            }
            else
            {
                txtTipoCambio.Visible = false;
                txtTipoCambio.Text = "1";
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblImpuesto.Text = fn.selectValue("select Valor from parametro where Parametro = 'IGV'");
            calcularFacturacion();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            calcularFacturacion();
        }

        private void txtOtrosTributos_TextChanged(object sender, EventArgs e)
        {
            calcularFacturacion();
        }

        private void txtISC_TextChanged(object sender, EventArgs e)
        {
            calcularFacturacion();
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calcularFacturacion();
        }

        private void qUITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dgvDetalle.CurrentRow.Index;




            DialogResult msj = MessageBox.Show("Desea Quitar el Producto", ".::SISTEMA::.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (msj == DialogResult.OK)
            {
                dgvDetalle.Rows.Remove(dgvDetalle.Rows[i]);
                calcularFacturacion();
            }

        }

        private void iNAFECTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvDetalle.CurrentRow.Cells["cnAfecto"].Value = false;
            calcularFacturacion();
        }

        private void aFECTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvDetalle.CurrentRow.Cells["cnAfecto"].Value = true;
            calcularFacturacion();
        }

        private void dtpFechaComprobante_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaVencimiento.Value = dtpFechaComprobante.Value;

        }

        private void cbxMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescuento.Focus();
            }
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOtrosTributos.Focus();
            }
        }

        private void txtOtrosTributos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtISC.Focus();
            }
        }

        private void calcularFacturacion()
        {
            double inafecto = 0, afecto = 0, isc = 0, otrosTributos = 0, igv = 0, descuento = 0, total = 0, impuesto;

            
            isc = Convert.ToDouble(fn.remplazarNulo(txtISC.Text));
            otrosTributos = Convert.ToDouble(fn.remplazarNulo(txtOtrosTributos.Text));
            descuento = Convert.ToDouble(fn.remplazarNulo(txtDescuento.Text));
            impuesto = Convert.ToDouble(lblImpuesto.Text);

            //DATOS DEL DETALLE
            foreach (DataGridViewRow rowDetalle in dgvDetalle.Rows)
            {
                double importe = Convert.ToDouble(rowDetalle.Cells["cnImporte"].Value);

                //VERIFICAMOS SI ES AFECTO O INAFECTO
                if (Convert.ToBoolean(rowDetalle.Cells["cnAfecto"].Value) == true)
                {
                    afecto += (importe / (impuesto + 1));
                }
                else
                {
                    inafecto += importe;
                }
            }

           if(chbxConIGV.Checked == false)
            {
                afecto = (afecto * 0.18) + afecto;
            }

            afecto = afecto - (descuento / 1.18);
            
            
            
            igv = ((afecto * impuesto) + (isc * impuesto));

            total = inafecto + afecto + igv + isc + otrosTributos + descuento;

            if(cbxTipoComprobante.Text != "SIN COMPROBANTE")
            {
                txtBaseGravada.Text = afecto.ToString("0.00");
                txtBaseNoGravada.Text = inafecto.ToString("0.00");
                lblIGV.Text = igv.ToString("0.00");
            }

            lblTotal.Text = total.ToString("0.00");
        }

        private void chbxConIGV_CheckedChanged(object sender, EventArgs e)
        {
            calcularFacturacion();
        }

        double total()
        {
            double total = 0;


            return total;
        }
    }
}
