using SwJugueriaAgustin.Clases;
using SwJugueriaAgustin.Formularios.Compra;
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
    public partial class FrmMovimientoAdministracion : Form
    {
        public string idRegistro;
        Funciones fn = new Funciones();
        public int mesRegistro, añoRegistro;
        public bool editar = false;
        public string id;
        public FrmMovimientoAdministracion()
        {
            InitializeComponent();
        }

        private void FrmMovimientoBancario_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("TipoOperacionAdministracion", "IDTipoOperacionAdministracion", "TipoOperacionAdministracion", cbxTipoOperacion);
            enable(false);

            mostrarGrid(idRegistro);

            btnNuevo.Select();
            btnNuevo.Focus();


            foreach (DataGridViewColumn col in dgvRegistros.Columns)
            {
                cboBuscar.Items.Add(col.Name);
            }
        }

        void mostrarGrid(string idRegistroAdministracion)
        {
            
            fn.ActualizarGrid(dgvRegistros, "select ROW_NUMBER() over(order by ma.IDMovimientoAdministracion) as Item,ma.IDMovimientoAdministracion,ma.Fecha,ma.Hora,toa.TipoOperacionAdministracion as TipoOperacion,so.SubOperacionAdministracion as SubOperacion,ma.Codigo,ma.Descripcion,ma.Abono,ma.Cargo,'' as Saldo from MovimientoAdministracion ma left join SubOperacionAdministracion so on ma.IDSubOperacion = so.IDSubOperacionAdministracion left join TipoOperacionAdministracion toa on toa.IDTipoOperacionAdministracion = so.IDOperacion where ma.IDRegistroAdministracion = '" + idRegistroAdministracion + "' order by ma.Fecha");
            dgvRegistros.Columns["IDMovimientoAdministracion"].Visible = false;

            filtrar();
        }

        void enable(bool state)
        {
            gbxDatos.Enabled = state;
            btnGuardar.Enabled = state;
            btnNuevo.Enabled = !state;
            btnCancel.Enabled = state;
        }

        private void cbxTipoOperacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fn.añadir_ddl("SubOperacionAdministracion", "IDSubOperacionAdministracion", "SubOperacionAdministracion WHERE IDOperacion = (SELECT IDTipoOperacionAdministracion from TipoOperacionAdministracion where TipoOperacionAdministracion = '" + cbxTipoOperacion.Text + "')",cbxSubOperacion);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            enable(true);
            dtpFecha.Focus();
        }

        private void cbxSubOperacion_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            eGuardar();
        }

        private void eGuardar()
        {
            if (validacionGuardar() == false)
            {
                return;
            }

            guardar();

            finalGuardar();
        }

        private void finalGuardar()
        {
            editar = false;
            MessageBox.Show("Operacion Correcta","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Information); ;
            limpiar();
            mostrarGrid(idRegistro);
            
        }

        private void limpiar()
        {
            cbxTipoOperacion.Text = "";
            cbxSubOperacion.Text = "";
            txtDescripcion.Text = "";
            txtAbono.Text = "";
            txtCargo.Text = "";
            txtCodigo.Clear();
            mostrarGrid(idRegistro);

            cbxTipoOperacion.Focus();
        }

        private void guardar()
        {   
            if (editar == true)
            {
                fn.Modificar("MovimientoAdministracion", "Fecha='"+dtpFecha.Value.ToShortDateString()+ "',Hora='"+DateTime.Now.ToShortTimeString()+ "',IDSubOperacion='"+cbxSubOperacion.SelectedValue+ "',Codigo='"+txtCodigo.Text+"',Descripcion='" + txtDescripcion.Text+ "',Abono='"+fn.remplazarNulo(txtAbono.Text)+ "',Cargo='"+fn.remplazarNulo(txtCargo.Text)+"'", "IDMovimientoAdministracion='" + id+"'");
            }
            else
            {
                fn.RegistrarOficial("MovimientoAdministracion", "Fecha,Hora,IDSubOperacion,Codigo,Descripcion,Abono,Cargo,IDRegistroAdministracion",
                   "'" + dtpFecha.Value.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + cbxSubOperacion.SelectedValue + "','"+txtCodigo.Text+"','" + txtDescripcion.Text + "','" + fn.remplazarNulo(txtAbono.Text) + "','" + fn.remplazarNulo(txtCargo.Text) + "','"+idRegistro+"'");
            }
        }

        private void txtNroCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtDescripcion.Focus();
            }
            
        }

        private void txtCargo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                eGuardar();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            limpiar();
            enable(false);
            editar = false;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = Convert.ToDateTime(dgvRegistros.CurrentRow.Cells["Fecha"].Value);
            cbxTipoOperacion.Text = dgvRegistros.CurrentRow.Cells["TipoOperacion"].Value.ToString();
            cbxSubOperacion.Text = dgvRegistros.CurrentRow.Cells["SubOperacion"].Value.ToString();
            txtCodigo.Text = dgvRegistros.CurrentRow.Cells["Codigo"].Value.ToString();
            txtDescripcion.Text = dgvRegistros.CurrentRow.Cells["Descripcion"].Value.ToString();
            txtAbono.Text = dgvRegistros.CurrentRow.Cells["Abono"].Value.ToString();
            txtCargo.Text = dgvRegistros.CurrentRow.Cells["Cargo"].Value.ToString();
            id = dgvRegistros.CurrentRow.Cells["IDMovimientoAdministracion"].Value.ToString();
            editar = true;
            enable(true);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvRegistros.Rows.Count == 0)
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
                    mostrarGrid(idRegistro);
                }
            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void filtrar()
        {
            dgvRegistros.CurrentCell = null;

            foreach (DataGridViewRow row in dgvRegistros.Rows)
            {
                if (string.IsNullOrWhiteSpace(txtBuscador.Text))
                {
                    row.Visible = true;
                }
                else if (row.Cells[cboBuscar.Text].Value.ToString().Contains(txtBuscador.Text))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private bool validacionGuardar()
        {
            if(!string.IsNullOrWhiteSpace(txtCodigo.Text) && editar == false)
            {
                SqlDataReader lector = fn.selectMultiValues("Select * from MovimientoAdministracion where IDRegistroAdministracion='" + idRegistro + "' and Codigo='" + txtCodigo.Text + "'");
                while(lector.Read())
                {
                    string idMovimeinto = lector["IDMovimientoAdministracion"].ToString();
                    string fecha = Convert.ToDateTime(lector["Fecha"]).ToShortDateString();
                    MessageBox.Show("El Movimiento Administrativo ya fue Registrado con el Codigo de Sistema: "+idMovimeinto + " y en la fecha: "+fecha,"FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }
            }

            int mes = dtpFecha.Value.Month;
            int año = dtpFecha.Value.Year;

            if(mes != mesRegistro || año != añoRegistro)
            {
                MessageBox.Show("La Fecha Especificada. No Corresponde a la Fecha del Registro Bancario", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFecha.Focus();
                return false;
            }

            

            if (cbxTipoOperacion.SelectedValue == null)
            {
                MessageBox.Show("Tipo de Operacion Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbxSubOperacion.SelectedValue == null)
            {
                MessageBox.Show("Sub Operacion Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

           


            return true;
        }
    }
}
