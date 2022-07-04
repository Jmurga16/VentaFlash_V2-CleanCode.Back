using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.UseCasesDTOs.CreateOrder
{
    public class CreateOrderParams
    {
        public int nIdProducto { get; set; }
        public string sNombre { get; set; }
        public string sCorreo { get; set; }
        public string sDireccion { get; set; }
    }
}
