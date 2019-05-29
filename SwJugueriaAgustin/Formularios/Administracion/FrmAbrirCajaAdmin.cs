using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Administracion
{
    public partial class FrmAbrirCajaAdmin : Form
    {
        Funciones fn = new Funciones();
        bool editar = false;
        string id;
        public FrmAbrirCajaAdmin()
        {
            InitializeComponent();
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if(validacionApertura() == false)
            {
                return;
            }

            if(editar == false)
            {
                fn.RegistrarOficial("RegistroAdministracion", "FechaApertura,Mes,Año,Estado,SaldoInicial,IDUsuario",
                "'" + DateTime.Now.ToShortDateString() + "','" + cbxMes.Text + "','" + txtAño.Text + "','ABIERTA','" + txtSaldo.Text + "','" + Datos.idUsuario + "'");

                MessageBox.Show("Caja Aperturada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                fn.Modificar("RegistroAdministracion","FechaApertura='"+DateTime.Now.ToShortDateString()+"',Mes='"+cbxMes.Text+"',Año='"+txtAño.Text+"',IDUsuario='"+Datos.idUsuario+"',SaldoInicial='"+txtSaldo.Text+"'", "IDRegistroAdministracion='"+id+"'");
                MessageBox.Show("Datos Actualizados", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            editar = false;
            mostrarGrid();
            limpiar();
        }

        void limpiar()
        {
            cbxMes.SelectedIndex = -1;
            txtAño.Text = "";
            txtSaldo.Text = "";
        }

        private bool validacionApertura()
        {
            if(editar == false)
            {
                if (fn.Existencia("*", "RegistroAdministracion", "Mes='" + cbxMes.Text + "' and Año='" + txtAño.Text + "'") == true)
                {
                    MessageBox.Show("Registro Administrativo con el mes y el año Especificado ya se encuentra Aperturada", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            try
            {
                Convert.ToDouble(txtSaldo.Text);
            }
            catch
            {
                MessageBox.Show("Saldo Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(editar == false)
            {
                SqlDataReader lector = fn.selectMultiValues("select * from RegistroAdministracion where Estado = 'ABIERTA'");
                while (lector.Read())
                {
                    string mes = lector["Mes"].ToString();
                    string año = lector["Año"].ToString();
                    MessageBox.Show("Registro Administrativo se encuentra Abierta en el Mes: " + mes + " Año: " + año, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void FrmAbrirCajaAdmin_Load(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        void mostrarGrid()
        {
            fn.ActualizarGrid(dgvRegistros, "select ra.IDRegistroAdministracion,ra.Mes,ra.Año,ra.Estado,ra.SaldoInicial,sum(ma.Abono) as Abono,sum(ma.Cargo) as Cargo,(ra.SaldoInicial + sum(ma.Abono) - sum(ma.Cargo)) as SaldoSistema,ra.SaldoReal,u.Usuario from RegistroAdministracion ra left join MovimientoAdministracion ma on ra.IDRegistroAdministracion = ma.IDRegistroAdministracion left join Usuario u on ra.IDUsuario = u.IDUsuario group by ra.IDRegistroAdministracion,ra.Mes,ra.Año,ra.Estado,ra.SaldoInicial,ra.SaldoReal,u.Usuario");
            
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt16(fn.selectValue("select count(*) from RegistroAdministracion"));

            if (cantidad == 1)
            {
                txtSaldo.ReadOnly = false;
            }
            
            id = dgvRegistros.CurrentRow.Cells["IDRegistroAdministracion"].Value.ToString();
            cbxMes.Text = dgvRegistros.CurrentRow.Cells["Mes"].Value.ToString();
            txtAño.Text = dgvRegistros.CurrentRow.Cells["Año"].Value.ToString();
            txtSaldo.Text = dgvRegistros.CurrentRow.Cells["SaldoInicial"].Value.ToString();
            editar = true;
        }

        private void cbxMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt16(fn.selectValue("select count(*) from RegistroAdministracion"));

            if (cantidad == 0)
            {
                txtSaldo.ReadOnly = false;
            }
            else
            {
                txtSaldo.Text =  fn.selectValue("select top(1) SaldoReal from RegistroAdministracion order by IDRegistroAdministracion desc");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            editar = false;
        }

        private void modificarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContraseña frm = new FrmContraseña();
            frm.ShowDialog();

            if(!frm.cancel)
            {
                FModificarCajaAdmin f = new FModificarCajaAdmin();
                f.cbxMes.Text = dgvRegistros.CurrentRow.Cells["Mes"].Value.ToString();
                f.txtAño.Text = dgvRegistros.CurrentRow.Cells["Año"].Value.ToString();
                f.rbtnCerrar.Checked = dgvRegistros.CurrentRow.Cells["Estado"].Value.ToString().Equals("CERRADA");
                f.rbtnAbrir.Checked = dgvRegistros.CurrentRow.Cells["Estado"].Value.ToString().Equals("ABIERTA");
                f.txtSaldoInicial.Text = dgvRegistros.CurrentRow.Cells["SaldoInicial"].Value.ToString();
                f.txtSaldoReal.Text = dgvRegistros.CurrentRow.Cells["SaldoReal"].Value.ToString();
                f.txtCodigo.Text = dgvRegistros.CurrentRow.Cells["IDRegistroAdministracion"].Value.ToString();
                f.ShowDialog();

                mostrarGrid();
            }
        }
    }
}
