using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SwJugueriaAgustin.Formularios
{
    public partial class frmBuscarRuc : Form
    {
        FrmTeclado f = new FrmTeclado();
        Clases.Empresas myInfo;
        public static bool existeRuc;
        Funciones fn = new Funciones();
        public static bool ConTeclado;

        public frmBuscarRuc()
        {
            InitializeComponent();
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (myInfo == null)
            {
                myInfo = new Empresas();
            }
            


            if (txt_cod.Text == "")
            {
                MessageBox.Show("Ingrese el codigo de Sunat");
                txt_cod.Focus();
                existeRuc = false;
            }
            else
            {

                try
                {
                    
                    //llamamos a los metodos de la libreria ConsultaReniec...
                    myInfo.GetInfo(this.txtruc.Text, this.txt_cod.Text);
                    this.txt_direccion.Text = myInfo.ApeMaterno;
                    this.txtrazonsocial.Text = myInfo.Nombres;
                    //  this.txtRuc.Text = txtNumDni.Text;
                    // this.txtNumDni.Text = "";
                    this.txt_cod.Text = "";
                    txtrazonsocial.Focus();
                    CargarImagen();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void CargarImagen()
        {
            try
            {
                

                if (myInfo == null)
                {
                    myInfo = new Empresas();
                }
                    

                

                this.pictureCapcha.Image = myInfo.GetCapcha;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmBuscarRuc_Load(object sender, EventArgs e)
        {
            pictureCapcha.Visible = true;
            txt_cod.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CargarImagen();
        }

        

        private void bto_agregar_Click(object sender, EventArgs e)
        {
            if(txtrazonsocial.Text == "Error!")
            {
                MessageBox.Show("Error al Guardar", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (fn.Existencia("*", "Cliente", "Numero='" + txtruc.Text + "'") == false)
                {
                    fn.Registrar("Cliente", "'" + txtrazonsocial.Text + "','" + txtruc.Text + "','" + txt_tel.Text + "','','" + txt_direccion.Text + "','" + txtReferecia.Text + "','2'");
                    existeRuc = false;
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void chHabilitar_CheckedChanged(object sender, EventArgs e)
        {
            if(chHabilitar.Checked == true)
            {
                txtrazonsocial.ReadOnly = false;
            }
            else
            {
                txtrazonsocial.ReadOnly = true;
            }
        }

        private void txt_cod_Click(object sender, EventArgs e)
        {
            
            if (ConTeclado == true)
            {
                f.txtTexto.Text = "";
                f.ShowDialog();
                TextBox texto = sender as TextBox;
                texto.Text = f.txtTexto.Text;
            }
        }
    }
}
