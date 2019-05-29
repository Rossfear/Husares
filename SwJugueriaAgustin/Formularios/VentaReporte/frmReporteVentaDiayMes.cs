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

namespace SwJugueriaAgustin.Formularios
{
    public partial class frmReporteVentaDiayMes : Form
    {
        Funciones fn = new Funciones();
        public frmReporteVentaDiayMes()
        {
            InitializeComponent();
        }

        private void mostrarGrid(DataGridView dgv,DateTimePicker fechainicio,DateTimePicker fechafin,Label ventas,Label lblresumenventa,GroupBox gbx)
        {
            fn.MostrarGri("CAST(c.FECHA_HORA as date) as Fecha,sum(v.total) as Venta",
                         "Venta v, CAJA c",
                         "v.anulada = 'False' and v.IDCaja = c.ID group by CAST(c.FECHA_HORA as date) having CAST(c.FECHA_HORA as date) between '"+fechainicio.Value.ToShortDateString()+"' and '"+fechafin.Value.ToShortDateString() + "'", dgv, "Venta");

            SqlDataReader lector;
            lector = fn.selectMultiValues("select sum(v.Total) as venta from Venta v, CAJA c where v.IDCaja = c.ID and CAST(c.FECHA_HORA as date) between '"+fechainicio.Value.ToShortDateString() + "' and '"+fechafin.Value.ToShortDateString() + "' and v.Anulada =  'False'");
            lector.Read();
            ventas.Text = lector["venta"].ToString();
            


            lblresumenventa.Text = ventas.Text;
            

            lblresumenventa.Text =  fn.remplazarNulo(lblresumenventa.Text);
            

            ventas.Text = fn.remplazarNulo(lblresumenventa.Text);
            

            gbx.Text = fechainicio.Value.Month.ToString() + " - "+fechainicio.Value.Year;

            lector.Close();
        }
        private void frmReporteVentaDiayMes_Load(object sender, EventArgs e)
        {
            chbxBUSCADOR.Checked = true;
        }

        private void dtp1FechaFin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv1, dtp1FechaInicio, dtp1FechaFin, lblventa1,lblmes1venta,gbx1);
        }

        private void dtp2Fin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv2, dtp2Inicio, dtp2Fin, lblventa2, lblmes2venta,gbx2);
        }

        private void dtp3Fin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv3, dtp3Inicio, dtp3Fin, lblventa3, lblmes3venta,gbx3);
        }

        private void dtp4FechaFin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv4, dtp4Inicio, dtp4FechaFin, lblventa4, lblmes4venta,gbx4);
        }

        private void dtp5Fin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv5, dtp5inicio, dtp5Fin, lblventa5,lblmes5venta,gbx5);
        }

        private void dtp6Fin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv6, dtp6inicio, dtp6Fin, lblventa6, lblmes6venta,  gbx6);
        }

        private void dtp7Fin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv7, dtp7Inicio, dtp7Fin, lblventa7,  lblmes7venta, gbx7);
        }

        private void dtp8fin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv8, dtp8inicio, dtp8fin, lblventa8, lblmes8venta,  gbx8);
        }

        private void dtp9fin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv9, dtp9inicio, dtp9fin, lblventa9, lblmes9venta,  gbx9);
        }

        private void dtp10fin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv10, dtp10inicio, dtp10fin, lblventa10, lblmes10venta,  gbx10);
        }

        private void dtp11fin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv11, dtp11inicio, dtp11fin, lblventa11,  lblmes11venta , gbx11);
        }

        private void dtp12fin_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv12, dtp12inicio, dtp12fin, lblventa12,  lblmes12venta, gbx12);
        }

        private void dtp1FechaInicio_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dtp1FechaInicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv1, dtp1FechaInicio, dtp1FechaFin, lblventa1, lblmes1venta, gbx1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (chbxBUSCADOR.Checked == true)
            {



                dtp2Inicio.Value = dtp1FechaInicio.Value.AddMonths(1);

                dtp3Inicio.Value = dtp2Inicio.Value.AddMonths(1);

                dtp4Inicio.Value = dtp3Inicio.Value.AddMonths(1);

                dtp5inicio.Value = dtp4Inicio.Value.AddMonths(1);

                dtp6inicio.Value = dtp5inicio.Value.AddMonths(1);

                dtp7Inicio.Value = dtp6inicio.Value.AddMonths(1);

                dtp8inicio.Value = dtp7Inicio.Value.AddMonths(1);

                dtp9inicio.Value = dtp8inicio.Value.AddMonths(1);

                dtp10inicio.Value = dtp9inicio.Value.AddMonths(1);

                dtp11inicio.Value = dtp10inicio.Value.AddMonths(1);

                dtp12inicio.Value = dtp11inicio.Value.AddMonths(1);


                //FECHAS FINALES
                dtp1FechaFin.Value = dtp2Inicio.Value.AddDays(-1);
                dtp2Fin.Value = dtp3Inicio.Value.AddDays(-1);
                dtp3Fin.Value = dtp4Inicio.Value.AddDays(-1);
                dtp4FechaFin.Value = dtp5inicio.Value.AddDays(-1);
                dtp5Fin.Value = dtp6inicio.Value.AddDays(-1);
                dtp6Fin.Value = dtp7Inicio.Value.AddDays(-1);
                dtp7Fin.Value = dtp8inicio.Value.AddDays(-1);
                dtp8fin.Value = dtp9inicio.Value.AddDays(-1);
                dtp9fin.Value = dtp10inicio.Value.AddDays(-1);
                dtp10fin.Value = dtp11inicio.Value.AddDays(-1);
                dtp11fin.Value = dtp12inicio.Value.AddDays(-1);

                dtp12fin.Value = dtp12inicio.Value.AddMonths(1);
                dtp12fin.Value = dtp12fin.Value.AddDays(-1);
            }

        }

        private void dtp2Inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv2, dtp2Inicio, dtp2Fin, lblventa2, lblmes2venta,  gbx2);
        }

        private void dtp3Inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv3, dtp3Inicio, dtp3Fin, lblventa3, lblmes3venta,  gbx3);
        }

        private void dtp4Inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv4, dtp4Inicio, dtp4FechaFin, lblventa4, lblmes4venta, gbx4);
        }

        private void dtp5inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv5, dtp5inicio, dtp5Fin, lblventa5, lblmes5venta,  gbx5);
        }

        private void dtp6inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv6, dtp6inicio, dtp6Fin, lblventa6, lblmes6venta,  gbx6);
        }

        private void dtp7Inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv7, dtp7Inicio, dtp7Fin, lblventa7, lblmes7venta, gbx7);
        }

        private void dtp8inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv8, dtp8inicio, dtp8fin, lblventa8, lblmes8venta,  gbx8);
        }

        private void dtp9inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv9, dtp9inicio, dtp9fin, lblventa9, lblmes9venta,  gbx9);
        }

        private void dtp10inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv10, dtp10inicio, dtp10fin, lblventa10, lblmes10venta,  gbx10);
        }

        private void dtp11inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv11, dtp11inicio, dtp11fin, lblventa11,  lblmes11venta, gbx11);
        }

        private void dtp12inicio_ValueChanged(object sender, EventArgs e)
        {
            mostrarGrid(dgv12, dtp12inicio, dtp12fin, lblventa12, lblmes12venta,  gbx12);
        }

        

        



        
    }
}
