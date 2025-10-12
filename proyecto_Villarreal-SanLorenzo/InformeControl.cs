using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

            GraficarSegunRadioButton();
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

        private DateTime ObtenerFechaMasAntigua()
        {
            DateTime fechaAntigua = new DateTime(1900, 01, 01);
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT TOP 1  fecha_registro FROM Registro " +
                        "ORDER BY fecha_registro ASC";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) // avanza al primer registro
                        {
                            fechaAntigua = Convert.ToDateTime(reader["fecha_registro"]);
                        }
                    }
                    db.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return fechaAntigua;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbDecisionIntervalo.SelectedItem.ToString();
            panelSeleccionIntervalo.Visible = opcion == "Personalizado";
            DateTime hoy = DateTime.Now.Date; // solo fecha sin hora
            switch (opcion)
            {
                case "Ultima semana":
                    fecha_fin = hoy.AddDays(1).AddSeconds(-1);       // hasta hoy 23:59:59
                    fecha_inicio = fecha_fin.AddDays(-7 + 1).Date;   // 7 días completos atrás
                    break;
                case "Ultimo mes":
                    // CORREGIDO: Empieza exactamente 1 mes atrás al día actual (ej: hoy 12/10 -> 12/09)
                    fecha_inicio = hoy.AddMonths(-1).Date;
                    fecha_fin = hoy.AddDays(1).AddSeconds(-1);
                    break;
                case "Ultimo año":
                    // MODIFICADO: Exacto 1 año atrás (sin +1 día extra)
                    fecha_inicio = hoy.AddYears(-1).Date;
                    fecha_fin = hoy.AddDays(1).AddSeconds(-1);
                    break;
                case "Todos los tiempos":
                    fecha_inicio = ObtenerFechaMasAntigua().Date;
                    fecha_fin = hoy.AddDays(1).AddSeconds(-1);
                    break;
                case "Personalizado":
                    // Para personalizado, usar valores de los DateTimePickers (actualizados en Leave events)
                    fecha_inicio = dtpFechaInicio.Value.Date;
                    fecha_fin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);
                    break;
            }
            // CORREGIDO: Actualizar el gráfico automáticamente al cambiar la selección (excepto si es personalizado, que usa botón)
            if (opcion != "Personalizado" && rbFechas.Checked)
            {
                GraficarSegunRadioButton();
            }
        }

        private string DeterminarEscalaTiempo()
        {
            double dias = dif_fechas.TotalDays;
            int aniosDiff = fecha_fin.Year - fecha_inicio.Year;
            if (dias < 0) return "error";
            if (dias <= 7) return "nombre_dias";
            if (dias <= 14) return "fechas_nombres_dias";
            if (dias <= 31) return "semanas";
            if (dias <= 90) return "semanas_meses";
            if (dias <= 365) return "meses";
            if (aniosDiff >= 1) return "meses_años"; // rango >1 año => mostrar meses con años
            return "años";
        }

        private (List<string> Etiquetas, List<DateTime> Periodos) GenerarEtiquetasYPeriodos(DateTime inicio, DateTime fin, string escala)
        {
            var etiquetas = new List<string>();
            var periodos = new List<DateTime>();  // Representante de cada período (ej: primer día)
            var cultura = new CultureInfo("es-ES");
            switch (escala)
            {
                case "nombre_dias":
                    for (var dia = inicio.Date; dia <= fin.Date; dia = dia.AddDays(1))
                    {
                        etiquetas.Add(dia.ToString("dddd", cultura));  // "lunes"
                        periodos.Add(dia.Date);
                    }
                    break;
                case "fechas_nombres_dias":
                    for (var dia = inicio.Date; dia <= fin.Date; dia = dia.AddDays(1))
                    {
                        etiquetas.Add(dia.ToString("ddd dd/MM", cultura));  // "Lun 01/10"
                        periodos.Add(dia.Date);
                    }
                    break;
                case "semanas":
                case "semanas_meses":
                    // CORREGIDO: Cálculo consistente para lunes de inicio de semana (coincide con SQL)
                    int daysToSubtract = ((int)inicio.DayOfWeek - 1 + 7) % 7;
                    var currentSemana = inicio.Date.AddDays(-daysToSubtract);  // Lunes de la semana que contiene 'inicio'
                    int numSemana = 1;
                    while (currentSemana <= fin.Date)
                    {
                        var finSemana = currentSemana.AddDays(6);  // Domingo de fin
                        if (finSemana > fin.Date) finSemana = fin.Date;  // Ajusta si excede
                        if (escala == "semanas")
                        {
                            etiquetas.Add($"Semana {numSemana} ({currentSemana:dd/MM} - {finSemana:dd/MM})");
                        }
                        else
                        {
                            var mesInicio = currentSemana.ToString("MMM", cultura);
                            etiquetas.Add($"Semana {numSemana}/{mesInicio} ({currentSemana:dd/MM} - {finSemana:dd/MM})");
                        }
                        periodos.Add(currentSemana.Date);  // Representante: lunes de inicio
                        currentSemana = currentSemana.AddDays(7);
                        numSemana++;
                    }
                    break;
                case "meses":
                    var mes = new DateTime(inicio.Year, inicio.Month, 1);
                    while (mes <= fin)
                    {
                        var finMes = mes.AddMonths(1).AddDays(-1);  // Último día del mes
                        if (finMes > fin) finMes = fin.Date;
                        etiquetas.Add(mes.ToString("MMM", cultura));  // "Oct"
                        periodos.Add(mes.Date);  // 1er día del mes
                        mes = mes.AddMonths(1);
                    }
                    break;
                case "meses_años":
                    var mesAnio = new DateTime(inicio.Year, inicio.Month, 1);
                    while (mesAnio <= fin)
                    {
                        var finMes = mesAnio.AddMonths(1).AddDays(-1);
                        if (finMes > fin) finMes = fin.Date;
                        etiquetas.Add(mesAnio.ToString("MMM yyyy", cultura));  // "Oct 2025"
                        periodos.Add(mesAnio.Date);
                        mesAnio = mesAnio.AddMonths(1);
                    }
                    break;
                case "años":
                    for (int año = inicio.Year; año <= fin.Year; año++)
                    {
                        var inicioAnio = new DateTime(año, 1, 1);
                        var finAnio = new DateTime(año, 12, 31);
                        if (inicioAnio < inicio) inicioAnio = inicio.Date;
                        if (finAnio > fin) finAnio = fin.Date;
                        etiquetas.Add(año.ToString());
                        periodos.Add(inicioAnio.Date);  // 1/1 del año (ajustado)
                    }
                    break;
            }
            return (etiquetas, periodos);
        }

        private Dictionary<DateTime, int> ObtenerDatosPorPeriodos(DateTime inicio, DateTime fin, string escala)
        {
            var resultados = new Dictionary<DateTime, int>();
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string query = "";
                    // CORREGIDO: Queries ajustadas, especialmente para semanas (coincide con C# para lunes)
                    switch (escala)
                    {
                        case "nombre_dias":
                        case "fechas_nombres_dias":
                            // Agrupar por día exacto
                            query = @"
                                SELECT 
                                    CAST(fecha_registro AS DATE) AS PeriodoRep,
                                    COUNT(*) AS Cantidad
                                FROM Registro
                                WHERE fecha_registro BETWEEN @inicio AND @fin
                                GROUP BY CAST(fecha_registro AS DATE)
                                ORDER BY PeriodoRep";
                            break;
                        case "semanas":
                        case "semanas_meses":
                            // CORREGIDO: Calcular lunes de inicio de semana consistente (Sunday=1 en SQL Server default)
                            query = @"
                                SELECT 
                                    DATEADD(DAY, -((DATEPART(WEEKDAY, CAST(fecha_registro AS DATE)) + 5) % 7), CAST(fecha_registro AS DATE)) AS PeriodoRep,
                                    COUNT(*) AS Cantidad
                                FROM Registro
                                WHERE fecha_registro BETWEEN @inicio AND @fin
                                GROUP BY DATEADD(DAY, -((DATEPART(WEEKDAY, CAST(fecha_registro AS DATE)) + 5) % 7), CAST(fecha_registro AS DATE))
                                ORDER BY PeriodoRep";
                            break;
                        case "meses":
                        case "meses_años":
                            // Agrupar por 1er día del mes
                            query = @"
                                SELECT 
                                    DATEFROMPARTS(YEAR(fecha_registro), MONTH(fecha_registro), 1) AS PeriodoRep,
                                    COUNT(*) AS Cantidad
                                FROM Registro
                                WHERE fecha_registro BETWEEN @inicio AND @fin
                                GROUP BY YEAR(fecha_registro), MONTH(fecha_registro)
                                ORDER BY PeriodoRep";
                            break;
                        case "años":
                            // Agrupar por 1/1 del año
                            query = @"
                                SELECT 
                                    DATEFROMPARTS(YEAR(fecha_registro), 1, 1) AS PeriodoRep,
                                    COUNT(*) AS Cantidad
                                FROM Registro
                                WHERE fecha_registro BETWEEN @inicio AND @fin
                                GROUP BY YEAR(fecha_registro)
                                ORDER BY PeriodoRep";
                            break;
                    }
                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DateTime periodoRep = Convert.ToDateTime(reader["PeriodoRep"]);
                            int cantidad = Convert.ToInt32(reader["Cantidad"]);
                            resultados[periodoRep.Date] = cantidad;  // Key: fecha representativa
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultados;
        }

        private void GraficarTiempo(List<string> etiquetas, List<int> valores)
        {
            panelGrafico.Controls.Clear();
            Chart chart = new Chart { Dock = DockStyle.Fill };
            panelGrafico.Controls.Add(chart);
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);
            chartArea.AxisX.Title = "Intervalo de tiempo";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.Title = "Cantidad de registros";
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartArea.AxisY.LabelStyle.Format = "N0";
            chartArea.AxisY.Enabled = AxisEnabled.True;
            int maxValor = valores.Count > 0 ? valores.Max() : 0;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = maxValor == 0 ? 10 : maxValor * 1.2;
            chartArea.AxisY.Interval = maxValor <= 10 ? 1 : Math.Ceiling(maxValor / 5.0);
            Series series = new Series
            {
                Name = "Registros",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelFormat = "N0"
            };
            chart.Series.Add(series);
            for (int i = 0; i < etiquetas.Count; i++)
            {
                DataPoint dp = new DataPoint
                {
                    YValues = new double[] { valores[i] },
                    AxisLabel = etiquetas[i]
                };
                series.Points.Add(dp);
            }
            chart.Titles.Add("Registros clínicos por intervalo");
            if (valores.All(v => v == 0))
            {
                chart.Titles[0].Text += " (No hay datos en este rango)";
            }
            chart.BackColor = Color.WhiteSmoke;
            chartArea.BackColor = Color.White;
        }

        private void dtpFechaInicio_Leave(object sender, EventArgs e)
        {
            dtpFechaFin.MinDate = dtpFechaInicio.Value;
            fecha_inicio = dtpFechaInicio.Value;
        }

        private void dtpFechaFin_Leave(object sender, EventArgs e)
        {
            fecha_fin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);
        }

        private void bActualizarGrafico_Click(object sender, EventArgs e)
        {
            GraficarSegunRadioButton();
        }

        private void GraficarSegunRadioButton()
        {
            if (rbFechas.Checked)
            {
                // NUEVO: Determinar escala
                string escala = DeterminarEscalaTiempo();
                if (escala == "error") return;  // Rango inválido
                // NUEVO: Generar etiquetas y períodos en paralelo
                var (etiquetas, periodos) = GenerarEtiquetasYPeriodos(fecha_inicio, fecha_fin, escala);
                // NUEVO: Obtener datos por períodos
                var datos = ObtenerDatosPorPeriodos(fecha_inicio, fecha_fin, escala);
                // NUEVO: Alinear valores (simple: por índice, usando periodos como key)
                var valores = new List<int>();
                foreach (var periodo in periodos)
                {
                    if (datos.TryGetValue(periodo.Date, out int cantidad))
                    {
                        valores.Add(cantidad);
                    }
                    else
                    {
                        valores.Add(0);  // No hay datos en este período
                    }
                }
                GraficarTiempo(etiquetas, valores);
            }
        }

    }
}

