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
    public partial class frmTraslado : Form
    {
        Funciones fn = new Funciones();
        Datos d = new Datos();
        public static string IDUsuario;
        public frmTraslado()
        {
            InitializeComponent();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
        }
        private void MostrarDatosGrid()
        {
            fn.ActualizarGrid(dgvInsumo, "select i.IDInsumo as Codigo,i.Insumo,sa.Stock,um.UniMedida from stockalmacen sa,Almacen a,Insumo i,UnidadMedida um where sa.IDInsumo = i.IDInsumo and sa.IDAlmacen = a.IDAlmacen and i.IDUniMedida = um.IDUniMedida and a.Almacen = '" + cbxAlmacenEmisor.Text + "' and i.Insumo like '%" + txtBuscar.Text + "%'");
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmAddCantidad frm = new frmAddCantidad();
                frm.ShowDialog();
                
                if(frm.Cancelado == false)
                {
                    string idInsumo = dgvInsumo.CurrentRow.Cells[0].Value.ToString();
                    string insumo = dgvInsumo.CurrentRow.Cells[1].Value.ToString();
                    string cantidad = frm.txtCantidad.Text;
                    dgvSalida.Rows.Add(idInsumo, insumo, cantidad, 'X');
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validacionGuardar() == false)
            {
                return;
            }
            
            DialogResult msj = MessageBox.Show("Desea REGISTRAR el Traslado de Insumos?", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string fecha = DateTime.Now.ToShortDateString();
            if (msj == DialogResult.OK)
            {
                

                //REGISTRAMOS SALIDA DEL ALMACEN EMISOR
                fn.Registrar("SalidaInsumo", "'" + fecha + "',(select IDTipoSalida from TipoSalida where TipoSalida = 'TRASLADO'),'" + cbxAlmacenEmisor.SelectedValue + "','False','" + Datos.idUsuario + "'");

                //REGISTRAMOS ENTRADA DEL ALMACEN RECEPTOR
                fn.RegistrarOficial("EntradaInsumo", "Fecha,IDTipoEntrada,IDAlmacenReceptor,Anulada,IDUsuario", "'" + fecha + "',(SELECT IDTipoEntrada from TipoEntrada where TipoEntrada = 'TRASLADO'),'" + cbxAlamcenReceptor.SelectedValue + "','False','" + Datos.idUsuario + "'");

                //OBTENEMOS CODIGO DE ENTRADA Y SALIDA
                string IDEntrada = fn.select_one_value("MAX(IDEntrada)", "EntradaInsumo", "IDEntrada>0", 0);
                string IDSalida = fn.select_one_value("MAX(IDSalida)", "SalidaInsumo", "IDSalida>0", 0);

                //REGISTRAMOS EL TRASLADO
                fn.RegistrarOficial("Traslado", "Fecha,IDEntrada,IDSalida,Anulada", "'" + fecha + "','" + IDEntrada + "','" + IDSalida + "','False'");

                //ENTRADA TIENDA
                if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" + cbxAlamcenReceptor.SelectedValue + "'") == "True")
                {
                    string idApertura = fn.select_one_value("MAX(IDApertura)", "AperturaAlmacen", "IDApertura>0", 0);
                    fn.RegistrarOficial("EntradaTienda", "IDEntrada,IDApertura", "'" + IDEntrada + "','" + idApertura + "'");
                }

                //SALIDA TIENDA
                if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" + cbxAlmacenEmisor.SelectedValue+"'") == "True")
                {
                    string idApertura = fn.select_one_value("MAX(IDApertura)", "AperturaAlmacen", "IDApertura>0", 0);
                    fn.RegistrarOficial("SalidaTienda", "IDSalida,IDApertura", "'" + IDSalida + "','" + idApertura + "'");
                }

                //DETALLE
                for (short i = 0; i < dgvSalida.Rows.Count; i++)
                {
                    string IDInsumo = dgvSalida.Rows[i].Cells["cnCod"].Value.ToString();
                    string insumo = dgvSalida.Rows[i].Cells["cnInsumo"].Value.ToString();
                    string cantidad = dgvSalida.Rows[i].Cells["cnCantidad"].Value.ToString();

                    //REGISTRAMOS DETALLE SALIDA DEL ALMACEN EMISOR
                    fn.RegistrarOficial("detallesalidainsumo", "IDSalidaInsumo,IDInsumo,Cantidad", "'" + IDSalida + "','" + IDInsumo + "','" + cantidad + "'");

                    //RESTAMOS STOCK DEL ALMACEN EMISOR
                    fn.Modificar("StockAlmacen", "Stock=Stock-" + cantidad, "IDAlmacen='" + cbxAlmacenEmisor.SelectedValue + "' and IDInsumo = '"+IDInsumo+"'");

                    //REGISTRAMOS KARDEX DE ALMACEN EMISOR
                    fn.Registrar("Kardex", "'" + DateTime.Now.ToShortDateString() + "','TRASLADO SALIDA','" + IDSalida + "','0','" + cantidad + "',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + cbxAlmacenEmisor.SelectedValue + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + cbxAlmacenEmisor.SelectedValue + "' and IDInsumo='" + IDInsumo + "')");


                    //REGISTRAMOS SU DETALLE ENTRADA
                    fn.RegistrarOficial("DetalleEntradaInsumo", "IDEntradaInsumo,IDInsumo,Cantidad", "'" + IDEntrada + "','" + IDInsumo + "','" + cantidad + "'");

                    //VERIFICAMOS SI EL ALMACEN RECEPTOR TIENE EL INSUMO
                    if (fn.Existencia("*", "StockAlmacen", "IDAlmacen='" + cbxAlamcenReceptor.SelectedValue + "' and IDInsumo='" + IDInsumo + "'") == true)
                    {
                        //AUMENTAMOS EL STOCK DEL ALMACEN RECEPTOR
                        fn.Modificar("StockAlmacen", "Stock=Stock+" + cantidad, "IDAlmacen='" + cbxAlamcenReceptor.SelectedValue + "' and IDInsumo='" + IDInsumo + "'");
                    }
                    else
                    {
                        //REGISTRAMOS EL INSUMO
                        fn.RegistrarOficial("StockAlmacen", "IDInsumo,IDAlmacen,Stock,PermitirControl", "'" + IDInsumo + "','" + cbxAlamcenReceptor.SelectedValue + "','" + cantidad + "','False'");
                    }

                    //REGISTRAMOS KARDEX DE ALMACEN RECEPTOR
                    fn.Registrar("Kardex", "'" + DateTime.Now.ToShortDateString() + "','TRASLADO ENTRADA','" + IDEntrada + "','" + cantidad + "','0',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + cbxAlamcenReceptor.SelectedValue + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + cbxAlamcenReceptor.SelectedValue + "' and IDInsumo='" + IDInsumo + "')");


                }



                dgvSalida.Rows.Clear();
                MessageBox.Show("Traslado Re de Productos REGISTRADA", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private bool validacionGuardar()
        {
            if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" + cbxAlamcenReceptor.SelectedValue + "'") == "True")
            {
                SqlDataReader lector = fn.selectMultiValues("select top(1) * from aperturaAlmacen order by IDApertura desc");
                lector.Read();
                DateTime fecha = Convert.ToDateTime(lector["FechaApertura"].ToString());
                string estado = lector["Estado"].ToString();

                if (estado == "C")
                {
                    MessageBox.Show("El Almacen de Venta se Encuentra Cerrado. Abrir para continuar con el Registro", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lector.Close();
                    return false;
                }

                if (fecha != Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    DialogResult msj = MessageBox.Show("La fecha de Apertura del Almacen de Venta se Encuentra abierta con la fecha (" + fecha.ToShortDateString() + ") siento diferente a la de Hoy : " + DateTime.Now.ToShortDateString() + ". Si Continua Afectara al Cuadre de Almacen con le Fecha: " + fecha.ToShortDateString() + ". Desea Continuar con el Registro?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (msj == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                lector.Close();
            }

            if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" + cbxAlmacenEmisor.SelectedValue + "'") == "True")
            {
                SqlDataReader lector = fn.selectMultiValues("select top(1) * from aperturaAlmacen order by IDApertura desc");
                lector.Read();
                DateTime fecha = Convert.ToDateTime(lector["FechaApertura"].ToString());
                string estado = lector["Estado"].ToString();

                if (estado == "C")
                {
                    MessageBox.Show("El Almacen de Venta se Encuentra Cerrado. Abrir para continuar con el Registro", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lector.Close();
                    return false;
                }

                if (fecha != Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    DialogResult msj = MessageBox.Show("La fecha de Apertura del Almacen de Venta se Encuentra abierta con la fecha (" + fecha.ToShortDateString() + ") siento diferente a la de Hoy : " + DateTime.Now.ToShortDateString() + ". Si Continua Afectara al Cuadre de Almacen con le Fecha: " + fecha.ToShortDateString() + ". Desea Continuar con el Registro?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (msj == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                lector.Close();
            }



            if (dgvSalida.Rows.Count == 0)
            {
                MessageBox.Show("Especifique productos", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //REGISTRAMOS LA SALIDA
            if (fn.Existencia("*", "Almacen", "Almacen='" + cbxAlamcenReceptor.Text + "'") == false)
            {
                MessageBox.Show("Almacen No Existe", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void dgvSalida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dgvSalida.Columns[3].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row2 in dgvSalida.SelectedRows)
                    {
                        DialogResult result = MessageBox.Show("Desea Quitar el Insumo de la Lista", "SisVentas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            if (!row2.IsNewRow) dgvSalida.Rows.Remove(row2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dgvInsumo.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSalidaProductos_Load(object sender, EventArgs e)
        {
            try
            {
                fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen", cbxAlmacenEmisor);
                fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen", cbxAlamcenReceptor);

                cbxAlmacenEmisor.SelectedIndex = -1;
                cbxAlamcenReceptor.SelectedIndex = -1;


                //LLENAMOS DATOS DE CONTROLES
                string IDApertura = fn.select_one_value("MAX(IDApertura)", "AperturaAlmacen", "IDApertura>0", 0);



                SqlDataReader lector = fn.selectMultiValues("select aa.FechaApertura as Fecha,aa.TURNO as Turno,a.Almacen from AperturaAlmacen aa inner join Almacen a on aa.idalmacen = a.IDAlmacen where IDApertura = '" + IDApertura + "'");
                lector.Read();
                lblAlmacen.Text = lector["Almacen"].ToString();
                lblFechaApertura.Text = Convert.ToDateTime(lector["Fecha"].ToString()).ToShortDateString();
                lblTurno.Text = lector["Turno"].ToString();
                lector.Close();
            }
            catch
            {

            }
            
        }

        private void cbxAlmacenEmisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
        }

        private void cbxAlmacenReceptor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (fn.selectValue("select PermiteVender from almacen where IDAlmacen = '" + cbxAlamcenReceptor.SelectedValue + "'") == "True")
            {
                gbxDatosTienda.Visible = true;
            }
            else
            {
                gbxDatosTienda.Visible = false;
            }
        }

        private void cbxAlamcenReceptor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxAlmacenEmisor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (fn.selectValue("select PermiteVender from almacen where IDAlmacen = '" + cbxAlmacenEmisor.SelectedValue + "'") == "True")
            {
                gbxDatosTienda.Visible = true;
            }
            else
            {
                gbxDatosTienda.Visible = false;
            }
        }
    }
}
