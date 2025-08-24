namespace proyecto_Villarreal_SanLorenzo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panelSidebar.ClientRectangle,
            Color.Transparent, 0, ButtonBorderStyle.None,  // Left
            Color.Transparent, 0, ButtonBorderStyle.None,                      // Top
            ColorTranslator.FromHtml("#E0E0E0"), 1, ButtonBorderStyle.Solid,                      // Right
            Color.Transparent, 0, ButtonBorderStyle.None                       // Bottom
            );
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panelSidebar.Invalidate();
            panelSidebar.Update();
        }
    }
}
