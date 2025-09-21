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
using BCrypt.Net; //Usado para hashear el password

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class Form_nuevo_usuario : Form
    {
        private bool passVisible = false; //Utilizado para el btn que muestra la oculta el password.
        public Form_nuevo_usuario()
        {
            this.InitializeComponent();
            CargarRoles();
            CargarEspecialidades();
        }

        private void botonSidebar2_Click(object sender, EventArgs e)
        {
            Form_nuevo_usuario formularioUsuarios = new Form_nuevo_usuario();
            formularioUsuarios.Show();
            this.Close();
        }

        private int ObtenerIdEspecialidad(string nombre_especialidad)//Metodo con el cual se obtiene la especialidad del usuario nuevo
        {
            string connectionStirng = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionStirng))
            {
                connection.Open();

                using (SqlCommand cmdBuscar = new SqlCommand("SELECT id_especialidad FROM Especialidades WHERE nombre_especialidad = @nombreEspecialidad", connection))
                {
                    cmdBuscar.Parameters.AddWithValue("@nombre_especialidad", nombre_especialidad);

                    object result = cmdBuscar.ExecuteScalar();

                    if (result != null)
                    {
                        return (int)result;//Por ende la especialidad existe
                    }
                    else//Es una nueva especialidad que se agrega a la tabla
                    {

                        using (SqlCommand cmdInsertar = new SqlCommand("INSERT INTO Especialidades (nombre_especialidad) UTPUT INSERTED.id_especialidad VALUES(@nombre_especialidad)", connection))
                        {
                            cmdInsertar.Parameters.AddWithValue("@nombre_especialidad", nombre_especialidad);

                            return (int)cmdInsertar.ExecuteScalar();
                        }
                    }
                }
            }
        }
        private int ObtenerIdRol(string nombre_rol)//Metodo con el cual se obtiene el rol del usuario nuevo
        {
            string connectionStirng = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionStirng))
            {
                connection.Open();

                using (SqlCommand cmdBuscar = new SqlCommand("SELECT id_rol FROM Rol WHERE nombre_rol = @nombreRol", connection))
                {
                    cmdBuscar.Parameters.AddWithValue("@nombreRol", nombre_rol);

                    object result = cmdBuscar.ExecuteScalar();

                    if (result != null)
                    {
                        return (int)result;//Por ende el rol existe
                    }
                    else//Es un rol nuevo que se agrega a la tabla
                    {

                        using (SqlCommand cmdInsertar = new SqlCommand("INSERT INTO Rol (nombre_rol) UTPUT INSERTED.id_rol VALUES(@nombreRol)", connection))
                        {
                            cmdInsertar.Parameters.AddWithValue("@nombreRol", nombre_rol);

                            return (int)cmdInsertar.ExecuteScalar();
                        }
                    }
                }
            }
        }


        private void bRegistrarUsuario_Click(object sender, EventArgs e, CancelEventArgs c)
        {
            ValidarComboboxes();
            int? especialidad = null;


            if (!tbEmail.Text.Contains("@"))//Verifica si el usuario ingreso el carácter '@' en el email.
            {
                MessageBox.Show("El correo electrónico debe contener un '@'.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                c.Cancel = true;

                tbEmail.Clear();
            }

            if (!string.IsNullOrWhiteSpace(comboBoxEsp.Text))//Verifica si se seleccionó una especialidad
            {
                especialidad = ObtenerIdEspecialidad(comboBoxEsp.Text.Trim());
            }

            int id_rol = ObtenerIdRol(comboBoxRoles.Text);
            string nombreUsuario = tbNomUsuario.Text.Trim().ToLower();
            string apellidoUsuario = tbApellidoUsuario.Text.Trim().ToLower();
            string emailUsuario = tbEmail.Text.Trim().ToLower();
            string telefono_string = tbTelefono.Text.Trim();
            long telefono_usuario = Convert.ToInt64(telefono_string);//Este se guarad en la bd
            string password_usuario = tbPassUsuario.Text;
            string password_usuario_hash = HashPassword(password_usuario);//Este se guarad en la bd


            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(apellidoUsuario) || string.IsNullOrEmpty(emailUsuario) ||
                string.IsNullOrEmpty(telefono_string) || string.IsNullOrEmpty(password_usuario))
            {
                MessageBox.Show("Debe completar todos los campos!",
                    "Error inicio de sesión", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CrearUsuario(id_rol, especialidad, nombreUsuario, apellidoUsuario, emailUsuario, telefono_usuario, password_usuario_hash);
        }

        //Creacion del usuario
        public static void CrearUsuario(int rol, int? especialidad, string nombre, string apellido, string email, long telefono, string password)
        {
            string connectionStirng = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connecction = new SqlConnection(connectionStirng))
            {
                connecction.Open();
                SqlTransaction transaction = connecction.BeginTransaction();

                try
                {
                    //1) Insertar en Usuarios
                    string queryNuevoUsuario = @"
                                                INSERT INTO Usuarios (nombre_usuario, apellido_usuario, email_usuario, telefono_usuario, password_usuario)
                                                OUTPUT INSERTED.id_usuario
                                                VALUES (@nombre_usuario,@apellido_usuario,@email_usuario,@telefono,@password_usuario)";

                    int id_usuario;
                    using (SqlCommand cmd = new SqlCommand(queryNuevoUsuario, connecction, transaction))
                    {
                        cmd.Parameters.AddWithValue("@nombre_usuario", nombre);
                        cmd.Parameters.AddWithValue("@apellido_usuario", apellido);
                        cmd.Parameters.AddWithValue("@email_usuario", email);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@password_usuario", password);

                        id_usuario = (int)cmd.ExecuteScalar();
                    }

                    //2) Insertar en Usuario_rol
                    string queryUsuarioRol = "INSERT INTO Usuario_rol (id_usuario, id_rol) VALUES (@id_usuario, @id_rol)";
                    using (SqlCommand cmdRol = new SqlCommand(queryUsuarioRol, connecction, transaction))
                    {
                        cmdRol.Parameters.AddWithValue("@id_usuario", id_usuario);
                        cmdRol.Parameters.AddWithValue("@id_rol", rol);
                        cmdRol.ExecuteNonQuery();
                    }

                    //3) Insertar en Usuario_especialidad (en caso de que el usuario tenga una)
                    if (especialidad.HasValue)
                    {
                        string queryUsuarioEsp = "INSERT INTO Usuario_especialidad (id_usuario, id_especialidad) VALUES (@id_usuario, @id_especialidad)";
                        using (SqlCommand cmdEsp = new SqlCommand(queryUsuarioEsp, connecction, transaction))
                        {
                            cmdEsp.Parameters.AddWithValue("@id_usuario", id_usuario);
                            cmdEsp.Parameters.AddWithValue("@id_especialidad", especialidad.Value);
                            cmdEsp.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();//Confirma la transacción

                    MessageBox.Show("Usuario registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CargarRoles() //Metodo que carga los roles al combobox
        {
            string connectionStirng = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connecction = new SqlConnection(connectionStirng))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id_rol, nombre_rol FROM Rol", connecction))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    comboBoxRoles.DataSource = dataTable;
                    comboBoxRoles.DisplayMember = "nombre_rol";
                    comboBoxRoles.ValueMember = "id_rol";

                }
                try
                {
                    connecction.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los roles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void CargarEspecialidades()//Metodo que carga las especialidades al combobox
        {
            string connectionStirng = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connecction = new SqlConnection(connectionStirng))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id_especialidad, nombre_especialidad FROM Especialidades", connecction))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    comboBoxEsp.DataSource = dataTable;
                    comboBoxEsp.DisplayMember = "nombre_especialidad";
                    comboBoxEsp.ValueMember = "id_especialidad";

                }
                try
                {
                    connecction.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las especialidades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void botonSidebar3_Click(object sender, EventArgs e)
        {
            //Llama al metodo el cual cierra la sesion.
            SesionUsuario.CerrarSesion();

            //Luego redirige al usuario al form-login
            Form_login formLogin = new Form_login();
            formLogin.Show();
            this.Close();
        }
        private void tbNomUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')//Permite letras, la tecla de retroceso y espacio en caso de nombres compuestos
            {
                e.Handled = true;
            }
        }//Metodo que controla los datos ingresados en el textbox
        private void tbApellidoUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }//Metodo que controla los datos ingresados en el textbox
        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))//Permite que el usuario solo ingrese numeros (0-9) y la tecla de retroceso
            {
                e.Handled = true;
            }
        }//Metodo que controla los datos ingresados en el textbox
        private void bMostrarPass1_Click(object sender, EventArgs e)
        {
            if (passVisible == false)
            {
                tbConfirmPass.PasswordChar = '\0';
                bMostrarPass1.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoCerrado;
                passVisible = true;
            }
            else
            {
                tbConfirmPass.PasswordChar = '*';
                bMostrarPass1.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoAbierto;
                passVisible = false;
            }
        }//Metodo que oculta/muestra la contraseña
        private void bMostrarConfPass2_Click(object sender, EventArgs e)
        {
            if (passVisible == false)
            {
                tbConfirmPass.PasswordChar = '\0';
                bMostrarConfPass2.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoCerrado;
                passVisible = true;
            }
            else
            {
                tbConfirmPass.PasswordChar = '*';
                bMostrarConfPass2.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoAbierto;
                passVisible = false;
            }
        }//Metodo que oculta/muestra la contraseña
        private bool ValidarComboboxes()//Metodo que comprueba que los comboBox esten completos
        {
            if (string.IsNullOrWhiteSpace(comboBoxRoles.Text))
            {
                MessageBox.Show("Debe seleccionar o escribir un rol.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxRoles.Focus();
                return false;
            }

            if (comboBoxEsp.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una especialidad.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxEsp.Focus();
                return false;
            }
            return true;
        }
        private bool CheckPassword()//Metodo que compara la contraseña y la confirmacion de contraseña
        {
            string password = tbPassUsuario.Text;
            string confirmPassword = tbConfirmPass.Text;

            if (password == confirmPassword)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Error al confirmar la contraseña.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }
        private string HashPassword(string password)//Metodo que hashea el password
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));//Hashea la contraseña con una salt de 12
        }
        private bool VerfiPassword(string password, string hashedPassword)//Metodo que verifica el password con el hash
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        private void comboBoxEsp_SelectedIndexChanged(object sender, EventArgs e)//Metodo que solo muestra el comboBox de especialidad al Medico/Enfermero
        {
            string rolSeleccionado = comboBoxRoles.Text.Trim().ToLower();

            // Si el rol es Médico o Enfermero → muestro el ComboBoxEspecialidades
            if (rolSeleccionado == "médico" || rolSeleccionado == "enfermero")
            {
                comboBoxEsp.Visible = true;
                lEspecialidad.Visible = true; // si tenés una etiqueta
            }
            else
            {
                comboBoxEsp.Visible = false;
                lEspecialidad.Visible = false;
            }
        }
    }
}
