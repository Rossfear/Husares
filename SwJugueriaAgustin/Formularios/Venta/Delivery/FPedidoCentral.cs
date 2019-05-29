using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Facturacion.Pedido;
using SwJugueriaAgustin.Objetos.Venta;
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

namespace SwJugueriaAgustin.Formularios.Venta.Delivery
{
    public partial class FPedidoCentral : Form
    {
        Funciones fn = new Funciones();
        SqlConnection conexion = new SqlConnection(Funciones.preconex);
        public FPedidoCentral()
        {
            InitializeComponent();
        }

        private void FPedidoCentral_Load(object sender, EventArgs e)
        {
            showListPlatos();
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


                fn.CargarCombo("Sucursal", "IDSucursal", "Sucursal", cboSucursal);
                generarcomprobante();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void generarcomprobante()
        {
            try
            {
                SqlDataReader lectorT = fn.selectMultiValues("select Serie,(Numero+1) AS Numero from Talonario where Comprobante = 'COMANDA' and IDSucursal='" + Datos.idSucursal + "'");
                while (lectorT.Read())
                {
                    lblSerieC.Text = lectorT["Serie"].ToString();
                    lblNumeroC.Text = Convert.ToDouble(lectorT["Numero"]).ToString("00000000");
                }
                lectorT.Close();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        private void txtTelefonoBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(txtTelefonoBuscar.Text) == false)
                    {
                        if (fn.Existencia("*", "cliente", "Telefono = '" + txtTelefonoBuscar.Text + "'") == true)
                        {
                            SqlDataReader lectorCliente = fn.selectMultiValues("select * from cliente where Telefono = '" + txtTelefonoBuscar.Text + "'");
                            lectorCliente.Read();
                            txtCodigo.Text = lectorCliente["IDCliente"].ToString();
                            txtCliente.Text = lectorCliente["Nombre"].ToString();
                            txtdireccion.Text = lectorCliente["Direccion"].ToString();
                            txtReferencia.Text = lectorCliente["Referencia"].ToString();
                            lectorCliente.Close();
                        }
                        else if (fn.Existencia("*", "cliente", "Telefono2 = '" + txtTelefonoBuscar.Text + "'") == true)
                        {
                            SqlDataReader lectorCliente = fn.selectMultiValues("select * from cliente where Telefono2 = '" + txtTelefonoBuscar.Text + "'");
                            lectorCliente.Read();
                            txtCodigo.Text = lectorCliente["IDCliente"].ToString();
                            txtCliente.Text = lectorCliente["Nombre"].ToString();
                            txtdireccion.Text = lectorCliente["Direccion"].ToString();
                            txtReferencia.Text = lectorCliente["Referencia"].ToString();
                            lectorCliente.Close();
                        }
                        else
                        {
                            DialogResult msj = MessageBox.Show("El Cliente no se Encuentra Registrado. Desea Registrarlo", "FactuTEd", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (msj == DialogResult.OK)
                            {
                                FrmValidacionDelivery cliente = new FrmValidacionDelivery();
                                cliente.txtTelefono1.Text = txtTelefonoBuscar.Text;
                                cliente.txtTelefonoBuscar.Text = txtTelefonoBuscar.Text;
                                cliente.txtNombres.Focus();
                                cliente.Delivery = true;
                                cliente.ShowDialog();
                                txtCliente.Text = cliente.txtNombres.Text;
                                txtCodigo.Text = cliente.txtIDCliente.Text;
                                txtdireccion.Text = cliente.txtdireccion.Text;
                                txtReferencia.Text = cliente.txtReferencia.Text;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            fn.BuscadorGrid(dgvListaPlatos, "Presentacion", txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgvListaPlatos.Focus();
            }
        }

        private void dgvListaPlatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            agregarPlato();
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

                    dgvPedido.Rows.Add(false, idPresentation, presentacion, frm.txtDescr.Text, combo, cantidad, precio, importe, "", categoria, costo, "");

                    if (combo)
                    {
                        //COMBO
                        SqlDataReader lectorCombo = fn.selectMultiValues("select p2.IDPresentacion,pro.Producto+''+p2.Presentacion as Presentacion,pc.cantidad,p2.Precio  from PresentacionCombo pc  inner join Presentacion p2 on pc.IDPresentacion = p2.IDPresentacion  inner join  Producto pro on p2.IDProducto = pro.IDProducto where pc.IDPresentacionCombo = '" + idPresentation + "'");
                        while (lectorCombo.Read())
                        {
                            string idPresentacionC = lectorCombo["IDPresentacion"].ToString();
                            string presentacionC = lectorCombo["Presentacion"].ToString();
                            int cantidadC = Convert.ToInt16(lectorCombo["Cantidad"]);


                            dgvPedido.Rows.Add(false, idPresentacionC, presentacionC, "", false, (cantidadC * cantidad), "0", "0", "", categoria, costo, idPresentation);
                        }
                        lectorCombo.Close();
                    }

                    calcularTotal();
                    txtBuscar.SelectAll();
                    txtBuscar.Focus();

                    //OcultarCombos();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvListaPlatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agregarPlato();
            }
        }

        void calcularTotal()
        {
            double total = 0;
            foreach (DataGridViewRow rowPedido in dgvPedido.Rows)
            {
                total += Convert.ToDouble(rowPedido.Cells["cnImporte"].Value.ToString());
            }

            txtTotal.Text = total.ToString("0.00");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validar()) return;

            Objetos.Venta.Pedido pedido = asignarDatos();
            if(!guardar(pedido))return;

            limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            dgvPedido.Rows.Clear();
            txtCodigo.Clear();
            txtCliente.Clear();
            txtTelefonoBuscar.Clear();
            txtTotal.Clear();
        }

        private Objetos.Venta.Pedido asignarDatos()
        {
            try
            {
                string IDMozo = fn.ObtenerValor("select IDMozo from Mozo where Nombres = 'DELIVERY' AND IDSucursal = " + cboSucursal.SelectedValue, false);
                string IDMesa = fn.ObtenerValor("SELECT IDMesa FROM Mesa WHERE Mesa = 'DELYVERY' AND IDZona = (SELECT IDZona FROM Zona WHERE Zona = 'DELIVERY' AND IDSucursal = "+ cboSucursal.SelectedValue +")", false);
                Objetos.Venta.Pedido pedido = new Objetos.Venta.Pedido();

                pedido.IDPedido = lblSerieC.Text + "-" + lblNumeroC.Text;
                pedido.Serie = lblSerieC.Text;
                pedido.Numero = lblNumeroC.Text;
                pedido.Hora = DateTime.Now.ToString("HH:mm:ss");
                pedido.IDMesa = Convert.ToInt32(IDMesa);
                pedido.IDMozo = Convert.ToInt16(IDMozo);
                pedido.Total = Convert.ToDecimal(txtTotal.Text);
                pedido.IDCliente = Convert.ToInt32(txtCodigo.Text);
                pedido.Direccion = txtdireccion.Text;
                pedido.Referencia = txtReferencia.Text;
                pedido.Vendido = false;
                pedido.Anulado = false;

                List<PedidoDetalle> lista = new List<PedidoDetalle>(); 
                foreach (DataGridViewRow item in dgvPedido.Rows)
                {
                    PedidoDetalle detalle = new PedidoDetalle();
                    detalle.IDPedido = lblSerieC.Text + "-" + lblNumeroC.Text;
                    detalle.IDPresentacion = Convert.ToInt16(item.Cells["cnCodigo"].Value);
                    detalle.Presentacion = item.Cells["cnPlato"].Value.ToString();
                    detalle.Descripcion = item.Cells["cnDescripcion"].Value.ToString();
                    detalle.Cantidad = Convert.ToInt16(item.Cells["cnCantidad"].Value);
                    detalle.Precio = Convert.ToDecimal(item.Cells["cnPrecio"].Value);
                    detalle.Imprimido = Convert.ToBoolean(item.Cells["cnImprimido"].Value);
                    detalle.Costo = Convert.ToDecimal(item.Cells["cnCosto"].Value);
                    detalle.Vendido = false;
                    detalle.Combo = Convert.ToBoolean(item.Cells["cnCombo"].Value);
                    detalle.IDPresentacionCombo = item.Cells["cnIDPresentacionCombo"].Value.ToString();
                    lista.Add(detalle);
                }

                pedido.Detalle = lista;
                return pedido;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Asignar Datos: " + ex.Message);
                return null;
            }
        }

        private bool guardar(Objetos.Venta.Pedido pedido)
        {
            try
            {
                SqlCommand cmd = fn.procedimientoAlmacenado("Pedido_Argegar");              
                cmd.Parameters.AddWithValue("@IDPedido", pedido.IDPedido);
                cmd.Parameters.AddWithValue("@Serie", pedido.Serie);
                cmd.Parameters.AddWithValue("@Numero", pedido.Numero);
                cmd.Parameters.AddWithValue("@Hora", pedido.Hora);
                cmd.Parameters.AddWithValue("@IDMesa", pedido.IDMesa);
                cmd.Parameters.AddWithValue("@IDMozo", pedido.IDMozo);
                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                cmd.Parameters.AddWithValue("@Vendido", pedido.Vendido);
                cmd.Parameters.AddWithValue("@Anulado", pedido.Anulado);
                cmd.Parameters.AddWithValue("@IDCliente", pedido.IDCliente);
                cmd.Parameters.AddWithValue("@Direccion", pedido.Direccion);
                cmd.Parameters.AddWithValue("@Refencia", pedido.Referencia);
                cmd.ExecuteNonQuery();

                foreach (var item in pedido.Detalle)
                {
                    SqlCommand detalle = fn.procedimientoAlmacenado("PedidoDetalle_Argegar");
                    detalle.Parameters.AddWithValue("@IDPedido", item.IDPedido);
                    detalle.Parameters.AddWithValue("@IDPresentacion", item.IDPresentacion);
                    detalle.Parameters.AddWithValue("@Presentacion", item.Presentacion);
                    detalle.Parameters.AddWithValue("@Descripcion", item.Descripcion);
                    detalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                    detalle.Parameters.AddWithValue("@Precio", item.Precio);
                    detalle.Parameters.AddWithValue("@Imprimido", item.Imprimido);
                    detalle.Parameters.AddWithValue("@Costo", item.Costo);
                    detalle.Parameters.AddWithValue("@Vendido", item.Vendido);
                    detalle.Parameters.AddWithValue("@Combo", item.Combo);
                    detalle.Parameters.AddWithValue("@IDPresentacionCombo", item.IDPresentacionCombo);
                    detalle.ExecuteNonQuery();
                }

                MessageBox.Show("Pedido Realizado", "FactuTed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                generarcomprobante();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar:  " + ex.Message, "FactuTed",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool validar()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Debe buscar al cliente", "FactuTed",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if (dgvPedido.Rows.Count == 0)
            {
                MessageBox.Show("Debe Ingresar plato Pedido", "FactuTed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
