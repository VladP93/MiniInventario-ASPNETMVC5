using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioEntidades
{
    public class Detalles
    {
        public int num_detalle { get; set; }
        public int factura { get; set; }
        public int producto { get; set; }
        public double cantidad { get; set; }
        public double precio { get; set; }
    }
}
