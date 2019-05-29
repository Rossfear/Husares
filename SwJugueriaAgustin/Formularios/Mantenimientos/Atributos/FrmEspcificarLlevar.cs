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

namespace SwJugueriaAgustin.Formularios.Mantenimientos.Atributos
{
    public partial class FrmEspcificarLlevar : Form
    {
        public string idPresentacion;
        public string idProducto;
        Funciones fn = new Funciones();
        bool existencia = false;

        public FrmEspcificarLlevar()
        {
            InitializeComponent();
        }

        private void FrmEspcificarLlevar_Load(object sender, EventArgs e)
        {
            fn.añadir_ddl("Presentacion","IDPresentacion","Presentacion where IDProducto = '"+idProducto+"' and Habilitado='False'",cbxPresentacion);
            cbxPresentacion.SelectedIndex = -1;

            if(fn.Existencia("*", "PresentacionLlevar","IDPresentacion='"+idPresentacion+"'") == true)
            {
                SqlDataReader lector = fn.selectMultiValues("select p.IDPresentacion,p.Presentacion from PresentacionLlevar pl inner join Presentacion p on pl.IDPresentacionLlevar = p.IDPresentacion where pl.IDPresentacion = '"+idPresentacion+"'");
                lector.Read();
                lblPresentacionLlevar.Tag = lector["IDPresentacion"].ToString();
                lblPresentacionLlevar.Text = lector["Presentacion"].ToString();
                lector.Close();
                existencia = true;
            }
            else
            {
                existencia = false;
            }
        }

        private void cbxPresentacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblPresentacionLlevar.Text = cbxPresentacion.Text;
            lblPresentacionLlevar.Tag = cbxPresentacion.SelectedValue;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validacionGuardar() == false)
            {
                return;
            }

            save();
        }

        private void save()
        {
            if(existencia == true)
            {
                fn.Modificar("PresentacionLlevar", "IDPresentacionLlevar='" + lblPresentacionLlevar.Tag + "'", "IDPresentacion='" + idPresentacion + "'");
            }
            else
            {
                fn.RegistrarOficial("PresentacionLlevar", "IDPresentacion,IDPresentacionLlevar", "'" + idPresentacion + "','" + lblPresentacionLlevar.Tag + "'");
            }

            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private bool validacionGuardar()
        {
            if (string.IsNullOrEmpty(lblPresentacionLlevar.Text) == true)
            {
                MessageBox.Show("Especificar Presentacion", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(existencia == true)
            {
                DialogResult msj = MessageBox.Show("Desea Editar los Datos?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                
                if(msj == DialogResult.Cancel)
                {
                    return false;
                }
            }
            else
            {
                DialogResult msj = MessageBox.Show("Desea Registrar los Datos?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msj == DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
