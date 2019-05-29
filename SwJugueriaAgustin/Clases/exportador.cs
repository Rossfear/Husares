using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace SwJugueriaAgustin.Clases
{
    public class exportador
    {
        public void exportaraexcel(DataGridView tabla)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            int ColumnIndex = 0;
            foreach (DataGridViewColumn col in tabla.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }
            int rowIndex = 0;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }

                
            }
            excel.Visible = true;
            Worksheet worksheet = (Worksheet)excel.ActiveSheet;
            worksheet.Activate();
            MessageBox.Show("Exportación Exitosa", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        public void exportaraexcelTimer(DataGridView tabla, ProgressBar progress)
        {
            int filasTotales = tabla.Rows.Count;

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            int ColumnIndex = 0;
            foreach (DataGridViewColumn col in tabla.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }
            int rowIndex = 0;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }

                progress.Value = (rowIndex * 100) / filasTotales;
            }
            excel.Visible = true;
            Worksheet worksheet = (Worksheet)excel.ActiveSheet;
            worksheet.Activate();
            MessageBox.Show("Exportación Exitosa", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progress.Value = 0;

        }

        public void ExportExcelTimer(DataGridView grd, string nombreGuardar,int indiceFecha, ProgressBar progessbar,string titulo)
        {
            //try
            //{

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = nombreGuardar;
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;

                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                    //ENCABELZADO
                    hoja_trabajo.Cells[1, 1] = titulo;
                    //********************

                    ////MENU EMCABEZADO
                    int ColumnIndex = 0;
                    foreach (DataGridViewColumn col in grd.Columns)
                    {
                        ColumnIndex++;
                        hoja_trabajo.Cells[2, ColumnIndex] = col.Name;
                    }

                    for (int f = 2; f < grd.Rows.Count + 2; f++)
                    {

                        for (int c = 0; c < grd.Columns.Count; c++)
                        {
                            if (c == indiceFecha)
                            {
                                DateTime fecha = Convert.ToDateTime(grd.Rows[f - 2].Cells[indiceFecha].Value.ToString());
                                hoja_trabajo.Cells[f + 1, c + 1] = fecha;
                            }
                            else
                            {
                                hoja_trabajo.Cells[f + 1, c + 1] = grd.Rows[f - 2].Cells[c].Value;
                            }
                            
                        }

                        progessbar.Value = (f * 100) / (grd.Rows.Count + 1);
                    }


                    hoja_trabajo.Columns.AutoFit();
                    hoja_trabajo.Range["A1"].EntireRow.Font.Bold = true;
                    hoja_trabajo.Range["A2"].EntireRow.Font.Bold = true;

                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Exportacion Exitosa", "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progessbar.Value = 0;
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al exportar la informacion debido a: " + ex.Message);
            //}

        }
    }
}
