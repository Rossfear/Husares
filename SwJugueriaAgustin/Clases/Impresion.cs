using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Clases
{
    class Impresion
    {
        Conversion CONVERSION = new Conversion();

        public void comanda(string area,System.Drawing.Printing.PrintPageEventArgs e,string mesa,string mozo,string idComanda,DataGridView dgvDetallePedido,bool reimprimir,bool llevar,bool cliente = false,string nombrecliente = "")
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion


            //DATOS PRINCEIPALES
            e.Graphics.DrawString(area, new Font("Courier New Condensada", 15, FontStyle.Bold), Brushes.Black, new Point(90, 0));
            e.Graphics.DrawString("Mesa: " + mesa, new Font("Courier New Condensada", 12, FontStyle.Regular), Brushes.Black, new Point(10, 30));
            e.Graphics.DrawString("Mozo: " + mozo, new Font("Courier New Condensada", 12, FontStyle.Regular), Brushes.Black, new Point(10, 50));
            e.Graphics.DrawString("H : " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 12, FontStyle.Regular), Brushes.Black, new Point(10, 70));
            e.Graphics.DrawString("Comanda: " + idComanda, new Font("Courier New Condensada", 12, FontStyle.Bold), Brushes.Black, new Point(10, 90));

            int plus = 0;

            if(cliente)
            {
                plus += 20;
                e.Graphics.DrawString("Cliente: " + nombrecliente, new Font("Courier New Condensada", 12, FontStyle.Bold), Brushes.Black, new Point(10, 90 + plus));
                plus += 15;
            }

            //ENCABEZADO
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 110+ plus));
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 120 + plus));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(50, 120 + plus));
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 130 + plus));

            //  SE AGREGA LOS PRODUCTOS
            int SUMATORIA = 0;
            foreach (DataGridViewRow row in dgvDetallePedido.Rows)
            {
                string categoria = row.Cells["cnCategoria"].Value.ToString();
                string idPresentacion = Convert.ToString(row.Cells["cnCodigo"].Value);
                string caracteristica = (row.Cells["cnDescripcion"].Value.ToString());
                bool combo = Convert.ToBoolean(row.Cells["cnCombo"].Value);

                if (combo) continue;

                if (caracteristica.Contains(":")) caracteristica =  caracteristica.Remove(caracteristica.IndexOf(":"));

                string descripcion = row.Cells["cnPlato"].Value.ToString() + " " + caracteristica;


                string cantidad = row.Cells["cnCantidad"].Value.ToString();
                int longitud = descripcion.Length;

                string productoP1 = "", productoP2 = "", productoP3 = "", productoP4 = "";
                if (longitud <= 20)
                {
                    productoP1 = descripcion;
                }
                else
                {
                    productoP1 = descripcion.Substring(0, 20);
                }


                if (longitud > 20)
                {
                    if (longitud >= 40)
                    {
                        productoP2 = descripcion.Substring(20, 20);
                    }
                    else
                    {
                        productoP2 = descripcion.Substring(20);
                    }
                }


                if (longitud > 40)
                {
                    if (longitud >= 60)
                    {
                        productoP3 = descripcion.Substring(40, 20);
                    }
                    else
                    {
                        productoP3 = descripcion.Substring(40);
                    }
                }


                if (longitud > 60)
                {
                    productoP4 = descripcion.Substring(60);
                }


                if(reimprimir == false)
                {
                    if (Convert.ToBoolean(row.Cells["cnImprimido"].Value) == llevar)
                    {
                        //SOLO AGREGA LOS COMESTIBLES
                        if (categoria == area)
                        {
                            e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(10, 141 + SUMATORIA + plus));
                            e.Graphics.DrawString("" + productoP1, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA + plus));
                            if (productoP2 != "")
                            {
                                SUMATORIA = SUMATORIA + 15;
                                e.Graphics.DrawString("" + productoP2, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA + plus));
                            }
                            if (productoP3 != "")
                            {
                                SUMATORIA = SUMATORIA + 15;
                                e.Graphics.DrawString("" + productoP3, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA + plus));
                            }
                            if (productoP4 != "")
                            {
                                SUMATORIA = SUMATORIA + 15;
                                e.Graphics.DrawString("" + productoP4, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA + plus));
                            }
                            e.Graphics.DrawString("-----------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 154 + SUMATORIA + plus));
                            SUMATORIA = SUMATORIA + 27;
                        }
                    }
                }
                else
                {
                    if (Convert.ToBoolean(row.Cells["cnImprimido"].Value) == true)
                    {
                        //SOLO AGREGA LOS COMESTIBLES
                        if (categoria == area)
                        {
                            e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(10, 141 + SUMATORIA + plus));
                            e.Graphics.DrawString("" + productoP1, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA + plus));
                            if (productoP2 != "")
                            {
                                SUMATORIA = SUMATORIA + 15;
                                e.Graphics.DrawString("" + productoP2, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA + plus));
                            }
                            if (productoP3 != "")
                            {
                                SUMATORIA = SUMATORIA + 15;
                                e.Graphics.DrawString("" + productoP3, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA + plus));
                            }
                            if (productoP4 != "")
                            {
                                SUMATORIA = SUMATORIA + 15;
                                e.Graphics.DrawString("" + productoP4, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA + plus));
                            }
                            e.Graphics.DrawString("-----------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 154 + SUMATORIA + plus));
                            SUMATORIA = SUMATORIA + 27;
                        }
                    }
                }

                
            }


            if (reimprimir == false)
            {
                e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 9, FontStyle.Regular), Brushes.Black, new Point(0, 170 + SUMATORIA + plus));
            }
            else
            {
                e.Graphics.DrawString("================REIMPRIMIDO=====================", new Font("Courier New Condensada", 9, FontStyle.Regular), Brushes.Black, new Point(0, 170 + SUMATORIA + plus));
            }

            e.Graphics.DrawString("F : " + DateTime.Now.ToShortDateString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 180 + SUMATORIA + plus));

        }

        public void comandaOficial(string area, System.Drawing.Printing.PrintPageEventArgs e, string mesa, string mozo, string idComanda, DataGridView dgvDetallePedido, bool reimprimir, bool llevar)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion


            //DATOS PRINCEIPALES
            e.Graphics.DrawString(area, new Font("Courier New Condensada", 15, FontStyle.Bold), Brushes.Black, new Point(90, 0));
            e.Graphics.DrawString("Mesa: " + mesa, new Font("Courier New Condensada", 12, FontStyle.Regular), Brushes.Black, new Point(10, 30));
            e.Graphics.DrawString("Mozo: " + mozo, new Font("Courier New Condensada", 12, FontStyle.Regular), Brushes.Black, new Point(10, 50));
            e.Graphics.DrawString("H : " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 12, FontStyle.Regular), Brushes.Black, new Point(10, 70));
            e.Graphics.DrawString("Comanda: " + idComanda, new Font("Courier New Condensada", 12, FontStyle.Bold), Brushes.Black, new Point(10, 90));

            //ENCABEZADO
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 110));
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 120));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(50, 120));
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 130));

            //  SE AGREGA LOS PRODUCTOS
            int SUMATORIA = 0;
            foreach (DataGridViewRow row in dgvDetallePedido.Rows)
            {
                string categoria = row.Cells["cnCategoria"].Value.ToString();
                string idPresentacion = Convert.ToString(row.Cells["cnCodigo"].Value);
                string caracteristica = (row.Cells["cnDescripcion"].Value.ToString());
                bool combo = Convert.ToBoolean(row.Cells["cnCombo"].Value);

                if (combo) continue;

                if (caracteristica.Contains(":")) caracteristica = caracteristica.Remove(caracteristica.IndexOf(":"));

                string descripcion = row.Cells["cnPlato"].Value.ToString() + " " + caracteristica;


                string cantidad = row.Cells["cnCantidad"].Value.ToString();
                int longitud = descripcion.Length;

                string productoP1 = "", productoP2 = "", productoP3 = "", productoP4 = "";
                if (longitud <= 20)
                {
                    productoP1 = descripcion;
                }
                else
                {
                    productoP1 = descripcion.Substring(0, 20);
                }


                if (longitud > 20)
                {
                    if (longitud >= 40)
                    {
                        productoP2 = descripcion.Substring(20, 20);
                    }
                    else
                    {
                        productoP2 = descripcion.Substring(20);
                    }
                }


                if (longitud > 40)
                {
                    if (longitud >= 60)
                    {
                        productoP3 = descripcion.Substring(40, 20);
                    }
                    else
                    {
                        productoP3 = descripcion.Substring(40);
                    }
                }


                if (longitud > 60)
                {
                    productoP4 = descripcion.Substring(60);
                }

                if (Convert.ToBoolean(row.Cells["cnImprimido"].Value) == false)
                {
                    //SOLO AGREGA LOS COMESTIBLES
                    if (categoria == area)
                    {
                        e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(10, 141 + SUMATORIA));
                        e.Graphics.DrawString("" + productoP1, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA));
                        if (productoP2 != "")
                        {
                            SUMATORIA = SUMATORIA + 15;
                            e.Graphics.DrawString("" + productoP2, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA));
                        }
                        if (productoP3 != "")
                        {
                            SUMATORIA = SUMATORIA + 15;
                            e.Graphics.DrawString("" + productoP3, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA));
                        }
                        if (productoP4 != "")
                        {
                            SUMATORIA = SUMATORIA + 15;
                            e.Graphics.DrawString("" + productoP4, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(46, 141 + SUMATORIA));
                        }
                        e.Graphics.DrawString("-----------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 154 + SUMATORIA));
                        SUMATORIA = SUMATORIA + 27;
                    }
                }
            }




                if (reimprimir == false)
            {
                e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 9, FontStyle.Regular), Brushes.Black, new Point(0, 170 + SUMATORIA));
            }
            else
            {
                e.Graphics.DrawString("================REIMPRIMIDO=====================", new Font("Courier New Condensada", 9, FontStyle.Regular), Brushes.Black, new Point(0, 170 + SUMATORIA));
            }

            e.Graphics.DrawString("F : " + DateTime.Now.ToShortDateString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 180 + SUMATORIA));

        }
        public void Comprobante(string nombreComprobante,string tipoDocumento, System.Drawing.Printing.PrintPageEventArgs e, string fecha, string hora, string serie, string numero, string direccion, string cliente, string nroDocumento, string tipoPago, string tipoImpresion, DataGridView dgvDatos, string total, string descuento, string subTotal, string igv, string mesa, string mozo, string nroComanda, bool reimpresion,bool delivery,string pagoCon,string cambio,bool ticket)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion

            e.Graphics.DrawString(Datos.RazonSocial, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(5, 0));
            e.Graphics.DrawString(Datos.nombreComercial, new Font("Courier New Condensada", 11, FontStyle.Bold), Brushes.Black, new Point(5, 20));
            e.Graphics.DrawString("RUC " + Datos.Ruc, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(90, 40));
            e.Graphics.DrawString(Datos.Direccion, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 52));
            e.Graphics.DrawString(Datos.Departmaneto, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(30, 64));
            e.Graphics.DrawString(nombreComprobante, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(20, 80));

            e.Graphics.DrawString(serie + "-" + numero, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(98, 94));

            string direccion1 = "", direccion2 = "";

            if (direccion.Trim().Length >= 33)
            {
                direccion1 = direccion.Trim().Substring(0, 33);
                direccion2 = direccion.Trim().Substring(33);
            }
            else
            {
                direccion1 = direccion.Trim().Substring(0);
            }

            e.Graphics.DrawString("CLIENTE: " + cliente, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 121));
            //e.Graphics.DrawString("" + cliente2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 133));
            e.Graphics.DrawString(tipoDocumento+":" + nroDocumento, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 146));
            e.Graphics.DrawString("DIR: " + direccion1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 159));
            e.Graphics.DrawString("" + direccion2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(28, 169));

            e.Graphics.DrawString("TP: " + tipoPago, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 184));

            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 197));

            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 213));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 213));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 213), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 213), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 226));


            int SUMATORIA = 0;
            //DETALLADO
            if (tipoImpresion == "DETALLADO")
            {
                if(delivery == true)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        double precio = Convert.ToDouble(row.Cells["cnPrecio"].Value);
                        string cantidad = row.Cells["cnCantidad"].Value.ToString();
                        string descri = row.Cells["cnPlato"].Value.ToString();
                        double importe = Convert.ToDouble(row.Cells["cnImporte"].Value);

                        e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 242 + SUMATORIA));
                        e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 242 + SUMATORIA));
                        e.Graphics.DrawString("" + precio.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 252 + SUMATORIA), alineacion);
                        e.Graphics.DrawString("" + importe.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 252 + SUMATORIA), alineacion);
                        e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 260 + SUMATORIA));
                        SUMATORIA = SUMATORIA + 30;
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        if ((bool)row.Cells["cnImprimido"].Value == true)
                        {
                            double precio = Convert.ToDouble(row.Cells["cnPrecio"].Value);

                            if (Datos.transferenciaGratuita == false && precio > 0)
                            {
                                string cantidad = row.Cells["cnCantidad"].Value.ToString();
                                string plato = row.Cells["cnPlato"].Value.ToString();
                                double importe = Convert.ToDouble(row.Cells["cnImporte"].Value);

                                string descripcion = row.Cells["cnDescripcion"].Value.ToString();

                                if (descripcion.Contains(":")) descripcion =  descripcion.Remove(0, descripcion.IndexOf(":")+1);
                                

                                e.Graphics.DrawString("" + plato + " " + descripcion.ToUpper(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 242 + SUMATORIA));
                                

                                e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 242 + SUMATORIA));
                                e.Graphics.DrawString("" + precio.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 252 + SUMATORIA), alineacion);
                                e.Graphics.DrawString("" + importe.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 252 + SUMATORIA), alineacion);
                                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 260 + SUMATORIA));
                                SUMATORIA = SUMATORIA + 30;
                            }
                        }
                    }
                }
            }
            else
            {
                e.Graphics.DrawString("1", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 242 + SUMATORIA));
                e.Graphics.DrawString("POR CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 242 + SUMATORIA + 5));
                e.Graphics.DrawString(Convert.ToDecimal(total).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 250 + SUMATORIA), alineacion);
                e.Graphics.DrawString(Convert.ToDecimal(total).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 250 + SUMATORIA), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 260 + SUMATORIA));
                SUMATORIA = SUMATORIA + 30;
            }

            e.Graphics.DrawString("DESCUENTO:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 244 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 244 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(descuento).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 244 + SUMATORIA), alineacion);

            e.Graphics.DrawString("OP INAFECTA:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 257 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 257 + SUMATORIA));
            e.Graphics.DrawString("" + "0.00", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 257 + SUMATORIA), alineacion);

            e.Graphics.DrawString("OP GRAVADA:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 270 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 270 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(subTotal).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 270 + SUMATORIA), alineacion);

            e.Graphics.DrawString("IGV:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 283 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 283 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(igv).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 283 + SUMATORIA), alineacion);

            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(70, 296 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 296 + SUMATORIA));
            e.Graphics.DrawString("" + Convert.ToDouble(total).ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 296 + SUMATORIA), alineacion);

            e.Graphics.DrawString("PAGO CON:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 309 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 309 + SUMATORIA));
            e.Graphics.DrawString("" + pagoCon, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 309 + SUMATORIA), alineacion);

            e.Graphics.DrawString("CAMBIO:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 322 + SUMATORIA));
            e.Graphics.DrawString("S/", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 322 + SUMATORIA));
            e.Graphics.DrawString("" + cambio, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 322 + SUMATORIA), alineacion);

            string letras1 = "", letras2 = "";
            string letras = "SON: " + CONVERSION.enletras(total) + " SOLES";

            if (letras.Length >= 43)
            {
                letras1 = letras.Substring(0, 43);
                letras2 = letras.Substring(43);
            }
            else
                letras1 = letras.Substring(0);




            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 337 + SUMATORIA));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 350 + SUMATORIA));



            e.Graphics.DrawString("Mesa: " + mesa, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 365 + SUMATORIA));
            e.Graphics.DrawString("Mozo: " + mozo, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 378 + SUMATORIA));
            if (mesa == "LLEVAR A" || mesa == "LLEVAR B")
            {
                e.Graphics.DrawString("Comanda: " + serie + " - " + numero, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(5, 391 + SUMATORIA));
            }
            else
            {
                e.Graphics.DrawString("Comanda: " + nroComanda, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(5, 391 + SUMATORIA));
            }


            if(ticket == false)
            {
                e.Graphics.DrawString("Representacion Impresa del Comprobante", new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(45, 415 + SUMATORIA));
                e.Graphics.DrawString("Consulte Documento en", new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(60, 428 + SUMATORIA));
                e.Graphics.DrawString(Datos.rutaDescarga, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(75, 441 + SUMATORIA));
                e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(70, 460 + SUMATORIA));


                e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 470 + SUMATORIA));
                e.Graphics.DrawString("F: " + fecha + "  -  H: " + hora, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(10, 480 + SUMATORIA));

                if (reimpresion == true)
                    e.Graphics.DrawString("C*", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(5, 460 + SUMATORIA));
            }
            else
            {
                
                e.Graphics.DrawString("Canjeable por Comprobante", new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(67, 415 + SUMATORIA));
                e.Graphics.DrawString("Gracias por su compra.", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(75, 435 + SUMATORIA));
                e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 445 + SUMATORIA));
                e.Graphics.DrawString("F: " + fecha + "  -  H: " + hora, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(10, 455 + SUMATORIA));

                if (reimpresion == true)
                    e.Graphics.DrawString("C*", new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(5, 435 + SUMATORIA));
            }

            

            
        }
        public void PreCuenta(System.Drawing.Printing.PrintPageEventArgs e, string mesa, string mozo, string idComanda, DataGridView dgvDetallePedido,string total)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion

            int plus = 15;

            e.Graphics.DrawString("Mesa: " + mesa, new Font("Courier New Condensada", 10, FontStyle.Bold), Brushes.Black, new Point(5, 0));
            e.Graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 13 + 5));
            e.Graphics.DrawString("Hora: " + DateTime.Now.ToShortTimeString(), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 26 + 5));
            e.Graphics.DrawString("Mozo: " + mozo, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 39 + 5));
            e.Graphics.DrawString("N° Comnada:" + idComanda, new Font("Courier New Condensada", 7, FontStyle.Bold), Brushes.Black, new Point(5, 39 + 5 + plus));

            e.Graphics.DrawString("PRE-CUENTA", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(110, 65 + 5 + plus));





            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 179 - 89 + plus));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 179 - 89 + plus));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 179 + 3 - 89 + plus), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 179 + 3 - 89 + plus), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 192 - 89 + plus));


            int SUMATORIA = 0;

            foreach (DataGridViewRow row in dgvDetallePedido.Rows)
            {

                decimal untario, costo;
                decimal can_2;
                int cantidad;
                string descri;

                descri = row.Cells["cnPlato"].Value.ToString();

                can_2 = Convert.ToDecimal(row.Cells["cnCantidad"].Value);
                untario = Convert.ToDecimal(row.Cells["cnPrecio"].Value);
                costo = Convert.ToDecimal(row.Cells["cnImporte"].Value);


                can_2 = Math.Round(can_2, 0);
                untario = Math.Round(untario, 2);
                costo = Math.Round(costo, 2);
                cantidad = Convert.ToInt16(can_2);



                e.Graphics.DrawString("" + cantidad, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5 - 89 + plus));
                e.Graphics.DrawString("" + descri, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5 - 89 + plus));

                e.Graphics.DrawString("" + untario.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 231 - 13 + SUMATORIA - 89 + 8 + plus), alineacion);
                e.Graphics.DrawString("" + costo.ToString("#,#.00"), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 231 - 13 + SUMATORIA + 8 - 89 + plus), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 245 - 13 + SUMATORIA - 89 + plus));
                SUMATORIA = SUMATORIA + 30;

            }

            string letras;




            Clases.Conversion CONVERSION = new Conversion();
            letras = CONVERSION.enletras(total);




            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 268 - 13 + SUMATORIA - 25 - 89 + plus));//276
            e.Graphics.DrawString("" + total, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 268 - 13 + SUMATORIA - 89 - 25 + plus), alineacion);

            string letras_ofi, mon, moneda = "Soles";
            if (moneda == "Soles")
            { mon = "SOLES"; }
            else
            { mon = "DOLARES"; }

            letras_ofi = "SON: " + letras + " " + mon;

            string letras1 = "", letras2 = "";
            int indice_letras = -1, indiceletras2 = 46;

            while (indice_letras <= 45)
            {
                indice_letras += 1;

                if (indice_letras < letras_ofi.Length)
                {
                    letras1 += letras_ofi[indice_letras];
                }
            }
            while (indiceletras2 < letras_ofi.Length - 1)
            {
                indiceletras2 += 1;
                letras2 += letras_ofi[indiceletras2];
            }

            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 281 - 13 + SUMATORIA - 25 - 89 + plus));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 291 - 13 + SUMATORIA - 25 - 89 + plus));
            e.Graphics.DrawString("=====================================================: " + Datos.Usuario, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 283 - 13 + SUMATORIA - 89 + plus));


        }

        public void comandaDelivery(bool seleccionado,string referencia,string telefono,string nombreComprobante, string tipoDocumento, System.Drawing.Printing.PrintPageEventArgs e, string fecha, string hora, string serie, string numero, string direccion, string cliente, string nroDocumento, string tipoPago, string tipoImpresion, DataGridView dgvDatos, string total, string mesa, string mozo, string nroComanda)
        {
            // formato de alineacion derecha
            StringFormat alineacion = new StringFormat();
            alineacion.Alignment = StringAlignment.Far;
            //fin formato alineacion




            e.Graphics.DrawString("COMANDA DELIVERY", new Font("Courier New Condensada", 9, FontStyle.Bold), Brushes.Black, new Point(50, 19));

            e.Graphics.DrawString(nombreComprobante+ ": " + serie+ " - " + numero, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(5, 49));





            //DAtos PErsona
            e.Graphics.DrawString("CLIENTE" + cliente, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 75));
            e.Graphics.DrawString(tipoDocumento+": " + nroDocumento, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 88));
            e.Graphics.DrawString("TELEFONO: " + telefono, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 101));


            //VERIFICAMOS EL TAMAÑO DE DIRECCION
            string direccion1 = "", direccion2 = "", direccion3 = "", direccion4 = "";

            int maximoCaracteres = 35;
            int filas = direccion.Length / maximoCaracteres;

            //FILA **1** DE DIRECCION
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (direccion.Length > i)
                {
                    direccion1 += direccion[i];
                }
                else
                {
                    break;
                }
            }

            //FILA **2** DIRECCION
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (direccion.Length > i + maximoCaracteres)
                {
                    direccion2 += direccion[i + maximoCaracteres];
                }
                else
                {
                    break;
                }
            }

            //FILA **3** DIRECCION
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (direccion.Length > i + (maximoCaracteres * 2))
                {
                    direccion3 += direccion[i + (maximoCaracteres * 2)];
                }
                else
                {
                    break;
                }
            }

            //FILA **4** DIRECCION
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (direccion.Length > i + (maximoCaracteres * 2))
                {
                    direccion4 += direccion[i + (maximoCaracteres * 2)];
                }
                else
                {
                    break;
                }
            }



            e.Graphics.DrawString("DIRECCIÓN:", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 127));

            int plusDireccion = 13;
            if (direccion1 != "")
            {
                e.Graphics.DrawString(direccion1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 127 + plusDireccion));
                plusDireccion += 13;
            }

            if (direccion2 != "")
            {
                e.Graphics.DrawString(direccion2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 127 + plusDireccion));
                plusDireccion += 13;
            }

            if (direccion3 != "")
            {
                e.Graphics.DrawString(direccion3, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 127 + plusDireccion));
                plusDireccion += 13;
            }

            if (direccion4 != "")
            {
                e.Graphics.DrawString(direccion4, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 127 + plusDireccion));
            }



            //VERIFICAMOS EL TAMAÑO DE ***REFERENCIA***
            string referencia1 = "", referencia2 = "", referencia3 = "", referencia4 = "";


            //FILA **1** DE REFERENCIA
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (referencia.Length > i)
                {
                    referencia1 += referencia[i];
                }
                else
                {
                    break;
                }
            }

            //FILA **2** REFERENCIA
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (referencia.Length > i + maximoCaracteres)
                {
                    referencia2 += referencia[i + maximoCaracteres];
                }
                else
                {
                    break;
                }
            }

            //FILA **3** REFERENCIA
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (referencia.Length > i + (maximoCaracteres * 2))
                {
                    referencia3 += referencia[i + (maximoCaracteres * 2)];
                }
                else
                {
                    break;
                }
            }

            //FILA **4** REFERENCIA
            for (int i = 0; i < maximoCaracteres; i++)
            {
                if (referencia.Length > i + (maximoCaracteres * 2))
                {
                    referencia4 += referencia[i + (maximoCaracteres * 2)];
                }
                else
                {
                    break;
                }
            }


            int plusReferencia = 0;


            e.Graphics.DrawString("REFERENCIA:", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(5, 140 + plusDireccion + plusReferencia));

            if (referencia1 != "")
            {
                e.Graphics.DrawString(referencia1, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 140 + 13 + plusDireccion + plusReferencia));
                plusReferencia += 13;
            }


            if (referencia2 != "")
            {
                e.Graphics.DrawString(referencia2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 140 + 13 + plusDireccion + plusReferencia));
                plusReferencia += 13;
            }

            if (referencia3 != "")
            {
                e.Graphics.DrawString(referencia3, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 13 + 140 + plusDireccion + plusReferencia));
                plusReferencia += 13;
            }

            if (referencia4 != "")
            {
                e.Graphics.DrawString(referencia4, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(5, 140 + 13 + plusDireccion + plusReferencia));

            }




            e.Graphics.DrawString("T. Pago:" + tipoPago + "- F: " + fecha + " / H: " + hora, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 13 + 153 + plusDireccion + plusReferencia));



            //Encabezado
            e.Graphics.DrawString("Cant.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 179 + 13 + plusDireccion + plusReferencia));
            e.Graphics.DrawString("Producto", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(46, 179 + 13 + plusDireccion + plusReferencia));
            e.Graphics.DrawString("Prec. Uni.", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(185, 179 + 13 + 3 + plusDireccion + plusReferencia), alineacion);
            e.Graphics.DrawString("Importe", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 179 + 13 + 3 + plusDireccion + plusReferencia), alineacion);
            e.Graphics.DrawString("==========================================", new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(10, 192 + 13 + plusDireccion + plusReferencia));


            int SUMATORIA = 0;
            if (tipoImpresion == "DETALLADO")
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    if ((bool)row.Cells["cnImprimido"].Value == seleccionado)
                    {
                        string descripcion = row.Cells["cnPlato"].Value.ToString() + " " + row.Cells["cnDescripcion"].Value.ToString();
                        string untario = Convert.ToString(row.Cells["cnPrecio"].Value);
                        string costo = Convert.ToString(row.Cells["cnImporte"].Value);
                        string can_2 = row.Cells["cnCantidad"].Value.ToString();


                        e.Graphics.DrawString("" + can_2, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5 + 13 + plusDireccion + plusReferencia));

                        if (descripcion.Length <= 30)
                        {
                            e.Graphics.DrawString("" + descripcion, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5 + 13 + plusDireccion + plusReferencia));

                            e.Graphics.DrawString("" + untario, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 231 + 13 - 13 + SUMATORIA + 8 + plusDireccion + plusReferencia), alineacion);
                            e.Graphics.DrawString("" + costo, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 231 + 13 - 13 + SUMATORIA + 8 + plusDireccion + plusReferencia), alineacion);

                            e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 245 + 13 - 13 + SUMATORIA + plusDireccion + plusReferencia));
                            SUMATORIA = SUMATORIA + 30;
                        }
                        else
                        {
                            e.Graphics.DrawString("" + descripcion.Substring(0, 30), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5 + 13 + plusDireccion + plusReferencia));
                            e.Graphics.DrawString("" + descripcion.Substring(30), new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 231 - 13 + SUMATORIA + 5 + 13 + plusDireccion + plusReferencia));

                            e.Graphics.DrawString("" + untario, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 244 + 13 - 13 + SUMATORIA + 8 + plusDireccion + plusReferencia), alineacion);
                            e.Graphics.DrawString("" + costo, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 244 + 13 - 13 + SUMATORIA + 8 + plusDireccion + plusReferencia), alineacion);

                            e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 245 + 13 + SUMATORIA + plusDireccion + plusReferencia));
                            SUMATORIA = SUMATORIA + 43;
                        }
                    }
                }
            }
            else
            {
                e.Graphics.DrawString("1", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 205 + SUMATORIA + 5 + 13 + plusDireccion + plusReferencia));
                e.Graphics.DrawString("POR CONSUMO", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(46, 218 - 13 + SUMATORIA + 5 + 13 + plusDireccion + plusReferencia));

                e.Graphics.DrawString("" + total, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(185, 231 + 13 - 13 + SUMATORIA + 8 + plusDireccion + plusReferencia), alineacion);
                e.Graphics.DrawString("" + total, new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(250, 231 + 13 - 13 + SUMATORIA + 8 + plusDireccion + plusReferencia), alineacion);
                e.Graphics.DrawString("------------------------------------------------------------------------", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(10, 245 + 13 - 13 + SUMATORIA + plusDireccion + plusReferencia));
                SUMATORIA = SUMATORIA + 30;
            }


            

            string letras = CONVERSION.enletras(total);




            e.Graphics.DrawString("TOTAL:", new Font("Courier New Condensada", 8, FontStyle.Regular), Brushes.Black, new Point(70, 268 - 13 + SUMATORIA - 25 + 13 + plusDireccion + plusReferencia));//276
            e.Graphics.DrawString("" + total, new Font("Courier New Condensada", 8, FontStyle.Bold), Brushes.Black, new Point(250, 268 - 13 + SUMATORIA - 25 + 13 + plusDireccion + plusReferencia), alineacion);



            

            string letras_ofi = "SON: " + letras + " SOLES";

            string letras1 = "", letras2 = "";
            int indice_letras = -1, indiceletras2 = 46;

            while (indice_letras <= 45)
            {
                indice_letras += 1;

                if (indice_letras < letras_ofi.Length)
                {
                    letras1 += letras_ofi[indice_letras];
                }
            }
            while (indiceletras2 < letras_ofi.Length - 1)
            {
                indiceletras2 += 1;
                letras2 += letras_ofi[indiceletras2];
            }

            e.Graphics.DrawString("" + letras1, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 281 + SUMATORIA - 25 + 26 + plusDireccion + plusReferencia));
            e.Graphics.DrawString("" + letras2, new Font("Courier New Condensada", 7, FontStyle.Regular), Brushes.Black, new Point(5, 173 + SUMATORIA - 25 + 26 + plusDireccion + plusReferencia));





        }


    }
}
