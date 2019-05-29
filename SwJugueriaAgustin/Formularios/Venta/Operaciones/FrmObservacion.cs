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

namespace SwJugueriaAgustin.Formularios
{
    public partial class FrmObservacion : Form
    {
        Funciones fn = new Funciones();
        Datos d = new Datos();
        public FrmObservacion()
        {
            InitializeComponent();
        }

        private void txtSerie_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtNumero.Text = Convert.ToDecimal(txtNumero.Text).ToString("00000000");

            //Verificamos si la venta existe
            if (fn.Existencia("*", "Venta", "IDVenta='" + txtSerie.Text + lblguion.Text + txtNumero.Text + "'") == false)
            {
                MessageBox.Show("La Venta Buscada NO EXISTE. Verificar el Ingreso de Datos", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNumero.Text == "" || txtSerie.Text == "")
            {
                MessageBox.Show("Ingrese Datos", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlConnection conexion = new SqlConnection(Funciones.preconex);

                try
                {
                    string oncod = "SELECT * FROM Venta WHERE IDVenta='" + txtSerie.Text + lblguion.Text + txtNumero.Text + "'";
                    SqlCommand cmd = new SqlCommand(oncod, conexion);
                    conexion.Open();
                    SqlDataReader lector = cmd.ExecuteReader();
                    lector.Read();
                    lblCliente.Text = lector["NombreCliente"].ToString();
                    lblFecha.Text = lector["Fecha"].ToString();
                    lblHora.Text = lector["Hora"].ToString();
                    lblTotal.Text = lector["Total"].ToString();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexion.Close();

                }
            }
        }

        private void txtNumero_Click(object sender, EventArgs e)
        {
            frmAddCantidad frm = new frmAddCantidad();
            frm.ShowDialog();
            if (frm.Cancelado == false)
            {
                txtNumero.Text = Convert.ToDecimal(frm.txtCantidad.Text).ToString("0000000000");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string idVenta = txtSerie.Text + lblguion.Text + txtNumero.Text;
                //Verificamos si la venta existe
                if (fn.Existencia("*", "Venta", "IDVenta='" + idVenta + "'") == false)
                {
                    MessageBox.Show("La Venta Buscada NO EXISTE. Verificar el Ingreso de Datos", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (string.IsNullOrEmpty(txtObservacion.Text) == true)
                {
                    MessageBox.Show("Especificar Motivo de Anulación", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (fn.Existencia("*", "Venta", "IDVenta= '" + idVenta + "' and Anulada='True'") == true)
                {
                    MessageBox.Show("La Venta ya se encuetra ANULADA", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //VERIFICAMOS SI LA OBSERVACION YA SE ENCUENTRA REGISTRADA
                if (fn.Existencia("*", "observacion", "IDVenta='" + idVenta + "' and Atendido='False'") == true)
                {
                    MessageBox.Show("La Venta ya se Encueentra Solicitada para la Anulación", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    fn.Registrar("Observacion", "'" + DateTime.Now.ToShortDateString() + "','" + txtSerie.Text + lblguion.Text + txtNumero.Text + "','" + txtObservacion.Text + "','" + Datos.idUsuario + "','False'");
                    MessageBox.Show("Solicitud de Anulación Enviada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmObservacion_Load(object sender, EventArgs e)
        {

        }
    }
}
