using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class InformeControl : UserControlProyecto
    {
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";
        private DateTime fecha_inicio = new DateTime(1900, 01, 01);
        private DateTime fecha_fin = new DateTime(1900, 01, 01);
        private TimeSpan dif_fechas => fecha_fin - fecha_inicio;
        public InformeControl()
        {
            InitializeComponent();
        }

        private void InformeControl_Load(object sender, EventArgs e)
        {
            cbDecisionIntervalo.SelectedIndex = 0;

            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;

            dtpFechaFin.MaxDate = DateTime.Now;
            dtpFechaInicio.MaxDate = DateTime.Now;

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

        private string DeterminarEscalaTiempo()
        {
            string escala = dif_fechas.TotalDays switch
            {
                (< 0) => "error", // Invalido
                (>= 0 and <= 7) => "nombre_dias", // Lunes, martes, miercoles, etc...
                (>= 7 and < 14) => "fechas_nombres_dias", // Lunes 01/Enero, martes 02/Enero, ..., lunes 08/Enero...
                (>= 14 and <= 31) => "semanas", // Semana 1, semana 2, semana  3, semana 4.
                (> 31 and <= 90) => "semanas_meses", // Semana 1/Enero, semana 2/Enero, ... , semana 1 febrero, semana 2 febrero.
                (> 90 and <= 365) => "meses", // Enero, febrero, marzo, ...
                (> 365 and <= 730) => "meses_años", // Enero 2025, febrero 2025, marzo 2025, etc...
                (> 730) => "años" // 2025, 2026, etc...
            };
            return escala;
        }

        private List<string> GenerarEtiquetas(DateTime inicio, DateTime fin, string escala)
        {
            var etiquetas = new List<string>();

            switch (escala)
            {
                case "nombre_dias":
                    for (var dia = inicio; dia <= fin; dia = dia.AddDays(1))
                        etiquetas.Add(dia.ToString("dddd", new CultureInfo("es-ES"))); // lunes, martes...
                    break;

                case "fechas_nombres_dias":
                    for (var dia = inicio; dia <= fin; dia = dia.AddDays(1))
                        etiquetas.Add(dia.ToString("ddd dd/MM")); // Lun 01/10
                    break;

                case "semanas":
                    int semana = 1;
                    for (var dia = inicio; dia <= fin; dia = dia.AddDays(7))
                    {
                        etiquetas.Add($"Semana {semana}");
                        semana++;
                    }
                    break;

                case "semanas_meses":
                    int semanaMes = 1;
                    DateTime current = inicio;
                    while (current <= fin)
                    {
                        etiquetas.Add($"Semana {semanaMes}/{current.ToString("MMM", new CultureInfo("es-ES"))}");
                        current = current.AddDays(7);
                        semanaMes++;
                    }
                    break;

                case "meses":
                    DateTime mes = new DateTime(inicio.Year, inicio.Month, 1);
                    while (mes <= fin)
                    {
                        etiquetas.Add(mes.ToString("MMMM", new CultureInfo("es-ES"))); // Enero, Febrero...
                        mes = mes.AddMonths(1);
                    }
                    break;

                case "meses_años":
                    DateTime mesAnio = new DateTime(inicio.Year, inicio.Month, 1);
                    while (mesAnio <= fin)
                    {
                        etiquetas.Add(mesAnio.ToString("MMMM yyyy", new CultureInfo("es-ES"))); // Enero 2025
                        mesAnio = mesAnio.AddMonths(1);
                    }
                    break;

                case "años":
                    for (int año = inicio.Year; año <= fin.Year; año++)
                        etiquetas.Add(año.ToString());
                    break;
            }
            return etiquetas;
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
