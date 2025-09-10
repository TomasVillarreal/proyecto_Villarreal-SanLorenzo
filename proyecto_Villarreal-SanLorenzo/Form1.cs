using System.Data.SqlClient;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class Form1 : Form
    {        
        private void Form1_Load(object sender, EventArgs e)
        {
           // cargarDatosUsuario();

        }

        private void CargarDatosUsuario()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal-SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            string queryUsuario = "SELECT nombre,apellido,id_rol FROM Usuario WHERE id_usuario = @id_usuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryUsuario, connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@id_usuario", SesionUsuario.Id_usuario);

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            //Se guarda el rol del usuario (representado por su id)
                            int rol = Convert.ToInt32(reader["id_rol"]);

                            if(rol == 1)
                            {
                                lRolUsuario.Text = "Gerente";

                            }else if(rol == 2)
                            {
                                lRolUsuario.Text = "Médico";
                            }else if(rol == 3)
                            {
                                lRolUsuario.Text = "Gerente";
                            }

                                
                           

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

        }
       // lNombreUsuario.Text = reader["nombre"].ToString() + " " + reader["apellido"].ToString();
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
