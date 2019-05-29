using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SwJugueriaAgustin.Clases;

namespace SwJugueriaAgustin.FormAdmin
{
    public partial class FrmSubCategoria : Form
    {

        Boolean Editar;
        Funciones ManipularDatos = new Funciones();
        String Codigo = "";
        String fecha;


        public static string conex = Funciones.preconex;
        SqlConnection cn = new SqlConnection(conex);
        public FrmSubCategoria()
        {
            InitializeComponent();
        }

        private void FrmSubCategoria_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dap = new SqlDataAdapter("SELECT IDCATEGORIA,CATEGORIA FROM  CATEGORIA ORDER BY CATEGORIA ", cn);

            DataTable tbl = new DataTable();
            dap.Fill(tbl);
            cbo_categoria.DataSource = tbl;
            cbo_categoria.DisplayMember = "CATEGORIA";
            cbo_categoria.ValueMember = "IDCATEGORIA";

            this.Activar();
            this.Bloquear();
            txt_sub_categoria.Focus();

            ManipularDatos.ActualizarGrid(this.dataGridView1, "SELECT  IDSubCategoria AS ID, SubCategoria FROM SUBCATEGORIA WHERE IDCategoria = " + Convert.ToInt16(cbo_categoria.SelectedValue) + " ORDER BY SubCategoria  ");

        }

        public void Bloquear()
        {

            txt_sub_categoria.Enabled = false;

        }

        public void Desbloquear()
        {

            txt_sub_categoria.Enabled = true;
        }
        public void Activar()
        {
            BtnNuevo.Enabled = true;
            BtnGuardar.Enabled = false;
            BtnEditar.Enabled = true;
            
            BtnCancelar.Enabled = false;

        }


        public void Desactivar()
        {
            BtnNuevo.Enabled = false;
            BtnGuardar.Enabled = true;
            BtnEditar.Enabled = false;
            
            BtnCancelar.Enabled = true;
        }
        public void Limpiar()
        {


            txt_sub_categoria.Text = "";

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Editar = false;
            this.Limpiar();

            this.Desactivar();
            this.Desbloquear();

            //  txt_activo.Focus();
            txt_sub_categoria.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar)
            {

                ManipularDatos.Conectar();
                String Query = "update SUBCATEGORIA set IDCATEGORIA = " + Convert.ToInt16(cbo_categoria.SelectedValue) + ",SUBCATEGORIA = '" + txt_sub_categoria.Text + "' where IDSUBCATEGORIA = '" + Codigo + "';";

                ManipularDatos.EjecutarSql(Query);
                ManipularDatos.ActualizarGrid(this.dataGridView1, "SELECT  IDSUBCATEGORIA AS ID,SUBCATEGORIA FROM SUBCATEGORIA WHERE IDCATEGORIA = " + Convert.ToInt16(cbo_categoria.SelectedValue) + " ORDER BY SUBCATEGORIA ");

                ManipularDatos.Desconectar();

                this.Limpiar();
                this.Activar();
                this.Bloquear();

                Editar = false;
            }

            else
            {
                //1.conectarse a la base de datos..
                ManipularDatos.Conectar();

                //2.Armar query..
                String Query = "insert into SUBCATEGORIA (IDCATEGORIA,SUBCATEGORIA)values( " + Convert.ToInt16(cbo_categoria.SelectedValue) + ", '" + txt_sub_categoria.Text + "');";

                //3.Ejecutar query...
                ManipularDatos.EjecutarSql(Query);

                //4.Actualizar el DataGrid...
                ManipularDatos.ActualizarGrid(this.dataGridView1, "SELECT  IDSubCategoria AS ID, SubCategoria FROM SUBCATEGORIA WHERE IDCategoria = " + Convert.ToInt16(cbo_categoria.SelectedValue) + " ORDER BY SubCategoria  ");

                //5.Desconectarse de la base de datos...
                ManipularDatos.Desconectar();

                //6.Limpiar las cajas de texto...

                this.Limpiar();
                this.Activar();
                this.Bloquear();
            }
        }

        private void cbo_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManipularDatos.ActualizarGrid(dataGridView1, "SELECT  IDSubCategoria AS ID, SubCategoria FROM SUBCATEGORIA WHERE IDCategoria = (SELECT IDCATEGORIA FROM CATEGORIA WHERE CATEGORIA = '" + cbo_categoria.Text+ "') ORDER BY SubCategoria  ");

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Editar = false;
            this.Limpiar();
            this.Activar();
            this.Bloquear();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.Desactivar();
            this.Desbloquear();

            Editar = true;
            Codigo = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            txt_sub_categoria.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Codigo = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var resultado = MessageBox.Show("¿Desear realmente eliminar este registro?", "Confirme el borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {

                ManipularDatos.Conectar();
                String Query = "delete from SUBCATEGORIA where IDSubCategoria = '" + Codigo + "';";
                ManipularDatos.EjecutarSql(Query);
                ManipularDatos.ActualizarGrid(this.dataGridView1, "SELECT  IDSubCategoria AS ID,SUBCATEGORIA FROM SUBCATEGORIA WHERE IDCATEGORIA = " + Convert.ToInt16(cbo_categoria.SelectedValue) + " ORDER BY SUBCATEGORIA ");

                ManipularDatos.Desconectar();
            }
            else


                return;
        }

        private void button1_Click(object sender, EventArgs e)
        {

           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string ID =  dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            ManipularDatos.Delete("SubCategoria", "IDSubCategoria='"+ID+"'",true);
            ManipularDatos.ActualizarGrid(dataGridView1, "SELECT  IDSubCategoria AS ID, SubCategoria FROM SUBCATEGORIA WHERE IDCategoria = (SELECT IDCATEGORIA FROM CATEGORIA WHERE CATEGORIA = '" + cbo_categoria.Text + "') ORDER BY SubCategoria  ");

        }
    }
}
