using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using System.Windows.Forms;
using static System.Configuration.ConfigurationManager;

namespace SwJugueriaAgustin.Clases
{
    class Funciones
    {
        public static string preconex = ConnectionStrings["stringConexion"].ConnectionString;

        //public static string preconex = "Data Source=192.168.0.5;Initial Catalog=DBAgustinOficial;Uid=admin;Pwd=123";

        //public static string preconex = "Data Source=192.168.0.20;Initial Catalog=DBAgustinOficial;Uid=innovated;Pwd=123";
        //public static string preconex = "Data Source=190.117.125.170;Initial Catalog=DBAgustinOficial;Uid=innovated;Pwd=321!";
        //public static string preconex = "Data Source=192.168.0.22;Initial Catalog='DBSanAgustin';Uid=AGUSTIN;Pwd=123";
        SqlConnection conex;
        SqlCommand cmd = new SqlCommand();
        private CookieContainer myCookie;

        public string obtenerClienteDNI(string numeroIdentificacion)
        {
            //A este link le pasamos los datos , RUC y valor del captcha
            string myUrl = String.Format("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI={0}",
                                    numeroIdentificacion);
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
            myWebRequest.CookieContainer = myCookie;
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            //Leemos los datos
            string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

            if (Datos.Trim().Contains("DNI no encontrado"))
            {
                return "";
            }
            else
            {
                return Datos.Replace("|", " ");
            }
        }

        public void Maximizar(Form frm)
        {
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        public void IniciarSesion()
        {

        }

        public void llamarTeclado()
        {
            Process.Start(Datos.rutaTeclado);
        }

        public void BuscadorGrid(DataGridView dataGrid, string Campo, string parametro)
        {
            dataGrid.CurrentCell = null;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (string.IsNullOrEmpty(Campo))
                    row.Visible = true;
                else if (row.Cells[Campo].Value.ToString().ToUpper().Contains(parametro.ToUpper()))
                    row.Visible = true;
                else
                    row.Visible = false;
            }

            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                if (dataGrid.Rows[i].Visible)
                {
                    dataGrid.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        public string remplazarNulo(string text)
        {
            if (string.IsNullOrEmpty(text) == true)
            {
                text = "0.00";
            }

            return text;
        }

        public void CargarCombo(string campo, string Value, string tabla, ComboBox combo)
        {
            try
            {
                if (combo.Items.Count > 0)
                {
                    combo.DataSource = null;
                    combo.Items.Clear();
                }
                SqlConnection conexion = new SqlConnection(preconex);

                DataSet ds = new DataSet();
                string consulta = "SELECT " + campo + "," + Value + " FROM " + tabla;

                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();

                da.Fill(dt);

                combo.DataSource = dt;
                combo.DisplayMember = dt.Columns[0].ColumnName;
                combo.ValueMember = dt.Columns[1].ColumnName;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        public void Registrar(string table, string datos)
        {
            SqlConnection conexion = new SqlConnection(preconex);

            try
            {
                string reg = "INSERT INTO " + table + " VALUES (" + datos + ")";
                SqlCommand cmdReg = new SqlCommand(reg, conexion);
                conexion.Open();
                int registro = cmdReg.ExecuteNonQuery();
                if (registro > 0)
                {

                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.Message, ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RegistrarOficial(string table, string campos, string datos)
        {
            SqlConnection conexion = new SqlConnection(preconex);

            
                string reg = "INSERT INTO " + table + "(" + campos + ") VALUES (" + datos + ")";
                SqlCommand cmdReg = new SqlCommand(reg, conexion);
                conexion.Open();
                int registro = cmdReg.ExecuteNonQuery();
                if (registro > 0)
                {

                }
                conexion.Close();
            
        }

        public void Eliminar(string table, string condicion)
        {
            SqlConnection conexion = new SqlConnection(preconex);
            try
            {
                string reg = "DELETE " + table + " WHERE " + condicion;
                SqlCommand cmdReg = new SqlCommand(reg, conexion);
                conexion.Open();
                int registro = cmdReg.ExecuteNonQuery();
                if (registro > 0)
                {

                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.Message, ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete(string table, string condicion,bool msj)
        {
            if(msj == true)
            {
                DialogResult mesnaje = MessageBox.Show("Desea Eliminar Dato Seleccionado", "FactuTED", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if(mesnaje == DialogResult.Cancel)
                {
                    return;
                }
            }

            SqlConnection conexion = new SqlConnection(preconex);
            try
            {
                string reg = "DELETE " + table + " WHERE " + condicion;
                SqlCommand cmdReg = new SqlCommand(reg, conexion);
                conexion.Open();
                int registro = cmdReg.ExecuteNonQuery();
                conexion.Close();

                if(msj == true)
                {
                    MessageBox.Show("Dato Eliminado", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.Message, ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Modificar(string table, string modificados, string condicion)
        {
            SqlConnection conexion = new SqlConnection(preconex);

            
                string upd = "update " + table + " set " + modificados + " where " + condicion;
                SqlCommand cmdUpd = new SqlCommand(upd, conexion);
                conexion.Open();
                int registro = cmdUpd.ExecuteNonQuery();
                conexion.Close();
            
        }

        public void MostrarGri(string campos, string tabla, string condicion, DataGridView Grid, string TablaPrincipal)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(preconex);
                conexion.Open();
                string consulta = "select " + campos + " from " + tabla + " where " + condicion;
                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                DataSet ds = new DataSet();
                da.Fill(ds, TablaPrincipal);
                Grid.DataSource = ds;
                Grid.DataMember = TablaPrincipal;
                conexion.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public string Cantidad(string campos, string tabla, string condicion)
        {
            SqlConnection conexion = new SqlConnection(preconex);
            string oncod = "SELECT  count(" + campos + ") FROM " + tabla + " WHERE " + condicion;
            SqlCommand cmd = new SqlCommand(oncod, conexion);
            conexion.Open();
            SqlDataReader lector = cmd.ExecuteReader();
            lector.Read();
            return lector[0].ToString();
            
        }

        public bool Existencia(string campos, string tabla, string condicion)
        {
            SqlConnection conexion = new SqlConnection(preconex);
            string oncod = "SELECT " + campos + " FROM " + tabla + " WHERE " + condicion;
            SqlCommand cmd = new SqlCommand(oncod, conexion);
            conexion.Open();
            SqlDataReader lector = cmd.ExecuteReader();
            lector.Read();
            if (lector.HasRows == true)
            {
                conexion.Close();
                return true;
            }
            else
            {
                conexion.Close();
                return false;
            }
        }

        public SqlConnection Conex_cod()
        {
            SqlConnection Conex_cod = new SqlConnection(preconex);

            return Conex_cod;
        }

        public void Conectar()
        {
            conex = new SqlConnection(preconex);
            conex.Open();
        }

        public void Desconectar()
        {
            conex.Close();
        }

        public void EjecutarSql(string Query)
        {

            SqlCommand comando = new SqlCommand(Query, conex);

            int FilasAfectadas = comando.ExecuteNonQuery();

            if (FilasAfectadas > 0)
            {

                MessageBox.Show("Operación Correcta", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo realizar la Operación", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Ejecutar(string consulta, bool QuiereMensaje)
        {
            SqlConnection conexion = new SqlConnection(preconex);

            try
            {
                SqlCommand cmdReg = new SqlCommand(consulta, conexion);
                conexion.Open();
                int registro = cmdReg.ExecuteNonQuery();
                if (registro > 0 && QuiereMensaje == true)
                {
                    MessageBox.Show("Proceso finalizado, Éxito", "FactuTed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show("Proceso incorrecto: " + ex.Message, "FactuTed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EjecutarSql2(string Query)
        {

            //try
            //{
            SqlCommand comando = new SqlCommand(Query, conex);

            int FilasAfectadas = comando.ExecuteNonQuery();

            if (FilasAfectadas < 1)
            {
                MessageBox.Show("No se pudo realizar la Operación", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //}
            //catch (Exception E)
            //{
            //    E.Message.ToString();
            //}

        }

        public void ActualizarGrid(DataGridView dg, String Query)
            {
            try
            {
                //conectando a la BD
                this.Conectar();

                //crear data set
                DataSet Ds = new DataSet();

                //crear un adaptador de dato
                SqlDataAdapter Da = new SqlDataAdapter(Query, conex);
                //llenar el data set

                Da.Fill(Ds, "Contrato");

                //Asignando el valor adecuado a las propiedades del data grid

                dg.DataSource = Ds;
                dg.DataMember = "Contrato";

                //cerramos la conexion

                this.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "San Agustin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public SqlCommand procedimientoAlmacenado(string nameProcedure)
        {
            SqlConnection conexion = new SqlConnection(Funciones.preconex);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(nameProcedure, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            

            return cmd;
        }

        public string ObtenerValor(string Consulta, bool mensajeError)
        {
            SqlConnection conexion = new SqlConnection(preconex);

            try
            {
                SqlCommand cmd = new SqlCommand(Consulta, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                lector.Read();
                string Retorno = lector[0].ToString();
                conexion.Close();
                return Retorno;
            }
            catch (Exception ex)
            {
                conexion.Close();

                if (mensajeError) MessageBox.Show("Proceso incorrecto: " + ex.Message, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return "";
            }
        }

        public void añadir_ddl(string campo, string Value, string tabla, ComboBox combo)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(preconex);
                string consulta = "SELECT " + Value + "," + campo + " FROM " + tabla;
                SqlDataAdapter dap = new SqlDataAdapter(consulta, conexion);

                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                combo.DataSource = tbl;
                combo.DisplayMember = campo;
                combo.ValueMember = Value;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        public string select_one_value(string campos, string tabla, string condicion, int indice)
        {
            SqlConnection conexion = new SqlConnection(preconex);

            try
            {
                string oncod = "SELECT " + campos + " FROM " + tabla + " WHERE " + condicion;
                SqlCommand cmd = new SqlCommand(oncod, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                lector.Read();
                string Retorno = lector[indice].ToString();
                conexion.Close();
                return Retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ".::SISTEMA::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                return "";
            }
        }
        public string selectValue(string Quey)
        {
            SqlConnection conexion = new SqlConnection(preconex);

            try
            {
                string oncod = Quey;
                SqlCommand cmd = new SqlCommand(oncod, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                lector.Read();
                string Retorno = lector[0].ToString();
                conexion.Close();
                return Retorno;
            }
            catch(Exception ex)
            {
                conexion.Close();
                return "";
            }
        }
        public SqlDataReader selectMultiValues(string query)
        {
            SqlConnection conexion = new SqlConnection(preconex);

            try
            {
                string oncod = query;
                SqlCommand cmd = new SqlCommand(oncod, conexion);
                conexion.Open();
                SqlDataReader lector = cmd.ExecuteReader();


                return lector;

            }
            catch
            {
                return null;
            }

        }

        public void añadir_ddl_CONDICION(string campos, string tabla, string condicion, int indice, ComboBox combo)
        {

            SqlConnection conexion = new SqlConnection(preconex);
            string consulta = "SELECT " + campos + " FROM " + tabla + " WHERE " + condicion;
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            conexion.Open();
            SqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                combo.Items.Add(lector[indice].ToString());
            }

            lector.Close();
        }

        public void cambiarConexion(string cadenaConex)
        {
            String cadenaNueva = cadenaConex;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["stringConexion"].ConnectionString = cadenaNueva;
            config.Save(ConfigurationSaveMode.Modified, true);
            Properties.Settings.Default.Save();
            MessageBox.Show("LA CADENA DE CONEXION SE ACTUALIZO CORRECTAMENTE", "INFORMACION DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }
    }
        
 
    
}
