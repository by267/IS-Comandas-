using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Comandas_.Mesero.Clases;
using MySql.Data.MySqlClient;

namespace IS_Comandas_.Cajero
{
    internal class dbTicket
    {
        private MySqlConnection conexion;
        private String strConexion;
        private MySqlCommand comando;
        private String strConsulta;
        private MySqlDataAdapter adaptador;

        public dbTicket()
        {
            conexion = new MySqlConnection();
            strConexion = "Server=localhost;UserId=root;Password=123456;DataBase=comandas";
            conexion.ConnectionString = strConexion;
            comando = new MySqlCommand();
            adaptador = new MySqlDataAdapter();
        }

        public Boolean abrir()
        {
            Boolean exito = false;
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
                exito = true;
            }
            return exito;
        }

        public Boolean cerrar()
        {
            Boolean exito = false;
            if (conexion.State == ConnectionState.Closed)
            {
                exito = false;
            }
            else
            {
                conexion.Close();
                exito = true;
            }
            return exito;
        }
        public void Agregar(ticket obj)
        {
            String sqlConsulta = "insert into ticket (listProd, total, ingreso, cambio) values(@listProd, @total, @ingreso, @feria)";
            comando.Parameters.Clear();
            comando.Parameters.Add("@listProd", MySqlDbType.VarChar).Value = obj.Producto;
            comando.Parameters.Add("@total", MySqlDbType.Float).Value = obj.Total;
            comando.Parameters.Add("@ingreso", MySqlDbType.Int64).Value = obj.Ingreso;
            comando.Parameters.Add("@feria", MySqlDbType.Float).Value = obj.Feria;

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
    }
}
