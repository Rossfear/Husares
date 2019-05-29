using SwJugueriaAgustin.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Administracion
{
    public partial class FrmCerrarCajaAdministracion : Form
    {
        bool existeCaja = false;
        string idCaja;
        Funciones fn = new Funciones();
        
        public FrmCerrarCajaAdministracion()
        {
            InitializeComponent();
        }

        private void FrmCerrarCajaAdministracion_Load(object sender, EventArgs e)
        {
            if (fn.Existencia("*", "CajaAdministracion", "idCaja > 0")) existeCaja = true;

            if(existeCaja == true)
            {
                SqlDataReader lectorCaja = fn.selectMultiValues("select top(1) * from cajaAdministracion order by IDCaja");
                lectorCaja.Read();
                idCaja = lectorCaja["IDCaja"].ToString();
                txtRFechaCaja.Text = Convert.ToDateTime(lectorCaja["FechaApertura"].ToString()).ToShortDateString();
                txtEstado.Text = lectorCaja["Estado"].ToString();
                txtRSaldoInicial.Text = lectorCaja["SaldoInicial"].ToString();

                if (txtEstado.Text == "CERRADA")
                {
                    txtRSaldoReal.Text = lectorCaja["SaldoFinal"].ToString();
                    txtDescripcion.Text = lectorCaja["Descripcion"].ToString();
                    txtRSaldoReal.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    btnAbrirCaja.Enabled = false;
                }

                lectorCaja.Close();


                //INGRESO***************************
                fn.ActualizarGrid(dgvIngreso, "select ti.TipoIngreso,sum(i.Monto) as Importe from ingreso i left join TipoIngreso ti on i.IDTipoIngreso = ti.IDTipoIngreso where i.Fecha  = '"+txtRFechaCaja.Text+"' group by ti.TipoIngreso");

                double ingreso = 0;
                foreach (DataGridViewRow rowIngreso in dgvIngreso.Rows)
                {
                    ingreso += Convert.ToDouble(rowIngreso.Cells["Importe"].Value);
                }

                txtIngreso.Text = ingreso.ToString("#,#.00");
                txtRIngreso.Text = ingreso.ToString("#,#.00");

                //EGRESO*****************************
                fn.ActualizarGrid(dgvEgreso, "select ti.TipoEgreso,sum(i.Monto) as Importe  from Egreso i  left join TipoEgreso ti on i.IDTipoEgreso = ti.IDTipoEgreso  where i.Fecha  = '"+txtRFechaCaja.Text+"'  group by ti.TipoEgreso");
                double egreso = 0;
                foreach (DataGridViewRow rowEgreso in dgvEgreso.Rows)
                {
                    egreso += Convert.ToDouble(rowEgreso.Cells["Importe"].Value);
                }

                txtEgreso.Text = egreso.ToString("#,#.00");
                txtREgreso.Text = egreso.ToString("#,#.00");

                double saldoInical = Convert.ToDouble(txtRSaldoInicial.Text);
                txtRSaldoFinal.Text = (saldoInical + ingreso - egreso).ToString("#,#.00");

               
            }
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if(validacionCerrar() == false)
            {
                return;
            }

            cerrarCaja();

            endSave();
        }

        private void endSave()
        {
            MessageBox.Show("Caja Administrativa Cerrada","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void cerrarCaja()
        {
            fn.Modificar("CajaAdministracion", "SaldoFinal='"+txtRSaldoReal.Text+"',Descripcion='"+txtDescripcion.Text+"',Estado='CERRADA'","IDCaja = '"+idCaja+"'");
        }

        private bool validacionCerrar()
        {
            try
            {
                Convert.ToDouble(txtRSaldoReal.Text);
            }
            catch
            {
                MessageBox.Show("Saldo Real Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRSaldoReal.Focus();
                return false;
            }

            DialogResult ms = MessageBox.Show("Desea Cerrar la Caja","FactuTED",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if(ms == DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }
    }
}
