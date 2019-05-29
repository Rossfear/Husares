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

namespace SwJugueriaAgustin.Formularios.Administracion
{
    public partial class FrmEgresoAdministracion : Form
    {
        bool update;
        string ID;
        Funciones fn = new Funciones();
        public FrmEgresoAdministracion()
        {
            InitializeComponent();

            KeyPreview = true;

            KeyDown += FrmTipoComprobante_KeyDown;
        }

        private void FrmTipoComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                enable(false);
                clean();
            }
        }

        private void FrmTipoComprobante_Load(object sender, EventArgs e)
        {
            //fn.añadir_ddl("TipoEgreso", "IDTipoEgreso", "TipoEgreso", cbxTipoEgreso);
            enable(false);
            showData();
        }

        private void showData()
        {
            //fn.ActualizarGrid(dgvDocumento, "select e.IDEgreso,te.TipoEgreso,e.Fecha,e.Motivo,e.Monto,e.Dirigido,u.Usuario from Egreso e left join TipoEgreso te on e.IDTipoEgreso = te.IDTipoEgreso left join Usuario u on e.IDUsuario = u.IDUsuario where e.Fecha = '"+dtpFechaBusqueda.Value.ToShortDateString()+"' order by e.IDEgreso desc");
            //dgvDocumento.Columns["IDEgreso"].Visible = false;


            //lblEgresos.Text = fn.selectValue("select sum(monto) from Egreso e where e.Fecha = '" + dtpFechaBusqueda.Value.ToShortDateString() + "'");

        }

        void enable(bool state)
        {
            gbxDatos.Enabled = state;
            btnGuardar.Enabled = state;
            //btnNuevo.Enabled = !state;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            enable(true);
            dtpFecha.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            eGuardar();


        }

        private void eGuardar()
        {
            if (validationSave() == false)
            {
                return;
            }

            save();

            endSave();
        }

        private void endSave()
        {
            clean();
            showData();
            MessageBox.Show("Operacion Correcta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clean()
        {
        //    cbxTipoEgreso.Text = "";
        //    txtMotivo.Text = "";
        //    txtDirigido.Text = "";
            txtMonto.Text = "0";
        }

        private void save()
        {
            try
            {
                if (update == true)
                {
                    //fn.Modificar("Egreso", "Fecha='"+dtpFecha.Value.ToShortDateString()+ "',IDTipoEgreso='" + cbxTipoEgreso.SelectedValue+ "',Motivo='" + txtMotivo.Text.Trim() + "',Dirigido='"+txtDirigido.Text+ "',Monto='"+txtMonto.Text+"',IDUsuario='"+Datos.idUsuario+"'", "IDEgreso='"+ID+"'");
                }
                else
                {
                    //fn.RegistrarOficial("Egreso", "Fecha,IDTipoEgreso,Motivo,Dirigido,Monto,IDUsuario",
                    //    "'" + dtpFecha.Value.ToShortDateString()+ "','"+cbxTipoEgreso.SelectedValue+"','"+txtMotivo.Text.Trim()+"','"+txtDirigido.Text+"','"+txtMonto.Text+"','"+Datos.idUsuario+"'");
                }

                update = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guardar: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private bool validationSave()
        {
            if (string.IsNullOrWhiteSpace(txtMotivo.Text) == true)
            {
                MessageBox.Show("Especificar Motivo de Egreso", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return false;
            }

            //if(cbxTipoEgreso.SelectedValue == null)
            //{
            //    MessageBox.Show("Tipo de Egreso No Existente", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtMotivo.Focus();
            //    return false;
            //}

            try
            {
                if(Convert.ToDouble(txtMonto.Text) < 0)
                {
                    MessageBox.Show("Monto Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMonto.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Monto Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return false;
            }




            DialogResult msj;

            if (update == true)
            {
                msj = MessageBox.Show("Desea Actualizar los datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                msj = MessageBox.Show("Desea Registrar los datos", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            if (msj == DialogResult.Cancel)
            {
                return false;
            }


            return true;
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dtpFecha.Value = Convert.ToDateTime(dgvDocumento.CurrentRow.Cells["Fecha"].Value);
                //cbxTipoEgreso.Text = dgvDocumento.CurrentRow.Cells["TipoEgreso"].Value.ToString();
                //txtMotivo.Text = dgvDocumento.CurrentRow.Cells["Motivo"].Value.ToString();
                //txtDirigido.Text = dgvDocumento.CurrentRow.Cells["Dirigido"].Value.ToString();
                txtMonto.Text = dgvDocumento.CurrentRow.Cells["Monto"].Value.ToString();
                ID = dgvDocumento.CurrentRow.Cells["IDEgreso"].Value.ToString();

                update = true;
                
                enable(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            showData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            update = false;
            enable(false);
            clean();
        }

        private void dtpFechaBusqueda_ValueChanged(object sender, EventArgs e)
        {
            showData();
        }

        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) SendKeys.Send("{TAB}") ;
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                eGuardar();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);

            if(msj == DialogResult.OK)
            {
                FrmContraseña frm = new FrmContraseña();
                frm.ShowDialog();

                if(frm.cancel == false)
                {
                    fn.Eliminar("Egreso", "IDEgreso='"+dgvDocumento.CurrentRow.Cells["IDEgreso"].Value.ToString()+"'");
                }
                MessageBox.Show("Dato Eliminado","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Information);
                showData();
            }
            
        }

        private void dtpFechaBusqueda_ValueChanged_1(object sender, EventArgs e)
        {
            showData();
        }

        private void txtAño_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //VRIFICAMOS SI EL REGISTRO ESPECIFICADO EXISTE
                    bool existe = fn.Existencia("*", "RegistroAdministracion", "MES='" + cbxMes.Text + "' AND AÑO='" + txtAño.Text + "'");

                    //SI EXISTE MOSTRAMOS EL DATAGRID ELSE -> REGISTRARLO
                    if (existe == true)
                    {
                        lblMes.Text = cbxMes.Text;
                        lblAño.Text = txtAño.Text;

                        //MOSTRAMOS EL DATADRIG
                        string codRegistro = fn.select_one_value("IDRegistroCompraLogistica", "RegistroCompraLogistica", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
                        //MostrarGrid(codRegistro);
                        //btnAddCompra.Select();
                    }
                    else
                    {
                        //PREGUNTAMOS SI DESEA REGISTRAR 
                        var msj = MessageBox.Show("El Registro de Compra especificado no se encuentra registrada. Desea Registrarlo?", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (msj == DialogResult.OK)
                        {
                            //REGISTRA
                            fn.Registrar("RegistroCompraLogistica", "'" + cbxMes.Text + "','" + txtAño.Text + "'");

                            lblMes.Text = cbxMes.Text;
                            lblAño.Text = txtAño.Text;

                            //MUESTRA GRID
                            string codRegistro = fn.select_one_value("IDRegistroCompraLogistica", "RegistroCompraLogistica", "MES='" + lblMes.Text + "' AND AÑO='" + lblAño.Text + "'", 0);
                            //MostrarGrid(codRegistro);
                            //btnAddCompra.Select();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
