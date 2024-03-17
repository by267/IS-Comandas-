using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IS_Comandas_
{
    internal class ConexionL
    {
        public static MySqlConnection getConexion()
        {
            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "123456";
            string bd = "comandas";

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + bd;

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            return conexion;

        }
    }
}
