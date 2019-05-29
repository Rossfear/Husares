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
    public partial class FrmCuadreManualVS : Form
    {
        Funciones fn = new Funciones();
        string idCaja;
        public FrmCuadreManualVS()
        {
            InitializeComponent();
        }

        private void txtImporteComprobante_TextChanged(object sender, EventArgs e)
        {
            calcularImporteComprobante();
        }

        private void calcularImporteComprobante()
        {
            double importeComprobante = 0, importeManFactura = 0, importeManBoleta = 0,importeManTicket,importeTotal=0;

            importeComprobante = Convert.ToDouble(fn.remplazarNulo(txtImporteComprobante.Text));
            importeManFactura = Convert.ToDouble(fn.remplazarNulo(txtImporteManFactura.Text));
            importeManBoleta = Convert.ToDouble(fn.remplazarNulo(txtImporteMBoleta.Text));
            importeManTicket = Convert.ToDouble(fn.remplazarNulo(txtTicketManual.Text));

            importeTotal = importeComprobante + importeManFactura + importeManBoleta + importeManTicket;

            txtImporteTotalVenta.Text = importeTotal.ToString("0.00");

        }

        private void txtMontoLote1_TextChanged(object sender, EventArgs e)
        {
            double lote1 = 0, lote2 = 0, lote3 = 0, lote4 = 0, lote5 = 0, totalLotes;

            lote1 = Convert.ToDouble(fn.remplazarNulo(txtMontoLote1.Text));
            lote2 = Convert.ToDouble(fn.remplazarNulo(txtMontoLote2.Text));
            lote3 = Convert.ToDouble(fn.remplazarNulo(txtMontoLote3.Text));
            lote4 = Convert.ToDouble(fn.remplazarNulo(txtMontoLote4.Text));
            

            totalLotes = lote1 + lote2 + lote3 + lote4 + lote5;

            txtTotalLotes.Text = totalLotes.ToString("0.00");

            txtRTarjeta.Text = txtTotalLotes.Text;
        }

        private void txtParcial1_TextChanged(object sender, EventArgs e)
        {
            double parcia1 = 0, parcia2 = 0, parcia3 = 0, parcia4 = 0, parcia5 = 0, totalParcial;

            parcia1 = Convert.ToDouble(fn.remplazarNulo(txtParcial1.Text));
            parcia2 = Convert.ToDouble(fn.remplazarNulo(txtParcial2.Text));
            parcia3 = Convert.ToDouble(fn.remplazarNulo(txtParcial3.Text));
            parcia4 = Convert.ToDouble(fn.remplazarNulo(txtParcial4.Text));
            parcia5 = Convert.ToDouble(fn.remplazarNulo(txtParcial5.Text));

            totalParcial = parcia1 + parcia2 + parcia3+ parcia4+ parcia5;

            txtParcialTotal.Text = totalParcial.ToString("0.00");
            txtREfectivo.Text = txtParcialTotal.Text;
        }

        private void FrmCuadreManual_Load(object sender, EventArgs e)
        {
            
            
        }

        private void calcularSencillo()
        {
            double saldoinicial = 0, egreso = 0, saldo, sencilloParcial = 0;

            sencilloParcial = Convert.ToDouble(fn.remplazarNulo(txtSencilloParcial.Text));
            saldoinicial = Convert.ToDouble(fn.remplazarNulo(txtSencilloIngreso.Text));
            egreso = Convert.ToDouble(fn.remplazarNulo(txtSencilloEgreso.Text));
            saldo = (saldoinicial - egreso);
            txtSencilloSaldo.Text = saldo.ToString("0.00");

            if (saldo > sencilloParcial)
            {
                labelSencillo.Text = "FALTANTE";
                labelSencillo.BackColor = Color.Red;
            }
            else if (sencilloParcial > saldo)
            {
                labelSencillo.Text = "SOBRANTE";
                labelSencillo.BackColor = Color.Green;
            }
            else if (sencilloParcial == saldo)
            {
                labelSencillo.Text = "CUADRADO";
                labelSencillo.BackColor = Color.White;
            }

            txtFaltaneSencillo.Text = (sencilloParcial-saldo).ToString("");
        }

        private void txtRTarjeta_TextChanged(object sender, EventArgs e)
        {
            double tarjeta = 0, efectivo = 0, totalEfectivo, totalVenta = 0;

            totalVenta = Convert.ToDouble(fn.remplazarNulo(txtImporteTotalVenta.Text));
            
            tarjeta = Convert.ToDouble(fn.remplazarNulo(txtRTarjeta.Text));
            efectivo = Convert.ToDouble(fn.remplazarNulo(txtREfectivo.Text));
            totalEfectivo = tarjeta + efectivo;

            txtRTotal.Text = totalEfectivo.ToString("0.00");

            txtRSobrante.Text = (totalEfectivo - totalVenta).ToString("0.00"); 

            if((totalEfectivo - totalVenta) >= 0)
            {
                labelCuadre.Text = "SOBRANTE";
                labelCuadre.BackColor = Color.Green;
            }
            else
            {
                labelCuadre.Text = "FALTANTE";
                labelCuadre.BackColor = Color.Red;
            }

        }

        private void txtRTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSencilloEgreso_TextChanged(object sender, EventArgs e)
        {
            calcularSencillo();
            
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if(validacionCerrar() == false)
            {
                return;
            }

            registro();

            endRegistro();
        }

        private void endRegistro()
        {
            MessageBox.Show("Caja Cuadrada y Cerrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void registro()
        {
            double efectivo=0, egreso=0,totalCierre;

            egreso = Convert.ToDouble(fn.remplazarNulo(txtSencilloEgreso.Text));

            double totalVenta = Convert.ToDouble(fn.remplazarNulo(txtImporteTotalVenta.Text));
            double tarjeta = Convert.ToDouble(fn.remplazarNulo(txtTotalLotes.Text));
            double efectivoSistema = totalVenta - tarjeta;
            double saldoSistema = efectivoSistema - egreso;

            efectivo = Convert.ToDouble(fn.remplazarNulo(txtREfectivo.Text));
            
                
            totalCierre = efectivo - egreso;

            fn.Modificar("Caja", "TicketMan='" + fn.remplazarNulo(txtTicketManual.Text) + "',BoletaMan='" + fn.remplazarNulo(txtImporteMBoleta.Text) + "',FacturaMan='" + fn.remplazarNulo(txtImporteManFactura.Text) + "',Tarjeta1='" + txtLote1.Text + "',Tarjeta1Monto='" + fn.remplazarNulo(txtMontoLote1.Text) + "',Tarjeta2='" + txtLote2.Text + "',Tarjeta2Monto='" + fn.remplazarNulo(txtMontoLote2.Text) + "',Tarjeta3='" + txtLote3.Text + "',Tarjeta3Monto='" + fn.remplazarNulo(txtMontoLote3.Text) + "',Tarjeta4='" + txtLote4.Text + "',Tarjeta4Monto='" + fn.remplazarNulo(txtMontoLote4.Text) + "',TotalTarjeta='" + fn.remplazarNulo(txtTotalLotes.Text) + "',TotalEfectivo='" + fn.remplazarNulo(txtParcialTotal.Text) + "',FECHA_CIERRE='" + DateTime.Now.ToShortDateString() + "',TotalSistema='" + fn.remplazarNulo(saldoSistema.ToString()) + "',TotalCierre='" + fn.remplazarNulo(totalCierre.ToString()) + "',Comentario='" + txtComantario.Text + "',Estado='CERRADA'", "ID='" + idCaja + "'");
        }

        private bool validacionCerrar()
        {
            if (fn.Existencia("*", "Mesa", "Estado != 'LIBRE' AND Mesa != 'DELYVERY'") == true)
            {
                MessageBox.Show("Antes de Cerrar Caja. Atender Todas las Mesas", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboCajera.SelectedValue == null)
            {
                MessageBox.Show("Seleccione Cajera", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if(string.IsNullOrEmpty(txtRTarjeta.Text) == true)
            {
                MessageBox.Show("Especifique Venta con Tarjeta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtREfectivo.Text) == true)
            {
                MessageBox.Show("Especifique Parciales", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DialogResult msj = MessageBox.Show("Desea Cerrar Caja", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(msj == DialogResult.Cancel) return false;

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string idCaja = "", condicion = "";

            if (rbtnVentaSalon.Checked == true)
            {
                condicion = " and Tipo='VENTA SALON'";
            }
            else
            {
                condicion = " and Tipo='DELIVERY'";
            }

            //DATOS DE CAJA
            SqlDataReader lector = fn.selectMultiValues("select top(1) * from caja where IDSucursal = '" + Datos.idSucursal + "' "+condicion+" order by ID desc");
            while (lector.Read())
            {
                idCaja = lector["ID"].ToString();
                txtFechaCaja.Text = Convert.ToDateTime(lector["Fecha_Hora"].ToString()).ToShortDateString();
                txtEstado.Text = lector["Estado"].ToString();
                txtSencilloIngreso.Text = lector["Efectivo"].ToString();
            }
            lector.Close();


            SqlDataReader lectorNroComprobante = fn.selectMultiValues("select sum(Monto) as Total,MIN(NroComprobante) as Minimo,max(NroComprobante) as Maximo from CuadreManual where IDCaja = '" + idCaja + "'");
            while (lectorNroComprobante.Read())
            {
                txtComprobanteInicio.Text = lectorNroComprobante["Minimo"].ToString();
                txtComprobanteFin.Text = lectorNroComprobante["Maximo"].ToString();
                txtImporteComprobante.Text = lectorNroComprobante["Total"].ToString();
            }
            lectorNroComprobante.Close();


            txtSencilloEgreso.Text = fn.selectValue("select sum(monto) from salidadinero where IDCaja = '" + idCaja + "'");
            calcularSencillo();
        }

        private void FrmCuadreManualVS_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Cajera", "IDCajera", "Cajera where Habilitado = 1", cboCajera);
        }
    }
}
