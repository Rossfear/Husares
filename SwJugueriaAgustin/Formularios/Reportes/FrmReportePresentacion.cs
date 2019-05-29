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

namespace SwJugueriaAgustin.Formularios.Reportes
{
    public partial class FrmReportePresentacion : Form
    {
        Funciones fn = new Funciones();
        exportador ex = new exportador();
        public FrmReportePresentacion()
        {
            InitializeComponent();
        }

        private void FrmReportePresentacion_Load(object sender, EventArgs e)
        {
            mostrarGrid();
        }


        private void mostrarGrid()
        {
            fn.ActualizarGrid(dgvPresentaciones, "select sc.SubCategoria,pro.Producto +' '+pre.Presentacion as Presentacion,pre.Precio from Producto pro left join Presentacion pre on pro.IDProducto = pre.IDProducto left join SubCategoria sc on pro.IDSubcategoria = sc.IDSubCategoria where pro.Producto like '%"+txtPresentacion.Text+"%' and pre.Precio like '%"+txtPrecio.Text+"%'");
        }

        private void txtPresentacion_TextChanged(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ex.ExportExcelTimer(dgvPresentaciones, "Presentaciones",-1, progressBar1, "Lista de Presentaciones");
            
        }
    }
}
