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
    public partial class FrmCategoria : Form
    {
   
        Boolean Editar;
        Funciones ManipularDatos = new Funciones();
        String Codigo = "";
        String fecha;


        public static string conex = Funciones.preconex;
        SqlConnection cn = new SqlConnection(conex);

        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Activar();
            this.Bloquear();
            txt_categoria.Focus();


            ManipularDatos.ActualizarGrid(this.dataGridView1, "SELECT  * FROM CATEGORIA ORDER BY CATEGORIA");
        }
        public void Bloquear()
        {

            txt_categoria.Enabled = false;

        }

        public void Desbloquear()
        {

            txt_categoria.Enabled = true;
        }
        public void Activar()
        {
            BtnNuevo.Enabled = true;
            BtnGuardar.Enabled = false;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnCancelar.Enabled = false;

        }


        public void Desactivar()
        {
            BtnNuevo.Enabled = false;
            BtnGuardar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnCancelar.Enabled = true;
        }
        public void Limpiar()
        {


            txt_categoria.Text = "";

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Editar = false;
            this.Limpiar();

            this.Desactivar();
            this.Desbloquear();

            //  txt_activo.Focus();
            txt_categoria.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar)
            {

                ManipularDatos.Conectar();
                String Query = "update CATEGORIA set CATEGORIA = '" + txt_categoria.Text + "' where IDCATEGORIA = '" + Codigo + "';";

                ManipularDatos.EjecutarSql(Query);
                ManipularDatos.ActualizarGrid(this.dataGridView1, "SELECT  * FROM CATEGORIA ORDER BY CATEGORIA");
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
                String Query = "insert into CATEGORIA (CATEGORIA)values( '" + txt_categoria.Text + "');";

                //3.Ejecutar query...
                ManipularDatos.EjecutarSql(Query);

                //4.Actualizar el DataGrid...
                ManipularDatos.ActualizarGrid(this.dataGridView1, "SELECT  * FROM CATEGORIA ORDER BY CATEGORIA");
                //5.Desconectarse de la base de datos...
                ManipularDatos.Desconectar();

                //6.Limpiar las cajas de texto...

                this.Limpiar();
                this.Activar();
                this.Bloquear();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.Desactivar();
            this.Desbloquear();

            Editar = true;
            Codigo = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            txt_categoria.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Editar = false;
            this.Limpiar();
            this.Activar();
            this.Bloquear();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Codigo = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var resultado = MessageBox.Show("¿Desear realmente eliminar este registro?", "Confirme el borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {

                ManipularDatos.Conectar();
                String Query = "delete from CATEGORIA where IDCATEGORIA = '" + Codigo + "';";
                ManipularDatos.EjecutarSql(Query);
                ManipularDatos.ActualizarGrid(this.dataGridView1, "SELECT  * FROM CATEGORIA ORDER BY CATEGORIA");
                ManipularDatos.Desconectar();
            }
            else


                return;
        }
    }
}
