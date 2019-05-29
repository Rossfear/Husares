using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SwJugueriaAgustin.Clases;

namespace SwJugueriaAgustin.Clases
{
    class Generador
    {
        Funciones instancia = new Funciones();


        public string GeneradorCodigo(string nomtabla)
        {
            SqlConnection cn = instancia.Conex_cod();
            string resultado = "";
            string codigo = "";

            Int64 suma1;

            DataSet ds = new DataSet();
            SqlDataAdapter consulta = new SqlDataAdapter("select NUMERO FROM GENERADOR WHERE NON_TABLA = '" + nomtabla + "'", cn);
            ds.Reset();

            consulta.Fill(ds, "GENERADOR");
            if (ds.Tables["GENERADOR"].Rows.Count > 0)
            {

                resultado = ds.Tables["GENERADOR"].Rows[0][0].ToString().Trim();
                suma1 = Convert.ToInt64(resultado);
                codigo = Convert.ToString(suma1 + 1);

            }
            else
            {
            }
            return codigo;
        }

        public void ActualizarCodigo(string nomtabla)
        {

            SqlConnection cn = instancia.Conex_cod();
            cn.Open();
            string sql = "update GENERADOR set NUMERO =NUMERO+1 where NON_TABLA='" + nomtabla + "'";
            SqlCommand cmd = new SqlCommand(sql, cn);

            cmd.ExecuteNonQuery();
            cn.Close();

        }
    }
}
