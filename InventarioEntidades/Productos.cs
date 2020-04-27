using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioEntidades
{
    public class Productos
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public Categorias categoria { get; set; }
        public int id_categoria { get; set; }
    }
}
