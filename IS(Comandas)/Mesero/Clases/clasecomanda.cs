using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace IS_Comandas_.Mesero.Clases
{
    internal class clasecomanda
    {
        public int Id { get; set; }
        public float precio { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public string comentarios { get; set; }
    }
}
