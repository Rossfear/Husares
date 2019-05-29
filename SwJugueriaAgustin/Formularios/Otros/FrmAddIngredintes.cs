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
    public partial class FrmAddIngredintes : Form
    {
        public string idPresentacion = "";
        Funciones fn = new Funciones();
        public bool Cancelado;

        public FrmAddIngredintes()
        {
            InitializeComponent();
        }

        private void FrmAddIngredintes_Load(object sender, EventArgs e)
        {
            //MOSTRAMOS LOS INGREDIENTES DE LA BASE DE DATOS
            SqlConnection conexion = new SqlConnection(Funciones.preconex);
            string oncod = "select UPPER(con.Condimento) as Condimento,con.IDCondimento from Condimento con inner join Categoria ca on con.IDCategoria = ca.IDCategoria inner join SubCategoria sc on ca.IDCategoria = sc.IDCategoria inner join Producto pro on sc.IDSubCategoria = pro.IDSubcategoria inner join Presentacion pre on pro.IDProducto = pre.IDProducto where pre.IDPresentacion = '" + idPresentacion + "'";
            SqlCommand cmd = new SqlCommand(oncod, conexion);
            conexion.Open();
            SqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                Button btn = new Button();
                btn.Text = lector["Condimento"].ToString();
                btn.Size = new System.Drawing.Size(140, 60);
                btn.ForeColor = Color.BlueViolet;
                btn.BackColor = Color.Gainsboro;
                btn.Tag = lector["IDCondimento"].ToString();
                btn.Click += btn_Click;
                flpCategorias.Controls.Add(btn);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;


            if (txtProducto.Text.Contains(btn.Text) == false)
            {
                btn.BackColor = Color.Lime;
                txtProducto.Text += " - " + btn.Text;
            }
            else
            {
                btn.BackColor = Color.Gainsboro;
                int indece = txtProducto.Text.IndexOf(btn.Text, 2) - 3;
                int tamañoletra = btn.Text.Length + 3;

                txtProducto.Text = txtProducto.Text.Remove(indece, tamañoletra);

            }



        }


        private void buscarRemplazar(string texto)
        {

        }
        private void txtProducto_Click(object sender, EventArgs e)
        {
            FrmTeclado frm = new FrmTeclado();
            frm.txtTexto.Text = txtProducto.Text;
            frm.ShowDialog();

            txtProducto.Text = frm.txtTexto.Text;
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            Cancelado = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancelado = true;
            Close();
        }
    }
}
