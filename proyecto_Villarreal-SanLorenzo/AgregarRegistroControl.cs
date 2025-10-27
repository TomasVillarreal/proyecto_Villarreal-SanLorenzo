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

                        while (reader.Read())
                        {
                            comboBoxMedicacion.Items.Add(reader["nombre_medicacion"].ToString());
                        }
                    }

                    // No es obligatorio seleccionar medicación
                    comboBoxMedicacion.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBoxMedicacion.SelectedIndex = -1;
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
            string medicacion = comboBoxMedicacion.Text.Trim();
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
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    string query = @"
                                INSERT INTO Historial (dni_paciente, tipo_registro, observaciones, medicacion, fecha)
                                VALUES (@dni, @tipo, @obs, @med, @fecha);";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {

                        string medicacionSeleccionada = comboBoxMedicacion.SelectedItem?.ToString()?.Trim();

                        if (string.IsNullOrEmpty(medicacionSeleccionada))
                        {
                            // Si no hay medicación seleccionada, insertamos un valor por defecto en lugar de NULL o vacío
                            medicacionSeleccionada = "Sin medicación";
                        }
                        cmd.Parameters.AddWithValue("@dni", this.dni);
                        cmd.Parameters.AddWithValue("@tipo", tipoRegistro ?? "Consulta Médica");
                        cmd.Parameters.AddWithValue("@obs", observaciones);
                        cmd.Parameters.AddWithValue("@medicacion", medicacionSeleccionada);
                        cmd.Parameters.AddWithValue("@fecha", fecha);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Registro agregado correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Volver al historial
                    if (controlPadreRegistro is HistorialClinicoControl historialControl)
                    {
                        historialControl.CargarHistoriales(this.dni);
                    }
                    AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, controlPadreRegistro, false));
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

       /* public void CargarRegistroParaEdicion(Registro registro)
        {

        }*/
    }
}
