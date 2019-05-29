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

namespace SwJugueriaAgustin.Formularios
{
    public partial class frmReporteObservacionesVenta : Form
    {
        Funciones fn = new Funciones();
        public frmReporteObservacionesVenta()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fn.MostrarGri("o.FechaSolicitud,o.IDVenta as [Cod. Venta],o.Observacion,u.Usuario as [Usuario Solic.],o.Atendido",
                "Observacion o,Usuario u", 
                "o.IDEmpleado = u.IDUsuario and u.Usuario like '%"+cbxUsuario.Text+"%' and o.IDVenta like '%"+txtCodVenta.Text+"%' and FechaSolicitud between '"+dtpFechaInicio.Value.ToShortDateString() + "' and '"+dtpFechaFin.Value.ToShortDateString() + "'", dgvSalida, "Observacion");
        }

        private void frmReporteObservacionesVenta_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Usuario", "IDUsuario", "Usuario", cbxUsuario);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportador ex = new exportador();
            ex.ExportExcelTimer(dgvSalida, "OBSERVACIONES", 0, progressBar1, "REPORTE " + dtpFechaInicio.Value.ToShortDateString() + "  -  " + dtpFechaFin.Value.ToShortDateString());
        }
    }
}
