using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Comandas_.Cajero
{
    internal class ticket
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public float Total { get; set; }
        public int Ingreso { get; set; }
        public float Feria { get; set; }
    }
}
