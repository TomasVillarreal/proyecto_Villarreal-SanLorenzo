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
        // Eventhandler para poder ir a otros controles usando las filas creadas
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;

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
                        // Guardo el total
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

        // Funcion que calcula el promedio de las consultas hechas por paciente
        private double PromedioRegistrosPaciente()
        {
            double promedio = 0;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para obtener el promedio al contar todas las filas
                    // y dividirlas por la cuenta del nro de pacientes distintos que hay
                    string queryNroPacientes = "SELECT CAST(COUNT(*) AS FLOAT) / COUNT(DISTINCT dni_paciente) AS PromedioRegistrosPorPaciente FROM Registro;";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        // Guardo el promedio y convierto a doble
                        promedio = Convert.ToDouble(cmd.ExecuteScalar());
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Si hay un error pq no hay registros, hago que el promedio sea 0
                if(ex.Number == 8134)
                {
                    promedio = 0;
                }
                // Si hay cualquier otro tipo de error, devuelvo mensaje de error general
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

        // Funcion para cargar los pacientes recientemente creados (en la ultima semana)
        private void CargarPacientesRecientes()
        {
            // Creo una fila
            FilasUltimaActividad filaPaciente;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Creo la query para que se me devuelva todos los pacientes creados en la ult semaan
                    string queryNroPacientes = "SELECT dni_paciente FROM Paciente " +
                        "WHERE fecha_creacion_registro >= DATEADD(DAY, -7, GETDATE()) AND fecha_creacion_registro <= GETDATE() " +
                        "AND visible = 1;";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        // Si esta query tiene resultados:
                        if (reader.HasRows)
                        {
                            // Entonces recorro todas las filas devueltas y:
                            while (reader.Read())
                            {
                                int dni = Convert.ToInt32(reader["dni_paciente"]);
                                // Creo una fila que tenga unicamente el dni del paciente como argumento
                                filaPaciente = new FilasUltimaActividad(dni, 0, 0, true);
                                // Y le asigno el eventhandler que tengo como atributo
                                // al evento de ClickFila de la fila, para poder abrir el uc correspondiente.
                                filaPaciente.ClickFila += (s, e) =>
                                {
                                    // Creo el uc de pacientes, le asigno el mismo eventhandler que este uc, y lo invoco
                                    PacientesControl verDatosPaciente = new PacientesControl(dni);
                                    verDatosPaciente.AbrirOtroControl += this.AbrirOtroControl;
                                    AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, verDatosPaciente, false));
                                };

                                panelContenedorPacientes.Controls.Add(filaPaciente);
                            }
                        }
                        else
                        {
                            // Si no tiene filas, creo el panel vacio y lo coloco
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

        // Funcion que cumple la misma tarea que la de pacientes, solo que esta carga
        // los registros recientes (en la ultima semana)
        private void CrearRegistrosRecientes()
        {
            // Es exactamente lo mismo que la funcion CargarPacientesRecientes.
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
