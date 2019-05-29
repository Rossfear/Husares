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
    public partial class frmBuscarDni : Form
    {
        Personas myInfo;
        FrmTeclado f = new FrmTeclado();
        Funciones fn = new Funciones();
        public static string DNI;
        public bool existe;
        public static bool ConTeclado;
        public frmBuscarDni()
        {
            InitializeComponent();
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void CargarImagen()
        {
            try
            {
                if (myInfo == null)
                    myInfo = new Personas();
                this.pictureCapcha.Image = myInfo.GetCapcha;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void CaptionResul()
        {
            try
            {
                switch (myInfo.GetResul)
                {
                    case Personas.Resul.Ok:
                        this.txt_cliente.Text = myInfo.Nombres + " " + myInfo.ApePaterno + " " + myInfo.ApeMaterno;
                        break;
                    case Personas.Resul.NoResul:
                        this.txt_cliente.Text = "No existe DNI o es Menor de Edad";
                        break;
                    case Personas.Resul.ErrorCapcha:
                        CargarImagen();
                        this.txt_cliente.Text = "Ingrese imagen correctamente";
                        break;
                    case Personas.Resul.Error:
                        this.txt_cliente.Text = "Error Desconocido";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmBuscarDni_Load(object sender, EventArgs e)
        {
            existe = false;
            txt_dni.Text = DNI;
        }

        private void bto_guardar_Click(object sender, EventArgs e)
        {
           if (txt_cliente.Text == "")
           {
            epError.SetError(txt_cliente, "Ingrese nombre del cliente");
                txt_cliente.Focus();
            return;
           }
            epError.Clear();

            if (txt_cliente.Text == "NO EXISTE DNI O ES MENOR DE EDAD")
            {
                epError.SetError(txt_cliente, "DNI incorrecto");
                txt_cliente.Focus();
                return;
            }
            epError.Clear();

            if (txt_cliente.Text == "Ingrese imagen correctamente")
            {
                epError.SetError(txt_cliente, "Ingrese código de imagen correctamente");
                txt_cliente.Focus();
                return;
            }
            epError.Clear();

            Funciones fn = new Funciones();
            if (chProveedor.Checked == false)
            {
                if (fn.Existencia("*", "cliente", "Numero='" + txt_dni.Text + "'") == false)
                {
                    //INSERT INTO CLIENTE VALUES('NOMBRE','NUMERO','TELEFONO','DIRECCIÓN')
                    fn.Registrar("CLIENTE", "'" + txt_cliente.Text + "','" + txt_dni.Text + "','" + txt_tel.Text + "','" + txt_direccion.Text + "','"+txtReferencia.Text+"',''");
                } 
            }
            else
            {
                if (fn.Existencia("*", "Proveedor", "Numero='" + txt_dni.Text + "'") == false)
                {
                    fn.Registrar("Proveedor", "(SELECT IDTipoDocumento from TipoDocumento where Descripcion = 'DNI'),'"+txt_dni.Text+"','"+txt_cliente.Text +"','"+txt_tel.Text+"','"+txt_direccion.Text+"','"+ txt_cliente.Text+ "'");
                }
            }
            existe = true;
            this.Close();
                
        }

        private void txt_cod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txt_cod.Text == "")
                {
                    MessageBox.Show("Ingrese el codigo de reniec");

                }
                else
                {

                    try
                    {
                        if (this.txt_dni.Text.Length != 8)
                        {

                            MessageBox.Show("El DNI tienen mas de '8 DIGITOS'");
                            this.Close();

                        }

                        myInfo.GetInfo(this.txt_dni.Text, this.txt_cod.Text);
                        CaptionResul();
                        txt_tel.Focus();
                        //CargarImagen(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chbManual.Checked == true)
            {
                txt_cliente.ReadOnly = false;
                Limpiar();
            }
            else
            {
                txt_cliente.ReadOnly = true;
                Limpiar();
                CargarImagen();
            }
        }
        private void Limpiar()
        {
            txt_cliente.Clear();
            txt_cod.Text = "";
            txt_direccion.Clear();
            txt_tel.Clear();
        }

        private void chHabilitar_CheckedChanged(object sender, EventArgs e)
        {
            if (chHabilitar.Checked == true)
            {
                txt_cliente.ReadOnly = false;
            }
            else
            {
                txt_cliente.ReadOnly = true;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
            if (txt_cod.Text == "")
            {
                MessageBox.Show("Ingrese el codigo de reniec");

            }
            else
            {

                try
                {
                    if (this.txt_dni.Text.Length != 8)
                    {

                        MessageBox.Show("El DNI tienen mas de '8 DIGITOS'");
                        this.Close();

                    }

                    myInfo.GetInfo(this.txt_dni.Text, this.txt_cod.Text);
                    CaptionResul();
                    txt_tel.Focus();
                    //CargarImagen(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCapcher_Click(object sender, EventArgs e)
        {
            CargarImagen();
            txt_cod.Focus();
        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {
            fn.llamarTeclado();
            txt_cod.Focus();
        }
    }
}
