using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Reportes;
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
    public partial class frmSolicitarPedido : Form
    {
        public frmSolicitarPedido()
        {
            InitializeComponent();
        }

        Funciones fn = new Funciones();

        private void txtBuscarInsumo_TextChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
        }

        private void frmSolicitarPedido_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen where PermiteEntrada = 'True'",cbxAlmacen);
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen", cbxAlmacenReceptor);
            cbxAlmacen.SelectedIndex = -1;
            cbxAlmacenReceptor.SelectedIndex = -1;
        }

        private void txtBuscarInsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dgvPedidos.Focus();
            }



        }

        private void dgvListaInsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                for(short i=0;i<dgvListaSolicitud.Rows.Count;i++)
                {
                    string cod = dgvPedidos.CurrentRow.Cells[0].Value.ToString();

                    if(cod == dgvListaSolicitud.Rows[i].Cells[0].Value.ToString())
                    {
                        MessageBox.Show("Producto ya Especificado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                frmAddCantidad frm = new frmAddCantidad();
                frm.lblCantidad.Text = "SALDO";
                
                frm.ShowDialog();
                string saldo = frm.txtCantidad.Text;
                frm.txtCantidad.Text = "";
                frm.lblCantidad.Text = "CANTIDAD";
                frm.ShowDialog();
                string cantidad = frm.txtCantidad.Text;

                
                

                if (frm.Cancelado == false)
                {
                    string cod = dgvPedidos.CurrentRow.Cells["Codigo"].Value.ToString();
                    string insumo = dgvPedidos.CurrentRow.Cells["Insumo"].Value.ToString();
                    string uniMedida = dgvPedidos.CurrentRow.Cells["UniMedida"].Value.ToString();
                    dgvListaSolicitud.Rows.Add(cod, insumo,saldo,cantidad , uniMedida, "X");
                }

            }
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if (validacion() == false)
            {
                return;
            }


            DialogResult msj = MessageBox.Show("Solicitud de Pedido \nAlmacen Receptor: " + cbxAlmacenReceptor.Text+ " \n Fecha Entrega: " + dtpFechaEntrega.Value + "", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(msj == DialogResult.OK)
            {
                //Registramos 
                registroSolicitud();

                //fin
                fin();
            }
        }

        private void fin()
        {
            dgvListaSolicitud.Rows.Clear();
            txtComentario.Text = "";
            MessageBox.Show("Solicitud Registrada","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void registroSolicitud()
        {
            //Registro Solicitud
            fn.RegistrarOficial("PedidoA", "FechaSolicitud,FechaEntrega,IDAlmacenEmisor,Comentario,IDAlmacenReceptor,IDUsuario,Atendido,Anulado",
                "'" + DateTime.Now.ToShortDateString() + "','" + dtpFechaEntrega.Value.ToShortDateString() + "','" + cbxAlmacen.SelectedValue + "','" + txtComentario.Text + "','"+cbxAlmacenReceptor.SelectedValue+"','" + Datos.idUsuario + "','False','False'");

            //Registro DetalleSolicitud
            for(short i=0;i<dgvListaSolicitud.Rows.Count;i++)
            {
                string idInsumo = dgvListaSolicitud.Rows[i].Cells["cnID"].Value.ToString();
                string cantidad = dgvListaSolicitud.Rows[i].Cells["cnCantidad"].Value.ToString();
                string saldo = dgvListaSolicitud.Rows[i].Cells["cnSaldo"].Value.ToString();
                fn.Registrar("DetallePedido", "(SELECT Max(IDPedido) from PedidoA),'" + idInsumo + "','"+saldo+"','" + cantidad + "'");
            }
            
        }

        private bool validacion()
        {
           

            if(dgvListaSolicitud.Rows.Count ==0)
            {
                MessageBox.Show("Especifique productos en la Solicitud", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(cbxAlmacen.SelectedValue == null)
            {
                MessageBox.Show("Almacen Emisor Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbxAlmacenReceptor.SelectedValue == null)
            {
                MessageBox.Show("Almacen Receptor Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(cbxAlmacen.SelectedValue.ToString() == cbxAlmacenReceptor.SelectedValue.ToString())
            {
                MessageBox.Show("No se puede Solicitar al Mismo almacen", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void dgvListaSolicitud_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvListaSolicitud.CurrentRow.Cells["cnQuitar"].Selected == true)
            {
                dgvListaSolicitud.Rows.Remove(dgvListaSolicitud.CurrentRow);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
        }

        private void MostrarDatosGrid()
        {
            fn.ActualizarGrid(dgvPedidos, "select i.IDInsumo as Codigo,i.Insumo,sa.Stock,um.UniMedida from stockalmacen sa,Almacen a,Insumo i,UnidadMedida um where sa.IDInsumo = i.IDInsumo and sa.IDAlmacen = a.IDAlmacen and i.IDUniMedida = um.IDUniMedida and a.Almacen = '" + cbxAlmacen.Text + "' and i.Insumo like '%" + txtBuscarInsumo.Text + "%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReportePedidos frm = new FrmReportePedidos();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmListaEntradaInsumo frm = new FrmListaEntradaInsumo();
            frm.ShowDialog();
        }
    }
}
