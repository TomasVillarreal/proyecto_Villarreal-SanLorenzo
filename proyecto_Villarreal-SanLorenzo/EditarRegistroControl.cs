using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class EditarRegistroControl : UserControlProyecto
    {
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;

        public HistorialClinicoControl controlPadreRegistro;

        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";

        int dni = 0;
        int idRegistroActual = 0;


        public EditarRegistroControl(int p_dni, int p_registro_actual = 0)
        {
            InitializeComponent();

            dni = p_dni;
            idRegistroActual = p_registro_actual;

            CargarDatosPaciente(dni);
            CargarTiposRegistro();
            CargarMedicaciones();

            if (idRegistroActual > 0)
                CargarRegistroParaEdicion(idRegistroActual);

            lDosis.Visible = false;
            tDosis.Visible = false;
        }

        public void CargarRegistroParaEdicion(int idRegistro)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            r.observaciones, 
                            tr.nombre_registro, 
                            m.nombre_medicacion, 
                            m.dosis_medicacion AS dosis
                        FROM Registro r
                        LEFT JOIN Tipo_registro tr ON r.id_tipo_registro = tr.id_tipo_registro
                        LEFT JOIN Registro_medicacion rm ON r.id_registro = rm.id_registro
                        LEFT JOIN Medicacion m ON rm.id_medicacion = m.id_medicacion
                        WHERE r.id_registro = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idRegistro);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // observaciones
                                tObservaciones.Text = reader["observaciones"]?.ToString() ?? string.Empty;

                                // tipo de registro
                                string tipo = reader["nombre_registro"]?.ToString();
                                if (!string.IsNullOrEmpty(tipo))
                                    comboBoxTipoRegistro.SelectedItem = tipo;

                                // medicación (nombre)
                                string medicacion = reader["nombre_medicacion"]?.ToString();
                                if (!string.IsNullOrEmpty(medicacion))
                                {
                                    comboBoxMedicacion.SelectedItem = medicacion;
                                    lDosis.Visible = true;
                                    tDosis.Visible = true;
                                    tDosis.Text = reader["dosis"]?.ToString() ?? string.Empty;
                                }
                                else
                                {
                                    comboBoxMedicacion.SelectedIndex = 0; // "(ninguna)"
                                    lDosis.Visible = false;
                                    tDosis.Visible = false;
                                    tDosis.Text = string.Empty;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el registro en la base de datos.", 
                                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
        }

        this.idRegistroActual = idRegistro;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al cargar el registro para edición: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void bAtras_Click(object sender, EventArgs e)//Funcion que permite volver a la vista anterior
        {
            var parent = this.Parent; // obtenemos el contenedor del control actual

            if (parent != null && controlPadreRegistro != null)
            {
                controlPadreRegistro.CargarHistoriales(dni);
                parent.Controls.Clear();
                parent.Controls.Add(controlPadreRegistro);
                controlPadreRegistro.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("No se pudo volver atrás.");
            }
        }
        private void comboBoxMedicacion_SelectedIndexChanged(object sender, EventArgs e)
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
        }//Funcion que permite mostrar el textbox de la dosis solo si se seleccionó un medicamento

        private void bGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE Registro
                             SET observaciones = @obs,
                                 id_tipo_registro = (SELECT id_tipo_registro FROM Tipo_registro WHERE nombre_registro = @tipo),
                                 id_medicacion = (SELECT id_medicacion FROM Medicacion WHERE nombre_medicacion = @medicacion),
                                 dosis = @dosis
                             WHERE id_registro = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@obs", tObservaciones.Text.Trim());
                        cmd.Parameters.AddWithValue("@tipo", comboBoxTipoRegistro.SelectedItem?.ToString() ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@medicacion",(comboBoxMedicacion.SelectedItem != null &&comboBoxMedicacion.SelectedItem.ToString() != "(ninguna)")
                                                                    ? comboBoxMedicacion.SelectedItem.ToString() : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@dosis", string.IsNullOrWhiteSpace(tDosis.Text) ? (object)DBNull.Value : tDosis.Text);
                        cmd.Parameters.AddWithValue("@id", idRegistroActual);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                            MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se realizaron cambios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
