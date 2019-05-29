using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using SwJugueriaAgustin.Clases;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class FrmAlmacen : Form
    {
        public FrmAlmacen()
        {
            InitializeComponent();
        }

        Boolean Editar;
        Funciones fn = new Funciones();
        String Codigo = "";
        String fecha;


        public static string conex = Funciones.preconex;
        SqlConnection cn = new SqlConnection(conex);

        private void frmTienda_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal", "IDSucursal", "Sucursal",cboSucursal);
            this.Activar();
            this.Bloquear();
            txtAlmacen.Focus();
            showGrid();
        }

        private void showGrid()
        {
            fn.ActualizarGrid(this.dataGridView1, "select a.IDAlmacen as Codigo,a.Almacen,a.PermiteEntrada,a.PermiteVender,s.Sucursal from almacen a left join Sucursal s on a.IDSucursal = s.IDSucursal where Almacen like '%" + txtBuscar.Text+"%' order by IDAlmacen desc");
        }

        public void Bloquear()
        {
            gbxDatos.Enabled = false;
            txtAlmacen.Enabled = false;

        }

        public void Desbloquear()
        {
            gbxDatos.Enabled = true;
            txtAlmacen.Enabled = true;
        }
        public void Activar()
        {
            BtnNuevo.Enabled = true;
            BtnGuardar.Enabled = false;
            
            
            BtnCancelar.Enabled = false;

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Editar = false;
            this.Limpiar();

            this.Desactivar();
            this.Desbloquear();

            //  txt_activo.Focus();
            txtAlmacen.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string permiteEntrada,permitevender;

            if(chbxPermiteIngreso.Checked == true)
            {
                permiteEntrada = "True";
            }
            else
            {
                permiteEntrada = "False";
            }


            if (chbxPuedeVender.Checked == true)
            {
                permitevender = "True";
            }
            else
            {
                permitevender = "False";
            }


            if (Editar)
            {

                fn.Conectar();
                String Query = "update ALMACEN set almacen = '" + txtAlmacen.Text + "',PermiteEntrada='"+permiteEntrada+"',PermiteVender='"+permitevender+"',IDSucursal='"+cboSucursal.SelectedValue+"' where idalmacen = '" + Codigo + "';";
                fn.EjecutarSql(Query);

                Editar = false;
            }

            else
            {
                
                fn.Conectar();
                String Query = "insert into ALMACEN (ALMACEN,PERMITEENTRADA,PERMITEVENDER,IDSucursal)values( '" + txtAlmacen.Text + "','"+permiteEntrada+"','"+permitevender+"','"+cboSucursal.SelectedValue+"');";
                fn.EjecutarSql(Query);

                
            }

            this.Limpiar();
            this.Activar();
            this.Bloquear();
            showGrid();
        }
        public void Limpiar()
        {

            chbxPermiteIngreso.Checked = false;
            chbxPuedeVender.Checked = false;
            txtAlmacen.Text = "";

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            
        }
        public void Desactivar()
        {
            BtnNuevo.Enabled = false;
            BtnGuardar.Enabled = true;
            BtnCancelar.Enabled = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Editar = false;
            this.Limpiar();
            this.Activar();
            this.Bloquear();
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Desactivar();
                this.Desbloquear();

                Editar = true;
                Codigo = this.dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                txtAlmacen.Text = this.dataGridView1.CurrentRow.Cells["Almacen"].Value.ToString();
                chbxPermiteIngreso.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["PermiteEntrada"].Value.ToString());
                chbxPuedeVender.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["PermiteVender"].Value.ToString());
                cboSucursal.Text = this.dataGridView1.CurrentRow.Cells["Sucursal"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            showGrid();
        }
    }
}
