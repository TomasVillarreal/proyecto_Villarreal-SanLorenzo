using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class VerUsuarioControl : UserControlProyecto
    {
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;
        public VerUsuarioControl()
        {
            InitializeComponent();
            ObtenerRegistro();
        }
        private void ObtenerRegistro()//Metodo que carga los datos de los usuarios ya registrados
        {
            string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                                    SELECT 
                                        u.id_usuario,
                                        u.nombre_usuario,
                                        u.apellido_usuario,
                                        u.email_usuario,
                                        u.telefono_usuario,
                                        STRING_AGG(r.nombre_rol, ', ') AS Roles,
                                        ISNULL(
                                            NULLIF(CAST(STRING_AGG(e.nombre_especialidad, ', ') AS VARCHAR(MAX)), ''), 
                                            'Sin especialidad'
                                        ) AS Especialidades
                                    FROM Usuarios u
                                    LEFT JOIN Usuario_rol ur ON u.id_usuario = ur.id_usuario
                                    LEFT JOIN Rol r ON ur.id_rol = r.id_rol
                                    LEFT JOIN Usuario_especialidad ue ON u.id_usuario = ue.id_usuario
                                    LEFT JOIN Especialidades e ON ue.id_especialidad = e.id_especialidad
                                    WHERE u.activo = 1
                                    GROUP BY u.id_usuario, u.nombre_usuario, u.apellido_usuario, u.email_usuario, u.telefono_usuario;";


                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTableUsuario = new DataTable();
                    dataAdapter.Fill(dataTableUsuario);

                    //Para manejar el error de la especialidad
                    foreach (DataRow row in dataTableUsuario.Rows)
                    {
                        if (row["Especialidades"] == DBNull.Value || string.IsNullOrWhiteSpace(row["Especialidades"].ToString()))
                        {
                            row["Especialidades"] = "Sin especialidad";
                        }
                    }

                    dataGridViewUsuarios.AutoGenerateColumns = true;
                    dataGridViewUsuarios.DataSource = null;
                    dataGridViewUsuarios.DataSource = dataTableUsuario;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                }
            }
        }

        private void CargarUsuariosEliminados() // Metodo que carga los usuarios eliminados del sistema
        {
            string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                                    SELECT 
                                        u.id_usuario,
                                        u.nombre_usuario,
                                        u.apellido_usuario,
                                        u.email_usuario,
                                        u.telefono_usuario,
                                        STRING_AGG(r.nombre_rol, ', ') AS Roles,
                                        ISNULL(
                                            NULLIF(CAST(STRING_AGG(e.nombre_especialidad, ', ') AS VARCHAR(MAX)), ''), 
                                            'Sin especialidad'
                                        ) AS Especialidades
                                    FROM Usuarios u
                                    LEFT JOIN Usuario_rol ur ON u.id_usuario = ur.id_usuario
                                    LEFT JOIN Rol r ON ur.id_rol = r.id_rol
                                    LEFT JOIN Usuario_especialidad ue ON u.id_usuario = ue.id_usuario
                                    LEFT JOIN Especialidades e ON ue.id_especialidad = e.id_especialidad
                                    WHERE u.activo = 0
                                    GROUP BY u.id_usuario, u.nombre_usuario, u.apellido_usuario, u.email_usuario, u.telefono_usuario;";


                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTableUsuario = new DataTable();
                    dataAdapter.Fill(dataTableUsuario);

                    //Para manejar el error de la especialidad
                    foreach (DataRow row in dataTableUsuario.Rows)
                    {
                        if (row["Especialidades"] == DBNull.Value || string.IsNullOrWhiteSpace(row["Especialidades"].ToString()))
                        {
                            row["Especialidades"] = "Sin especialidad";
                        }
                    }

                    dataGridViewUsuarios.AutoGenerateColumns = true;
                    dataGridViewUsuarios.DataSource = null;
                    dataGridViewUsuarios.DataSource = dataTableUsuario;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                }
            }
        }

        private void EditarUsuario()
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.CurrentRow.Cells["id_usuario"].Value);
                Dictionary<string, object> diccionario = CrearDiccionario();

                string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = @"
                                        UPDATE Usuarios 
                                        SET nombre_usuario = @nombre, 
                                            apellido_usuario = @apellido, 
                                            telefono_usuario = @telefono, 
                                            email_usuario = @correo
                                        WHERE id_usuario = @idUsuario";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@nombre", diccionario["nombre"].ToString());
                            cmd.Parameters.AddWithValue("@apellido", diccionario["apellido"].ToString());
                            cmd.Parameters.AddWithValue("@telefono", Convert.ToInt64(diccionario["telefono"]));
                            cmd.Parameters.AddWithValue("@correo", diccionario["email"].ToString());
                            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (rbUsuariosEliminados.Checked)
                                {
                                    CargarUsuariosEliminados();
                                } else if (rbUsuariosVisibles.Checked)
                                {
                                    ObtenerRegistro();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
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
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bEditarUsuario_Click(object sender, EventArgs e)//Metodo que permite editar la informacion del usuario
        {
            Dictionary<string, object> diccionario = CrearDiccionario();
            if (DetectarErrores(diccionario))
            {
                EditarUsuario();
            }
        }

        private void EliminarUsuario()
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.CurrentRow.Cells["id_usuario"].Value);

                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este usuario?", "Confirmación",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "UPDATE Usuarios SET activo = 0 WHERE id_usuario = @idUsuario";

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ObtenerRegistro();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar usuario: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReactivarUsuario()
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.CurrentRow.Cells["id_usuario"].Value);

                DialogResult result = MessageBox.Show("¿Está seguro que desea reactivar a este usuario?", "Confirmación",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "UPDATE Usuarios SET activo = 1 WHERE id_usuario = @idUsuario";

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Usuario reactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CargarUsuariosEliminados();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo reactivar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al reactivar usuario: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bEliminarUsuario_Click(object sender, EventArgs e)//Metodo que permite eliminar (de forma logica [activo = 0]) a un usuario
        {
            if (rbUsuariosEliminados.Checked)
            {
                ReactivarUsuario();
            }
            else if (rbUsuariosVisibles.Checked)
            {
                EliminarUsuario();
            }
        }
        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)//Metodo que selecciona a un usuario y carga la informacion a los textbox
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridViewUsuarios.Rows[e.RowIndex];

                tbNomUsuario.Text = fila.Cells["nombre_usuario"].Value.ToString();
                tbApellidoUsuario.Text = fila.Cells["apellido_usuario"].Value.ToString();
                tbTelefono.Text = fila.Cells["telefono_usuario"].Value.ToString();
                tbEmail.Text = fila.Cells["email_usuario"].Value.ToString();
            }
        }

        private void bAgregarUsuario_Click(object sender, EventArgs e)//Redirije al usuario a la vista para agregar usuarios
        {
            NuevoUsuarioControl nuevoUsuario = new NuevoUsuarioControl();

            nuevoUsuario.AbrirOtroControl += this.AbrirOtroControl;

            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, nuevoUsuario, true));
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

        private void rbUsuariosVisibles_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerRegistro();
            bEliminarUsuario.Text = "Eliminar usuario";
        }

        private void rbUsuariosEliminados_CheckedChanged(object sender, EventArgs e)
        {
            CargarUsuariosEliminados();
            bEliminarUsuario.Text = "Reactivar usuario";
        }

        private void tbTextoCaracteresPacienteRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tbNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^\d$") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

    }
}
