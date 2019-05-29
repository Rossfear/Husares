using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class FrmDetalleCompra : Form
    {
        public FrmDetalleCompra()
        {
            InitializeComponent();
        }
        public string IDCompra;
        Clases.Funciones fn = new Clases.Funciones();

        private void FrmDetalleCompra_Load(object sender, EventArgs e)
        {
            fn.MostrarGri("i.Insumo,dc.Cantidad,dc.Costo,Afecto,cast(dc.Cantidad * dc.Costo as decimal(18,2)) as Importe",
                "DetalleCompra dc,Insumo i",
                "dc.IDInsumo = i.IDInsumo  AND IDCompra='" + IDCompra + "'", dgvDetalleCompra, "DetalleCompra");
        }
    }
}
