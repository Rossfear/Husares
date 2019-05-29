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
    public partial class FrmSeleccionPedido : Form
    {
        Funciones fn = new Funciones();
        Impresion pt = new Impresion();
        public bool existsOrder, reimprimir = false;
        string IDOrder, printer;
        DateTime fecha = DateTime.Now.Date;
        SqlConnection conexion = new SqlConnection(Funciones.preconex);

        public FrmSeleccionPedido()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += FrmSeleccionPedido_KeyDown;
        }

        private void FrmSeleccionPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();

        }

        private void SeleccionPedido_Load(object sender, EventArgs e)
        {
            try
            {
                if (Datos.conPrecuenta == true)
                {
                    btnPreCuenta.Visible = true;
                }
                else
                {
                    btnPreCuenta.Visible = false;
                }

                if (existsOrder == true)
                {
                    //CARGAR DATA
                    SqlDataReader readerData = fn.selectMultiValues("select p.IDPedido,m.IDMozo,m.Usuario,Serie,Numero from  Pedido p  inner join Mozo m on p.IDMozo = m.IDMozo   where IDMesa = '"+lblMesa.Tag+"' and Vendido='False' and Anulado='False'");
                    while(readerData.Read())
                    {
                        IDOrder = readerData["IDPedido"].ToString();
                        lblMozo.Tag = readerData["IDMozo"].ToString();
                        lblMozo.Text = readerData["Usuario"].ToString();
                        lblSerieC.Text = readerData["Serie"].ToString();
                        lblNumeroC.Text = readerData["Numero"].ToString();
                    }
                    readerData.Close();

                    //CARGAR DETAIL
                    DataTable tabla = new DataTable();
                    SqlCommand cmd = fn.procedimientoAlmacenado("Venta_PedidoDetalle_Listar");
                    cmd.Parameters.AddWithValue("@IDPedido",IDOrder);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tabla);


                    foreach (DataRow reader in tabla.Rows)
                    {
                        bool imprimido = Convert.ToBoolean(reader["Imprimido"].ToString());
                        string code = reader["IDPresentacion"].ToString();
                        string categoria = reader["Categoria"].ToString();
                        string presentacion = reader["Presentacion"].ToString();
                        string descripcion = reader["Descripcion"].ToString();
                        string Quantity = reader["Cantidad"].ToString();
                        string price = reader["Precio"].ToString();
                        string idDetallePedido = reader["IDDetallePedido"].ToString();
                        string amount = Math.Round(Convert.ToDecimal(reader["Importe"].ToString()), 2).ToString();
                        string costo = reader["Costo"].ToString();
                        bool combo = Convert.ToBoolean(reader["Combo"]);
                        string idPresentacionCombo = reader["idPresentacionCombo"].ToString();

                        dgvPedido.Rows.Add(imprimido, code, presentacion, descripcion, combo, Quantity, price, amount, idDetallePedido, categoria, costo, idPresentacionCombo); 
                    }


                    OcultarCombos();

                    gbxAnulacion.Enabled = true;
                    btnAnularPedido.Enabled = true;
                    btnCargarMozo.Enabled = false;
                    btnPreCuenta.Enabled = true;

                    if (Datos.mozo != true)
                    {
                        btnFacturar.Visible = true;
                    }
                }
                else
                {
                    SqlDataReader lectorT = fn.selectMultiValues("select Serie,(Numero+1) AS Numero from Talonario where Comprobante = 'COMANDA' and IDSucursal='" + Datos.idSucursal + "'");
                    while(lectorT.Read())
                    {
                        lblSerieC.Text = lectorT["Serie"].ToString();
                        lblNumeroC.Text = Convert.ToDouble(lectorT["Numero"]).ToString("00000000");
                    }
                    lectorT.Close();
                    
                    //SI NO EXISTE PEDIDO
                    gbxAnulacion.Enabled = false;
                    btnAnularPedido.Enabled = false;
                    btnCargarMozo.Enabled = true;
                    btnPreCuenta.Enabled = false;

                    if (Datos.mozo == false)
                    {
                        btnFacturar.Visible = true;

                        string condicion;
                        if (lblMesa.Text == "DELYVERY")
                            condicion = "select * from mozo WHERE CajaDelivery = 1 and IDSucursal = '" + Datos.idSucursal + "' and Habilitado='True'";
                        else
                            condicion = "select * from mozo WHERE CajaSalon = 1 and IDSucursal = '" + Datos.idSucursal + "' and Habilitado='True'";

                        SqlDataReader lector = fn.selectMultiValues(condicion);
                        while (lector.Read())
                        {
                            lblMozo.Text = lector["Usuario"].ToString();
                            lblMozo.Tag = lector["IDMozo"].ToString();
                        }
                        lector.Close();
                    }
                }

                showListPlatos();
                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void addItem()
        {
            try
            {
                frmAddCantidad frm = new frmAddCantidad();
                frm.ShowDialog();
                if (frm.Cancelado == false)
                {
                    int cantidad = Convert.ToInt16(frm.txtCantidad.Text);
                    string idPresentation = dgvListaPlatos.CurrentRow.Cells["IDPresentacion"].Value.ToString();
                    string categoria = dgvListaPlatos.CurrentRow.Cells["Categoria"].Value.ToString();
                    string costo = dgvListaPlatos.CurrentRow.Cells["Costo"].Value.ToString();
                    string presentacion = dgvListaPlatos.CurrentRow.Cells["Presentacion"].Value.ToString();
                    double precio = Convert.ToDouble(dgvListaPlatos.CurrentRow.Cells["Precio"].Value.ToString());
                    bool combo = Convert.ToBoolean(dgvListaPlatos.CurrentRow.Cells["Combo"].Value.ToString());
                    double importe = precio * cantidad;

                    dgvPedido.Rows.Add(false, idPresentation, presentacion, frm.txtDescr.Text, combo, cantidad, precio, importe, "", categoria, costo,"");

                    if(combo)
                    {
                        //COMBO
                        SqlDataReader lectorCombo = fn.selectMultiValues("select p2.IDPresentacion,pro.Producto+''+p2.Presentacion as Presentacion,pc.cantidad,p2.Precio  from PresentacionCombo pc  inner join Presentacion p2 on pc.IDPresentacion = p2.IDPresentacion  inner join  Producto pro on p2.IDProducto = pro.IDProducto where pc.IDPresentacionCombo = '"+idPresentation+"'");
                        while (lectorCombo.Read())
                        {
                            string idPresentacionC = lectorCombo["IDPresentacion"].ToString();
                            string presentacionC = lectorCombo["Presentacion"].ToString();
                            int cantidadC = Convert.ToInt16(lectorCombo["Cantidad"]);


                            dgvPedido.Rows.Add(false, idPresentacionC, presentacionC, "", false, (cantidadC * cantidad), "0", "0", "", categoria, costo,idPresentation);
                        }
                        lectorCombo.Close();
                    }

                    calcularTotal();
                    txtBuscar.SelectAll();
                    txtBuscar.Focus();

                    OcultarCombos();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void OcultarCombos()
        {
            foreach (DataGridViewRow fila in dgvPedido.Rows)
            {
                string idPedido = fila.Cells["cnIDPresentacionCombo"].Value.ToString();

                if(!string.IsNullOrWhiteSpace(idPedido))
                {
                    fila.Visible = false;
                }
            }
        }

        void calcularTotal()
        {
            double total = 0;
            foreach (DataGridViewRow rowPedido in dgvPedido.Rows)
            {
                total += Convert.ToDouble(rowPedido.Cells["cnImporte"].Value.ToString());
            }

            lblTotal.Text = total.ToString("0.00");
        }
        private bool validationAddItem()
        {

            if (Convert.ToBoolean(dgvListaPlatos.CurrentRow.Cells["Combo"].Value))
            {
                string idPresentacion = dgvListaPlatos.CurrentRow.Cells["IDPresentacion"].Value.ToString();

                foreach (DataGridViewRow fila in dgvPedido.Rows)
                {
                    string idPresentacionCombo = fila.Cells["cnIDPresentacionCombo"].Value.ToString();

                    if (idPresentacion == idPresentacionCombo)
                    {
                        MessageBox.Show("La Presentacion ya se encuentra especificada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            if (dgvListaPlatos.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione Un Plato", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void dgvPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSolicitarPedido_Click(object sender, EventArgs e)
        {
            //VALIDATION
            if (validationSave() == false)
            {
                return;
            }

            if (existsOrder == true)
            {
                //UPDATE ORDER
                UpdateOrder();
            }
            else
            {
                //SAVE ORDER
                saveOrder();
            }

            //print
            print();

            //END SAVE
            endSave();
        }

        private void print()
        {
            try
            {
                if (Datos.cantidadComanda == 0) return;

                bool existsBar = false, existsCocina = false, existsHorno = false;

                for (int i = 0; i < dgvPedido.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvPedido.Rows[i].Cells["cnImprimido"].Value) == false)
                    {
                        string idPresentation = dgvPedido.Rows[i].Cells["cnCodigo"].Value.ToString();

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
                    pdBar.PrinterSettings.PrinterName = Datos.impresoraBar;

                    if (Datos.cantidadComanda == 1)
                    {
                        pdBar.Print();
                    }
                    else
                    {
                        pdBar.Print();
                        pdBar.Print();
                    }
                }

                if (existsCocina == true)
                {
                    pdCocina.PrinterSettings.PrinterName = Datos.impresoraCocina;

                    if (Datos.cantidadComanda == 1)
                    {
                        pdCocina.Print();
                    }
                    else
                    {
                        pdCocina.Print();
                        pdCocina.Print();
                    }
                }

                if (existsHorno == true)
                {
                    pdHorno.PrinterSettings.PrinterName = Datos.impresoraHorno;

                    if (Datos.cantidadComanda == 1)
                    {
                        pdHorno.Print();
                    }
                    else
                    {
                        pdHorno.Print();
                        pdHorno.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateOrder()
        {
            //Delete
            fn.Eliminar("PedidoDetalle", "IDPedido = '" + IDOrder + "'");

            registryDetail(IDOrder);
        }

        private void endSave()
        {
            this.Close();
        }

        private void saveOrder()
        {
            string date = DateTime.Now.ToShortDateString();
            string idPedido = lblSerieC.Text + "-" + lblNumeroC.Text;
            DateTime time = DateTime.Now;

            //REGISTRY ORDER
            fn.RegistrarOficial("Pedido", "IDPedido,Serie,Numero,Fecha,Hora,IDMesa,IDMozo,Vendido,Anulado",
                "'"+idPedido+"','"+lblSerieC.Text+"','"+lblNumeroC.Text+"','" + date + "','" + time.ToString("HH:mm:ss") + "','" + lblMesa.Tag + "','" + lblMozo.Tag + "','False','False'");

            //REGISTRY DETAIL
            registryDetail(idPedido);           

            ////TALONARIO
            //fn.Modificar("Talonario", "Numero=Numero+1", "Serie='"+lblSerieC.Text+"'");
        }

        private void registryDetail(string vidpedido)
        {
            //REGISTRY DETAIL ORDER
            for (int i = 0; i < dgvPedido.Rows.Count; i++)
            {
                string idPresentacion = dgvPedido.Rows[i].Cells["cnCodigo"].Value.ToString();
                string quantity = dgvPedido.Rows[i].Cells["cnCantidad"].Value.ToString();
                string presentacion = dgvPedido.Rows[i].Cells["cnPlato"].Value.ToString();
                string descripcion = dgvPedido.Rows[i].Cells["cnDescripcion"].Value.ToString();
                string price = dgvPedido.Rows[i].Cells["cnPrecio"].Value.ToString();
                string cost = dgvPedido.Rows[i].Cells["cnCosto"].Value.ToString();
                bool combo = Convert.ToBoolean(dgvPedido.Rows[i].Cells["cnCombo"].Value);
                string idPresentacionCombo = dgvPedido.Rows[i].Cells["cnIDPresentacionCombo"].Value.ToString();

                fn.RegistrarOficial("PedidoDetalle", "IDPedido,IDPresentacion,Presentacion,Descripcion,Cantidad,Precio,Imprimido,Costo,Vendido,Combo,IDPresentacionCombo",
                    "'" + vidpedido + "','" + idPresentacion + "','" + presentacion + "','" + descripcion   + "','" + quantity + "','" + price + "','True','" + cost + "','False','"+combo+"','"+idPresentacionCombo+"'");
            }
        }

        private bool validationSave()
        {
            if(existsOrder == false)
            {
                if (fn.Existencia("*", "Pedido", "IDPedido='" + lblSerieC.Text+"-"+lblNumeroC.Text + "'") == true)
                {
                    fn.Modificar("Talonario", "Numero=(select MAX(numero) from Pedido WHERE len(numero) = 8)", "Serie='"+lblSerieC.Text+"'");
                    lblNumeroC.Text = Convert.ToDouble(fn.selectValue("select (Numero+1) from Talonario where Serie = '"+lblSerieC.Text+"'")).ToString("00000000");
                }
            }

            if (string.IsNullOrEmpty(lblMozo.Text) == true)
            {
                MessageBox.Show("Especifique Mozo", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvPedido.Rows.Count == 0)
            {
                MessageBox.Show("Especifique Productos al Pedido", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAnularPedido_Click(object sender, EventArgs e)
        {
            FrmCargarMozo frm = new FrmCargarMozo();
            frm.reimprimir = true;
            frm.ShowDialog();

            if (FrmCargarMozo.cancel == false)
            {
                if (string.IsNullOrEmpty(txtMotivoAnulacion.Text) == true)
                {
                    MessageBox.Show("Especifique motivo de la Anulación.", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult msj = MessageBox.Show("Desea Anular El Pedido?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (msj == DialogResult.OK)
                {
                    //fn.Modificar("Pedido", "Anulado='True'", "IDPedido='" + IDOrder + "'");
                    //fn.Modificar("Mesa", "Estado='LIBRE'", "IDMesa='" + lblMesa.Tag + "'");
                    fn.RegistrarOficial("PedidoAnulacion", "Fecha,Hora,IDPedido,Motivo,IDMozo", "'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + IDOrder + "','" + txtMotivoAnulacion.Text + "','" + lblMozo.Tag + "'");
                    MessageBox.Show("Pedido Anulado y Mesa Liberada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }


        }
        private void pdBar_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            pt.comandaOficial("BAR",e, lblMesa.Text, lblMozo.Text, lblSerieC.Text + "-" + lblNumeroC.Text, dgvPedido, reimprimir,false);            
        }

        private void nOIMPRIMIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCargarMozo frm = new FrmCargarMozo();
            frm.reimprimir = true;
            frm.ShowDialog();

            if (FrmCargarMozo.cancel == false)
            {
                dgvPedido.CurrentRow.Cells["cnImprimido"].Value = false;
                reimprimir = true;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agregarPlato();
            }
        }

        void agregarPlato()
        {
            //VALIDATION
            if (validationAddItem() == false)
            {
                return;
            }

            //ADD ITEM
            addItem();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgvListaPlatos.Focus();
            }
        }

        private void showListPlatos()
        {
            try
            {
                DataTable tablaPresentacion = new DataTable();

                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_mostrarPlatos", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@productoPresentacion", SqlDbType.VarChar, 100).Value = txtBuscar.Text;
                da.SelectCommand.Parameters.Add("@idSucursal", SqlDbType.Int).Value = Datos.idSucursal;
                da.Fill(tablaPresentacion);
                dgvListaPlatos.DataSource = tablaPresentacion;
                conexion.Close();


                dgvListaPlatos.Columns["IDPresentacion"].Visible = false;
                dgvListaPlatos.Columns["Categoria"].Visible = false;
                dgvListaPlatos.Columns["Costo"].Visible = false;
                dgvListaPlatos.Columns["Presentacion"].Width = 300;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblMesa.Text != "DELYVERY")
                {
                    SqlDataReader lectorCaja = fn.selectMultiValues("select top(1) * from Caja where TIPO = 'VENTA SALON' and IDSucursal = '"+Datos.idSucursal+"' order by ID Desc");
                    lectorCaja.Read();
                    string ultimaFechaCaja = lectorCaja["FECHA_HORA"].ToString();
                    string idCaja = lectorCaja["ID"].ToString();
                    string estado = lectorCaja["Estado"].ToString();
                    lectorCaja.Close();

                    if (estado == "CERRADA")
                    {
                        MessageBox.Show("ABRIR CAJA", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (fecha != Convert.ToDateTime(ultimaFechaCaja))
                    {
                        DialogResult msj = MessageBox.Show("Seguro que Desea Vender con la Caja del Dia " + Convert.ToDateTime(ultimaFechaCaja).ToShortDateString() + " Estando Hoy con Diferente Fecha: " + fecha.ToShortDateString(), "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


                        if (msj == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    SqlDataReader lectorCaja = fn.selectMultiValues("select top(1) ID,cast(FECHA_HORA as Date) as FechaCaja,ESTADO from caja where TIPO = 'DELIVERY' and IDSucursal = '"+Datos.idSucursal+"' order by ID Desc");
                    lectorCaja.Read();
                    string ultimaFechaCaja = lectorCaja["FechaCaja"].ToString();
                    string idCaja = lectorCaja["ID"].ToString();
                    string estado = lectorCaja["Estado"].ToString();
                    lectorCaja.Close();

                    if (estado == "CERRADA")
                    {
                        MessageBox.Show("ABRIR CAJA", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (fecha != Convert.ToDateTime(ultimaFechaCaja))
                    {
                        DialogResult msj = MessageBox.Show("Seguro que Desea Vender con la Caja del Dia " + Convert.ToDateTime(ultimaFechaCaja).ToShortDateString() + " Estando Hoy con Diferente Fecha: " + fecha.ToShortDateString(), "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


                        if (msj == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }


                if (validationFacturar() == false)
                {
                    return;
                }


                if (lblMesa.Text == "DELYVERY")
                {
                    showfrmVentaDelivery();
                }
                else
                {
                    ShowfrmVentaSalon();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showfrmVentaDelivery()
        {
            FrmFacturaDelivery frm = new FrmFacturaDelivery();
            frm.idCliente = lblCodCliente.Text;
            //Labe's
            frm.lblMesa.Text = lblMesa.Text;
            frm.lblMesa.Tag = lblMesa.Tag;
            frm.lblMozo.Text = lblMozo.Text;
            frm.lblMozo.Tag = lblMozo.Tag;
            frm.lblComanda.Text = lblSerieC.Text+"-"+lblNumeroC.Text;

            //Grid
            for (int i = 0; i < dgvPedido.Rows.Count; i++)
            {
                string idPresetation = dgvPedido.Rows[i].Cells["cnCodigo"].Value.ToString();
                string Plato = dgvPedido.Rows[i].Cells["cnPlato"].Value.ToString();
                string descripcion = dgvPedido.Rows[i].Cells["cnDescripcion"].Value.ToString();
                string quantity = dgvPedido.Rows[i].Cells["cnCantidad"].Value.ToString();
                string price = dgvPedido.Rows[i].Cells["cnPrecio"].Value.ToString();
                string amount = dgvPedido.Rows[i].Cells["cnImporte"].Value.ToString();
                string codPedido = dgvPedido.Rows[i].Cells["cnCodPedido"].Value.ToString();
                string categoria = dgvPedido.Rows[i].Cells["cnCategoria"].Value.ToString();
                string costo = dgvPedido.Rows[i].Cells["cnCosto"].Value.ToString();
                bool combo = Convert.ToBoolean(dgvPedido.Rows[i].Cells["cnCombo"].Value);
                string idPresentacionCombo = dgvPedido.Rows[i].Cells["cnIDPresentacionCombo"].Value.ToString();

                frm.dgvPedido.Rows.Add(true, idPresetation, Plato, descripcion,combo, quantity, price, amount, codPedido, categoria, costo,idPresentacionCombo);
            }

            frm.existsOrder = existsOrder;
            frm.IDRequest = IDOrder;

            frm.ShowDialog();

            if (frm.facturado == true)
            {
                this.Close();
            }
        }

        private void ShowfrmVentaSalon()
        {
            FrmFacturarDirecto frm = new FrmFacturarDirecto();

            //Labe's
            frm.lblMesa.Text = lblMesa.Text;
            frm.lblMesa.Tag = lblMesa.Tag;
            frm.lblMozo.Text = lblMozo.Text;
            frm.lblMozo.Tag = lblMozo.Tag;
            frm.lblComanda.Text = lblSerieC.Text+"-"+lblNumeroC.Text;

            string concatenacion = ":";
            bool especificado = false;
            
            //Operacion No Gratuita
            for(int i=0;i<dgvPedido.Rows.Count; i++ )
            {
                double price = Convert.ToDouble(dgvPedido.Rows[i].Cells["cnPrecio"].Value.ToString());
                string Plato = dgvPedido.Rows[i].Cells["cnPlato"].Value.ToString();
                bool combo = Convert.ToBoolean(dgvPedido.Rows[i].Cells["cnCombo"].Value);
                string IDPresentacionCombo = dgvPedido.Rows[i].Cells["cnIDPresentacionCombo"].Value.ToString();

                if (price == 0 && string.IsNullOrWhiteSpace(IDPresentacionCombo))
                {
                    concatenacion += " + " + Plato;
                }
            }

            //Grid
            for (int i = 0; i < dgvPedido.Rows.Count; i++)
            {
                double price = Convert.ToDouble(dgvPedido.Rows[i].Cells["cnPrecio"].Value);
                string idPresetation = dgvPedido.Rows[i].Cells["cnCodigo"].Value.ToString();
                bool combo = Convert.ToBoolean(dgvPedido.Rows[i].Cells["cnCombo"].Value);
                string Plato = dgvPedido.Rows[i].Cells["cnPlato"].Value.ToString();
                string IDPresentacionCombo = dgvPedido.Rows[i].Cells["cnIDPresentacionCombo"].Value.ToString();

                string descripcion;
                if (price > 0 && especificado == false)
                {
                    descripcion = dgvPedido.Rows[i].Cells["cnDescripcion"].Value.ToString() +""+ concatenacion;
                    especificado = true;
                }
                else
                {
                    descripcion = dgvPedido.Rows[i].Cells["cnDescripcion"].Value.ToString();
                }
                
                
                string quantity = dgvPedido.Rows[i].Cells["cnCantidad"].Value.ToString();
                string amount = dgvPedido.Rows[i].Cells["cnImporte"].Value.ToString();
                string codPedido = dgvPedido.Rows[i].Cells["cnCodPedido"].Value.ToString();
                string categoria = dgvPedido.Rows[i].Cells["cnCategoria"].Value.ToString();
                string costo = dgvPedido.Rows[i].Cells["cnCosto"].Value.ToString();
                
                

                frm.dgvPedido.Rows.Add(true, idPresetation, Plato, descripcion,combo, quantity, price, amount, codPedido, categoria, costo,IDPresentacionCombo);
            }

            frm.existsOrder = existsOrder;
            frm.IDRequest = IDOrder;

            frm.ShowDialog();

            if (frm.facturado == true)
            {
                this.Close();
            }
        }

        private bool validationFacturar()
        {
            if (string.IsNullOrEmpty(lblMozo.Text) == true)
            {
                MessageBox.Show("Especifique Mozo", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvPedido.Rows.Count == 0)
            {
                MessageBox.Show("Especifique Platos al Pedido", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCargarMozo_Click_1(object sender, EventArgs e)
        {
            FrmCargarMozo frm = new FrmCargarMozo();
            frm.ShowDialog();

            if (FrmCargarMozo.cancel == false)
            {
                lblMozo.Text = frm.cboMozo.Text;
                lblMozo.Tag = frm.cboMozo.SelectedValue;
                txtBuscar.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnPreCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                //ppdView.Document = pdPreCuenta;
                //ppdView.ShowDialog();
                pdPreCuenta.PrinterSettings.PrinterName = printer;
                pdPreCuenta.Print();
                fn.Modificar("Mesa", "Estado = 'PRECUENTA'", "IDMesa='" + lblMesa.Tag + "'");
                MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impresora Pre Cuenta: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            //MUESTRA LA LISTA DE LOS PLATOS
            fn.BuscadorGrid(dgvListaPlatos, "Presentacion",txtBuscar.Text);
        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            ppdView.Document = pdPreCuenta;
            ppdView.ShowDialog();
            try
            {
                bool existsBar = false, existsCocina = false, existsHorno = false;

                for (int i = 0; i < dgvPedido.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvPedido.Rows[i].Cells["cnImprimido"].Value) == false)
                    {
                        string idPresentation = dgvPedido.Rows[i].Cells["cnCodigo"].Value.ToString();

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

                       if(existsCocina == true && existsBar == true && existsHorno == true)
                        {
                            break;
                        }
                    }
                }

                if (existsBar == true)
                {
                    ppdView.Document = pdBar;
                    ppdView.ShowDialog();
                }

                if (existsCocina == true)
                {
                    ppdView.Document = pdCocina;
                    ppdView.ShowDialog();

                }
                if (existsHorno == true)
                {
                    ppdView.Document = pdHorno;
                    ppdView.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void qUITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row2 in dgvPedido.SelectedRows)
                {
                    if (string.IsNullOrWhiteSpace(row2.Cells["cnCodPedido"].Value.ToString()) == true)
                    {
                        DialogResult result = MessageBox.Show("Desea Quitar el Plato de la Lista", "FactuTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            bool combo = Convert.ToBoolean(dgvPedido.CurrentRow.Cells["cnCombo"].Value);

                            if (combo)
                            {
                                string idPresentacion = dgvPedido.CurrentRow.Cells["cnCodigo"].Value.ToString();

                                for (int i = 0; i < dgvPedido.Rows.Count; i++)
                                {
                                    if (dgvPedido.Rows[i].Cells["cnIDPresentacionCombo"].Value.ToString() == idPresentacion)
                                    {
                                        dgvPedido.Rows.Remove(dgvPedido.Rows[i]);
                                        i--;
                                    }
                                }
                            }
                            dgvPedido.Rows.Remove(row2);
                        }
                    }
                    else
                    {

                        DialogResult result = MessageBox.Show("Desea Quitar el Plato de la Lista", "FactuTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        

                        if(result == DialogResult.Yes)
                        {
                            FrmCargarMozo frm = new FrmCargarMozo();
                            frm.reimprimir = true;
                            frm.ShowDialog();

                            if (FrmCargarMozo.cancel == false)
                            {
                                if (!row2.IsNewRow)
                                {
                                    string codPedido = dgvPedido.CurrentRow.Cells["cnCodPedido"].Value.ToString();
                                    fn.Eliminar("PedidoDetalle", "IDDetallePedido='" + codPedido + "'");

                                    bool combo = Convert.ToBoolean(dgvPedido.CurrentRow.Cells["cnCombo"].Value);

                                    if (combo)
                                    {
                                        string idPresentacion = dgvPedido.CurrentRow.Cells["cnCodigo"].Value.ToString();

                                        for (int i = 0; i < dgvPedido.Rows.Count; i++)
                                        {
                                            if (dgvPedido.Rows[i].Cells["cnIDPresentacionCombo"].Value.ToString() == idPresentacion)
                                            {
                                                dgvPedido.Rows.Remove(dgvPedido.Rows[i]);
                                                i--;
                                            }
                                        }


                                        fn.Eliminar("PedidoDetalle", "IDPresentacionCombo = '" + idPresentacion + "'");
                                    }


                                    dgvPedido.Rows.Remove(row2);
                                }
                            }

                        }
                        
                    }
                }

                calcularTotal();
            }
            catch (Exception ex)
            {

            }
        }

        private void pdPreCuenta_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            pt.PreCuenta(e,lblMesa.Text,lblMozo.Text,lblSerieC.Text+"-"+lblNumeroC.Text,dgvPedido,lblTotal.Text);
        }

        private void btnPreCuenta_Click_1(object sender, EventArgs e)
        {
            pdPreCuenta.Print();
            fn.Modificar("Mesa", "Estado = 'PRECUENTA'", "IDMesa='" + lblMesa.Tag + "'");
            this.Close();
        }

        private void dgvListaPlatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            agregarPlato();
        }

        private void dgvPedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvPedido.Columns["cnCantidad"].Index && e.RowIndex >= 0)
            {
                double precio = Convert.ToDouble(dgvPedido.CurrentRow.Cells["cnPrecio"].Value);
                byte cantida = Convert.ToByte(dgvPedido.CurrentRow.Cells["cnCantidad"].Value);
                double importe = precio * cantida;

                dgvPedido.CurrentRow.Cells["cnImporte"].Value = importe;


                //if (Convert.ToBoolean(dgvPedido.CurrentRow.Cells["cnCombo"].Value) == true)
                //{
                //    string idPresentacionCombo = dgvPedido.CurrentRow.Cells["cnCodigo"].Value.ToString();

                //    foreach (DataGridViewRow row in dgvPedido.Rows)
                //    {
                //        if (row.Cells["cnIDPresentacionCombo"].Value.ToString() == idPresentacionCombo)
                //        {
                //            byte cantidadActualCombo = Convert.ToByte(row.Cells["cnCantidad"].Value);
                //            int cantidadCombo = cantidadActualCombo / cantida;
                //            row.Cells["cnCantidad"].Value = (cantida * cantidadCombo);
                //        }
                //    }
                //}

                calcularTotal();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            float precio = Convert.ToSingle(dgvPedido.CurrentRow.Cells["cnPrecio"].Value);
            byte cantidadActual = Convert.ToByte(dgvPedido.CurrentRow.Cells["cnCantidad"].Value);
            int cantidadNuevo = cantidadActual + 1;

            float nuevoImporte = precio * cantidadNuevo;

            dgvPedido.CurrentRow.Cells["cnCantidad"].Value = cantidadNuevo;
            dgvPedido.CurrentRow.Cells["cnImporte"].Value = nuevoImporte;

            if (Convert.ToBoolean(dgvPedido.CurrentRow.Cells["cnCombo"].Value) == true)
            {
                string idPresentacionCombo = dgvPedido.CurrentRow.Cells["cnCodigo"].Value.ToString();

                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    if (row.Cells["cnIDPresentacionCombo"].Value.ToString() == idPresentacionCombo)
                    {
                        byte cantidadActualCombo = Convert.ToByte(row.Cells["cnCantidad"].Value);
                        int cantidadCombo = cantidadActualCombo / cantidadActual;
                        row.Cells["cnCantidad"].Value = (cantidadNuevo * cantidadCombo);
                    }
                }
            }


            calcularTotal();
        }

        private void pdHorno_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            pt.comandaOficial("HORNO", e, lblMesa.Text, lblMozo.Text, lblSerieC.Text + "-" + lblNumeroC.Text, dgvPedido, reimprimir, false);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                //DATOS
                float precio = Convert.ToSingle(dgvPedido.CurrentRow.Cells["cnPrecio"].Value);
                byte cantidadActual = Convert.ToByte(dgvPedido.CurrentRow.Cells["cnCantidad"].Value);
                bool combo = Convert.ToBoolean(dgvPedido.CurrentRow.Cells["cnCombo"].Value);

                //NUEVOS DATOS
                int cantidadNuevo = cantidadActual - 1;

                if (cantidadNuevo == 0)
                {
                    qUITARToolStripMenuItem_Click(sender,e);
                    return;
                }

                float nuevoImporte = precio * cantidadNuevo;

                if (combo == true)
                {
                    //REDUCIMOS CANTIDAD
                    string idPresentacionCombo = dgvPedido.CurrentRow.Cells["cnCodigo"].Value.ToString();

                    foreach (DataGridViewRow row in dgvPedido.Rows)
                    {
                        if (row.Cells["cnIDPresentacionCombo"].Value.ToString() == idPresentacionCombo)
                        {
                            byte cantidadActualCombo = Convert.ToByte(row.Cells["cnCantidad"].Value);
                            int cantidadCombo = cantidadActualCombo / cantidadActual;
                            row.Cells["cnCantidad"].Value = cantidadActualCombo - cantidadCombo;
                        }
                    }
                }

                if (cantidadNuevo > 0)
                {
                    dgvPedido.CurrentRow.Cells["cnCantidad"].Value = cantidadNuevo;
                    dgvPedido.CurrentRow.Cells["cnImporte"].Value = nuevoImporte;
                }

                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }        
        private void pdCocina_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            pt.comandaOficial("COCINA",e,lblMesa.Text,lblMozo.Text,lblSerieC.Text+"-"+lblNumeroC.Text,dgvPedido,reimprimir,false);
        }
    }
}
