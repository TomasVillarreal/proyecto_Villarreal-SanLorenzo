using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class Form_login : Form
    {
        private bool passVisible = false; //Utilizado para el btn que muestra/ oculta el password.

        public Form_login()
        {
            InitializeComponent();
        }
        public static int VerifCredenciales(string email_usuario, string password)//Metodo que verifica las credenciales del usuario y carga sus datos
        {
            string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            string queryUser = @"
                                SELECT u.id_usuario,
                                       u.password_usuario,
                                       u.nombre_usuario,
                                       u.apellido_usuario,
                                       u.telefono_usuario,
                                       u.email_usuario
                                FROM Usuarios AS u
                                WHERE u.email_usuario = @email AND u.activo = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(queryUser, connection))
            {
                cmd.Parameters.AddWithValue("@email", email_usuario);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string contraseñaAlmacenada = reader["password_usuario"].ToString();

                        if (BCrypt.Net.BCrypt.Verify(password, contraseñaAlmacenada))
                        {
                            int id_usuario = Convert.ToInt32(reader["id_usuario"]);

                            SesionUsuario.IniciarSesion(
                                id_usuario,
                                reader["nombre_usuario"].ToString(),
                                reader["apellido_usuario"].ToString(),
                                reader["email_usuario"].ToString(),
                                reader["telefono_usuario"].ToString()
                            );

                            reader.Close();

                            CargarRolesYEspecialidades(id_usuario, connection);

                            return id_usuario;
                        }
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar credenciales: " + ex.Message);
                    return -1;
                }
            }
        }

        private static void CargarRolesYEspecialidades(int idUsuario, SqlConnection connection)//Metodo que carga los roles y especialidades (si es que tiene)
        {
            string query = @"
                            SELECT r.nombre_rol, e.nombre_especialidad
                            FROM Usuario_rol ur
                            JOIN Rol r ON ur.id_rol = r.id_rol
                            LEFT JOIN Usuario_especialidad ue ON ur.id_usuario = ue.id_usuario
                            LEFT JOIN Especialidades e ON ue.id_especialidad = e.id_especialidad
                            WHERE ur.id_usuario = @idUsuario";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string rol = reader["nombre_rol"].ToString();
                    string especialidad = reader["nombre_especialidad"] != DBNull.Value ? reader["nombre_especialidad"].ToString() : null;

                    SesionUsuario.Roles.Add(rol);
                    if (especialidad != null)
                        SesionUsuario.Especialidades.Add(especialidad);
                }

                reader.Close();
            }
        }


        private void bIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text.Trim();
            string password = tbPass.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe completar todos los campos!",
                    "Error inicio de sesión", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int id_usuario = VerifCredenciales(usuario, password);

            if (id_usuario > 0) //Credenciales correctas, se obtuvo el id del usuario e ingresa a la app
            {
                FormHome formHome = new FormHome();
                formHome.Show();

                this.Hide();
            }
            else if (id_usuario == 0)//El usuario no existe o contraseña incorrecta
            {
                MessageBox.Show("Credenciales incorrectas. Intente nuevamente",
                    "Error inicio de sesión", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                tbUsuario.Clear();
                tbPass.Clear();
            }
        }

        private void bMostrarPass_Click(object sender, EventArgs e)
        {
            if (passVisible == false)
            {
                tbPass.PasswordChar = '\0';
                bMostrarPass.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoCerrado;
                passVisible = true;
            }
            else
            {
                tbPass.PasswordChar = '*';
                bMostrarPass.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoAbierto;
                passVisible = false;
            }
        }//Metodo que muestra/oculta la contraseña

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//Metodo que mediante un boton cierra la aplicacion
    }
}
