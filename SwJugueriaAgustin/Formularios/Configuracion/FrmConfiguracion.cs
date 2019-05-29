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
    public partial class FrmConfiguracion : Form
    {
        Funciones fn = new Funciones();

        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void frmRuc_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            fn.Modificar("datosimpresion", "Ruc='" + txtRuc.Text + "',CantidadComanda='"+cboCantidadComanda.Text+ "'" +
                                            ",RutaDescarga='"+txtWebDescarga.Text+"'"+
                                            ",ImpresoraCocina='" + txtImpresoraCocina.Text + "'" +
                                            ",ImpresoraBar='" + txtImpresoraBar.Text + "'"
                                            , "IDDato='1'");

            fn.Modificar("datosimpresion", "Direccion='" + txtDireccion.Text + "',CantidadComprobante='"+cboCantidadComprobante.Text+"'", "IDDato='1'");
            fn.Modificar("datosimpresion", "NombreComercial='" + txtNombreComercial.Text + "'", "IDDato='1'");
            fn.Modificar("datosimpresion", "Departamento='" + txtDepartament.Text + "'", "IDDato='1'");
            fn.Modificar("datosimpresion", "RazonSocial='" + txtRazonSocial.Text + "'", "IDDato='1'");
            
            MessageBox.Show("Datos Actualizados", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private void mostrar()
        {
            try
            {
                fn.CargarCombo("Almacen","IDAlmacen","Almacen",cboAlmacen);

                SqlDataReader reader = fn.selectMultiValues("select * from datosImpresion");
                reader.Read();
                txtRuc.Text = reader["Ruc"].ToString();
                chbxTrasferenciaGratuita.Checked = (bool)reader["TransferenciaGratuita"];
                txtDepartament.Text = reader["Departamento"].ToString();
                txtNombreComercial.Text = reader["NombreComercial"].ToString();
                txtDireccion.Text = reader["Direccion"].ToString();
                txtRazonSocial.Text = reader["RazonSocial"].ToString();
                chbxPreCuenta.Checked = Convert.ToBoolean(reader["PreCuenta"].ToString());
                cboCantidadComanda.Text = reader["CantidadComanda"].ToString();
                cboCantidadComprobante.Text = reader["CantidadComprobante"].ToString();
                cboAlmacen.SelectedValue = reader["IDAlmacen"].ToString();
                chbxAumentarStock.Checked = (bool)reader["AumentarStock"];
                txtWebDescarga.Text = reader["RutaDescarga"].ToString();
                chbxOcultarDinero.Checked = (bool)reader["OcultarDinero"];
                chbxAbrircajasinAlmacen.Checked = (bool)reader["AbrirCajasinAlmacen"];
                txtImpresoraBar.Text = reader["ImpresoraBar"].ToString();
                txtImpresoraCocina.Text = reader["Impresoracocina"].ToString();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        private void btnActualizarConfiguracion_Click(object sender, EventArgs e)
        {
            fn.Modificar("datosimpresion", "AumentarStock='"+chbxAumentarStock.Checked+"',IDAlmacen='" + cboAlmacen.SelectedValue+"'," +
                "PreCuenta='" + chbxPreCuenta.Checked + "',OcultarDinero='" + chbxOcultarDinero.Checked + "',AbrirCajasinAlmacen = '"+ chbxAbrircajasinAlmacen.Checked +"'"
                
                , "IDDato='1'");

            MessageBox.Show("Operación Correcta","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fn.selectValue("select ContraseñaSeguridad from DatosImpresion") != txtContraseña.Text)
            {
                MessageBox.Show("Contraseña Incorrecta","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
                

            if(txtNuevaContraseña.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Contraseñas no coinciden", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
            fn.Modificar("datosimpresion", "ContraseñaSeguridad='" + txtNuevaContraseña.Text + "'", "IDDato='1'");
            MessageBox.Show("Operación Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
