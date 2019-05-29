using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwJugueriaAgustin.Clases
{
    public class Mantenimiento
    {
        Funciones fn = new Funciones();
        public void Bloquear(GroupBox groupBox, Button Guardar, Button Editar, Button Elimar, Button Nuevo, Button cancelar)
        {
            groupBox.Enabled = false;
            Guardar.Enabled = false;
            Editar.Enabled = true;
            Elimar.Enabled = true;
            cancelar.Enabled = false;

            Nuevo.Enabled = true;
            Nuevo.Select();
        }

        public void Desbloquear(GroupBox groupBox, Button Guardar, Button Editar, Button Elimar, Button Nuevo, Button cancelar)
        {
            groupBox.Enabled = true;
            Guardar.Enabled = true;
            Editar.Enabled = false;
            Elimar.Enabled = false;
            cancelar.Enabled = true;

            Nuevo.Enabled = false;
        }


        public void Guardar(bool editar, string tabla, string campos,string datos, string modificados, string condicionModificar)
        {
            if (editar == true)
            {
                fn.Modificar(tabla, modificados, condicionModificar);
                editar = false;
                MessageBox.Show("Datos Actualizados", "Taberna", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                fn.RegistrarOficial(tabla,campos ,datos);
                MessageBox.Show("Datos Registrados", "Taberna", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
