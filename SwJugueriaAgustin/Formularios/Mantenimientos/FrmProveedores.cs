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
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }
        //Yamado a funciones
        Clases.Funciones fn = new Clases.Funciones();
        bool Guardar = true;
        int IDProveedor;
        private void CargarGrid()
        {
            fn.ActualizarGrid(dgProveedor, "select top(20) IDProveedor as Codigo,td.Descripcion as TipoDocumento,p.Numero,p.RazonSocial,p.Telefono,p.Direccion,p.Contacto from  proveedor p left join TipoDocumento td on p.IDTipoDocumento = td.IDTipoDocumento where p.Numero like '" + txtBuscarRUC.Text + "%' ORDER BY IDProveedor desc");
        }
        private void Limpiar()
        {
            txtcontacto.Clear();
            txtdireccion.Clear();
            txtidentificacion.Clear();
            txtrazonsocial.Clear();
            txttelefono.Clear();
            error.Clear();
        }
        private bool Validar()
        {
            bool f = false;
            if (txtidentificacion.Text == "")
            {
                error.SetError(txtidentificacion, "Ingrese el número de RUC del proveedor");
                return f;
            }
            error.Clear();
            if (txtrazonsocial.Text == "")
            {
                error.SetError(txtrazonsocial, "Ingrese la razón social");
                return f;
            }
            error.Clear();
            return true;
        }
        private void _enable(bool b)
        {
            gbxInformacion.Enabled = b;

            btnNuevo.Enabled = !b;
            btnGuardar.Enabled = b;
            btnCancelar.Enabled = b;
        }
        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Descripcion", "IDTipoDocumento", "TipoDocumento", cboTipoDocumento);


            CargarGrid();

            Guardar = true;

            _enable(false);
            btnNuevo.Select();
        }
        private string Grid(string i)
        {
            string valor;
            return valor = dgProveedor.CurrentRow.Cells[i].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //VALIDACION
            if (validationSave() == false)
            {
                return;
            }

            //GUARDAMOS
            save();

            //FIN DEL GUARDAR
            endSave();

        }

        private void endSave()
        {
            Limpiar();
            CargarGrid();
            _enable(false);
            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool validationSave()
        {
            if (cboTipoDocumento.SelectedValue == null)
            {
                MessageBox.Show("Seleccione Tipo de Documento", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Guardar == true)
            {
                if (fn.Existencia("*", "Proveedor", "Numero='" + txtidentificacion.Text + "'") == true)
                {
                    MessageBox.Show("El Proveedor con el numero de identificación '" + txtidentificacion.Text + "' YA SE ENCUENTRA REGISTRADO", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void save()
        {
            if (Guardar)
            {
                fn.RegistrarOficial("Proveedor", "IDTipoDocumento,Numero,RazonSocial,Telefono,Direccion,Contacto",
                    "'" + cboTipoDocumento.SelectedValue + "','" + txtidentificacion.Text + "','" + txtrazonsocial.Text + "','" + txttelefono.Text + "','" + txtdireccion.Text + "','" + txtcontacto.Text + "'");
            }
            else
            {
                fn.Modificar("Proveedor", "Numero='" + txtidentificacion.Text + "',RazonSocial='" + txtrazonsocial.Text + "',Telefono='" + txttelefono.Text + "',Direccion='" + txtdireccion.Text + "',Contacto='" + txtcontacto.Text + "',IDTipoDocumento='" + cboTipoDocumento.SelectedValue + "'", "IDProveedor='" + IDProveedor + "'");
            }
        }

        private void eGuardar()
        {

        }

        private bool Filas()
        {
            if (dgProveedor.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Filas() != true) { return; }
            fn.Eliminar("Proveedor", "IDProveedor='" + dgProveedor.CurrentRow.Cells["IDProveedor"].Value.ToString() + "'");
            CargarGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Guardar = true;
            _enable(true);
            gbxInformacion.Enabled = true;
            txtidentificacion.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Guardar = true;
            _enable(false);
        }

        private void txtidentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txttelefono.Focus();
            }
        }

        private void txttelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtrazonsocial.Focus();
            }
        }

        private void txtrazonsocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcontacto.Focus();
            }
        }

        private void txtcontacto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtdireccion.Focus();
            }
        }

        private void txtdireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                eGuardar();
            }
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Filas() != true) { return; }

                if(Grid("Numero") == "0")
                {
                    MessageBox.Show("Por Seguridad no se Debe Editar el Proveedor Varios", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                IDProveedor = Convert.ToInt32(Grid("Codigo"));
                cboTipoDocumento.Text = Grid("TipoDocumento");
                txtidentificacion.Text = Grid("Numero");
                txtrazonsocial.Text = Grid("RazonSocial");
                txttelefono.Text = Grid("Telefono");
                txtdireccion.Text = Grid("Direccion");
                txtcontacto.Text = Grid("Contacto");

                Guardar = false;
                _enable(true);
                gbxInformacion.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Editar: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txtBuscarRUC_TextChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void eLIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fn.Delete("Proveedor","IDProveedor='"+ Grid("Codigo") + "'",true);
            CargarGrid();
        }
    }
}
