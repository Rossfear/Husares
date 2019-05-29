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
    public partial class FrmListaCompras : Form
    {
        public FrmListaCompras()
        {
            InitializeComponent();
        }
        Clases.Funciones fn = new Clases.Funciones();
        Clases.exportador ex = new Clases.exportador();
        private void CargarGrid()
        {
            fn.MostrarGri("IDCompra as [ID],c.Fecha as [FECHA DE REGISTRO],c.FechaComprobante AS [FECHA COMPROBANTE],c.FechaVencimiento AS [FECHA VENCIMIENTO],t.NombreComprobante as COMPROBANTE,c.Hora AS [HORA DE REGISTRO],P.Numero AS [IDENTIFICACIÓN PROVEEDOR],P.RazonSocial AS [NOMBRE PROOVEEDOR],C.Serie AS [SERIE],C.Numero AS [NUMERO],C.Total AS [TOTAL],C.SubTotal AS [SUBTOTAL],C.Igv AS [IGV]  ",
                "Compra c inner join Proveedor p on c.IDProveedor = p.IDProveedor inner join TipoComprobante t on c.TipoComprobante = t.IDTipoComprobante", 
                "IDCompra!=0", 
                dgvCompras, "Compra");
        }
        private void FrmListaCompras_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl_CONDICION("NombreComprobante", "TipoComprobante", "IDTipoComprobante > 0",0, cbxTipoComprobante);
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen", cbxAlmacen);
            
            
        }

        private void txtCodVenta_KeyDown(object sender, KeyEventArgs e)
        {
            mostrarGrid();
        }

        private void dtpFecha2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarFecha();
            }
        }
        private void BuscarFecha()
        {
            fn.MostrarGri("IDCompra as [ID],c.Fecha as [FECHA DE REGISTRO],c.FechaComprobante AS [FECHA COMPROBANTE],c.FechaVencimiento AS [FECHA VENCIMIENTO],t.NombreComprobante as COMPROBANTE,c.Hora AS [HORA DE REGISTRO],P.Numero AS [IDENTIFICACIÓN PROVEEDOR],P.RazonSocial AS [NOMBRE PROOVEEDOR],C.Serie AS [SERIE],C.Numero AS [NUMERO],C.Total AS [TOTAL],C.SubTotal AS [SUBTOTAL],C.Igv AS [IGV],c.Cancelada",
                "Compra c inner join Proveedor p on c.IDProveedor = p.IDProveedor inner join TipoComprobante t on c.TipoComprobante = t.IDTipoComprobante", 
                "c.Fecha between '"+dtpFecha.Value.ToShortDateString()+"' and '"+dtpFecha2.Value.ToShortDateString()+"'", dgvCompras, "Compra");
        }

        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarFecha();
            }
        }

        private void dgvCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmDetalleCompra frm = new FrmDetalleCompra();
                frm.IDCompra = dgvCompras.CurrentRow.Cells["Codigo"].Value.ToString();
                frm.ShowDialog(this);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void dtpFecha2_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void mostrarGrid()
        {
            string tipoComprobante;
            if (cbxTipoComprobante.Text == "BOLETA Y FACTURA")
            {
                tipoComprobante = " and tc.NombreComprobante = 'BOLETA' OR tc.NombreComprobante = 'FACTURA'";
            }
            else
            {
                tipoComprobante = " and tc.NombreComprobante like '%" + cbxTipoComprobante.Text + "%'";
            }

            fn.ActualizarGrid(dgvCompras, "select ROW_NUMBER() over(order by c.IDCompra) as Item,a.Almacen,c.FechaEmision,c.FechaVencimiento,tc.NombreComprobante as TipoComprobante,tc.Codigo,c.Serie,c.Numero as Correlativo,td.Tipo,p.Numero,p.RazonSocial as Denominacion,c.Moneda,c.TipoCambio,c.Impuesto,c.BaseGravada,c.Igv,c.BaseNoGravada,c.ISC,c.OtrosTributos,c.Descuento,c.Total,c.AumentaStock from Compra c left join TipoComprobante tc on c.IDTipoComprobante = tc.IDTipoComprobante left join Proveedor p on c.IDProveedor = p.IDProveedor left join TipoDocumento td on p.IDTipoDocumento = td.IDTipoDocumento left join Almacen a on c.IDAlmacen = c.IDAlmacen left join Usuario u on c.IDUsuario = u.IDUsuario where c.FechaEmision between '" + dtpFecha.Value.ToShortDateString() + "' and '" + dtpFecha2.Value.ToShortDateString() + "' and c.Serie like '%" + txtSerie.Text + "%' and c.Numero like '%" + txtNumero.Text + "%' and a.Almacen like '%" + cbxAlmacen.Text + "%' " + tipoComprobante + "");

            SqlDataReader lectorFactura = fn.selectMultiValues("select sum(c.BaseGravada) as BaseGravada,sum(c.Igv) as IGV,sum(c.BaseNoGravada) as NoGravada,sum(c.ISC) as Isc,sum(c.OtrosTributos) as OtrosTributos,sum(c.Descuento) as Descuento,sum(c.Total) as Total from Compra c left join TipoComprobante tc on c.IDTipoComprobante = tc.IDTipoComprobante left join Proveedor p on c.IDProveedor = p.IDProveedor left join TipoDocumento td on p.IDTipoDocumento = td.IDTipoDocumento left join Almacen a on c.IDAlmacen = c.IDAlmacen left join Usuario u on c.IDUsuario = u.IDUsuario where c.FechaEmision between '" + dtpFecha.Value.ToShortDateString() + "' and '" + dtpFecha2.Value.ToShortDateString() + "' and c.Serie like '%" + txtSerie.Text + "%' and c.Numero like '%" + txtNumero.Text + "%' and a.Almacen like '%" + cbxAlmacen.Text + "%' " + tipoComprobante + "");
            lectorFactura.Read();
            lblDescuento.Text = lectorFactura["Descuento"].ToString();
            lblGravada.Text = lectorFactura["BaseGravada"].ToString();
            lblIgv.Text = lectorFactura["igv"].ToString();
            lblIsc.Text = lectorFactura["isc"].ToString();
            lblNoGravada.Text = lectorFactura["noGravada"].ToString();
            lblOtrosTributos.Text = lectorFactura["OtrosTributos"].ToString();
            lblTotal.Text = lectorFactura["total"].ToString();
            lectorFactura.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esto puedo tardar unos Minutos. Seleccione Aceptar para continuar", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ex.exportaraexcel(dgvCompras);
        }
    }
}
