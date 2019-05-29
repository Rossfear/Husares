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

namespace SwJugueriaAgustin.Formularios.Compra
{
    public partial class FrmBuscarRucAdmin : Form
    {
        Clases.Empresas myInfo;
        public bool existeRuc;
        public bool registrado = false;
        Funciones fn = new Funciones();
        public static bool ConTeclado;

        public FrmBuscarRucAdmin()
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
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Ingrese el codigo de Sunat");
                txtCodigo.Focus();
                existeRuc = false;
            }
            else
            {

                try
                {
                    //llamamos a los metodos de la libreria ConsultaReniec...
                    myInfo.GetInfo(this.txtruc.Text, this.txtCodigo.Text);
                    this.txt_direccion.Text = myInfo.ApeMaterno;
                    this.txtrazonsocial.Text = myInfo.Nombres;
                    //  this.txtRuc.Text = txtNumDni.Text;
                    // this.txtNumDni.Text = "";
                    this.txtCodigo.Text = "";
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
                    myInfo = new Clases.Empresas();
                this.pictureCapcha.Image = myInfo.GetCapcha;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error temporal al Conectarse con el servidor de SUNAT. Llene los Datos de Forma Manual y Seleccione Agregar", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmBuscarRuc_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Descripcion", "IDTipoDocumento", "TipoDocumento", cboTipoDoc);
            cboTipoDoc.Text = "RUC";
            pictureCapcha.Visible = true;
            txtCodigo.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CargarImagen();
        }

        private void bto_agregar_Click(object sender, EventArgs e)
        {
            if (txtrazonsocial.Text == "Error!")
            {
                MessageBox.Show("Error al Guardar", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (fn.Existencia("*", "Proveedor", "Numero='" + txtruc.Text + "'") == false)
                {
                    fn.RegistrarOficial("Proveedor", "IDTipoDocumento,Numero,RazonSocial,Telefono,Direccion",
                        "'" + cboTipoDoc.SelectedValue + "','" + txtruc.Text + "','" + txtrazonsocial.Text + "','" + txt_tel.Text + "','" + txt_direccion.Text + "'");
                    registrado = true;
                    
                    this.Close();
                }
                else
                {
                    registrado = false;
                    this.Close();
                }
            }
        }


        private void txt_cod_Click(object sender, EventArgs e)
        {
            if (ConTeclado == true)
            {
                //FrmTeclado f = new FrmTeclado();
                //f.ShowDialog();
                //TextBox texto = sender as TextBox;
                //texto.Text = f.txtTexto.Text;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_cod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text) == true)
                {
                    MessageBox.Show("Ingrese el codigo de Sunat");
                    txtCodigo.Focus();
                    existeRuc = false;
                }
                else
                {
                    try
                    {
                        //llamamos a los metodos de la libreria ConsultaReniec...
                        myInfo.GetInfo(this.txtruc.Text, this.txtCodigo.Text);
                        this.txt_direccion.Text = myInfo.ApeMaterno;
                        this.txtrazonsocial.Text = myInfo.Nombres;
                        this.txtCodigo.Text = "";
                        txtrazonsocial.Focus();
                        CargarImagen();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
