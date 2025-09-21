using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    /*
     * Clase de tipo de argumentos creada para poder navegar entre usercontrol distintos,
     * y poder pasar otro tipo de datos junto a esta navegacion.
     */
    public class AbrirEdicionEventArgs : EventArgs
    {
        // Objeto que pasaremos como argumento, junto al usercontrol.
        public object datos { get; set; }
        // Usercontrol hacia el cual deseamos movernos
        public UserControlProyecto control {  get; set; }
        // Argumento inutil, se deberia sacar.
        public bool esEdicion { get; set; }

        // Cuando se crea este tipo de evento, se le asignan los datos pasados como argumento.
        public AbrirEdicionEventArgs  (Object p_datos, UserControlProyecto p_control, bool p_edicion)
        {
            this.datos = p_datos;
            this.control = p_control;
            this.esEdicion = p_edicion;
        }

    }
}
