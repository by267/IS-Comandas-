using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace IS_Comandas_.Gerente.Clases
{
    internal class dbCategoria
    {
        private MySqlConnection conexion;
        private String strConexion;
        private MySqlCommand comando;
        private String strConsulta;
        private MySqlDataAdapter adaptador;

        public dbCategoria()
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
        public DataTable ConsultarCodigo(ClassCategoria obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select idCategorias, nombre from categorias where nombre = @nombre";
            comando.Parameters.Clear();
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = obj.Nombre;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void Agregar(ClassCategoria obj)
        {
            String sqlConsulta = "insert into categorias (nombre) values(@nombre)";
            comando.Parameters.Clear();
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = obj.Nombre;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable ConsultarU(String tabla)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from categorias";

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void EliminarE(ClassCategoria obj)
        {
            String sqlConsulta = "delete from categorias where nombre = @nombre";
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = obj.Nombre;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable ConsultarTodos()
        {
            DataTable datos = new DataTable();
            String strConsulta = "select * from categorias";
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = strConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void Actualizar(ClassCategoria obj)
        {
            String sqlConsulta = "update categorias set nombre = @nombre where idCategorias = @id";
            comando.Parameters.Clear();
            comando.Parameters.Add("@id", MySqlDbType.Int64).Value = obj.Id;
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = obj.Nombre;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
    }
}
