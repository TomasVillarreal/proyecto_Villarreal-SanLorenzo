using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    public class FilasUltimaActividad : Panel
    {

        int dni = 0;
        bool nuevosPacientes;
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";

        public FilasUltimaActividad(int p_dni, bool p_nuevosPacientes)
        {
            this.BackColor = Color.White;
            this.dni = p_dni;
            this.Size = new Size(320, 46);
            this.nuevosPacientes = p_nuevosPacientes;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Left;
            pb.Size = new Size(25, 46);
            pb.SizeMode = PictureBoxSizeMode.Zoom;

            Label lNombrePaciente = new Label();
            lNombrePaciente.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lNombrePaciente.AutoSize = true;
            lNombrePaciente.Location = new Point(pb.Right + 10, 10);
            lNombrePaciente.Text = ObtenerNombrePaciente();

            Label lDescripcion = new Label();
            lDescripcion.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lDescripcion.AutoSize = true;
            lDescripcion.Location = new Point(pb.Right + 10, 25);
            lDescripcion.Text = nuevosPacientes ? "Registrado por " + ObtenerNombreMedico() : "";

            Label lFecha = new Label();
            lFecha.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lFecha.AutoSize = true;
            lFecha.Location = new Point(this.Width - 67, 10);
            lFecha.Text = ObtenerFecha();

            pb.Image = nuevosPacientes ? Resource1.plus : Resource1.exclamation;

            this.Controls.Add(pb);
            this.Controls.Add(lNombrePaciente);
            this.Controls.Add(lDescripcion);
            this.Controls.Add(lFecha);
        }

        private string ObtenerNombrePaciente()
        {
            string nombre_completo = "";
            using(SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre_paciente + ' ' + apellido_paciente AS nombre_completo " +
                    "FROM Paciente WHERE dni_paciente = @dni";
                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@dni", this.dni);
                    db.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // avanza al primer registro
                    {
                        nombre_completo = reader["nombre_completo"].ToString();
                    }
                }
                db.Close();
            }
            return nombre_completo;
        }

        private string ObtenerFecha()
        {
            string fecha = "";
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT fecha_creacion_registro " +
                    "FROM Paciente WHERE dni_paciente = @dni";
                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@dni", this.dni);
                    db.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // avanza al primer registro
                    {
                        DateTime fechaDT = (DateTime)reader["fecha_creacion_registro"];
                        fecha = fechaDT.ToString("dd/MM/yyyy");
                    }
                }
                db.Close();
            }
            return fecha;
        }

        private string ObtenerNombreMedico()
        {
            string nombre_completo = "";
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT m.nombre_usuario + ' ' + m.apellido_usuario AS nombre_completo " +
                    "FROM Paciente p INNER JOIN Usuarios m ON p.usuario_creacion_registro = m.id_usuario " +
                    "WHERE p.dni_paciente = @dni";
                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@dni", this.dni);
                    db.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // avanza al primer registro
                    {
                        nombre_completo = reader["nombre_completo"].ToString();
                    }
                }
                db.Close();
            }
            return nombre_completo;
        }
    }
}
