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

namespace SwJugueriaAgustin.Formularios.Configuracion
{
    public partial class FConfiguracionSucursal : Form
    {
        Funciones fn = new Funciones();
        public FConfiguracionSucursal()
        {
            InitializeComponent();
        }

        private void FConfiguracionSucursal_Load(object sender, EventArgs e)
        {
            ComboBox[] LCombos = { cboDeliveryBa, cboDeliveryCocina, cboDeliveryHorno ,cboLlevarBar, cboLlevarCocina, cboLlevarHorno ,cboMozoBar, cboMozoCocina, cboMozoHorno };

            foreach (var item in LCombos)
            {
                CargarImpresoras(item);
            }

            cboMozoBar.Text = Datos.impresoraBar;
            cboMozoCocina.Text = Datos.impresoraCocina;
            cboMozoHorno.Text = Datos.impresoraHorno;

            //Hecho por Daniel
            cboDeliveryBa.Text = Datos.impresoraDeliveryBar;
            cboDeliveryCocina.Text = Datos.impresoraDeliveryCocina;
            cboDeliveryHorno.Text = Datos.impresoraDeliveryHorno;

            cboLlevarBar.Text = Datos.impresorallevarBar;
            cboLlevarCocina.Text = Datos.impresorallevarCocina;
            cboLlevarHorno.Text = Datos.impresorallevarHorno;
        }

        void CargarImpresoras(ComboBox combo)
        {
            foreach (String Impresora in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                combo.Items.Add(Impresora);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            fn.Modificar("Impresora", "Impresora='" + cboDeliveryCocina.Text + "'", "IDSucursal = '" + Datos.idSucursal + "' and Tipo = 'DELIVERY COCINA'");
            fn.Modificar("Impresora", "Impresora='" + cboDeliveryBa.Text + "'", "IDSucursal = '" + Datos.idSucursal + "' and Tipo = 'DELIVERY BAR'");
            fn.Modificar("Impresora", "Impresora='" + cboDeliveryHorno.Text + "'", "IDSucursal = '" + Datos.idSucursal + "' and Tipo = 'DELIVERY HORNO'");

            fn.Modificar("Impresora", "Impresora='" + cboMozoCocina.Text + "'", "IDSucursal = '" + Datos.idSucursal + "' and Tipo = 'COCINA'");
            fn.Modificar("Impresora", "Impresora='" + cboMozoBar.Text + "'", "IDSucursal = '" + Datos.idSucursal + "' and Tipo = 'BAR'");
            fn.Modificar("Impresora", "Impresora='" + cboMozoHorno.Text + "'", "IDSucursal = '" + Datos.idSucursal + "' and Tipo = 'HORNO'");

            fn.Modificar("Impresora", "Impresora='" + cboLlevarBar.Text + "'", "IDSucursal = '" + Datos.idSucursal + "' and Tipo = 'LLEVAR BAR'");
            fn.Modificar("Impresora", "Impresora='" + cboLlevarCocina.Text + "'", "IDSucursal = '" + Datos.idSucursal + "' and Tipo = 'LLEVAR COCINA'");
            fn.Modificar("Impresora", "Impresora='" + cboLlevarHorno.Text + "'", "IDSucursal = '" + Datos.idSucursal + "' and Tipo = 'LLEVAR HORNO'");


            Datos.impresoraBar = cboMozoBar.Text;
            Datos.impresoraCocina = cboMozoCocina.Text;
            Datos.impresoraHorno = cboMozoHorno.Text;

            Datos.impresoraDeliveryBar = cboDeliveryBa.Text;
            Datos.impresoraDeliveryCocina = cboDeliveryCocina.Text;
            Datos.impresoraDeliveryHorno = cboDeliveryHorno.Text;

            Datos.impresorallevarBar = cboLlevarBar.Text;
            Datos.impresorallevarCocina = cboLlevarCocina.Text;
            Datos.impresorallevarHorno = cboLlevarHorno.Text;


            MessageBox.Show("Datos actualizados");
            this.Close();
        }
    }
}
