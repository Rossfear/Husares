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
    
    public partial class FrmMostrarPresentacion : Form
    {
        public string IDProducto;
        Funciones fn = new Funciones();
        SqlConnection conexion = new SqlConnection(Funciones.preconex);

        public FrmMostrarPresentacion()
        {
            InitializeComponent();
        }

        public bool Cancelado;
        public string IDPresentacion;
        private void FrmMostrarPresentacion_Load(object sender, EventArgs e)
        {
            flpCategorias.Controls.Clear();
            lblProducto.Text = "----------------";
            chbxLlevar.Visible = false;
            chbxLlevar.Checked = false;


            if (Convert.ToInt16(fn.Cantidad("*", "Presentacion", "IDProducto='" + IDProducto + "' and Habilitado='True'")) == 1)
            {
                lblProducto.Text = fn.select_one_value("Presentacion", "Presentacion", "IDProducto='" + IDProducto + "'", 0);
                IDPresentacion = fn.select_one_value("IDPresentacion", "Presentacion", "IDProducto='" + IDProducto + "'", 0);

            }

            
            string oncod = "select UPPER(Presentacion) AS [PRESENTACION],IDPresentacion from Presentacion where IDProducto='"+IDProducto+"' and Habilitado='True'";
            SqlCommand cmd = new SqlCommand(oncod, conexion);
            conexion.Open();
            SqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                Button btn = new Button();
                btn.Text = lector["Presentacion"].ToString();
                btn.Size = new System.Drawing.Size(170, 80);
                btn.ForeColor = Color.BlueViolet;
                btn.BackColor = Color.Gainsboro;
                btn.Tag = lector["IDPresentacion"].ToString();
                btn.Click += btn_Click;
                flpCategorias.Controls.Add(btn);
            }
            conexion.Close();
            return;


            


        }
        void btn_Click(object sender, EventArgs e)
        {
            chbxLlevar.Checked = false;

            Button btn = sender as Button;
            IDPresentacion = btn.Tag.ToString();
            lblProducto.Text = btn.Text;
            

            if(fn.Existencia("*", "PresentacionLLevar","IDPresentacion='"+IDPresentacion+"'") == true)
            {
                chbxLlevar.Visible = true;

                
            }
            else
            {
                chbxLlevar.Visible = false;
            }

            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                txtCantidad.Text += btn.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int c = txtCantidad.TextLength - 1;
            string text = "";
            for (int i = 0; i < c; i++)
            {
                text += txtCantidad.Text[i];
            }
            txtCantidad.Text = text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += ".";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelado = true;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtCantidad.Text == "")
            {
                frmMensaje frm = new frmMensaje();
                frm.lblmensaje.Text = "Ingrese Cantidad";
                frm.tmrCierre.Interval = 700;
                frm.ShowDialog();
                return;
            }
            if(lblProducto.Text == "----------------")
            {
                MessageBox.Show("Seleccione una Categoria", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                Cancelado = false;
                this.Close();
            }
            
        }

        private void btnAddIngredientes_Click(object sender, EventArgs e)
        {
            //if(lblProducto.Text == "----------------")
            //{
            //    MessageBox.Show("Seleccione Producto", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
                
            //        FrmAddIngredintes frm = new FrmAddIngredintes();
            //        frm.txtProducto.Text = lblProducto.Text;
            //        FrmAddIngredintes.IDProducto = IDProducto;
            //        frm.ShowDialog();
            //    if (FrmAddIngredintes.Cancelado == false)
            //    {
            //        lblProducto.Text = frm.txtProducto.Text;
            //    }
                
            //}
        }

        private void chbxLlevar_CheckedChanged(object sender, EventArgs e)
        {
            if(chbxLlevar.Checked == true)
            {
                SqlDataReader lector = fn.selectMultiValues("select pl.IDPresentacionLLevar,p.Presentacion from PresentacionLLevar pl  inner join Presentacion p on pl.IDPresentacionLLevar = p.IDPresentacion where pl.IDPresentacion = '"+IDPresentacion+"'");
                lector.Read();
                IDPresentacion = lector["IDPresentacionLlevar"].ToString();
                lblProducto.Text = lector["Presentacion"].ToString();
                lector.Close();
            }
            else
            {
                SqlDataReader lector = fn.selectMultiValues("select p.IDPresentacion,p.Presentacion from PresentacionLLevar pl inner join Presentacion p on pl.IDPresentacion = p.IDPresentacion where pl.IDPresentacionLLevar = '"+IDPresentacion+"'");
                lector.Read();
                IDPresentacion = lector["IDPresentacion"].ToString();
                lblProducto.Text = lector["Presentacion"].ToString();
                lector.Close();
            }
        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {
            if(lblProducto.Text != "----------------")
            {
                fn.llamarTeclado();
            }
            
        }
    }
}
