using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IS_Comandas_.Gerente.Clases
{
    internal class dbMesa
    {
        private MySqlConnection conexion;
        private String strConexion;
        private MySqlCommand comando;
        private String strConsulta;
        private MySqlDataAdapter adaptador;

        public dbMesa()
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
        public void Agregar(ClassMesa obj)
        {
            String sqlConsulta = "insert into mesas (estado) values('off')";
            comando.Parameters.Clear();
            //comando.Parameters.Add("@numero", MySqlDbType.Int64).Value = obj.Numero;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public void EliminarE(ClassMesa obj)
        {
            String sqlConsulta = "delete from mesas where idmesas = @mesa";
            comando.Parameters.Add("@mesa", MySqlDbType.Int64).Value = obj.Id;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable ConsultarU(String tabla)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from mesas";

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable ConsultarTodos()
        {
            DataTable datos = new DataTable();
            String strConsulta = "select * from mesas";
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = strConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void Eliminar()
        {
            String sqlConsulta = "DELETE FROM mesas ORDER BY idmesas DESC LIMIT 1;";
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public void activarMesa(ClassMesa obj)
        {
            String sqlConsulta = "update mesas set estado = 'on' where idmesas = @idmesas;";
            comando.Parameters.Add("@idmesas", MySqlDbType.Int64).Value = obj.Id;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable ConsultarE(String tabla)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from mesas where estado= 'off'";

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable ConsultarO(String tabla)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from mesas where estado= 'on'";

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
    }
}
