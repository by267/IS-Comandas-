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
            String sqlConsulta = "insert into comandas (producto, precio, cantidad, mesa, comentarios, noComanda) values(@producto, @precio, @cantidad, @mesa, @comentarios, @noComanda)";
            comando.Parameters.Clear();
            comando.Parameters.Add("@producto", MySqlDbType.VarChar).Value = obj.producto;
            comando.Parameters.Add("@precio", MySqlDbType.Float).Value = obj.precio;
            comando.Parameters.Add("@cantidad", MySqlDbType.Int64).Value = obj.cantidad;
            comando.Parameters.Add("@noComanda", MySqlDbType.Float).Value = obj.noComanda;
            comando.Parameters.Add("@mesa", MySqlDbType.Int64).Value = obj.mesa;
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
            String sqlConsulta = "select  idComandas, producto, precio, cantidad from comandas where noComanda = @mesa";
            comando.Parameters.Clear();
            comando.Parameters.Add("@mesa", MySqlDbType.Int32).Value = obj.noComanda;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
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
        public void EliminarE(clasecomanda obj)
        {
            String sqlConsulta = "delete from comandas where noComanda = @comanda";
            comando.Parameters.Add("@comanda", MySqlDbType.VarChar).Value = obj.noComanda;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable sumaTotal(clasecomanda obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "SELECT ROUND(SUM(precio*cantidad), 3) AS subtotal FROM comandas where mesa = @mesa;"; comando.Parameters.Clear();
            comando.Parameters.Add("@mesa", MySqlDbType.Int32).Value = obj.mesa;
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
            String sqlConsulta = "SELECT DISTINCT noComanda FROM comandas;";

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable ConsultarPuesto(clasecomanda obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from comandas where noComanda = @comanda";
            comando.Parameters.Clear();
            comando.Parameters.Add("@comanda", MySqlDbType.VarChar).Value = obj.noComanda;
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
