using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace IS_Comandas_.Gerente.Clases
{
    internal class dbMenu
    {
        private MySqlConnection conexion;
        private String strConexion;
        private MySqlCommand comando;
        private String strConsulta;
        private MySqlDataAdapter adaptador;

        public dbMenu()
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
        public DataTable ConsultarCodigoH(ClassMenu obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select  idMenu, nombre, descripcion, precio, categoria from menu where nombre = @nombre";
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
        public void Agregar(ClassMenu obj)
        {
            String sqlConsulta = "insert into menu (nombre, descripcion, precio, categoria) values(@nombre, @descripcion, @precio, @categoria)";
            comando.Parameters.Clear();
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = obj.Nombre;
            comando.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = obj.Descripcion;
            comando.Parameters.Add("@precio", MySqlDbType.VarChar).Value = obj.Precio;
            comando.Parameters.Add("@categoria", MySqlDbType.VarChar).Value = obj.Categoria;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable ConsultarTodosCat()
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
        public void EliminarE(ClassMenu obj)
        {
            String sqlConsulta = "delete from menu where nombre = @nombre";
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
            String sqlConsulta = "select * from menu";

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
            String strConsulta = "select * from menu";
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = strConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void Actualizar(ClassMenu obj)
        {
            String sqlConsulta = "update menu set nombre = @nombre,  descripcion = @descripcion, precio = @precio, categoria = @categoria where nombre = @nombre";
            comando.Parameters.Clear();
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = obj.Nombre;
            comando.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = obj.Descripcion;
            comando.Parameters.Add("@precio", MySqlDbType.Float).Value = obj.Precio;
            comando.Parameters.Add("@categoria", MySqlDbType.VarChar).Value = obj.Categoria;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
    }
}
