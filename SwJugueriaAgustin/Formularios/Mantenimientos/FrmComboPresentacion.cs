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

namespace SwJugueriaAgustin.Formularios.Mantenimientos
{
    public partial class FrmComboPresentacion : Form
    {
        Funciones fn = new Funciones();
        frmAddCantidad frm = new frmAddCantidad();
        public string idSucursal;
        public FrmComboPresentacion()
        {
            InitializeComponent();
        }

        public string IDPresentacionCombo { get; set; }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmComboPresentacion_Load(object sender, EventArgs e)
        {
            mostrarPresentaciones();

            mostrarPresentacionesCombo();

        }

        private void mostrarPresentacionesCombo()
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = fn.procedimientoAlmacenado("spListarPresentacionCombo");
            cmd.Parameters.AddWithValue("@idPresentacion", IDPresentacionCombo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dgvListaCombo.DataSource = dt;


        }

        private void mostrarPresentaciones()
        {
            DataTable dt = new DataTable();
            dgvPresentaciones.DataSource = null;
            SqlCommand cmd = fn.procedimientoAlmacenado("spListarPresentacion");
            cmd.Parameters.AddWithValue("@IDSucursal",idSucursal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dgvPresentaciones.DataSource = dt;

            dgvPresentaciones.Columns["IDPresentacion"].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            fn.Eliminar("PresentacionCombo", "IDPresentacionCombo='" + IDPresentacionCombo + "'");

            foreach (DataGridViewRow row in dgvListaCombo.Rows)
            {
                string idPresentacion = row.Cells["cnIDPresentacion"].Value.ToString();
                string cantidad = row.Cells["cnCantidad"].Value.ToString();

                fn.RegistrarOficial("PresentacionCombo", "IDPresentacionCombo,IDPresentacion,Cantidad",
                    "'" + IDPresentacionCombo + "','" + idPresentacion + "','" + cantidad + "'");
            }

            MessageBox.Show("Datos Registrados", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvPresentaciones.CurrentCell = null;

            foreach (DataGridViewRow row in dgvPresentaciones.Rows)
            {
                if (row.Cells["Presentacion"].Value.ToString().ToUpper().Contains(txtBuscar.Text.ToUpper()))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void dgvPresentaciones_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frm.txtCantidad.Text = "";
                    frm.ShowDialog();

                    if (frm.Cancelado == false)
                    {
                        string idPresentacion = dgvPresentaciones.CurrentRow.Cells["IDPresentacion"].Value.ToString();
                        string Presentacion = dgvPresentaciones.CurrentRow.Cells["Presentacion"].Value.ToString();

                        DataTable dt = dgvListaCombo.DataSource as DataTable;
                        DataRow fila = dt.NewRow();
                        fila["IDPresentacion"] = idPresentacion;
                        fila["Presentacion"] = Presentacion;
                        fila["cantidad"] = frm.txtCantidad.Text;

                        dt.Rows.Add(fila);

                        dgvListaCombo.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void quitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvListaCombo.Rows.Remove(dgvListaCombo.CurrentRow);
        }
    }
}
