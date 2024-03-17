using IS_Comandas_.Gerente.Clases;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Comandas_
{
    internal class Control
    {
        public string ctrlLogin(string usuario, string password)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            ClassEmpleado datosUsuario = null;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                datosUsuario = modelo.porUsuario(usuario);

                if (datosUsuario == null)
                {
                    respuesta = "El usuario no existe";
                }
                else
                {
                    if (datosUsuario.Password != password)
                    {
                        respuesta = "El usuario y la contraseña no coinciden";
                    }
                    else
                    {
                        Session.Usuario = datosUsuario.Usuario;
                        Session.pass = usuario;
                    }
                }
            }
            return respuesta;
        }
    }
}
