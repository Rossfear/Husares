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
    public partial class FrmRMovimientoMotorizado : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmRMovimientoMotorizado()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void showData()
        {
            fn.ActualizarGrid(dgvDocumento, "select mm.IDMovimiento,mm.Fecha,mm.Hora,r.Nombres as Motorizado,mm.Descripcion,u.Usuario from MovimientoMotorizado mm left join Repartidor r on mm.IDMotorizado = r.IDRepartidor left join Usuario u on mm.IDUsuario = u.IDUsuario where mm.Fecha between '" + dtpFechaInicio.Value.ToShortDateString() + "' and '"+dtpFechaFin.Value.ToShortDateString()+"' and r.Nombres like '%"+cboRepartidor.Text+"%' order by mm.IDMovimiento desc");
            dgvDocumento.Columns["IDMovimiento"].Visible = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ex.exportaraexcelTimer(dgvDocumento,progressBar1);
        }
    }
}
