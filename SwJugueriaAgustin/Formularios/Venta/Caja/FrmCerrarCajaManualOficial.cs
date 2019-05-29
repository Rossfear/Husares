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
    public partial class FrmCerrarCajaManualOficial : Form
    {
        Funciones fn = new Funciones();
        string idCaja = "";

        public FrmCerrarCajaManualOficial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string condicion = "";

            if (rbtnVentaSalon.Checked == true)
            {
                condicion = " and Tipo='VENTA SALON'";
            }
            else
            {
                condicion = " and Tipo='DELIVERY'";
            }

            SqlDataReader lectorCaja = fn.selectMultiValues("select top(1) * from CAJA where Estado = 'ABIERTA' and IDSucursal = '" + Datos.idSucursal + "' " + condicion + " ORDER BY ID DESC ");
            while (lectorCaja.Read())
            {
                idCaja = lectorCaja["ID"].ToString();
                txtEstado.Text = lectorCaja["Estado"].ToString();
                txtFecha.Text = Convert.ToDateTime(lectorCaja["Fecha_Hora"]).ToShortDateString();
                lblSaldoInicial.Text = lectorCaja["SaldoInicial"].ToString();
                txtCajero.Tag = lectorCaja["IDCajero"].ToString();
                txtCajero.Text = fn.selectValue("select Usuario from Cajera where IDCajera  ='"+txtCajero.Tag+"'");
            }

            txtMontoManual.Text = fn.selectValue("select sum(monto) from CuadreManual where IDCaja = '"+idCaja+"'");

            lblSalidaTotal.Text = fn.remplazarNulo(fn.selectValue("select sum(Monto) from SalidaDinero where IDCaja='" + idCaja + "'"));


            ventaComprobante();
        }

        void ventaComprobante()
        {
            double ventaManual = 0, boletaSistema = 0, facturaSistema = 0;
            double ticketManual = 0, boletaManual = 0, facturaManual = 0, total = 0;

            ventaManual = Convert.ToDouble(fn.remplazarNulo(txtMontoManual.Text));

            ticketManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMTicket.Text));
            boletaManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMBoleta.Text));
            facturaManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMFactura.Text));

            total = ventaManual + boletaSistema + facturaSistema + ticketManual + boletaManual + facturaManual;

            txtTotalComprobante.Text = total.ToString("0.00");
            lblIngresoTotal.Text = total.ToString("0.00");

            calcularTotalTarjeta();
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



            double ventaTotal = 0;
            double ticketManual = 0, boletaManual = 0, facturaManual = 0, total = 0;

            ventaTotal =  Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(total) from venta where IDCaja = '" + idCaja + "' and Anualdo = 0")));

            ticketManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMTicket.Text));
            boletaManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMBoleta.Text));
            facturaManual = Convert.ToDouble(fn.remplazarNulo(txtMontoMFactura.Text));

            total = ventaTotal  + ticketManual + boletaManual + facturaManual;


            double tarjeta1 = 0, tarjeta2 = 0, tarjeta3 = 0, tarjeta4 = 0, totalTarjeta;

            tarjeta1 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta1Monto.Text));
            tarjeta2 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta2Monto.Text));
            tarjeta3 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta3Monto.Text));
            tarjeta4 = Convert.ToDouble(fn.remplazarNulo(txtTarjeta4Monto.Text));

            totalTarjeta = tarjeta1 + tarjeta2 + tarjeta3 + tarjeta4;


            double efectivo = total - totalTarjeta;
            double salida = Convert.ToDouble(fn.remplazarNulo(lblSalidaTotal.Text));

            double saldoSistema = efectivo - salida;


            fn.Modificar("Caja", "TicketMan='" + fn.remplazarNulo(txtMontoMTicket.Text) + "',BoletaMan='" + fn.remplazarNulo(txtMontoMBoleta.Text) + "',FacturaMan='" + fn.remplazarNulo(txtMontoMFactura.Text) + "',Tarjeta1='" + txtTarjeta1.Text + "',Tarjeta1Monto='" + fn.remplazarNulo(txtTarjeta1Monto.Text) + "',Tarjeta2='" + txtTarjeta2.Text + "',Tarjeta2Monto='" + fn.remplazarNulo(txtTarjeta2Monto.Text) + "',Tarjeta3='" + txtTarjeta3.Text + "',Tarjeta3Monto='" + fn.remplazarNulo(txtTarjeta3Monto.Text) + "',Tarjeta4='" + txtTarjeta4.Text + "',Tarjeta4Monto='" + fn.remplazarNulo(txtTarjeta4Monto.Text) + "',TotalTarjeta='" + fn.remplazarNulo(txtTarjetaTotal.Text) + "',TotalEfectivo='"+efectivo+"',TotalEfectivoManual='" + fn.remplazarNulo(txtEfectivoTotal.Text) + "',FECHA_CIERRE='" + DateTime.Now.ToShortDateString() + "',TotalSistema='" + saldoSistema + "',TotalManual='"+fn.remplazarNulo(lblSaldoSistema.Text)+"',TotalCierre='" + fn.remplazarNulo(txtTotalCierre.Text) + "',Comentario='" + txtComentario.Text + "',Estado='CERRADA'", "ID='" + idCaja + "'");
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

            if(idCaja == "")
            {
                MessageBox.Show("Especificar Caja", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(fn.selectValue("select Contraseña from Cajera where IDCajera = '"+txtCajero.Tag+"'") != txtContraseña.Text)
            {
                MessageBox.Show("Contraseña Incorrecta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ventaComprobante();
        }

        void calcularEfectivo()
        {
            double tarjeta = Convert.ToDouble(fn.remplazarNulo(txtTarjetaTotal.Text));
            double totalVenta = Convert.ToDouble(fn.remplazarNulo(txtTotalComprobante.Text));
            double salida = Convert.ToDouble(fn.remplazarNulo(lblSalidaTotal.Text));
            double efectivo = totalVenta - tarjeta;

            txtEfectivoTotal.Text = efectivo.ToString("0.00");
            lblIngresoEfectivo.Text = efectivo.ToString("0.00");

            lblSaldoSistema.Text = (efectivo - salida).ToString("0.00");
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

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
