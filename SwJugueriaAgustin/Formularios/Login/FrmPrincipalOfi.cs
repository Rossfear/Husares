using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios;
using SwJugueriaAgustin.Formularios.Reportes;
using SwJugueriaAgustin.Formularios.Mantenimiento;
using SwJugueriaAgustin.Formularios.Operaciones;
using SwJugueriaAgustin.Formularios.Listas;
using SwJugueriaAgustin.Formularios.ReporteVenta;
using System.Data.SqlClient;
using SwJugueriaAgustin.Formularios.Compra;
using SwJugueriaAgustin.Formularios.Mantenimientos.Atributos;
using SwJugueriaAgustin.Compra.Mantenimiento;
using SwJugueriaAgustin.Formularios.Compra_Reporte;
using SwJugueriaAgustin.Formularios.Seguridad;
using SwJugueriaAgustin.Formularios.SeguridadReporte;
using SwJugueriaAgustin.Formularios.VentaReporte;
using SwJugueriaAgustin.Formularios.Login;
using SwJugueriaAgustin.Formularios.Administracion;
using SwJugueriaAgustin.Formularios.ReporteAdministrativo;
using SwJugueriaAgustin.Formularios.AdministracionReporte;
using SwJugueriaAgustin.Compra.Operacion;
using SwJugueriaAgustin.Formularios.Mantenimientos.Entidades;
using SwJugueriaAgustin.Formularios.Mantenimientos;
using SwJugueriaAgustin.Formularios.Venta.Caja;
using SwJugueriaAgustin.Formularios.Configuracion;
using System.Collections.Generic;
using DevExpress.XtraBars.Ribbon;

namespace SwJugueriaAgustin.Principal
{
    public partial class FrmPrincipalOfi : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Funciones fn = new Funciones();
        public FrmPrincipalOfi()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Dictionary<string, bool> diccionario = new Dictionary<string, bool>();

            SqlDataReader lector = fn.selectMultiValues("SELECT * FROM FormularioUsuario where IDUsuario = '"+Datos.idUsuario+"'");
            if(lector.HasRows)
            {
                while (lector.Read())
                {
                    diccionario.Add(lector["IDFormulario"].ToString(), (bool)lector["Permiso"]);
                }
                lector.Close();
            }
            


            var controls = this.ribbon.Manager.Items;

            for (int i = 0; i < controls.Count; i++)
            {
                var control = controls[i] as BarButtonItem;

                if (control != null)
                {
                    if(diccionario.ContainsKey(controls[i].Name))
                    {
                        controls[i].Enabled = diccionario[controls[i].Name];
                    }
                }
            }


            btnItemEmpresa.Caption = Datos.RazonSocial;
            btnUsuario.Caption = Datos.Usuario;
        }


        private void bBIComprobantes_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.FrmListaVentas);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.FrmListaVentas abrir = new Formularios.FrmListaVentas();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------    
        }

        private void bBIClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.FrmClientes);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.FrmClientes abrir = new Formularios.FrmClientes();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIDEntrada_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCompas);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCompas abrir = new FrmCompas();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIFacturasRec_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.FrmListaCompras);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.FrmListaCompras abrir = new Formularios.FrmListaCompras();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIProveedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.FrmProveedores);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.FrmProveedores abrir = new Formularios.FrmProveedores();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBICategorias_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormAdmin.FrmCategoria);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FormAdmin.FrmCategoria abrir = new FormAdmin.FrmCategoria();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBISubCategorias_ItemClick(object sender, ItemClickEventArgs e)
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

        private void bBIAgregados_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.FrmIngredientesMantenimiento);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.FrmIngredientesMantenimiento abrir = new Formularios.FrmIngredientesMantenimiento();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIInsumos_ItemClick(object sender, ItemClickEventArgs e)
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

        private void bBIProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.Frm_Pro);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.Frm_Pro abrir = new Formularios.Frm_Pro();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBILPrecios_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBINoticiaciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.frmListaObservaciones);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.frmListaObservaciones abrir = new Formularios.frmListaObservaciones();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIConsumoCli_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmVentaCliente);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmVentaCliente abrir = new FrmVentaCliente();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIGePedido_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBIDDevoluciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBIRepresentates_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBIAlmacenes_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBITraspasos_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListaPedidos);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            frmListaPedidos abrir = new frmListaPedidos();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIEntradasYSa_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.FrmObservacion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.frmTraslado abrir = new Formularios.frmTraslado();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIVolStock_ItemClick(object sender, ItemClickEventArgs e)
        {
               
        }

        private void bBIConsInventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBIValoInventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBITarjetaPOS_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBIAntiProveedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBIReciboIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBIPagosEfec_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBICalendarioCPagos_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBICajas_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmConfigurarCaja);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmConfigurarCaja abrir = new FrmConfigurarCaja();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIInParcial_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBISalidadEfec_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("En Proceso...");
        }

        private void bBIStockInsumos_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.frmListaInsumo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.frmListaInsumo abrir = new Formularios.frmListaInsumo();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBITalonario_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.FrmUsuario);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.FrmUsuario abrir = new Formularios.FrmUsuario();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.FrmConfiguracion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.FrmConfiguracion abrir = new Formularios.FrmConfiguracion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCuadreManualVS);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCuadreManualVS abrir = new FrmCuadreManualVS();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------  
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.frmListaObservacionCompra);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.frmListaObservacionCompra abrir = new Formularios.frmListaObservacionCompra();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIReporteGVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.FrmListaVentas);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.FrmListaVentas abrir = new Formularios.FrmListaVentas();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIReporteProducto_ItemClick(object sender, ItemClickEventArgs e)
        { //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.frmReporteVentaxProducto);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.frmReporteVentaxProducto abrir = new Formularios.frmReporteVentaxProducto();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
            
        }

        private void bBIVentaDelivery_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.frmRepVentaPresentFlujo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.frmRepVentaPresentFlujo abrir = new Formularios.frmRepVentaPresentFlujo();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 


        }

        private void bBIListaTraslados_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.frmListaSalidaInsumo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.frmListaSalidaInsumo abrir = new Formularios.frmListaSalidaInsumo();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
            


        }

        private void bBIListaNotificaciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.frmReporteObservacionesVenta);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.frmReporteObservacionesVenta abrir = new Formularios.frmReporteObservacionesVenta();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIVentaxFecha_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.frmReporteVentaDiayMes);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.frmReporteVentaDiayMes abrir = new Formularios.frmReporteVentaDiayMes();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBITiendas_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmAlmacen);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmAlmacen abrir = new FrmAlmacen();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIAnular_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.FrmObservacion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.FrmObservacion abrir = new Formularios.FrmObservacion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void FrmPrincipalOfi_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir del Sistema?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(msj == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                Application.ExitThread();
            }
                
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void bBIKardex_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmKardex);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmKardex abrir = new FrmKardex();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void bBIListaPresentacionesT_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmReportePresentacion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmReportePresentacion abrir = new FrmReportePresentacion();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------
        }

        private void bBISolicitarPedido_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmSolicitarPedido);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            frmSolicitarPedido abrir = new frmSolicitarPedido();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------
        }

        private void bBIListaPedidos_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmReportePedidos);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmReportePedidos abrir = new FrmReportePedidos();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------
        }

        private void barButtonItem6_ItemClick_1(object sender, ItemClickEventArgs e)
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

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
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

        private void bBIStockProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmListaEntradaInsumo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmListaEntradaInsumo abrir = new FrmListaEntradaInsumo();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCuadreAlmacen);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCuadreAlmacen abrir = new FrmCuadreAlmacen();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmListaEntrada);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmListaEntrada abrir = new FrmListaEntrada();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
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

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmListaSalidas);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmListaSalidas abrir = new FrmListaSalidas();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmVentaInsumo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmVentaInsumo abrir = new FrmVentaInsumo();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
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

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmVentasGenerales);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmVentasGenerales abrir = new FrmVentasGenerales();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRCuadreCajaA);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRCuadreCajaA abrir = new FrmRCuadreCajaA();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRSalidaDinero);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRSalidaDinero abrir = new FrmRSalidaDinero();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRPresentacionSemanal);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRPresentacionSemanal abrir = new FrmRPresentacionSemanal();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem38_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteObservacionesVenta);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            frmReporteObservacionesVenta abrir = new frmReporteObservacionesVenta();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
            
        }

        private void Cons_Presentacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmReportePresentacion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmReportePresentacion abrir = new FrmReportePresentacion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Salida_Insumo_ItemClick(object sender, ItemClickEventArgs e)
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

        private void barButtonItem16_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmConfigurarAlmacen);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmConfigurarAlmacen abrir = new FrmConfigurarAlmacen();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private bool validacionAbrirAlmacen()
        {
            SqlDataReader lector = fn.selectMultiValues("select top(1) * from aperturaAlmacen order by IDApertura desc");
            while(lector.Read())
            {
                string estado = lector["Estado"].ToString();
                string fechaApertura = lector["FechaApertura"].ToString();

                if(estado == "A")
                {
                    MessageBox.Show("Estado de Almacen Abierto con la Fecha: " + fechaApertura, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            lector.Close();

            return true;
        }

        private void barButtonItem17_ItemClick_1(object sender, ItemClickEventArgs e)
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

        private void barButtonItem24_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmTipoCambio);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmTipoCambio abrir = new FrmTipoCambio();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
            
        }

        private void barButtonItem22_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmTipoComprobante);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmTipoComprobante abrir = new FrmTipoComprobante();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem25_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmTipoDocumento);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmTipoDocumento abrir = new FrmTipoDocumento();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Anular_Salida_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmListaSalidas);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmListaSalidas abrir = new FrmListaSalidas();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem27_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListaObservacionCompra);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            frmListaObservacionCompra abrir = new frmListaObservacionCompra();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmTipoEntrada);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmTipoEntrada abrir = new FrmTipoEntrada();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmMTipoSalida);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmMTipoSalida abrir = new FrmMTipoSalida();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem28_ItemClick_1(object sender, ItemClickEventArgs e)
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
            FrmSalidaDinero abrir = new FrmSalidaDinero();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Cons_Compra_Eliminadas_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmComprasEliminadas);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmComprasEliminadas abrir = new FrmComprasEliminadas();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem6_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmEntradasAnuladas);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmEntradasAnuladas abrir = new FrmEntradasAnuladas();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
            
        }

        private void barButtonItem13_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmSalidaAnuladas);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmSalidaAnuladas abrir = new FrmSalidaAnuladas();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
            
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmListaObservacionCompra);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmListaObservacionCompra abrir = new FrmListaObservacionCompra();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
            
        }

        private void Manten_Unidad_Medida_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmMUnidadMedida);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmMUnidadMedida abrir = new FrmMUnidadMedida();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Rep_Venta_Contable_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRVentaContable);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRVentaContable abrir = new FrmRVentaContable();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem6_ItemClick_3(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRCompraContable);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRCompraContable abrir = new FrmRCompraContable();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem6_ItemClick_4(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRPresentacionSemanal);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRPresentacionSemanal abrir = new FrmRPresentacionSemanal();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Manten_Tipo_Egreso_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmSubOperacionAdministracion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmSubOperacionAdministracion abrir = new FrmSubOperacionAdministracion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem6_ItemClick_5(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmEgresoAdministracion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmEgresoAdministracion abrir = new FrmEgresoAdministracion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
            
        }

        private void Report_Egresos_Administrativos_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmREgresos);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmREgresos abrir = new FrmREgresos();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Report_Resumen_Administrativo_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRCajaAdministracion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRCajaAdministracion abrir = new FrmRCajaAdministracion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
            
        }

        private void Manten_Tipo_Operacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmTipoOperacion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmTipoOperacion abrir = new FrmTipoOperacion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Manten_Sub_Operaciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmMSubOperaciones);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmMSubOperaciones abrir = new FrmMSubOperaciones();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Movimiento_Bancario_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRegistroMovAdministracion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRegistroMovAdministracion abrir = new FrmRegistroMovAdministracion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Rep_Movimeinto_Tarjeta_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRMovimientoBancario);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRMovimientoBancario abrir = new FrmRMovimientoBancario();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Compra_Contable_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCompraContable);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCompraContable abrir = new FrmCompraContable();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem22_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.innovated.pe/");
        }

        private void Abrir_Caja_Administracion_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmAbrirCajaAdmin);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmAbrirCajaAdmin abrir = new FrmAbrirCajaAdmin();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Ingreso_Administracion_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmIngresoAdministrativo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmIngresoAdministrativo abrir = new FrmIngresoAdministrativo();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem24_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmTipoOperacionAdministracion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmTipoOperacionAdministracion abrir = new FrmTipoOperacionAdministracion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void Cerrar_Caja_Administracion_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCerrarCajaAdministracion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCerrarCajaAdministracion abrir = new FrmCerrarCajaAdministracion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem25_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRCajaAdministracion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRCajaAdministracion abrir = new FrmRCajaAdministracion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem27_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmVentaManual);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmVentaManual abrir = new FrmVentaManual();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem28_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem31_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmMMotorizado);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmMMotorizado abrir = new FrmMMotorizado();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmMMozo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmMMozo abrir = new FrmMMozo();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem38_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCajeros);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCajeros abrir = new FrmCajeros();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmTipoPago);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmTipoPago abrir = new FrmTipoPago();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 

        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmTrasladoMotorizado);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmTrasladoMotorizado abrir = new FrmTrasladoMotorizado();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRMovimientoMotorizado);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------
            
            //Abrir Formulario dentro del MDI.
            FrmRMovimientoMotorizado abrir = new FrmRMovimientoMotorizado();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCajaFechas);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCajaFechas abrir = new FrmCajaFechas();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 

        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCajaFechas);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCajaFechas abrir = new FrmCajaFechas();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCuadreCompraVenta);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCuadreCompraVenta abrir = new FrmCuadreCompraVenta();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem47_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCuadreInsumo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCuadreInsumo abrir = new FrmCuadreInsumo();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem48_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmSucursal);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmSucursal abrir = new FrmSucursal();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------   

        }

        private void barButtonItem51_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmCopiaSeguridad);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmCopiaSeguridad abrir = new FrmCopiaSeguridad();
            abrir.Show();
            //--------------------------------------------   
        }

        private void barButtonItem24_ItemClick_3(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem31_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmSolicitarPedido);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            frmSolicitarPedido abrir = new frmSolicitarPedido();
            abrir.MdiParent = this;
            abrir.Show();
            //--------------------------------------------
        }

        private void barButtonItem32_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListaPedidos);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            frmListaPedidos abrir = new frmListaPedidos();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem25_ItemClick_3(object sender, ItemClickEventArgs e)
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

        private void barButtonItem27_ItemClick_3(object sender, ItemClickEventArgs e)
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

        private void barButtonItem25_ItemClick_4(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmRVentaConciliacion);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FrmRVentaConciliacion abrir = new FrmRVentaConciliacion();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem27_ItemClick_4(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.frmReporteVentaDiayMes);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            Formularios.frmReporteVentaDiayMes abrir = new Formularios.frmReporteVentaDiayMes();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem25_ItemClick_5(object sender, ItemClickEventArgs e)
        {
            //Se Busca el formulario, buscandolo entre los forms abiertos 
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FVentaRepartidor);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }
            //--------------------------------------------

            //Abrir Formulario dentro del MDI.
            FVentaRepartidor abrir = new FVentaRepartidor();
            abrir.MdiParent = this;
            abrir.Show();
            //-------------------------------------------- 
        }

        private void barButtonItem31_ItemClick_3(object sender, ItemClickEventArgs e)
        {
            //Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrnRPedidomozo);

            //if (FrmEvitarMultipleForm != null)
            //{
            //    //si la instancia existe la pongo en primer plano
            //    FrmEvitarMultipleForm.BringToFront();
            //    return;
            //}
            ////--------------------------------------------

            ////Abrir Formulario dentro del MDI.
            //FrnRPedidomozo abrir = new FrnRPedidomozo();
            //abrir.MdiParent = this;
            //abrir.Show();
        }

        private void barButtonItem32_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmReporteMozo);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }

            FrmReporteMozo abrir = new FrmReporteMozo();
            abrir.MdiParent = this;
            abrir.Show();
        }
    }
}