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

namespace SwJugueriaAgustin.Formularios.ReporteAdministrativo
{
    public partial class FrmREgresos : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmREgresos()
        {
            InitializeComponent();
        }

        private void chbxPorMes_CheckedChanged(object sender, EventArgs e)
        {
            if(chbxPorMes.Checked == true)
            {
                cbxMes.Visible = true;
                txtAño.Visible = true;
                dtpFin.Visible = false;
                dtpFecha.Visible = false;
            }
            else
            {
                cbxMes.Visible = false;
                txtAño.Visible = false;
                dtpFin.Visible = true;
                dtpFecha.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(chbxPorMes.Checked == false)
            {
                if(string.IsNullOrEmpty(cbxTipoEgreso.Text) == false)
                {
                    fn.ActualizarGrid(dgEgresos, "select e.IDEgreso,te.TipoEgreso,e.Fecha,e.Motivo,e.Monto,e.Dirigido,u.Usuario from Egreso e left join TipoEgreso te on e.IDTipoEgreso = te.IDTipoEgreso left join Usuario u on e.IDUsuario = u.IDUsuario where e.Fecha between '" + dtpFecha.Value.ToShortDateString() + "' and '" + dtpFin.Value.ToShortDateString() + "' and te.TipoEgreso like '%" + cbxTipoEgreso.Text + "%' order by e.fecha");
                    lblIngresoTotal.Text = fn.remplazarNulo(fn.selectValue("select sum(monto) from Egreso e left join TipoEgreso te on e.IDTipoEgreso = te.IDTipoEgreso where e.Fecha between '" + dtpFecha.Value.ToShortDateString() + "' and '" + dtpFin.Value.ToShortDateString() + "'  and te.TipoEgreso like '%" + cbxTipoEgreso.Text + "%'"));
                }
            }
            else
            {
                fn.ActualizarGrid(dgEgresos, "select e.IDEgreso,te.TipoEgreso,e.Fecha,e.Motivo,e.Monto,e.Dirigido,u.Usuario from Egreso e left join TipoEgreso te on e.IDTipoEgreso = te.IDTipoEgreso left join Usuario u on e.IDUsuario = u.IDUsuario where MONTH(e.Fecha) = '"+(cbxMes.SelectedIndex + 1)+ "' and YEAR(e.Fecha) = '"+txtAño.Text+"' and te.TipoEgreso like '%" + cbxTipoEgreso.Text + "%'  order by e.Fecha");
                lblIngresoTotal.Text = fn.remplazarNulo(fn.selectValue("select sum(monto) from Egreso e left join TipoEgreso te on e.IDTipoEgreso = te.IDTipoEgreso where MONTH(e.Fecha) = '" + (cbxMes.SelectedIndex + 1) + "' and YEAR(e.Fecha) = '" + txtAño.Text + "' and te.TipoEgreso like '%" + cbxTipoEgreso.Text + "%'"));
            }
            
        }

        private void FrmREgresos_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("TipoEgreso","IDTipoEgreso", "TipoEgreso",cbxTipoEgreso);
            chbxPorMes.Checked = false ;
            cbxMes.Visible = false;
            txtAño.Visible = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ex.exportaraexcelTimer(dgEgresos, progressBar1);
        }
    }
}
