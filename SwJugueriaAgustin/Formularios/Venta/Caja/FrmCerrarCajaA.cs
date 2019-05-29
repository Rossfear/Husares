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

namespace SwJugueriaAgustin.Formularios.Venta.Caja
{
    public partial class FrmCerrarCajaA : Form
    {
        Funciones fn = new Funciones();

        public FrmCerrarCajaA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idCaja ="",condicion = "";

            if (rbtnVentaSalon.Checked == true)
            {
                condicion = " and Tipo='VENTA SALON'";
            }
            else
            {
                condicion = " and Tipo='DELIVERY'";
            }

            SqlDataReader lectorCaja = fn.selectMultiValues("select top(1) * from CAJA where Estado = 'ABIERTA' and IDSucursal = '"+Datos.idSucursal+"' "+condicion+" ORDER BY ID DESC ");
            while (lectorCaja.Read())
            {
                idCaja = lectorCaja["ID"].ToString();
                txtEstado.Text = lectorCaja["Estado"].ToString();
                txtFecha.Text = Convert.ToDateTime(lectorCaja["Fecha_Hora"]).ToShortDateString();
                lblSaldoInicial.Text = lectorCaja["SaldoInicial"].ToString();
            }

            lblSalidaTotal.Text = fn.remplazarNulo(fn.selectValue("select sum(Monto) from SalidaDinero where IDCaja='"+idCaja+"' and Entrada = 0"));
            lblIngreso.Text = fn.remplazarNulo(fn.selectValue("select sum(Monto) from SalidaDinero where IDCaja='" + idCaja + "' and Entrada = 1"));

            //TIPO DE COMPROBANTE
            SqlDataReader lector = fn.selectMultiValues("select sum(v.Total) as Total,tc.NombreComprobante as TipoComprobante from Venta v inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante inner join CAJA c on v.IDCaja = c.ID where v.Anulada = 0 and c.ID = '"+idCaja+"' group by tc.NombreComprobante");
            while(lector.Read())
            {
                string tipoComprobante = lector["TipoComprobante"].ToString();
                if (tipoComprobante == "BOLETA") txtMontoSBoleta.Text = lector["Total"].ToString();

                else if (tipoComprobante == "FACTURA") txtMontoSFactura.Text = lector["Total"].ToString();

                else if (tipoComprobante == "TICKET") txtMontoSTicket.Text = lector["Total"].ToString();
            }
            lector.Close();

            txtTarjeta1Monto.Text = "0.00";
            txtTarjeta2Monto.Text = "0.00";
            txtTarjeta3Monto.Text = "0.00";
            txtTarjeta4Monto.Text = "0.00";

            if(!string.IsNullOrEmpty(idCaja))
            {
                ReportePorCaja(idCaja, "Venta_VentaxCaja_Listar",dgvVentaDetalle);
                ReportePorCaja(idCaja, "Venta_IngresoxCaja_Listar", dgvIngreso);
                ReportePorCaja(idCaja, "Venta_SalidaxCaja_Listar", dgvEgreso);
            }
        }

        

        private void ReportePorCaja(string idCaja,string procedimiento,DataGridView dgv)
        {
            DataTable tablaVenta = new DataTable();
            SqlCommand cmd = fn.procedimientoAlmacenado(procedimiento);
            cmd.Parameters.AddWithValue("@IDCaja", idCaja);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tablaVenta);
            cmd.Connection.Close();

            dgv.DataSource = tablaVenta;
        }

        void ventaComprobante()
        {
            double ticketSistema = 0, boletaSistema = 0, facturaSistema = 0;
            double ticketManual = 0, boletaManual = 0, facturaManual = 0,total=0;

            ticketSistema = Convert.ToDouble(fn.remplazarNulo(txtMontoSTicket.Text));
            boletaSistema = Convert.ToDouble(fn.remplazarNulo(txtMontoSBoleta.Text));
            facturaSistema = Convert.ToDouble(fn.remplazarNulo(txtMontoSFactura.Text));

            ticketManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMTicket.Text));
            boletaManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMBoleta.Text));
            facturaManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMFactura.Text));

            total = ticketSistema+ boletaSistema+ facturaSistema+ ticketManual+ boletaManual+ facturaManual;

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

            string idCaja = "", condicion = "";

            if (rbtnVentaSalon.Checked == true)
            {
                condicion = " and Tipo='VENTA SALON'";
            }
            else
            {
                condicion = " and Tipo='DELIVERY'";
            }

            SqlDataReader lectorCaja = fn.selectMultiValues("select top(1) * from CAJA where Estado = 'ABIERTA' "+condicion+"  ORDER BY ID DESC ");
            while (lectorCaja.Read())
            {
                idCaja = lectorCaja["ID"].ToString();
                txtEstado.Text = lectorCaja["Estado"].ToString();
                txtFecha.Text = Convert.ToDateTime(lectorCaja["Fecha_Hora"]).ToShortDateString();
                lblSaldoInicial.Text = lectorCaja["SaldoInicial"].ToString();
            }

            fn.Modificar("Caja", "TicketMan='"+fn.remplazarNulo(txtMontoMTicket.Text)+ "',BoletaMan='"+fn.remplazarNulo(txtMontoMBoleta.Text)+ "',FacturaMan='"+fn.remplazarNulo(txtMontoMFactura.Text)+ "',Tarjeta1='"+txtTarjeta1.Text+ "',Tarjeta1Monto='"+fn.remplazarNulo(txtTarjeta1Monto.Text)+ "',Tarjeta2='"+txtTarjeta2.Text+ "',Tarjeta2Monto='"+fn.remplazarNulo(txtTarjeta2Monto.Text)+ "',Tarjeta3='"+txtTarjeta3.Text+ "',Tarjeta3Monto='"+fn.remplazarNulo(txtTarjeta3Monto.Text)+ "',Tarjeta4='"+txtTarjeta4.Text+ "',Tarjeta4Monto='"+fn.remplazarNulo(txtTarjeta4Monto.Text)+ "',TotalTarjeta='"+fn.remplazarNulo(txtTarjetaTotal.Text)+ "',TotalEfectivo='"+fn.remplazarNulo(txtEfectivoTotal.Text)+ "',FECHA_CIERRE='"+DateTime.Now.ToShortDateString()+ "',TotalSistema='"+fn.remplazarNulo(lblSaldoSistema.Text)+ "',TotalCierre='"+fn.remplazarNulo(txtTotalCierre.Text)+ "',Comentario='"+txtComentario.Text+ "',Estado='CERRADA'","ID='"+idCaja+"'");
            MessageBox.Show("Caja Cerrada","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private bool validacionCerrarCaja()
        {
            if(txtEstado.Text == "CERRADA")
            {
                MessageBox.Show("La Caja ya se encuentra Cerrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            DialogResult msj = MessageBox.Show("Desea Cerrar la Caja", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(msj == DialogResult.Cancel)
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

            lblSaldoSistema.Text = (efectivo - salida + ingreso).ToString("0.00");
        }

        void calcularTotalTarjeta()
        {
            double tarjeta1 = 0, tarjeta2 = 0, tarjeta3 = 0, tarjeta4 = 0,total;

            tarjeta1 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta1Monto.Text));
            tarjeta2 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta2Monto.Text));
            tarjeta3 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta3Monto.Text));
            tarjeta4 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta4Monto.Text));

            total = tarjeta1 + tarjeta2 + tarjeta3 + tarjeta4;

            txtTarjetaTotal.Text = total.ToString("0.00");

            calcularEfectivo();
        }

        private void FrmCerrarCajaA_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }
}
