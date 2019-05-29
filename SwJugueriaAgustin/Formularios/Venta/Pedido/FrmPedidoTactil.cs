using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Operaciones;
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

namespace SwJugueriaAgustin.Formularios.Venta.Pedido
{
    public partial class FrmPedidoTactil : Form
    {
        Funciones fn = new Funciones();
        public bool existsOrder, reimprimir = false;
        string IDOrder, printer;
        Impresion pt = new Impresion();
        DateTime fecha = DateTime.Now.Date;
        frmAddCantidad frmCantidad = new frmAddCantidad();
        FrmCargarMozo frmMozo = new FrmCargarMozo();

        SqlConnection conexion = new SqlConnection(Funciones.preconex);
        public FrmPedidoTactil()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnularPedido_Click(object sender, EventArgs e)
        {
            frmMozo.txtPass.Clear();
            frmMozo.reimprimir = true;
            frmMozo.ShowDialog();

            if (FrmCargarMozo.cancel == false)
            {
                DialogResult msj = MessageBox.Show("Desea Anular El Pedido?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (msj == DialogResult.OK)
                {
                    fn.Modificar("Pedido", "Anulado='True'", "IDPedido='" + IDOrder + "'");
                    fn.Modificar("Mesa", "Estado='LIBRE'", "IDMesa='" + lblMesa.Tag + "'");
                    MessageBox.Show("Pedido Anulado y Mesa Liberada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

        }

        private void FrmPedidoTactil_Load(object sender, EventArgs e)
        {
            cargarCategoria();

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
                    SqlDataReader readerData = fn.selectMultiValues("select p.IDPedido,m.IDMozo,m.Usuario,Serie,Numero from  Pedido p  inner join Mozo m on p.IDMozo = m.IDMozo   where IDMesa = '" + lblMesa.Tag + "' and Vendido='False' and Anulado='False'");
                    while (readerData.Read())
                    {
                        IDOrder = readerData["IDPedido"].ToString();
                        lblMozo.Tag = readerData["IDMozo"].ToString();
                        lblMozo.Text = readerData["Usuario"].ToString();
                        lblSerieC.Text = readerData["Serie"].ToString();
                        lblNumeroC.Text = readerData["Numero"].ToString();
                    }
                    readerData.Close();

                    //CARGAR DETAIL
                    SqlDataReader reader = fn.selectMultiValues("select isnull(pd.Combo,0) as Combo,pd.IDDetallePedido,pd.Costo,c.Categoria,pd.Imprimido,pd.IDPresentacion,pd.Presentacion,pd.Descripcion,pd.Cantidad,pr.Precio,(pd.Cantidad * pr.Precio) as importe from PedidoDetalle pd inner join Presentacion pr on pd.IDPresentacion = pr.IDPresentacion inner join Producto pro on pr.IDProducto = pro.IDProducto inner join SubCategoria sc on pro.IDSubcategoria = sc.IDSubCategoria inner join Categoria c on sc.IDCategoria = c.IDCategoria where IDPedido = '" + IDOrder + "' and pd.Vendido = 'False'");
                    while (reader.Read())
                    {
                        bool imprimido = Convert.ToBoolean(reader["Imprimido"].ToString());
                        string code = reader["IDPresentacion"].ToString();
                        string categoria = reader["Categoria"].ToString();
                        string presentacion = reader["Presentacion"].ToString();
                        string descripcion = reader["Descripcion"].ToString();
                        bool combo = Convert.ToBoolean(reader["Combo"]);
                        string Quantity = reader["Cantidad"].ToString();
                        string price = reader["Precio"].ToString();
                        string idDetallePedido = reader["IDDetallePedido"].ToString();
                        string amount = Math.Round(Convert.ToDecimal(reader["Importe"].ToString()), 2).ToString();
                        string costo = reader["Costo"].ToString();

                        dgvPedido.Rows.Add(imprimido, code, presentacion, descripcion,combo, Quantity, price, amount, idDetallePedido, categoria, costo);
                    }
                    reader.Close();

                    btnAnularPedido.Enabled = true;
                    btnCargarMozo.Enabled = false;
                    btnPreCuenta.Enabled = true;

                    
                }
                else
                {
                    SqlDataReader lectorT = fn.selectMultiValues("select Serie,(Numero+1) AS Numero from Talonario where Comprobante = 'COMANDA' and IDSucursal='" + Datos.idSucursal + "'");
                    while (lectorT.Read())
                    {
                        lblSerieC.Text = lectorT["Serie"].ToString();
                        lblNumeroC.Text = Convert.ToDouble(lectorT["Numero"]).ToString("00000000");
                    }
                    lectorT.Close();

                    
                    btnAnularPedido.Enabled = false;
                    btnCargarMozo.Enabled = true;
                    btnPreCuenta.Enabled = false;

                    if (Datos.mozo == false)
                    {
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


                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
        void calcularTotal()
        {
            double total = 0;
            foreach (DataGridViewRow rowPedido in dgvPedido.Rows)
            {
                rowPedido.Height = 40;
                total += Convert.ToDouble(rowPedido.Cells["cnImporte"].Value.ToString());
            }

            lblTotal.Text = total.ToString("0.00");
        }

        private void cargarCategoria()
        {
            try
            {
                string oncod = "select * from Categoria";
                SqlCommand cmd = new SqlCommand(oncod, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Button btn = new Button();
                    btn.FlatStyle = FlatStyle.Popup;
                    btn.Text = lector["Categoria"].ToString();
                    btn.Size = new Size(140, 60);
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.Teal;
                    btn.Tag = lector["IDCategoria"].ToString();
                    btn.Click += btnCategoria_Click;
                    flpCategoria.Controls.Add(btn);
                }
                conexion.Close();
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cargarSubcategoria(string IDCategoria)
        {
            try
            {
                flpSubCategoria.Controls.Clear();
                string oncod = "select * from SubCategoria where IDCategoria = '" + IDCategoria + "'";
                SqlCommand cmd = new SqlCommand(oncod, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Button btn = new Button();
                    btn.FlatStyle = FlatStyle.Popup;
                    btn.Text = lector["SubCategoria"].ToString();
                    btn.Size = new Size(140, 60);
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.MediumSeaGreen;
                    btn.Tag = lector["IDSubCategoria"].ToString();
                    btn.Click += btnSubcategoria_Click;
                    flpSubCategoria.Controls.Add(btn);
                }
                conexion.Close();
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cargarProducto(string IDSubcategoria)
        {
            try
            {
                flpProducto.Controls.Clear();
                string oncod = "select pre.IDPresentacion,UPPER(pro.Producto) as Producto from Producto pro inner join Presentacion pre on pro.IDProducto = pre.IDProducto where IDSubcategoria = '" + IDSubcategoria+"' and pro.Activo = 1 and pre.IDSucursal = '"+Datos.idSucursal+"'";
                SqlCommand cmd = new SqlCommand(oncod, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Button btn = new Button();
                    btn.FlatStyle = FlatStyle.Popup;
                    btn.Text = lector["Producto"].ToString();
                    btn.Size = new Size(140, 60);
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.SeaGreen;
                    btn.Tag = lector["IDPresentacion"].ToString();
                    btn.Click += btnProducto_Click;
                    flpProducto.Controls.Add(btn);
                }
                conexion.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            Button btnProducto = sender as Button;

            
            frmCantidad.idPresentacion = btnProducto.Tag.ToString();
            frmCantidad.txtCantidad.Clear();
            frmCantidad.txtDescr.Clear();
            frmCantidad.ShowDialog(this);

            if(frmCantidad.Cancelado == false)
            {
                double precio =0,importe=0,costo=0;
                string categoria="";
                bool combo = false;
                string idPresentacion = btnProducto.Tag.ToString();
                string plato = btnProducto.Text;
                string descripcion = frmCantidad.txtDescr.Text;
                double cantidad = Convert.ToDouble(frmCantidad.txtCantidad.Text);

                SqlDataReader lector = fn.selectMultiValues("select pre.Precio,pre.Costo,ca.Categoria,pre.Combo from presentacion pre inner join Producto pro on pre.IDProducto = pro.IDProducto inner join SubCategoria sc on pro.IDSubcategoria = sc.IDSubCategoria inner join Categoria ca on sc.IDCategoria = ca.IDCategoria where IDPresentacion = "+idPresentacion+"");
                while(lector.Read())
                {
                    precio = Convert.ToDouble(lector["Precio"]);
                    costo = Convert.ToDouble(lector["Costo"]);
                    categoria = lector["Categoria"].ToString();
                    combo = Convert.ToBoolean(lector["Combo"]);
                    importe = precio * cantidad;
                }
                lector.Close();
                
                
                dgvPedido.Rows.Add(false,idPresentacion,plato,descripcion,combo,cantidad,precio,importe.ToString("0.00"),"",categoria,costo);
                calcularTotal();
                
            }
        }

        

        private void btnCargarMozo_Click(object sender, EventArgs e)
        {
            FrmCargarMozo frm = new FrmCargarMozo();
            frm.ShowDialog();

            if (FrmCargarMozo.cancel == false)
            {
                lblMozo.Text = frm.cboMozo.Text;
                lblMozo.Tag = frm.cboMozo.SelectedValue;
            }
        }

        private void btnPreCuenta_Click(object sender, EventArgs e)
        {
            pdPreCuenta.Print();
            fn.Modificar("Mesa", "Estado = 'PRECUENTA'", "IDMesa='" + lblMesa.Tag + "'");
            this.Close();
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

        private void print()
        {
            try
            {
                bool existsBar = false, existsCocina = false;

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
                }



                if (existsBar == true)
                {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void saveOrder()
        {
            string date = DateTime.Now.ToShortDateString();
            string idPedido = lblSerieC.Text + "-" + lblNumeroC.Text;
            DateTime time = DateTime.Now;

            //REGISTRY ORDER
            fn.RegistrarOficial("Pedido", "IDPedido,Serie,Numero,Fecha,Hora,IDMesa,IDMozo,Vendido,Anulado",
                "'" + idPedido + "','" + lblSerieC.Text + "','" + lblNumeroC.Text + "','" + date + "','" + time.ToString("HH:mm:ss") + "','" + lblMesa.Tag + "','" + lblMozo.Tag + "','False','False'");

            //REGISTRY DETAIL
            registryDetail(idPedido);

            //STATE MESA
            fn.Modificar("Mesa", "Estado='OCUPADA',Hora='" + time.ToString("dd-MM-yyyy HH:mm:ss") + "'", "IDMesa='" + lblMesa.Tag + "'");

            //TALONARIO
            fn.Modificar("Talonario", "Numero=Numero+1", "Serie='" + lblSerieC.Text + "'");
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


                fn.RegistrarOficial("PedidoDetalle", "IDPedido,IDPresentacion,Presentacion,Descripcion,Cantidad,Precio,Imprimido,Costo,Vendido",
                    "'" + vidpedido + "','" + idPresentacion + "','" + presentacion + "','" + descripcion + "','" + quantity + "','" + price + "','True','" + cost + "','False'");
            }
        }

        private bool validationSave()
        {
            if (existsOrder == false)
            {
                if (fn.Existencia("*", "Pedido", "IDPedido='" + lblSerieC.Text + "-" + lblNumeroC.Text + "'") == true)
                {
                    fn.Modificar("Talonario", "Numero=(select MAX(numero) from Pedido WHERE len(numero) = 8)", "Serie='" + lblSerieC.Text + "'");
                    lblNumeroC.Text = Convert.ToDouble(fn.selectValue("select (Numero+1) from Talonario where Serie = '" + lblSerieC.Text + "'")).ToString("00000000");
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
        private void pdBar_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            pt.comanda("BAR", e, lblMesa.Text, lblMozo.Text, lblSerieC.Text + "-" + lblNumeroC.Text, dgvPedido, reimprimir, false);
        }

        private void pdPreCuenta_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion


            e.Graphics.DrawString("Mesa: " + lblMesa.Text, new Font("Courier New Condensada", 10, FontStyle.Bold), Brushes.Black, new Point(5, 0));
            e.Graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 13 + 5));
            e.Graphics.DrawString("Hora: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 26 + 5));
            e.Graphics.DrawString("Mozo: " + lblMozo.Text, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 39 + 5));

            e.Graphics.DrawString("PRE-CUENTA", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(110, 65 + 5));





            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 179 - 89));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 179 - 89));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 179 + 3 - 89), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 179 + 3 - 89), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 192 - 89));


            int SUMATORIA = 0;

            foreach (DataGridViewRow row in dgvPedido.Rows)
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



                e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5 - 89));
                e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5 - 89));

                e.Graphics.DrawString("" + untario.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 231 - 13 + SUMATORIA - 89 + 8), alineacion);
                e.Graphics.DrawString("" + costo.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 231 - 13 + SUMATORIA + 8 - 89), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 245 - 13 + SUMATORIA - 89));
                SUMATORIA = SUMATORIA + 30;

            }

            string letras;




            Clases.Conversion CONVERSION = new Conversion();
            letras = CONVERSION.enletras(lblTotal.Text.ToString());




            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 268 - 13 + SUMATORIA - 25 - 89));//276
            e.Graphics.DrawString("" + lblTotal.Text, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 268 - 13 + SUMATORIA - 89 - 25), alineacion);

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

            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 281 - 13 + SUMATORIA - 25 - 89));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 291 - 13 + SUMATORIA - 25 - 89));
            e.Graphics.DrawString("=====================================================: " + Datos.Usuario, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 283 - 13 + SUMATORIA - 89));


        }

        private void pdCocina_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            pt.comanda("COCINA", e, lblMesa.Text, lblMozo.Text, lblSerieC.Text + "-" + lblNumeroC.Text, dgvPedido, reimprimir, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmMozo.txtPass.Clear();
                frmMozo.reimprimir = true;
                frmMozo.ShowDialog();

                if (FrmCargarMozo.cancel == false)
                {
                    dgvPedido.CurrentRow.Cells["cnImprimido"].Value = false;
                    reimprimir = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
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
                            if (!row2.IsNewRow) dgvPedido.Rows.Remove(row2);
                        }
                    }
                    else
                    {
                        frmMozo.txtPass.Clear();
                        frmMozo.reimprimir = true;
                        frmMozo.ShowDialog();

                        if (FrmCargarMozo.cancel == false)
                        {
                            DialogResult result = MessageBox.Show("Desea Quitar el Plato de la Lista", "FactuTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                            if (result == DialogResult.Yes)
                            {
                                if (!row2.IsNewRow)
                                {
                                    string codPedido = dgvPedido.CurrentRow.Cells["cnCodPedido"].Value.ToString();
                                    fn.Eliminar("PedidoDetalle", "IDDetallePedido='" + codPedido + "'");
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

        private void dgvPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToBoolean(dgvPedido.CurrentRow.Cells["cnImprimido"].Value) == false)
                {
                    float precio = Convert.ToSingle(dgvPedido.CurrentRow.Cells["cnPrecio"].Value);
                    byte cantidadActual = Convert.ToByte(dgvPedido.CurrentRow.Cells["cnCantidad"].Value);
                    int cantidadNuevo = cantidadActual + 1;

                    float nuevoImporte = precio * cantidadNuevo;

                    dgvPedido.CurrentRow.Cells["cnCantidad"].Value = cantidadNuevo;
                    dgvPedido.CurrentRow.Cells["cnImporte"].Value = nuevoImporte;

                    calcularTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToBoolean(dgvPedido.CurrentRow.Cells["cnImprimido"].Value) == false)
                {
                    //DATOS
                    float precio = Convert.ToSingle(dgvPedido.CurrentRow.Cells["cnPrecio"].Value);
                    byte cantidadActual = Convert.ToByte(dgvPedido.CurrentRow.Cells["cnCantidad"].Value);

                    //NUEVOS DATOS
                    int cantidadNuevo = cantidadActual - 1;
                    float nuevoImporte = precio * cantidadNuevo;

                    if (cantidadNuevo == 0)
                    {
                        dgvPedido.Rows.Remove(dgvPedido.CurrentRow);
                    }
                    else
                    {
                        dgvPedido.CurrentRow.Cells["cnCantidad"].Value = cantidadNuevo;
                        dgvPedido.CurrentRow.Cells["cnImporte"].Value = nuevoImporte;
                    }

                    if (dgvPedido.Rows.Count == 0)
                    {
                        this.Close();
                    }

                    calcularTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDescripcion_Click(object sender, EventArgs e)
        {
            if(dgvPedido.Rows.Count > 0)
            {
                FrmAddIngredintes frm = new FrmAddIngredintes();
                frm.txtProducto.Text = dgvPedido.CurrentRow.Cells["cnDescripcion"].Value.ToString();
                frm.idPresentacion = dgvPedido.CurrentRow.Cells["cnCodigo"].Value.ToString();
                frm.ShowDialog();

                if(frm.Cancelado == false)
                {
                    dgvPedido.CurrentRow.Cells["cnDescripcion"].Value = frm.txtProducto.Text;
                }
            }
        }

        private void btnSubcategoria_Click(object sender, EventArgs e)
        {
            Button btnSubCategoria = sender as Button;
            cargarProducto(btnSubCategoria.Tag.ToString());
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Button btnCategoria = sender as Button;
            cargarSubcategoria(btnCategoria.Tag.ToString());
        }
    }
}
