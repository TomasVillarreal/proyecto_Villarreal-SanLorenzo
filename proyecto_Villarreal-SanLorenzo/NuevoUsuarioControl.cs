using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class NuevoUsuarioControl : UserControlProyecto
    {
        private bool passVisible1 = false;
        private bool passVisible2 = false;
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;
        public NuevoUsuarioControl()
        {
            InitializeComponent();
            CargarRoles();
            CargarEspecialidades();
        }
        private int ObtenerIdEspecialidad(string nombre_especialidad)//Metodo con el cual se obtiene la especialidad del usuario nuevo
        {
            string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmdBuscar = new SqlCommand("SELECT id_especialidad FROM Especialidades WHERE nombre_especialidad = @nombre_especialidad", connection))
                {
                    cmdBuscar.Parameters.AddWithValue("@nombre_especialidad", nombre_especialidad);

                    object result = cmdBuscar.ExecuteScalar();

                    if (result != null)
                    {
                        return (int)result;//Por ende la especialidad existe
                    }
                    else//Es una nueva especialidad que se agrega a la tabla
                    {
                        using (SqlCommand cmdInsertar = new SqlCommand("INSERT INTO Especialidades (nombre_especialidad) OUTPUT INSERTED.id_especialidad VALUES(@nombre_especialidad)", connection))
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
            string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
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

                        using (SqlCommand cmdInsertar = new SqlCommand("INSERT INTO Rol (nombre_rol) OUTPUT INSERTED.id_rol VALUES(@nombreRol)", connection))
                        {
                            cmdInsertar.Parameters.AddWithValue("@nombreRol", nombre_rol);

                            return (int)cmdInsertar.ExecuteScalar();
                        }
                    }
                }
            }
        }

        private void RegistrarUsuario()
        {
            int? especialidad = null;//Se define una variable que puede ser nula (algunos usuarios no tendran especialidad)
            Dictionary<string, object> diccionario = CrearDiccionario();

            //Se guardan los datos ingresados
            int id_rol = ObtenerIdRol(comboBoxRoles.Text);
            string nombreUsuario = diccionario["nombre"].ToString().ToLower().Trim();
            string apellidoUsuario = diccionario["apellido"].ToString().ToLower().Trim();
            string emailUsuario = diccionario["email"].ToString().ToLower().Trim();
            string telefono_string = diccionario["telefono"].ToString().Trim();
            string password_usuario = diccionario["pass"].ToString();
            string password_usuario_hash = HashPassword(password_usuario);//Este se guarad en la bd

            //Verificacion de campos vacios
            long telefono_usuario = Convert.ToInt64(telefono_string);//Este se guarad en la bd

            if (!ValidarComboboxes())
            {
                return;
            }

            if (comboBoxEsp.SelectedValue != null && comboBoxEsp.SelectedValue != DBNull.Value)
            {
                especialidad = Convert.ToInt32(comboBoxEsp.SelectedValue);
            }
            else
            {
                especialidad = null; // Sin especialidad
            }

            if (!CheckPassword())
            {
                return;
            }

            //Se cargan los datos al metodo
            CrearUsuario(id_rol, especialidad, nombreUsuario, apellidoUsuario, emailUsuario, telefono_usuario, password_usuario_hash);

            VerUsuarioControl verUsuario = new VerUsuarioControl();
            verUsuario.AbrirOtroControl += this.AbrirOtroControl;
            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, verUsuario, true));
        }

        public void bRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> diccionario = CrearDiccionario();
            if (DetectarErrores(diccionario))
            {
                RegistrarUsuario();
            }
        }

        public static void CrearUsuario(int rol, int? especialidad, string nombre, string apellido, string email, long telefono, string password)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connecction = new SqlConnection(connectionString))
            {
                connecction.Open();
                SqlTransaction transaction = connecction.BeginTransaction();

                try
                {
                    //Validar si el email ya esta registrado y muestra un mensaje
                    using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(1) FROM Usuarios WHERE email_usuario = @Email", connecction, transaction))
                    {
                        cmdCheck.Parameters.AddWithValue("@Email", email);

                        int existe = (int)cmdCheck.ExecuteScalar();
                        if (existe > 0)
                        {
                            MessageBox.Show("El correo electrónico ya está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            transaction.Rollback();
                            return;
                        }
                    }

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
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    // Este numero de excepcion indica que ha ocurrido una excepcion de PK duplicada
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Ya existe un usuario con ese ID", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Este numero de excepcioon indica que ha ocurrido un duplicado en algun campo unico
                    else if (ex.Number == 2601)
                    {
                        MessageBox.Show("Se esta intentando crear un registro con un valor unico repetido",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al intentar registrar el usuario: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }//Creacion del usuario


        //Metodos que controlan los datos ingresados en los textbox
        private void tbNomUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')//Permite letras, la tecla de retroceso y espacio en caso de nombres compuestos
            {
                e.Handled = true;
            }
        }
        private void tbApellidoUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            //permite solo dígitos y backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
            else if (e.KeyChar != (char)Keys.Back && tb.Text.Length >= 10)//si no es backspace y ya hay 10 caracteres bloquea
            {
                e.Handled = true;
                return;
            }
        }


        //Metodos que manejan los combobox
        private void CargarRoles() //Carga los roles al combobox
        {
            string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connecction = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id_rol, nombre_rol FROM Rol WHERE nombre_rol <> 'Gerente'", connecction))
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
        private void CargarEspecialidades()//Carga las especialidades al combobox
        {
            string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT id_especialidad, nombre_especialidad FROM Especialidades WHERE nombre_especialidad IS NOT NULL AND LTRIM(RTRIM(nombre_especialidad)) <> ''", connection))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                //Fila nula para usuarios sin especialidad
                DataRow filaVacia = dataTable.NewRow();
                filaVacia["id_especialidad"] = DBNull.Value;
                filaVacia["nombre_especialidad"] = "-- Sin especialidad --";
                dataTable.Rows.InsertAt(filaVacia, 0);

                comboBoxEsp.DataSource = dataTable;
                comboBoxEsp.DisplayMember = "nombre_especialidad";
                comboBoxEsp.ValueMember = "id_especialidad";
            }
        }
        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)//Si el rol es Médico o Enfermero se muestra el ComboBoxEspecialidades
        {
            string rolSeleccionado = comboBoxRoles.Text.Trim().ToLower();

            if (rolSeleccionado == "medico" || rolSeleccionado == "enfermero")
            {
                comboBoxEsp.Visible = true;
                lEspecialidad.Visible = true;
            }
            else
            {
                comboBoxEsp.Visible = false;
                lEspecialidad.Visible = false;
            }
        }
        private bool ValidarComboboxes()
        {
            //Validar roles
            if (string.IsNullOrWhiteSpace(comboBoxRoles.Text))
            {
                MessageBox.Show("Debe seleccionar o escribir un rol.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxRoles.Focus();
                return false;
            }
            else if (!comboBoxRoles.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("El rol solo puede contener letras y espacios.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxRoles.Focus();
                return false;
            }

            //Validar especialidades
            if (string.IsNullOrWhiteSpace(comboBoxEsp.Text))
            {
                MessageBox.Show("Debe seleccionar o escribir una especialidad.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxEsp.Focus();
                return false;
            }
            else if (comboBoxEsp.Visible == true && !comboBoxEsp.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("La especialidad solo puede contener letras y espacios.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxEsp.Focus();
                return false;
            }

            return true;
        }//Valid que los combobox esten completos


        //Metodos que ocultan/muestran la contraseña
        private void TogglePassword(TextBox textBox, Button button, ref bool visible)
        {
            if (visible)
            {
                textBox.PasswordChar = '*';
                button.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoAbierto;
                visible = false;
            }
            else
            {
                textBox.PasswordChar = '\0';
                button.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoCerrado;
                visible = true;
            }
        }
        private void bMostrarPass1_Click(object sender, EventArgs e)
        {
            TogglePassword(tbPassUsuario, bMostrarPass1, ref passVisible1);
        }
        private void bMostrarConfPass2_Click(object sender, EventArgs e)
        {
            TogglePassword(tbConfirmPass, bMostrarConfPass2, ref passVisible2);
        }


        //Metodos para el manejo de la contraseña
        private bool CheckPassword()//Compara la contraseña y la confirmacion de contraseña
        {
            Dictionary<string, object> diccionario = CrearDiccionario();
            string password = diccionario["pass"].ToString();
            string confirmPassword = diccionario["confirmPass"].ToString();

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
        private string HashPassword(string password)//Hashea el password
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));//Hashea la contraseña con una salt de 12
        }
        private bool VerfiPassword(string password, string hashedPassword)//Compara el password con su hash
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        // Funcion que crea un diccionario tal que sus claves seran los nombres de los distintos tipos de datos que se colocaron 
        // en el usercontrol, y cuyos valores son efectivamente estos datos
        private Dictionary<string, object> CrearDiccionario()
        {
            // Creo el diccionario, asigno las claves con los valores y lo devuelvo
            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic.Add("nombre", tbNomUsuario.Text);
            dic.Add("apellido", tbApellidoUsuario.Text);
            dic.Add("email", tbEmail.Text);
            dic.Add("telefono", tbTelefono.Text);
            dic.Add("pass", tbPassUsuario.Text);
            dic.Add("confirmPass", tbConfirmPass.Text);

            return dic;
        }

        /* Funcion que nos permite hacer dos cosas. La primera, devuelve un booleano basado en si hubo algun error
         * en los datos ingresados en los textbox, dentro de las cosas permitidas. 
         * La segunda, en base a si hubo estos errores, hace visible unos labels (anteriormente invisibles) y les 
         * modifica el texto para poder mostrarle al usuario que cosas puso mal.
        */
        private bool DetectarErrores(Dictionary<string, object> dic)
        {
            // Booleano que luego se devolvera.
            bool todoBien = true;

            // Recorro uno a uno las claves del diccionario pasado como argumento
            foreach (var clave in dic.Keys)
            {
                // Obtengo el valor que esta asociado en una clave del diccionario (en caso de que exista)
                string valor = dic[clave]?.ToString() ?? "";
                /* Creo un string que luego servira para poder acceder al label de error correspondiente
                 * a dicho tipo de dato. Este string esta formado por la primera parte que corresponde al
                 * formato del label "lError" y una segunda parte cuyo valor depende de la clave. Por ejemplo,
                 * si la clave es 'nombre', lo que hago es capitalizar la primera letra, y le concateno esto
                 * a la parte del formato, de tal forma que quede lErrorDni, tal que esto coincide con el 
                 * nombre el cual se le puso al label invisible
                 */
                string lblErrorNombre = "lError" + char.ToUpper(clave[0]) + clave.Substring(1);

                // Busco el label cuyo nombre coincide con el string creado arriba. El bool
                // pasado como argumento sirve para ver si se quiere buscar sobre todos los controles hijo.
                Control[] controles = this.Controls.Find(lblErrorNombre, true);
                // Si el vector con controles esta vacio, o si no es un label, nos salteamos esta iteracion.
                // En caso de que si sea un label, se le asigna el nombre de lblError.
                if (controles.Length == 0 || !(controles[0] is Label lblError))
                    continue;

                /*
                 * Colocamos la visibilidad del label error en falso, asi si se verifica mas de una vez
                 * al registro este no queda visible por los intentos anteriores
                 */
                lblError.Visible = false;

                // Si el valor esta vacio, mostramos mensaje de error en el label. Esto afecta a todos los tipos de dato.
                if (string.IsNullOrWhiteSpace(valor))
                {
                    lblError.Visible = true;
                    lblError.Text = "Por favor rellene este campo";
                    todoBien = false;
                }
                else
                {
                    // Si el valor no esta vacio, verificamos que tipo de dato es y mostramos un dato diferente en cada caso
                    switch (clave)
                    {
                        case "telefono":
                            // Si el telefono es distinto de diez, o hay caracteres que no son digitos, mostramos msj de error.
                            if (valor.Length != 10 || !valor.All(char.IsDigit))
                            {
                                lblError.Visible = true;
                                lblError.Text = "Por favor inserte un numero de teléfono válido";
                                todoBien = false;
                            }
                            break;
                        case "email":
                            // Si el email no tiene formato de email, muestro mensaje de error.
                            if (!Regex.IsMatch(valor, @"^[a-zA-Z0-9.]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                            {
                                lblError.Visible = true;
                                lblError.Text = "Por favor inserte un email válido";
                                todoBien = false;
                            }
                            break;
                    }
                }
            }

            return todoBien;
        }
    }
}
