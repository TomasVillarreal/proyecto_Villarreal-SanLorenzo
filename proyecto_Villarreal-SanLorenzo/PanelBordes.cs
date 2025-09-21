using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    // Clase creada para hacer que los paneles dentro de los usercontrol, tal que estos contienen datos
    // sean uniformes entre si
    public class PanelBordes : Panel
    {
        // Cuando se crea este tipo de panel:
        public PanelBordes()
        {
            // Colocamos un color de fondo por defecto
            this.BackColor = Color.White;

            // Se activa la prop que evita que haya parpadeos al pintar los bordes.
            this.DoubleBuffered = true;

            // Se suscribe el evento de pintar los bordes.
            this.Paint += PanelBordes_Paint;
        }

        // Se pinta los bordes.
        private void PanelBordes_Paint(object sender, PaintEventArgs e)
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
