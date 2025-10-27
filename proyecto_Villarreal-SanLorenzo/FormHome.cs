using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class FormHome : Form
    {

        string connectionString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True;";

        public FormHome()
        {
            InitializeComponent();
            this.Load += FormHome_Load;
        }
        // Evento que al apenas cargar el form, se coloca el home y se le asigna el evento para cambiar de control
        private void FormHome_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            panelDefault.Controls.Clear();
            HomeControl homeControl = new HomeControl();
            homeControl.AbrirOtroControl += UserControlProyecto_AbrirOtroControl;
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

            bCambiarRol.Visible = SesionUsuario.Roles.Count > 1;
            switch (SesionUsuario.RolActivo)
            {
                case "Gerente":
                    bHistorial.Visible = true;
                    bPacientes.Visible = true;
                    bUsuarios.Visible = true;
                    bInforme.Visible = true;
                    bAgregarPersonal.Visible = true;
                    bBackup.Visible = true;
                    bCerrarSesion.Visible = true;
                    break;
                case "Medico":
                case "Enfermero":
                    bHistorial.Visible = true;
                    bPacientes.Visible = true;
                    bUsuarios.Visible = false;
                    bInforme.Visible = true;
                    bAgregarPersonal.Visible = false;
                    bBackup.Visible = false;
                    bCerrarSesion.Visible = true;
                    break;
                case "Administrativo":
                    bHistorial.Visible = true;
                    bPacientes.Visible = true;
                    bUsuarios.Visible = false;
                    bInforme.Visible = false;
                    bAgregarPersonal.Visible = false;
                    bBackup.Visible = false;
                    bCerrarSesion.Visible = true;
                    break;

                default:
                    bHistorial.Visible = false;
                    bPacientes.Visible = false;
                    bUsuarios.Visible = false;
                    bInforme.Visible = false;
                    bAgregarPersonal.Visible = false;
                    bBackup.Visible = false;
                    bCerrarSesion.Visible = true;
                    break;
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

        // Funcion que realiza el backup.
        public void RealizarBackup(string ruta)
        {
            /* Creo el nombre del archivo backup que se va a crear, poniendo 
             * el nombre de Backups Clinicks, junto con la fecha de hoy,
             *  y la hora actual, formateando a esta fecha con simbolos permitidos
             *  para colocarlos como nombre */
            string nombreArchivo = $"Backup Clinicks - {DateTime.Now.ToString("yyyy-MM-dd HH-mm")}.bak";
            // Combino a este nombre con la ruta elegida por el usuario para tener la ruta que va a ser usada para hacer el backup
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);

            try
            {
                /* 
                 * Creo la query para hacer el backup sobre la bd que usamos,
                 * con la ruta completa hecha anteriormente, y la ejecuto
                 */
                string query = $@"
                    BACKUP DATABASE [proyecto_Villarreal_SanLorenzo]
                    TO DISK = '{rutaCompleta}'
                    WITH FORMAT, INIT,
                         NAME = 'Backup Clinicks - {DateTime.Now.ToString("yyyy-MM-dd HH-mm")}',
                         SKIP, NOREWIND, NOUNLOAD, STATS = 10;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Backup realizado con éxito.",
                        "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en la base de datos: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        // Evento que ocurre al clickear en el boton para ver los informes
        private void bInforme_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            // Si el usuario actual tiene el rol de medico o enfermero cargo un informe particular
            if (SesionUsuario.RolActivo.ToLower() == "medico" || SesionUsuario.RolActivo.ToLower() == "enfermero")
            {
                InformeMedicosEnfermeros informe = new InformeMedicosEnfermeros();
                informe.Dock = DockStyle.Fill;
                panelDefault.Controls.Add(informe);
                // Si es gerente, cargo el otro tipo de informe.
            }
            else if (SesionUsuario.RolActivo.ToLower() == "gerente")
            {
                InformeControl informe = new InformeControl();
                informe.Dock = DockStyle.Fill;
                panelDefault.Controls.Add(informe);
            }

        }
        private void bBackup_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            BackupControl backupControl = new BackupControl();
            backupControl.EstablecerFormPadre(this);
            backupControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(backupControl);
        }

        private void bHistorial_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            HistorialClinicoControl historialControl = new HistorialClinicoControl();
            historialControl.AbrirOtroControl += UserControlProyecto_AbrirOtroControl;
            historialControl.Dock = DockStyle.Fill;
            panelDefault.Controls.Add(historialControl);
        }

        private void bHome_Click(object sender, EventArgs e)
        {
            panelDefault.Controls.Clear();
            HomeControl homeControl = new HomeControl();
            homeControl.AbrirOtroControl += UserControlProyecto_AbrirOtroControl;
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

        // Metodo para cambiar de rol, en caso de q el usuario tenga mas de 2 roles
        private void bCambiarRol_Click(object sender, EventArgs e)
        {
            // Primero oculto el form del home, por seguridad
            this.Hide();
            // Creo nuevamente el form para seleccionar el rol
            using (FormSeleccionRol formRol = new FormSeleccionRol(SesionUsuario.Roles))
            {
                // Si el dialogo del form para cambiar de rol es presionado
                if (formRol.ShowDialog() == DialogResult.OK)
                {
                    // Cambio el rol activo del usuario
                    SesionUsuario.RolActivo = formRol.RolSeleccionado;
                    // Y croe nuevamente este form home
                    FormHome nuevoHome = new FormHome();
                    nuevoHome.Show();
                    // Y elimino el form home con el rol viejo
                    this.Close();
                }
                // Sino le decimos al usuario que tiene q ingresar un rol
                else
                {
                    MessageBox.Show("Debes seleccionar un rol para continuar.");
                    this.Close();
                    return;
                }
            }
        }
    }
}
