using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    // Clase creada para hacer que todos los usercontrol sean uniformes entre si.
    public class UserControlProyecto : UserControl
    {
        // Cuando se crea este tipo de usercontrol:
        public UserControlProyecto()
        {
            // Se le cambia el color de fondo a uno por defecto
            this.BackColor = ColorTranslator.FromHtml("#F5F5F5");

            // Propiedad que hace que no haya parpadeos al pintar los bordes.
            this.DoubleBuffered = true;

            // Se suscribe el evento para pintarle los bordes
            this.Paint += UserControlProyecto_Paint;

            // Se le coloca el tamaño del panel default del form principal
            this.Size = new Size(768, 575);
        }

        // Se pintan los bordes.
        private void UserControlProyecto_Paint(object sender, PaintEventArgs e)
        {
            Color bordeColor = ColorTranslator.FromHtml("#C0C0C0");
            int grosor = 1;

            ControlPaint.DrawBorder(
                e.Graphics,
                this.ClientRectangle,
                bordeColor, grosor, ButtonBorderStyle.Solid,   // Left
                bordeColor, grosor, ButtonBorderStyle.Solid,   // Top
                bordeColor, grosor, ButtonBorderStyle.Solid,   // Right
                bordeColor, grosor, ButtonBorderStyle.Solid    // Bottom
            );
        }
    }
}
