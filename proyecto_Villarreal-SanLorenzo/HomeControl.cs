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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class HomeControl : UserControlProyecto
    {

        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";

        public HomeControl()
        {
            InitializeComponent();
        }

        private void HomeControl_Load(object sender, EventArgs e)
        {
            CargarPacientesRecientes();
            CrearRegistrosRecientes();
            lNumeroPacientesActivos.Text = TotalPacientesActivos().ToString();
            lNroPromedioRegistros.Text = PromedioRegistrosPaciente().ToString("0.00");
        }

        // Funcion que devuelve el total de pacientes registrados en el hospital
        private int TotalPacientesActivos()
        {
            int total_pacientes = 0;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT COUNT (dni_paciente) FROM Paciente";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        // Guardo el total y lo pongo en el texto del label correspondiente
                        total_pacientes = (int)cmd.ExecuteScalar();
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return total_pacientes;
        }

        private double PromedioRegistrosPaciente()
        {
            double promedio = 0;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT CAST(COUNT(*) AS FLOAT) / COUNT(DISTINCT dni_paciente) AS PromedioRegistrosPorPaciente FROM Registro;";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        // Guardo el total y lo pongo en el texto del label correspondiente
                        promedio = Convert.ToDouble(cmd.ExecuteScalar());
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                if(ex.Number == 8134)
                {
                    promedio = 0;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }      
            }
            return promedio;
        }

        // Funcion para crear un panel vacio para avisarle al usuario que no se han creado ninguna fila esta semana
        // para los paneles del home
        private Panel crearPanelVacio(bool esConsulta)
        {
            Panel panelVacio = new Panel();
            panelVacio.Size = new Size(320, 46);
            string texto = esConsulta ? "nuevas consultas" : "nuevos pacientes";

            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Left;
            pb.Size = new Size(25, 46);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = Resource1.question;

            Label labelAviso = new Label();
            labelAviso.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            labelAviso.AutoSize = true;
            labelAviso.Location = new Point(pb.Right + 10, 10);
            labelAviso.Text = "No se han registrado " + texto + " \nesta ultima semana!";

            panelVacio.Controls.Add(pb);
            panelVacio.Controls.Add(labelAviso);

            return panelVacio;
        }


        private void CargarPacientesRecientes()
        {
            FilasUltimaActividad filaPaciente;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT dni_paciente FROM Paciente " +
                        "WHERE fecha_crecion_registro >= DATEADD(DAY, -7, GETDATE()) AND fecha_crecion_registro <= GETDATE() " +
                        "AND visible = 1;";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                filaPaciente = new FilasUltimaActividad(Convert.ToInt32(reader["dni_paciente"]), 0, 0, true);
                                panelContenedorPacientes.Controls.Add(filaPaciente);
                            }
                        }
                        else
                        {
                            panelContenedorPacientes.Controls.Add(crearPanelVacio(false));

                        }
                            db.Close();
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearRegistrosRecientes()
        {
            FilasUltimaActividad filaPaciente;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT dni_paciente, id_registro, id_historial FROM Registro " +
                        "WHERE fecha_registro >= DATEADD(DAY, -7, GETDATE()) AND fecha_registro <= GETDATE();";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                filaPaciente = new FilasUltimaActividad
                                    (Convert.ToInt32(reader["dni_paciente"]), 
                                        Convert.ToInt32(reader["id_registro"]), 
                                        Convert.ToInt32(reader["id_historial"]), 
                                        false
                                     );
                                panelContenedorRegistros.Controls.Add(filaPaciente);
                            }
                        }
                        else
                        {
                            panelContenedorRegistros.Controls.Add(crearPanelVacio(true));

                        }
                        db.Close();
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
