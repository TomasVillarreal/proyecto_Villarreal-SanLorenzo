using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Funcion que pone lindo al sidebar. Le dibuja un borde, unicamente.
        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panelSidebar.ClientRectangle,
            Color.Transparent, 0, ButtonBorderStyle.None,  // Left
            Color.Transparent, 0, ButtonBorderStyle.None,                      // Top
            ColorTranslator.FromHtml("#E0E0E0"), 1, ButtonBorderStyle.Solid,                      // Right
            Color.Transparent, 0, ButtonBorderStyle.None                       // Bottom
            );
        }

        // Funcion para iniciar el timer.
        public void IniciarTimerBackup(int milisegundos, string ruta)
        {
            // Iniciamos el timer, y ponemos al intervalo a los milisegundos pasado como argumento,
            timerBackup.Enabled = true;
            timerBackup.Interval = milisegundos;

            /*
             * Cada vez que se cumple un intervalo, realizamos un backup con la ruta pasada como argumento.
             * Esta funcion es una funcion lambda, asi puedo usar el argumento de ruta sin tener que mandarlo
             * como argumento de alguna forma, en caso de que la cree como una funcion aparte.
             */
            timerBackup.Tick += (s, e) =>
            {
                RealizarBackup(ruta);
            };

            timerBackup.Start();
        }

        // Paramos el timer.
        public void PararTimer()
        {
            timerBackup.Stop();
            timerBackup.Enabled = false;
        }

        // Devuelve un booleano en base a si el enabled del timer.
        public bool MarchaTimer()
        {
            return timerBackup.Enabled;
        }

        // Funcion que "realiza" el backup.
        public void RealizarBackup(string ruta)
        {
            MessageBox.Show("Se ha realizado un backup!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Funcion utilizada por un monton de usercontrol que nos permite acceder a un usercontrol pasado como argumento, junto a otros datos.
        private void UserControlProyecto_AbrirOtroControl(object sender, AbrirEdicionEventArgs e)
        {
            // Limpio el panel default que se encuentra en el form1.
            panelDefault.Controls.Clear();
            // Si el control pasado como argumento existe, entonces lo coloco en el panel default.
            if (e.control != null)
            {
                e.control.Dock = DockStyle.Fill;
                panelDefault.Controls.Add(e.control);
            }
        }

        // Si se actualiza el tamaño del form1, entonces simplemente redibujo el borde del sidebar.
        private void Form1_Resize(object sender, EventArgs e)
        {
            panelSidebar.Invalidate();
            panelSidebar.Update();
        }

        // De aca en adelante la mayoria de funciones son las mismas, explicare una nomas.
        // Funcion que nos lleva al usercontrol de pacientes si se aprieta ese boton en el sidebar.
        private void bPacientes_Click(object sender, EventArgs e)
        {
            // Limpio lo que se encontraba en el panel default de forma previa.
            panelDefault.Controls.Clear();
            // Creo el usercontrol. 
            PacientesControl pacientesControl = new PacientesControl();
            // Le suscribo el evento para poder cambiar a otro user control a su atributo.
            pacientesControl.AbrirOtroControl += UserControlProyecto_AbrirOtroControl;
            // Relleno el panel default con este usercontrol.
            pacientesControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(pacientesControl);
        }

        // Funcion que le pone unos bordes al panel default.
        private void panelDefault_Paint(object sender, PaintEventArgs e)
        {
            Color bordeColor = ColorTranslator.FromHtml("#C0C0C0");

            int grosor = 1; // Grosor del borde

            // Dibuja el borde
            ControlPaint.DrawBorder(
                e.Graphics,
                panelDefault.ClientRectangle,
                bordeColor, grosor, ButtonBorderStyle.Solid,   // Left
                bordeColor, grosor, ButtonBorderStyle.Solid,   // Top
                bordeColor, grosor, ButtonBorderStyle.Solid,   // Right
                bordeColor, grosor, ButtonBorderStyle.Solid    // Bottom
            );
        }

        private void bBackup_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            BackupControl backupControl = new BackupControl();
            backupControl.EstablecerFormPadre(this);
            backupControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(backupControl);
        }

        private void bAgregarPersonal_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            PersonalControl pesonalControl = new PersonalControl();
            pesonalControl.AbrirOtroControl += UserControlProyecto_AbrirOtroControl;
            pesonalControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(pesonalControl);
        }

        private void bHome_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            HomeControl homeControl = new HomeControl();
            homeControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(homeControl);
        }

        // Esta funcion al cargar el form1 carga automaticamente al dashboard.
        private void Form1_Load(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            HomeControl homeControl = new HomeControl();
            homeControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(homeControl);
        }
    }
}
