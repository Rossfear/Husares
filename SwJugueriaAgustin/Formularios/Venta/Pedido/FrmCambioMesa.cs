using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Operaciones
{
    public partial class FrmCambioMesa : Form
    {
        Funciones fn = new Funciones();

        public FrmCambioMesa()
        {
            InitializeComponent();
        }

        private void FrmCambioMesa_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //CARGAMOS ZONAS
            fn.CargarCombo("Zona", "IDZona", "zona where Zona != 'LLEVAR' and IDSucursal = '"+Datos.idSucursal+"'", cboZonaA);
            fn.CargarCombo("Zona", "IDZona", "zona where Zona != 'LLEVAR' and IDSucursal = '"+Datos.idSucursal+"'", cboZonaN);
        }

        private void cboZonaA_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fn.CargarCombo("Mesa", "IDMesa", "Mesa where IDZona='" + cboZonaA.SelectedValue + "'", cboMesaA);
        }

        private void cboZonaN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fn.CargarCombo("Mesa", "IDMesa", "Mesa where IDZona='" + cboZonaN.SelectedValue + "'", cboMesaN);
        }

        private void cboMesaN_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void btnTrasladarMesa_Click(object sender, EventArgs e)
        {
            //VALIDAMOS
            if (validationTrasladar() == false)
            {
                return;
            }

            //GUARDAMOS TRASLADO
            Savetraslado();

            //FINAL DEL TRASLADO
            endTraslado();
        }

        private void endTraslado()
        {


            //ACTUALIZA GRID
            fn.ActualizarGrid(dgvPedidoMA, "select pd.IDPresentacion,pd.Presentacion,pd.Cantidad,pd.Precio from Pedido p inner join PedidoDetalle pd on p.IDPedido = pd.IDPedido where p.Vendido = 'False' and Anulado='False' and p.IDMesa = '" + cboMesaA.SelectedValue + "'");
            fn.ActualizarGrid(dgvPedidoMN, "select pd.IDPresentacion,pd.Presentacion,pd.Cantidad from Pedido p inner join PedidoDetalle pd on p.IDPedido = pd.IDPedido where p.Vendido = 'False' and Anulado='False' and p.IDMesa = '" + cboMesaN.SelectedValue + "'");

            MessageBox.Show("Pedido Trasladado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Savetraslado()
        {
            string idPedidoActual = "", idMozo = "", idPedidoNuevo = "", codigoComanda = "",serie="",numero="";


            //VARIABLES ACTUALES
            SqlDataReader lector = fn.selectMultiValues("select * from Pedido where IDMesa='" + cboMesaA.SelectedValue + "' and Vendido = 'False' and Anulado='False'");
            while (lector.Read())
            {
                idPedidoActual = lector["IDPedido"].ToString();
                idMozo = lector["IDMozo"].ToString();
                serie = lector["Serie"].ToString();
                numero = lector["Numero"].ToString();
            }
            lector.Close();


            if (fn.Existencia("*", "Pedido", "IDMesa='" + cboMesaN.SelectedValue + "' and Vendido = 'False' and Anulado='False'") == false)
            {
                string vSerie = fn.selectValue("select serie from Talonario where Comprobante = 'COMANDA' and IDSucursal = '" + Datos.idSucursal + "'");
                string vNumero = Convert.ToDouble(fn.selectValue("select Numero from Talonario where Comprobante = 'COMANDA' and IDSucursal = '" + Datos.idSucursal + "'")).ToString("00000000");

                idPedidoNuevo = vSerie + "-" + vNumero;

                if (fn.Existencia("*", "Pedido", "IDPedido='" + idPedidoNuevo+ "'") == true)
                {
                    fn.Modificar("Talonario", "Numero=(select MAX(numero) from Pedido where len(numero) = 8)", "Serie='" + vSerie + "'");
                    vNumero = Convert.ToDouble(fn.selectValue("select (Numero+1) from Talonario where Serie = '" + vSerie + "'")).ToString("00000000");
                }

                idPedidoNuevo = vSerie + "-" + vNumero;


                //SI LA MESA NUEVA NO TIENE PEDIDO - SE REGISTRA EL PEDIDO
                fn.RegistrarOficial("Pedido", "IDPedido,Serie,Numero,Fecha,Hora,IDMesa,IDMozo,Total,Vendido,Anulado",
                    "'"+idPedidoNuevo+"','"+vSerie+"','"+vNumero+"','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + cboMesaN.SelectedValue + "','" + idMozo + "','0','False','False'");

                fn.Modificar("Talonario","Numero=Numero+1","Serie='"+vSerie+"'");
            }
            else
            {
                idPedidoNuevo = fn.selectValue("select IDPedido from pedido where IDMesa='" + cboMesaN.SelectedValue + "' and Vendido = 'False' and Anulado='False'");
            }

            

            //REGISTRAMOS EL DETALLE AL NUEVO PEDIDO - (NUEVA MESA)
            foreach (DataGridViewRow rowPedido in dgvPedidoMA.Rows)
            {
                string idPresentacion = rowPedido.Cells["IDPresentacion"].Value.ToString();
                string presentacion = rowPedido.Cells["Presentacion"].Value.ToString();
                string descripcion = rowPedido.Cells["Descripcion"].Value.ToString();
                string cantidad = rowPedido.Cells["Cantidad"].Value.ToString();
                string precio = rowPedido.Cells["precio"].Value.ToString();
                string costo = rowPedido.Cells["Costo"].Value.ToString();
                bool combo = Convert.ToBoolean(rowPedido.Cells["combo"].Value);
                string idPresentacionCombo = rowPedido.Cells["idPresentacionCombo"].Value.ToString();

                fn.RegistrarOficial("PedidoDetalle", "IDPedido,IDPresentacion,Presentacion,Descripcion,Cantidad,Precio,Imprimido,Costo,Vendido,Combo,IDPresentacionCombo",
                "'" + idPedidoNuevo + "','" + idPresentacion + "','" + presentacion + "','" + descripcion + "','" + cantidad + "','" + precio + "','True','" + costo + "','False','"+combo+"','"+idPresentacionCombo+"'");
            }

            fn.Modificar("Pedido", "Anulado='True'", "IDPedido='" + idPedidoActual + "'");
            fn.Modificar("Mesa", "Estado='LIBRE'", "IDMesa='" + cboMesaA.SelectedValue + "'");

            DateTime horaMesa = Convert.ToDateTime(fn.selectValue("select Hora from Mesa where IDMesa = '" + cboMesaA.SelectedValue + "'"));
            fn.Modificar("Mesa", "Estado='OCUPADA',Hora='" + horaMesa.ToString("dd-MM-yyyy HH:mm:ss") + "'", "IDMesa='" + cboMesaN.SelectedValue + "'");
        }

        private bool validationTrasladar()
        {
            if (dgvPedidoMA.Rows.Count == 0)
            {
                MessageBox.Show("Mesa Seleccionada no Tiene Pedido", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboMesaA.SelectedValue == null)
            {
                MessageBox.Show("Especificar la Mesa Actual", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboMesaN.SelectedValue == null)
            {
                MessageBox.Show("Especificar la Mesa Nueva", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboMesaA.SelectedValue.ToString() == cboMesaN.SelectedValue.ToString())
            {
                MessageBox.Show("No se puede Realizar un Traslado a la misma mesa.", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DialogResult msj = MessageBox.Show("Desea Trasladar la Mesa: " + cboMesaA.Text + " Hacia la Mesa: " + cboMesaN.Text, "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (msj == DialogResult.Cancel)
            {
                return false;
            }


            return true;
        }

        private void cboMesaA_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cboMesaA_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cboMesaA_SelectedValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                if(cboMesaA.SelectedValue != null)
                fn.ActualizarGrid(dgvPedidoMA, "select pd.IDPresentacion,pd.Presentacion,pd.Cantidad,pd.Precio,pd.Descripcion,pd.Costo,pd.Combo,pd.IDPresentacionCombo from Pedido p inner join PedidoDetalle pd on p.IDPedido = pd.IDPedido where p.Vendido = 'False' and Anulado='False' and p.IDMesa = (SELECT idmesa from mesa where Mesa = '" + cboMesaA.Text + "' and IDZona = '"+cboZonaA.SelectedValue+"')");
            }
            catch
            {

            }
        }

        private void cboMesaN_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(cboMesaN.SelectedValue != null)
                fn.ActualizarGrid(dgvPedidoMN, "select pd.IDPresentacion,pd.Presentacion,pd.Cantidad,pd.Descripcion,pd.Costo,pd.Combo,pd.IDPresentacionCombo from Pedido p inner join PedidoDetalle pd on p.IDPedido = pd.IDPedido where p.Vendido = 'False' and Anulado='False' and p.IDMesa = (SELECT idmesa from mesa where Mesa = '" + cboMesaN.Text + "' and IDZona = '"+cboZonaN.SelectedValue+"')");
            }
            catch
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
