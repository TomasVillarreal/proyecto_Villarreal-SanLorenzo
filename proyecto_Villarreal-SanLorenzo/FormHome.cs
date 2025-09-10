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
        }
        private void FormHome_Load(object sender, EventArgs e)
          {
              CargarDatosUsuario();
          }

          private void CargarDatosUsuario()
          {
                //Verifica si existe sesion activa
                if (SesionUsuario.SesionActiva())
                {
                    string nombre_rol = SesionUsuario.nombre_rol;
                    string nombre_completo = $"{SesionUsuario.nombre_usuario} {SesionUsuario.apellido_usuario}";

                    lRol.Text = nombre_rol;
                    lNombreUsuario.Text = nombre_completo;
                }
                else
                {
                    // En caso en que la sesión no esté activa
                    MessageBox.Show("No se encontró información de la sesión.");
                }
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

        private void FormHome_Resize(object sender, EventArgs e)
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
