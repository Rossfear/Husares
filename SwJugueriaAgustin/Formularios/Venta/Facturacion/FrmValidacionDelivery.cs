using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Operaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Facturacion.Pedido
{
    public partial class FrmValidacionDelivery : Form
    {
        Funciones fn = new Funciones();
        public bool Delivery;
        public FrmValidacionDelivery()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += FrmValidacionDelivery_KeyDown1;
        }

        private void FrmValidacionDelivery_KeyDown1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmValidacionDelivery_Load(object sender, EventArgs e)
        {
            txtTelefonoBuscar.Select();
            txtTelefonoBuscar.Focus();
        }

        private void txtTelefonoBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {


                    if (string.IsNullOrEmpty(txtTelefonoBuscar.Text) == false)
                    {
                        if (fn.Existencia("*", "cliente", "Telefono = '" + txtTelefonoBuscar.Text + "'") == true)
                        {
                            SqlDataReader lectorCliente = fn.selectMultiValues("select * from cliente where Telefono = '" + txtTelefonoBuscar.Text + "'");
                            lectorCliente.Read();
                            txtIDCliente.Text = lectorCliente["IDCliente"].ToString();
                            txtNombres.Text = lectorCliente["Nombre"].ToString();
                            txtnumero.Text = lectorCliente["Numero"].ToString();
                            txtTelefono1.Text = lectorCliente["Telefono"].ToString();
                            txtTelefono2.Text = lectorCliente["Telefono2"].ToString();
                            txtdireccion.Text = lectorCliente["Direccion"].ToString();
                            txtReferencia.Text = lectorCliente["Referencia"].ToString();
                            lectorCliente.Close();
                        }
                        else if (fn.Existencia("*", "cliente", "Telefono2 = '" + txtTelefonoBuscar.Text + "'") == true)
                        {
                            SqlDataReader lectorCliente = fn.selectMultiValues("select * from cliente where Telefono2 = '" + txtTelefonoBuscar.Text + "'");
                            lectorCliente.Read();
                            txtIDCliente.Text = lectorCliente["IDCliente"].ToString();
                            txtNombres.Text = lectorCliente["Nombre"].ToString();
                            txtnumero.Text = lectorCliente["Numero"].ToString();
                            txtTelefono1.Text = lectorCliente["Telefono"].ToString();
                            txtTelefono2.Text = lectorCliente["Telefono2"].ToString();
                            txtdireccion.Text = lectorCliente["Direccion"].ToString();
                            txtReferencia.Text = lectorCliente["Referencia"].ToString();
                            lectorCliente.Close();
                        }
                        else
                        {
                            DialogResult msj = MessageBox.Show("El Cliente no se Encuentra Registrado. Desea Registrarlo", "FactuTEd", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (msj == DialogResult.OK)
                            {
                                limpiar();
                                txtTelefono1.Text = txtTelefonoBuscar.Text;
                                txtnumero.Focus();
                            }
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        void limpiar()
        {
            
            txtdireccion.Clear();
            txtIDCliente.Clear();
            txtNombres.Clear();
            txtnumero.Clear();
            txtReferencia.Clear();
            txtTelefono1.Clear();
            txtTelefono2.Clear();
        }
        private void FrmValidacionDelivery_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtnumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(string.IsNullOrEmpty(txtnumero.Text) == false)
                {
                    BuscarCliente(txtnumero.Text);
                }
                else
                {
                    txtNombres.Focus();
                }
            }
        }

        private void BuscarCliente(string Numero)
        {
            if (Numero.Length == 8 || Numero.Length == 11)
            {
                if (fn.Existencia("*", "Cliente", "Numero='" + Numero + "'") == true)
                {
                    clienteEncontrado(Numero);
                }
                else
                {
                    if (Numero.Length == 8)
                    {
                        frmBuscarDni FRM = new frmBuscarDni();
                        frmBuscarDni.DNI = Numero;
                        FRM.ShowDialog();

                        if (FRM.existe == true)
                        {
                            txtnumero.Text = FRM.txt_dni.Text;
                            if (Numero != "")
                            {
                                if (fn.Existencia("Numero", "Cliente", "Numero='" + Numero + "'") == true)
                                {
                                    clienteEncontrado(Numero);
                                }
                            }
                        }
                    }
                    else if (Numero.Length == 11)
                    {
                        frmBuscarRuc FRM = new frmBuscarRuc();
                        FRM.txtruc.Text = txtnumero.Text;
                        FRM.ShowDialog();
                        txtnumero.Text = FRM.txtruc.Text;
                        if (Numero != "")
                        {
                            if (fn.Existencia("Numero", "Cliente", "Numero='" + Numero + "'") == true)
                            {
                                clienteEncontrado(Numero);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Numero de identificación incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnumero.Focus();
            }
        }

        private void clienteEncontrado(string nroDocumento)
        {
            SqlDataReader lectorCliente = fn.selectMultiValues("select * from cliente where Numero = '" + nroDocumento + "'");
            lectorCliente.Read();
            txtNombres.Text = lectorCliente["Nombre"].ToString();
            txtdireccion.Text = lectorCliente["Direccion"].ToString();
            txtTelefono1.Text = lectorCliente["Telefono"].ToString();
            txtTelefono2.Text = lectorCliente["Telefono2"].ToString();
            txtdireccion.Text = lectorCliente["Direccion"].ToString();
            txtReferencia.Text = lectorCliente["Referencia"].ToString();
            lectorCliente.Close();
        }

        private void txtNombres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono1.Focus();
            }
        }

        private void txtTelefono1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono2.Focus();
            }
        }

        private void txtTelefono2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtdireccion.Focus();
            }
        }

        private void txtdireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReferencia.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        void eGuardar()
        {
            //VALIDAMOS
            if (validacionGuardar() == false)
            {
                return;
            }

            //GUARDAMOS
            guardar();
        }

        private void guardar()
        {
            if(string.IsNullOrEmpty(txtIDCliente.Text) == true)
            {
                fn.RegistrarOficial("Cliente", "Nombre,Numero,Telefono,Telefono2,Direccion,Referencia",
                    "'" + txtNombres.Text + "','" + txtnumero.Text + "','" + txtTelefono1.Text + "','" + txtTelefono2.Text + "','" + txtdireccion.Text + "','" + txtReferencia.Text + "'");

                txtIDCliente.Text = fn.selectValue("select IDCliente from cliente where Telefono='" + txtTelefono1.Text + "' and Telefono2='" + txtTelefono2.Text + "'");
            }
            else
            {
                fn.Modificar("Cliente", "Nombre='" + txtNombres.Text + "',Numero='" + txtnumero.Text + "',Telefono='" + txtTelefono1.Text + "',Telefono2='" + txtTelefono2.Text + "',Direccion='" + txtdireccion.Text + "',Referencia='" + txtReferencia.Text + "'", "IDCliente='" + txtIDCliente.Text + "'");    
            }
        }

        private bool validacionGuardar()
        {
            if(string.IsNullOrEmpty(txtNombres.Text) == true)
            {
                MessageBox.Show("Ingrese Nombre de Cliente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTelefono1.Text) == true && string.IsNullOrEmpty(txtTelefono2.Text))
            {
                MessageBox.Show("Ingrese N° de Telefono", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtdireccion.Text) == true)
            {
                MessageBox.Show("Ingrese Dirección", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            

            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {            
            eGuardar();

            if (!validacionProcesar()) return;

            if (Delivery)
            {
                this.Hide();
            }
            else
            {
                this.Hide();
                FrmSeleccionPedido frm = new FrmSeleccionPedido();

                frm.labelCliente.Visible = true;
                frm.lblCliente.Visible = true;
                frm.lblCodCliente.Visible = true;

                frm.lblCliente.Text = txtNombres.Text;
                frm.lblCodCliente.Text = txtIDCliente.Text;

                frm.lblMesa.Text = "DELYVERY";
                frm.lblMesa.Tag = 1;

                frm.btnSolicitarPedido.Enabled = false;
                frm.btnFacturar.Enabled = true;
                frm.existsOrder = false;
                frm.ShowDialog();                
            }
        }

        private bool validacionProcesar()
        {
            if(string.IsNullOrEmpty(txtIDCliente.Text) == true)
            {
                MessageBox.Show("Cliente No Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
