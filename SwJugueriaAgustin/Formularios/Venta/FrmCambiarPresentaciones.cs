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

namespace SwJugueriaAgustin.Formularios.Operaciones
{
    public partial class FrmCambiarPresentaciones : Form
    {
        Funciones fn = new Funciones();
        public bool cambiarPresentacion = false;
        public string CodigoCambiado;

        public FrmCambiarPresentaciones()
        {
            InitializeComponent();
        }

        private void btnBoletaB_Click(object sender, EventArgs e)
        {
            selectComprobanteBuscar(btnBoletaB, btnFacturaB, btnTickeB);
        }

        void selectComprobanteBuscar(Button btnSelect, Button btnNoSelect1, Button btnNoSelect2)
        {
            try
            {
                btnSelect.BackColor = Color.Lime;
                btnNoSelect1.BackColor = Color.Gainsboro;
                btnNoSelect2.BackColor = Color.Gainsboro;

                txtTipoComprobante.Text = btnSelect.Text;

                if (btnSelect.Text == "T")
                {
                    txtSerie.Text = fn.selectValue("select NON_TABLA FROM GENERADOR WHERE COMPROBANTE ='TICKET'");
                }
                else if (btnSelect.Text == "B")
                {
                    txtSerie.Text = fn.selectValue("select NON_TABLA FROM GENERADOR WHERE COMPROBANTE ='COMPROBANTE'");
                }
                else if (btnSelect.Text == "F")
                {
                    txtSerie.Text = fn.selectValue("select NON_TABLA FROM GENERADOR WHERE COMPROBANTE ='COMPROBANTE'");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnFacturaB_Click(object sender, EventArgs e)
        {
            selectComprobanteBuscar(btnFacturaB, btnBoletaB, btnTickeB);
        }

        private void btnTickeB_Click(object sender, EventArgs e)
        {
            selectComprobanteBuscar(btnTickeB, btnFacturaB, btnBoletaB);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string idVenta = txtSerie.Text + " - " + txtNumero.Text;
                
                SqlDataReader lector = fn.selectMultiValues("select v.NombreCliente,c.Numero from venta v inner join Cliente c on v.IDCliente = c.IDCliente where IDVenta = '"+idVenta+"'");
                lector.Read();
                txtCliente.Text = lector["NombreCliente"].ToString();
                txtNroDocumento.Text = lector["Numero"].ToString();
                lector.Close();

                fn.ActualizarGrid(dgvDetalleVenta, "select dv.IDPresentacion as cnCodigo,dv.Presentacion as cnPresentacion,dv.Cantidad as cnCantidad,Precio as cnPrecio,(Cantidad * Precio) as cnImporte from DetalleVenta dv where IDVenta = '" + idVenta + "'");

                if(dgvDetalleVenta.Rows.Count > 0)
                {
                    CodigoCambiado = idVenta;
                    cambiarPresentacion = true;
                    this.Close();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNumero_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddCantidad frmCantidad = new frmAddCantidad();
                frmCantidad.ShowDialog();

                if (frmCantidad.Cancelado == false)
                {
                    txtNumero.Text = Convert.ToDecimal(frmCantidad.txtCantidad.Text).ToString("00000000");

                    //SqlDataReader readerVenta = fn.selectMultiValues("select * from venta where IDVenta = '" + idVenta + "'");
                    //readerVenta.Read();
                    //lblTipoPago.Text = readerVenta["TipoPago"].ToString();
                    //lblTotal.Text = readerVenta["Total"].ToString();
                    //readerVenta.Close();

                    //lblSerieActual.Text = txtSerie.Text;
                    //lblNumeroActual.Text = txtNumero.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            cambiarPresentacion = false;
            this.Close();
        }

        private void FrmCambiarPresentaciones_Load(object sender, EventArgs e)
        {
            if (Datos.sinTicket == true)
            {
                btnTickeB.Visible = false;
            }
            else
            {
                btnTickeB.Visible = true;
            }
        }
    }
}
