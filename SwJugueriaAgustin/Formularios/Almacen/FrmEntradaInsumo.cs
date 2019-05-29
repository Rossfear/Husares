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
    public partial class FrmEntradaInsumo : Form
    {
        Funciones fn = new Funciones();
        string idApertura;
        public FrmEntradaInsumo()
        {
            InitializeComponent();
        }

        private void FrmEntradaInsumo_Load(object sender, EventArgs e)
        {
            try
            {
                if(Datos.administrador == true)
                {
                    fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where IDSucursal = '" + Datos.idSucursal + "'", cbxAlamcenReceptor);
                    fn.añadir_ddl("TipoEntrada", "IDTipoEntrada", "TipoEntrada", cbxTipoEntrada);
                }
                else
                {
                    fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where IDSucursal = '" + Datos.idSucursal + "' and PermiteVender = '1'", cbxAlamcenReceptor);
                    fn.añadir_ddl("TipoEntrada", "IDTipoEntrada", "TipoEntrada where Estado='True'", cbxTipoEntrada);
                }

                
                
                cbxTipoEntrada.SelectedIndex = -1;
                cbxAlamcenReceptor.SelectedIndex = -1;


                SqlDataReader lector = fn.selectMultiValues("select top(1) aa.IDApertura,aa.FechaApertura as Fecha,aa.TURNO as Turno,a.Almacen  from AperturaAlmacen aa  inner join Almacen a on aa.idalmacen = a.IDAlmacen  where aa.IDSucursal = '"+Datos.idSucursal+"' order by FechaApertura desc");
                while(lector.Read())
                {
                    idApertura = lector["IDApertura"].ToString();
                    lblAlmacen.Text = lector["Almacen"].ToString();
                    lblFechaApertura.Text = Convert.ToDateTime(lector["Fecha"].ToString()).ToShortDateString();
                    lblTurno.Text = lector["Turno"].ToString();
                }
                lector.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        

        private void cbxAlmacenReceptor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void MostrarDatosGrid()
        {
            fn.ActualizarGrid(dgvInsumo, "select i.IDInsumo,i.Insumo,um.UniMedida from Insumo i inner join UnidadMedida um on i.IDUniMedida = um.IDUniMedida where i.Insumo like '%"+txtBuscar.Text+"%'");
        }

        private void dgvInsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmAddCantidad frm = new frmAddCantidad();
                frm.ShowDialog();

                if (frm.Cancelado == false && string.IsNullOrWhiteSpace(frm.txtCantidad.Text) == false)
                {
                    string idInsumo = dgvInsumo.CurrentRow.Cells[0].Value.ToString();
                    string insumo = dgvInsumo.CurrentRow.Cells[1].Value.ToString();
                    string cantidad = frm.txtCantidad.Text;
                    dgvSalida.Rows.Add(idInsumo, insumo, cantidad, 'X');
                    txtBuscar.Focus();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validacionGuardar() == false)
            {
                return;
            }

            DialogResult msj = MessageBox.Show("Desea REGISTRAR la Entrada de Insumos?", "Factu-TED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if (msj == DialogResult.OK)
            {
                string fecha = DateTime.Now.ToShortDateString();

                //REGISTRAMOS ENTRADA
                fn.RegistrarOficial("EntradaInsumo", "Fecha,IDTipoEntrada,IDAlmacenReceptor,Anulada,IDUsuario",
                    "'" + fecha + "','"+cbxTipoEntrada.SelectedValue+"','" + cbxAlamcenReceptor.SelectedValue + "','False','"+ Datos.idUsuario + "'");

                //OBTENEMOS EL CODIGO DE ENTRADA
                string IDEntrada = fn.select_one_value("MAX(IDEntrada)", "EntradaInsumo", "IDEntrada>0", 0);

                if(fn.selectValue("select PermiteVender from almacen where IDAlmacen = '"+ cbxAlamcenReceptor.SelectedValue + "'") == "True")
                {
                    //REGISTRAMOS LA ENTRADA A TIENDA
                    fn.RegistrarOficial("entradatienda", "IDEntrada,IDApertura", "'" + IDEntrada + "','" + idApertura + "'");
                }
                

                //REGISTRAMOS DETALLE ENTRADA
                for (short i = 0; i < dgvSalida.Rows.Count; i++)
                {
                    string IDInsumo = dgvSalida.Rows[i].Cells["cnCod"].Value.ToString();
                    string insumo = dgvSalida.Rows[i].Cells["cnInsumo"].Value.ToString();
                    string cantidad = dgvSalida.Rows[i].Cells["cnCantidad"].Value.ToString();

                    //REGISTRAMOS EL DETALLE DE ENTRADA
                    fn.RegistrarOficial("detalleEntradaInsumo", "IDEntradaInsumo,IDInsumo,Cantidad,Anulado", 
                        "'" + IDEntrada + "','" + IDInsumo + "','" + cantidad + "','0'");

                    
                    //VERIFICAMSO SI ESTA EN LA TABLA STOCKALMACEN
                    if (fn.Existencia("*","StockAlmacen","IDAlmacen='"+cbxAlamcenReceptor.SelectedValue +"' and IDInsumo='"+IDInsumo+"'") == true)
                    {
                        //AUMENTAMOS STOCK STOCK
                        fn.Modificar("StockAlmacen", "Stock=Stock+" + cantidad, "IDAlmacen='" + cbxAlamcenReceptor.SelectedValue + "' and IDInsumo='" + IDInsumo + "'");
                    }
                    else
                    {
                        //SI NO EXISTE LO REGISTRAMOS CON STOCK QUE INGRESA
                        fn.RegistrarOficial("StockAlmacen", "IDInsumo,IDAlmacen,Stock,PermitirControl", "'" + IDInsumo + "','" + cbxAlamcenReceptor.SelectedValue + "','" + cantidad + "','False'");
                    }

                    //REGISTRAMOS EL KARDEX
                    fn.Registrar("Kardex", "'" + DateTime.Now.ToShortDateString() + "','ENTRADA " + cbxTipoEntrada.Text + "','" + IDEntrada + "','" + cantidad + "','0',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + cbxAlamcenReceptor.SelectedValue + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + cbxAlamcenReceptor.SelectedValue + "' and IDInsumo='" + IDInsumo + "')");
                }
                dgvSalida.Rows.Clear();
                MessageBox.Show("Entrada de Insumo REGISTRADA con el Codigo "+IDEntrada, "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool validacionGuardar()
        {
            if (dgvSalida.Rows.Count == 0)
            {
                MessageBox.Show("Especifique productos", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dgvSalida.Rows.Count == 0)
            {
                MessageBox.Show("Especifique productos", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cbxTipoEntrada.SelectedValue == null)
            {
                MessageBox.Show("Tipo de Entrada No Existe", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cbxAlamcenReceptor.SelectedValue == null)
            {
                MessageBox.Show("Almacen Receptor No Existe", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" + cbxAlamcenReceptor.SelectedValue + "'") == "True")
            {
                SqlDataReader lector = fn.selectMultiValues("select * from aperturaAlmacen where IDApertura = '"+idApertura+"'");
                while(lector.Read())
                {
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
                }
               
                lector.Close();
            }

            return true;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dgvInsumo.Focus();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxAlamcenReceptor_SelectionChangeCommitted(object sender, EventArgs e)
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

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
