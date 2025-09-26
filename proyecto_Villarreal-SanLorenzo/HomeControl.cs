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
            // Coneccion a la base de datos para contar cuantas filas hay en la tabla de "Paciente"
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
                        int total_pacientes = (int)cmd.ExecuteScalar();
                        lNumeroPacientesActivos.Text = total_pacientes.ToString();
                        db.Close();
                    }
                }
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        "WHERE fecha_crecion_registro >= DATEADD(DAY, -7, GETDATE()) AND fecha_crecion_registro <= GETDATE();";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            filaPaciente = new FilasUltimaActividad(Convert.ToInt32(reader["dni_paciente"]), true);
                            panelContenedorPacientes.Controls.Add(filaPaciente);
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
