using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin
{
    public partial class Frm_deta_pedido : Form
    {
        public bool conCortesia = false;
        public static string IDVenta,fecha_inicio;
        Clases.Funciones fn = new Clases.Funciones();
        public Frm_deta_pedido()
        {
            InitializeComponent();
        }

        private void Frm_deta_pedido_Load(object sender, EventArgs e)
        {
            if (conCortesia == true)
            {
                fn.MostrarGri("p.Presentacion,SUM(DV.Cantidad) AS Cantidad,T.TipoPago",
             "DetalleVenta dv inner join venta v on dv.IDVenta=v.IDVenta 	inner join Presentacion p on dv.IDPresentacion = p.IDPresentacion INNER JOIN TipoPago T ON V.IDTipoPago=T.IDTipoPago",
             "v.Fecha ='" + fecha_inicio + "'   group by dv.IDPresentacion,p.Presentacion,T.TipoPago having   p.Presentacion ='" + IDVenta + "' ", dataGridView1, "DetalleVenta");
            }
            else
            {
                fn.MostrarGri("p.Presentacion,sum(dv.Cantidad) as Cantidad,tp.TipoPago",
                    "DetalleVenta dv,venta v,Presentacion p,TipoPago tp",
                    "dv.IDVenta = v.IDVenta and dv.IDPresentacion = p.IDPresentacion and v.IDTipoPago = tp.IDTipoPago and  v.Fecha >= '" + fecha_inicio + "' and v.Fecha <= '" + fecha_inicio + "' and tp.TipoPago != 'CORTESIA' group by dv.IDPresentacion,p.Presentacion ,tp.TipoPago having p.Presentacion like '%" + IDVenta + "%'  order by sum(dv.Cantidad) desc", dataGridView1, "DetalleVenta");
            }

        }
    }
}
