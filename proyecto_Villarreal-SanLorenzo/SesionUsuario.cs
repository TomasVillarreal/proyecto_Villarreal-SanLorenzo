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
        public static long telefono_usuario { get; set; }
        public static string email_usuario { get; set; }


        //Metodo para iniciar la sesion
        public static void IniciarSesion(int idUsuario,int idRol, string nombre, string apellido, string nombreRol, long telefono, string email)
        {
            SesionUsuario.id_usuario = idUsuario;
            SesionUsuario.id_rol = idRol;
            SesionUsuario.nombre_usuario = nombre;
            SesionUsuario.apellido_usuario = apellido;
            SesionUsuario.nombre_rol = nombreRol;
            SesionUsuario.telefono_usuario = telefono;
            SesionUsuario.email_usuario += email;
        }

        //Metodo para cerrar la sesion
        public static void CerrarSesion()
        {
            SesionUsuario.id_usuario = 0;
            SesionUsuario.id_rol = 0;
            SesionUsuario.nombre_usuario = null;
            SesionUsuario.apellido_usuario = null;
            SesionUsuario.nombre_rol = null;
            SesionUsuario.telefono_usuario = 0;
            SesionUsuario.email_usuario = null;
        }

        //Metodo para verificar si la sesion esta activa
        public static bool SesionActiva()
        {
            return SesionUsuario.id_usuario > 0;
        }
    }
}
