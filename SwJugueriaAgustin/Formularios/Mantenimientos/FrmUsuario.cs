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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }
        Clases.Funciones fn = new Clases.Funciones();
        bool update;
        string IDUsuario;
        private void _Enable(bool i)
        {
            gbxDatos.Enabled = i;         
            btnNuevo.Enabled = !i;
            btnGuardar.Enabled = i;
            btnCancelar.Enabled = i;
        }
        private void MostrarDatosGrid()
        {
            fn.ActualizarGrid(dgvUsuario, "select IDUsuario as Codigo,s.Sucursal,u.Nombres as Nombre,u.Telefono,Tipo,Usuario,Contraseña,Habilitado,PermisosEspeciales as [P. Espce.],u.Tactil,Mozo  from Usuario u left join sucursal s on u.IDSucursal = s.IDSucursal where Nombres like '%" + txtBuscar.Text+"%' order by IDUsuario desc");
            dgvUsuario.Columns["Contraseña"].Visible = false;
            dgvUsuario.Columns["Codigo"].Visible = false;
        }
        private void LimpiarControles()
        {
            chbxMozo.Checked = false;
            chbxPermisosEspciales.Checked = false;
            chbxSeleccionTodo.Checked = false;
            chbxTactil.Checked = false;
            txtTelefono.Clear();
            txttrabajador.Clear();
            txtusuario.Clear();
            txtpass.Clear();
            txtConfPass.Clear();
            cboTipo.SelectedIndex = -1;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal", "IDSucursal", "Sucursal",cboSucursal);
            
            permisoNuevo();

            


            _Enable(false);
            MostrarDatosGrid();
            
        }

        private void gridPermiso(string query)
        {
            try
            {
                fn.ActualizarGrid(dgvPermisos, query);

                //PROPIEDADES DE PERMISO
                dgvPermisos.Columns[0].ReadOnly = true;
                dgvPermisos.Columns[1].ReadOnly = true;


                dgvPermisos.Columns[0].Width = 60;
                dgvPermisos.Columns[1].Width = 180;
                dgvPermisos.Columns[2].Width = 60;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _Enable(true);
            txttrabajador.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _Enable(false);
            LimpiarControles();
            update = false;
            permisoNuevo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //VALIDAMOS
            if(validationSave() == false)
            {
                return;
            }

            //GUARDAMOS
            save();

            //FINALIZAMOS
            endSave();
                        
            
        }

        private void endSave()
        {
            _Enable(false);
            LimpiarControles();
            MostrarDatosGrid();
            permisoNuevo();
            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void save()
        {
            string _idUsuario;
            if (update == false)
            {
                //REGISTRAMOS
                fn.RegistrarOficial("Usuario", "Nombres,Telefono,Usuario,Contraseña,Tipo,Habilitado,PermisosEspeciales,IDSucursal,Tactil,Mozo", 
                    "'" + txttrabajador.Text + "','"+txtTelefono.Text+"','" + txtusuario.Text + "','" + txtpass.Text + "','"+cboTipo.Text+"','True','"+chbxPermisosEspciales.Checked+"','"+cboSucursal.SelectedValue+"','"+chbxTactil.Checked+"','"+chbxMozo.Checked+"'");

                _idUsuario = fn.selectValue("select max(IDUsuario) from usuario");
            }
            else
            {
                fn.Modificar("Usuario", "IDSucursal = '"+cboSucursal.SelectedValue+"',Nombres='" + txttrabajador.Text + "',Usuario ='" + txtusuario.Text + "',Telefono='"+txtTelefono.Text+"',PermisosEspeciales='"+chbxPermisosEspciales.Checked+"',Tactil='"+chbxTactil.Checked+ "',Mozo='"+chbxMozo.Checked+"'", "idusuario='" + IDUsuario + "'");
                fn.Eliminar("FormularioUsuario","IDUsuario='"+IDUsuario+"'");
                update = false;
                _idUsuario = IDUsuario;
            }


            foreach (DataGridViewRow row in dgvPermisos.Rows)
            {
                fn.RegistrarOficial("FormularioUsuario", "IDUsuario,IDFormulario,Permiso", "'"+_idUsuario+"','" + row.Cells["Item"].Value + "','" + Convert.ToBoolean(row.Cells["Permiso"].Value) + "'");
            }
        }

        private bool validationSave()
        {
            if(string.IsNullOrWhiteSpace(cboTipo.Text) == true)
            {
                MessageBox.Show("Seleccionar Tipo de Usuario", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtpass.Text != txtConfPass.Text)
            {
                MessageBox.Show("Las contraseñas no Coinciden", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpass.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txttrabajador.Text) == true || string.IsNullOrWhiteSpace(txtpass.Text) == true || string.IsNullOrWhiteSpace(txtusuario.Text) == true)
            {
                MessageBox.Show("Verificar el Ingreso de Datos.", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(update == false)
            {
                if (fn.Existencia("*", "Usuario", "Usuario='" + txtusuario.Text + "'") == true)
                {
                    MessageBox.Show("Nombre de Usuario ya Registrado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            
            return true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos", ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Enable(false);
            txttrabajador.Focus();
            IDUsuario = dgvUsuario.CurrentRow.Cells["ID"].Value.ToString();
            txttrabajador.Text = dgvUsuario.CurrentRow.Cells["NOMBRE TRABAJADOR"].Value.ToString();
            txtusuario.Text = dgvUsuario.CurrentRow.Cells["NOMBRE USUARIO"].Value.ToString();   
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos", ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fn.Eliminar("Usuario", "ID='" + dgvUsuario.CurrentRow.Cells["ID"].Value.ToString() + "'");
            MostrarDatosGrid();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarDatosGrid();
        }

        private void dESHABILITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Deshabilitar El Usuario Selecciondo", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if(msj == DialogResult.OK)
            {
                string idUsuario = dgvUsuario.CurrentRow.Cells["Codigo"].Value.ToString();
                fn.Modificar("Usuario", "Habilitado='False'", "IDUsuario = '" + idUsuario + "'");
                MostrarDatosGrid();
            }


            
        }

        private void mODIFICARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuario.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos", ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _Enable(true);
                txttrabajador.Focus();
                IDUsuario = dgvUsuario.CurrentRow.Cells["Codigo"].Value.ToString();
                cboSucursal.Text = dgvUsuario.CurrentRow.Cells["Sucursal"].Value.ToString();
                chbxTactil.Checked = Convert.ToBoolean(dgvUsuario.CurrentRow.Cells["Tactil"].Value);
                txttrabajador.Text = dgvUsuario.CurrentRow.Cells["Nombre"].Value.ToString();
                txtusuario.Text = dgvUsuario.CurrentRow.Cells["Usuario"].Value.ToString();
                txtTelefono.Text = dgvUsuario.CurrentRow.Cells["Telefono"].Value.ToString();
                cboTipo.Text = dgvUsuario.CurrentRow.Cells["Tipo"].Value.ToString();
                chbxPermisosEspciales.Checked = Convert.ToBoolean(dgvUsuario.CurrentRow.Cells["P. Espce."].Value);
                chbxMozo.Checked = Convert.ToBoolean(dgvUsuario.CurrentRow.Cells["Mozo"].Value);
                txtpass.Text = dgvUsuario.CurrentRow.Cells["Contraseña"].Value.ToString();
                txtConfPass.Text = txtpass.Text;
                update = true;

                if (fn.Existencia("*", "FormularioUsuario", "IDUsuario='" + IDUsuario + "'") == true)
                {
                    gridPermiso("select f.IDFormulario as Item,f.Pagina,f.Formulario,fu.Permiso from FormularioUsuario fu inner join Formulario f on fu.IDFormulario = f.IDFormulario where IDUsuario = '" + IDUsuario + "'");
                }
                else
                {
                    permisoNuevo();
                }

                dgvPermisos.Columns["Item"].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        void permisoNuevo()
        {
            gridPermiso("select IDFormulario as Item,Pagina,Formulario,CONVERT(bit,'False') as Permiso from Formulario order by Pagina");

            dgvPermisos.Columns["Item"].Visible = false;
        }
        private void txttrabajador_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtusuario.Focus();
            }
        }

        private void txtusuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpass.Focus();
            }
        }

        private void cboTipo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConfPass.Focus();
            }
        }

        private void hABILITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Habilitar El Usuario Selecciondo", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (msj == DialogResult.OK)
            {
                string idUsuario = dgvUsuario.CurrentRow.Cells["Codigo"].Value.ToString();
                fn.Modificar("Usuario", "Habilitado='True'", "IDUsuario = '" + idUsuario + "'");
                MostrarDatosGrid();
            }

        }

        private void chbxSeleccionTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxSeleccionTodo.Checked == true)
            {
                foreach (DataGridViewRow row in dgvPermisos.Rows)
                {
                    row.Cells["Permiso"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvPermisos.Rows)
                {
                    row.Cells["Permiso"].Value = false;
                }
            }
        }
    }
}
