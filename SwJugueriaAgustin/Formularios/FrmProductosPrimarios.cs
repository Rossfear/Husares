using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios
{
    public partial class FrmProductosPrimarios : Form
    {
        public FrmProductosPrimarios()
        {
            InitializeComponent();
        }
        Clases.Funciones fn = new Clases.Funciones();
        bool QuiereGuardar;
        string IDProducto;
        private void Bloquear(bool i)
        {
            txtNombreProducto.Enabled = !i;
            txtCompra.Enabled = !i;
            cboUnidadMedida.Enabled = !i;
            btnNuevo.Enabled = i;
            btnGuardar.Enabled = !i;
            btnModificar.Enabled = i;
            btnEliminar.Enabled = i;
            btnCancelar.Enabled = !i;
        }
        private void MostrarDatosGrid()
        {
            fn.MostrarGri("IDProductoPrimo as [ID],Producto as [NOMBRE PRODUCTO],um.UniMedida as [UM],PP.PrecioCompra AS [PRECIO COMPRA],pp.stock AS [STOCK] ", "productoprimo pp INNER JOIN UnidadMedida um on pp.IDUniMedida = um.IDUniMedida ", "IDProductoPrimo!=0", dgvProductos, "productoprimo");
        }
        private void FrmProductosPrimarios_Load(object sender, EventArgs e)
        {

        }
    }
}
