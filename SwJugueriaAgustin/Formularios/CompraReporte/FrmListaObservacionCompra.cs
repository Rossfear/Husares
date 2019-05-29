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

namespace SwJugueriaAgustin.Formularios.Compra_Reporte
{
    public partial class FrmListaObservacionCompra : Form
    {
        Funciones fn = new Funciones();
        public FrmListaObservacionCompra()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fn.ActualizarGrid(dgvSalida,"select co.Atendido,co.FechaSolicitud,p.RazonSocial,tc.NombreComprobante as TipoComprobante,c.Serie,c.Numero,c.Total from CompraObservacion co inner join Compra c on co.IDCompra = c.IDCompra inner join Usuario u on co.IDEmpleado = u.IDUsuario inner join TipoComprobante tc on c.IDTipoComprobante = tc.IDTipoComprobante inner join Proveedor p on c.IDProveedor = p.IDProveedor where co.Atendido = 'False' and co.FechaSolicitud between '"+dtpFechaInicio.Value.ToShortDateString()+"' and '"+dtpFechaFin.Value.ToShortDateString()+"'");
        }

        private void frmReporteObservacionesVenta_Load(object sender, EventArgs e)
        {
            //fn.añadir_ddl("Usuario", "IDUsuario", "Usuario", cbxUsuario);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            ex.exportaraexcel(dgvSalida);
        }
    }
}
