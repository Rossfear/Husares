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
    public partial class FrmSalidaInsumo : Form
    {
        Funciones fn = new Funciones();
        string idApertura;
        public FrmSalidaInsumo()
        {
            InitializeComponent();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
        }
        private void MostrarDatosGrid()
        {
            fn.ActualizarGrid(dgvInsumo, "select i.IDInsumo as Codigo,i.Insumo,sa.Stock,um.UniMedida from stockalmacen sa,Almacen a,Insumo i,UnidadMedida um where sa.IDInsumo = i.IDInsumo and sa.IDAlmacen = a.IDAlmacen and i.IDUniMedida = um.IDUniMedida and a.Almacen = '" + cbxAlamcenEmisor.Text + "' and i.Insumo like '%" + txtBuscar.Text + "%'");
        }

        private void dgvInsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmAddCantidad frm = new frmAddCantidad();
                frm.ShowDialog();

                if (frm.Cancelado == false)
                {
                    string idInsumo = dgvInsumo.CurrentRow.Cells[0].Value.ToString();
                    string insumo = dgvInsumo.CurrentRow.Cells[1].Value.ToString();
                    string cantidad = frm.txtCantidad.Text;
                    dgvSalida.Rows.Add(idInsumo, insumo, cantidad, 'X');
                }
            }
        }

        private void FrmSalidaInsumo_Load(object sender, EventArgs e)
        {
            try
            {
                if (Datos.administrador == true)
                {
                    fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where IDSucursal = '" + Datos.idSucursal + "'", cbxAlamcenEmisor);
                    fn.añadir_ddl("TipoSalida", "IDTipoSalida", "TipoSalida", cbxTipoSalida);
                }
                else
                {
                    fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where IDSucursal = '" + Datos.idSucursal + "' and PermiteVender = '1'", cbxAlamcenEmisor);
                    fn.añadir_ddl("TipoSalida", "IDTipoSalida", "TipoSalida where Estado='True'", cbxTipoSalida);
                }

                cbxAlamcenEmisor.SelectedIndex = -1;
                cbxTipoSalida.SelectedIndex = -1;

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validacionGuardar() == false)
            {
                return;
            }

            DialogResult msj = MessageBox.Show("Desea REGISTRAR la Salida de Insumos?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string fecha = DateTime.Now.ToShortDateString();
            if (msj == DialogResult.OK)
            {
                //REGISTRAMOS SALIDA
                fn.RegistrarOficial("SalidaInsumo", "Fecha,IDTipoSalida,IDAlmacenEmisor,Anulada,IDUsuario",
                    "'" + fecha + "','" + cbxTipoSalida.SelectedValue + "','" + cbxAlamcenEmisor.SelectedValue + "','False','" + Datos.idUsuario + "'");

                //OBTENEMOS EL CODIGO DE salida
                string IDSalida = fn.select_one_value("MAX(IDSalida)", "SalidaInsumo", "IDSalida>0", 0);

                if(fn.selectValue("select PermiteVender from almacen where IDAlmacen = '"+cbxAlamcenEmisor.SelectedValue+"'") == "True")
                {
                    //REGISTRAMOS LA SALIDA A LA TINEDA
                    fn.RegistrarOficial("salidatienda", "IDSalida,IDApertura", "'" + IDSalida + "','" + idApertura + "'");
                }
                

                //REGISTRAMOS DETALLE salida
                for (short i = 0; i < dgvSalida.Rows.Count; i++)
                {
                    string IDInsumo = dgvSalida.Rows[i].Cells["cnCod"].Value.ToString();
                    string insumo = dgvSalida.Rows[i].Cells["cnInsumo"].Value.ToString();
                    string cantidad = dgvSalida.Rows[i].Cells["cnCantidad"].Value.ToString();


                    //REGISTRAMOS EL DETALLE DE SALIDA
                    fn.RegistrarOficial("detalleSalidaInsumo", "IDSalidaInsumo,IDInsumo,Cantidad,Anulado", 
                        "'" + IDSalida + "','" + IDInsumo + "','" + cantidad + "','0'");

                    //AUMENTAMOS STOCK STOCK
                    fn.Modificar("StockAlmacen", "Stock=Stock-" + cantidad, "IDAlmacen='" + cbxAlamcenEmisor.SelectedValue + "' and IDInsumo='" + IDInsumo + "'");

                    //REGISTRAMOS EL KARDEX
                    fn.RegistrarOficial("Kardex", "Fecha,Proceso,CodProceso,Entrada,Salida,Saldo,IDStockAlmacen", 
                        "'" + fecha + "','SALIDA " + cbxTipoSalida.Text + "','" + IDSalida + "','0','"+ cantidad + "',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + cbxAlamcenEmisor.SelectedValue + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + cbxAlamcenEmisor.SelectedValue + "' and IDInsumo='" + IDInsumo + "')");
                }
                dgvSalida.Rows.Clear();
                MessageBox.Show("Salida de Insumo REGISTRADA con el Codigo " + IDSalida, "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private bool validacionGuardar()
        {
            if (dgvSalida.Rows.Count == 0)
            {
                MessageBox.Show("Especifique productos", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cbxTipoSalida.SelectedValue == null)
            {
                MessageBox.Show("Tipo de salida No Existe", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cbxAlamcenEmisor.SelectedValue == null)
            {
                MessageBox.Show("Almacen Receptor No Existe", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" + cbxAlamcenEmisor.SelectedValue + "'") == "True")
            {
                SqlDataReader lector = fn.selectMultiValues("select top(1) * from aperturaAlmacen where IDApertura = '"+idApertura+"'");
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
                        DialogResult msj = MessageBox.Show("La fecha de Apertura del Almacen de Tienda se Encuentra abierta con la fecha (" + fecha.ToShortDateString() + ") siento diferente a la de Hoy : " + DateTime.Now.ToShortDateString() + ". Si Continua Afectara al Cuadre de Almacen con le Fecha: " + fecha.ToShortDateString() + ". Desea Continuar con el Registro?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

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

        private void cbxAlamcenEmisor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (fn.selectValue("select PermiteVender from almacen where IDAlmacen = '" + cbxAlamcenEmisor.SelectedValue + "'") == "True")
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
