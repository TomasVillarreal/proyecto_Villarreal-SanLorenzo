using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    public static class SesionUsuario
    {
        //Información del usuario a almacenar durante su sesión
        //Constructores
        public static int id_usuario { get; set; }

        public static int id_rol { get; set; }
        public static string nombre_usuario { get; set; }
        public static string apellido_usuario { get; set; }
        public static string nombre_rol { get; set; }


        //Metodo para iniciar la sesion
        public static void IniciarSesion(int id_usuario,int id_rol, string nombre, string apellido, string nombre_rol)
        {
            id_usuario = id_usuario;
            id_rol = id_rol;
            nombre_usuario = nombre;
            apellido_usuario = apellido;
        }

        //Metodo para cerrar la sesion
        public static void CerrarSesion()
        {
            id_usuario = 0; //Indica que no hay usuario
            id_rol = 0;
            nombre_usuario = null;
            apellido_usuario = null;
            nombre_rol = null;
        }

        //Metodo para verificar si la sesion esta activa
        public static bool SesionActiva()
        {
            return SesionUsuario.id_usuario > 0;
        }
    }
}
