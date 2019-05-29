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

namespace SwJugueriaAgustin.Formularios
{
    public partial class frmRepVentaPresentFlujo : Form
    {
        public static string CodigoVenta, fecha_inicio;
        Funciones fn = new Funciones();
        public frmRepVentaPresentFlujo()
        {
            InitializeComponent();
        }

        private void frmRepVentaPresentFlujo_Load(object sender, EventArgs e)
        {

        }
        private void mostrarGrid(DataGridView grid, DateTimePicker fecha)
        {
            if (chbxCortesia.Checked == true)
            {
                fn.MostrarGri("p.Presentacion,sum(dv.Cantidad) as Cantidad",
                "DetalleVenta dv,venta v,Presentacion p",
                "v.Anulada = 'False' and dv.IDVenta = v.IDVenta and dv.IDPresentacion = p.IDPresentacion and  v.Fecha >= '" + fecha.Value.ToShortDateString() + "' and v.Fecha <= '" + fecha.Value.ToShortDateString() + "' group by dv.IDPresentacion,p.Presentacion having p.Presentacion like '%" + txtPresentacion.Text + "%'  order by sum(dv.Cantidad) desc ", grid, "DetalleVenta");
            }
            else
            {
                fn.MostrarGri("p.Presentacion,sum(dv.Cantidad) as Cantidad",
                    "DetalleVenta dv,venta v,Presentacion p,TipoPago tp",
                    "v.Anulada = 'False' and dv.IDVenta = v.IDVenta and dv.IDPresentacion = p.IDPresentacion and v.IDTipoPago = tp.IDTipoPago and  v.Fecha >= '" + fecha.Value.ToShortDateString() + "' and v.Fecha <= '" + fecha.Value.ToShortDateString() + "' and tp.TipoPago != 'CORTESIA' group by dv.IDPresentacion,p.Presentacion having p.Presentacion like '%" + txtPresentacion.Text + "%'  order by sum(dv.Cantidad) desc", grid, "DetalleVenta");
            }

        }

        private void fecha1_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(grid1, fecha1);
            DateTime fechainicial = fecha1.Value;
            fecha2.Value = fechainicial.AddDays(1);
            fecha3.Value = fechainicial.AddDays(2);
            fecha4.Value = fechainicial.AddDays(3);
            fecha5.Value = fechainicial.AddDays(4);
            fecha6.Value = fechainicial.AddDays(5);
            fecha7.Value = fechainicial.AddDays(6);
        }

        private void fecha2_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(grid2, fecha2);
        }

        private void fecha3_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(grid3, fecha3);
        }

        private void fecha4_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(grid4, fecha4);
        }

        private void fecha5_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(grid5, fecha5);
        }

        private void fecha6_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(grid6, fecha6);
        }

        private void fecha7_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(grid7, fecha7);
        }

        private void txtPresentacion_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void grid2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CodigoVenta = grid2.CurrentRow.Cells[0].Value.ToString();

                fecha_inicio = fecha2.Value.ToShortDateString();
                //     fecha_fin = grid1.CurrentRow.Cells[0].Value.ToString();

                Frm_deta_pedido dv = new Frm_deta_pedido();
                Frm_deta_pedido.IDVenta = CodigoVenta;
                Frm_deta_pedido.fecha_inicio = fecha_inicio;

                if (chbxCortesia.Checked == true)
                {
                    dv.conCortesia = true;
                }
                else
                {
                    dv.conCortesia = false;
                }
                dv.ShowDialog(this);
            }
        }

        private void grid3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CodigoVenta = grid3.CurrentRow.Cells[0].Value.ToString();

                fecha_inicio = fecha3.Value.ToShortDateString();

                Frm_deta_pedido dv = new Frm_deta_pedido();
                Frm_deta_pedido.IDVenta = CodigoVenta;
                Frm_deta_pedido.fecha_inicio = fecha_inicio;

                if (chbxCortesia.Checked == true)
                {
                    dv.conCortesia = true;
                }
                else
                {
                    dv.conCortesia = false;
                }

                dv.ShowDialog(this);
            }
        }

        private void grid4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CodigoVenta = grid4.CurrentRow.Cells[0].Value.ToString();

                fecha_inicio = fecha4.Value.ToShortDateString();
                //     fecha_fin = grid1.CurrentRow.Cells[0].Value.ToString();

                Frm_deta_pedido dv = new Frm_deta_pedido();
                Frm_deta_pedido.IDVenta = CodigoVenta;
                Frm_deta_pedido.fecha_inicio = fecha_inicio;

                if (chbxCortesia.Checked == true)
                {
                    dv.conCortesia = true;
                }
                else
                {
                    dv.conCortesia = false;
                }

                dv.ShowDialog(this);
            }
        }

        private void grid5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CodigoVenta = grid5.CurrentRow.Cells[0].Value.ToString();

                fecha_inicio = fecha5.Value.ToShortDateString();
                //     fecha_fin = grid1.CurrentRow.Cells[0].Value.ToString();

                Frm_deta_pedido dv = new Frm_deta_pedido();
                Frm_deta_pedido.IDVenta = CodigoVenta;
                Frm_deta_pedido.fecha_inicio = fecha_inicio;

                if (chbxCortesia.Checked == true)
                {
                    dv.conCortesia = true;
                }
                else
                {
                    dv.conCortesia = false;
                }

                dv.ShowDialog(this);
            }
        }

        private void grid6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CodigoVenta = grid6.CurrentRow.Cells[0].Value.ToString();

                fecha_inicio = fecha6.Value.ToShortDateString();
                //     fecha_fin = grid1.CurrentRow.Cells[0].Value.ToString();

                Frm_deta_pedido dv = new Frm_deta_pedido();
                Frm_deta_pedido.IDVenta = CodigoVenta;
                Frm_deta_pedido.fecha_inicio = fecha_inicio;

                if (chbxCortesia.Checked == true)
                {
                    dv.conCortesia = true;
                }
                else
                {
                    dv.conCortesia = false;
                }

                dv.ShowDialog(this);
            }
        }

        private void grid7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CodigoVenta = grid7.CurrentRow.Cells[0].Value.ToString();

                fecha_inicio = fecha7.Value.ToShortDateString();
                //     fecha_fin = grid1.CurrentRow.Cells[0].Value.ToString();

                Frm_deta_pedido dv = new Frm_deta_pedido();
                Frm_deta_pedido.IDVenta = CodigoVenta;
                Frm_deta_pedido.fecha_inicio = fecha_inicio;

                if (chbxCortesia.Checked == true)
                {
                    dv.conCortesia = true;
                }
                else
                {
                    dv.conCortesia = false;
                }

                dv.ShowDialog(this);
            }
        }

        private void chbxCortesia_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrarGrid(grid1, fecha1);
            mostrarGrid(grid2, fecha2);
            mostrarGrid(grid3, fecha3);
            mostrarGrid(grid4, fecha4);
            mostrarGrid(grid5, fecha5);
            mostrarGrid(grid6, fecha6);
            mostrarGrid(grid7, fecha7);
        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CodigoVenta = grid1.CurrentRow.Cells[0].Value.ToString();

                fecha_inicio = fecha1.Value.ToShortDateString();
                //     fecha_fin = grid1.CurrentRow.Cells[0].Value.ToString();

                Frm_deta_pedido dv = new Frm_deta_pedido();
                Frm_deta_pedido.IDVenta = CodigoVenta;
                Frm_deta_pedido.fecha_inicio = fecha_inicio;

                if (chbxCortesia.Checked == true)
                {
                    dv.conCortesia = true;
                }
                else
                {
                    dv.conCortesia = false;
                }

                dv.ShowDialog(this);
            }
        }
    }
}
