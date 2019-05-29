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

namespace SwJugueriaAgustin.Formularios.Almacen
{
    public partial class FrmAtenderPedido : Form
    {
        Funciones fn = new Funciones();
        public string idPedido;
        public FrmAtenderPedido()
        {
            InitializeComponent();
        }

        private void FrmAtenderPedido_Load(object sender, EventArgs e)
        {
            try
            {
                string IDApertura = fn.select_one_value("MAX(IDApertura)", "AperturaAlmacen", "IDApertura>0", 0);

                SqlDataReader lector = fn.selectMultiValues("select aa.FechaApertura as Fecha,aa.TURNO as Turno,a.Almacen from AperturaAlmacen aa inner join Almacen a on aa.idalmacen = a.IDAlmacen where IDApertura = '" + IDApertura + "'");
                lector.Read();
                lblAlmacen.Text = lector["Almacen"].ToString();
                lblFechaApertura.Text = Convert.ToDateTime(lector["Fecha"].ToString()).ToShortDateString();
                lblTurno.Text = lector["Turno"].ToString();
                lector.Close();
            }
            catch
            {

            }
            


            fn.MostrarGri("i.IDInsumo,i.Insumo,dp.Saldo,dp.Cantidad,um.UniMedida", "DetallePedido dp inner join Insumo i on dp.IDInsumo = i.IDInsumo inner join UnidadMedida um on i.IDUniMedida = um.IDUniMedida ", "IDPedido = '" + idPedido + "'", dgvListaInsumo, "DatellePedido");
            dgvListaInsumo.Columns["IDInsumo"].Visible = false;

            gbxDatosTienda.Visible = false;

            if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen  ='"+lblAlmacenEmisor.Tag+"'") == "True")
            {
                gbxDatosTienda.Visible = true;
            }
            else if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen  ='" + lblAlmacenReceptor.Tag + "'") == "True")
            {
                gbxDatosTienda.Visible = true;
            }
        }

        private void dgvListaInsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                atenderInsumo();
            }

        }

        private void atenderInsumo()
        {
            try
            {
                string codInsumo = dgvListaInsumo.CurrentRow.Cells["IDInsumo"].Value.ToString();
                string insumo = dgvListaInsumo.CurrentRow.Cells["Insumo"].Value.ToString();

                for (short i = 0; i < dgvAtendiendoInsumo.Rows.Count; i++)
                {
                    string codigo = dgvAtendiendoInsumo.Rows[i].Cells["cnCodigo"].Value.ToString();
                    if (codInsumo == codigo)
                    {
                        MessageBox.Show("El Inusmo ya se Encuentra en la Lista de Atendidos. Verificar", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                frmAddCantidad frm = new frmAddCantidad();
                frm.ShowDialog();

                if (frm.Cancelado == false)
                {
                    dgvAtendiendoInsumo.Rows.Add(codInsumo, insumo, frm.txtCantidad.Text, 'X');

                    dgvListaInsumo.Rows.Remove(dgvListaInsumo.CurrentRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validacionGuardar()
        {
            if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" + lblAlmacenEmisor.Tag + "'") == "True")
            {
                SqlDataReader lector = fn.selectMultiValues("select top(1) * from aperturaAlmacen order by FechaApertura desc");
                lector.Read();
                DateTime fecha = Convert.ToDateTime(lector["FechaApertura"].ToString());
                string estado = lector["Estado"].ToString();

                if (estado == "C")
                {
                    MessageBox.Show("El Almacen de Venta se Encuentra Cerrado. Abrir para continuar con el Registro", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lector.Close();
                    return false;
                }

                if (fecha != Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    DialogResult msj = MessageBox.Show("La fecha de Apertura del Almacen de Venta se Encuentra abierta con la fecha (" + fecha.ToShortDateString() + ") siento diferente a la de Hoy : " + DateTime.Now.ToShortDateString() + ". Si Continua Afectara al Cuadre de Almacen con le Fecha: " + fecha.ToShortDateString() + ". Desea Continuar con el Registro?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (msj == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                lector.Close();
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validacionGuardar() == false)
            {
                return;
            }

            DialogResult msj = MessageBox.Show("Desea REGISTRAR la Atencion del Pedido", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string fecha = DateTime.Now.ToShortDateString();
            if (msj == DialogResult.OK)
            {
                //REGISTRAMOS SALIDA DEL ALMACEN EMISOR
                fn.RegistrarOficial("SalidaInsumo","Fecha,IDTipoSalida,IDAlmacenEmisor,Anulada,IDUsuario",
                    "'" + fecha + "',(select IDTipoSalida from TipoSalida where TipoSalida = 'TRASLADO'),'" + lblAlmacenEmisor.Tag + "','False','" + Datos.idUsuario + "'");

                //OBTENEMOS CODIGO DE SALIDA
                string IDSalida = fn.select_one_value("MAX(IDSalida)", "SalidaInsumo", "IDSalida>0", 0);

                //SALIDA TIENDA
                if (fn.selectValue("select PermiteVender from Almacen where IDAlmacen = '" +    lblAlmacenEmisor.Tag + "'") == "True")
                {
                    string idApertura = fn.select_one_value("MAX(IDApertura)", "AperturaAlmacen", "IDApertura>0", 0);
                    fn.RegistrarOficial("SalidaTienda", "IDSalida,IDApertura", "'" + IDSalida + "','" + idApertura + "'");
                }

                //DETALLE
                for (short i = 0; i < dgvAtendiendoInsumo.Rows.Count; i++)
                {
                    string IDInsumo = dgvAtendiendoInsumo.Rows[i].Cells["cnCodigo"].Value.ToString();
                    string insumo = dgvAtendiendoInsumo.Rows[i].Cells["cnInsumo"].Value.ToString();
                    string cantidad = dgvAtendiendoInsumo.Rows[i].Cells["cnCantidad"].Value.ToString();

                    //REGISTRAMOS DETALLE SALIDA DEL ALMACEN EMISOR
                    fn.RegistrarOficial("detallesalidainsumo", "IDSalidaInsumo,IDInsumo,Cantidad", "'" + IDSalida + "','" + IDInsumo + "','" + cantidad + "'");

                    //RESTAMOS STOCK DEL ALMACEN EMISOR
                    fn.Modificar("StockAlmacen", "Stock=Stock-" + cantidad, "IDAlmacen='" + lblAlmacenEmisor.Tag + "' and IDInsumo = '" + IDInsumo + "'");

                    //REGISTRAMOS KARDEX DE ALMACEN EMISOR
                    fn.Registrar("Kardex", "'" + DateTime.Now.ToShortDateString() + "','TRASLADO SALIDA','" + IDSalida + "','0','" + cantidad + "',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + lblAlmacenEmisor.Tag + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + lblAlmacenEmisor.Tag + "' and IDInsumo='" + IDInsumo + "')");
                }

                fn.Modificar("PedidoA","Atendido='True'","IDPedido='"+idPedido+"'");
                MessageBox.Show("Pedido Atendido", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void dgvAtendiendoInsumo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
