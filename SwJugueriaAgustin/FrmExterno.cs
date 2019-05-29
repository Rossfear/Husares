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

namespace SwJugueriaAgustin
{
    public partial class FrmExterno : Form
    {
        Funciones fn = new Funciones();
        Clases.Conversion CONVERSION = new Conversion();
        public string preconex = "Data Source=190.117.125.170\\PRODUCCION;Initial Catalog=DBTabernaHusares;Uid=innovated;Pwd=123";
        
        public FrmExterno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(DataGridViewRow row in dgvPedido.Rows)
                {
                    string idpedido = row.Cells["IDPedido"].Value.ToString();
                    string nroComanda = row.Cells["Codigo"].Value.ToString();

                    string nuevoComanda = nroComanda.Replace("0 - ","");

                    
                    fn.Modificar("pedido","Codigo='"+nuevoComanda+"'","IDPedido='"+idpedido+"'");
                }

                MessageBox.Show("Proceso Finalizado");
            }
            catch
            {

            }
        }

        public void RegistrarOficial(string table, string campos, string datos)
        {
            SqlConnection conexion = new SqlConnection(preconex);

            try
            {
                string reg = "INSERT INTO " + table + "(" + campos + ") VALUES (" + datos + ")";
                SqlCommand cmdReg = new SqlCommand(reg, conexion);
                conexion.Open();
                int registro = cmdReg.ExecuteNonQuery();
                if (registro > 0)
                {

                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.Message, ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmExterno_Load(object sender, EventArgs e)
        {
            fn.ActualizarGrid(dgvDatos, "SELECT * FROM Insumo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ppDialog.Document = printDocument1;
            ppDialog.ShowDialog();
        }


        public void ActualizarGrid(DataGridView dg, String Query)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(preconex);

                //crear data set
                DataSet Ds = new DataSet();

                //crear un adaptador de dato
                SqlDataAdapter Da = new SqlDataAdapter(Query, conexion);
                //llenar el data set

                Da.Fill(Ds, "Contrato");

                //Asignando el valor adecuado a las propiedades del data grid

                dg.DataSource = Ds;
                dg.DataMember = "Contrato";

                //cerramos la conexion

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public SqlDataReader selectMultiValues(string query)
        {
            SqlConnection conexion = new SqlConnection(preconex);

            try
            {
                string oncod = query;
                SqlCommand cmd = new SqlCommand(oncod, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();


                return lector;

            }
            catch
            {
                return null;
            }

        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string direccion = "";
            e.Graphics.DrawImage(pictureBox1.Image, 30, 10,230,100);


            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion



            e.Graphics.DrawString("         ALENI S.A.C.", new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(50, 120));
            e.Graphics.DrawString("RUC: 20477455353", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 140));
            e.Graphics.DrawString("MZA. C LOTE. 31 URB. LAS HORTENCIAS DE CALIFORNIA", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 152));
            e.Graphics.DrawString("LA LIBERTAD-TRUJILLO-VICTOR LARCO HERRERA", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(30, 164));
            e.Graphics.DrawString("BOLETA DE VENTA ELECTRONICA", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(40, 180));

            e.Graphics.DrawString("B001 - 00000057", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(98, 194));

            string direccion1 = "", direccion2 = "";

            if (direccion.Length >= 33)
            {
                direccion1 = direccion.Trim().Substring(0, 33);
                direccion2 = direccion.Trim().Substring(33);
            }
            else
            {
                direccion1 = direccion.Trim().Substring(0);
            }

            e.Graphics.DrawString("SR(A): CLIENTES VARIOS", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 221));
            //e.Graphics.DrawString("" + cliente2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 133));
            e.Graphics.DrawString("DNI: 0", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 246));
            e.Graphics.DrawString("DIR: " + direccion1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 259));
            e.Graphics.DrawString("" + direccion2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(28, 269));

            e.Graphics.DrawString("TP: EFECTIVO", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 284));

            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 297));

            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 313));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 313));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 313), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 313), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 326));


            int SUMATORIA = 0;
            //DETALLADO
            if ("DETALLADO" == "DETALLADO")
            {
                foreach (DataGridViewRow row in dgvPedido.Rows)
                {
                    try
                    {
                        if ((bool)row.Cells["cnImprimido"].Value == true)
                        {
                            string descri = row.Cells["cnPlato"].Value.ToString();

                            string cantidad = row.Cells["cnCantidad"].Value.ToString();
                            double precio = Convert.ToDouble(row.Cells["cnPrecio"].Value);
                            double importe = Convert.ToDouble(row.Cells["cnImporte"].Value);

                            e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 342 + SUMATORIA));
                            e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 342 + SUMATORIA));
                            e.Graphics.DrawString("" + precio.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 352 + SUMATORIA), alineacion);
                            e.Graphics.DrawString("" + importe.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 352 + SUMATORIA), alineacion);
                            e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 360 + SUMATORIA));
                            SUMATORIA = SUMATORIA + 30;
                        }
                    }
                    catch
                    {

                    }
                    
                }
            }
            else
            {
                e.Graphics.DrawString("1", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 342 + SUMATORIA));
                e.Graphics.DrawString("POR CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 342 + SUMATORIA + 5));
                e.Graphics.DrawString(Convert.ToDecimal("59.00").ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 350 + SUMATORIA), alineacion);
                e.Graphics.DrawString(Convert.ToDecimal("59.00").ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 350 + SUMATORIA), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 360 + SUMATORIA));
                SUMATORIA = SUMATORIA + 30;
            }

            e.Graphics.DrawString("DESCUENTO:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 344 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 344 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble("00.00").ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 344 + SUMATORIA), alineacion);

            e.Graphics.DrawString("OP INAFECTA:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 357 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 357 + SUMATORIA));
            e.Graphics.DrawString("" + "0.00", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 357 + SUMATORIA), alineacion);

            e.Graphics.DrawString("OP GRAVADA:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 370 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 370 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble("56.70").ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 370 + SUMATORIA), alineacion);

            e.Graphics.DrawString("IGV:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 383 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 383 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble("10.20").ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 383 + SUMATORIA), alineacion);

            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 396 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 396 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble("66.90").ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 396 + SUMATORIA), alineacion);

            string letras1 = "", letras2 = "";
            string letras = "SON: " + CONVERSION.enletras("66.90") + " SOLES";

            if (letras.Length >= 43)
            {
                letras1 = letras.Substring(0, 43);
                letras2 = letras.Substring(43);
            }
            else
                letras1 = letras.Substring(0);




            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 411 + SUMATORIA));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 424 + SUMATORIA));



            e.Graphics.DrawString("MESA: MESA A" , new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 439 + SUMATORIA));
            e.Graphics.DrawString("Moso: MANUELITO", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 452 + SUMATORIA));
            if ("MESA A" == "LLEVAR A" || "MESA A" == "LLEVAR B")
            {
                e.Graphics.DrawString("Comanda: " + "B001" + " - " + "00000058", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 465 + SUMATORIA));
            }
            else
            {
                e.Graphics.DrawString("Comanda: " + "158", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 465 + SUMATORIA));
            }

            string t1 = "Representación automática de Boleta de Venta";
            string t2 = "Electrónica puede ser descargado en";
            string t3 = "www.innovated.pe";

            e.Graphics.DrawString(t1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(25, 485 + SUMATORIA));
            e.Graphics.DrawString(t2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(45, 498 + SUMATORIA));
            e.Graphics.DrawString(t3, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 511 + SUMATORIA));

            e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 531 + SUMATORIA));
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 541 + SUMATORIA));
            e.Graphics.DrawString("F: " + DateTime.Now.ToShortDateString() + "  -  H: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(10, 554 + SUMATORIA));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow grid in dgvDatos.Rows)
            {
                //string idInsumo = 
            }
            MessageBox.Show("ok");
        }
    }
}
