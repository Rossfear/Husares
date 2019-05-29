using Microsoft.Office.Interop.Excel;
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

namespace SwJugueriaAgustin.Formularios.AdministracionReporte
{
    public partial class FrmRMovimientoBancario : Form
    {
        Funciones fn = new Funciones();
        public FrmRMovimientoBancario()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(chbxPorMes.Checked == true)
            {
                labelSaldo.Visible = true; labelSaldoIni.Visible = true;
                txtSaldoInicial.Visible = true; txtSaldo.Visible = true;

                //TIPO DE OPERACION *************************************
                SqlCommand cmd = fn.procedimientoAlmacenado("SP_RMovimientoBancarioMes");
                cmd.Parameters.AddWithValue("@mes",(cbxMes.SelectedIndex + 1));
                cmd.Parameters.AddWithValue("@año", txtAño.Text);

                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvTipoOperaciones.DataSource = dt;
                //********************************************************


                //PROVEEDOR
                SqlCommand cmdPr = fn.procedimientoAlmacenado("sp_RMovimientoBancarioPRMes");
                cmdPr.Parameters.AddWithValue("@mes", (cbxMes.SelectedIndex + 1));
                cmdPr.Parameters.AddWithValue("@año", txtAño.Text);

                System.Data.DataTable dtPr = new System.Data.DataTable();
                SqlDataAdapter daPr = new SqlDataAdapter(cmdPr);
                daPr.Fill(dtPr);
                dgvProveedores.DataSource = dtPr;
                //********************************************************

                txtSaldoInicial.Text = fn.remplazarNulo(fn.selectValue("select SaldoInicial from RegistroBancario where Mes='"+cbxMes.Text+"' and Año='"+txtAño.Text+"'"));
                
            }
            else
            {
                labelSaldo.Visible = false;labelSaldoIni.Visible = false;
                txtSaldoInicial.Visible = false;txtSaldo.Visible = false;

                //TIPO DE OPERACION *************************************
                SqlCommand cmdFecha = fn.procedimientoAlmacenado("sp_RMovimientoBancarioFecha");
                cmdFecha.Parameters.AddWithValue("@fechaInicio", dtpInicio.Value.ToShortDateString());
                cmdFecha.Parameters.AddWithValue("@fechaFin", dtpFin.Value.ToShortDateString());

                System.Data.DataTable dtFecha = new System.Data.DataTable();
                SqlDataAdapter daFecha = new SqlDataAdapter(cmdFecha);
                daFecha.Fill(dtFecha);
                dgvTipoOperaciones.DataSource = dtFecha;
                //********************************************************


                //PROVEEDOR
                SqlCommand cmdPr = fn.procedimientoAlmacenado("sp_RMovimientoBancarioPRFecha");
                cmdPr.Parameters.AddWithValue("@fechaInicio", dtpInicio.Value.ToShortDateString());
                cmdPr.Parameters.AddWithValue("@fechaFin", dtpFin.Value.ToShortDateString());

                System.Data.DataTable dtPr = new System.Data.DataTable();
                SqlDataAdapter daPr = new SqlDataAdapter(cmdPr);
                daPr.Fill(dtPr);
                dgvProveedores.DataSource = dtPr;
                //********************************************************
            }

            decimal abonoTO = 0,cargoTO=0;
            foreach(DataGridViewRow rowTipo in dgvTipoOperaciones.Rows)
            {
                abonoTO = abonoTO + Convert.ToDecimal(rowTipo.Cells["Abono"].Value);
                cargoTO = cargoTO + Convert.ToDecimal(rowTipo.Cells["Cargo"].Value);
            }
            txtAbonoTO.Text = abonoTO.ToString("#,#.00");
            txtCargoTO.Text = cargoTO.ToString("#,#.00");


            decimal abonoPR = 0, cargoPR = 0;
            foreach (DataGridViewRow rowProveedor in dgvProveedores.Rows)
            {
                abonoPR = abonoPR + Convert.ToDecimal(rowProveedor.Cells["Abono"].Value);
                cargoPR = cargoPR + Convert.ToDecimal(rowProveedor.Cells["Cargo"].Value);
            }
            txtAbonoPR.Text = abonoPR.ToString("#,#.00");
            txtCargoPR.Text = cargoPR.ToString("#,#.00");

            txtAbonoTotal.Text = (abonoPR + abonoTO).ToString("#,#.00");
            txtCargoTotal.Text = (cargoTO + cargoPR).ToString("#,#.00");

            decimal saldoInicial = Convert.ToDecimal(txtSaldoInicial.Text);

            txtSaldo.Text = (saldoInicial + (abonoPR + abonoTO) - (cargoPR + cargoTO)).ToString("#,#.00");
            
        }

        private void chbxPorMes_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxPorMes.Checked == true)
            {
                cbxMes.Visible = true;
                txtAño.Visible = true;
                labelAño.Visible = true;
                dtpFin.Visible = false;
                dtpInicio.Visible = false;

            }
            else
            {
                cbxMes.Visible = false;
                txtAño.Visible = false;
                labelAño.Visible = false;
                dtpFin.Visible = true;
                dtpInicio.Visible = true;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportaraexcelTimer();
        }

        public void exportaraexcelTimer()
        {
            int filasTotales = dgvProveedores.Rows.Count;

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;
            //CABECERA TIPO OPERACION
            foreach (DataGridViewColumn col in dgvTipoOperaciones.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }

            //CUERPO   OPERACION
            int rowIndex = 0;
            foreach (DataGridViewRow row in dgvTipoOperaciones.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in dgvTipoOperaciones.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }
            }

            excel.Cells[rowIndex + 3, 1] = "TOTAL";
            excel.Cells[rowIndex + 3, 3] = txtAbonoTO.Text;
            excel.Cells[rowIndex + 3, 4] = txtCargoTO.Text;

            //***********************************************************************

            int ColumnIndexPR = 7;
            //CABECERA TIPO OPERACION
            foreach (DataGridViewColumn col in dgvProveedores.Columns)
            {
                ColumnIndexPR++;
                excel.Cells[1, ColumnIndexPR] = col.Name;
            }

            //CUERPO TIPO PROVEEDOR
            int rowIndexPR = 0;
            foreach (DataGridViewRow row in dgvProveedores.Rows)
            {
                rowIndexPR++;
                ColumnIndexPR = 7;
                foreach (DataGridViewColumn col in dgvProveedores.Columns)
                {
                    ColumnIndexPR++;
                    excel.Cells[rowIndexPR + 1, ColumnIndexPR] = row.Cells[col.Name].Value;
                }
            }

            excel.Cells[rowIndexPR + 3, 8] = "TOTAL";
            excel.Cells[rowIndexPR + 3, 9] = txtAbonoPR.Text;
            excel.Cells[rowIndexPR + 3, 10] = txtCargoPR.Text;

            if (txtSaldoInicial.Visible == true)
            {
                excel.Cells[1, 13] = "SALDO INICIAL:";
                excel.Cells[1, 14] = txtSaldoInicial.Text;
            }
            

            excel.Cells[2, 13] = "ABONO TOTAL:";
            excel.Cells[2, 14] = txtAbonoTotal.Text;

            excel.Cells[3, 13] = "CARGO TOTAL:";
            excel.Cells[3, 14] = txtCargoTotal.Text;

            if (txtSaldo.Visible == true)
            {
                excel.Cells[4, 13] = "SALDO :";
                excel.Cells[4, 14] = txtSaldo.Text;
            }



            excel.Visible = true;
            Worksheet worksheet = (Worksheet)excel.ActiveSheet;
            worksheet.Activate();
            MessageBox.Show("Exportación Exitosa", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }
    }
}
