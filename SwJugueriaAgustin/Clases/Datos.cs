using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwJugueriaAgustin.Clases
{
    public class Datos
    {
        //USUARIO
        public static string idUsuario { get; set; }
        public static string Usuario { get; set; }
        public static string nombre { get; set; }
        public static bool tactil { get; set; }
        public static bool mozo { get; set; }

        //SISTEMA
        public static string wifi { get; set; }
        public static string idSucursal { get; set; }
        public static string sucursal { get; set; }
        public static string rutaTeclado { get; set; }
        public static bool permisoEspeciales { get; set; }
        public static string Alias { get; set; }
        public static string IDAlmacen { get; set; }
        public static bool AumentarStock { get; set; }

        public static bool sinTicket { get; set; }
        public static double LimiteTicket { get; set; }
        public static bool conTeclado { get; set; }
        public static int cantidadComanda { get; set; }
        public static int cantidadComprobante { get; set; }
        public static bool ocultarDinero { get; set; }

        public static bool administrador { get; set; }
        public static bool transferenciaGratuita { get; set; }

        //IMPRESORAS
        public static string impresoraCocina { get; set; }
        public static string impresoraBar { get; set; }
        public static string impresoraHorno { get; set; }
        public static string impresoraComprobante { get; set; }
        //
        public static string impresoraDeliveryBar { get; set; }
        public static string impresoraDeliveryCocina { get; set; }
        public static string impresoraDeliveryHorno { get; set; }

        public static string impresorallevarCocina { get; set; }
        public static string impresorallevarBar { get; set; }   
        public static string impresorallevarHorno { get; set; }   

        //DATOS IMPRESION
        public static string Ruc { get; set; }
        public static string Direccion { get; set; }
        public static string nombreComercial { get; set; }
        public static string Departmaneto { get; set; }
        public static string RazonSocial { get; set; }
        
        public static string contraseñaSeguridad { get; set; }
        public static bool conPrecuenta { get; set; }
        public static string nroAutorizacion { get; set; }
        public static string serieImpresora { get; set; }
        public static string rutaDescarga { get; set; }
        public static bool AbrirCajaSinAlmacen { get; set; }

    }
}
