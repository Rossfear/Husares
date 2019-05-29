using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SwJugueriaAgustin.Clases;

namespace SwJugueriaAgustin.Formularios
{
    public partial class Frm_Caja : Form
    {
        string fecha = DateTime.Now.ToShortDateString();

        Funciones fn = new Funciones();


        //   string nivel = Frm_Login.nivel;



        public static string conexion = Funciones.preconex;
        SqlConnection cn = new SqlConnection(conexion);

        public Frm_Caja()
        {
            InitializeComponent();
        }
        
       

 
       
      
        private void Frm_Caja_Load(object sender, EventArgs e)
        {
            fn.CargarCombo("c.Usuario", "c.IDCajera", "CajeraSucursal cs  inner join Sucursal s on cs.IDSucursal = s.IDSucursal  inner join Cajera c on cs.IDCajera = c.IDCajera  where cs.IDSucursal = '"+Datos.idSucursal+"'",cboCajero);
        }
        

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            if (validacionApertura() == false)
            {
                return;
            }

            string tipo = "";
            if (rbtnDelivery.Checked == true)
            {
                tipo = "DELIVERY";
            }
            else
            {
                tipo = "VENTA SALON";
            }

            fn.RegistrarOficial("Caja", "FECHA_HORA,SaldoInicial,Tipo,Estado,IDUsuario,IDSucursal,IDCajero",
                "'"+DateTime.Now.ToShortDateString()+"','"+txt_efectivo.Text+"','"+tipo+"','ABIERTA','"+Datos.idUsuario+"','"+Datos.idSucursal+"','"+cboCajero.SelectedValue+"'");

            MessageBox.Show("Operacion Correcta","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();

        }

        private bool validacionApertura()
        {
            if(!Datos.AbrirCajaSinAlmacen)
            {
                if (!fn.Existencia("*", "AperturaAlmacen", "FechaApertura = '" + DateTime.Now.ToShortDateString() + "' and IDSucursal = '" + Datos.idSucursal + "'"))
                {
                    MessageBox.Show("Aperturar Almacen", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            try
            {
                Convert.ToDecimal(txt_efectivo.Text);
            }
            catch
            {
                MessageBox.Show("Monto Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string estadoCaja = "";

            string tipo = "";
            if (rbtnDelivery.Checked == true)
            {
                tipo = "DELIVERY";
            }
            else
            {
                tipo = "VENTA SALON";
            }

            if(cboCajero.SelectedValue == null)
            {
                MessageBox.Show("Cajero Incorrecto", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(fn.selectValue("select Contraseña from Cajera where IDCajera = '"+cboCajero.SelectedValue+"'") != txtContraseña.Text)
            {
                MessageBox.Show("Contraseña Incorrecta", "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fn.Existencia("*", "Caja", "Tipo ='" + tipo + "' and IDSucursal = '"+Datos.idSucursal+"' ORDER BY ID DESC") == true)
            {
                estadoCaja = fn.select_one_value("top(1)ESTADO", "CAJA", "Tipo ='" + tipo + "' and IDSucursal = '"+Datos.idSucursal+"' ORDER BY ID DESC", 0);
            }

            if (estadoCaja == "ABIERTA")
            {
                string fecha = fn.select_one_value("top(1)FECHA_HORA", "CAJA", "IDSucursal = '"+Datos.idSucursal+"'  ORDER BY ID DESC", 0);
                MessageBox.Show("LA CAJA ESTA ABIERTA DESDE EL DIA " + fecha, "FactuTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            if (rbtnDelivery.Checked == false && rbtnVentaSalon.Checked == false)
            {
                MessageBox.Show("Especifica Tipo de Caja", "FActuTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var msj = MessageBox.Show("Desea Abrir Caja","FactuTED",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if(msj == DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void txt_efectivo_Click(object sender, EventArgs e)
        {

        }
    }
}
