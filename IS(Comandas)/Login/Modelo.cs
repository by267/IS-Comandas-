using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Comandas_.Gerente.Clases;
using MySql.Data.MySqlClient;

namespace IS_Comandas_
{
    internal class Modelo
    {
        public ClassEmpleado porUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = ConexionL.getConexion();
            conexion.Open();

            string sql = "SELECT Usuario, Password FROM empleados WHERE Usuario LIKE @Usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@Usuario", usuario);

            reader = comando.ExecuteReader();

            ClassEmpleado usr = null;

            while (reader.Read())
            {
                usr = new ClassEmpleado();
                usr.Usuario = reader["Usuario"].ToString();
                usr.Password = reader["Password"].ToString();
            }
            return usr;
        }
    }
}
