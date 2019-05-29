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
    public partial class FrmStockAlmacen : Form
    {
        Clases.Funciones fn = new Clases.Funciones();
        bool QuiereGuardar;
        string IDStockAlamcen;
        public FrmStockAlmacen()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += FrmProductosPrimos_KeyDown;
        }

        private void FrmProductosPrimos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                EGuardar();
            }
        }

        private void Bloquear(bool i)
        {
            btnNuevo.Enabled = i;
            btnGuardar.Enabled = !i;
            
            //btnEliminar.Enabled = i;
            btnCancelar.Enabled = !i;

            groupBox1.Enabled = !i;
            
            
            
        }
        private void MostrarDatosGrid()
        {
            fn.ActualizarGrid(dgvProductos, "select sa.IDStockAlmacen,a.Almacen,i.Insumo,sa.Stock,um.UniMedida,sa.PermitirControl from stockalmacen sa,Almacen a,Insumo i,UnidadMedida um where sa.IDInsumo = i.IDInsumo and sa.IDAlmacen = a.IDAlmacen and i.IDUniMedida = um.IDUniMedida and a.Almacen = '" + cbxAlmacen.Text + "' and i.Insumo like '%" + txtBuscar.Text + "%'");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EGuardar();
        }

        private void EGuardar()
        {
            if(validacionGuardar() == false)
            {
                return;
            }

            registrar();
            
            Bloquear(true);
            Limpiarcontroles();
            MostrarDatosGrid();
            QuiereGuardar = true;
            btnNuevo.Select();
            MessageBox.Show("Operacion Correcta", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void registrar()
        {
            string permitirControl;

            if(checkBox1.Checked == true)
            {
                permitirControl = "True";
            }
            else
            {
                permitirControl = "False";
            }

            //GUARDAR
            if (QuiereGuardar == true)
            {

                DialogResult msj = MessageBox.Show("¿Desea REGISTRAR el Insumo?", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msj == DialogResult.OK)
                {
                    fn.RegistrarOficial("StockAlmacen", "IDInsumo,IDAlmacen,Stock,PermitirControl", "'" + cbxInsumo.SelectedValue + "','" + cbxAlmacen.SelectedValue + "','" + txtStockTotal.Text + "','" + permitirControl + "'");
                }
                else
                {
                    return;
                }
            }
            else
            {

                DialogResult msj = MessageBox.Show("¿Desea ACTUALIZAR el Insumo?", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msj == DialogResult.OK)
                {
                    fn.Modificar("StockAlmacen", "IDAlmacen='"+cbxAlmacen.SelectedValue+"',IDInsumo='"+cbxInsumo.SelectedValue+"',Stock='"+txtStockTotal.Text+"',PermitirControl='"+permitirControl+"'", "IDStockAlmacen='"+IDStockAlamcen+"'");

                    //REGISTRAMOS KARDEX
                    fn.RegistrarOficial("Kardex", "Fecha,Proceso,CodProceso,Entrada,Salida,Saldo,IDStockAlmacen",
                        "'" + DateTime.Now.ToShortDateString() + "','EDICION DE INSUMO','" + IDStockAlamcen + "','0','0','" + txtStockTotal.Text + "','" + IDStockAlamcen + "'");
                }
                else
                {
                    return;
                }
            }
        }

        private bool validacionGuardar()
        {
            

           

            if (fn.Existencia("*","Insumo","Insumo='"+cbxInsumo.Text+"'") == false)
            {
                MessageBox.Show("El Insumo No Existe", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }

            if(QuiereGuardar == true)
            {
                if (fn.Existencia("*", "StockAlmacen", "IDAlmacen='" + cbxAlmacen.SelectedValue + "' and IDInsumo='" + cbxInsumo.SelectedValue + "'") == true)
                {
                    MessageBox.Show("El Insumo que deseas registrar en el Almacen ya existe", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            

            if (txtStockTotal.Text == "")
            {
                error.SetError(txtStockTotal, "Debe ingresar stock del producto");
                txtStockTotal.Focus(); return false;
            }
            
        

            return true;
        }

        private void frmProductosPrimos_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Insumo", "IDInsumo", "Insumo", cbxInsumo);
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where PermiteEntrada='True'", cbxAlmacen);
            Bloquear(true);
            QuiereGuardar = true;
            
            btnNuevo.Select();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Bloquear(false);
            cbxInsumo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            Bloquear(true);
            Limpiarcontroles();
        }

        private void Limpiarcontroles()
        {
            cbxInsumo.Text = "";
            checkBox1.Checked = false;
            txtStockTotal.Text = "0";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea eliminar el Registro Seleccionado?", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(msj == DialogResult.OK)
            {
                if (dgvProductos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos", ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                fn.Eliminar("ProductoPrimo", "IDProductoPrimo='" + dgvProductos.CurrentRow.Cells["ID"].Value.ToString() + "'");
                MostrarDatosGrid();
            }

            
        }

    

    

        private void txtStock_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
        }

        

       

      

       


        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            
            
            
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if(validacionEliminar() == false)
            {
                return;
            }

            DialogResult msj = MessageBox.Show("Desea Elimar el insumo Seleccionado", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(msj == DialogResult.OK)
            {
                string idInsumo = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                fn.Eliminar("DetalleStock", "IDInsumo='" + idInsumo + "'");
                fn.Eliminar("Insumo", "IDInsumo='" + idInsumo + "'");

                MostrarDatosGrid();
                MessageBox.Show("Datos Eliminados", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private bool validacionEliminar()
        {
            if(fn.Existencia("*","Receta","IDInsumo='"+ dgvProductos.CurrentRow.Cells[0].Value.ToString() + "'") == true)
            {
                MessageBox.Show("El Insumo Seleccionado esta Especificado en una Receta. No se Puede Eliminar", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void cbxAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
        }

        private void cbxInsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                fn.añadir_ddl("Insumo", "IDInsumo", "Insumo", cbxInsumo);
            }
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos", ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Bloquear(false);
            Limpiarcontroles();
            QuiereGuardar = false;

            IDStockAlamcen = dgvProductos.CurrentRow.Cells["IDStockAlmacen"].Value.ToString();
            cbxAlmacen.Text = dgvProductos.CurrentRow.Cells["Almacen"].Value.ToString();
            cbxInsumo.Text = dgvProductos.CurrentRow.Cells["Insumo"].Value.ToString();
            txtStockTotal.Text = dgvProductos.CurrentRow.Cells["STOCK"].Value.ToString();
            string PermitirControl = dgvProductos.CurrentRow.Cells["PermitirControl"].Value.ToString();

            if (PermitirControl == "True")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar el insumo Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (msj == DialogResult.OK)
            {
                string idStockAlmacen = dgvProductos.CurrentRow.Cells["IDStockAlmacen"].Value.ToString();
                fn.Eliminar("Receta", "IDStockAlmacen = '" + idStockAlmacen + "'");
                fn.Eliminar("StockAlmacen", "IDStockAlmacen = '" + idStockAlmacen + "'");
                MostrarDatosGrid();
            }
            
        }
    }
}
