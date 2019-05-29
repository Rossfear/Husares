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

namespace SwJugueriaAgustin.Formularios.Configuracion
{
    public partial class FrmCopiaSeguridad : Form
    {
        Funciones fn = new Funciones();
        SqlConnection conexion = new SqlConnection(Funciones.preconex);
        public FrmCopiaSeguridad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre_copia = (System.DateTime.Today.Day.ToString() + "-" + System.DateTime.Today.Month.ToString() + "-" + System.DateTime.Today.Year.ToString() + "-" + System.DateTime.Now.Hour.ToString() + "-" + System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString() + " MiPrograma");

            string comando_consulta = "BACKUP DATABASE [DBTabernaGolf] TO  DISK = N'D:\\Archivos\\" + nombre_copia + "' WITH NOFORMAT, NOINIT,  NAME = N'DBTabernaGolf-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

            SqlCommand cmd = new SqlCommand(comando_consulta, conexion);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("La Copia se ha creado Satisfactoriamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }



        }

        private void BTNgENERAR_Click(object sender, EventArgs e)
        {

        }
    }
}
