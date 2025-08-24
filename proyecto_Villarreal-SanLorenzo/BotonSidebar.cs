using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    public class BotonSidebar : Button
    {
        // Propiedades
        public int BorderRadius { get; set; } = 10;
        public Color NormalColor { get; set; } = Color.White; // fondo base
        public Color HoverColor { get; set; } = ColorTranslator.FromHtml("#E0E0E0");
        public Color ClickColor { get; set; } = ColorTranslator.FromHtml("#C0C0C0");
        public bool IsActive { get; set; } = false; // si el botón está seleccionado/activo

        private bool isHover = false;
        private bool isPressed = false;

        public BotonSidebar()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.TabStop = false;
            this.DoubleBuffered = true; // para dibujar suavemente

            // Suscribimos eventos
            this.MouseEnter += (s, e) => { isHover = true; Invalidate(); };
            this.MouseLeave += (s, e) => { isHover = false; Invalidate(); };
            this.MouseDown += (s, e) => { isPressed = true; Invalidate(); };
            this.MouseUp += (s, e) => { isPressed = false; Invalidate(); };
            this.Resize += (s, e) => UpdateRegion();
        }

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

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Elegir color según estado
            Color fillColor = NormalColor;
            if (IsActive) fillColor = ClickColor;
            else if (isPressed) fillColor = ClickColor;
            else if (isHover) fillColor = HoverColor;

            using (SolidBrush brush = new SolidBrush(fillColor))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            // 2. Calcular tamaños
            Size textSize = TextRenderer.MeasureText(this.Text, this.Font);
            int spacing = 30; // espacio entre imagen y texto
            int totalWidth = textSize.Width;
            if (this.Image != null)
                totalWidth += this.Image.Width + spacing;

            // Coordenada X inicial para centrar bloque (imagen + texto)
            int startX = (this.Width - totalWidth) / 2;
            int centerY = this.Height / 2;

            // 3. Dibujar imagen (si hay)
            if (this.Image != null)
            {
                int imgY = centerY - (this.Image.Height / 2);
                g.DrawImage(this.Image, startX, imgY, this.Image.Width, this.Image.Height);
                startX += this.Image.Width + spacing;
            }

            // Dibujar texto centrado
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
