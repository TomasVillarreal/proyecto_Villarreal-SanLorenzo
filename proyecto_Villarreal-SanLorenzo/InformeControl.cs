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
            cbDecisionIntervalo.SelectedIndex = 4;
            cbSeleccionGrafico.SelectedIndex = 0;

            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;

            dtpFechaFin.MaxDate = DateTime.Now;
            dtpFechaInicio.MaxDate = DateTime.Now;

            ActualizarStats();

            GraficarSegunRadioButton();
        }

        private void ActualizarStats()
        {
            lMedicoActivo.Text = ObtenerMedicoActivo(fecha_inicio, fecha_fin);
            AjustarLabelIzquierda(lMedicoActivo);
            lFecha.Text = ObtenerFechaActividad(fecha_inicio, fecha_fin);
            AjustarLabelIzquierda(lFecha);
            lTotalRegistros.Text = ObtenerTotalRegistros(fecha_inicio, fecha_fin).ToString();
            lPromedioRegistros.Text = ObtenerPromedioRegistros(fecha_inicio, fecha_fin).ToString("0.00");
        }

        private void AjustarLabelIzquierda(Label label, int margenDerecho = 10)
        {
            using (Graphics g = label.CreateGraphics())
            {
                SizeF textoSize = g.MeasureString(label.Text, label.Font);

                // Calcular posición para que no se corte
                int nuevaX = label.Parent.Width - (int)textoSize.Width - margenDerecho;

                // Evitar que se salga del panel (por si el texto es muy largo)
                if (nuevaX < 0)
                    nuevaX = 0;

                label.Left = nuevaX;
            }
        }

        private string FormatearListaNatural(List<string> items)
        {
            if (items == null || items.Count == 0)
                return "No hay registros en el rango";

            if (items.Count == 1)
                return items[0];

            if (items.Count == 2)
                return $"{items[0]} y {items[1]}";

            return string.Join(", ", items.Take(items.Count - 1)) + " y " + items.Last();
        }

        private int ObtenerTotalRegistros(DateTime inicio, DateTime fin)
        {
            int total_registros = 0;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT COUNT (*) FROM Registro WHERE fecha_registro BETWEEN @inicio AND @fin";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);
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

        private string ObtenerFechaActividad(DateTime inicio, DateTime fin)
        {
            string resultado = "";
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string query = @"
                        WITH Conteo AS (
                            SELECT 
                                CAST(fecha_registro AS DATE) AS fecha,
                                COUNT(*) AS Cantidad
                            FROM Registro
                            WHERE fecha_registro BETWEEN @inicio AND @fin
                            GROUP BY CAST(fecha_registro AS DATE)
                        )
                        SELECT fecha
                        FROM Conteo
                        WHERE Cantidad = (SELECT MAX(Cantidad) FROM Conteo)
                        ORDER BY fecha;";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);

                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<string> fechas = new List<string>();

                        while (reader.Read())
                        {
                            DateTime f = Convert.ToDateTime(reader["fecha"]);
                            fechas.Add(f.ToString("dd/MM/yyyy"));
                        }

                        if (fechas.Count == 0)
                            resultado = "No hay registros en el rango";
                        else if (fechas.Count == 1)
                            resultado = fechas[0];
                        else
                            resultado = FormatearListaNatural(fechas);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        private string ObtenerMedicoActivo(DateTime inicio, DateTime fin)
        {
            string resultado = "";
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string query = @"
                        WITH Conteo AS (
                            SELECT 
                                u.nombre_usuario + ' ' + u.apellido_usuario AS nombre_completo,
                                COUNT(*) AS Cantidad
                            FROM Registro r
                            INNER JOIN Usuarios u ON r.id_usuario = u.id_usuario
                            WHERE r.fecha_registro BETWEEN @inicio AND @fin
                            GROUP BY u.nombre_usuario, u.apellido_usuario
                        )
                        SELECT nombre_completo
                        FROM Conteo
                        WHERE Cantidad = (SELECT MAX(Cantidad) FROM Conteo);";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);

                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<string> medicos = new List<string>();

                        while (reader.Read())
                            medicos.Add(reader["nombre_completo"].ToString());

                        if (medicos.Count == 0)
                            resultado = "No hay registros en el rango";
                        else if (medicos.Count == 1)
                            resultado = medicos[0];
                        else
                            resultado = FormatearListaNatural(medicos);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
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
                        else
                        {
                            fechaAntigua = new DateTime(1900, 01, 01);
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

        private double ObtenerPromedioRegistros(DateTime inicio, DateTime fin)
        {
            double promedio = 0;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Se crea la query para contar las filas
                    string queryNroPacientes = "SELECT CAST(COUNT(*) AS FLOAT) / COUNT(DISTINCT CAST(fecha_registro AS DATE)) " +
                        "AS PromedioRegistrosPorPaciente FROM Registro WHERE fecha_registro BETWEEN @inicio AND @fin;";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);

                        db.Open();
                        // Guardo el total y lo pongo en el texto del label correspondiente
                        promedio = Convert.ToDouble(cmd.ExecuteScalar());
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 8134)
                {
                    promedio = 0;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return promedio;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbDecisionIntervalo.SelectedItem.ToString();
            panelSeleccionIntervalo.Visible = opcion == "Personalizado";
            bActualizarGrafico.Visible = opcion == "Personalizado";
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
                    fecha_inicio = ObtenerFechaMasAntigua().Date == new DateTime(1900, 01, 01) ? new DateTime(2023, 01, 01) : ObtenerFechaMasAntigua().Date;
                    fecha_fin = hoy.AddDays(1).AddSeconds(-1);
                    break;
                case "Personalizado":
                    // Para personalizado, usar valores de los DateTimePickers (actualizados en Leave events)
                    fecha_inicio = dtpFechaInicio.Value.Date;
                    fecha_fin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);
                    break;
            }
            // CORREGIDO: Actualizar el gráfico automáticamente al cambiar la selección (excepto si es personalizado, que usa botón)
            if (opcion != "Personalizado")
            {
                GraficarSegunRadioButton();
                ActualizarStats();
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
            if (dias <= 730) return "meses_años"; // rango >1 año => mostrar meses con años
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

        private void RealizarGraficoTiempo(List<string> etiquetas, List<int> valores)
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

        private void GraficarSegunTiempo()
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
            RealizarGraficoTiempo(etiquetas, valores);
        }

        private List<(string NombreMostrar, int CantidadRegistros)> ObtenerDatosPorMedico(DateTime inicio, DateTime fin)
        {
            var resultados = new List<(string, int)>();

            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    u.id_usuario,
                    u.nombre_usuario,
                    u.apellido_usuario,
                    COUNT(*) AS CantidadRegistros
                FROM Registro r
                INNER JOIN Usuarios u ON r.id_usuario = u.id_usuario
                WHERE fecha_registro BETWEEN @inicio AND @fin
                GROUP BY u.id_usuario, u.nombre_usuario, u.apellido_usuario
                ORDER BY COUNT(*) DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);

                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        var listaTemporal = new List<(int Id, string Nombre, string Apellido, int Cantidad)>();

                        while (reader.Read())
                        {
                            listaTemporal.Add((
                                Convert.ToInt32(reader["id_usuario"]),
                                reader["nombre_usuario"].ToString(),
                                reader["apellido_usuario"].ToString(),
                                Convert.ToInt32(reader["CantidadRegistros"])
                            ));
                        }

                        // Resolver apellidos repetidos
                        var gruposPorApellido = listaTemporal.GroupBy(x => x.Apellido);
                        foreach (var grupo in gruposPorApellido)
                        {
                            if (grupo.Count() == 1)
                            {
                                var unico = grupo.First();
                                resultados.Add(($"{unico.Apellido}", unico.Cantidad));
                            }
                            else
                            {
                                // Si hay repetidos, agregar iniciales del nombre
                                foreach (var medico in grupo)
                                {
                                    string[] partesNombre = medico.Nombre.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                    string iniciales = "";
                                    if (partesNombre.Length >= 1) iniciales += partesNombre[0][0];
                                    if (partesNombre.Length >= 2) iniciales += partesNombre[1][0];
                                    resultados.Add(($"{medico.Apellido} {iniciales.ToUpper()}", medico.Cantidad));
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener datos de médicos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultados;
        }

        private void GraficarSegunMedicos()
        {
            try
            {
                // 1️⃣ Obtener datos de médicos activos en el rango
                var datosMedicos = ObtenerDatosPorMedico(fecha_inicio, fecha_fin);

                // 2️⃣ Generar etiquetas (nombres) y valores (cantidad de registros)
                var etiquetas = datosMedicos.Select(d => d.NombreMostrar).ToList();
                var valores = datosMedicos.Select(d => d.CantidadRegistros).ToList();

                // 3️⃣ Graficar reutilizando la misma función de visualización
                RealizarGraficoMedicos(etiquetas, valores);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al graficar por médicos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void RealizarGraficoMedicos(List<string> etiquetas, List<int> valores)
        {
            panelGrafico.Controls.Clear();
            Chart chart = new Chart { Dock = DockStyle.Fill };
            panelGrafico.Controls.Add(chart);
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            chartArea.AxisX.Title = "Médicos activos";
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
                Name = "Registros por Médico",
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

            chart.Titles.Add("Registros clínicos por médico activo");
            if (valores.All(v => v == 0))
            {
                chart.Titles[0].Text += " (No hay datos en este rango)";
            }

            chart.BackColor = Color.WhiteSmoke;
            chartArea.BackColor = Color.White;
        }

        private void GraficarSegunTiposConsulta()
        {
            try
            {
                // 1️⃣ Obtener datos agrupados por tipo de consulta
                var datosTipos = ObtenerDatosPorTipoConsulta(fecha_inicio, fecha_fin);

                // 2️⃣ Generar etiquetas (tipos) y valores (cantidad de registros)
                var etiquetas = datosTipos.Select(d => d.NombreMostrar).ToList();
                var valores = datosTipos.Select(d => d.CantidadRegistros).ToList();

                // 3️⃣ Reutilizar la función de graficado
                RealizarGraficoTiposConsulta(etiquetas, valores);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al graficar por tipos de consulta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<(string NombreMostrar, int CantidadRegistros)> ObtenerDatosPorTipoConsulta(DateTime inicio, DateTime fin)
        {
            var resultados = new List<(string, int)>();

            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    t.nombre_registro AS TipoConsulta,
                    COUNT(*) AS CantidadRegistros
                FROM Registro r
                INNER JOIN Tipo_registro t ON r.id_tipo_registro = t.id_tipo_registro
                WHERE r.fecha_registro BETWEEN @inicio AND @fin
                GROUP BY t.nombre_registro
                ORDER BY COUNT(*) DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);

                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            resultados.Add((
                                reader["TipoConsulta"].ToString(),
                                Convert.ToInt32(reader["CantidadRegistros"])
                            ));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener datos de tipos de consulta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultados;
        }

        private void RealizarGraficoTiposConsulta(List<string> etiquetas, List<int> valores)
        {
            panelGrafico.Controls.Clear();
            Chart chart = new Chart { Dock = DockStyle.Fill };
            panelGrafico.Controls.Add(chart);

            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            chartArea.AxisX.Title = "Tipos de consulta";
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
                Name = "Registros por Tipo de Consulta",
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

            chart.Titles.Add("Registros clínicos por tipo de consulta");
            if (valores.All(v => v == 0))
            {
                chart.Titles[0].Text += " (No hay datos en este rango)";
            }

            chart.BackColor = Color.WhiteSmoke;
            chartArea.BackColor = Color.White;
        }

        private void GraficarSegunRadioButton()
        {
            if (cbSeleccionGrafico.SelectedItem.ToString() == "Segun tiempos")
            {
                GraficarSegunTiempo();
            }
            else if (cbSeleccionGrafico.SelectedItem.ToString() == "Segun medicos")
            {
                GraficarSegunMedicos();
            }
            else if (cbSeleccionGrafico.SelectedItem.ToString() == "Segun consultas")
            {
                GraficarSegunTiposConsulta();
            }
        }

        private void cbSeleccionGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {
            GraficarSegunRadioButton();
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
            ActualizarStats();
        }

    }
}

