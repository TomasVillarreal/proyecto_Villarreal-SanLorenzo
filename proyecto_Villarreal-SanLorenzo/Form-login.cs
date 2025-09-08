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
        private bool passVisibile = false; //Utilizado para el btn que muestra la oculta el password.

        public Form_login()
        {
            InitializeComponent();
        }
        public static bool VerifCredenciales(string nombreUsuario, string password)
        {
            string connectionStirng = "Data Source=localhost;Initial Catalog=proyecto_Villarreal-SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            string queryVerif = "SELECT password FROM Usuario WHERE nombre = @nombreUsuario";

            using (SqlConnection connection = new SqlConnection(connectionStirng))
            {
                using (SqlCommand cmd = new SqlCommand(queryVerif, connection))
                {
                    cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario); // Corregido

                    try
                    {
                        connection.Open();
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            string contraseñaAlmacenada = resultado.ToString();
                            return (password == contraseñaAlmacenada);
                        }
                        else
                        {
                            return false; // El usuario no existe
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al verificar credenciales: " + ex.Message);
                        return false;
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

            if (VerifCredenciales(usuario, password))
            {
                Form1 formHome = new Form1();
                formHome.Show();

                this.Hide();
            }
            else
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
            if(passVisibile == false)
            {
                tbPass.PasswordChar = '\0';
                bMostrarPass.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoCerrado;
                passVisibile = true;
            }
            else
            {
                tbPass.PasswordChar = '*';
                bMostrarPass.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoAbierto;
                passVisibile = false;
            }
        }
    }
}
