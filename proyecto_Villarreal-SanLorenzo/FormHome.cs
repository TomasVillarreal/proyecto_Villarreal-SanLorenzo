using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            this.Load += FormHome_Load;
        }
        private void FormHome_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            panelDefault.Controls.Clear();
            HomeControl homeControl = new HomeControl();
            homeControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(homeControl);
        }
        private void CargarDatosUsuario()//Carga los datos del usuario en sesion
        {
            if (SesionUsuario.SesionActiva())
            {
                string nombre_completo = $"{SesionUsuario.nombre_usuario} {SesionUsuario.apellido_usuario}";

                if (string.IsNullOrEmpty(SesionUsuario.RolActivo))
                {
                    if (SesionUsuario.Roles.Count == 1)
                    {
                        SesionUsuario.RolActivo = SesionUsuario.Roles[0];
                    }
                    else if (SesionUsuario.Roles.Count > 1)
                    {
                        using (FormSeleccionRol formRol = new FormSeleccionRol(SesionUsuario.Roles))
                        {
                            if (formRol.ShowDialog() == DialogResult.OK)
                            {
                                SesionUsuario.RolActivo = formRol.RolSeleccionado;
                            }
                            else
                            {
                                MessageBox.Show("Debes seleccionar un rol para continuar.");
                                this.Close();
                                return;
                            }
                        }
                    }
                }

                lRol.Text = SesionUsuario.RolActivo;
                lNombreUsuario.Text = nombre_completo;
            }
            else
            {
                MessageBox.Show("No se encontró información de la sesión.");
            }

            if (SesionUsuario.RolActivo != "Gerente")
            {
                bAgregarPersonal.Visible = false;
                bUsuarios.Visible = false;
            }
            else
            {
                bAgregarPersonal.Visible = true;
                bUsuarios.Visible = true;
            }
        }
        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panelSidebar.ClientRectangle,
            Color.Transparent, 0, ButtonBorderStyle.None,
            Color.Transparent, 0, ButtonBorderStyle.None,
            ColorTranslator.FromHtml("#E0E0E0"), 1, ButtonBorderStyle.Solid,
            Color.Transparent, 0, ButtonBorderStyle.None
            );
        }
        private void FormHome_Resize(object sender, EventArgs e)
        {
            panelSidebar.Invalidate();
            panelSidebar.Update();
        }
        private void bCerrarSesion_Click(object sender, EventArgs e)
        {
            //Llama al metodo el cual cierra la sesion.
            SesionUsuario.CerrarSesion();

            Form_login formLogin = new Form_login();
            formLogin.Show();
            this.Close();
        }
        private void bAgregarPersonal_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            NuevoUsuarioControl usuarioControl = new NuevoUsuarioControl();
            usuarioControl.AbrirOtroControl += UserControlProyecto_AbrirOtroControl;
            usuarioControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(usuarioControl);
        }
        private void bUsuarios_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            VerUsuarioControl verUsuario = new VerUsuarioControl();
            verUsuario.AbrirOtroControl += UserControlProyecto_AbrirOtroControl;
            verUsuario.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(verUsuario);
        }

        // Funcion para iniciar el timer.
        public void IniciarTimerBackup(int milisegundos, string ruta)
        {
            // Iniciamos el timer, y ponemos al intervalo a los milisegundos pasado como argumento,
            timerBackup.Enabled = true;
            timerBackup.Interval = milisegundos;

            /*

        Cada vez que se cumple un intervalo, realizamos un backup con la ruta pasada como argumento.
        Esta funcion es una funcion lambda, asi puedo usar el argumento de ruta sin tener que mandarlo
        como argumento de alguna forma, en caso de que la cree como una funcion aparte.*/
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
        private void bBackup_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            BackupControl backupControl = new BackupControl();
            backupControl.EstablecerFormPadre(this);
            backupControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(backupControl);
        }

        private void bHome_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            HomeControl homeControl = new HomeControl();
            homeControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(homeControl);
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
    }
}
