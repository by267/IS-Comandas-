using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IS_Comandas_.Gerente.Clases
{
    internal class dbEmpleado
    {
        private MySqlConnection conexion;
        private String strConexion;
        private MySqlCommand comando;
        private String strConsulta;
        private MySqlDataAdapter adaptador;

        public dbEmpleado()
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
        public DataTable ConsultarPuesto(ClassEmpleado obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from empleados where Usuario = @Usuario";
            comando.Parameters.Clear();
            comando.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = obj.Usuario;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void Agregar(ClassEmpleado obj)
        {
            String sqlConsulta = "insert into empleados (Nombre, ApellidoPaterno, ApellidoMaterno, Usuario, Password, Puesto) values(@nombre, @aPaterno, @aMaterno, @usuario, @pass, @puesto)";
            comando.Parameters.Clear();
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = obj.Nombre;
            comando.Parameters.Add("@aPaterno", MySqlDbType.VarChar).Value = obj.ApellidoPaterno;
            comando.Parameters.Add("@aMaterno", MySqlDbType.VarChar).Value = obj.ApellidoMaterno;
            comando.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = obj.Usuario;
            comando.Parameters.Add("@pass", MySqlDbType.VarChar).Value = obj.Password;
            comando.Parameters.Add("@puesto", MySqlDbType.VarChar).Value = obj.Puesto;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }

        public DataTable ConsultarCodigoH(ClassEmpleado obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select  idEmpleado, Nombre, ApellidoPaterno, ApellidoMaterno, Usuario, Password, Puesto from empleados where Usuario = @Usuario";
            comando.Parameters.Clear();
            comando.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = obj.Usuario;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void EliminarE(ClassEmpleado obj)
        {
            String sqlConsulta = "delete from empleados where Usuario = @usuario";
            comando.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = obj.Usuario;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable ConsultarU(String tabla)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from empleados";

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
            String strConsulta = "select * from empleados";
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = strConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable ConsultarCodigo(ClassEmpleado obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select Usuario from empleados where Usuario = @Usuario";
            comando.Parameters.Clear();
            comando.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = obj.Usuario;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void Actualizar(ClassEmpleado obj)
        {
            String sqlConsulta = "update empleados set Password = @pass where Usuario = @Usuario";
            comando.Parameters.Clear();
            comando.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = obj.Usuario;
            comando.Parameters.Add("@pass", MySqlDbType.VarChar).Value = obj.Password;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
    }
}
