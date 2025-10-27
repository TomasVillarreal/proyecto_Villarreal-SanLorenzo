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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class InformeControl : UserControlProyecto
    {
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";
        // Atributos con el cual calcularemos los periodos de tiempo por el cual obtendremos los datos
        private DateTime fecha_inicio = new DateTime(1900, 01, 01);
        private DateTime fecha_fin = new DateTime(1900, 01, 01);
        // Atributo que representa la cantidad de dias de diferencia entre los atributos de tiempo
        private TimeSpan dif_fechas => fecha_fin - fecha_inicio;

        public InformeControl()
        {
            InitializeComponent();
        }

        // Al cargar el usercontrol:
        private void InformeControl_Load(object sender, EventArgs e)
        {
            // Pondremos el combobox dela decision de periodo de tiempo en "Personalizado"
            cbDecisionIntervalo.SelectedIndex = 4;
            // Y la de seleccion de grafico en "Segun tiempos"
            cbSeleccionGrafico.SelectedIndex = 0;

            // En un principio, colocaremos la fecha actual en los datatimepicker (dtp)
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;

            // Y pondremos que la fecha maxima de ambos dtp en la fecha actual
            dtpFechaFin.MaxDate = DateTime.Now;
            dtpFechaInicio.MaxDate = DateTime.Now;

            // Graficamos y actualizamos las stats
            ActualizarStats();
            GraficarSegunRadioButton();
        }

        /* Funcion que hace que basicamente el panel con estadisticas
         * no graficas se actualice cada vez q se cambia el periodo de tiempo */
        private void ActualizarStats()
        {
            lMedicoActivo.Text = ObtenerMedicoActivo(fecha_inicio, fecha_fin);
            /* Ajusto el texto un poco para que entre en el panel, en caso de que haya
             * mas de un medico */
            AjustarLabelIzquierda(lMedicoActivo);
            lFecha.Text = ObtenerFechaActividad(fecha_inicio, fecha_fin);
            /* Ajusto el texto un poco para que entre en el panel, en caso de que haya
             * mas de una fecha */
            AjustarLabelIzquierda(lFecha);
            lTotalRegistros.Text = ObtenerTotalRegistros(fecha_inicio, fecha_fin).ToString();
            lPromedioRegistros.Text = ObtenerPromedioRegistros(fecha_inicio, fecha_fin).ToString("0.00");
        }

        /* Funcion para ajustar a la izquierda los labels que pueden crecer de acuerdo
         en tamaño debido a que hay mas de un dato que posee la cantidad de registros en 
        ese periodo de tiempo. Ej: por si hay mas de un medico que poseen la misma
        cantidad de registros en un periodo de tiempo determinado. */
        private void AjustarLabelIzquierda(Label label, int margenDerecho = 10)
        {
            // Usaremos un objeto graphics temporal, para calcular el tamaño
            using (Graphics g = label.CreateGraphics())
            {
                // Mediremos el tamaño del label pasado como arg, segun su fuente
                SizeF textoSize = g.MeasureString(label.Text, label.Font);

                // Calcularemos la nueva posicion que tendra nuestro label en base al tamaño de arriba
                int nuevaX = label.Parent.Width - (int)textoSize.Width - margenDerecho;

                // Si el texto es muy largo, haremos q este se alinee con el margen de la izquierda
                if (nuevaX < 0)
                    nuevaX = 0;

                // Colocaremos al label en su nueva posicion
                label.Left = nuevaX;
            }
        }

        // Funcion para formatear el texto con "," y "y".
        private string FormatearListaNatural(List<string> items)
        {
            // Si la lista de items esta vacia, entonces pondremos un texto placeholder
            if (items == null || items.Count == 0)
                return "No hay registros en el rango";

            // Si es exactamente uno el tamaño de la lista, devolveremos el primer item de la lista
            if (items.Count == 1)
                return items[0];

            // Si hay 2 items en la lista, separaremos los items de la lista por una "y"
            if (items.Count == 2)
                return $"{items[0]} y {items[1]}";

            // Si hay mas de 2, entonces iremos separando todos los items de la lista
            // salvo el ultimo, con ",". Y al ultimo lo separamos por un "y"
            return string.Join(", ", items.Take(items.Count - 1)) + " y " + items.Last();
        }

        // Funcion para obtener el total de registros en un periodo dado por una fecha de inicio y final
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

        // Funcion para obtener la fecha de mayor cantidad de registros en el periodo de tiempo pasado como arg.
        private string ObtenerFechaActividad(DateTime inicio, DateTime fin)
        {
            // String con el cual se devolvera el conjunto de resultados formateado
            string resultado = "";
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    /* Query que crea una tabla temporal pura y exclusivamente para este metodo tal que
                     esta tabla contiene un conjunto de distitnas fechas donde el sistema estuvo activo
                    y el total de registros que fueron hechos en dicho dia. Tal que estos registros
                    son agrupados por la fecha y se verifica que dicha fecha este dentro del periodo
                    pasado como argumento. Luego de la creacion de esa tabla temporal,
                    seleccionamos la fecha donde se cumpla que se haya hecho la mayor cantidad de registros
                    de dicha tabla temporal. */
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
                        // Pasamos como argumento las fechas del periodo
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);

                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        // Creamos una lista de fechas con la cual guardaremos los resultados de la query
                        List<string> fechas = new List<string>();

                        while (reader.Read())
                        {
                            // Convertimos la fecha obtenida de la query en un datetime
                            DateTime f = Convert.ToDateTime(reader["fecha"]);
                            // Y lo guardamos en la lista creada arriba con el formato separado por "/"
                            fechas.Add(f.ToString("dd/MM/yyyy"));
                        }

                        // Pequeño formateo
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

        // Funcion para obtener el nombre del medico con mayor cantidad de registros en el periodo de tiempo pasado como arg.
        private string ObtenerMedicoActivo(DateTime inicio, DateTime fin)
        {
            // String con el cual se devolvera el conjunto de resultados formateado
            string resultado = "";
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    /* Query que crea una tabla temporal pura y exclusivamente para este metodo tal que
                     esta tabla contiene un conjunto de distintos nombres de medico que crearon la mayor cantidad de registros
                    y el total de registros que fueron hechos por dicho medico. Tal que estos registros
                    son agrupados por el nombre del medico y se verifica que la fecha donde se hizo el registro este dentro del periodo
                    pasado como argumento. Luego de la creacion de esa tabla temporal,
                    seleccionamos el/los medicos donde se cumpla que estos hayan hecho la mayor cantidad de registros */
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
                        // Pasamos como argumento las fechas del periodo
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);

                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        // Creamos una lista de strings con la cual guardaremos los resultados de la query
                        List<string> medicos = new List<string>();

                        while (reader.Read())
                        {
                            // Añadimos los resultados de la query al vector de arriba
                            medicos.Add(reader["nombre_completo"].ToString());
                        }

                        // Pequeño formateo
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

        // Funcion con el cual obtendremos la fecha mas antigua de actividad en todo el sistema
        // para poder hacer las comparaciones respecto de esta y no de una fecha placeholder
        private DateTime ObtenerFechaMasAntigua()
        {
            // Basicamente una fecha placeholder, en caso de q no haya actividad
            DateTime fechaAntigua = new DateTime(1900, 01, 01);
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Query donde obtendremos la fecha mas antigua
                    string queryNroPacientes = "SELECT TOP 1  fecha_registro FROM Registro " +
                        "ORDER BY fecha_registro ASC";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        // Si hay una fecha, es pq hay registros, y si los hay lo guardamos
                        if (reader.Read())
                        {
                            fechaAntigua = Convert.ToDateTime(reader["fecha_registro"]);
                        }
                        else
                        {
                            //Si no, usamos la fecha placeholder
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

        // Funcion para obtener el promedio de registros de un periodo en particular
        private double ObtenerPromedioRegistros(DateTime inicio, DateTime fin)
        {
            double promedio = 0;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    /* Se crea la query para obtener el promedio basicamente haciendo una division
                     donde el dividendo es el total de registros hechos, y el divisor el numero de fechas 
                    distintas en las cuales se hicieron registros, en un periodo particular de tiempo*/
                    string queryNroPacientes = "SELECT CAST(COUNT(*) AS FLOAT) / COUNT(DISTINCT CAST(fecha_registro AS DATE)) " +
                        "AS PromedioRegistrosPorPaciente FROM Registro WHERE fecha_registro BETWEEN @inicio AND @fin;";

                    using (SqlCommand cmd = new SqlCommand(queryNroPacientes, db))
                    {
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);

                        db.Open();
                        promedio = Convert.ToDouble(cmd.ExecuteScalar());
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Si ocurre este tipo de error, significa que no hay registros, y en ese caso devuelvo 0 como el promedio
                if (ex.Number == 8134)
                {
                    promedio = 0;
                }
                // Si el error no es por eso, devuelvo un msj de error general
                else
                {
                    MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return promedio;
        }

        // Evento que sucede al cambiar el item del combobox de periodo de tiempo
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtengo la opcion elegida
            string opcion = cbDecisionIntervalo.SelectedItem.ToString();
            // Y si es personalizado, hago visible las opciones de seleccionar
            // el intervalo de tiempo y el boton para actualizar el grafico
            panelSeleccionIntervalo.Visible = opcion == "Personalizado";
            bActualizarGrafico.Visible = opcion == "Personalizado";
            // Obtengo la fecha de hoy
            DateTime hoy = DateTime.Now.Date;
            // Veremos que opcion fue elegida, en un string:
            switch (opcion)
            {
                // Si la opcion elegida es la de la ultima semana, entonces:
                case "Ultima semana":
                    // Hago que la fecha fin sea hoy hasta las 23:59:59
                    fecha_fin = hoy.AddDays(1).AddSeconds(-1);
                    // Y que la fecha inicio sea siete dias anterior al de hoy
                    fecha_inicio = fecha_fin.AddDays(-7 + 1).Date;
                    break;
                // Si la opcion elegida es la de hace un mes:
                case "Ultimo mes":       
                    // Hago que la fecha inicio sea exactamente un mes atras al de hoy
                    fecha_inicio = hoy.AddMonths(-1).Date;
                    // Hago que la fecha fin sea hoy hasta las 23:59:59
                    fecha_fin = hoy.AddDays(1).AddSeconds(-1);
                    break;
                // Si la opcion elegida es la de hace un año:
                case "Ultimo año":
                    // Hago que la fecha de inicio sea hace exactamente un año atras
                    fecha_inicio = hoy.AddYears(-1).Date;
                    // Hago que la fecha fin sea hoy hasta las 23:59:59
                    fecha_fin = hoy.AddDays(1).AddSeconds(-1);
                    break;
                // Si la opcion elegida es la de todos los tiempos:
                case "Todos los tiempos":
                    /* Hago que la fecha de inicio sea la mas antigua posible a traves del metodo,
                    y si la fecha devuelta es la de placeholder, pongo una fecha placeholder de hace 2 años atras */
                    fecha_inicio = ObtenerFechaMasAntigua().Date == new DateTime(1900, 01, 01) ? new DateTime(2023, 01, 01) : ObtenerFechaMasAntigua().Date;
                    // Hago que la fecha fin sea hoy hasta las 23:59:59
                    fecha_fin = hoy.AddDays(1).AddSeconds(-1);
                    break;
                // Si la opcion elegida es la de personalizado:
                case "Personalizado":
                    // Obtengo los valores de los dtp
                    fecha_inicio = dtpFechaInicio.Value.Date;
                    fecha_fin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);
                    break;
            }
            // Actualizo el grafico y las estadisticas cada vez q se cambia de periodo, y este no sea "personalizado"
            if (opcion != "Personalizado")
            {
                GraficarSegunRadioButton();
                ActualizarStats();
            }
        }

        /* Funcion para poder determinar la escala de tiempo que se usara para las etiquetas
         * del eje X en la opcion de graficar segun tiempos */
        private string DeterminarEscalaTiempo()
        {
            // Obtengo la diferencia de dias
            double dias = dif_fechas.TotalDays;
            // Si la dif es menor a 0, devuelvo error
            if (dias < 0) return "error";
            /* Si es menor o igual a 7, las etiquetas van a ser con los nombres de los dias.
             * Ej: Lunes, martes, etc. */
            if (dias <= 7) return "nombre_dias";
            /* Si es mayor a 7, pero menor o igual a 14, las etiquetas van a ser con los nombres de los dias y las fechas.
             * Ej: Lunes 27/10, martes 28/10r, etc. */
            if (dias <= 14) return "fechas_nombres_dias";
            /* Si es mayor a 14, pero menor o igual a 31, las etiquetas van a ser con las semanas a partir de este dia.
            * Ej: Semana 1 (27/09 - 04/10), etc. */
            if (dias <= 31) return "semanas";
            /* Si es mayor a 31, pero menor o igual a 90, las etiquetas van a ser con las semanas a partir de este dia
            * y el mes al cual pertenecen. Ej: Semana 1 (27/09 - 04/10), etc. */
            if (dias <= 90) return "semanas_meses";
            /* Si es mayor a 90, pero menor o igual a 365, las etiquetas van a ser con los meses del año.
            * Ej: Octubre, Novimbre, Diciembre, Enero, ..., Octubre */
            if (dias <= 365) return "meses";
            /* Si es mayor a 365, pero menor o igual a 730 (dos años), las etiquetas van a ser con los meses del año y el año.
            * Ej: Octubre 2023, Novimbre 2023, Diciembre 2023, Enero 2024, ..., Octubre 2025 */
            if (dias <= 730) return "meses_años";
            // Si es mayor a 730, las etiquetas van a ser con los años
            return "años";
        }

        // Funcion que devuelve una matriz de etiquetas y el conjunto de periodo a los cuales estas estiquetas hacen referencia
        private (List<string> Etiquetas, List<DateTime> Periodos) GenerarEtiquetasYPeriodos(DateTime inicio, DateTime fin, string escala)
        {
            // Conjunto de etiquetas que se utilizaran en el eje X.
            var etiquetas = new List<string>();
            // Conjunto de datetime que repreentaran a un periodo de la etiqueta
            var periodos = new List<DateTime>();
            // Cultura para obtener el nombre de los dias de la semana, ej: lunes.
            var cultura = new CultureInfo("es-ES");
            // Segun la escala pasada como argumento y obtenida de la funcion DeterminarEscalaTiempo:
            switch (escala)
            {
                // Si la escala devuelta es segun los nombres de los dias, (lunes)
                case "nombre_dias":
                    /* Voy recorriendo todos y cada uno de los dias establecido por el periodo
                     * formado por el intervalo inicio y fin pasados como argumento,
                     * y aumentando uno a uno estos dias */
                    for (var dia = inicio.Date; dia <= fin.Date; dia = dia.AddDays(1))
                    {
                        /* Añado en el conjunto de etiquetas la que representa el dia sobre
                        * la cual me encuentro parado en el for, haciendo uso de la cultura
                        * , ej: lunes */
                        etiquetas.Add(dia.ToString("dddd", cultura));
                        // Añado el dia al conjunto de periodos
                        periodos.Add(dia.Date);
                    }
                    break;
                // Si la escala devuelta es segun los nombres de los dias y sus fechas, (Lun 01/10)
                case "fechas_nombres_dias":
                    // Recorro el periodo.
                    for (var dia = inicio.Date; dia <= fin.Date; dia = dia.AddDays(1))
                    {
                        /* Añado el dia actual al vector con el formato achicado del 
                         * nombre del dia, y la fecha a la cual esta representa */
                        etiquetas.Add(dia.ToString("ddd dd/MM", cultura));
                        // Añado el dia al periodo
                        periodos.Add(dia.Date);
                    }
                    break;
                // Si la escala devuelta es segun las semanas.
                case "semanas":
                case "semanas_meses":
                    /* Calculo donde se obtiene cuantos son la cantidad de dias que hay restarle
                     a la semana que abarca la fecha de inicio pasada como argumento.
                    Explicacion detallada: DayOfWeek devuelve un int que representa el dia de la semana
                    en la cual esta el dia de inicio pasado como argumento.
                    El -1 es para poder ajustar a que sucederia con el dia lunes, pq por la funcion DayOfWeek
                    devuelve 1 para los dias lunes. El +7 es para cuando el resultado sea domingo, por ejemplo.
                    Y el %7 es para obtener el resto de la division de ese numero obtenido por 7.*/
                    int daysToSubtract = ((int)inicio.DayOfWeek - 1 + 7) % 7;
                    /* Ahora ajustaremos la fecha de inicio restandole la cantidad de dias que fueron obtenidos
                     * arriba, y asi ahora la fecha de inicio sera igual al lunes de esa semana */
                    var currentSemana = inicio.Date.AddDays(-daysToSubtract);
                    // Contador de semanas
                    int numSemana = 1;
                    /* Mientras que la fecha, la cual arranca por el lunes de la semana en la cual se encuentra
                     * fecha inicio sea menor que la fecha de fin */
                    while (currentSemana <= fin.Date)
                    {
                        // Calcularemos el domingo de la seaman en la cual me encuentro, sumandole 6 dias a la semana actual.
                        var finSemana = currentSemana.AddDays(6);  // Domingo de fin
                        /* Si el domingo de la semana es mayor (en fecha) que la fecha de fin,
                         * hago que la fecha del domingo coincida con la fecha de fin */
                        if (finSemana > fin.Date) finSemana = fin.Date;
                        // Si la escala es "semanas"
                        if (escala == "semanas")
                        {
                            /* Añado como etiqueta a "Semana" mas el numero que representa la semaan 
                             * en la cual me encuentro, y el rango de fechas que cubre esa semana */
                            etiquetas.Add($"Semana {numSemana} ({currentSemana:dd/MM} - {finSemana:dd/MM})");
                        }
                        // Si la escala es "semanas_meses"
                        else
                        {
                            // Consigo el mes del periodo de tiempo, de forma abreviada y segun la cultura
                            var mesInicio = currentSemana.ToString("MMM", cultura);
                            /* Añado como etiqueta a "Semana" mas el numero que representa la semana, el mes  
                            * en la cual me encuentro, y el rango de fechas que cubre esa semana */
                            etiquetas.Add($"Semana {numSemana}/{mesInicio} ({currentSemana:dd/MM} - {finSemana:dd/MM})");
                        }
                        // Añado como representante a los lunes de inicio al periodo
                        periodos.Add(currentSemana.Date);
                        // Y ahora hago que la semana sea el lunes siguiente a la semana anterior
                        currentSemana = currentSemana.AddDays(7);
                        // Añado uno al num de semana 
                        numSemana++;
                    }
                    break;
                // Si la escala es de meses:
                case "meses":
                    // Creo una variable de datetime que tenga el mes de inicio, 
                    // el año tmb de inicio, y el primer dia del mes
                    var mes = new DateTime(inicio.Year, inicio.Month, 1);
                    while (mes <= fin)
                    {
                        // Creo una variable de datime que representa el ultimo dia del mes,
                        // al añadirle un mes a la variable creada, y restandole un dia.
                        var finMes = mes.AddMonths(1).AddDays(-1);
                        /* Si el ultimo dia del mes es mayor que la fecha de fin,
                         * hago que la fecha de fin de mes coincida con la fecha de fin */
                        if (finMes > fin) finMes = fin.Date;
                        // Añado el nombre del mes en el cual me encuenmtro
                        etiquetas.Add(mes.ToString("MMM", cultura));
                        // Añado el primer dia del mes como representante, al periodo
                        periodos.Add(mes.Date);
                        // Y voy al siguiente mes
                        mes = mes.AddMonths(1);
                    }
                    break;
                // Si la escala es de meses:
                case "meses_años":
                    // Esto hace lo mismo que la escala de meses, salvo que
                    var mesAnio = new DateTime(inicio.Year, inicio.Month, 1);
                    while (mesAnio <= fin)
                    {
                        var finMes = mesAnio.AddMonths(1).AddDays(-1);
                        if (finMes > fin) finMes = fin.Date;
                        // Añado el nombre del mes en el cual me encuentro, y su año
                        etiquetas.Add(mesAnio.ToString("MMM yyyy", cultura));
                        periodos.Add(mesAnio.Date);
                        mesAnio = mesAnio.AddMonths(1);
                    }
                    break;
                // Si la escala es de años
                case "años":
                    // Recorro todos y cada uno de los años desde la fecha de inicio a la final
                    for (int año = inicio.Year; año <= fin.Year; año++)
                    {
                        // Creando una variable para el inicio y el fin del año en el cual me encuentro
                        var inicioAnio = new DateTime(año, 1, 1);
                        var finAnio = new DateTime(año, 12, 31);
                        /* Si el primer dia del año es menor que la fecha de inicio,
                        * hago que la fecha de inicio de año coincida con la fecha de inicio */
                        if (inicioAnio < inicio) inicioAnio = inicio.Date;
                        /* Si el ultimo dia del año es mayor que la fecha de fin,
                        * hago que la fecha de fin de año coincida con la fecha de fin */
                        if (finAnio > fin) finAnio = fin.Date;
                        // Añado el año al conjunto de etiquetas
                        etiquetas.Add(año.ToString());
                        // Y añado el primer dia del año como representante
                        periodos.Add(inicioAnio.Date);
                    }
                    break;
            }
            // Devuelvo todo esto q hice
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

        // Funcion que grafica segun la opcion de tipo de grafico elegida.
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

        // Evento que al salir de la fecha de inicio, actualizamos el atributo
        // del user control y colocamos la fecha minimo del dtp fecha fin a esta fecha.
        private void dtpFechaInicio_Leave(object sender, EventArgs e)
        {
            dtpFechaFin.MinDate = dtpFechaInicio.Value;
            fecha_inicio = dtpFechaInicio.Value;
        }

        // Evento que al salir del dtp de fecha de fin, actualizamos el atributo del usercontrol.
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

