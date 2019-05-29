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

namespace SwJugueriaAgustin.Formularios.Administracion
{
    public partial class FrmRAdministrativo : Form
    {
        Funciones fn = new Funciones();
        public FrmRAdministrativo()
        {
            InitializeComponent();
        }

        

        private void FrmRAdministrativo_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                    //INGRESO
                    decimal total = 0;
                    fn.ActualizarGrid(dgvIngreso, "select tc.NombreComprobante as TipoComprobante,sum(v.Total) as Importe from venta v inner join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante where MONTH(v.Fecha) = "+(cbxMes.SelectedIndex + 1)+" and YEAR(v.Fecha) = "+txtAño.Text+" and v.Anulada = 0 group by tc.NombreComprobante");
                    foreach(DataGridViewRow rowIngreso in dgvIngreso.Rows)
                    {
                        total += Convert.ToDecimal(rowIngreso.Cells["Importe"].Value);
                    }
                    lblIngresoTotal.Text = total.ToString("#,#.00");

                    

                    //******************** EGRESOS ********************
                    //EGRESO
                    decimal egreso =0;
                    fn.ActualizarGrid(dgvEgreso, "select te.TipoEgreso,te.Contable,sum(e.Monto) as Egreso from Egreso e inner join TipoEgreso te on e.IDTipoEgreso = te.IDTipoEgreso where MONTH(e.Fecha) = "+(cbxMes.SelectedIndex + 1)+" and YEAR(e.Fecha) = "+txtAño.Text+ " group by te.TipoEgreso,te.Contable");
                    foreach(DataGridViewRow rowEgreso in dgvEgreso.Rows)
                    {
                        if(Convert.ToBoolean(rowEgreso.Cells["Contable"].Value) == true)
                        {
                            egreso += Convert.ToDecimal(rowEgreso.Cells["Egreso"].Value);
                        }
                    }
                    lblEgresoTotal.Text = egreso.ToString("#,#.00");

                    //COMPRA
                    decimal compraLogistica = 0;
                    fn.ActualizarGrid(dgvCompraLogistica, "select tc.NombreComprobante as TipoComprobante,sum(c.Total) as Importe from Compra c left join TipoComprobante tc on c.IDTipoComprobante = tc.IDTipoComprobante inner join RegistroCompra rc on c.IDRegistroCompra = rc.IDRegistroCompra where rc.Mes = '"+cbxMes.Text+"' and rc.Año = '"+txtAño.Text+"' group by tc.NombreComprobante");
                    foreach (DataGridViewRow rowCompra in dgvCompraLogistica.Rows)
                    {
                    compraLogistica += Convert.ToDecimal(rowCompra.Cells["Importe"].Value);
                    }
                    lblCompraLogistica.Text = compraLogistica.ToString("#,#.00");


                    //COMPRA
                    decimal compraContable = 0;
                    fn.ActualizarGrid(dgvCompraContable, "select tc.NombreComprobante as TipoComprobante,sum(c.Total) as Importe from CompraContable c left join TipoComprobante tc on c.IDTipoComprobante = tc.IDTipoComprobante inner join RegistroCompra rc on c.IDRegistroCompra = rc.IDRegistroCompra where rc.Mes = '" + cbxMes.Text + "' and rc.Año = '" + txtAño.Text + "' group by tc.NombreComprobante");
                    foreach (DataGridViewRow rowCompra in dgvCompraContable.Rows)
                    {
                    compraContable += Convert.ToDecimal(rowCompra.Cells["Importe"].Value);
                    }
                    lblCompraContable.Text = compraContable.ToString("#,#.00");

                lblTotalCompra.Text = (compraContable + compraLogistica).ToString("#,#.00");

                lblRIngreso.Text = total.ToString("#,#.00");
                lblRSalida.Text = (egreso + compraContable + compraLogistica).ToString("#,#.00");
                lblRDiferencia.Text = (total - (egreso + compraContable + compraLogistica)).ToString("#,#.00");

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
