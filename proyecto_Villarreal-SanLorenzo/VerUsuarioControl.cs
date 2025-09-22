using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                                   ISNULL(STRING_AGG(e.nombre_especialidad, ', '), 'Sin especialidad') AS Especialidades
                                FROM Usuarios u
                                LEFT JOIN Usuario_rol ur ON u.id_usuario = ur.id_usuario
                                LEFT JOIN Rol r ON ur.id_rol = r.id_rol
                                LEFT JOIN Usuario_especialidad ue ON u.id_usuario = ue.id_usuario
                                LEFT JOIN Especialidades e ON ue.id_especialidad = e.id_especialidad
                                WHERE u.activo = 1
                                GROUP BY u.id_usuario, u.nombre_usuario, u.apellido_usuario, u.email_usuario, u.telefono_usuario";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTableUsuario = new DataTable();
                    dataAdapter.Fill(dataTableUsuario);

                    dataGridViewUsuarios.DataSource = dataTableUsuario;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                }
            }
        }

        private void bEditarUsuario_Click(object sender, EventArgs e)//Metodo que permite editar la informacion del usuario
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.CurrentRow.Cells["id_usuario"].Value);

                string nombre = tbNomUsuario.Text.Trim();
                string apellido = tbApellidoUsuario.Text.Trim();
                string telefono = tbTelefono.Text.Trim();
                string email = tbEmail.Text.Trim();

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                    string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Debe completar todos los campos antes de editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@apellido", apellido);
                            cmd.Parameters.AddWithValue("@telefono", telefono);
                            cmd.Parameters.AddWithValue("@correo", email);
                            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ObtenerRegistro();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al editar usuario: " + ex.Message);
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
    }
}
