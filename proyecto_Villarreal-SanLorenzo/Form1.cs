using System.Windows.Forms;

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

        public void IniciarTimerBackup(int milisegundos, string ruta)
        {
            timerBackup.Enabled = true;
            timerBackup.Interval = milisegundos;

            timerBackup.Tick += (s, e) =>
            {
                RealizarBackup(ruta);
            };

            timerBackup.Start();
        }

        public void PararTimer()
        {
            timerBackup.Stop();
            timerBackup.Enabled = false;
        }

        public bool MarchaTimer()
        {
            return timerBackup.Enabled;
        }


        public void RealizarBackup(string ruta)
        {
            MessageBox.Show("Se ha realizado un backup!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Uc1_AbrirOtroControl(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            RegistrarPacienteControl registrarPaciente = new RegistrarPacienteControl();
            registrarPaciente.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(registrarPaciente);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panelSidebar.Invalidate();
            panelSidebar.Update();
        }

        private void bPacientes_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            PacientesControl pacientesControl = new PacientesControl();
            pacientesControl.AbrirOtroControl += Uc1_AbrirOtroControl;
            pacientesControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(pacientesControl);
        }

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
            PersonalControl personalControl = new PersonalControl();
            personalControl.AbrirOtroControl += Uc1_AbrirOtroControl;
            personalControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(personalControl);
        }
    }
}
