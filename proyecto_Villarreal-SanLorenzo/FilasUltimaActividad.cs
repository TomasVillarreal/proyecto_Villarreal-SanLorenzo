using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_Villarreal_SanLorenzo
{
    public class FilasUltimaActividad : Panel
    {

        int dni = 0;
        int nro_registro = 0;
        int nro_historial = 0;
        bool nuevosPacientes;
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";

        public FilasUltimaActividad(int p_dni, int p_nro_registro, int p_nro_historial, bool p_nuevosPacientes)
        {
            this.BackColor = Color.White;
            if (p_dni != 0) this.dni = p_dni;
            if (p_nro_registro != 0) this.nro_registro = p_nro_registro;
            if (p_nro_historial != 0) this.nro_historial = p_nro_historial;
            this.Size = new Size(300, 46);
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
            lDescripcion.Text = nuevosPacientes ? "Registrado por " + ObtenerNombreMedico() : ObtenerTipoRegistro();

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
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(nombre_completo);
        }

        private string ObtenerFecha()
        {
            string fecha = "";
            string query = "";
            string nombre_columna = "";

                if (nuevosPacientes)
                {
                    query = "SELECT fecha_crecion_registro " +
                        "FROM Paciente WHERE dni_paciente = @dni";
                    nombre_columna = "fecha_crecion_registro";
                } else
                {
                    query = "SELECT fecha_registro " +
                            "FROM Registro WHERE id_historial = @nro_historial AND id_registro = @nro_registro AND dni_paciente = @dni";
                    nombre_columna = "fecha_registro";
                }
                using (SqlConnection db = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@dni", this.dni);
                        if (!nuevosPacientes)
                        {
                            cmd.Parameters.AddWithValue("@nro_historial", this.nro_historial);
                            cmd.Parameters.AddWithValue("@nro_registro", this.nro_registro);
                        }
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) // avanza al primer registro
                        {
                            DateTime fechaDT = (DateTime)reader[nombre_columna];
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
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(nombre_completo);
        }

        private string ObtenerTipoRegistro()
        {
            string nombre_registro = "";
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT tr.nombre_registro " +
                    "FROM Registro r INNER JOIN Tipo_registro tr ON r.id_tipo_registro = tr.id_tipo_registro " +
                    "WHERE r.id_historial = @nro_historial AND r.id_registro = @nro_registro AND r.dni_paciente = @dni";
                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@dni", this.dni);
                    cmd.Parameters.AddWithValue("@nro_registro", this.nro_registro);
                    cmd.Parameters.AddWithValue("@nro_historial", this.nro_historial);
                    db.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // avanza al primer registro
                    {
                        nombre_registro = reader["nombre_registro"].ToString();
                    }
                }
                db.Close();
            }
            return nombre_registro;
        }
    }
}
