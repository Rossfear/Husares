using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.SeguridadReporte
{
    public partial class FrmSalidaAnuladas : Form
    {
        Funciones fn = new Funciones();
        public FrmSalidaAnuladas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fn.ActualizarGrid(dgVentas, "select ei.IDSalida,u.Nombres,ea.Fecha,ea.Hora,ea.Motivo,te.Tiposalida,a.Almacen from SalidaAnulacion ea inner join salidaInsumo ei on ea.IDSalida = ei.IDSalida inner join Almacen a on ei.IDAlmacenEmisor = a.IDAlmacen inner join Usuario u on ea.IDUsuario = u.IDUsuario inner join Tiposalida te on ei.IDTiposalida = te.IDTiposalida where ea.Fecha between '" + dtpFecha.Value.ToShortDateString() + "' and '" + dtpFin.Value.ToShortDateString() + "' and u.Usuario like '%" + cbxUsuario.Text + "%'");
            dgVentas.Columns["IDSalida"].Visible = false;
        }

        private void FrmEntradasAnuladas_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Usuario", "IDUsuario", "Usuario where Tipo='ADMINISTRACION' AND Habilitado='True'", cbxUsuario);
        }

        private void dgVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgVentas.Rows.Count > 0)
            {

                string IDSalida = dgVentas.CurrentRow.Cells["IDSalida"].Value.ToString();
                fn.ActualizarGrid(dataGridView1, "select i.Insumo,de.Cantidad from DetallesalidaInsumo de inner join Insumo i on de.IDInsumo = i.IDInsumo where de.IDSalidaInsumo = '" + IDSalida + "'");



            }
            else
            {
                MessageBox.Show("No se Selecciono Ninguna Observación", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
