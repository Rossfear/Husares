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

namespace SwJugueriaAgustin.Formularios.AdministracionReporte
{
    public partial class FrmRCuadreAdministracion : Form
    {
        Funciones fn = new Funciones();
        public FrmRCuadreAdministracion()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //******************** SALDOS *********************
            //lblSaldoMesAnterior.Text = 

            //******************** EGRESOS ********************
            //decimal egreso = 0;
            //fn.ActualizarGrid(dgvEgreso, "select te.TipoEgreso,sum(e.Monto) as Egreso from Egreso e left join TipoEgreso te on e.IDTipoEgreso = te.IDTipoEgreso where MONTH(e.Fecha) = " + (cbxMes.SelectedIndex + 1) + " and YEAR(e.Fecha) = " + txtAño.Text + " group by te.TipoEgreso,te.Contable");
            //foreach (DataGridViewRow rowEgreso in dgvEgreso.Rows)
            //{
            //    egreso += Convert.ToDecimal(rowEgreso.Cells["Egreso"].Value);
            //}
            //lblEgresoTotal.Text = egreso.ToString("#,#.00");



        }
    }
}
