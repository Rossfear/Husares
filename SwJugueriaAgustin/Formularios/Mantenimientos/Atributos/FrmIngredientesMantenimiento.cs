using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SwJugueriaAgustin.Clases;

namespace SwJugueriaAgustin.Formularios
{
    public partial class FrmIngredientesMantenimiento : Form
    {
        Funciones ManipularDatos = new Funciones();
        Clases.Funciones fn = new Clases.Funciones();
        bool QuiereGuardar;
        string IDCategoria;
        public FrmIngredientesMantenimiento()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Bloquear(false);
            txtCategoria.Focus();
        }


        private void Bloquear(bool i)
        {
            txtCategoria.Enabled = !i;
            btnNuevo.Enabled = i;
            btnGuardar.Enabled = !i;
            btnModificar.Enabled = i;
            BtnEliminar.Enabled = i;
            btnCancelar.Enabled = !i;
            btnNuevo.Select();
        }

        private void FrmIngredientesMantenimiento_Load(object sender, EventArgs e)
        {
            Bloquear(true);
            QuiereGuardar = true;
            MostrarDatosGrid();
            mostrarCategoria();
        }

        private void mostrarCategoria()
        {
            fn.añadir_ddl("Categoria", "IDCategoria", "Categoria", cbxCategoria);
        }
        private void MostrarDatosGrid()
        {
            fn.MostrarGri("IDCondimento as [ID],Condimento,Categoria", "Condimento co,Categoria ca", "co.IDCategoria = ca.IDCategoria and ca.Categoria = '" + cbxCategoria.Text + "'", dgvIngredientes, "Condimento");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EGuardar();
        }
        private void EGuardar()
        {
            try
            {
                if (fn.Existencia("*", "Condimento", "Condimento='" + txtCategoria.Text.TrimEnd() + "'") == true)
                {
                    MessageBox.Show("EL Condimento ya se encuentra Registrada", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCategoria.Text == "")
                {
                    MessageBox.Show("Ingrese el Insumo", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCategoria.Focus(); return;
                }
                if (QuiereGuardar == true)
                {
                    fn.Registrar("Condimento", "'" + txtCategoria.Text.TrimEnd() + "','"+cbxCategoria.SelectedValue+"'");
                }
                else
                {
                    fn.Modificar("CondimEnto", "Condimento='" + txtCategoria.Text.TrimEnd() + "',IDCategoria='"+cbxCategoria.SelectedValue+"'", "IDCondimento='" + IDCategoria + "'");
                }
                Bloquear(true);
                txtCategoria.Clear();
                MostrarDatosGrid();
                QuiereGuardar = true;
            }
            catch
            {

            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Bloquear(true);
            txtCategoria.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bloquear(false);
            txtCategoria.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EGuardar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvIngredientes.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos", ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bloquear(false);
            txtCategoria.Focus();
            QuiereGuardar = false;
            IDCategoria = dgvIngredientes.CurrentRow.Cells["ID"].Value.ToString();
            txtCategoria.Text = dgvIngredientes.CurrentRow.Cells["Condimento"].Value.ToString();
            cbxCategoria.Text = dgvIngredientes.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bloquear(true);
            txtCategoria.Clear();
        }

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            fn.MostrarGri("IDCondimento as [ID],Condimento,Categoria", "Condimento co,Categoria ca", "co.IDCategoria = ca.IDCategoria and ca.Categoria = '"+cbxCategoria.Text+"'", dgvIngredientes, "Condimento");


        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string cod_elimina;
            cod_elimina = this.dgvIngredientes.CurrentRow.Cells[0].Value.ToString();
            var resultado = MessageBox.Show("¿Desear realmente eliminar este Ingrediente?", "Confirme el borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {

                ManipularDatos.Conectar();
                String Query = "delete from Condimento where IDCondimento = '" + cod_elimina + "';";
                ManipularDatos.EjecutarSql(Query);

               
                ManipularDatos.Desconectar();
                fn.MostrarGri("IDCondimento as [ID],Condimento,Categoria", "Condimento co,Categoria ca", "co.IDCategoria = ca.IDCategoria and ca.Categoria = '" + cbxCategoria.Text + "'", dgvIngredientes, "Condimento");

            }
            else


                return;
        }
    }
}
