using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Compra.Mantenimiento;
using SwJugueriaAgustin.Formularios;
using SwJugueriaAgustin.Formularios.Compra;
using SwJugueriaAgustin.Formularios.Mantenimientos.Atributos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Compra.Operacion
{
    public partial class FrmAddCompraContable : Form
    {
        //INSTANCIA A LA CLASE
        Funciones fn = new Funciones();
        public static string codCompra;
        //VARIABLES PUBLICAS
        public static string Codregistro;
        public static bool editar;

        public string idCompraContable;
        public FrmAddCompraContable()
        {
            InitializeComponent();
            KeyPreview = true;

            KeyDown += FrmAddCompraContable_KeyDown;

        }

        private void FrmAddCompraContable_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                //NUEVO
                Desbloqueo();
                editar = false;
                limpiar();
            }
            else if(e.KeyCode == Keys.F5)
            {
                //GUARDAR
                _Guardar();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            
        }

        private void FRM_DETALLE_COMPRA_Load(object sender, EventArgs e)
        {
            if (editar == true)
            {
                Desbloqueo();
            }
            else
            {
                //LLENAMOS LOS COMBOX CON DATOS
                Bloqueo();
                
                lblImpuesto.Text = fn.selectValue("select Valor from parametro where Parametro = 'IGV'");
            }
            mostrarCombo();
        }

        private void Bloqueo()
        {
            gbxDatos.Enabled = false;
            
            gbxFactura.Enabled = false;
            
            btnGuardar.Enabled = false;
            
            btnSalir.Enabled = false;
            btnNuevo.Enabled = true;
            btnNuevo.Select();
        }

        public void Desbloqueo()
        {
            gbxDatos.Enabled = true;
            gbxFactura.Enabled = true;
            btnGuardar.Enabled = true;
            btnSalir.Enabled = true;
            dtpFecha.Select();
        }

      
        private void mostrarCombo()
        {
            fn.añadir_ddl("NombreComprobante", "IDTipoComprobante", "TipoComprobante", cbxTipoComprobante);
            
        }

        private void cbxTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSerie.Focus();
            }
            else if(e.KeyCode == Keys.F5)
            {
                fn.añadir_ddl("NombreComprobante", "IDTipoComprobante", "TipoComprobante", cbxTipoComprobante);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _Guardar();
        }

        private void _Guardar()
        {
            //VALIDACION
            if (validationSave() == false)
            {
                return;
            }

            //GUARDAR
            save();

            //FINAL GUARDAR
            endSave();
        }

        private void endSave()
        {
            if(editar == true) MessageBox.Show("Compra Actualizada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Compra Registrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

            limpiar();
            Bloqueo();
        }

        private bool validationSave()
        {
            if (cbxTipoComprobante.SelectedValue == null)
            {
                MessageBox.Show("Tipo de Documento no Existente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTipoCambio.Text) == true)
            {
                MessageBox.Show("No Existe Tipo de Cambio", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fn.Existencia("*", "Proveedor", "Numero='" + txtNumero.Text + "'") == false)
            {
                MessageBox.Show("Registre Proveedor", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!editar)
            {
                string idProveedor = fn.selectValue("select IDProveedor from proveedor where Numero = '" + txtNumero.Text + "'");

                if (fn.Existencia("*", "CompraContable", "IDProveedor = '" + idProveedor + "' and Serie = '" + txtSerie.Text + "' and Numero = '" + txtCorrelativo.Text + "' and IDTipoComprobante = '" + cbxTipoComprobante.SelectedValue + "'"))
                {
                    MessageBox.Show("La Compra con el proveedor especificado que tiene la serie y numero ya existe", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }


            if (editar == true)
            {
                var msj = MessageBox.Show("¿DESEA MODIFICAR LOS DATOS?", "SISTEMA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msj == DialogResult.Cancel)
                {
                    return false;
                }
            }
        

            return true;
        }

        private void save()
        {
            try
            {
                //VARIABLES
                float tipoCambio = Convert.ToSingle(txtTipoCambio.Text);
                string fechaRegistro = DateTime.Now.ToShortDateString();
                string horaRegistro = DateTime.Now.ToShortTimeString();
                string idProveedor = fn.selectValue("select IDProveedor from proveedor where Numero = '" + txtNumero.Text + "'");
                

                //VARIABLES FACTURACION
                double afecto = Convert.ToDouble(txtAfecto.Text) * tipoCambio;
                double inafecto = Convert.ToDouble(txtInafecto.Text) * tipoCambio;
                double igv = Convert.ToDouble(txtIGV.Text) * tipoCambio;
                double isc = Convert.ToDouble(fn.remplazarNulo(txtISC.Text)) * tipoCambio;
                double otros = Convert.ToDouble(fn.remplazarNulo(txtOtros.Text)) * tipoCambio;
                double descuento = Convert.ToDouble(fn.remplazarNulo(txtDescuento.Text)) * tipoCambio;
                double total = Convert.ToDouble(txtTotal.Text) * tipoCambio;

                if (editar == true)
                {
                    //EDITAR
                    fn.Modificar("CompraContable", "FechaRegistro='" + fechaRegistro + "',HoraRegistro='" + horaRegistro + "',FechaEmision='" + dtpFecha.Value.ToShortDateString() + "',Impuesto='" + lblImpuesto.Text + "',FechaVencimiento='" + dtpFechaVcto.Value.ToShortDateString() + "',IDTipoComprobante='" + cbxTipoComprobante.SelectedValue + "',Serie='" + txtSerie.Text + "',Numero='" + txtCorrelativo.Text + "',IDProveedor='" + idProveedor + "',Moneda='" + cbxMoneda.Text + "',BaseNoGravada='" + inafecto + "',BaseGravada='" + afecto + "',Igv='" + igv + "',ISC='" + isc + "',OtrosTributos='" + otros + "',Descuento='" + descuento + "',Total='" + total + "',TipoCambio='" + txtTipoCambio.Text + "',IDUsuario='" + Datos.idUsuario + "'",
                        "IDCompraContable='"+idCompraContable+"'");

                }
                else
                {
                    //REGISTRAR
                    fn.RegistrarOficial("CompraContable", "FechaRegistro,HoraRegistro,FechaEmision,FechaVencimiento,IDTipoComprobante,Serie,Numero,IDProveedor,Moneda,BaseNoGravada,BaseGravada,Igv,ISC,OtrosTributos,Descuento,Total,TipoCambio,Impuesto,IDUsuario,Cancelada,IDRegistroCompra,ConIGV",
                        "'"+fechaRegistro+"','"+horaRegistro+"','"+dtpFecha.Value.ToShortDateString()+ "','"+dtpFechaVcto.Value.ToShortDateString()+"','"+cbxTipoComprobante.SelectedValue+"','"+txtSerie.Text+"','"+txtCorrelativo.Text+"','"+idProveedor+"','"+cbxMoneda.Text+"','"+inafecto+"','"+afecto+"','"+igv+"','"+isc+"','"+otros+"','"+descuento+"','"+total+"','"+txtTipoCambio.Text+"','"+lblImpuesto.Text+"','"+Datos.idUsuario+"','False','"+Codregistro+"','True'");

                    idCompraContable = fn.selectValue("select max(IDCompraContable) from compracontable");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

    
       

        private void limpiar()
        {
            cbxTipoComprobante.SelectedIndex = -1;
            cbxMoneda.SelectedIndex = 0;
            txtCorrelativo.Text = "";
            txtSerie.Text = "";
            txtNumero.Text = "";
            txtAfecto.Text = "0";
            txtNombre.Text = "";
            txtDescuento.Text = "0";
            txtIGV.Text = "0";
            txtISC.Text = "0";
            txtOtros.Text = "0";
            txtTipoCambio.Text = "1";
            txtTotal.Text = "0";
            txtInafecto.Text = "0";
            editar = false;
        }



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Desbloqueo();
            editar = false;
            
        }

        private void cbxMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMoneda.SelectedIndex == 1)
            {
                txtTipoCambio.Visible = true;
                bool existeTipo = fn.Existencia("*","TipoCambio", "Fecha = '" + dtpFecha.Value.ToShortDateString() + "'");

                if(existeTipo == true)
                {
                    txtTipoCambio.Text = fn.selectValue("select TipoCambio from tipocambio where Fecha = '" + dtpFecha.Value.ToShortDateString() + "'");
                }
                else
                {
                    txtTipoCambio.Text = "";
                    DialogResult msj = MessageBox.Show("Tipo de Cambio con la Fecha "+dtpFecha.Value.ToShortDateString()+" del comprobante No se Encuentra Registrada. Desea Registrarlo?","FactuTED",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

                    FrmTipoCambio frm = new FrmTipoCambio();
                    frm.ShowDialog();

                    return;
                }
            }
            else
            {
                txtTipoCambio.Visible = false;
                txtTipoCambio.Text = "1";
            }

            //if (editar == false)
            //{
            //    calcularFacturacion();
            //}
        }

        private void txtTipoCambio_TextChanged(object sender, EventArgs e)
        {
            //if (ProcEditar == false)
            //{
            //    CalcularTotal();
            //}
        }


        private void txtTotal_TextChanged_1(object sender, EventArgs e)
        {
            //if (ProcEditar == false)
            //{
            //    CalcularTotal();
            //}
        }



        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpFechaVcto.Focus();
            }
        }

      

        


        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCorrelativo.Focus();
            }
        }

        private void txtNumeroDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumero.Focus();
            }
        }

        private void txtRuc_DNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNumero.Text != "")
                {
                    if (fn.Existencia("*", "Proveedor", "Numero='" + txtNumero.Text + "'") == true)
                    {
                        txtNombre.Text = fn.select_one_value("RazonSocial", "Proveedor", "Numero='" + txtNumero.Text + "'", 0);
                        cbxMoneda.Focus();
                    }
                    else
                    {
                        if (txtNumero.TextLength == 11)
                        {

                            FrmBuscarRucAdmin frmRuc = new FrmBuscarRucAdmin();
                            frmRuc.txtruc.Text = txtNumero.Text;
                            frmRuc.ShowDialog();

                            if (frmRuc.registrado == true)
                            {
                                txtNombre.Text = frmRuc.txtrazonsocial.Text;
                                cbxMoneda.Focus();
                            }
                        }
                        else if (txtNumero.TextLength == 8)
                        {
                            FrmBuscarDNIAdmin frmDni = new FrmBuscarDNIAdmin();
                            FrmBuscarDNIAdmin.DNI = txtNumero.Text;
                            frmDni.ShowDialog();

                            if (frmDni.registrado == true)
                            {
                                txtNombre.Text = frmDni.txt_cliente.Text;
                                cbxMoneda.Focus();
                            }

                        }
                    }
                }

            }
        }



        private void verProveedor()
        {
            txtNombre.Text = fn.select_one_value("RazonSocial", "Proveedor", "Numero='" + txtNumero.Text + "'", 0);
            
        }

        private void txtRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }

        

        

        private void cbxMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbxMoneda.SelectedIndex == 1)
                {
                    txtTipoCambio.Focus();
                }
                else
                {
                    txtAfecto.Focus();
                }
            }
        }

        private void txtTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }










        private void txtISC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOtros.Focus();
            }
        }

        private void txtOtros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescuento.Focus();
            }
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            limpiar();
            Bloqueo();
            btnNuevo.Enabled = true;
            
            editar = false;
            btnNuevo.Select();
            
        }

        

        private void txtTipoCambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotal.Focus();
            }
        }

        private void txtISC_TextChanged(object sender, EventArgs e)
        {
            calcularFacturacion();
            //if (ProcEditar == false)
            //{
            //    CalcularTotal();
            //}

        }

      

      

        

       

        private void calcularFacturacion()
        {
            try
            {
                double inafecto = 0, afecto = 0, isc = 0, otrosTributos = 0, igv = 0, descuento = 0, total = 0, impuesto = 0;

                isc = Convert.ToDouble(fn.remplazarNulo(txtISC.Text));
                otrosTributos = Convert.ToDouble(fn.remplazarNulo(txtOtros.Text));
                descuento = Convert.ToDouble(fn.remplazarNulo(txtDescuento.Text));
                impuesto = Convert.ToDouble(lblImpuesto.Text);
                afecto = Convert.ToDouble(fn.remplazarNulo(txtAfecto.Text));
                inafecto = Convert.ToDouble(fn.remplazarNulo(txtInafecto.Text));


                afecto = afecto - (descuento / 1.18);

                igv = ((afecto * impuesto) + (isc * impuesto));

                total = inafecto + afecto + igv + isc + otrosTributos + descuento;


                txtIGV.Text = igv.ToString("0.00");
                txtTotal.Text = total.ToString("0.00");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            calcularFacturacion();
        }

        private void dtpFechaVcto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                cbxTipoComprobante.Focus();
            }
        }

        
        

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                

                calcularFacturacion();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        private void txtOtros_TextChanged(object sender, EventArgs e)
        {
            calcularFacturacion();
           

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaVcto.Value = dtpFecha.Value;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblImpuesto.Text = fn.selectValue("select Valor from parametro where Parametro = 'IGV'");
            calcularFacturacion();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            FrmProveedores frm = new FrmProveedores();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
            editar = false;
            Bloqueo();
        }

        

        private void txtAfecto_TextChanged(object sender, EventArgs e)
        {
            calcularFacturacion();
        }

        private void txtInafecto_TextChanged(object sender, EventArgs e)
        {
            calcularFacturacion();
        }

        private void txtAfecto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtInafecto.Focus();
            }
        }

        private void txtInafecto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtISC.Focus();
            }
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _Guardar();
            }
        }
    }
}
