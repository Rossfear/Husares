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

namespace SwJugueriaAgustin.Formularios.Seguridad
{
    public partial class FrmEntradasAnuladas : Form
    {
        Funciones fn = new Funciones();
        public FrmEntradasAnuladas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fn.ActualizarGrid(dgVentas,"select ei.IDEntrada,u.Nombres,ea.Fecha,ea.Hora,ea.Motivo,te.TipoEntrada,a.Almacen from EntradaAnulacion ea inner join EntradaInsumo ei on ea.IDEntrada = ei.IDEntrada inner join Almacen a on ei.IDAlmacenReceptor = a.IDAlmacen inner join Usuario u on ea.IDUsuario = u.IDUsuario inner join TipoEntrada te on ei.IDTipoEntrada = te.IDTipoEntrada where ea.Fecha between '"+dtpFecha.Value.ToShortDateString()+"' and '"+dtpFin.Value.ToShortDateString()+"' and u.Usuario like '%"+cbxUsuario.Text+"%'");
            dgVentas.Columns["IDEntrada"].Visible = false;
        }

        private void FrmEntradasAnuladas_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Usuario","IDUsuario","Usuario where Tipo='ADMINISTRACION' AND Habilitado='True'",cbxUsuario);
        }

        private void dgVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgVentas.Rows.Count > 0)
            {

                string idEntrada = dgVentas.CurrentRow.Cells["IDEntrada"].Value.ToString();
                fn.ActualizarGrid(dataGridView1, "select i.Insumo,de.Cantidad from DetalleEntradaInsumo de inner join Insumo i on de.IDInsumo = i.IDInsumo where de.IDEntradaInsumo = '"+idEntrada+"'");

                

            }
            else
            {
                MessageBox.Show("No se Selecciono Ninguna Observación", "Factu-TED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
