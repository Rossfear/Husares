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

namespace SwJugueriaAgustin.Formularios.Reportes
{
    public partial class FrmReportePedidos : Form
    {
        Funciones fn = new Funciones();
        public FrmReportePedidos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fn.MostrarGri("p.IDPedido as Cod,p.FechaEntrega,t.Almacen as AlmacenSolicitador,p.Comentario,u.Nombres as [Solicitador(a)] ",
                "Pedido p inner join Almacen t on p.IDAlmacenReceptor = t.IDAlmacen inner join Usuario u on p.IDUsuario = u.IDUsuario",
                "p.FechaEntrega between '" + dtpFecha.Value.ToShortDateString() + "' and '" + dtpFin.Value.ToShortDateString() + "'", dgvListaPedidos, "Pedido");
        }

        private void dgvListaPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string idPedido = dgvListaPedidos.CurrentRow.Cells[0].Value.ToString();
                FrmReporteAtencion frm = new FrmReporteAtencion();
                FrmReporteAtencion.idAtencion = fn.select_one_value("IDAtencion", "AtencionPedido", "IDPedido='" + idPedido + "'",0);
                frm.lblCodPedido.Text = idPedido;
                frm.ShowDialog();
            }

        }

        private void dgvListaPedidos_SelectionChanged(object sender, EventArgs e)
        {
            string idPedido = dgvListaPedidos.CurrentRow.Cells[0].Value.ToString();
            fn.MostrarGri("i.IDInsumo,i.Insumo,dp.Saldo,dp.Cantidad,um.UniMedida", "DetallePedido dp inner join Insumo i on dp.IDInsumo = i.IDInsumo inner join UnidadMedida um on i.IDUniMedida = um.IDUniMedida ", "IDPedido = '" + idPedido + "'", dgvListaInsumo, "DatellePedido");
            string idAlmacen = fn.select_one_value("IDAlmacen", "Almacen", "Almacen='" + dgvListaPedidos.CurrentRow.Cells[2].Value.ToString() + "'", 0);
        }

        private void FrmReportePedidos_Load(object sender, EventArgs e)
        {

        }
    }
}
