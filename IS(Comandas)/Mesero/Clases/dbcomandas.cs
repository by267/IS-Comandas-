using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Comandas_.Gerente.Clases;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace IS_Comandas_.Mesero.Clases
{
    internal class dbcomandas
    {
        private MySqlConnection conexion;
        private String strConexion;
        private MySqlCommand comando;
        private String strConsulta;
        private MySqlDataAdapter adaptador;

        public dbcomandas()
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
        public void Agregar(clasecomanda obj)
        {
            String sqlConsulta = "insert into comandas (producto, precio, cantidad, comentarios) values(@producto, @precio, @cantidad, @comentarios)";
            comando.Parameters.Clear();
            comando.Parameters.Add("@producto", MySqlDbType.VarChar).Value = obj.producto;
            comando.Parameters.Add("@precio", MySqlDbType.Float).Value = obj.precio;
            comando.Parameters.Add("@cantidad", MySqlDbType.Int64).Value = obj.cantidad;
            comando.Parameters.Add("@comentarios", MySqlDbType.VarChar).Value = obj.comentarios;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable ConsultarTodosCom()
        {
            DataTable datos = new DataTable();
            String strConsulta = "select * from comandas";
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
            String sqlConsulta = "delete from comandas where producto = @producto";
            comando.Parameters.Add("@producto", MySqlDbType.VarChar).Value = obj.Nombre;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable ConsultarCodigoH(clasecomanda obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select  idComandas, producto, precio, cantidad from comandas where mesa = @mesa";
            comando.Parameters.Clear();
            comando.Parameters.Add("@mesa", MySqlDbType.Int32).Value = obj.mesa;
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
