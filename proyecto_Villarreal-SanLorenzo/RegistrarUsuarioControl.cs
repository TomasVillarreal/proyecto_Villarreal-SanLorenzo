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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class RegistrarUsuarioControl : UserControlProyecto
    {

        string connectionString = "Server=localhost;Database=proyecto_Villarreal-SanLorenzo;Trusted_Connection=True;";

        public RegistrarUsuarioControl()
        {
            InitializeComponent();
        }

        private void bRegistrarPaciente_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string queryAgregar = "INSERT INTO Paciente (dni_paciente, nombre_paciente, apellido_paciente, direccion_paciente," +
                    "telefono_paciente, fecha_nacimiento_paciente, visible) VALUES (@dni, @nombre, @apellido, @direccion," +
                    "@telefono, @fecha_nacimiento, @visible)";

                SqlCommand cmd = new SqlCommand(queryAgregar, db);

                cmd.Parameters.AddWithValue("@dni", tDniPacienteRegistro.Text);
                cmd.Parameters.AddWithValue("@nombre", tNombrePacienteRegistro.Text);
                cmd.Parameters.AddWithValue("@apellido", tApellidoPacienteRegistro.Text);
                cmd.Parameters.AddWithValue("@direccion", tDireccionPacienteRegistro.Text);
                cmd.Parameters.AddWithValue("@telefono", tTelefonoPacienteRegistro.Text);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", tFechaPacienteRegistro.Value.Date);
                cmd.Parameters.AddWithValue("@visible", 1);

                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        private bool ControlarValores(params object[] valores)
        {
            int dni = Convert.ToInt32(valores[0]);
            string nombre = valores[1]?.ToString();
            string apellido = valores[2]?.ToString();
            string direccion = valores[3]?.ToString();
            string telefono = valores[4]?.ToString();
            string fecha = valores[5]?.ToString();

            return false;

        }

        private void CargarDatos()
        {
            
        }
    }
}
