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

        private void bCerrarSesion_Click(object sender, EventArgs e)
        {
            //Llama al metodo el cual cierra la sesion.
            SesionUsuario.CerrarSesion();

            //Luego redirige al usuario al form-login
            Form_login formLogin = new Form_login();
            formLogin.Show();
            this.Close();
        }
    }
}
