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

namespace SwJugueriaAgustin.Formularios.AdministracionReporte
{
    public partial class FrmRCuadreCajaA : Form
    {
        Funciones fn = new Funciones();

        public FrmRCuadreCajaA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            string idCaja = "";
            string condicion;

            if (rbtnVentaSalon.Checked == true)
            {
                condicion = " Tipo='VENTA SALON'";
            }
            else
            {
                condicion = " Tipo='DELIVERY'";
            }

            //SUCURSAL
            string sucursal = "";
            if (string.IsNullOrWhiteSpace(cboSucursal.Text) == false)
            {
                sucursal = " and IDSucursal = '"+cboSucursal.SelectedValue+"'";
            }


            SqlDataReader lectorCaja = fn.selectMultiValues("select * from CAJA where cast(Fecha_Hora as date) = '"+dtpFecha.Value.ToShortDateString()+"' "+sucursal+"  and "+condicion+"");
            while (lectorCaja.Read())
            {
                idCaja = lectorCaja["ID"].ToString();
                txtCodigo.Text = idCaja;
                txtTipo.Text = lectorCaja["Tipo"].ToString();
                txtEstado.Text = lectorCaja["Estado"].ToString();
                txtSucursal.Text = cboSucursal.Text;
                txtFecha.Text = Convert.ToDateTime(lectorCaja["Fecha_Hora"]).ToShortDateString();
                lblSaldoInicial.Text = lectorCaja["SaldoInicial"].ToString();
                txtMontoMTicket.Text = lectorCaja["TicketMan"].ToString();
                txtMontoMBoleta.Text = lectorCaja["BoletaMan"].ToString();
                txtMontoMFactura.Text = lectorCaja["FacturaMan"].ToString();
                txtTarjeta1.Text = lectorCaja["Tarjeta1"].ToString();
                txtTarjeta1Monto.Text = lectorCaja["Tarjeta1Monto"].ToString();
                txtTarjeta2.Text = lectorCaja["Tarjeta2"].ToString();
                txtTarjeta2Monto.Text = lectorCaja["Tarjeta2Monto"].ToString();
                txtTarjeta3.Text = lectorCaja["Tarjeta3"].ToString();
                txtTarjeta3Monto.Text = lectorCaja["Tarjeta3Monto"].ToString();
                txtTarjeta4.Text = lectorCaja["Tarjeta4"].ToString();
                txtTarjeta4Monto.Text = lectorCaja["Tarjeta4Monto"].ToString();
                txtTotalCierre.Text = lectorCaja["TotalSistema"].ToString();
                txtComentario.Text = lectorCaja["Comentario"].ToString();
                txtRespuesta.Text = lectorCaja["Respuesta"].ToString();

            }

            lblSalidaTotal.Text = fn.remplazarNulo(fn.selectValue("select sum(Monto) from SalidaDinero where IDCaja='" + idCaja + "' and Entrada = 0"));
            lblIngreso.Text = fn.remplazarNulo(fn.selectValue("select sum(Monto) from SalidaDinero where IDCaja='" + idCaja + "' and Entrada = 1"));

            //TIPO DE COMPROBANTE
            SqlDataReader lector = fn.selectMultiValues("select sum(v.Total) as Total,tc.NombreComprobante as TipoComprobante from Venta v inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante inner join CAJA c on v.IDCaja = c.ID where v.Anulada = 0 and c.ID = '" + idCaja + "' group by tc.NombreComprobante");
            while (lector.Read())
            {
                string tipoComprobante = lector["TipoComprobante"].ToString();
                if (tipoComprobante == "BOLETA") txtMontoSBoleta.Text = lector["Total"].ToString();

                else if (tipoComprobante == "FACTURA") txtMontoSFactura.Text = lector["Total"].ToString();

                else if (tipoComprobante == "TICKET") txtMontoSTicket.Text = lector["Total"].ToString();
            }
            lector.Close();


        }

        private void limpiar()
        {
            txtCodigo.Clear();
            txtSucursal.Clear();
            txtTipo.Clear();
            txtComentario.Clear();
            txtEfectivoTotal.Clear();
            txtEstado.Clear();
            txtFecha.Clear();
            txtMontoMBoleta.Clear();
            txtMontoMFactura.Clear();
            txtMontoMTicket.Clear();
            txtMontoSBoleta.Clear();
            txtMontoSFactura.Clear();
            txtMontoSTicket.Clear();
            txtTarjeta1.Clear();
            txtTarjeta1Monto.Clear();
            txtTarjeta2.Clear();
            txtTarjeta2Monto.Clear();
            txtTarjeta3.Clear();
            txtTarjeta3Monto.Clear();
            txtTarjeta4.Clear();
            txtTarjeta4Monto.Clear();
            txtTarjetaTotal.Clear();
            txtTotalCierre.Clear();
            txtTotalComprobante.Clear();
            lblIngresoEfectivo.Text = "0.00";
            lblIngresoTotal.Text = "0.00";
            lblSaldoInicial.Text = "0.00";
            lblSaldoSistema.Text = "0.00";
            lblSalidaTotal.Text = "0.00";
        }

        void ventaComprobante()
        {
            double ticketSistema = 0, boletaSistema = 0, facturaSistema = 0;
            double ticketManual = 0, boletaManual = 0, facturaManual = 0, total = 0;

            ticketSistema = Convert.ToDouble(fn.remplazarNulo(txtMontoSTicket.Text));
            boletaSistema = Convert.ToDouble(fn.remplazarNulo(txtMontoSBoleta.Text));
            facturaSistema = Convert.ToDouble(fn.remplazarNulo(txtMontoSFactura.Text));

            ticketManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMTicket.Text));
            boletaManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMBoleta.Text));
            facturaManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMFactura.Text));

            total = ticketSistema + boletaSistema + facturaSistema + ticketManual + boletaManual + facturaManual;

            txtTotalComprobante.Text = total.ToString("0.00");
            lblIngresoTotal.Text = total.ToString("0.00");

            calcularEfectivo();
        }


        private void txtMontoMTicket_TextChanged(object sender, EventArgs e)
        {
            ventaComprobante();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (validacionCerrarCaja() == false)
            {
                return;
            }

            string idCaja = "";
            if (rbtnVentaSalon.Checked == true)
            {
                SqlDataReader lectorCaja = fn.selectMultiValues("select top(1) * from CAJA where Estado = 'ABIERTA' and Tipo='VENTA SALON' ORDER BY ID DESC ");
                while (lectorCaja.Read())
                {
                    idCaja = lectorCaja["ID"].ToString();
                    txtEstado.Text = lectorCaja["Estado"].ToString();
                    txtFecha.Text = Convert.ToDateTime(lectorCaja["Fecha_Hora"]).ToShortDateString();
                    lblSaldoInicial.Text = lectorCaja["SaldoInicial"].ToString();
                }
            }

            fn.Modificar("Caja", "TicketMan='" + fn.remplazarNulo(txtMontoMTicket.Text) + "',BoletaMan='" + fn.remplazarNulo(txtMontoMBoleta.Text) + "',FacturaMan='" + fn.remplazarNulo(txtMontoMFactura.Text) + "',Tarjeta1='" + txtTarjeta1.Text + "',Tarjeta1Monto='" + fn.remplazarNulo(txtTarjeta1Monto.Text) + "',Tarjeta2='" + txtTarjeta2.Text + "',Tarjeta2Monto='" + fn.remplazarNulo(txtTarjeta2Monto.Text) + "',Tarjeta3='" + txtTarjeta3.Text + "',Tarjeta3Monto='" + fn.remplazarNulo(txtTarjeta3Monto.Text) + "',Tarjeta4='" + txtTarjeta4.Text + "',Tarjeta4Monto='" + fn.remplazarNulo(txtTarjeta4Monto.Text) + "',TotalTarjeta='" + fn.remplazarNulo(txtTarjetaTotal.Text) + "',TotalEfectivo='" + fn.remplazarNulo(txtEfectivoTotal.Text) + "',FECHA_CIERRE='" + DateTime.Now.ToShortDateString() + "',TotalSistema='" + fn.remplazarNulo(lblSaldoSistema.Text) + "',TotalCierre='" + fn.remplazarNulo(txtTotalCierre.Text) + "',Comentario='" + txtComentario.Text + "',Estado='CERRADA'", "ID='" + idCaja + "'");
            MessageBox.Show("Caja Cerrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private bool validacionCerrarCaja()
        {
            if (txtEstado.Text == "CERRADA")
            {
                MessageBox.Show("La Caja ya se encuentra Cerrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            DialogResult msj = MessageBox.Show("Desea Cerrar la Caja", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (msj == DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }

        private void txtTarjeta1Monto_TextChanged(object sender, EventArgs e)
        {
            calcularTotalTarjeta();
        }

        void calcularEfectivo()
        {
            double tarjeta = Convert.ToDouble(fn.remplazarNulo(txtTarjetaTotal.Text));
            double totalVenta = Convert.ToDouble(fn.remplazarNulo(txtTotalComprobante.Text));
            double salida = Convert.ToDouble(fn.remplazarNulo(lblSalidaTotal.Text));
            double ingreso = Convert.ToDouble(fn.remplazarNulo(lblIngreso.Text));
            double efectivo = totalVenta - tarjeta;

            txtEfectivoTotal.Text = efectivo.ToString("0.00");
            lblIngresoEfectivo.Text = efectivo.ToString("0.00");


            lblSaldoSistema.Text = (efectivo + ingreso - salida).ToString("0.00");
        }

        void calcularTotalTarjeta()
        {
            double tarjeta1 = 0, tarjeta2 = 0, tarjeta3 = 0, tarjeta4 = 0, total;

            tarjeta1 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta1Monto.Text));
            tarjeta2 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta2Monto.Text));
            tarjeta3 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta3Monto.Text));
            tarjeta4 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta4Monto.Text));

            total = tarjeta1 + tarjeta2 + tarjeta3 + tarjeta4;

            txtTarjetaTotal.Text = total.ToString("0.00");

            calcularEfectivo();
        }

        private void FrmRCuadreCajaA_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal", "IDSucursal", "Sucursal", cboSucursal);
        }

        private void btnConfirmarCaja_Click(object sender, EventArgs e)
        {
            fn.Modificar("Caja","Respuesta='"+txtRespuesta.Text.Trim()+"'","ID = '"+txtCodigo.Text+"'");

            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
