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
    public partial class AgregarRegistroControl : UserControlProyecto
    {
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;

        public UserControlProyecto controlPadreRegistro;

        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";

        int dni = 0;

        private void AgregarRegistroControl_Load(object sender, EventArgs e)
        {
            if (dni != 0)
            {
                CargarDatos(dni);
                tDniPacienteRegistro.ReadOnly = true;
                tNombrePacienteRegistro.ReadOnly = true;
                tApellidoPacienteRegistro.ReadOnly = true;
            }
        }
        public AgregarRegistroControl(int p_dni)
        {

            InitializeComponent();
            this.dni = p_dni;

        }
        private void CargarDatos(int p_dni)
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Selecciono todas las columnas de la fila cuyo DNI coincida con el que se le fue pasado como argumento
                    string query = "SELECT dni_paciente, nombre_paciente, apellido_paciente FROM Paciente WHERE dni_paciente = @dni";
                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@dni", p_dni);
                        db.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            // Relleno todos y cada uno de los controles con los datos del paciente
                            tApellidoPacienteRegistro.Text = reader["apellido_paciente"].ToString(); ;
                            tNombrePacienteRegistro.Text = reader["nombre_paciente"].ToString(); ;
                            tDniPacienteRegistro.Text = reader["dni_paciente"].ToString();
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
