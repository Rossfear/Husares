using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Facturacion.Pedido;
using SwJugueriaAgustin.Formularios.Venta.Facturacion;
using SwJugueriaAgustin.Formularios.Venta.Facturar;
using SwJugueriaAgustin.Formularios.Venta.Pedido;
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
    public partial class FrmSeleccionMesa : Form
    {
        Funciones fn = new Funciones();
        FrmCargarMozo frm = new FrmCargarMozo();
        SqlConnection conexion = new SqlConnection(Funciones.preconex);

        string idZona;
        string zona;
        public FrmSeleccionMesa()
        {
            InitializeComponent();
        }

        private void FrmSeleccionMesa_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CargarZona();
            timer1.Start();

            cargarDatos();
        }

        private void cargarDatos()
        {
            
        }

        private void CargarZona()
        {
            try
            {
                string oncod = "select Zona,IDZona from Zona where IDSucursal='" + Datos.idSucursal + "' order by Item";
                SqlCommand cmd = new SqlCommand(oncod, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Button btn = new Button();

                    btn.FlatStyle = FlatStyle.Popup;
                    btn.Text = lector["Zona"].ToString();
                    btn.Size = new System.Drawing.Size(140, 60);
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.Teal;
                    btn.Tag = lector["IDZona"].ToString();
                    btn.Click += btnZona_Click;
                    flpZona.Controls.Add(btn);
                }
                conexion.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void btnZona_Click(object sender, EventArgs e)
        {
            Button btnZona = sender as Button;

            idZona = btnZona.Tag.ToString();
            zona = btnZona.Text;

            lblZona.Text = zona;

            if (btnZona.Text == "DELIVERY")
            {
                cargarDelivery();
            }
            else
            {
                CargarmMesa(btnZona.Tag.ToString());
            }
        }

        private void cargarDelivery()
        {
            string idBox = fn.select_one_value("MAX(ID)", "Caja", "Tipo = 'DELIVERY' and IDSucursal = '"+Datos.idSucursal+"'", 0);
            flpMesa.Controls.Clear();

            //BOTON NUEVO
            Button btnDelivery = new Button();
            btnDelivery.FlatStyle = FlatStyle.Popup;
            btnDelivery.Text = "NUEVO DELIVERY";
            btnDelivery.Size = new System.Drawing.Size(250, 200);
            flpMesa.Controls.Add(btnDelivery);
            btnDelivery.Click += btnDelivery_click;

            //AGREGAMOS LOS DEMAS BOTONES
            SqlConnection conexion = new SqlConnection(Funciones.preconex);
            string oncod = "select v.Total,v.IDVenta,v.Fecha,v.Hora,TRIM(v.NombreCliente) AS NombreCliente,v.Estado,trim(c.Telefono) as Telefono,trim(c.Telefono2) as Telefono2,trim(c.Direccion) as Direccion ,trim(c.Referencia) as Referencia,r.Nombres as Repartidor,V.PagoCon,v.vuelto from venta v left join Cliente c on v.IDCliente = c.IDCliente left join Repartidor r on v.IDRepartidor = r.IDRepartidor where TipoVenta = 'VD' and v.IDCaja = '" + idBox+"' order by cast(Hora as time) desc,v.Fecha desc";
            SqlCommand cmd = new SqlCommand(oncod, conexion);
            conexion.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                string idVenta = lector["IDVenta"].ToString();
                string date = Convert.ToDateTime(lector["Fecha"].ToString()).ToShortDateString();
                string time = lector["Hora"].ToString();
                string cliente = lector["NombreCliente"].ToString();
                string total = lector["Total"].ToString();
                string direccion = lector["Direccion"].ToString();
                string telefono1 = lector["Telefono"].ToString();
                string telefono2 = lector["Telefono2"].ToString();
                string refrecnai = lector["Referencia"].ToString().Trim();
                string repartidor = lector["Repartidor"].ToString();
                string pagoCon = lector["PagoCon"].ToString();
                string vuelto = lector["Vuelto"].ToString();
                string estado = lector["Estado"].ToString();

                Button btn = new Button();
                btn.FlatStyle = FlatStyle.Popup;
                btn.Text = "Codigo: " + idVenta + "\nFecha-Hora: " + date + " - " + time +"\nCliente: " + cliente +"\nTelefonos: "+telefono1+" - "+telefono2 +"\nDireccion: "+direccion+"\nReferencia: "+refrecnai+"\nRepartidor: "+repartidor+"\nTotal: "+total+"\nPagoCon: "+pagoCon+"      Cambio: "+vuelto;
                btn.Size = new System.Drawing.Size(250, 200);

                if (estado == "SOLICITADO")
                {
                    btn.BackColor = Color.IndianRed;
                    btn.ForeColor = Color.White;
                }
                else if (estado == "ATENDIDO")
                {
                    btn.BackColor = Color.DarkTurquoise;
                    btn.ForeColor = Color.White;
                }
                else if(estado == "CONFIRMADO")
                {
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.White;
                }

                btn.Tag = lector["IDVenta"].ToString();
                btn.Click += btnDelivery_click;
                flpMesa.Controls.Add(btn);
            }
            return;
        }

        private void btnDelivery_click(object sender, EventArgs e)
        {
            Button btnMesa = sender as Button;

            if (btnMesa.Text == "NUEVO DELIVERY")
            {
                FrmValidacionDelivery frm = new FrmValidacionDelivery();
                frm.ShowDialog();
                
            }
            else if (btnMesa.BackColor == Color.DarkTurquoise)
            {
                FrmConfirmarDelivery frmConfirmar = new FrmConfirmarDelivery();
                frmConfirmar.IDVenta = btnMesa.Tag.ToString();
                frmConfirmar.ShowDialog();
            }
            else if(btnMesa.BackColor == Color.IndianRed)
            {
                FrmAtenderDelivery frm = new FrmAtenderDelivery();
                frm.idVenta = btnMesa.Tag.ToString();
                frm.ShowDialog();
            }
            else
            {
                FrmDetalleVenta frm = new FrmDetalleVenta();
                FrmDetalleVenta.IDVenta = btnMesa.Tag.ToString();
                frm.ShowDialog();
            }




            cargarDelivery();


            //CargarmMesa(idZona);
        }

        private void CargarmMesa(string idZona)
        {
            try
            {
                flpMesa.Controls.Clear();

                string oncod = "select Mesa,IDMesa,Estado,Hora,cast(dateadd(minute,(DATEDIFF( MI , Hora , GETDATE())),'00:00:00') as time(0)) as Diferencia from Mesa where IDZona = '" + idZona + "'";
                SqlCommand cmd = new SqlCommand(oncod, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    Button btn = new Button();
                    btn.FlatStyle = FlatStyle.Popup;
                    btn.Text = lector["Mesa"].ToString();
                    btn.Size = new System.Drawing.Size(140, 60);

                    if (lector["Estado"].ToString() == "OCUPADA")
                    {
                        btn.Text = btn.Text + "\n" + lector["Diferencia"].ToString();
                        btn.BackColor = Color.IndianRed;
                        btn.ForeColor = Color.White;
                    }
                    else if (lector["Estado"].ToString() == "LIBRE")
                    {
                        btn.BackColor = Color.MediumSeaGreen;
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        btn.Text = btn.Text + "\n" + lector["Diferencia"].ToString();
                        btn.BackColor = Color.DarkTurquoise;
                        btn.ForeColor = Color.White;
                    }

                    btn.Tag = lector["IDMesa"].ToString();
                    btn.Click += btnMesa_Click;
                    flpMesa.Controls.Add(btn);
                }
                lector.Close();
                conexion.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private bool validacionSeleccionMesa(string idMesa)
        {
            if(Datos.mozo == true)
            {
                SqlDataReader lectorPedido = fn.selectMultiValues("select * from pedido where IDMesa = '" + idMesa + "' and Vendido = 'False' and Anulado='False'");
                while (lectorPedido.Read())
                {
                    frm.txtPass.Clear();
                    string idMozo = lectorPedido["IDMozo"].ToString();
                    frm.condicion = " and IDMozo='" + idMozo + "'";
                    frm.ShowDialog();

                    if (FrmCargarMozo.cancel == true)
                    {
                        return false;
                    }
                }
                lectorPedido.Close();
            }

            return true;
        }

        private void btnMesa_Click(object sender, EventArgs e)
        {
            Button btnMesa = sender as Button;
            

            if (validacionSeleccionMesa(btnMesa.Tag.ToString()) == false)
            {
                return;
            }

            if (Datos.tactil != true)
            {
                FrmSeleccionPedido frm = new FrmSeleccionPedido();

                if (btnMesa.BackColor != Color.MediumSeaGreen)
                {
                    int indice = btnMesa.Text.IndexOf("\n");
                    frm.lblMesa.Text = btnMesa.Text.Remove(indice);
                    frm.lblMesa.Tag = btnMesa.Tag;
                }
                else
                {
                    frm.lblMesa.Text = btnMesa.Text;
                    frm.lblMesa.Tag = btnMesa.Tag;
                }



                if (fn.Existencia("*", "Pedido", "IDMesa = '" + btnMesa.Tag + "' and Vendido = 'False' and Anulado='False'") == true)
                {
                    frm.existsOrder = true;
                    frm.btnFacturar.Enabled = true;
                }
                else
                {
                    frm.existsOrder = false;
                    frm.btnFacturar.Enabled = false;
                }

                if (btnMesa.Text == "LLEVAR A" || btnMesa.Text == "LLEVAR B")
                {
                    frm.btnSolicitarPedido.Enabled = false;
                    frm.btnFacturar.Enabled = true;
                }
                else
                {
                    frm.btnSolicitarPedido.Enabled = true;
                }

                frm.ShowDialog();
                CargarmMesa(idZona);
            }
            else
            {
                FrmPedidoTactil frm = new FrmPedidoTactil();
                if (btnMesa.BackColor != Color.MediumSeaGreen)
                {
                    int indice = btnMesa.Text.IndexOf("\n");
                    frm.lblMesa.Text = btnMesa.Text.Remove(indice);
                    frm.lblMesa.Tag = btnMesa.Tag;
                }
                else
                {
                    frm.lblMesa.Text = btnMesa.Text;
                    frm.lblMesa.Tag = btnMesa.Tag;
                }



                if (fn.Existencia("*", "Pedido", "IDMesa = '" + btnMesa.Tag + "' and Vendido = 'False' and Anulado='False'") == true)
                {
                    frm.existsOrder = true;
                }
                else
                {
                    frm.existsOrder = false;
                }

                if (btnMesa.Text == "LLEVAR A" || btnMesa.Text == "LLEVAR B")
                {
                    frm.btnSolicitarPedido.Enabled = false;
                }
                else
                {
                    frm.btnSolicitarPedido.Enabled = true;
                }

                frm.ShowDialog();
                CargarmMesa(idZona);
            }
        }

        private void btnAtenderDelivery_Click(object sender, EventArgs e)
        {
            FrmAtenderDelivery frm = new FrmAtenderDelivery();
            frm.ShowDialog();

            cargarDelivery();
        }

        private void btnCambiarRepartidor_Click(object sender, EventArgs e)
        {
            FrmCambiarRepartidor frm = new FrmCambiarRepartidor();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (zona == "DELIVERY")
            {
                cargarDelivery();
            }
            else
            {
                CargarmMesa(idZona);
            }
        }
    }
}
