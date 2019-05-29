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

namespace SwJugueriaAgustin.Formularios.Reportes
{
    public partial class FrmReporteAtencion : Form
    {
        Funciones fn = new Funciones();
        
        public static string idAtencion;
        public FrmReporteAtencion()
        {
            InitializeComponent();
        }

        private void FrmReporteAtencion_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader lector = fn.selectMultiValues("select u.Nombres,ap.Fecha,ap.Hora from AtencionPedido ap inner join Usuario u on ap.IDUsuario = u.IDUsuario where ap.IDAtencion='" + idAtencion + "'");
                lector.Read();
                lblNombreTrabajador.Text = lector["Nombres"].ToString();
                lblFecha.Text = lector["Fecha"].ToString();
                lblHora.Text = lector["Hora"].ToString();
                lector.Close();


                fn.MostrarGri("i.Insumo,da.Cantidad,um.UniMedida", "DetalleAtencionPedido da inner join Insumo i on da.IDInsumo = i.IDInsumo inner join UnidadMedida um on i.IDUniMedida = um.IDUniMedida", "da.IDAtencion='" + idAtencion + "'", dgvDetalleAtencion, "DetalleAtencionPedido");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
