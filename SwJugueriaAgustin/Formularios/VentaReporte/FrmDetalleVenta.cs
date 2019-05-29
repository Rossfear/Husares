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
    public partial class FrmDetalleVenta : Form
    {
        public FrmDetalleVenta()
        {
            InitializeComponent();
        }
        public static string IDVenta;
        Clases.Funciones fn = new Clases.Funciones();
        private void FrmDetalleVenta_Load(object sender, EventArgs e)
        {
            fn.MostrarGri("s.SubCategoria,pr.Producto +' '+ p.Presentacion,dv.Cantidad,dv.Costo,dv.Precio",
                "Presentacion p,VentaDetalle dv,Categoria c,Venta v,Producto pr,SubCategoria s",
                "dv.IDPresentacion = p.IDPresentacion and dv.IDVenta = v.IDVenta and p.IDProducto = pr.IDProducto and pr.IDSubcategoria = s.IDSubCategoria and c.IDCategoria = s.IDCategoria and dv.IDVenta = '" + IDVenta + "'", dgvDetalleVenta, "DetalleVenta");


        }
    }
}
