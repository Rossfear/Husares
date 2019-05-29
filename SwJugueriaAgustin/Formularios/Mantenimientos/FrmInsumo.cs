using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Mantenimiento
{
    public partial class FrmInsumo : Form
    {
        bool editar;
        string idInsumo;
        Clases.Mantenimiento mn = new Clases.Mantenimiento();
        Funciones fn = new Funciones();
        public FrmInsumo()
        {
            InitializeComponent();
        }

        private void FrmInsumo_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("UniMedida", "IDUniMedida", "UnidadMedida", cbxUniMedida);
            mostrarGrdi();
            mn.Bloquear(gbxInsumo,btnGuardar, btnNuevo, btnNuevo, btnNuevo,btnCancelar);
        }

        private void mostrarGrdi()
        {
            fn.ActualizarGrid(dgvInsumo, "select i.IDInsumo,i.Insumo,u.UniMedida,i.Costo  from Insumo i left join UnidadMedida u on i.IDUniMedida = u.IDUniMedida where i.Insumo like '%" + txtBuscar.Text + "%' order by i.IDInsumo desc");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            mn.Desbloquear(gbxInsumo, btnGuardar, btnNuevo, btnNuevo, btnNuevo, btnCancelar);
            editar = false;
            txtInsumo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validacionGuardar() == false)
            {
                return;
            }

            mn.Guardar(editar, "Insumo", "Insumo,IDUniMedida,Costo", "'" + txtInsumo.Text + "','" + cbxUniMedida.SelectedValue + "','" + txtCosto.Text + "'","Insumo='"+txtInsumo.Text+"',IDUniMedida='"+cbxUniMedida.SelectedValue+"',Costo='"+txtCosto.Text+"'","IDInsumo='"+idInsumo+"'");
            mostrarGrdi();
            editar = false;
            limpiar();
            mn.Bloquear(gbxInsumo, btnGuardar, btnNuevo, btnNuevo, btnNuevo, btnCancelar);
        }

        private void limpiar()
        {
            txtInsumo.Text = "";
            txtCosto.Text = "0";
         
        }

        private bool validacionGuardar()
        {
            
            if(editar == false)
            {
                if (fn.Existencia("*", "Insumo", "Insumo='" + txtInsumo.Text + "'") == true)
                {
                    MessageBox.Show("Insumo Ya Existe", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            
            try
            {
                if(Convert.ToDecimal(txtCosto.Text) < 0)
                {
                    MessageBox.Show("Costo Incorrecto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Costo Incorrecto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mn.Bloquear(gbxInsumo, btnGuardar, btnNuevo, btnNuevo, btnNuevo, btnCancelar);
            editar = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarGrdi();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idInsumo = dgvInsumo.CurrentRow.Cells["IDInsumo"].Value.ToString();
            txtInsumo.Text = dgvInsumo.CurrentRow.Cells["Insumo"].Value.ToString();
            cbxUniMedida.Text = dgvInsumo.CurrentRow.Cells["UniMedida"].Value.ToString();
            txtCosto.Text = dgvInsumo.CurrentRow.Cells["Costo"].Value.ToString();
            editar = true;
            mn.Desbloquear(gbxInsumo, btnGuardar, btnNuevo, btnNuevo, btnNuevo, btnCancelar);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar el insumo Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (msj == DialogResult.OK)
            {
                string idInsumo = dgvInsumo.CurrentRow.Cells["IDInsumo"].Value.ToString();

                SqlDataReader lector = fn.selectMultiValues("select * from StockAlmacen where IDInsumo = '"+idInsumo+"'");
                while(lector.Read())
                {
                    string idStockAlmacen = lector["IDStockAlmacen"].ToString();
                    fn.Eliminar("Receta","IDStockAlmacen='"+idStockAlmacen+"'");
                }
                lector.Close();


                fn.Eliminar("StockAlmacen", "IDInsumo='" + idInsumo + "'");
                fn.Eliminar("Insumo", "IDInsumo='" + idInsumo + "'");
                mostrarGrdi();
                MessageBox.Show("Dato Eliminado");
            }
        }
    }
}
