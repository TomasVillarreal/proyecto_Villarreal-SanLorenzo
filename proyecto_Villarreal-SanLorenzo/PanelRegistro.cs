using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    public class PanelRegistro : Panel
    {
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";

        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;

        public int historial, registro, dni = 0;
        bool nuevosPacientes;
        string nombrePaciente;


        public  PanelRegistro(int p_historial, int p_registro)//Constructor del PanelRegistro
        {

            historial = p_historial;
            registro = p_registro;

            var datosPaciente = ObtenerDatosPaciente();
            if (int.TryParse(datosPaciente.dni, out int dniPaciente))
                dni = dniPaciente;
            nombrePaciente = datosPaciente.nombre;

            // apariencia del panel
            this.Height = 70;
            this.Width = 600;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(6);
            this.BackColor = Color.WhiteSmoke;

            CargarComponentes();
        }

        public void CargarComponentes()//Carga los componentes al panel
        {
            var datosPaciente = ObtenerDatosPaciente();

            // === DNI ===
            Label lDniPaciente = new Label();
            lDniPaciente.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lDniPaciente.Text = "DNI: " + datosPaciente.dni;
            lDniPaciente.AutoSize = true;
            lDniPaciente.Location = new Point(10, 10);

            // === Nombre ===
            Label lNombrePaciente = new Label();
            lNombrePaciente.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lNombrePaciente.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo
                                     .ToTitleCase(datosPaciente.nombre.ToLower());
            lNombrePaciente.AutoSize = true;
            lNombrePaciente.Location = new Point(10, lDniPaciente.Bottom + 2);

            // === Profesional (Dr./Enf.) ===
            Label lProfesional = new Label();
            lProfesional.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lProfesional.ForeColor = Color.Gray;

            var datos = ObtenerDatosProfesional();
            string prefijo = datos.rol.Equals("Médico", StringComparison.OrdinalIgnoreCase) ? "Dr. " :
                             datos.rol.Equals("Enfermero", StringComparison.OrdinalIgnoreCase) ? "Enf. " : "";

            string texto = $"{prefijo}{datos.nombreCompleto}";
            if (!string.IsNullOrWhiteSpace(datos.especialidad))
                texto += $" ({datos.especialidad})";

            lProfesional.Text = texto;
            lProfesional.AutoSize = true;
            lProfesional.Location = new Point(lNombrePaciente.Right + 25, 10);

            // === Tipo de registro ===
            Label lTipoRegistro = new Label();
            lTipoRegistro.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lTipoRegistro.Text = ObtenerTipoRegistro();
            lTipoRegistro.AutoSize = true;
            lTipoRegistro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lTipoRegistro.Location = new Point(this.Width - 240, 10);

            // === Fecha del registro ===
            Label lFecha = new Label();
            lFecha.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lFecha.ForeColor = Color.DimGray;
            lFecha.Text = ObtenerFecha();
            lFecha.AutoSize = true;
            lFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lFecha.Location = new Point(this.Width - 100, 10);

            // === Observaciones ===
            Label lObservaciones = new Label();
            lObservaciones.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            string textoObs = ObtenerObservaciones();
            lObservaciones.Text = "📝 Observaciones: " + (string.IsNullOrWhiteSpace(textoObs) ? "—" : textoObs);
            lObservaciones.ForeColor = Color.Black;
            lObservaciones.AutoSize = false;
            lObservaciones.MaximumSize = new Size(this.Width - 40, 0);
            lObservaciones.Location = new Point(10, lNombrePaciente.Bottom + 20);
            lObservaciones.AutoEllipsis = false;

            // Calcula altura exacta del texto
            using (Graphics g = this.CreateGraphics())
            {
                SizeF size = g.MeasureString(lObservaciones.Text, lObservaciones.Font, lObservaciones.MaximumSize.Width);
                lObservaciones.Size = new Size((int)size.Width, (int)size.Height + 5);
            }

            int alturaTotal = lObservaciones.Bottom + 15;

            // === Medicación (si existe) ===
            string medicacion = ObtenerMedicacion();
            if (!string.IsNullOrWhiteSpace(medicacion))
            {
                Label lMedicacion = new Label();
                lMedicacion.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lMedicacion.Text = "💊 Medicación: " + medicacion;
                lMedicacion.AutoSize = false;
                lMedicacion.MaximumSize = new Size(this.Width - 40, 0);
                lMedicacion.Location = new Point(10, lObservaciones.Bottom + 8);
                lMedicacion.ForeColor = Color.FromArgb(40, 40, 40);

                using (Graphics g = this.CreateGraphics())
                {
                    SizeF size = g.MeasureString(lMedicacion.Text, lMedicacion.Font, lMedicacion.MaximumSize.Width);
                    lMedicacion.Size = new Size((int)size.Width, (int)size.Height + 5);
                }

                this.Controls.Add(lMedicacion);
                alturaTotal = lMedicacion.Bottom + 15;
            }

            // === Ajustes del panel ===
            this.Height = Math.Max(alturaTotal, 110);
            this.Padding = new Padding(8);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Width = 650;
            this.Margin = new Padding(6);

            // === Agregar controles ===
            this.Controls.Add(lDniPaciente);
            this.Controls.Add(lNombrePaciente);
            this.Controls.Add(lProfesional);
            this.Controls.Add(lTipoRegistro);
            this.Controls.Add(lFecha);
            this.Controls.Add(lObservaciones);
        }

        private (string nombre, string dni) ObtenerDatosPaciente()//Obtiene el NYA del paciente junto con su DNI
        {
            string nombreCompleto = "";
            string dniPaciente = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                            SELECT p.nombre_paciente, p.apellido_paciente, p.dni_paciente
                            FROM Historial h
                            INNER JOIN Paciente p ON h.dni_paciente = p.dni_paciente
                            WHERE h.id_historial = @idHistorial;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idHistorial", this.historial);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombre = reader["nombre_paciente"] != DBNull.Value
                                    ? reader["nombre_paciente"].ToString()
                                    : "";

                                string apellido = reader["apellido_paciente"] != DBNull.Value
                                    ? reader["apellido_paciente"].ToString()
                                    : "";

                                nombreCompleto = $"{nombre} {apellido}".Trim();

                                if (reader["dni_paciente"] != DBNull.Value)
                                    dniPaciente = reader["dni_paciente"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del paciente: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (nombreCompleto, dniPaciente);
        }

        private string ObtenerFecha()//Obtiene la fecha en la que se registró por 1era vez al paciente en el sistema
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

        private (string nombreCompleto, string rol, string especialidad) ObtenerDatosProfesional()//Obtiene el NYA y la especialidad tanto de medicos como de enfermeros
        {
            string nombreCompleto = "";
            string rol = "";
            string especialidad = "";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                u.nombre_usuario + ' ' + u.apellido_usuario AS nombre_completo,
                r.nombre_rol,
                e.nombre_especialidad
            FROM Registro reg
            INNER JOIN Usuarios u ON reg.id_usuario = u.id_usuario
            INNER JOIN Usuario_rol ur ON u.id_usuario = ur.id_usuario
            INNER JOIN Rol r ON ur.id_rol = r.id_rol
            LEFT JOIN Usuario_especialidad ue ON u.id_usuario = ue.id_usuario
            LEFT JOIN Especialidades e ON ue.id_especialidad = e.id_especialidad
            WHERE reg.id_registro = @idRegistro";

                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@idRegistro", this.registro);
                    db.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        nombreCompleto = reader["nombre_completo"].ToString();
                        rol = reader["nombre_rol"].ToString();
                        especialidad = reader["nombre_especialidad"].ToString();
                    }
                }
            }

            return (nombreCompleto, rol, especialidad);
        }

        private string ObtenerTipoRegistro()//Obtiene el nombre de los registros asociados al dni del paciente
        {
            string tipo_registro = "";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT tr.nombre_registro
            FROM Registro r
            INNER JOIN Tipo_registro tr ON r.id_tipo_registro = tr.id_tipo_registro
            WHERE r.id_registro = @id_registro";

                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@id_registro", this.registro);
                    db.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        tipo_registro = reader["nombre_registro"].ToString();
                    }
                }
            }

            return tipo_registro;

        }

        private string ObtenerObservaciones()//Obtiene las observaciones que haya realizado el médico/enfermero
        {
            string observaciones = "";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"
                            SELECT observaciones
                            FROM Registro
                            WHERE id_registro = @id_registro";

                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@id_registro", this.registro);
                    db.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        observaciones = reader["observaciones"] != DBNull.Value ? reader["observaciones"].ToString() : "Sin observaciones.";
                    }
                }
            }

            return observaciones;


        }

        private string ObtenerMedicacion()//Obtiene la medicacion suministrada al paciente (en caso de que haya sido asi)
        {
            string medicacionInfo = "";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT m.nombre_medicacion, m.dosis_medicacion
            FROM Registro_medicacion rm
            INNER JOIN Medicacion m ON rm.id_medicacion = m.id_medicacion
            WHERE rm.id_registro = @idRegistro";

                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@idRegistro", this.registro);
                    db.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombre = reader["nombre_medicacion"].ToString();
                            string dosis = reader["dosis_medicacion"].ToString();

                            if (!string.IsNullOrWhiteSpace(nombre))
                                medicacionInfo = $"{nombre} ({dosis})";
                        }
                    }
                }
            }

            return medicacionInfo;
        }
    }
}
