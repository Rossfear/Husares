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
    public partial class frmListaInsumo : Form
    {
        Funciones fn = new Funciones();
        public frmListaInsumo()
        {
            InitializeComponent();
        }

        private void frmListaInsumo_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where PermiteEntrada='True'",cbxAlmacen);
            //OTORGAMOS COLOR A LAS LEYENDAS
            txtNaranja.BackColor = Color.DarkOrange;
            txtRojo.BackColor = Color.Red;
            txtVerde.BackColor = Color.GreenYellow;
            txtBlanco.BackColor = Color.White;


            
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarGridCondicion();
        }

        private void mostrarGridCondicion()
        {
            
                MostrarGrid("");
            
            
        }

        private void MostrarGrid(string condicion)
        {
            fn.ActualizarGrid(dgvInsumo, "select sa.IDStockAlmacen,a.Almacen,i.Insumo,sa.Stock,um.UniMedida,sa.PermitirControl from stockalmacen sa,Almacen a,Insumo i,UnidadMedida um where sa.IDInsumo = i.IDInsumo and sa.IDAlmacen = a.IDAlmacen and i.IDUniMedida = um.IDUniMedida and a.Almacen like '%" + cbxAlmacen.Text + "%' and i.Insumo like '%" + cbxInsumo.Text + "%'");
        }

        private void EstadoStock()
        {
            try
            {
                int longitud = dgvInsumo.Rows.Count;

                for (int i = 0; i < longitud; i++)
                {
                    double stock = Convert.ToDouble(dgvInsumo.Rows[i].Cells[4].Value.ToString());
                    double stockMin = Convert.ToDouble(dgvInsumo.Rows[i].Cells[5].Value.ToString());
                    double stockMax = Convert.ToDouble(dgvInsumo.Rows[i].Cells[6].Value.ToString());

                    if (stock <= 0)
                    {
                        dgvInsumo.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dgvInsumo.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (stock <= stockMin)
                    {
                        dgvInsumo.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrange;
                    }
                    else if (stock >= stockMax)
                    {
                        dgvInsumo.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }



        }

        private void cbxEspecificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            ex.ExportExcelTimer(dgvInsumo, "",-1, progressBar1,"LISTA DE INSUMO");
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void chbxActualizar_CheckedChanged(object sender, EventArgs e)
        {
            if(chbxActualizar.Checked == true)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void dgvInsumo_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    fn.MostrarGri("t.Tienda,ds.Stock", "DetalleStock ds,Tienda t", "ds.IDTienda = t.IDTienda and IDInsumo = '" + dgvInsumo.CurrentRow.Cells[0].Value.ToString() + "'", dgvListaStockEmpresa, "DetalleStock");
            //}
            //catch (Exception ex)
            //{
                
            //}

        }

        private void dgvInsumo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
                MostrarGrid("");
            

            
        }

        private void cbxAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            fn.añadir_ddl("Insumo", "sa.IDStockAlmacen", "StockAlmacen  sa,Insumo i  where sa.IDInsumo = i.IDInsumo and IDAlmacen =(select IDAlmacen from almacen where almacen = '" + cbxAlmacen.Text + "')", cbxInsumo);
        }
    }
}
