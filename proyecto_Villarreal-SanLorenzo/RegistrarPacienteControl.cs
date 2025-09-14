using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//Es importante usar esto.
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
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Paciente WHERE dni_paciente = @dni";
                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
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
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RegistrarPaciente()
        {
            Dictionary<string, object> diccionario = CrearDiccionario();

            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string queryAgregar = "INSERT INTO Paciente (dni_paciente, nombre_paciente, apellido_paciente, direccion_paciente," +
                        "telefono_paciente, fecha_nacimiento_paciente, visible) VALUES (@dni, @nombre, @apellido, @direccion," +
                        "@telefono, @fecha_nacimiento, 1)";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, db))
                    {
                        cmd.Parameters.AddWithValue("@dni", Convert.ToInt32(diccionario["dni"]));
                        cmd.Parameters.AddWithValue("@nombre", diccionario["nombre"].ToString());
                        cmd.Parameters.AddWithValue("@apellido", diccionario["apellido"].ToString());
                        cmd.Parameters.AddWithValue("@direccion", diccionario["direccion"].ToString());
                        cmd.Parameters.AddWithValue("@telefono", Convert.ToInt32(diccionario["telefono"]));
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", diccionario["fecha_nacimiento"]);

                        db.Open();
                        cmd.ExecuteNonQuery();
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Dictionary<string, object> CrearDiccionario()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic.Add("dni", tDniPacienteRegistro.Text);
            dic.Add("nombre", tNombrePacienteRegistro.Text);
            dic.Add("apellido", tApellidoPacienteRegistro.Text);
            dic.Add("direccion", tDireccionPacienteRegistro.Text);
            dic.Add("telefono", tTelefonoPacienteRegistro.Text);
            dic.Add("fecha_nacimiento", tFechaPacienteRegistro.Value.Date);

            return dic;
        }

        private void EditarPaciente()
        {
            
            Dictionary<string, object> diccionario = CrearDiccionario();

            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string queryAgregar = "UPDATE Paciente SET nombre_paciente=@nombre, apellido_paciente=@apellido, " +
                        "direccion_paciente=@direccion,telefono_paciente=@telefono, fecha_nacimiento_paciente=@fecha_nacimiento, visible=1" +
                        "WHERE dni_paciente = @dni";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, db))
                    {

                        cmd.Parameters.AddWithValue("@dni", Convert.ToInt32(diccionario["dni"]));
                        cmd.Parameters.AddWithValue("@nombre", diccionario["nombre"].ToString());
                        cmd.Parameters.AddWithValue("@apellido", diccionario["apellido"].ToString());
                        cmd.Parameters.AddWithValue("@direccion", diccionario["direccion"].ToString());
                        cmd.Parameters.AddWithValue("@telefono", Convert.ToInt32(diccionario["telefono"]));
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", diccionario["fecha_nacimiento"]);



                        db.Open();
                        cmd.ExecuteNonQuery();
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bRegistrarPaciente_Click(object sender, EventArgs e)
        {
            ApretarEnter();

        }

        

        private void ApretarEnter()
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

        private void textBoxControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
                ApretarEnter();
            }
        }

        private void RegistrarPacienteControl_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.PreviewKeyDown += textBoxControl_PreviewKeyDown;
                }
            }
        }
    }
}
