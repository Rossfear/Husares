using SwJugueriaAgustin.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class frmReceta : Form
    {
        public static string IDPresentacion;
        bool exite;
        Funciones fn = new Funciones();
        public frmReceta()
        {
            InitializeComponent();
        }

        private void frmReceta_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where PermiteVender='True'", cbxAlmacen);
            MostrarReceta();
            
        }


        private void MostrarReceta()
        {
            if (fn.Existencia("*", "Receta", "IDPresentacion = '" + IDPresentacion + "'"))
            {
                exite = true;


                //Obtenemos los datos
                SqlConnection conexion = new SqlConnection(Funciones.preconex);
                string consulta = "SELECT sa.IDStockAlmacen,i.Insumo,r.Cantidad,i.Costo,u.UniMedida  FROM Insumo i,Receta r,UnidadMedida u,Presentacion p,StockAlmacen sa where r.IDStockAlmacen = sa.IDStockAlmacen and sa.IDInsumo = i.IDInsumo and r.IDPresentacion = p.IDPresentacion and i.IDUniMedida = u.IDUniMedida and p.IDPresentacion='" + IDPresentacion+"'";
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                int p = 0;
                while (lector.Read())
                {
                    p = Convert.ToInt16(lector[0].ToString());
                    dgvRecetaProducto.Rows.Add(lector["IDStockAlmacen"].ToString(), lector["Insumo"].ToString(), lector["Cantidad"].ToString(), lector["Costo"].ToString(), lector["UniMedida"].ToString(), 'X');
                }
                lector.Close();
                conexion.Close();
                ;
            }
            else
            {
                exite = false;
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dgvProductoPrimo.Focus();
            }
        }

        private void dgvProductoPrimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (dgvProductoPrimo.RowCount > 0)
                    {
                        e.SuppressKeyPress = true;
                        //Fila Seleccionada
                        int select = dgvProductoPrimo.CurrentRow.Index;
                        string codProducto = dgvProductoPrimo.Rows[select].Cells[0].Value.ToString();
                        string Producto = dgvProductoPrimo.Rows[select].Cells["Insumo"].Value.ToString();

                        frmAddCantidad frm = new frmAddCantidad();
                        frm.ShowDialog();

                        if(frm.Cancelado == false)
                        {
                            float cantidad = Convert.ToSingle(frm.txtCantidad.Text);
                            string uniMedia = dgvProductoPrimo.Rows[select].Cells["UniMedida"].Value.ToString();
                            string costo = fn.select_one_value("Costo", "Insumo", "Insumo='" + Producto + "'", 0);

                            dgvRecetaProducto.Rows.Add(codProducto, Producto, cantidad, costo, uniMedia, "X");
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El detalle no se agrego a la receta","AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msj = MessageBox.Show("Desea REGISTRAR LA RECETA?", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(msj == DialogResult.OK)
                {
                    fn.Eliminar("Receta", "IDPresentacion='" + IDPresentacion + "'");

                    for (short i = 0; i < dgvRecetaProducto.Rows.Count; i++)
                    {
                        fn.Registrar("Receta", "'" + IDPresentacion + "','" + dgvRecetaProducto.Rows[i].Cells[0].Value.ToString() + "','" + dgvRecetaProducto.Rows[i].Cells[2].Value.ToString() + "'");
                    }
                    MessageBox.Show("Datos REGISTRADO", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                
                

            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void Guardar()
        {

        }

        private void dgvRecetaProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvRecetaProducto.CurrentRow.Cells[5].Selected == true)
            {
                DialogResult msj = MessageBox.Show("Desea Quitarlo de la lista", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(msj == DialogResult.OK)
                {
                   
                        dgvRecetaProducto.Rows.Remove(dgvRecetaProducto.CurrentRow);

                        

                    
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();    
        }

        private void MostrarDatosGrid()
        {
            fn.ActualizarGrid(dgvProductoPrimo, "select sa.IDStockAlmacen,i.Insumo,sa.Stock,um.UniMedida from stockalmacen sa,Almacen a,Insumo i,UnidadMedida um where sa.IDInsumo = i.IDInsumo and sa.IDAlmacen = a.IDAlmacen and i.IDUniMedida = um.IDUniMedida and a.Almacen = '" + cbxAlmacen.Text + "' and i.Insumo like '%" + txtBuscar.Text + "%'");
        }

        private void cbxAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
        }
    }
}
