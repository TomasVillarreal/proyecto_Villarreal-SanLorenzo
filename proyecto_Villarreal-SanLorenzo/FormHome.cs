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
        }

        private void CargarDatosUsuario()
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
            Form_nuevo_usuario formularioUsuarios = new Form_nuevo_usuario();
            formularioUsuarios.Show();
            this.Close();
        }

        private void bUsuarios_Click(object sender, EventArgs e)
        {
            FormVerUsuarios formUsuarios = new FormVerUsuarios();
            formUsuarios.Show();
            this.Close();
        }
    }
}
