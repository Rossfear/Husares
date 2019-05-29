using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class FrmListaVentas : Form
    {
        public FrmListaVentas()
        {
            InitializeComponent();
        }
        Clases.Funciones fn = new Clases.Funciones();
        public static string CodigoVenta;





        private void dgVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataGridViewRow row in dgVentas.SelectedRows)
                {
                    CodigoVenta = row.Cells["IDVenta"].Value.ToString();

                    FrmDetalleVenta dv = new FrmDetalleVenta();
                    FrmDetalleVenta.IDVenta = CodigoVenta;
                    dv.ShowDialog(this);
                }

            }
        }

        private void FrmListaVentas_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal","IDSucursal","Sucursal",cboSucursal);
            fn.CargarCombo("TipoPago","IDTipoPago","TipoPago",cbxTipoPago);
            cbxTipoPago.Text = "";
            cbxTipoComp.Text = "TODOS";
            
        }

        private void agregarHora(ComboBox combohora, ComboBox comboMinutos)
        {
            for (short i = 0; i <= 23; i++)
            {
                combohora.Items.Add(i.ToString("00"));
            }

            for (short i = 0; i <= 59; i++)
            {
                comboMinutos.Items.Add(i.ToString("00"));
            }


        }

        private void mostrarGridCompleto(ComboBox combo, string radioButton)
        {





        }





     



        private void button2_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            //VARIABLES
            string tipoVenta, tipoComprobante;

            //TIPO DE VENTA
            if (rbtnDelivery.Checked == true) tipoVenta = " AND v.TipoVenta = 'VD'";
            else if (rbtnSalon.Checked == true) tipoVenta = " and v.TipoVenta = 'VS'";
            else tipoVenta = "";

            string sucursal = "";
            //SUCURSAL
            if(string.IsNullOrWhiteSpace(cboSucursal.Text) == false)
            {
                sucursal = " and c.IDSucursal = '"+cboSucursal.SelectedValue+"'";
            }

            //TIPO DE COMPROBANTE
            if (cbxTipoComp.Text == "FACTURA Y BOLETA") tipoComprobante = "not like '%TICKET%'";
            else if (cbxTipoComp.Text == "TODOS")       tipoComprobante = "LIKE '%%'";
            else                                        tipoComprobante = "LIKE '%" + cbxTipoComp.Text + "%'";


            if (chbxAnuladas.Checked == false)
            {
                //Mostramos Ventas Generales
                fn.ActualizarGrid(dgVentas, "select iif(v.TipoVenta = 'VS','SALON','DELIVERY') AS TipoVenta,v.IDVenta,v.Fecha,v.Hora,tc.NombreComprobante as TipoComprobante,v.Serie,v.Numero,v.NombreCliente,tp.TipoPago,iif(v.Anulada = 1,'0',v.SubTotal) as SubTotal,iif(v.Anulada = 1,'0',v.Igv) as IGV,iif(v.Anulada = 1,'0',v.Total) as Total,v.CreditoConfirmado,r.Nombres as Repartidor,u.Usuario,mo.Nombres as Mozo,me.Mesa,v.Pagado AS PagadoDelivery,v.Estado as EstadoDelivery,iif(v.Anulada = 1,'ANULADA','OK') as EstadoVenta,v.MotivoNoPago from Venta v left join TipoPago tp on v.IDTipoPago = tp.IDTipoPago left join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante left join Repartidor r on v.IDRepartidor = r.IDRepartidor left join Usuario u on v.IDEmpleado = u.IDUsuario left join Mozo mo on v.IDMozo = mo.IDMozo left join Mesa me on v.IDMesa = me.IDMesa inner join CAJA c on v.IDCaja = c.ID where cast(c.FECHA_HORA as date) between '" + dtpFecha.Value.ToShortDateString()+"' and '"+dtpFin.Value.ToShortDateString()+"' and tp.TipoPago like '%"+cbxTipoPago.Text+"%' and tc.NombreComprobante "+tipoComprobante+" and v.Serie like '%"+txtSerie.Text+"%' "+sucursal+" and v.Numero like '%"+txtNumero.Text+"%' "+tipoVenta+"");
                lblTotal.Text = fn.selectValue("select sum(v.Total) from Venta v left join TipoPago tp on v.IDTipoPago = tp.IDTipoPago left join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante inner join CAJA c on v.IDCaja = c.ID where cast(c.FECHA_HORA as date) between '" + dtpFecha.Value.ToShortDateString() + "' and '" + dtpFin.Value.ToShortDateString() + "' and tp.TipoPago like '%" + cbxTipoPago.Text + "%' and tc.NombreComprobante " + tipoComprobante + " and v.Serie like '%" + txtSerie.Text + "%' "+sucursal+" and v.Numero like '%" + txtNumero.Text + "%' " + tipoVenta + " and v.Anulada = 0");

                //SI ESTA VACIO LE DEVOLVEROS 0
                lblTotal.Text = fn.remplazarNulo(lblTotal.Text);
            }
            else
            {
                fn.ActualizarGrid(dgVentas, "select iif(v.TipoVenta = 'VS','SALON','DELIVERY') AS TipoVenta,v.IDVenta,v.Fecha,v.Hora,tc.NombreComprobante as TipoComprobante,v.Serie,v.Numero,v.NombreCliente,tp.TipoPago,v.SubTotal,v.Igv,v.Total,v.CreditoConfirmado,r.Nombres as Repartidor,u.Usuario,mo.Nombres as Mozo,me.Mesa,v.Pagado AS PagadoDelivery,v.Estado as EstadoDelivery,iif(v.Anulada = 1,'ANULADA','OK') as EstadoVenta,v.MotivoNoPago from Venta v left join TipoPago tp on v.IDTipoPago = tp.IDTipoPago left join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante left join Repartidor r on v.IDRepartidor = r.IDRepartidor left join Usuario u on v.IDEmpleado = u.IDUsuario left join Mozo mo on v.IDMozo = mo.IDMozo left join Mesa me on v.IDMesa = me.IDMesa inner join CAJA c on v.IDCaja = c.ID where cast(c.FECHA_HORA as date) between '" + dtpFecha.Value.ToShortDateString() + "' and '" + dtpFin.Value.ToShortDateString() + "' and tp.TipoPago like '%" + cbxTipoPago.Text + "%' and tc.NombreComprobante " + tipoComprobante + " and v.Serie like '%" + txtSerie.Text + "%' "+sucursal+" and v.Numero like '%" + txtNumero.Text + "%' " + tipoVenta + " and v.Anulada = 1");

                lblTotal.Text = "00.00";
            }


            fn.ActualizarGrid(dgvDetalle, "select i.Insumo,CAST(sum(r.Cantidad * dv.Cantidad) AS DECIMAL(18,2)) as Cantidad   from venta v   inner join CAJA c on v.IDCaja = c.id   inner join Sucursal s on c.IDSucursal = s.IDSucursal  inner join VentaDetalle dv on v.IDVenta = dv.IDVenta   inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion   inner join Receta r on p.IDPresentacion = r.IDPresentacion   inner join StockAlmacen sa on r.IDStockAlmacen = sa.IDStockAlmacen   inner join Insumo i on sa.IDInsumo = i.IDInsumo    inner join Almacen a on sa.IDAlmacen = a.IDAlmacen inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante inner join TipoPago tp on v.IDTipoPago = tp.IDTipoPago where v.Anulada = 'False' and cast(c.fecha_hora as date) between '" + dtpFecha.Value.ToShortDateString()+"' and '"+dtpFin.Value.ToShortDateString()+"' and tp.TipoPago like '%"+cbxTipoPago.Text+"%' "+tipoVenta+" AND tc.NombreComprobante "+tipoComprobante+" "+sucursal+" group by i.Insumo");

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Clases.exportador lemonis = new Clases.exportador();
            lemonis.exportaraexcelTimer(dgVentas, progressBar1);


        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }











        private void aCTIVARVENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgVentas.CurrentRow.Cells["ESTADO"].Value.ToString() == "OK")
            {
                MessageBox.Show("La Venta ya se Encuentra Activa", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string idVenta = dgVentas.CurrentRow.Cells[0].Value.ToString();

            DialogResult msj = MessageBox.Show("Desea ACTIVAR la Venta " + idVenta, "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (msj == DialogResult.OK)
            {


                SqlDataReader lectorPresentaciones = fn.selectMultiValues("select * from VentaDetalle where IDVenta = '" + idVenta + "'");
                while (lectorPresentaciones.Read())
                {
                    string idpresentacion = lectorPresentaciones["IDPresentacion"].ToString();
                    string cantidad = lectorPresentaciones["Cantidad"].ToString();

                    SqlConnection conexion = new SqlConnection(Funciones.preconex);
                    string oncod = "select IDStockAlmacen,Cantidad from Receta WHERE IDPresentacion = '" + idpresentacion + "'";
                    SqlCommand cmd = new SqlCommand(oncod, conexion);
                    conexion.Open();
                    SqlDataReader lector = cmd.ExecuteReader();
                    while (lector.Read())
                    {
                        string idStockAlmacen = lector[0].ToString();
                        string IDInsumo = fn.select_one_value("IDInsumo", "StockAlmacen", "IDStockAlmacen='" + idStockAlmacen + "'", 0);

                        //Descontando receta de producto paraventa
                        decimal cantidadSalida = Convert.ToDecimal(lector["Cantidad"].ToString()) * Convert.ToDecimal(cantidad);
                        fn.Modificar("StockAlmacen", "Stock=Stock-(" + cantidadSalida + ")", "IDStockAlmacen='" + idStockAlmacen + "'");
                    }
                }

                fn.Modificar("Venta", "Anulada='False'", "IDVenta='" + idVenta + "'");

                //REGISTRAMOS 
                fn.RegistrarOficial("[Venta.Seguridad]", "Fecha,Hora,IDVenta,IDUsuario,Movimiento", "'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToLongTimeString() + "','" + idVenta + "','" + Datos.idUsuario + "','VENTA ACTIVADA'");

                MessageBox.Show("Venta Activada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                buscar();
            }



        }

        private void vERDETALLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoVenta = dgVentas.CurrentRow.Cells["IDVenta"].Value.ToString();

                FrmDetalleVenta dv = new FrmDetalleVenta();
                FrmDetalleVenta.IDVenta = CodigoVenta;
                dv.ShowDialog(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cONVERTIRACREDITOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string idVenta = dgVentas.CurrentRow.Cells["IDVenta"].Value.ToString();

                //VALIDAMOS
                if (validacionCobrarCredito(idVenta) == false) return;


                fn.Modificar("Venta", "CreditoConfirmado='True'","IDVenta='"+idVenta+"'");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private bool validacionCobrarCredito(string idVenta)
        {
            string tipoPago = dgVentas.CurrentRow.Cells["TipoPago"].Value.ToString();
            if(tipoPago != "CREDITO")
            {
                MessageBox.Show("La Venta Seleccionada no es ha Credito","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            DialogResult msj = MessageBox.Show("Desea Atender la Venta " + idVenta + "", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (msj == DialogResult.Cancel) return false;

            return true;
        }
    }
}
