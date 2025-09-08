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
        public static string Nombre_usuario { get; private set; }
        public static int  Id_usuario {get; private set; }

        //Metodo para iniciar la sesion
        public static void IniciarSesion(int id, string nombre)
        {
            Id_usuario = id;
            Nombre_usuario = nombre;
        }

        //Metodo para cerrar la sesion
        public static void CerrarSesion()
        {
            Id_usuario = 0; //Indica que no hay usuario
            Nombre_usuario = null;
        }

        //Metodo para verificar si la sesion esta activa
        public static bool SesionActiva()
        {
            return !string.IsNullOrEmpty(Nombre_usuario);
        }
    }
}
