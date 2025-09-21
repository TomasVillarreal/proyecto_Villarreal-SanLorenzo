using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    // Clase creada para los botones que se encuentran en el sidebar, tal que estos sean uniformes.
    public class BotonSidebar : Button
    {
        // Atributos que representan las propiedades de los botones.

        // Este es el tamaño del radio de los bordes del boton, tal que los botones esten redondeados.
        public int BorderRadius { get; set; } = 10;

        // Una serie de colores que puede tener el boton.
        public Color NormalColor { get; set; } = Color.White; // fondo base
        public Color HoverColor { get; set; } = ColorTranslator.FromHtml("#E0E0E0");
        public Color ClickColor { get; set; } = ColorTranslator.FromHtml("#C0C0C0");

        // Booleanos que nos permitiran saber el estado en el cual se encuentra el boton.
        public bool IsActive { get; set; } = false; // Si el boton esta activo
        private bool isHover = false; // Si se pasa el mouse sobre el boton
        private bool isPressed = false; // Si el boton es apretado

        // Cuando se crea el boton, realizamos lo siguiente.
        public BotonSidebar()
        {
            // Se le coloca el estilo del boton a un estilo flat por defecto para poder modificar cosas de este
            this.FlatStyle = FlatStyle.Flat;
            // Se le pone el borde que tiene por defecto a 0
            this.FlatAppearance.BorderSize = 0;
            // Hace que el boton no sea afectado por el TAB, si el usuario aprieta al tab.
            this.TabStop = false;
            // Se activa la propiedad para que se puedan pintar los bordes sin que este parpadee
            this.DoubleBuffered = true; 

            // Suscribimos eventos
            this.MouseEnter += (s, e) => { isHover = true; Invalidate(); };
            this.MouseLeave += (s, e) => { isHover = false; Invalidate(); };
            this.MouseDown += (s, e) => { isPressed = true; Invalidate(); };
            this.MouseUp += (s, e) => { isPressed = false; Invalidate(); };
            this.Resize += (s, e) => UpdateRegion();
        }

        // Funcion que le asigna unos bordes redondeados al boton, con el valor que tiene el atributo.
        private void UpdateRegion()
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, BorderRadius, BorderRadius), 180, 90);
            path.AddArc(new Rectangle(Width - BorderRadius, 0, BorderRadius, BorderRadius), 270, 90);
            path.AddArc(new Rectangle(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius), 0, 90);
            path.AddArc(new Rectangle(0, Height - BorderRadius, BorderRadius, BorderRadius), 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        // Funcion que es ejecutada cada vez que se necesita pintar el boton
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Se elige el color segun el estado en el cual se encuentra el boton.
            Color fillColor = NormalColor;
            if (IsActive) fillColor = ClickColor;
            else if (isPressed) fillColor = ClickColor;
            else if (isHover) fillColor = HoverColor;

            // Se pinta el fondo del boton con el color elegido
            using (SolidBrush brush = new SolidBrush(fillColor))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            // Se calcula el tamaño para poder poner imagenes y el texto, tal que estos queden bien.
            Size textSize = TextRenderer.MeasureText(this.Text, this.Font);
            int spacing = 30; // espacio entre imagen y texto
            int totalWidth = textSize.Width;
            if (this.Image != null)
                totalWidth += this.Image.Width + spacing;

            int startX = (this.Width - totalWidth) / 2;
            int centerY = this.Height / 2;

            // Se dibuja la imagen, si es que existe.
            if (this.Image != null)
            {
                int imgY = centerY - (this.Image.Height / 2);
                g.DrawImage(this.Image, startX, imgY, this.Image.Width, this.Image.Height);
                startX += this.Image.Width + spacing;
            }

            // Se dibuja el texto.
            TextRenderer.DrawText(
                g,
                this.Text,
                this.Font,
                this.ClientRectangle,
                this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }
    }
}
