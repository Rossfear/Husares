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
    public partial class Frm_Pro : Form
    {
        Funciones fn = new Funciones();
        bool editar;
        string idProducto;
        public static string IDPresentacion, Producto, utilidad;
        public Frm_Pro()
        {
            InitializeComponent();
        }

        private void Frm_Pro_Load(object sender, EventArgs e)
        {
            mostrarGrid();
            mostrarCategoria();
            Bloquar();
            editar = false;
        }
        #region Complementos
        private void mostrarCategoria()
        {
            fn.añadir_ddl("Categoria", "IDCategoria", "Categoria", cbxCategoria);
        }
        private void mostrarSubCategoria()
        {
            fn.añadir_ddl("SubCategoria", "IDSubCategoria", "SubCategoria WHERE IDCategoria=(select IDCategoria from Categoria where Categoria='" + cbxCategoria.Text + "')", cbxSubCategoria);
        }
        private void Bloquar()
        {
            gbxProducto.Enabled = false;
            btnNUEVO.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnCancelar.Enabled = false;



            btnNUEVO.Select();
        }
        private void DesBloquar()
        {
            gbxProducto.Enabled = true;
            btnNUEVO.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            cbxCategoria.Focus();
        }

        private void btnNUEVO_Click(object sender, EventArgs e)
        {
            DesBloquar();
            editar = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            eGuardar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            eEditar();
        }
        private void eEditar()
        {
            editar = true;

            idProducto = dgvProducto.CurrentRow.Cells["ID"].Value.ToString();
            cbxCategoria.Text = dgvProducto.CurrentRow.Cells["CATEGORIA"].Value.ToString();
            cbxSubCategoria.Text = dgvProducto.CurrentRow.Cells["SUBCATEGORIA"].Value.ToString();
            txtProducto.Text = dgvProducto.CurrentRow.Cells["NOMBRE PRODUCTO"].Value.ToString();

            DesBloquar();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            eCancelar();
        }
        private void eCancelar()
        {
            limpiar();
            Bloquar();

            editar = false; ;
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            mostrarGrid();
        }
        private void mostrarGrid()
        {
            fn.MostrarGri("p.IDProducto as [ID],c.Categoria as [CATEGORIA],SC.SubCategoria AS [SUBCATEGORIA],P.Producto AS [NOMBRE PRODUCTO],p.ACTIVO",
                          "Producto p left join SubCategoria sc on p.idsubcategoria = sc.IDSubCategoria left join Categoria c on sc.IDCategoria = c.IDCategoria",
                          "p.Producto like '%" + txtBuscador.Text + "%' and c.Categoria like '%" + cbxCategoria.Text + "%' and  sc.SubCategoria like '%" + cbxSubCategoria.Text + "%' order by ID desc", dgvProducto, "Producto");
        }

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarSubCategoria();
            mostrarGrid();
        }

        private void cbxCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxSubCategoria.Focus();
            }
        }

        private void cbxSubCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //si existe la subcategoria pasa el focues
                if (fn.Existencia("*", "SubCategoria", "SubCategoria='" + cbxSubCategoria.Text + "' and IDCategoria='" + cbxCategoria.SelectedValue + "'") == true)
                {
                    txtProducto.Focus();
                }
                else
                {
                    //si no existe -> te da la alternativa de registrarlo
                    DialogResult msj = MessageBox.Show("La SubCategoria Ingresada no se Existe. Desea Registrarla?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (msj == DialogResult.OK)
                    {
                        //si seleeciona si verificamos si la CATEGORIA es correcta para evitar errores
                        bool existeCategoria = fn.Existencia("*", "Categoria", "Categoria='" + cbxCategoria.Text + "'");
                        if (existeCategoria == true)
                        {
                            //si todo es correcto se registrar la subcategoria
                            fn.Registrar("SubCategoria", "'" + cbxSubCategoria.Text + "','" + cbxCategoria.SelectedValue + "'");
                            string subcate = cbxSubCategoria.Text;
                            mostrarSubCategoria();
                            cbxSubCategoria.Text = subcate;
                            txtProducto.Focus();
                        }
                        else
                        {
                            //Muestra mensaje de la no existencia de la categoria
                            MessageBox.Show("Ingrese o Seleccione una categoria Correcta", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvProducto.Focus();
            }
        }

        private void dgvProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmPresentaciones f = new FrmPresentaciones();
                f.lblProducto.Text = dgvProducto.CurrentRow.Cells[3].Value.ToString();
                FrmPresentaciones.IDProducto = dgvProducto.CurrentRow.Cells[0].Value.ToString();
                f.ShowDialog();
                txtBuscador.Focus();
            }
        }
        private void eGuardar()
        {
            if(validacionGuardar() == false)
            {
                return;
            }

            if (editar == false)
            {
                fn.RegistrarOficial("Producto",
                    "IDSubcategoria,Producto,Activo",
                    "'" + cbxSubCategoria.SelectedValue.ToString() + "','" + txtProducto.Text.TrimEnd() + "','True'");
                MessageBox.Show("Datos registrados correctamente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                fn.Modificar("Producto", "IDSubcategoria='" + cbxSubCategoria.SelectedValue.ToString() + "',Producto='" + txtProducto.Text.TrimEnd() + "'", "IDProducto='" + idProducto + "'");
                editar = false;
                MessageBox.Show("Datos Actuliazados correctamente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limpiar();
            Bloquar();
            mostrarGrid();
        }

        private bool validacionGuardar()
        {
            if (string.IsNullOrWhiteSpace(txtProducto.Text) == true)
            {
                MessageBox.Show("Verificar el ingreso de Datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }



            return true;
        }

        private void cbxSubCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eEditar();
        }

        private void eLIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar El Plato " + dgvProducto.CurrentRow.Cells["NOMBRE PRODUCTO"].Value.ToString(), "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (msj == DialogResult.OK)
            {
                idProducto = dgvProducto.CurrentRow.Cells["ID"].Value.ToString();
                SqlDataReader lector = fn.selectMultiValues("select * from Presentacion where IDProducto='"+idProducto+"'");
                while(lector.Read())
                {
                    string idPresentacion = lector["IDPresentacion"].ToString();
                    fn.Eliminar("Receta","IDPresentacion='"+idPresentacion+"'");
                }
                lector.Close();

                fn.Eliminar("Presentacion", "IDProducto = '" + idProducto + "'");
                fn.Eliminar("Producto", "IDProducto = '" + idProducto + "'");
                MessageBox.Show("Producto Eliminado");
                mostrarGrid();
            }
        }

        private void cbxCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cbxCategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mostrarSubCategoria();
            mostrarGrid();
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idProducto = dgvProducto.CurrentRow.Cells["ID"].Value.ToString();
            fn.Modificar("Producto", "Activo=1", "IDProducto='"+idProducto+"'");
            mostrarGrid();
        }

        private void deshabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idProducto = dgvProducto.CurrentRow.Cells["ID"].Value.ToString();
            fn.Modificar("Producto", "Activo=0", "IDProducto='" + idProducto + "'");
            mostrarGrid();
        }

        private void verPresentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPresentaciones f = new FrmPresentaciones();
                f.lblProducto.Text = dgvProducto.CurrentRow.Cells[3].Value.ToString();
                FrmPresentaciones.IDProducto = dgvProducto.CurrentRow.Cells[0].Value.ToString();
                f.ShowDialog();
                txtBuscador.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbxSubCategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void limpiar()
        {


            txtProducto.Text = "";
        }

        #endregion

    }
}
