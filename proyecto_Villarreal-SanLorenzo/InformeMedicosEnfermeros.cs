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
using System.Windows.Forms.DataVisualization.Charting;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class InformeMedicosEnfermeros : UserControlProyecto
    {
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";
        private DateTime fecha_inicio = new DateTime(1900, 01, 01);
        private DateTime fecha_fin = new DateTime(1900, 01, 01);
        private TimeSpan dif_fechas => fecha_fin - fecha_inicio;

        public InformeMedicosEnfermeros()
        {
            InitializeComponent();
        }

        private void InformeMedicosEnfermeros_Load(object sender, EventArgs e)
        {
            cbDecisionIntervalo.SelectedIndex = 4;

            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;

            dtpFechaFin.MaxDate = DateTime.Now;
            dtpFechaInicio.MaxDate = DateTime.Now;

            GraficarSegunTiposConsulta();
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
                GraficarSegunTiposConsulta();
                //ActualizarStats();
            }
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
                    AND id_usuario = @usuario
                GROUP BY t.nombre_registro
                ORDER BY COUNT(*) DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);
                        cmd.Parameters.AddWithValue("@usuario", SesionUsuario.id_usuario);

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
            GraficarSegunTiposConsulta();
        }
    }
}
