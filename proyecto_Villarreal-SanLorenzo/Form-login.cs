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
        private bool passVisible = false; //Utilizado para el btn que muestra la oculta el password.

        public Form_login()
        {
            InitializeComponent();
        }
        public static int VerifCredenciales(string email_usuario, string password)
        {
            //Cadena de conexión
            string connectionStirng = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            // Consulta a la bd por el 'password' ingresado de acuerdo al 'email' ingresado
            string queryVerif = @"
                                SELECT u.id_usuario AS id_usuario,
                                       u.password_usuario AS password,
                                       u.nombre_usuario AS nombre_usuario,
                                       u.apellido_usuario AS apellido_usuario,
                                       u.telefono AS telefono_usuario,
                                       u.email_usuario AS email_usuario,
                                       u.id_rol AS id_rol,
                                       u.id_especialidad AS id_especialidad,
                                       e.nombre_especialidad AS nombre_especialidad,
                                       r.nombre_rol AS nombre_rol
                                FROM Usuarios AS u
                                JOIN Rol AS r ON u.id_rol = r.id_rol
                                JOIN Especialidad AS e ON u.id_especialidad = e.id_especialidad
                                WHERE u.email_usuario = @email";

            //Crea la conexión con la base de datos
            using (SqlConnection connection = new SqlConnection(connectionStirng))
            {
                //Comando que asocia la consulta con la conexión
                using (SqlCommand cmd = new SqlCommand(queryVerif, connection))
                {
                    //Asocia el valor del parametro con el valor en la base de datos
                    cmd.Parameters.AddWithValue("@email", email_usuario);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string contraseñaAlmacenada = reader["password"].ToString();

                            if (password == contraseñaAlmacenada)
                            {
                                //Se almacenan los datos del usuario
                                SesionUsuario.IniciarSesion(
                                    Convert.ToInt32(reader["id_usuario"]),
                                    Convert.ToInt32(reader["id_rol"]),
                                    reader["nombre_usuario"].ToString(),
                                    reader["apellido_usuario"].ToString(),
                                    reader["nombre_rol"].ToString(),
                                    Convert.ToInt64(reader["telefono_usuario"]),
                                    reader["email_usuario"].ToString()
                                );

                                return SesionUsuario.id_usuario;
                            }
                            reader.Close();

                        }
                        return 0; //El usuario no existe o contraseña incorrecta
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al verificar credenciales: " + ex.Message);
                        return -1;
                    }
                }
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

            if (id_usuario > 0)
            {
                //Credenciales correctas, se obtuvo el id del usuario e ingresa a la app
                FormHome formHome = new FormHome();
                formHome.Show();

                this.Hide();
            }
            else if (id_usuario == 0)
            {
                //El usuario no existe o contraseña incorrecta
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
