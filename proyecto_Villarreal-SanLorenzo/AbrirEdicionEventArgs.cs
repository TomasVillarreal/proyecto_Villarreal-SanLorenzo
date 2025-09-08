using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    public class AbrirEdicionEventArgs : EventArgs
    {
        public object datos { get; set; }
        public UserControlProyecto control {  get; set; }
        public bool esEdicion { get; set; }

        public AbrirEdicionEventArgs  (Object p_datos, UserControlProyecto p_control, bool p_edicion)
        {
            this.datos = p_datos;
            this.control = p_control;
            this.esEdicion = p_edicion;
        }

    }
}
