using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//Es importante usar esto.
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                        "telefono_paciente, fecha_nacimiento_paciente, usuario_creacion_registro) VALUES (@dni, @nombre, @apellido, @direccion," +
                        "@telefono, @fecha_nacimiento, @usuario_creacion)";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, db))
                    {
                        cmd.Parameters.AddWithValue("@dni", Convert.ToInt32(diccionario["dni"]));
                        cmd.Parameters.AddWithValue("@nombre", diccionario["nombre"].ToString());
                        cmd.Parameters.AddWithValue("@apellido", diccionario["apellido"].ToString());
                        cmd.Parameters.AddWithValue("@direccion", diccionario["direccion"].ToString());
                        cmd.Parameters.AddWithValue("@telefono", Convert.ToInt64(diccionario["telefono"]));
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", diccionario["fecha_nacimiento"]);
                        cmd.Parameters.AddWithValue("@usuario_creacion", 1231231);

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
                        "direccion_paciente=@direccion,telefono_paciente=@telefono, fecha_nacimiento_paciente=@fecha_nacimiento, " +
                        "fecha_modificacion_registro = @fechaHoy, usuario_modif_registro = @usuario_modif "
                        + "WHERE dni_paciente = @dni";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, db))
                    {

                        cmd.Parameters.AddWithValue("@dni", Convert.ToInt32(diccionario["dni"]));
                        cmd.Parameters.AddWithValue("@nombre", diccionario["nombre"].ToString());
                        cmd.Parameters.AddWithValue("@apellido", diccionario["apellido"].ToString());
                        cmd.Parameters.AddWithValue("@direccion", diccionario["direccion"].ToString());
                        cmd.Parameters.AddWithValue("@telefono", Convert.ToInt64(diccionario["telefono"]));
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", diccionario["fecha_nacimiento"]);
                        cmd.Parameters.AddWithValue("@fechaHoy", DateTime.Today);
                        cmd.Parameters.AddWithValue("@usuario_modif", 1231231);


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

        private bool DetectarErrores(Dictionary<string, object> dic)
        {
            bool todoBien = true;

            foreach (var clave in dic.Keys)
            {
                string valor = dic[clave]?.ToString() ?? "";
                string lblErrorNombre = "lError" + char.ToUpper(clave[0]) + clave.Substring(1);

                Control[] controles = this.Controls.Find(lblErrorNombre, true);
                if (controles.Length == 0 || !(controles[0] is Label lblError))
                    continue;

                lblError.Visible = false;

                if (string.IsNullOrWhiteSpace(valor))
                {
                    lblError.Visible = true;
                    lblError.Text = "Por favor rellene este campo";
                    todoBien = false;
                }
                else
                {
                    switch (clave)
                    {
                        case "dni":
                            if (!int.TryParse(valor, out int dniVal) || valor.Length < 7 || valor.Length > 8)
                            {
                                lblError.Visible = true;
                                lblError.Text = "Por favor inserte un DNI válido";
                                todoBien = false;
                            }
                            break;
                        case "telefono":
                            if (valor.Length < 10 || valor.Length > 13 || !valor.All(char.IsDigit))
                            {
                                lblError.Visible = true;
                                lblError.Text = "Por favor inserte un numero de teléfono válido";
                                todoBien = false;
                            }
                            break;
                        case "direccion":
                            if (valor.All(char.IsDigit))
                            {
                                lblError.Visible = true;
                                lblError.Text = "Por favor inserte una dirección válida";
                                todoBien = false;
                            }
                            break;
                    }
                }
            }

            return todoBien;
        }



        private void ApretarEnter()
        {
            Dictionary<string, object> diccionario = CrearDiccionario();
            if (DetectarErrores(diccionario))
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
        }

        private void textBoxControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
                ApretarEnter();
            }
        }


        private void tbTextoCaracteresPacienteRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tbNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^\d$") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tbDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9\s]") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void RegistrarPacienteControl_Load(object sender, EventArgs e)
        {
            tFechaPacienteRegistro.MaxDate = DateTime.Today;
        }
    }
}
