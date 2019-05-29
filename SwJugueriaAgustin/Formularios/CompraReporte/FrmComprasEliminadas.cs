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
    public partial class FrmComprasEliminadas : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmComprasEliminadas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fn.ActualizarGrid(dgvDetalle, "select ce.Fecha,ce.Hora,tc.NombreComprobante as TipoComprobante,ce.Serie,ce.Numero,ce.Proveedor,ce.Total,u.Nombres as Responsable from CompraEliminada ce inner join TipoComprobante tc on ce.IDTipoComprobante = tc.IDTipoComprobante inner join Usuario u on ce.IDUsuario = u.IDUsuario where ce.Fecha between '"+dtpFecha.Value.ToShortDateString()+"' and '"+dtpFin.Value.ToShortDateString()+"' and tc.NombreComprobante like '%"+cbxTipoComp.Text+"%'");
        }

        private void FrmComprasEliminadas_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("NombreComprobante","IDTipoComprobante", "TipoComprobante",cbxTipoComp);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            
            ex.exportaraexcel(dgvDetalle);
        }
    }
}
