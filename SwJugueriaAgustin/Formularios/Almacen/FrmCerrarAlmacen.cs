using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Operaciones
{
    public partial class FrmCerrarAlmacen : Form
    {
        Funciones fn = new Funciones();
        bool editar;
        string IDApertura;
        public FrmCerrarAlmacen()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {

            if (validacionGuardar() == false)
            {
                return;

            }


            DialogResult msj = MessageBox.Show("Desea Cerrar en Almacen", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            {
                if(msj == DialogResult.OK)
                {
                    fn.Modificar("AperturaAlmacen", "Estado='C',FechaCierre='" + DateTime.Now.ToShortDateString() + "'", "IDApertura='"+IDApertura+"'");

                    for (int i = 0; i < dgvInsumo.Rows.Count; i++)
                    {
                        string idStockAlmacen = dgvInsumo.Rows[i].Cells["cnCodigo"].Value.ToString();
                        string cantidad = dgvInsumo.Rows[i].Cells["cnCantidadCerrada"].Value.ToString();

                        fn.Modificar("StockAlmacen", "Stock='" + cantidad + "'", "IDStockAlmacen ='" + idStockAlmacen + "'");
                        fn.Modificar("[AperturaAlmacen.Detalle]", "CantidadFinal='" + cantidad + "'", "IDApertura='" + IDApertura + "' and IDStockAlmacen='" + idStockAlmacen + "'");
                    }

                    MessageBox.Show("Almacen Cerrado Correctamente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

           
        }

        private bool validacionGuardar()
        {
            foreach (DataGridViewRow row in dgvInsumo.Rows)
            {
                if ((row.Cells["cnSobrante"].Value == null) || (row.Cells["cnCantidadCerrada"].Value == null))
                {
                    MessageBox.Show("Verificar que todos los insumos. Esten Especificados su saldo Final", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            foreach (DataGridViewRow row in dgvInsumo.Rows)
            {
                if((string.IsNullOrEmpty(row.Cells["cnSobrante"].Value.ToString()) == true) || (string.IsNullOrEmpty(row.Cells["cnCantidadCerrada"].Value.ToString()) == true))
                {
                    MessageBox.Show("Verificar que todos los insumos. Esten Especificados su saldo Final", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

           if(fn.selectValue("select Estado from AperturaAlmacen where IDApertura = '"+IDApertura+"'") == "C")
            {
                MessageBox.Show("El Almacen ya se cuentra cerrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(dgvInsumo.Rows.Count == 0)
            {
                MessageBox.Show("Especificar Productos", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;   
        }

        private void FrmAbrirAlmacen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void mostraGrid()
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlCommand cmd = fn.procedimientoAlmacenado("Almacen_AperturaAlmacenCerrar_Listar");
                cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(lblFechaApertura.Text).ToShortDateString());
                cmd.Parameters.AddWithValue("@IDApertura", IDApertura);
                cmd.Parameters.AddWithValue("@IDSucursal", Datos.idSucursal);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                dgvInsumo.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }


       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void lblAbierto_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            SqlDataReader lector = fn.selectMultiValues("select top(1) aa.IDApertura,aa.FechaApertura as Fecha,aa.Turno,a.Almacen,aa.Estado  from AperturaAlmacen aa   inner join Almacen a on aa.idalmacen = a.IDAlmacen  where aa.IDSucursal = '" + Datos.idSucursal + "' order by Fecha desc");
            while (lector.Read())
            {

                IDApertura = lector["IDApertura"].ToString();
                lblAlmacen.Text = lector["Almacen"].ToString();
                lblEstado.Text = lector["Estado"].ToString().Equals("C") ? "CERRADA" : "ABIERTA";
                lblFechaApertura.Text = Convert.ToDateTime(lector["Fecha"].ToString()).ToShortDateString();
            }
            lector.Close();

            mostraGrid();
        }

        private void calcularTotal()
        {
            try
            {
                foreach (DataGridViewRow row in dgvInsumo.Rows)
                {
                    
                    double saldoSistema = Convert.ToDouble(row.Cells["cnSaldo"].Value);
                    double saldoReal = Convert.ToDouble(fn.remplazarNulo(row.Cells["cnCantidadCerrada"].Value.ToString()));


                    double faltante = saldoSistema - saldoReal;

                    row.Cells["cnSobrante"].Value = faltante;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void dgvInsumo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvInsumo.Columns["cnEspecificar"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row2 in dgvInsumo.SelectedRows)
                    {
                        frmAddCantidad frm = new frmAddCantidad();
                        frm.lblCantidad.Text = "SALDO";
                        frm.ShowDialog();

                        if(frm.Cancelado == false)
                        {
                            calcularSaldo(row2,frm.txtCantidad.Text);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void calcularSaldo(DataGridViewRow row2,string cantidadReal)
        {
            if(!string.IsNullOrEmpty(cantidadReal))
            {
                double saldoSistema = Convert.ToDouble(row2.Cells["cnSaldo"].Value.ToString());
                double saldoReal = Convert.ToDouble(cantidadReal);


                double faltante = saldoSistema - saldoReal;


                row2.Cells["cnCantidadCerrada"].Value = saldoReal;
                row2.Cells["cnSobrante"].Value = faltante;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            if (validacionGuardar() == false)
            {
                return;

            }


            if (string.IsNullOrEmpty(txtCajero.Text) == true)
            {
                MessageBox.Show("Especificar Cajera(o)", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //pdCerrarAlmacen.PrinterSettings.PrinterName = "COCINA";
                pdCerrarAlmacen.Print();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Impresión: "+ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

            
        }

        private void pdCerrarAlmacen_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //CABECERA
            e.Graphics.DrawString("CIERRE DE ALMACEN", new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(60, 5));
            e.Graphics.DrawString("Fecha: "+lblFechaApertura.Text, new Font("Courier New Condensada", 9, FontStyle.Regular), Brushes.Black, new Point(5, 25));
            e.Graphics.DrawString("CAJA: " + txtCajero.Text, new Font("Courier New Condensada", 9, FontStyle.Regular), Brushes.Black, new Point(5, 55));

            //CUERPO
            //Encabezado
            e.Graphics.DrawString("Insumo", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(0, 77));
            e.Graphics.DrawString("SI", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(76, 77));
            e.Graphics.DrawString("EN", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(106, 77));
            e.Graphics.DrawString("DE", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(136, 77));
            e.Graphics.DrawString("SV", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(166, 77));
            e.Graphics.DrawString("SS", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(196, 77));
            e.Graphics.DrawString("SR", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(226, 77));
            e.Graphics.DrawString("FA", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(256, 77));
            e.Graphics.DrawString("====================================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(0, 90));


            //CUERPO
            int SUMATORIA = 0;
            foreach (DataGridViewRow row in dgvInsumo.Rows)
            {
                string insumo = row.Cells["cnInsumo"].Value.ToString();
                string saldoInicial = row.Cells["cnSaldoInicial"].Value.ToString();
                string entrada = row.Cells["cnEntrada"].Value.ToString();
                string descarte = row.Cells["cnDescarte"].Value.ToString();
                string salidaVenta = row.Cells["cnSalidaVenta"].Value.ToString();
                string saldoSistema = row.Cells["cnSaldo"].Value.ToString();
                string saldoReal = row.Cells["cnCantidadCerrada"].Value.ToString();
                string faltante = row.Cells["cnSobrante"].Value.ToString();

                e.Graphics.DrawString(insumo, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(0, 103 + SUMATORIA));
                e.Graphics.DrawString(saldoInicial, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(76, 116 + SUMATORIA));
                e.Graphics.DrawString(entrada, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(106, 116 + SUMATORIA));
                e.Graphics.DrawString(descarte, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(136, 116 + SUMATORIA));
                e.Graphics.DrawString(salidaVenta, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(166, 116 + SUMATORIA));
                e.Graphics.DrawString(saldoSistema, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(196, 116 + SUMATORIA));
                e.Graphics.DrawString(saldoReal, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(226, 116 + SUMATORIA));
                e.Graphics.DrawString(faltante, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(256, 116 + SUMATORIA));
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(0, 125 + SUMATORIA));
                SUMATORIA = SUMATORIA + 30;
            }

            e.Graphics.DrawString("Observacion:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(0, 125 + SUMATORIA));

            e.Graphics.DrawString("==================================================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(0, 175 + SUMATORIA));
        }

        private void dgvInsumo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = pdCerrarAlmacen;
            printPreviewDialog1.ShowDialog();
        }

        private void actualizarCantidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string IDStockAlmacen = dgvInsumo.CurrentRow.Cells["cnCodigo"].Value.ToString();
            string IDInsumo = dgvInsumo.CurrentRow.Cells["cnIDInsumo"].Value.ToString();

            string saldoInicial = fn.selectValue("select dbo.FN_Almacen_SaldoInicial("+IDApertura+","+IDStockAlmacen+")");
            string cantidadEntrada = fn.selectValue("select dbo.FN_Almacen_CantidadEntrada(" + IDApertura + "," + IDInsumo + ")");
            string cantidadSalida = fn.selectValue("select dbo.FN_Almacen_CantidadSalida(" + IDApertura + "," + IDInsumo + ")");
            string CantidadVenta = fn.selectValue("SELECT [dbo].[FN_Almacen_CantidadVenta]("+Datos.idSucursal+","+IDStockAlmacen+",'"+lblFechaApertura.Text+"')");

            dgvInsumo.CurrentRow.Cells["cnSaldoInicial"].Value = saldoInicial;
            dgvInsumo.CurrentRow.Cells["cnEntrada"].Value = string.IsNullOrEmpty(cantidadEntrada) ? "0" : cantidadEntrada;
            dgvInsumo.CurrentRow.Cells["cnDescarte"].Value = string.IsNullOrEmpty(cantidadSalida) ? "0" : cantidadSalida;
            dgvInsumo.CurrentRow.Cells["cnSalidaVenta"].Value = string.IsNullOrEmpty(CantidadVenta) ? "0" : CantidadVenta;

            calcularSaldo(dgvInsumo.CurrentRow, (dgvInsumo.CurrentRow.Cells["cnCantidadCerrada"].Value  == null) ? "" : dgvInsumo.CurrentRow.Cells["cnCantidadCerrada"].Value.ToString());
        }

        private void dgvInsumo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvInsumo.Columns["cnCantidadCerrada"].Index && e.RowIndex >= 0)
                {
                    string cantidad = Convert.ToDouble(dgvInsumo.CurrentRow.Cells["cnCantidadCerrada"].Value).ToString();
                    if(!string.IsNullOrEmpty(cantidad))
                    {
                        calcularSaldo(dgvInsumo.CurrentRow, cantidad);
                    }
                    
                }
            }
            catch
            {

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            

            foreach (DataGridViewRow fila in dgvInsumo.Rows)
            {
                string IDStockAlmacen = fila.Cells["cnCodigo"].Value.ToString();
                string IDInsumo = fila.Cells["cnIDInsumo"].Value.ToString();

                string saldoInicial = fn.selectValue("select dbo.FN_Almacen_SaldoInicial(" + IDApertura + "," + IDStockAlmacen + ")");
                string cantidadEntrada = fn.selectValue("select dbo.FN_Almacen_CantidadEntrada(" + IDApertura + "," + IDInsumo + ")");
                string cantidadSalida = fn.selectValue("select dbo.FN_Almacen_CantidadSalida(" + IDApertura + "," + IDInsumo + ")");
                string CantidadVenta = fn.selectValue("SELECT [dbo].[FN_Almacen_CantidadVenta](" + Datos.idSucursal + "," + IDStockAlmacen + ",'" + lblFechaApertura.Text + "')");

                fila.Cells["cnSaldoInicial"].Value = saldoInicial;
                fila.Cells["cnEntrada"].Value = string.IsNullOrEmpty(cantidadEntrada) ? "0" : cantidadEntrada;
                fila.Cells["cnDescarte"].Value = string.IsNullOrEmpty(cantidadSalida) ? "0" : cantidadSalida;
                fila.Cells["cnSalidaVenta"].Value = string.IsNullOrEmpty(CantidadVenta) ? "0" : CantidadVenta;

                calcularSaldo(dgvInsumo.CurrentRow, (dgvInsumo.CurrentRow.Cells["cnCantidadCerrada"].Value == null) ? "" : dgvInsumo.CurrentRow.Cells["cnCantidadCerrada"].Value.ToString()); calcularSaldo(dgvInsumo.CurrentRow, (dgvInsumo.CurrentRow.Cells["cnCantidadCerrada"].Value == null) ? "" : dgvInsumo.CurrentRow.Cells["cnCantidadCerrada"].Value.ToString());

                //btnActualizar.Cursor = Cursor.Handle;
                this.Cursor = Cursors.WaitCursor;
            }
            this.Cursor = Cursors.Default;

        }
    }
}
