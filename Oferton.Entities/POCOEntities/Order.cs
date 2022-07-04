using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.Entities.POCOEntities
{
    public class Order
    {
        public int nIdOrden { get; set; }
        public int nIdProducto { get; set; }
        public int nIdCliente { get; set; }
        public bool bEstado { get; set; }
        
    }
}
