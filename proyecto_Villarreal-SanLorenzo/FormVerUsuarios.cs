using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class FormVerUsuarios : Form
    {
        public FormVerUsuarios()
        {
            InitializeComponent();
            ObtenerRegistro();
            CargarDatosUsuario();
        }
        private void CargarDatosUsuario()
        {
            string nombre_completo = $"{SesionUsuario.nombre_usuario} {SesionUsuario.apellido_usuario}";
            lNombreUsuario.Text = nombre_completo;
            lRol.Text = SesionUsuario.RolActivo;
        }

        private void ObtenerRegistro()
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

        private void bAgregarUsuario_Click(object sender, EventArgs e)
        {
            Form_nuevo_usuario formNuevoUsuario = new Form_nuevo_usuario();
            formNuevoUsuario.Show();

            this.Hide();
        }

        private void bEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["id_usuario"].Value);

                string nombre = tbNomUsuario.Text.Trim();
                string apellido = tbApellidoUsuario.Text.Trim();
                string telefono = tbTelefono.Text.Trim();
                string email = tbEmail.Text.Trim();

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(email))
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

                        string query = @"UPDATE Usuarios 
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
                                ObtenerRegistro(); // refrescar el grid
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

        private void bEliminarUsuario_Click(object sender, EventArgs e)
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

        private void bHome_Click(object sender, EventArgs e)
        {
            FormHome formHome = new FormHome();
            formHome.Show();
            this.Close();
        }

        private void bPersonal_Click(object sender, EventArgs e)
        {
            Form_nuevo_usuario formularioUsuarios = new Form_nuevo_usuario();
            formularioUsuarios.Show();
            this.Close();
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            //Llama al metodo el cual cierra la sesion.
            SesionUsuario.CerrarSesion();

            Form_login formLogin = new Form_login();
            formLogin.Show();
            this.Close();
        }
    }
}
