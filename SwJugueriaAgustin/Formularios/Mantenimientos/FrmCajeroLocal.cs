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

namespace SwJugueriaAgustin.Formularios.Mantenimientos
{
    public partial class FrmCajeroLocal : Form
    {
        Funciones fn = new Funciones();
        public string IDCajero;
        public FrmCajeroLocal()
        {
            InitializeComponent();
        }

        private void FrmCajeroLocal_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("Sucursal","IDSucursal", "Sucursal",cboSucursal);
            mostrarDatos();
        }

        private void mostrarDatos()
        {
            try
            {
                fn.ActualizarGrid(dgvDatos, "select s.IDsucursal,s.Sucursal,c.Nombres from CajeraSucursal cs inner join Sucursal s on cs.IDSucursal = s.IDSucursal inner join Cajera c on cs.IDCajera = c.IDCajera where c.IDCajera = '" + IDCajero + "'");
                dgvDatos.Columns["IDSucursal"].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(cboSucursal.Text))
                {
                    MessageBox.Show("Sucursal Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                fn.RegistrarOficial("CajeraSucursal", "IDCajera,IDSucursal", "'" + IDCajero + "','" + cboSucursal.SelectedValue + "'");
                limpiar();
                mostrarDatos();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void limpiar()
        {
            cboSucursal.Text = "";
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idSucursal = dgvDatos.CurrentRow.Cells["IDSucursal"].Value.ToString();
            fn.Delete("CajeraSucursal","IDCajera='"+IDCajero+"' and IDSucursal = '"+idSucursal+"'",true);
            mostrarDatos();
        }
    }
}
