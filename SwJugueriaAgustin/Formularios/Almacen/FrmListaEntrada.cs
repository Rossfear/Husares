using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Listas
{
    public partial class FrmListaEntrada : Form
    {
        Funciones fn = new Funciones();
        public FrmListaEntrada()
        {
            InitializeComponent();
        }

        private void FrmListaEntrada_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen", cbxAlmacen);
            fn.añadir_ddl("TipoEntrada", "IDTipoEntrada", "TipoEntrada", cbxTipoEntrada);
        }

        private void mostraGrid()
        {
            if (fn.selectValue("select PermiteVender from almacen where IDAlmacen = '" + cbxAlmacen.SelectedValue + "'") == "True")
            {
                fn.ActualizarGrid(dgvEntrada, "select ei.IDEntrada as Codigo,ei.Fecha,a.Almacen,te.TipoEntrada,u.Usuario  from entradainsumo ei   inner join EntradaTienda et on ei.IDEntrada = et.IDEntrada inner join AperturaAlmacen aa on et.IDApertura = aa.IDApertura inner join TipoEntrada te on ei.IDTipoEntrada = te.IDTipoEntrada  inner join Almacen a on ei.IDAlmacenReceptor = a.IDAlmacen  inner join Usuario u on ei.IDUsuario = u.IDUsuario where a.IDAlmacen = '" + cbxAlmacen.SelectedValue + "' and aa.FechaApertura between '" + dtpFechaInicio.Value.ToShortDateString() + "' and '" + dtpFechaFin.Value.ToShortDateString() + "' and te.TipoEntrada like '%" + cbxTipoEntrada.Text + "%' and ei.Anulada = 'False'");
            }
            else
            {
                fn.ActualizarGrid(dgvEntrada, "select ei.IDEntrada as Codigo,ei.Fecha,a.Almacen,te.TipoEntrada,u.Usuario from entradainsumo ei  inner join TipoEntrada te on ei.IDTipoEntrada = te.IDTipoEntrada inner join Almacen a on ei.IDAlmacenReceptor = a.IDAlmacen inner join Usuario u on ei.IDUsuario = u.IDUsuario where a.Almacen like '%" + cbxAlmacen.Text + "%' and ei.Fecha between '" + dtpFechaInicio.Value.ToShortDateString() + "' and '" + dtpFechaFin.Value.ToShortDateString() + "' and te.TipoEntrada like '%" + cbxTipoEntrada.Text + "%' and ei.Anulada = 'False'");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostraGrid();
        }

        private void dgvEntrada_SelectionChanged(object sender, EventArgs e)
        {
            mostrarDetalle();
        }

        private void mostrarDetalle()
        {
            try
            {
                string IDEntrada = dgvEntrada.CurrentRow.Cells["Codigo"].Value.ToString();
                fn.ActualizarGrid(dgvDetalleEntrada, "select de.IDDetalleEntrada,i.IDInsumo,i.Insumo,de.Cantidad from DetalleEntradaInsumo de inner join Insumo i on de.IDInsumo = i.IDInsumo where IDEntradaInsumo = '" + IDEntrada + "' and de.Anulado = 0");
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validacionAnular() == false)
            {
                return;
            }

            Anular();
            
        }

        private void Anular()
        {
            DialogResult msj = MessageBox.Show("Desea Anular La Entrada", "Factu-TED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if(msj == DialogResult.OK)
            {
                string almacen = dgvEntrada.CurrentRow.Cells["Almacen"].Value.ToString();
                string IDEntrada = dgvEntrada.CurrentRow.Cells["Codigo"].Value.ToString();
                string IDAlmacen = fn.select_one_value("IDAlmacen", "Almacen", "Almacen='" + almacen + "'", 0);
                string TipoEntrada = dgvEntrada.CurrentRow.Cells["TipoEntrada"].Value.ToString();

                //ANULAMOS LA ENTRADA
                fn.Modificar("EntradaInsumo", "Anulada='True'", "IDEntrada='" + IDEntrada + "'");

                //REGISTRAMOS LA ANULACION
                fn.RegistrarOficial("EntradaAnulacion", "IDEntrada,IDUsuario,Fecha,Hora,Motivo", "'" + IDEntrada + "','" + Datos.idUsuario + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + txtMotivo.Text + "'");

                //DEVOLVEMOS STOCK
                for (int i = 0; i < dgvDetalleEntrada.Rows.Count; i++)
                {
                    string IDInsumo = dgvDetalleEntrada.Rows[i].Cells["IDInsumo"].Value.ToString();
                    string cantidad = dgvDetalleEntrada.Rows[i].Cells["Cantidad"].Value.ToString();

                    //DEVOLVEMOS EL STOCK
                    fn.Modificar("StockAlmacen", "Stock=Stock-" + cantidad, "IDAlmacen='" + IDAlmacen + "' and IDInsumo='" + IDInsumo + "'");

                    //REGISTRAMOS KARDEX
                    fn.Registrar("Kardex", "'" + DateTime.Now.ToShortDateString() + "','ANULACION " + TipoEntrada + "','" + IDEntrada + "','0','" + cantidad + "',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + IDAlmacen + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + IDAlmacen + "' and IDInsumo='" + IDInsumo + "')");
                }

                MessageBox.Show("Entrada Anulada", "Factu-TEd", MessageBoxButtons.OK, MessageBoxIcon.Information);


                mostraGrid();

                if(dgvEntrada.Rows.Count == 0)
                {
                    this.Close();
                }
            }
            
        }

        private bool validacionAnular()
        {
            if(string.IsNullOrEmpty(txtMotivo.Text) == true)
            {
                MessageBox.Show("Ingrese el Motivo de Anulación de Entrada", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(dgvEntrada.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione una Entrada", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;   
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var msj = MessageBox.Show("Desea Anular Pedido Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if(msj == DialogResult.OK)
            {
                string IDDetalle = dgvDetalleEntrada.CurrentRow.Cells["IDDetalleEntrada"].Value.ToString();
                fn.Modificar("DetalleEntradaInsumo", "Anulado=1", "IDDetalleEntrada='" + IDDetalle + "'");
                mostrarDetalle();
            }
            
        }
    }
}
