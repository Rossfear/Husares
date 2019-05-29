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
    public partial class FrmRegistroMovAdministracion : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        
        public FrmRegistroMovAdministracion()
        {
            InitializeComponent();
        }

        private void txtAño_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(fn.Existencia("*", "RegistroAdministracion", "Mes='"+cbxMes.Text+"' and Año='"+txtAño.Text+"'") == true)
                {
                    buscarRegistro();
                    btnNuevo.Focus();

                    foreach (DataGridViewColumn col in dgvRegistros.Columns)
                    {
                        cbxTipoBusqueda.Items.Add(col.Name);
                    }
                }
                else
                {
                    DialogResult msj = MessageBox.Show("El Registro Administrativo con el Mes especificado no Existe.", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        void buscarRegistro()
        {
            SqlDataReader lectorRegistro = fn.selectMultiValues("select * from RegistroAdministracion where Mes='" + cbxMes.Text + "' and Año='" + txtAño.Text + "'");
            lectorRegistro.Read();
            string idRegistro = lectorRegistro["IDRegistroAdministracion"].ToString();
            txtRAño.Text = lectorRegistro["Año"].ToString();
            txtRMes.Text = lectorRegistro["Mes"].ToString();
            txtRInicial.Text = lectorRegistro["SaldoInicial"].ToString();
            txtREstado.Text = lectorRegistro["Estado"].ToString();

            if(txtREstado.Text == "CERRADA")
            {
                txtSaldoReal.Text = lectorRegistro["SaldoReal"].ToString();
                txtSaldoReal.ReadOnly = true;
            }
            else
            {
                txtSaldoReal.Text = "";
                txtSaldoReal.ReadOnly = false;
            }

            lectorRegistro.Close();

            mostrarGrid(idRegistro);
            
        }

        private void txtSaldoInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(validacionApertura() == false)
                {
                    return;
                }

                aperturaRegistro();

                buscarRegistro();
            }
        }

        private void aperturaRegistro()
        {
            

            MessageBox.Show("Registro Creado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool validacionApertura()
        {
            
            if(cbxMes.Text == "")
            {
                MessageBox.Show("Seleccione Mes", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fn.Existencia("*", "RegistroAdministracion", "Mes='" + cbxMes.Text + "' and Año='" + txtAño.Text + "'") == true)
            {
                MessageBox.Show("Registro Administrativo con Fecha Especificada ya Existe","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            

            DialogResult msj = MessageBox.Show("Desea Abrir un nuevo Registro un Nuevo Registro Bancario", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(msj == DialogResult.Cancel)
            {
                return false;
            }


            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if(txtREstado.Text == "CERRADA")
            {
                DialogResult msj = MessageBox.Show("El Registro Administrativo se encuentra Cerrado. Solo puede Ingresar con Contraseña de Administrador. Desea Continuar","FactuTED",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (msj == DialogResult.OK)
                {
                    FrmContraseña frm = new FrmContraseña();
                    frm.ShowDialog();

                    if (frm.cancel) return;
                }
                else return;
            }

            if (fn.Existencia("*", "RegistroAdministracion", "Mes='" + txtRMes.Text + "' and Año='" + txtRAño.Text + "'") == true)
            {
                string idRegistro = fn.selectValue("select IDRegistroAdministracion from RegistroAdministracion where Mes='" + txtRMes.Text + "' and Año='" + txtAño.Text + "'");
                FrmMovimientoAdministracion frm = new FrmMovimientoAdministracion();
                frm.idRegistro = idRegistro;
                frm.lblRegistro.Text = "Registro Administrativo: " + txtRMes.Text + " - " + txtRAño.Text;
                frm.mesRegistro = (txtRMes.SelectedIndex + 1);
                frm.añoRegistro = Convert.ToInt16(txtAño.Text);
                frm.ShowDialog();

                mostrarGrid(idRegistro);
            }
        }


        void mostrarGrid(string idRegistroAdministracion)
        {
            decimal totalAbono = 0, totalCargo=0;
            decimal saldoInicial = Convert.ToDecimal(txtRInicial.Text);
            decimal saldoFinal = 0 + saldoInicial;  

            fn.ActualizarGrid(dgvRegistros, "select ROW_NUMBER() over(order by ma.Fecha) as Item,ma.IDMovimientoAdministracion,ma.Fecha,ma.Hora,toa.TipoOperacionAdministracion as TipoOperacion,so.SubOperacionAdministracion as SubOperacion,ma.Codigo,ma.Descripcion,ma.Abono,ma.Cargo,'' as Saldo from MovimientoAdministracion ma left join SubOperacionAdministracion so on ma.IDSubOperacion = so.IDSubOperacionAdministracion left join TipoOperacionAdministracion toa on toa.IDTipoOperacionAdministracion = so.IDOperacion where ma.IDRegistroAdministracion = '"+ idRegistroAdministracion + "' order by ma.Fecha");
            dgvRegistros.Columns["IDMovimientoAdministracion"].Visible = false;


            foreach(DataGridViewRow row in dgvRegistros.Rows)
            {
                decimal entrada = Convert.ToDecimal(row.Cells["Abono"].Value);
                totalAbono = totalAbono + entrada;

                decimal salida = Convert.ToDecimal(row.Cells["cargo"].Value);
                totalCargo = totalCargo + salida;

                saldoFinal = saldoFinal + entrada - salida;
                row.Cells["Saldo"].Value = saldoFinal;
            }

            txtSaldoActual.Text = saldoFinal.ToString("#,#.00");
            txtAbono.Text = totalAbono.ToString("#,#.00");
            txtCargo.Text = totalCargo.ToString("#,#.00");
        }

        private void FrmRegistroMovBancarios_Load(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione Registro a Eliminar", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            


            DialogResult msj = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (msj == DialogResult.OK)
            {
                FrmContraseña frm = new FrmContraseña();
                frm.ShowDialog();

                if (frm.cancel == false)
                {
                    fn.Eliminar("MovimientoAdministracion", "IDMovimientoAdministracion='" + dgvRegistros.CurrentRow.Cells["IDMovimientoAdministracion"].Value.ToString() + "'");
                    MessageBox.Show("Dato Eliminado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string idRegistro = fn.selectValue("select IDRegistroAdministracion from RegistroAdministracion where Mes='" + txtRMes.Text + "' and Año='" + txtAño.Text + "'");
                    mostrarGrid(idRegistro);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ex.exportaraexcelTimer(dgvRegistros,progressBar1);
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if(validacionCerrar() == false)
            {
                return;
            }
            

            string idRegistro = fn.selectValue("select IDRegistroAdministracion from RegistroAdministracion where Mes='" + txtRMes.Text + "' and Año='" + txtAño.Text + "'");
            fn.Modificar("RegistroAdministracion","SaldoReal='"+txtSaldoReal.Text+"',Estado='CERRADA'", "IDRegistroAdministracion='"+idRegistro+"'");
            buscarRegistro();
        }

        private bool validacionCerrar()
        {
            if (txtREstado.Text == "CERRADA")
            {
                MessageBox.Show("El Registro se Encuentra Cerrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtSaldoReal.Text) == true)
            {
                MessageBox.Show("Especifique Saldo Real", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }

            DialogResult msj = MessageBox.Show("Desea Cerrar La caja Administrativo de " + txtRMes.Text + " - " + "Año: " + txtRAño.Text + "?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(msj == DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvRegistros.CurrentCell = null;

                foreach (DataGridViewRow row in dgvRegistros.Rows)
                {
                    if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                    {
                        row.Visible = true;
                    }
                    else if (row.Cells[cbxTipoBusqueda.Text].Value.ToString().Contains(txtBuscar.Text))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ex.exportaraexcelTimer(dgvRegistros,progressBar1);
        }
    }
}
