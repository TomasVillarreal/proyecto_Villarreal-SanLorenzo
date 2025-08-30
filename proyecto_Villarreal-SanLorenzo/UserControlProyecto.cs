using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    public class UserControlProyecto : UserControl
    {
        public UserControlProyecto()
        {
            // Color de fondo por defecto
            this.BackColor = ColorTranslator.FromHtml("#F5F5F5");

            // Activar doble buffer para evitar parpadeos al pintar
            this.DoubleBuffered = true;

            // Enganchar evento Paint para dibujar borde
            this.Paint += UserControlProyecto_Paint;

            this.Size = new Size(768, 575);
        }

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
