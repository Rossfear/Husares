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

namespace SwJugueriaAgustin.Formularios.Configuracion
{
    public partial class FrmConfigurarCaja : Form
    {
        Funciones fn = new Funciones();
        string idCaja, idSalida;
        bool editar;


        public FrmConfigurarCaja()
        {
            InitializeComponent();
        }

        private void FrmConfigurarCaja_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal","IDSucursal","Sucursal",cboSucursal);
        }

        private void _enable(bool state)
        {
            gbxData.Enabled = state;
            BtnNuevo.Enabled = !state;
            BtnGuardar.Enabled = state;
            BtnCancelar.Enabled = state;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlDataReader lector = fn.selectMultiValues("select * from caja where Tipo='"+cboTipo.Text+"' and IDSucursal='"+cboSucursal.SelectedValue+"' and cast(Fecha_Hora as date) = '"+dtpFecha.Value.ToShortDateString()+"'");
            while(lector.Read())
            {
                idCaja = lector["ID"].ToString();
                txtFecha.Text = Convert.ToDateTime(lector["Fecha_Hora"]).ToString();
                txtTipo.Text = lector["Tipo"].ToString();
                txtSucursal.Text = fn.selectValue("select Sucursal from sucursal where IDSucursal = '"+ lector["IDSucursal"].ToString()+"'");
                txtSaldoInicial.Text = lector["SaldoInicial"].ToString();

                txtTarjeta1.Text = lector["Tarjeta1"].ToString();
                txtTarjeta1Monto.Text = lector["Tarjeta1Monto"].ToString();
                txtTarjeta2.Text = lector["Tarjeta2"].ToString();
                txtTarjeta2Monto.Text = lector["Tarjeta2Monto"].ToString();
                txtTarjeta3.Text = lector["Tarjeta3"].ToString();
                txtTarjeta3Monto.Text = lector["Tarjeta3Monto"].ToString();
                txtTarjeta4.Text = lector["Tarjeta4"].ToString();
                txtTarjeta4Monto.Text = lector["Tarjeta4Monto"].ToString();

                txtTicketManual.Text = lector["TicketMan"].ToString();
                txtBoletaManual.Text = lector["BoletaMan"].ToString();
                txtFacturaMan.Text = lector["FacturaMan"].ToString();

                txtTotalCierre.Text = lector["TotalCierre"].ToString();

            }
            lector.Close();


            mostrarGridSalidaDinero();
        }

        private void btnMidificar_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Desea Actualizar la Caja","FactuTED",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                fn.Modificar("Caja",
                "SaldoInicial='" + fn.remplazarNulo(txtSaldoInicial.Text) + "',TicketMan='" + fn.remplazarNulo(txtTicketManual.Text) + "',BoletaMan='" + fn.remplazarNulo(txtBoletaManual.Text) + "',FacturaMan='" + fn.remplazarNulo(txtFacturaMan.Text) + "',Tarjeta1='" + txtTarjeta1.Text + "',Tarjeta2='" + txtTarjeta2.Text + "',Tarjeta3='" + txtTarjeta3.Text + "',Tarjeta4='" + txtTarjeta4.Text + "',Tarjeta1Monto='" + fn.remplazarNulo(txtTarjeta1Monto.Text) + "',Tarjeta2Monto='" + fn.remplazarNulo(txtTarjeta2Monto.Text) + "',Tarjeta3Monto='" + fn.remplazarNulo(txtTarjeta3Monto.Text) + "',Tarjeta4Monto='" + fn.remplazarNulo(txtTarjeta4Monto.Text) + "',TotalCierre='" + fn.remplazarNulo(txtTotalCierre.Text) + "'",
                "ID = '" + idCaja + "'");


                MessageBox.Show("Caja Actualizada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idSalida = dgvSalidaDinero.CurrentRow.Cells["Codigo"].Value.ToString();
            txtMonto.Text = dgvSalidaDinero.CurrentRow.Cells["Monto"].Value.ToString();
            txtMotivo.Text = dgvSalidaDinero.CurrentRow.Cells["MotivoSalida"].Value.ToString();
            editar = true;
            _enable(true);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _enable(true);
            txtMotivo.Focus();
        }

        private bool validacionGuardar(string idcaja)
        {
            try
            {
                if (Convert.ToDecimal(txtMonto.Text) < 0)
                {
                    MessageBox.Show("Monto Incorrecto", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Monto Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtMotivo.Text) == true)
            {
                MessageBox.Show("Ingrese el Motivo de Salida", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return false;
            }

            return true;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (validacionGuardar(idCaja) == false)
            {
                return;
            }



            string hora = DateTime.Now.ToLongTimeString();
            if (editar == false)
            {
                DialogResult msj = MessageBox.Show("Desea Guardar la Salida de Dinero", "Factu-TED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msj == DialogResult.OK)
                {
                    fn.RegistrarOficial("SalidaDinero", "Hora,MotivoSalida,Monto,IDCaja", "'" + hora + "','" + txtMotivo.Text + "','" + txtMonto.Text + "','" + idCaja + "'");
                }
                else
                { return; }

            }
            else
            {
                DialogResult msj = MessageBox.Show("Desea Actualizar la Salida de Dinero", "Factu-TED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msj == DialogResult.OK)
                {
                    fn.Modificar("SalidaDinero", "Hora='" + hora + "',MotivoSalida='" + txtMotivo.Text + "',Monto='" + txtMonto.Text + "',IDCaja='" + idCaja + "'", "IDSalidaDinero='" + idSalida + "'");
                    editar = false;
                }
                else
                { return; }
            }
            mostrarGridSalidaDinero();
            limpiar();
        }

        private void limpiar()
        {
            txtMonto.Text = "0";
            txtMotivo.Text = "";
            _enable(false);
        }

        private void mostrarGridSalidaDinero()
        {
            fn.ActualizarGrid(dgvSalidaDinero, "select sd.IDSalidaDinero as Codigo,CAST(c.FECHA_HORA as date) as Fecha,sd.Hora,sd.MotivoSalida,sd.Monto from SalidaDinero sd inner join CAJA c on sd.IDCaja = c.ID where sd.IDCaja = '" + idCaja + "'");
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
