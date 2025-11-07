using Microsoft.Win32;
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

        public HistorialClinicoControl controlPadreRegistro;

        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";

        int dni = 0;

        public AgregarRegistroControl(int p_dni, int p_historial, int p_registro)
        {
            InitializeComponent();

            lDosis.Visible = false;
            tDosis.Visible = false;
            this.dni = p_dni;

            if (dni != 0)
            {
                CargarDatosPaciente(dni);
                tDniPacienteRegistro.ReadOnly = true;
                tNombrePacienteRegistro.ReadOnly = true;
                tApellidoPacienteRegistro.ReadOnly = true;
            }

        }
        public AgregarRegistroControl(int p_dni)
        {

            InitializeComponent();
            lDosis.Visible = false;
            tDosis.Visible = false;
            this.dni = p_dni;

            CargarTiposRegistro();
            CargarMedicaciones();

            if (dni != 0)
            {
                CargarDatosPaciente(dni);
                tDniPacienteRegistro.ReadOnly = true;
                tNombrePacienteRegistro.ReadOnly = true;
                tApellidoPacienteRegistro.ReadOnly = true;
            }

        }
        private void CargarTiposRegistro()//Funcion que carga los tipos de registros al combobox
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    string query = "SELECT nombre_registro FROM Tipo_registro ORDER BY nombre_registro;";
                    using (SqlCommand cmd = new SqlCommand(query, db))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBoxTipoRegistro.Items.Clear();

                        while (reader.Read())
                        {
                            comboBoxTipoRegistro.Items.Add(reader["nombre_registro"].ToString());
                        }
                    }

                    comboBoxTipoRegistro.SelectedIndex = 0; // valor inicial
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de registro: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMedicaciones()//Funcion que carga las medicaciones al combobox
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    string query = "SELECT nombre_medicacion FROM Medicacion ORDER BY nombre_medicacion;";
                    using (SqlCommand cmd = new SqlCommand(query, db))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBoxMedicacion.Items.Clear();

                        // 🔹 Insertamos opción "(ninguna)" al principio
                        comboBoxMedicacion.Items.Add("(ninguna)");

                        while (reader.Read())
                        {
                            comboBoxMedicacion.Items.Add(reader["nombre_medicacion"].ToString());
                        }
                    }

                    comboBoxMedicacion.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBoxMedicacion.SelectedIndex = 0; // "(ninguna)" como valor por defecto
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las medicaciones: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosPaciente(int p_dni)
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
        }//Funcion que carga los datos del paciente

        private void bGuardarRegistro_Click(object sender, EventArgs e)
        {
            string observaciones = tObservaciones.Text.Trim();
            string medicacionSeleccionada = comboBoxMedicacion.SelectedItem?.ToString()?.Trim();
            string tipoRegistro = comboBoxTipoRegistro.SelectedItem?.ToString();
            DateTime fecha = DateTime.Now;

            if (string.IsNullOrWhiteSpace(observaciones))
            {
                MessageBox.Show("Debe completar las observaciones del registro.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idUsuario = SesionUsuario.id_usuario;
                string especialidad = SesionUsuario.RolActivo ?? "Sin especialidad";
                int idHistorial = ObtenerOCrearIdHistorialPorDni(this.dni);

                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    // Insertar registro
                    string insertRegistro = @"
                                            INSERT INTO Registro (id_historial, dni_paciente, id_tipo_registro, id_usuario, id_especialidad, fecha_registro, observaciones)
                                            OUTPUT INSERTED.id_registro
                                            VALUES (@idHistorial, @dni,
                                                (SELECT id_tipo_registro FROM Tipo_registro WHERE nombre_registro = @tipo),
                                                @idUsuario,
                                                (SELECT id_especialidad FROM Especialidades WHERE nombre_especialidad = @especialidad),
                                                GETDATE(),
                                                @obs
                                            );";

                    int nuevoIdRegistro;

                    using (SqlCommand cmd = new SqlCommand(insertRegistro, db))
                    {
                        cmd.Parameters.AddWithValue("@idHistorial", idHistorial);
                        cmd.Parameters.AddWithValue("@dni", this.dni);
                        cmd.Parameters.AddWithValue("@tipo", tipoRegistro ?? "Consulta Médica");
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@especialidad", especialidad);
                        cmd.Parameters.AddWithValue("@obs", observaciones);

                        nuevoIdRegistro = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Insertar medicación si corresponde
                    if (!string.IsNullOrEmpty(medicacionSeleccionada) && medicacionSeleccionada.ToLower() != "(ninguna)")
                    {
                        string insertMedicacion = @"
                                            INSERT INTO Registro_medicacion (id_registro, id_historial, dni_paciente, id_usuario, id_medicacion)
                                            VALUES (@idRegistro, @idHistorial, @dni, @idUsuario,
                                                (SELECT id_medicacion FROM Medicacion WHERE nombre_medicacion = @nombreMed)
                                            );";

                        using (SqlCommand cmdMed = new SqlCommand(insertMedicacion, db))
                        {
                            cmdMed.Parameters.AddWithValue("@idRegistro", nuevoIdRegistro);
                            cmdMed.Parameters.AddWithValue("@idHistorial", idHistorial);
                            cmdMed.Parameters.AddWithValue("@dni", this.dni);
                            cmdMed.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdMed.Parameters.AddWithValue("@nombreMed", medicacionSeleccionada);
                            cmdMed.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Registro agregado correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (controlPadreRegistro is HistorialClinicoControl historialControl)
                    {
                        historialControl.CargarHistoriales(this.dni, nuevoIdRegistro);
                    }

                    // Volver a la vista anterior
                    AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(0, this.controlPadreRegistro, false));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el registro: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Funcion que mediante un click en el boton, guarda el nuevo registro

        private void bAtras_Click(object sender, EventArgs e)//Funcion que permite volver a la vista anterior
        {
            // Volvemos al control que nos llamo.
            controlPadreRegistro?.CargarHistoriales(dni);
            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(0, this.controlPadreRegistro, false));
        }

        private void comboBoxMedicacion_SelectedIndexChanged(object sender, EventArgs e)//Funcion que permite mostrar el textbox de la dosis solo si se seleccionó un medicamento
        {
            // Si la opción elegida es distinta de "(ninguna)", mostramos dosis
            if (comboBoxMedicacion.SelectedItem == null || comboBoxMedicacion.SelectedItem.ToString() == "(ninguna)")
            {
                lDosis.Visible = false;
                tDosis.Visible = false;
                tDosis.Text = string.Empty;

            }
            else
            {
                lDosis.Visible = true;
                tDosis.Visible = true;

            }
        }

        private int ObtenerOCrearIdHistorialPorDni(int dniPaciente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Primero intentamos obtener el historial existente
                string querySelect = "SELECT id_historial FROM Historial WHERE dni_paciente = @dni";
                using (SqlCommand cmdSelect = new SqlCommand(querySelect, connection))
                {
                    cmdSelect.Parameters.AddWithValue("@dni", dniPaciente);
                    object result = cmdSelect.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result); // Ya existe, lo devolvemos
                    }
                }

                // Si no existe, historial porque va a ser el priemr registro y leugo su creacion, se crea
                string queryInsert = @"
                                    INSERT INTO Historial (dni_paciente, fecha_creacion)
                                    OUTPUT INSERTED.id_historial
                                    VALUES (@dni, @fechaCreacion);";

                using (SqlCommand cmdInsert = new SqlCommand(queryInsert, connection))
                {
                    cmdInsert.Parameters.AddWithValue("@dni", dniPaciente);
                    cmdInsert.Parameters.AddWithValue("@fechaCreacion", DateTime.Now);

                    int nuevoIdHistorial = Convert.ToInt32(cmdInsert.ExecuteScalar());
                    return nuevoIdHistorial;
                }
            }
        }
    }
}
