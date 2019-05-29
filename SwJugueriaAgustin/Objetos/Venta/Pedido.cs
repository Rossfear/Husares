using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwJugueriaAgustin.Objetos.Venta
{
    class Pedido
    {
        public string IDPedido { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public int IDMesa { get; set; }
        public int IDMozo { get; set; }
        public decimal Total { get; set; }
        public bool Vendido { get; set; }
        public bool Anulado { get; set; }
        public int IDCliente { get; set; }
        public List<PedidoDetalle> Detalle { get; set; }
    }
}
