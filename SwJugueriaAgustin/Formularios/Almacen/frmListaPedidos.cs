using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Almacen;
using System;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Reportes
{
    public partial class frmListaPedidos : Form
    {
        Funciones fn = new Funciones();
        string idAlmacen;
        string idPedido;
        private bool load;

        public frmListaPedidos()
        {
            InitializeComponent();
        }

        private void frmListaPedidos_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Almacen","IDAlmacen","Almacen", cbxAlmacenEmisor);
        }

        private void mostrarPedidos()
        {
            fn.ActualizarGrid(dgvListaPedidos, "select p.IDPedido,p.FechaEntrega,a.IDAlmacen as IDAlmacenReceptor,a.Almacen as AlmacenReceptor,p.Comentario,u.Nombres,ae.Almacen as AlmacenEmisor,ae.IDAlmacen as IDAlmacenEmisor from PedidoA p  inner join Almacen a on p.IDAlmacenReceptor = a.IDAlmacen  inner join Usuario u on p.IDUsuario = u.IDUsuario  inner join Almacen ae on p.IDAlmacenEmisor = ae.IDAlmacen where p.FechaEntrega between '" + dtpFecha.Value.ToShortDateString()+"' and '"+dtpFin.Value.ToShortDateString()+"' and IDAlmacenEmisor = '"+cbxAlmacenEmisor.SelectedValue+"' and p.Atendido='False'");
            dgvListaPedidos.Columns["IDPedido"].Visible = false;
            dgvListaPedidos.Columns["IDAlmacenEmisor"].Visible = false;
            dgvListaPedidos.Columns["AlmacenEmisor"].Visible = false;
            dgvListaPedidos.Columns["IDAlmacenReceptor"].Visible = false;

        }

    
  

   

        private void button1_Click(object sender, EventArgs e)
        {
            //if (validacionGuardar() == false)
            //{
            //    return;
            //}

            //DialogResult msj = MessageBox.Show("Desea REGISTRAR la Atencion de Insumos?", "San Agustin", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //string fecha = DateTime.Now.ToShortDateString();
            //if (msj == DialogResult.OK)
            //{
            //    //REGISTRAMOS SALIDA DEL ALMACEN EMISOR
            //    fn.Registrar("SalidaInsumo", "'" + fecha + "',(select IDTipoSalida from TipoSalida where TipoSalida = 'TRASLADO'),'" + lblAlmacenEmisor.Tag + "','False','" + Datos.idUsuario + "'");

                

            //    //REGISTRAMOS ENTRADA DEL ALMACEN RECEPTOR
            //    fn.RegistrarOficial("EntradaInsumo", "Fecha,IDTipoEntrada,IDAlmacenReceptor,Anulada,IDUsuario", "'" + fecha + "',(SELECT IDTipoEntrada from TipoEntrada where TipoEntrada = 'TRASLADO'),'" + cbxAlamcenReceptor.SelectedValue + "','False','" + Datos.idUsuario + "'");

            //    //OBTENEMOS CODIGO DE ENTRADA Y SALIDA
            //    string IDEntrada = fn.select_one_value("MAX(IDEntrada)", "EntradaInsumo", "IDEntrada>0", 0);
            //    string IDSalida = fn.select_one_value("MAX(IDSalida)", "SalidaInsumo", "IDSalida>0", 0);

            //    //REGISTRAMOS EL TRASLADO
            //    fn.RegistrarOficial("Traslado", "Fecha,IDEntrada,IDSalida,Anulada", "'" + fecha + "','" + IDEntrada + "','" + IDSalida + "','False'");

            //    //ENTRADA TIENDA
            //    if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" + cbxAlamcenReceptor.SelectedValue + "'") == "True")
            //    {
            //        string idApertura = fn.select_one_value("MAX(IDApertura)", "AperturaAlmacen", "IDApertura>0", 0);
            //        fn.RegistrarOficial("EntradaTienda", "IDEntrada,IDApertura", "'" + IDEntrada + "','" + idApertura + "'");
            //    }

            //    //SALIDA TIENDA
            //    if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" + cbxAlmacenEmisor.SelectedValue + "'") == "True")
            //    {
            //        string idApertura = fn.select_one_value("MAX(IDApertura)", "AperturaAlmacen", "IDApertura>0", 0);
            //        fn.RegistrarOficial("SalidaTienda", "IDSalida,IDApertura", "'" + IDSalida + "','" + idApertura + "'");
            //    }

            //    //DETALLE
            //    for (short i = 0; i < dgvSalida.Rows.Count; i++)
            //    {
            //        string IDInsumo = dgvSalida.Rows[i].Cells["cnCod"].Value.ToString();
            //        string insumo = dgvSalida.Rows[i].Cells["cnInsumo"].Value.ToString();
            //        string cantidad = dgvSalida.Rows[i].Cells["cnCantidad"].Value.ToString();

            //        //REGISTRAMOS DETALLE SALIDA DEL ALMACEN EMISOR
            //        fn.RegistrarOficial("detallesalidainsumo", "IDSalidaInsumo,IDInsumo,Cantidad", "'" + IDSalida + "','" + IDInsumo + "','" + cantidad + "'");

            //        //RESTAMOS STOCK DEL ALMACEN EMISOR
            //        fn.Modificar("StockAlmacen", "Stock=Stock-" + cantidad, "IDAlmacen='" + cbxAlmacenEmisor.SelectedValue + "' and IDInsumo = '" + IDInsumo + "'");

            //        //REGISTRAMOS KARDEX DE ALMACEN EMISOR
            //        fn.Registrar("Kardex", "'" + DateTime.Now.ToShortDateString() + "','TRASLADO SALIDA','" + IDSalida + "','0','" + cantidad + "',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + cbxAlmacenEmisor.SelectedValue + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + cbxAlmacenEmisor.SelectedValue + "' and IDInsumo='" + IDInsumo + "')");


            //        //REGISTRAMOS SU DETALLE ENTRADA
            //        fn.RegistrarOficial("DetalleEntradaInsumo", "IDEntradaInsumo,IDInsumo,Cantidad", "'" + IDEntrada + "','" + IDInsumo + "','" + cantidad + "'");

            //        //VERIFICAMOS SI ALMACEN RECEPTOR PERMITE EL INGRESO DE INSUMO
            //        if (fn.select_one_value("PermiteEntrada", "Almacen", "IDAlmacen='" + cbxAlamcenReceptor.SelectedValue + "'", 0) == "True")
            //        {

            //            //VERIFICAMOS SI EL ALMACEN RECEPTOR TIENE EL INSUMO
            //            if (fn.Existencia("*", "StockAlmacen", "IDAlmacen='" + cbxAlamcenReceptor.SelectedValue + "' and IDInsumo='" + IDInsumo + "'") == true)
            //            {
            //                //AUMENTAMOS EL STOCK DEL ALMACEN RECEPTOR
            //                fn.Modificar("StockAlmacen", "Stock=Stock+" + cantidad, "IDAlmacen='" + cbxAlamcenReceptor.SelectedValue + "' and IDInsumo='" + IDInsumo + "'");
            //            }
            //            else
            //            {
            //                //REGISTRAMOS EL INSUMO
            //                fn.RegistrarOficial("StockAlmacen", "IDInsumo,IDAlmacen,Stock,PermitirControl", "'" + IDInsumo + "','" + cbxAlamcenReceptor.SelectedValue + "','" + cantidad + "','False'");
            //            }

            //            //REGISTRAMOS KARDEX DE ALMACEN RECEPTOR
            //            fn.Registrar("Kardex", "'" + DateTime.Now.ToShortDateString() + "','TRASLADO ENTRADA','" + IDEntrada + "','" + cantidad + "','0',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + cbxAlamcenReceptor.SelectedValue + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + cbxAlamcenReceptor.SelectedValue + "' and IDInsumo='" + IDInsumo + "')");

            //        }

            //    }



            //    dgvSalida.Rows.Clear();
            //    MessageBox.Show("Traslado Re de Productos REGISTRADA", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private bool validacionGuardar()
        {
           
            //REGISTRAMOS LA SALIDA
            

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostrarPedidos();

            
        }

        private void dgvAtendiendoInsumo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvListaPedidos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvListaInsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                atenderInsumo();
            }

            
        }

        private void atenderInsumo()
        {
            
        }


        private void dgvListaPedidos_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FrmAtenderPedido frm = new FrmAtenderPedido();
                frm.idPedido = dgvListaPedidos.CurrentRow.Cells["IDPedido"].Value.ToString();
                frm.lblAlmacenEmisor.Text = dgvListaPedidos.CurrentRow.Cells["AlmacenEmisor"].Value.ToString();
                frm.lblAlmacenEmisor.Tag = dgvListaPedidos.CurrentRow.Cells["IDAlmacenEmisor"].Value.ToString();
                frm.lblAlmacenReceptor.Text = dgvListaPedidos.CurrentRow.Cells["AlmacenReceptor"].Value.ToString();
                frm.lblAlmacenReceptor.Tag = dgvListaPedidos.CurrentRow.Cells["IDAlmacenReceptor"].Value.ToString();
                frm.ShowDialog();

                mostrarPedidos();
            }
        }
    }
}
