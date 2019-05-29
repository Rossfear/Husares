using SwJugueriaAgustin.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Formularios.Operaciones
{
    public partial class FrmConexion : Form
    {
        public FrmConexion()
        {
            InitializeComponent();
        }

        private void FrmConexion_Load(object sender, EventArgs e)
        {
            txtServidorRemoto.Text = ConfigurationManager.AppSettings["ServidorRemoto"];
            txtBaseHusares.Text = ConfigurationManager.AppSettings["baseHusares"];
            txtBaseGolf.Text = ConfigurationManager.AppSettings["baseGolf"];
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funciones fn = new Funciones();
            fn.cambiarConexion("Data Source="+txtservidor.Text+";Initial Catalog="+txtbase.Text+";Uid="+txtusuario.Text+";Pwd="+txtpass.Text+"");
        }


        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private void txtServidorRemoto_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUpdateAppSettings("baseGolf", txtBaseGolf.Text);
            AddUpdateAppSettings("baseHusares", txtBaseHusares.Text);
            AddUpdateAppSettings("ServidorRemoto", txtServidorRemoto.Text);
            MessageBox.Show("Datos Actualizado","FactuTED",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
