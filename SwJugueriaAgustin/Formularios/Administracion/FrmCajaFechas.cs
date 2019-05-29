using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Administracion
{
    public partial class FrmCajaFechas : Form
    {
        bool update;
        string ID;
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmCajaFechas()
        {
            InitializeComponent();

            KeyPreview = true;

            KeyDown += FrmTipoComprobante_KeyDown;
        }

        private void FrmTipoComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                enable(false);
                clean();
            }
        }

        private void FrmTipoComprobante_Load(object sender, EventArgs e)
        {
            int mes = DateTime.Now.Month;
            cbxMes.SelectedIndex = (mes - 1);

            enable(false);
            showData();
        }

        private void showData()
        {
            fn.ActualizarGrid(dgvDocumento, "select IDCajaFechas,Fecha,EfectivoDeposito,Tarjeta,Ticket,Total as TotalReal,TotalSistema,Comentario,u.Usuario from cajaFechas cf  left join Usuario u on cf.IDUsuario = u.IDUsuario where MONTH(fecha) = "+(cbxMes.SelectedIndex + 1)+" order by IDCajaFechas desc");
            dgvDocumento.Columns["IDCajaFechas"].Visible = false;

            double efectivoDeposito = 0, tarjeta = 0, ticket = 0, totalReal = 0, TotalSistema = 0;

            foreach (DataGridViewRow row in dgvDocumento.Rows)
            {
                efectivoDeposito += Convert.ToDouble(row.Cells["EfectivoDeposito"].Value);
                tarjeta += Convert.ToDouble(row.Cells["Tarjeta"].Value);
                ticket += Convert.ToDouble(row.Cells["Ticket"].Value);
                totalReal += Convert.ToDouble(row.Cells["TotalReal"].Value);
                TotalSistema += Convert.ToDouble(row.Cells["TotalSistema"].Value);
            }

            lblEfectivoDeposito.Text = efectivoDeposito.ToString("#,#.00");
            lblTarjeta.Text = tarjeta.ToString("#,#.00");
            lblTicket.Text = ticket.ToString("#,#.00");
            lblTotalReal.Text = totalReal.ToString("#,#.00");
            lblTotalSistema.Text = TotalSistema.ToString("#,#.00");
        }

        void enable(bool state)
        {
            gbxDatos.Enabled = state;
            btnGuardar.Enabled = state;
            btnNuevo.Enabled = !state;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            enable(true);
            dtpFecha.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            eGuardar();
        }

        private void eGuardar()
        {
            if (validationSave() == false)
            {
                return;
            }

            save();

            endSave();
        }

        private void endSave()
        {
            clean();
            showData();
            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtpFecha.Focus();
        }

        private void clean()
        {
            txtEfectivoDepostito.Text = "0";
            txtTarjeta.Text = "0";
            txtTicket.Text = "0";
            txtTotal.Text = "0";
            txtComantario.Text = "";
        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    fn.Modificar("CajaFechas", "Fecha='" + dtpFecha.Value.ToShortDateString() + "',EfectivoDeposito='" + fn.remplazarNulo(txtEfectivoDepostito.Text)+ "',Tarjeta='" +fn.remplazarNulo(txtTarjeta.Text)+ "',Ticket='" + fn.remplazarNulo(txtTicket.Text)+ "',Total='" + fn.remplazarNulo(txtTotal.Text)+ "',TotalSistema='"+fn.remplazarNulo(txtTotalSistema.Text)+"',Comentario='" + txtComantario.Text+"',IDUsuario='" + Datos.idUsuario + "'", "IDCajaFechas='" + ID + "'");
                }
                else
                {
                    fn.RegistrarOficial("CajaFechas", "Fecha,EfectivoDeposito,Tarjeta,Ticket,Total,TotalSistema,Comentario,IDUsuario",
                        "'" + dtpFecha.Value.ToShortDateString() + "','" + fn.remplazarNulo(txtEfectivoDepostito.Text) + "','" + fn.remplazarNulo(txtTarjeta.Text) + "','" + fn.remplazarNulo(txtTarjeta.Text) + "','" + fn.remplazarNulo(txtTotal.Text) + "','"+fn.remplazarNulo(txtTotalSistema.Text)+"','"+txtComantario.Text+"','" + Datos.idUsuario + "'");
                }

                update = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private bool validationSave()
        {
            if(fn.Existencia("*", "CajaFechas", "Fecha='"+DateTime.Now.ToShortDateString()+"'") == true)
            {
                MessageBox.Show("Caja con Fecha Especificada ya se Encuentra Registrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFecha.Focus();
                return false;
            }
            

            
            try
            {
                if (Convert.ToDouble(txtEfectivoDepostito.Text) < 0)
                {
                    MessageBox.Show("Total Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEfectivoDepostito.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Total Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEfectivoDepostito.Focus();
                return false;
            }




            DialogResult msj;

            if (update == true)
            {
                msj = MessageBox.Show("Desea Actualizar los datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                msj = MessageBox.Show("Desea Registrar los datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            if (msj == DialogResult.Cancel)
            {
                return false;
            }


            return true;
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dtpFecha.Value = Convert.ToDateTime(dgvDocumento.CurrentRow.Cells["Fecha"].Value);
                txtEfectivoDepostito.Text = dgvDocumento.CurrentRow.Cells["EfectivoDeposito"].Value.ToString();
                txtTarjeta.Text = dgvDocumento.CurrentRow.Cells["Tarjeta"].Value.ToString();
                txtTicket.Text = dgvDocumento.CurrentRow.Cells["Ticket"].Value.ToString();
                txtTotal.Text = dgvDocumento.CurrentRow.Cells["TotalReal"].Value.ToString();
                //txtTotalSistema.Text = dgvDocumento.CurrentRow.Cells["TotalSistema"].Value.ToString();
                txtComantario.Text = dgvDocumento.CurrentRow.Cells["Comentario"].Value.ToString();
                ID = dgvDocumento.CurrentRow.Cells["IDCajaFechas"].Value.ToString();

                update = true;

                enable(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            showData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            update = false;
            enable(false);
            clean();
        }

        private void dtpFechaBusqueda_ValueChanged(object sender, EventArgs e)
        {
            showData();
        }

        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) SendKeys.Send("{TAB}");
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                eGuardar();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (msj == DialogResult.OK)
            {
                FrmContraseña frm = new FrmContraseña();
                frm.ShowDialog();

                if (frm.cancel == false)
                {
                    fn.Eliminar("CajaFechas", "IDCajaFechas='" + dgvDocumento.CurrentRow.Cells["IDCajaFechas"].Value.ToString() + "'");
                }
                MessageBox.Show("Dato Eliminado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showData();
            }

        }

        private void dtpFechaBusqueda_ValueChanged_1(object sender, EventArgs e)
        {
            showData();
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            showData();
        }

        private void txtEfectivoDepostito_TextChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }

        void calcularTotal()
        {
            decimal comprobante=0, tarjeta=0, ticket=0,total;

            comprobante = Convert.ToDecimal(fn.remplazarNulo(txtEfectivoDepostito.Text));
            tarjeta = Convert.ToDecimal(fn.remplazarNulo(txtTarjeta.Text));
            ticket = Convert.ToDecimal(fn.remplazarNulo(txtTicket.Text));

            total = comprobante + tarjeta + ticket;

            txtTotal.Text = total.ToString("0.00");
        }

        private void txtTarjeta_TextChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void txtTicket_TextChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            txtTotalSistema.Text = fn.selectValue("select sum(v.Total) from Venta v inner join CAJA c on v.IDCaja = c.ID where v.Anulada = 0 and cast(c.FECHA_HORA as date) = '"+dtpFecha.Value.ToShortDateString()+"'");
            //double comprobanteTotal = 0;

            //double comprobanteManual = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(cm.FacturaMonto + cm.BoletaMonto) from CAJA ca inner join CajaManual cm on ca.ID = cm.IDCaja where cast(ca.FECHA_HORA as date) = '"+dtpFecha.Value.ToShortDateString()+"'")));
            //double comprobante = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(v.Total) from Venta v left join TipoComprobante tc on v.IDTipoCom = tc.IDTipoComprobante inner join CAJA c on v.IDCaja = c.ID where NombreComprobante != 'TICKET' and v.Anulada = 0 and cast(c.FECHA_HORA as date) = '" + dtpFecha.Value.ToShortDateString() + "'")));

            //comprobanteTotal = comprobanteManual + comprobante;



            //double tarjeta = Convert.ToDouble(fn.remplazarNulo(fn.selectValue("select sum(cm.Lote1Monto + cm.Lote2Monto  + cm.Lote3Monto + cm.Lote4Monto + cm.Lote5Monto)  from CAJA ca inner join CajaManual cm on ca.ID = cm.IDCaja  where cast(ca.FECHA_HORA as date) = '"+dtpFecha.Value.ToShortDateString()+"'")));
            //txtTarjeta.Text = tarjeta.ToString("0.00");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ex.exportaraexcelTimer(dgvDocumento,progressBar1);
        }
    }
}
