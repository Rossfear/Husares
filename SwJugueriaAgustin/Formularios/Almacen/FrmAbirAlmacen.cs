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
    public partial class FrmAbirAlmacen : Form
    {
        bool bloqueo = true;   
        
        public FrmAbirAlmacen()
        {
            InitializeComponent();
        }

        Funciones fn = new Funciones();
        private bool validacionGuardar()
        {
            if(fn.Existencia("*","AperturaAlmacen","FechaApertura = '"+DateTime.Now.ToShortDateString()+ "' and Turno='MAÑANA' AND IDSucursal = '" + Datos.idSucursal+"'") == true)
            {
                MessageBox.Show("Ya Existe una Apertura de Almacen con la Fecha Actual","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            SqlDataReader lector = fn.selectMultiValues("select top(1) * from aperturaAlmacen where Estado = 'A' and IDSucursal = '"+Datos.idSucursal+ "' order by FechaApertura desc");
            while(lector.Read())
            {
                string fecha = lector["FechaApertura"].ToString();
                MessageBox.Show("Existe Una apertua de Almacen Abierta: \nFecha: " + Convert.ToDateTime(fecha).ToShortDateString(), "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            lector.Close();

            return true;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (validacionGuardar() == false)
            {
                return;
            }

            DialogResult msj = MessageBox.Show("¿Desea Abrir Almacen?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            {
                if (msj == DialogResult.OK)
                {
                    fn.RegistrarOficial("AperturaAlmacen", "FechaApertura,Hora,IDUsuario,Estado,IDAlmacen,Turno,IDSucursal",
                        "'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + Datos.idUsuario + "','A','"+cbxAlmacen.SelectedValue+"','MAÑANA','"+Datos.idSucursal+"'");

                    string IDApertura = fn.select_one_value("MAX(IDApertura)", "AperturaAlmacen", "IDApertura>0", 0);

                    for (int i = 0; i < dgvInsumo.Rows.Count; i++)
                    {
                        string idStockAlmacen = dgvInsumo.Rows[i].Cells["cnCodigo"].Value.ToString();
                        string cantidad = dgvInsumo.Rows[i].Cells["cnCantidadApertura"].Value.ToString();

                        fn.RegistrarOficial("[AperturaAlmacen.Detalle]", "IDApertura,IDStockAlmacen,CantidadInicial", "'" + IDApertura + "','" + idStockAlmacen + "','" + cantidad + "'");
                        fn.Modificar("StockAlmacen", "Stock='" + cantidad + "'", "IDStockAlmacen='"+idStockAlmacen+"'");

                        //REGISTRAMOS KARDEX
                        fn.RegistrarOficial("Kardex", "Fecha,Proceso,CodProceso,Entrada,Salida,Saldo,IDStockAlmacen",
                            "'"+DateTime.Now.ToShortDateString()+"','CUADRE DE ALMACEN','"+IDApertura+"','0','0','"+cantidad+"','"+idStockAlmacen+"'");
                    }

                    MessageBox.Show("Apertura de Almacen Correctamente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void FrmAbirAlmacen_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where PermiteVender='True' and IDSucursal='"+Datos.idSucursal+"'", cbxAlmacen);

                DataTable tabla = new DataTable();
                SqlCommand cmd = fn.procedimientoAlmacenado("Almacen_AperturaAlmacen_Listar");
                cmd.Parameters.AddWithValue("@IDSucursal", Datos.idSucursal);
                cmd.Parameters.AddWithValue("@IDAlmacen", cbxAlmacen.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                dgvInsumo.DataSource = tabla;

                foreach (DataGridViewRow row in dgvInsumo.Rows)
                {
                    row.Height = 25;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            frmAddCantidad frm = new frmAddCantidad();
            frm.ShowDialog();

            if(frm.Cancelado == false)
            {
                if(Datos.contraseñaSeguridad == frm.txtCantidad.Text)
                {
                    dgvInsumo.Columns["cnCantidadApertura"].ReadOnly = false;
                    bloqueo = false;
                    MessageBox.Show("Contraseña Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvInsumo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(bloqueo == false)
                {
                    if (e.ColumnIndex == dgvInsumo.Columns["cnCantidadApertura"].Index && e.RowIndex >= 0)
                    {
                        foreach (DataGridViewRow row2 in dgvInsumo.SelectedRows)
                        {
                            frmAddCantidad frm = new frmAddCantidad();
                            frm.lblCantidad.Text = "CANTIDAD";
                            frm.ShowDialog();

                            if (frm.Cancelado == false)
                            {
                                row2.Cells["cnCantidadApertura"].Value = frm.txtCantidad.Text;
                            }


                        }
                    }
                }
                
            }
            catch
            {

            }
        }

        
    }
}
