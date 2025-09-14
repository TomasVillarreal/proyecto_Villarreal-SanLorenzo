using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    public class FilasUltimaActividad : Panel
    {

        int dni = 0;

        public FilasUltimaActividad(int p_dni)
        {
            this.BackColor = Color.White;
            this.dni = p_dni;
        }

        private void FilasUltimaActividad_Load(object sender, EventArgs e)
        {
            
        }

            

    }
}
