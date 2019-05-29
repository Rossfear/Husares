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
    public partial class FrmListaSalidas : Form
    {
        Funciones fn = new Funciones();
        public FrmListaSalidas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostraGrid();
        }

        private void mostraGrid()
        {
            if (fn.selectValue("select PermiteVender from almacen where IDAlmacen = '" + cbxAlmacen.SelectedValue + "'") == "True")
            {
                fn.ActualizarGrid(dgvSalida, "select si.IDSalida as Codigo,si.Fecha,a.Almacen,te.TipoSalida,u.Usuario   from SalidaInsumo si    inner join tipoSalida te on si.IDTipoSalida = te.IDTipoSalida   inner join Almacen a on si.IDAlmacenEmisor = a.IDAlmacen   inner join Usuario u on si.IDUsuario = u.IDUsuario inner join SalidaTienda st on st.IDSalida = si.IDSalida inner join AperturaAlmacen aa on st.IDApertura = aa.IDApertura where a.Almacen like '%"+cbxAlmacen.Text+"%' and aa.FechaApertura between '"+dtpFechaInicio.Value.ToShortDateString()+"' and '"+dtpFechaFin.Value.ToShortDateString()+"' and te.TipoSalida like '%"+cbxTipoSalida.Text+"%' and si.Anulada = 'False'");
            }
            else
            {
                fn.ActualizarGrid(dgvSalida, "select ei.IDSalida as Codigo,ei.Fecha,a.Almacen,te.TipoSalida,u.Usuario  from SalidaInsumo ei   inner join tipoSalida te on ei.IDTipoSalida = te.IDTipoSalida  inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen  inner join Usuario u on ei.IDUsuario = u.IDUsuario where a.Almacen like '%" + cbxAlmacen.Text + "%' and ei.Fecha between '" + dtpFechaInicio.Value.ToShortDateString() + "' and '" + dtpFechaFin.Value.ToShortDateString() + "' and te.TipoSalida like '%" + cbxTipoSalida.Text + "%' and ei.Anulada = 'False'");
            }
        }

        private void dgvEntrada_SelectionChanged(object sender, EventArgs e)
        {
            mostrarDetalle();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (validacionAnular() == false)
            {
                return;
            }

            Anular();
        }

        private bool validacionAnular()
        {
            if (string.IsNullOrEmpty(txtMotivo.Text) == true)
            {
                MessageBox.Show("Ingrese el Motivo de Anulación de Salida", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvSalida.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione una Salida", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void Anular()
        {
            DialogResult msj = MessageBox.Show("Desea Anular La Salida", "Factu-TED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (msj == DialogResult.OK)
            {
                string almacen = dgvSalida.CurrentRow.Cells["Almacen"].Value.ToString();
                string IDEntrada = dgvSalida.CurrentRow.Cells["Codigo"].Value.ToString();
                string IDAlmacen = fn.select_one_value("IDAlmacen", "Almacen", "Almacen='" + almacen + "'", 0);
                string TipoEntrada = dgvSalida.CurrentRow.Cells["TipoSalida"].Value.ToString();

                //ANULAMOS LA SALIDA
                fn.Modificar("SalidaInsumo", "Anulada='True'", "IDSalida='" + IDEntrada + "'");

                //REGISTRAMOS LA ANULACION
                fn.RegistrarOficial("SalidaAnulacion", "IDSalida,IDUsuario,Fecha,Hora,Motivo", "'" + IDEntrada + "','" + Datos.idUsuario + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + txtMotivo.Text + "'");

                //DEVOLVEMOS STOCK
                for (int i = 0; i < dgvDetalleSalida.Rows.Count; i++)
                {
                    string IDInsumo = dgvDetalleSalida.Rows[i].Cells["IDInsumo"].Value.ToString();
                    string cantidad = dgvDetalleSalida.Rows[i].Cells["Cantidad"].Value.ToString();

                    //DEVOLVEMOS EL STOCK
                    fn.Modificar("StockAlmacen", "Stock=Stock+" + cantidad, "IDAlmacen='" + IDAlmacen + "' and IDInsumo='" + IDInsumo + "'");

                    //REGISTRAMOS KARDEX
                    fn.Registrar("Kardex", "'" + DateTime.Now.ToShortDateString() + "','ANULACION " + TipoEntrada + "','" + IDEntrada + "','" + cantidad + "','0',(select Stock from StockAlmacen where IDInsumo = '" + IDInsumo + "' and IDAlmacen='" + IDAlmacen + "'),(SELECT IDStockAlmacen from StockAlmacen where IDAlmacen = '" + IDAlmacen + "' and IDInsumo='" + IDInsumo + "')");
                }

                MessageBox.Show("Salida Anulada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);


                mostraGrid();

                if (dgvSalida.Rows.Count == 0)
                {
                    this.Close();
                }
            }

        }

        private void FrmListaSalidas_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Almacen", "IDAlmacen", "Almacen", cbxAlmacen);
            fn.añadir_ddl("TipoSalida", "IDTipoSalida", "TipoSalida where Estado = 'True'", cbxTipoSalida);
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var msj = MessageBox.Show("Desea Anular Detalle de Pedido Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (msj == DialogResult.OK)
            {
                string IDDetalle = dgvDetalleSalida.CurrentRow.Cells["IDDetalle"].Value.ToString();
                fn.Modificar("DetalleSalidaInsumo", "Anulado=1", "IDDetalle='" + IDDetalle + "'");
                mostrarDetalle();
            }
        }

        private void mostrarDetalle()
        {
            try
            {
                string IDEntrada = dgvSalida.CurrentRow.Cells["Codigo"].Value.ToString();
                fn.ActualizarGrid(dgvDetalleSalida, "select de.IDDetalle,i.IDInsumo,i.Insumo,de.Cantidad from DetalleSalidaInsumo de inner join Insumo i on de.IDInsumo = i.IDInsumo where IDSalidaInsumo = '" + IDEntrada + "' and de.Anulado = 0");
            }
            catch
            {

            }
        }
    }
}
