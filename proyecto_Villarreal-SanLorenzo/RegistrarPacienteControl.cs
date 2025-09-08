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
    public partial class RegistrarPacienteControl : UserControlProyecto
    {

        string connectionString = "Server=localhost;Database=proyecto_Villarreal-SanLorenzo;Trusted_Connection=True;";
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;
        public PacientesControl ControlPadre;
        int dni = 0;

        public RegistrarPacienteControl()
        {
            InitializeComponent();
        }
        public RegistrarPacienteControl(int p_dni)
        {
            InitializeComponent();
            this.dni = p_dni;

            if (dni != 0)
            {
                this.CargarDatos(p_dni);
                bRegistrarPaciente.Text = "Editar Paciente";
                tDniPacienteRegistro.ReadOnly = true;
            }
        }

        private void CargarDatos(int p_dni)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Paciente WHERE dni_paciente = @dni";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@dni", p_dni);
                db.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tApellidoPacienteRegistro.Text = reader["apellido_paciente"].ToString(); ;
                    tNombrePacienteRegistro.Text = reader["nombre_paciente"].ToString(); ;
                    tDniPacienteRegistro.Text = reader["dni_paciente"].ToString();
                    tTelefonoPacienteRegistro.Text = reader["telefono_paciente"].ToString();
                    tDireccionPacienteRegistro.Text = reader["direccion_paciente"].ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("fecha_nacimiento_paciente")))
                    {
                        tFechaPacienteRegistro.Value = reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento_paciente"));
                    }
                }

                db.Close();
            }
        }

        private void RegistrarPaciente()
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

        private void EditarPaciente()
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string queryAgregar = "UPDATE Paciente SET nombre_paciente=@nombre, apellido_paciente=@apellido, " +
                    "direccion_paciente=@direccion,telefono_paciente=@telefono, fecha_nacimiento_paciente=@fecha_nacimiento, visible=1" +
                    "WHERE dni_paciente = @dni";

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

        private void bRegistrarPaciente_Click(object sender, EventArgs e)
        {
            if (this.dni == 0)
            {
                this.RegistrarPaciente();
            }
            else
            {
                this.EditarPaciente();
            }

            ControlPadre?.CargarDatos();
            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(0, this.ControlPadre, false));

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

        private void RegistrarPacienteControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dni == 0)
                {
                    this.RegistrarPaciente();
                }
                else
                {
                    this.EditarPaciente();
                }

                PacientesControl pacienteControl = new PacientesControl();
                AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(0, this.ControlPadre, false));
            }
        }
    }
}
