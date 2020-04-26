using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioEntidades
{
    public class Facturas
    {
        public int num_factura { get; set; }
        public int cliente { get; set; }
        public DateTime fecha { get; set; }
        public int num_pago { get; set; }
    }
}
