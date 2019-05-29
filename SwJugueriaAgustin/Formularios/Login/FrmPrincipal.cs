using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Configuracion;
using SwJugueriaAgustin.Formularios.Listas;
using SwJugueriaAgustin.Formularios.Mantenimiento;
using SwJugueriaAgustin.Formularios.Operaciones;
using SwJugueriaAgustin.Formularios.Venta.Caja;
using SwJugueriaAgustin.Formularios.Venta.Delivery;
using SwJugueriaAgustin.Formularios.VentaReporte.Caja;
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
    public partial class FrmPrincipal : Form
    {
        Funciones fn = new Funciones();
        public FrmPrincipal()
        {
            InitializeComponent();
            KeyPreview = true;

            KeyDown += FrmPrincipal_KeyDown;
        }

        private void FrmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                Datos.sinTicket = true;
                tsEstadoTickect.Text = "ST";
            }
            else if(e.KeyCode == Keys.C)
            {
                Datos.sinTicket = false;
                tsEstadoTickect.Text = "CT";
            }
            else if(e.KeyCode == Keys.F11)
            {
                FConfiguracionSucursal f = new FConfiguracionSucursal();
                f.ShowDialog();
            }
        }

        private void Mostrarformulario(Form form)
        {
            form.MdiParent = this;
            form.Show();
            form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }






        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (Datos.sinTicket == true)
            {
                tsEstadoTickect.Text = "ST";
            }
            else
            {
                tsEstadoTickect.Text = "CT";
            }

            tssUsuario.Text = Datos.Usuario;
            tssSucursal.Text = Datos.sucursal;
        }








        private void pRODUCTOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Frm_Pro FRM = new Frm_Pro();
            Mostrarformulario(FRM);
        }

  
        private void cLIENTESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmClientes FRM = new FrmClientes();
            Mostrarformulario(FRM);
        }

        private void pROVEEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedores FRM = new FrmProveedores();
            Mostrarformulario(FRM);
        }

       
  

        

      

        

    

       



   

        

        
        


        

        private void cAMBIARCONTRASEÑAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCambiarPass);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCambiarPass abrir = new FrmCambiarPass();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }



        private void aBRIRCAJAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string estadoCaja = "";
            if (fn.Existencia("*", "CAJA", "ID >= 0  ORDER BY ID DESC") == true)
            {
                estadoCaja = fn.select_one_value("top(1)ESTADO", "CAJA", "ID>=0  ORDER BY ID DESC", 0);
            }

            if (estadoCaja == "ABIERTA")
            {
                string fecha = fn.select_one_value("top(1)FECHA_HORA", "CAJA", "ID>=0  ORDER BY ID DESC", 0);
                MessageBox.Show("LA CAJA ESTA ABIERTA DESDE EL DIA " + fecha, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Se Busca el formulario, buscandolo entre los forms abiertos 
                Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Caja);

                if (FrmEvitarMultipleForm != null)
                {
                    //si la instancia existe la pongo en primer plano
                    FrmEvitarMultipleForm.BringToFront();
                    return;
                }
                //--------------------------------------------

                //Abrir Formulario dentro del MDI.
                Frm_Caja abrir = new Frm_Caja();
                abrir.MdiParent = this;
                abrir.Show();
                //-------------------------------------------- 
            }
        }

        private void cERRARALMACENToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader lector = fn.selectMultiValues("select top(1)aa.IDApertura,cast(c.FECHA_HORA as date) as Fecha,aa.Estado from AperturaAlmacen aa inner join CAJA c on aa.IDCaja = c.ID order by IDApertura desc");
                lector.Read();

                string IDApertura = lector["IDApertura"].ToString();
                string Fecha = lector["Fecha"].ToString();
                string Estado = lector["Estado"].ToString();

                //VERIFICAMOS SI EL ALMACEN SE ENCUENTRA CERRADO
                if (Estado == "C")
                {
                    MessageBox.Show("El Almacen se Encuentra Cerrado desde el Dia " + Fecha, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                //Se Busca el formulario, buscandolo entre los forms abiertos 
                Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCerrarAlmacen);

                if (FrmEvitarMultipleForm != null)
                {
                    //si la instancia existe la pongo en primer plano
                    FrmEvitarMultipleForm.BringToFront();
                    return;
                }
                //--------------------------------------------

                //Abrir Formulario dentro del MDI.
                FrmCerrarAlmacen abrir = new FrmCerrarAlmacen();
                abrir.MdiParent = this;
                abrir.Show();
                //-------------------------------------------- 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void aBRIRALMACENToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader lector = fn.selectMultiValues("select top(1)aa.IDApertura,cast(c.FECHA_HORA as date) as Fecha,aa.Estado from AperturaAlmacen aa inner join CAJA c on aa.IDCaja = c.ID order by IDApertura desc");
                lector.Read();

                string IDApertura = lector["IDApertura"].ToString();
                string Fecha = lector["Fecha"].ToString();
                string Estado = lector["Estado"].ToString();

                //VERIFICAMOS SI EL ALMACEN SE ENCUENTRA CERRADO
                if (Estado == "A")
                {
                    MessageBox.Show("El Almacen se Encuentra Abierto desde el Dia " + Fecha, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string idCaja = fn.select_one_value("MAX(ID)", "Caja", "ID>0", 0);


                DateTime fecha = DateTime.Now.Date;

                string ultimaFechaCaja = fn.select_one_value("top(1)cast(FECHA_HORA as Date)", "Caja", "ID>=0 order by ID Desc", 0);

                if (fecha != Convert.ToDateTime(ultimaFechaCaja))
                {
                    DialogResult msj = MessageBox.Show("Seguro que Desea Abrir Almacen con la Caja del Dia " + Convert.ToDateTime(ultimaFechaCaja).ToShortDateString() + " Estando Hoy con Diferente Fecha: " + fecha.ToShortDateString(), "Taberna", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (msj == DialogResult.Cancel)
                    {
                        return;
                    }
                }


                if (fn.Existencia("*", "CAja", "ID>0") == true)
                {
                    if (fn.select_one_value("top(1)ESTADO", "CAJA", "ID>=0  ORDER BY ID DESC", 0) == "CERRADA")
                    {
                        MessageBox.Show("PRIMERO ABRIR CAJA", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (fn.Existencia("*", "AperturaAlmacen", "IDCaja='" + idCaja + "'") == true)
                    {
                        MessageBox.Show("ALMACEN YA SE ENCUENTRA ABIERTO", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Se Busca el formulario, buscandolo entre los forms abiertos 
                        Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmAbirAlmacen);

                        if (FrmEvitarMultipleForm != null)
                        {
                            //si la instancia existe la pongo en primer plano
                            FrmEvitarMultipleForm.BringToFront();
                            return;
                        }
                        //--------------------------------------------

                        //Abrir Formulario dentro del MDI.
                        FrmAbirAlmacen abrir = new FrmAbirAlmacen();
                        abrir.MdiParent = this;
                        abrir.Show();
                        //-------------------------------------------- 
                    }
                }
                else
                {
                    MessageBox.Show("ABRIR CAJA", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

   

        private void sUBCATEGORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormAdmin.FrmSubCategoria);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FormAdmin.FrmSubCategoria abrir = new FormAdmin.FrmSubCategoria();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void sELECCIONMESAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmSeleccionMesa);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmSeleccionMesa abrir = new FrmSeleccionMesa();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }





        private void sALIDADINEROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmSalidaDinero);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------


            //Abrir Formulario dentro del MDI.
            FrmSalidaDinero frm = new FrmSalidaDinero();
            frm.MdiParent = this;
            frm.Show();
            //--------------------------------------------
        }

        private void aBRIRCAJAToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Caja);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Frm_Caja abrir = new Frm_Caja();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 

        }

        private void cERRARCAJAToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if(Datos.ocultarDinero == false)
            {
                //Se Busca el formulario, buscandolo entre los forms abiertos 
                Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCerrarCajaA);

                if (FrmEvitarMultipleForm != null)
                {
                    //si la instancia existe la pongo en primer plano
                    FrmEvitarMultipleForm.BringToFront();
                    return;
                }
                //--------------------------------------------

                //Abrir Formulario dentro del MDI.
                FrmCerrarCajaA abrir = new FrmCerrarCajaA();
                abrir.MdiParent = this;
                abrir.Show();
                //-------------------------------------------- 
            }
            else
            {
                //Se Busca el formulario, buscandolo entre los forms abiertos 
                Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCerrarCajaManualOficial);

                if (FrmEvitarMultipleForm != null)
                {
                    //si la instancia existe la pongo en primer plano
                    FrmEvitarMultipleForm.BringToFront();
                    return;
                }
                //--------------------------------------------

                //Abrir Formulario dentro del MDI.
                FrmCerrarCajaManualOficial abrir = new FrmCerrarCajaManualOficial();
                abrir.MdiParent = this;
                abrir.Show();
                //-------------------------------------------- 
            }
        }

        private void aBRIRCAJAToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void aBRIALMACENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmAbirAlmacen);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmAbirAlmacen abrir = new FrmAbirAlmacen();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void cERRARALMACENToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCerrarAlmacen);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCerrarAlmacen abrir = new FrmCerrarAlmacen();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void iNSUMOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmInsumo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmInsumo abrir = new FrmInsumo();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void iNSUMOALMACENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmStockAlmacen);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmStockAlmacen abrir = new FrmStockAlmacen();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void eNTRADAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmEntradaInsumo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmEntradaInsumo abrir = new FrmEntradaInsumo();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------    
        }

        private void sALIDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmSalidaInsumo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmSalidaInsumo abrir = new FrmSalidaInsumo();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------  
        }

        private void rEIMPRIMIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReimprimir);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            frmReimprimir abrir = new frmReimprimir();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------  
        }

        private void sOLICITARANULACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmObservacion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmObservacion abrir = new FrmObservacion();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------  
        }

        private void tRASLADODEMESAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCambioMesa);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCambioMesa abrir = new FrmCambioMesa();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------  
        }

        private void vENTASALONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCerrarCajaA);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCerrarCajaA abrir = new FrmCerrarCajaA();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------   
        }

       
        private void tRASLADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTraslado);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            frmTraslado abrir = new frmTraslado();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------   
        }

        private void iNGRESODECOMPROBANTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cASAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(validacionCajaSalon() == false)
            {
                return;
            }

            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCuadreCajaManual);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCuadreCajaManual abrir = new FrmCuadreCajaManual();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------   
        }

        private bool validacionCajaSalon()
        {
            string estado = fn.selectValue("select top(1) ESTADO from CAJA where TIPO = 'VENTA SALON' AND IDSucursal = '"+Datos.idSucursal+"' ORDER BY ID desc");

            if (estado == "CERRADA")
            {
                MessageBox.Show("Caja Cerrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void dELIVERYToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(validacionCajaDelivery()== false)
            {
                return;
            }
            
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCajaManualDelivery);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCajaManualDelivery abrir = new FrmCajaManualDelivery();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------   
        }

        private bool validacionCajaDelivery()
        {
            string estado = fn.selectValue("select top(1) ESTADO from CAJA where TIPO = 'DELIVERY' and IDSucursal = '"+Datos.idSucursal+"' ORDER BY ID desc");

            if (estado == "CERRADA")
            {
                MessageBox.Show("Caja Cerrada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir del Sistema?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (msj == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                Application.ExitThread();
            }
        }

        private void rESPUESTASDECAJAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRespuestasCaja);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRespuestasCaja abrir = new FrmRespuestasCaja();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------   
        }

        private void listaPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FListaDelivery);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FListaDelivery abrir = new FListaDelivery();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }
    }
}
