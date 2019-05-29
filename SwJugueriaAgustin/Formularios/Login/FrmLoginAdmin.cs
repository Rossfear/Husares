using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios;
using SwJugueriaAgustin.Formularios.Apariencia;
using SwJugueriaAgustin.Formularios.Operaciones;
using SwJugueriaAgustin.Principal;
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

namespace SwJugueriaAgustin.FormAdmin
{
    public partial class FrmLoginAdmin : Form
    {
        Funciones fn = new Funciones();
        FrmPrincipalOfi frmPrincipal = new FrmPrincipalOfi();
        FrmPrincipal frmVenta = new FrmPrincipal();
        public static string CodUser, Usuario, Caja, nivel;
        public FrmLoginAdmin()
        {
            InitializeComponent();
            KeyPreview = true;

            KeyDown += FrmLoginPrincipal_KeyDown;
        }

        private void FrmLoginPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                FrmConexion frm = new FrmConexion();
                frm.ShowDialog();
            }
            else if (e.KeyCode == Keys.F1)
            {
                FrmSeleccionEmpresa frm = new FrmSeleccionEmpresa();
                frm.ShowDialog();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }



        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ingresar();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresar();
        }




        private void txtPass_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void pbx1_Click(object sender, EventArgs e)
        {
            txtPass.Text += "1";
        }

        private void pbx2_Click(object sender, EventArgs e)
        {
            txtPass.Text += "2";
        }

        private void pbx3_Click(object sender, EventArgs e)
        {
            txtPass.Text += "3";
        }

        private void pbx4_Click(object sender, EventArgs e)
        {
            txtPass.Text += "4";
        }

        private void pbx5_Click(object sender, EventArgs e)
        {
            txtPass.Text += "5";
        }

        private void pbx6_Click(object sender, EventArgs e)
        {
            txtPass.Text += "6";
        }

        private void pbx7_Click(object sender, EventArgs e)
        {
            txtPass.Text += "7";
        }

        private void pbx8_Click(object sender, EventArgs e)
        {
            txtPass.Text += "8";
        }

        private void pbx9_Click(object sender, EventArgs e)
        {
            txtPass.Text += "9";
        }

        private void pbx0_Click(object sender, EventArgs e)
        {
            txtPass.Text += "0";
        }

        private void pbxAsterisco_Click(object sender, EventArgs e)
        {
            txtPass.Text += ".";
        }

        private void pbxNumeral_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != "")
            {
                txtPass.Text = txtPass.Text.Remove(txtPass.TextLength - 1, 1);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            ingresar();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ingresar();
            }
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cboSucursal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fn.CargarCombo("Usuario","IDUsuario", "Usuario where IDSucursal='"+cboSucursal.SelectedValue+"' and Tipo='Venta'",cboUsuario);
        }

        private void cboUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void FrmLoginPrincipal_Load(object sender, EventArgs e)
        {
            

            try
            {
                fn.CargarCombo("Sucursal","IDSucursal", "sucursal",cboSucursal);
                cboSucursal.SelectedIndex = -1;

                cboUsuario.Select();
                cboUsuario.Focus();
                lblEmpresa.Text = fn.selectValue("select RazonSocial from DatosImpresion");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

       

        Datos d = new Datos();
        private void ingresar()
        {
            try
            {
                SqlDataReader lectorUsuario = fn.selectMultiValues("SELECT u.*,s.Sucursal FROM Usuario u inner join sucursal s on u.IDSucursal = s.IDSucursal where u.Usuario = '"+cboUsuario.Text+"' and u.Contraseña = '"+txtPass.Text+"' and u.Habilitado = 'True'");
                lectorUsuario.Read();

                if (lectorUsuario.HasRows == true)
                {
                    //DATOS DE USUARIO
                    Datos.nombre = lectorUsuario["Nombres"].ToString();
                    Datos.Usuario = lectorUsuario["Usuario"].ToString();
                    Datos.idUsuario = lectorUsuario["IDUsuario"].ToString();
                    Datos.permisoEspeciales = Convert.ToBoolean(lectorUsuario["PermisosEspeciales"]);
                    Datos.sucursal = lectorUsuario["Sucursal"].ToString();
                    Datos.idSucursal = lectorUsuario["IDSucursal"].ToString();
                    Datos.mozo = (bool)lectorUsuario["Mozo"];
                    Datos.tactil = (bool)lectorUsuario["Tactil"];
                    string tipo = lectorUsuario["Tipo"].ToString();
                    Datos.sinTicket = false;
                    Datos.conTeclado = true;


                    SqlDataReader lectorImpresion = fn.selectMultiValues("select * from datosimpresion");

                    lectorImpresion.Read();
                    Datos.Ruc = lectorImpresion["ruc"].ToString();
                    Datos.transferenciaGratuita = (bool)lectorImpresion["TransferenciaGratuita"];
                    Datos.Direccion = lectorImpresion["Direccion"].ToString();
                    Datos.nombreComercial = lectorImpresion["NombreComercial"].ToString();
                    Datos.Departmaneto = lectorImpresion["Departamento"].ToString();
                    Datos.RazonSocial = lectorImpresion["RazonSocial"].ToString();
                    Datos.conPrecuenta = Convert.ToBoolean(lectorImpresion["PreCuenta"].ToString());
                    Datos.contraseñaSeguridad = lectorImpresion["ContraseñaSeguridad"].ToString();
                    Datos.serieImpresora = lectorImpresion["SerieImpresora"].ToString();
                    Datos.nroAutorizacion = lectorImpresion["NroAutorizacion"].ToString();
                    Datos.wifi = lectorImpresion["Wifi"].ToString();
                    Datos.Alias = lectorImpresion["Alias"].ToString();
                    Datos.cantidadComanda = Convert.ToInt16(lectorImpresion["CantidadComanda"].ToString());
                    Datos.cantidadComprobante = Convert.ToInt16(lectorImpresion["CantidadComprobante"].ToString());
                    Datos.ocultarDinero = (bool) lectorImpresion["ocultarDinero"];
                    Datos.rutaDescarga = lectorImpresion["RutaDescarga"].ToString();
                    Datos.IDAlmacen = lectorImpresion["IDAlmacen"].ToString();
                    Datos.AumentarStock = (bool)lectorImpresion["AumentarStock"];
                    Datos.AbrirCajaSinAlmacen = Convert.ToBoolean(lectorImpresion["AbrirCajaSinAlmacen"]);
                    lectorImpresion.Close();

                    SqlDataReader lectorImpresora = fn.selectMultiValues("select * from Impresora where IDSucursal = '"+Datos.idSucursal+"'");
                    while(lectorImpresora.Read())
                    {
                        if(lectorImpresora["Tipo"].ToString().Equals("BAR"))
                        {
                            Datos.impresoraBar = lectorImpresora["Impresora"].ToString();
                        }
                        else if (lectorImpresora["Tipo"].ToString().Equals("COCINA"))
                        {
                            Datos.impresoraCocina = lectorImpresora["Impresora"].ToString();
                        }
                        else if (lectorImpresora["Tipo"].ToString().Equals("HORNO"))
                        {
                            Datos.impresoraHorno = lectorImpresora["Impresora"].ToString();
                        }
                        //
                        else if (lectorImpresora["Tipo"].ToString().Equals("DELIVERY COCINA"))
                        {
                            Datos.impresoraDeliveryCocina = lectorImpresora["Impresora"].ToString();
                        }
                        else if (lectorImpresora["Tipo"].ToString().Equals("DELIVERY BAR"))
                        {
                            Datos.impresoraDeliveryBar = lectorImpresora["Impresora"].ToString();
                        }
                        else if (lectorImpresora["Tipo"].ToString().Equals("DELIVERY HORNO"))
                        {
                            Datos.impresoraDeliveryHorno = lectorImpresora["Impresora"].ToString();
                        }
                        //
                        else if (lectorImpresora["Tipo"].ToString().Equals("LLEVAR COCINA"))
                        {
                            Datos.impresorallevarCocina = lectorImpresora["Impresora"].ToString();
                        }
                        else if (lectorImpresora["Tipo"].ToString().Equals("LLEVAR BAR"))
                        {
                            Datos.impresorallevarBar = lectorImpresora["Impresora"].ToString();
                        }
                        else if (lectorImpresora["Tipo"].ToString().Equals("LLEVAR HORNO"))
                        {
                            Datos.impresorallevarHorno = lectorImpresora["Impresora"].ToString();
                        }
                    }

                    if (tipo == "VENTA")
                    {
                        Datos.administrador = false;
                        Datos.sinTicket = true;
                        frmVenta.Show();
                    }
                    else
                    {
                        Datos.administrador = true;
                        Datos.sinTicket = false;
                        frmPrincipal.Show();
                    }

                    this.Hide();

                    lectorUsuario.Close();
                }
                else
                {
                    MessageBox.Show("Error De inicio de Sesión, Verifique Usuario o Contraseña", ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
