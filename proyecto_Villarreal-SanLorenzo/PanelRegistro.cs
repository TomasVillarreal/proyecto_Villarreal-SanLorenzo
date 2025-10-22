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


        public  PanelRegistro(int p_historial, int p_registro)//Constructor del PanelRegistro
        {
            
            historial = p_historial;
            registro = p_registro;
            dni = ObtenerDniPaciente(); //se obtiene el dni antes de cargar los datos

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
            // DNI
            Label lDniPaciente = new Label();
            lDniPaciente.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lDniPaciente.Text = "DNI: " + dni.ToString();
            lDniPaciente.AutoSize = true;
            lDniPaciente.Location = new Point(10, 10);

            // Nombre del paciente (debajo del DNI, con mayúscula en iniciales)
            string nombrePaciente = ObtenerNombrePaciente();
            if (!string.IsNullOrWhiteSpace(nombrePaciente))
                nombrePaciente = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombrePaciente.ToLower());

            Label lNombrePaciente = new Label();
            lNombrePaciente.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lNombrePaciente.Text = nombrePaciente;
            lNombrePaciente.AutoSize = true;
            lNombrePaciente.Location = new Point(10, lDniPaciente.Bottom + 2);

            // Nombre del médico (antes del tipo de registro)
            Label lMedico = new Label();
            lMedico.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lMedico.ForeColor = Color.Gray;
            string nombreMedico = ObtenerNombreMedico();
            if (!string.IsNullOrWhiteSpace(nombreMedico))
                nombreMedico = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreMedico.ToLower());
            lMedico.Text = "Dr. " + nombreMedico;
            lMedico.AutoSize = true;
            lMedico.Location = new Point(lNombrePaciente.Right + 30, 10);

            // Tipo de registro
            Label lTipoRegistro = new Label();
            lTipoRegistro.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lTipoRegistro.Text = ObtenerTipoRegistro();
            lTipoRegistro.AutoSize = true;
            lTipoRegistro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lTipoRegistro.Location = new Point(this.Width - 240, 10);

            // Fecha del registro
            Label lFecha = new Label();
            lFecha.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lFecha.ForeColor = Color.DimGray;
            lFecha.Text = ObtenerFecha();
            lFecha.AutoSize = true;
            lFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lFecha.Location = new Point(this.Width - 100, 10);

            // observaciones
            Label lObservaciones = new Label();
            lObservaciones.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lObservaciones.Text = "📝 Observaciones: " + ObtenerObservaciones();
            lObservaciones.AutoSize = false;
            lObservaciones.Size = new Size(this.Width - 60, 45);
            this.Height = 110;
            lObservaciones.Location = new Point(10, 50);
            lObservaciones.ForeColor = Color.Black;

            // Estilos generales
            this.Padding = new Padding(8);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = 100;
            this.Width = 650;
            this.Margin = new Padding(6);

            // Agregar controles al panel
            this.Controls.Add(lDniPaciente);
            this.Controls.Add(lNombrePaciente);
            this.Controls.Add(lMedico);
            this.Controls.Add(lTipoRegistro);
            this.Controls.Add(lFecha);
            this.Controls.Add(lObservaciones);

        }

        private int ObtenerDniPaciente() //Obtiene el dni del paciente
        {
            int dniPaciente = 0;

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT dni_paciente FROM Historial WHERE id_historial = @id_historial";

                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@id_historial", this.historial);
                    db.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        dniPaciente = Convert.ToInt32(reader["dni_paciente"]);
                    }
                }
            }

            return dniPaciente;
        }

        private string ObtenerNombrePaciente() //Obtiene el nombre completo del paciente
        {
            string nombre_completo = "";
            using (SqlConnection db = new SqlConnection(connectionString))
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

        private string ObtenerNombreMedico()//Obtiene el nombre completo del medico que lo registro
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

        private string ObtenerObservaciones()
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


        }//Obtiene las observaciones de los medicos al paciente


        /* PRUEBA
         * 
         * 
         *             /* crear el botón (PRUEBA)
            Button boton = new Button();
            boton.Text = "Registrar Paciente";
            boton.Size = new Size(150, 40);
            boton.Location = new Point(20, 20);

            boton.Click += bboton_Click;

            // agregar el botón al panel
            // si PanelRegistro hereda de Panel o UserControl:
            this.Controls.Add(boton);
        private void bboton_Click(object sender, EventArgs e) //Aregar Funcionalidad
        {
            AgregarRegistroControl agregarRegistro = new AgregarRegistroControl(12345678);

            agregarRegistro.AbrirOtroControl += this.AbrirOtroControl;

            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, agregarRegistro, false));

        }*/

    }

}
