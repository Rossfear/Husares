using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwJugueriaAgustin.Objetos.Venta
{
    public class PedidoDetalle
    {
        public string IDPedido { get; set; }
        public int IDPresentacion { get; set; }
        public string Presentacion { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public bool Imprimido { get; set; }
        public decimal Costo { get; set; }
        public bool Vendido { get; set; }
        public bool Combo { get; set; }
        public string IDPresentacionCombo { get; set; }        
    }
}
