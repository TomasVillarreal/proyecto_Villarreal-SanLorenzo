using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    public static class SesionUsuario
    {
        public static int id_usuario { get; set; }
        public static string nombre_usuario { get; set; }
        public static string apellido_usuario { get; set; }
        public static string email_usuario { get; set; }
        public static string telefono_usuario { get; set; }
        public static List<string> Roles { get; set; } = new List<string>();
        public static List<string> Especialidades { get; set; } = new List<string>();
        public static string RolActivo { get; set; }

        public static void IniciarSesion(int idUsuario, string nombre, string apellido, string email, string telefono)
        {
            id_usuario = idUsuario;
            nombre_usuario = nombre;
            apellido_usuario = apellido;
            email_usuario = email;
            telefono_usuario = telefono;

            Roles.Clear();
            Especialidades.Clear();
            RolActivo = null; //Se selecciona más adelante
        }

        public static void CerrarSesion()
        {
            id_usuario = 0;
            nombre_usuario = null;
            apellido_usuario = null;
            email_usuario = null;
            telefono_usuario = null;

            Roles.Clear();
            Especialidades.Clear();
            RolActivo = null;
        }

        public static bool SesionActiva()
        {
            return id_usuario > 0;
        }
    }
}
