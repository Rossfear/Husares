using SwJugueriaAgustin.Clases;
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
    public partial class FrmSalidaDinero : Form
    {
        bool editar;
        string idSalida, idCaja;
        Funciones fn = new Funciones();

        public FrmSalidaDinero()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string tipo = "";

            if (rbtnVentaSalon.Checked == true)
            {
                tipo = "VENTA SALON";
            }
            else if (rbtnVentaDelivery.Checked == true)
            {
                tipo = "DELIVERY";
            }

            idCaja = fn.select_one_value("MAX(ID)", "Caja", "Tipo = '" + tipo + "' and IDSucursal = '"+Datos.idSucursal+"'", 0);

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
                    fn.RegistrarOficial("SalidaDinero", "Hora,MotivoSalida,Monto,IDCaja,Entrada", "'" + hora + "','" + txtMotivo.Text + "','" + txtMonto.Text + "','" + idCaja + "','"+rbtnIngreso.Checked+"'");
                }
                else
                { return; }

            }
            else
            {
                DialogResult msj = MessageBox.Show("Desea Actualizar la Salida de Dinero", "Factu-TED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msj == DialogResult.OK)
                {
                    fn.Modificar("SalidaDinero", "Hora='" + hora + "',MotivoSalida='" + txtMotivo.Text + "',Monto='" + txtMonto.Text + "',IDCaja='" + idCaja + "',Entrada='"+rbtnIngreso.Checked+"'", "IDSalidaDinero='" + idSalida + "'");
                    editar = false;
                }
                else
                { return; }
            }
            mostrarGrid();
            limpiar();
        }

        private void limpiar()
        {
            txtMonto.Text = "0";
            txtMotivo.Text = "";
            _enable(false);
        }

        private void mostrarGrid()
        {
            string tipo = rbtnVentaSalon.Checked ? "VENTA SALON" : "DELIVERY";

            DataTable tabla = new DataTable();
            SqlCommand cmd = fn.procedimientoAlmacenado("Caja_MovimientoDinero_Listar");
            cmd.Parameters.AddWithValue("@IDSucursal",Datos.idSucursal);
            cmd.Parameters.AddWithValue("@Tipo", tipo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            dgvSalidaDinero.DataSource = tabla;


            double ingreso = 0,egreso =0;
            foreach (DataGridViewRow fila in dgvSalidaDinero.Rows)
            {
                double monto = Convert.ToDouble(fila.Cells["Monto"].Value);

                if (fila.Cells["Movimiento"].Value.ToString().Equals("INGRESO"))
                {
                    ingreso += monto;
                }
                else
                {
                    egreso += monto;
                }
            }

            lblIngreso.Text = ingreso.ToString("0.00");
            lblEgreso.Text = egreso.ToString("0.00");
        }

        private void FrmSalidaDinero_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            editar = false;

            //BLOQUEAR
            _enable(false);
        }

        private void _enable(bool state)
        {
            gbxData.Enabled = state;
            BtnNuevo.Enabled = !state;
            BtnGuardar.Enabled = state;
            BtnCancelar.Enabled = state;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _enable(true);
            txtMotivo.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            _enable(false);
            editar = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void rbtnVentaSalon_CheckedChanged(object sender, EventArgs e)
        {
            
            try
            {
                string tipo = rbtnVentaSalon.Checked ? "VENTA SALON" : "DELIVERY";
                lblFechaCaja.Text = Convert.ToDateTime(fn.selectValue("select top(1) cast(FECHA_HORA as date) as Fecha from caja where Tipo='" + tipo + "' and IDSucursal = '" + Datos.idSucursal + "' order by id desc")).ToShortDateString();
            }
            catch
            {
            }
            finally
            {
                mostrarGrid();
            }
            
            
        }



        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idSalida = dgvSalidaDinero.CurrentRow.Cells["Codigo"].Value.ToString();
            txtMonto.Text = dgvSalidaDinero.CurrentRow.Cells["Monto"].Value.ToString();
            txtMotivo.Text = dgvSalidaDinero.CurrentRow.Cells["MotivoSalida"].Value.ToString();
            rbtnIngreso.Checked = dgvSalidaDinero.CurrentRow.Cells["Movimiento"].Value.ToString().Equals("ENTRADA");
            rbtnEgreso.Checked = dgvSalidaDinero.CurrentRow.Cells["Movimiento"].Value.ToString().Equals("SALIDA");
            editar = true;
            _enable(true);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fn.selectValue("select Estado from caja where id = '" + fn.select_one_value("MAX(ID)", "Caja", "Tipo = '" + (rbtnVentaSalon.Checked ? "VENTA SALON" : "DELIVERY") + "' and IDSucursal = '" + Datos.idSucursal + "'", 0) + "'") == "CERRADA")
            {
                MessageBox.Show("La Caja Seleccionada ya se Encuentra Cerrada", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult msj = MessageBox.Show("Desea Eliminar el movimiento seleccionada","FactuTED",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

            if(msj == DialogResult.OK)
            {
                fn.Eliminar("SalidaDinero","IDSalidaDinero = '"+ dgvSalidaDinero.CurrentRow.Cells["Codigo"].Value.ToString() + "'");
                mostrarGrid();
            }
        }

        private bool validacionGuardar(string idcaja)
        {
            if (rbtnVentaDelivery.Checked == false && rbtnVentaSalon.Checked == false)
            {
                MessageBox.Show("Seleccione Tipo de Caja", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(fn.selectValue("select Estado from caja where id = '"+idcaja+"'") == "CERRADA")
            {
                MessageBox.Show("La Caja Seleccionada ya se Encuentra Cerrada", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
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
    }
}
