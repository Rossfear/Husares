using SwJugueriaAgustin.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class frmObservacionCompra : Form
    {
        Funciones fn = new Funciones();
        
        public frmObservacionCompra()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(fn.Existencia("*","Compra","IDCompra='"+txtCodCompra.Text+"'") == true)
            {
                SqlDataReader lector;
                lector = fn.selectMultiValues("select IDCompra as [ID],c.Fecha as [FECHA DE REGISTRO],c.FechaComprobante AS [FECHA COMPROBANTE],c.FechaVencimiento AS [FECHA VENCIMIENTO],t.NombreComprobante as COMPROBANTE,c.Hora AS [HORA DE REGISTRO],P.Numero AS [IDENTIFICACIÓN PROVEEDOR],P.RazonSocial AS [NOMBRE PROOVEEDOR],C.Serie AS [SERIE],C.Numero AS [NUMERO],C.Total AS [TOTAL],C.SubTotal AS [SUBTOTAL],C.Igv AS [IGV] from Compra c inner join Proveedor p on c.IDProveedor = p.IDProveedor inner join TipoComprobante t on c.TipoComprobante = t.IDTipoComprobante where IDCompra='" + txtCodCompra.Text + "'");
                lector.Read();

                lblComprobante.Text = lector[4].ToString();
                lblFecha.Text = Convert.ToDateTime(lector[1].ToString()).ToShortDateString();
                lblHora.Text = lector[5].ToString();
                lblProveedor.Text = lector[7].ToString();
                lblTotal.Text = lector["TOTAL"].ToString();
                lblSerie.Text = lector["SERIE"].ToString();
                lblNumero.Text = lector["NUMERO"].ToString();
                lector.Close();
            }
            else
            {
                MessageBox.Show("La Compra no Existe", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtObservacion.Text) == true)
            {
                MessageBox.Show("Ingrese motivo de cancelacion de la compra", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(fn.Existencia("*", "ObservacionCompra", "IDCompra='"+txtCodCompra.Text+"'") == true)
            {
                MessageBox.Show("La Compra ya fue Solicitada para Cancelación", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult msj = MessageBox.Show("Desea Solicitar la cancelación de Compra?", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(msj == DialogResult.OK)
                {
                    fn.Registrar("ObservacionCompra", "'"+DateTime.Now.ToShortDateString()+"','" + txtCodCompra.Text + "','" + txtObservacion.Text + "','" + Datos.idUsuario + "','False'");
                    MessageBox.Show("Solicitud de Cancelacion de la compra Enviada", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmObservacionCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
