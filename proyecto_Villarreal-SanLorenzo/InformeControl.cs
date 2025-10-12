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
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class InformeControl : UserControlProyecto
    {
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";
        private DateTime fecha_inicio = new DateTime(1900, 01, 01);
        private DateTime fecha_fin = new DateTime(1900, 01, 01);
        public InformeControl()
        {
            InitializeComponent();
        }

        private void InformeControl_Load(object sender, EventArgs e)
        {
            cbDecisionIntervalo.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;

            lMedicoActivo.Text = ObtenerMedicoActivo();
            lFecha.Text = ObtenerFechaActividad();
            lTotalRegistros.Text = ObtenerTotalRegistros().ToString();
            lPromedioRegistros.Text = ObtenerPromedioRegistros().ToString("0.00");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDecisionIntervalo.SelectedItem.ToString() == "Personalizado")
            {
                panelSeleccionIntervalo.Visible = true;
            }
            else if (cbDecisionIntervalo.SelectedItem.ToString() == "Ultima semana")
            {
                fecha_fin = DateTime.Now;
                fecha_inicio = fecha_fin.AddDays(-7);
            }
            else if (cbDecisionIntervalo.SelectedItem.ToString() == "Ultimo mes")
            {
                fecha_fin = DateTime.Now;
                fecha_inicio = fecha_fin.AddMonths(-1);
            }
            else if (cbDecisionIntervalo.SelectedItem.ToString() == "Ultimo año")
            {
                fecha_fin = DateTime.Now;
                fecha_inicio = fecha_fin.AddYears(-1);
            }
            else if (cbDecisionIntervalo.SelectedItem.ToString() == "Todos los tiempos")
            {
                fecha_fin = DateTime.Now;
            }
        }

        private int ObtenerTotalRegistros()
        {
            int total_registros = 0;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT COUNT (*) FROM Registro";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        // Guardo el total y lo pongo en el texto del label correspondiente
                        total_registros = (int)cmd.ExecuteScalar();
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return total_registros;
        }

        private string ObtenerFechaActividad()
        {
            string fecha = "";
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT TOP 1  CAST(fecha_registro AS DATE) AS fecha_maxima, COUNT(*) AS CantidadRegistros FROM Registro " +
                        "GROUP BY CAST(fecha_registro AS DATE) ORDER BY CantidadRegistros DESC";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) // avanza al primer registro
                        {
                            DateTime fechaRegistro = Convert.ToDateTime(reader["fecha_maxima"]);
                            fecha = fechaRegistro.ToString("dd/MM/yyyy");
                        }
                    }
                    db.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return fecha;
        }

        private string ObtenerMedicoActivo()
        {
            string nombre = "";
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT TOP 1 u.nombre_usuario + ' ' + u.apellido_usuario AS nombre_completo, " +
                        "COUNT(*) AS CantidadRegistros FROM Registro r " +
                        "INNER JOIN Usuarios u ON r.id_usuario = u.id_usuario GROUP BY r.id_usuario, u.nombre_usuario, u.apellido_usuario ORDER BY CantidadRegistros DESC";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) // avanza al primer registro
                        {
                            nombre = reader["nombre_completo"].ToString();
                        }
                    }
                    db.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nombre;
        }

        private double ObtenerPromedioRegistros()
        {
            double promedio = 0;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT CAST(COUNT(*) AS FLOAT) / COUNT(DISTINCT CAST(fecha_registro AS DATE)) AS PromedioRegistrosPorPaciente FROM Registro;";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        // Guardo el total y lo pongo en el texto del label correspondiente
                        promedio = Convert.ToDouble(cmd.ExecuteScalar());
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return promedio;
        }

        private void dtpFechaInicio_Leave(object sender, EventArgs e)
        {
            dtpFechaFin.MinDate = dtpFechaInicio.Value;
            fecha_inicio = dtpFechaInicio.Value;
        }

        private void dtpFechaFin_Leave(object sender, EventArgs e)
        {
            fecha_fin = dtpFechaFin.Value;
        }
    }
}
