using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class HistorialClinicoControl : UserControlProyecto
    {
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";

        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;

        public HistorialClinicoControl()
        {
            InitializeComponent();
        }

        private void HistorialClinicoControl_Load(object sender, EventArgs e)
        {
            PlaceholderBusqueda(tBusquedaDNI, "Buscar por DNI...");

            //Se muestra el mensaje inicial
            panelContenedorRegistros.Controls.Clear();
            panelContenedorRegistros.Controls.Add(CrearPanelMensaje("Ingrese un DNI"));

        }

        private void tBusquedaDNI_KeyDown(object sender, KeyEventArgs e)//Funcion que permite la busqueda de los registros de un paciente por su DNI
        {
            if (e.KeyCode != Keys.Enter) return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            string textoDNI = tBusquedaDNI.Text.Trim();

            if (string.IsNullOrEmpty(textoDNI))
            {
                MostrarMensaje("debe ingresar el DNI del paciente");
                return;
            }

            if (!int.TryParse(textoDNI, out int dniBusqueda))
            {
                MostrarMensaje("el DNI ingresado no es válido");
                return;
            }

            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    string query = @"
                                    SELECT dni_paciente, nombre_paciente, apellido_paciente
                                    FROM Paciente
                                    WHERE dni_paciente = @dni;";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@dni", dniBusqueda);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MostrarMensaje(". No se encontró ningún paciente con el DNI ingresado");
                                return;
                            }

                            panelContenedorRegistros.Controls.Clear();

                            while (reader.Read())
                            {
                                int dniPaciente = Convert.ToInt32(reader["dni_paciente"]);
                                string nombre = reader["nombre_paciente"].ToString();
                                string apellido = reader["apellido_paciente"].ToString();

                                // encabezado
                                Label lblPaciente = new Label();
                                lblPaciente.Text = $"{apellido}, {nombre} (DNI: {dniPaciente})";
                                lblPaciente.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                                lblPaciente.AutoSize = true;
                                lblPaciente.Margin = new Padding(6, 12, 6, 4);
                                panelContenedorRegistros.Controls.Add(lblPaciente);

                                // cargar historiales
                                CargarHistoriales(dniPaciente);
                            }

                            panelContenedorRegistros.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("ocurrió un error al buscar el paciente: " + ex.Message);
            }
        }

        public void CargarHistoriales(int p_dniPaciente)//Método que carga los registros del paciente
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    // buscar id_historial del paciente
                    string queryHistorial = "SELECT id_historial FROM Historial WHERE dni_paciente = @dni";
                    int idHistorial = 0;

                    using (SqlCommand cmdHistorial = new SqlCommand(queryHistorial, db))
                    {
                        cmdHistorial.Parameters.AddWithValue("@dni", p_dniPaciente);
                        object result = cmdHistorial.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                            idHistorial = Convert.ToInt32(result);
                    }

                    if (idHistorial == 0)
                    {
                        MostrarMensaje("no se encontró historial para este paciente");
                        return;
                    }

                    string queryRegistros = @"
                                            SELECT id_registro
                                            FROM Registro
                                            WHERE id_historial = @id_historial
                                            ORDER BY fecha_registro DESC, id_registro DESC";

                    using (SqlCommand cmdRegistros = new SqlCommand(queryRegistros, db))
                    {
                        cmdRegistros.Parameters.AddWithValue("@id_historial", idHistorial);

                        using (SqlDataReader reader = cmdRegistros.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MostrarMensaje("no hay registros cargados para este paciente");
                                return;
                            }

                            panelContenedorRegistros.Controls.Clear();
                            int posY = 10;

                            while (reader.Read())
                            {
                                int idRegistro = Convert.ToInt32(reader["id_registro"]);

                                PanelRegistro panel = new PanelRegistro(idHistorial, idRegistro, this);
                                panel.Dock = DockStyle.None;
                                panel.Width = panelContenedorRegistros.ClientSize.Width - 25;
                                panel.AutoSize = true;
                                panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                                panel.Margin = new Padding(6);
                                panel.Location = new Point(10, posY);

                                panel.AbrirOtroControl += this.AbrirOtroControl;
                                panelContenedorRegistros.Controls.Add(panel);
                                posY += panel.Height + 10;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("error al cargar historiales: " + ex.Message);
            }
        } //Funcion que carga los registros del historial medico del paciente en caso de que tenga y siempre y cuando se busque al mismo por su DNI/NYA previamente

        private void tBusquedaDNI_KeyPress(object sender, KeyPressEventArgs e)//Funcion que no permite el ingreso de caracteres no numéricos
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^\d$") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void PlaceholderBusqueda(TextBox txt, string placeholder)//Funcion que coloca un texto fantasma en caso de estar vacio
        {
            // Se coloca el texto en el/los textbox
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            // Funcion lambda que se activa cuando el usuario hace click en el textbox
            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    // Basicamente borra el texto y le cambia el color
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            // Funcion lambda que se activa siempre y cuando el usuario no haga click en el textbox
            txt.LostFocus += (s, e) =>
            {
                // Verifica si este esta vacio, y si es asi, le coloca el placeholder.
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void bAgregarRegistroPaciente_Click(object sender, EventArgs e)//Boton que abre la vista para agregar registros al paciente seleccionado
        {
            string txt = tBusquedaDNI.Text.Trim();

            if (string.IsNullOrEmpty(txt))
            {
                MessageBox.Show("Debe ingresar el DNI del paciente antes de agregar un registro.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt, out int dniBusqueda))
            {
                MessageBox.Show("El DNI ingresado no es válido.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AgregarRegistroControl agregarRegistro = new AgregarRegistroControl(dniBusqueda);
            agregarRegistro.controlPadreRegistro = this;
            agregarRegistro.AbrirOtroControl += this.AbrirOtroControl;

            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, agregarRegistro, false));
        }

        private void MostrarMensaje(string texto)//Funcion que crea un panel donde se muesstran los mensajes
        {
            panelContenedorRegistros.Controls.Clear();
            panelContenedorRegistros.Controls.Add(CrearPanelMensaje(texto));
            panelContenedorRegistros.Refresh();
        }

        private Panel CrearPanelMensaje(string texto) //Metodo que crea un mensaje que se muestra en el panel del registro de los pacientes
        {
            Panel panelMensaje = new Panel();
            panelMensaje.AutoSize = true;
            panelMensaje.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelMensaje.Padding = new Padding(10);
            panelMensaje.MaximumSize = new Size(panelContenedorRegistros.Width - 20, 0);

            PictureBox pb = new PictureBox();
            pb.Location = new Point(15, 20);
            pb.Size = new Size(32, 32);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = Resource1.question;

            Label lbl = new Label();
            lbl.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(panelContenedorRegistros.Width - 100, 0);
            lbl.Location = new Point(pb.Right + 15, 20);
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Text = "No se han encontrado registros " + texto + ".";

            panelMensaje.Controls.Add(pb);
            panelMensaje.Controls.Add(lbl);

            return panelMensaje;

        }

        private void CargarHistorialesSinLimpiar(int p_dniPaciente)//Funcion utilizada para no interferir con la búsqueda por DNI, que sí necesita limpiar antes de mostrar.
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string queryHistorial = "SELECT id_historial FROM Historial WHERE dni_paciente = @dni";
                    int idHistorial = 0;

                    using (SqlCommand cmdHistorial = new SqlCommand(queryHistorial, db))
                    {
                        cmdHistorial.Parameters.AddWithValue("@dni", p_dniPaciente);
                        db.Open();
                        object result = cmdHistorial.ExecuteScalar();
                        db.Close();

                        if (result != null && result != DBNull.Value)
                            idHistorial = Convert.ToInt32(result);
                    }

                    if (idHistorial == 0)
                    {
                        panelContenedorRegistros.Controls.Add(CrearPanelMensaje("sin historial registrado."));
                        return;
                    }

                    string queryRegistros = @"
                                            SELECT id_registro
                                            FROM Registro
                                            WHERE id_historial = @id_historial
                                            ORDER BY  fecha_registro DESC, id_registro DESC";

                    using (SqlCommand cmdRegistros = new SqlCommand(queryRegistros, db))
                    {
                        cmdRegistros.Parameters.AddWithValue("@id_historial", idHistorial);
                        db.Open();

                        using (SqlDataReader reader = cmdRegistros.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                panelContenedorRegistros.Controls.Add(CrearPanelMensaje("sin registros asociados."));
                            }
                            else
                            {
                                int posY = panelContenedorRegistros.Controls.Count * 60;

                                while (reader.Read())
                                {
                                    int idRegistro = Convert.ToInt32(reader["id_registro"]);

                                    PanelRegistro panel = new PanelRegistro(idHistorial, idRegistro, this);
                                    panel.Dock = DockStyle.None;
                                    panel.Width = panelContenedorRegistros.ClientSize.Width - 25;
                                    panel.AutoSize = true;
                                    panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                                    panel.Margin = new Padding(6);
                                    panel.Location = new Point(10, posY);

                                    panel.AbrirOtroControl += this.AbrirOtroControl;
                                    panelContenedorRegistros.Controls.Add(panel);

                                    panelContenedorRegistros.Controls.Add(panel);
                                    posY += panel.Height + 10;
                                }
                            }
                        }

                        db.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historiales: " + ex.Message);
            }
        }

        //Funcion Tomi
        /*public HistorialClinicoControl(int p_dni)
        {
            InitializeComponent();

            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    // buscar id_historial del paciente
                    string queryHistorial = "SELECT id_historial FROM Historial WHERE dni_paciente = @dni";
                    int idHistorial = 0;

                    using (SqlCommand cmdHistorial = new SqlCommand(queryHistorial, db))
                    {
                        cmdHistorial.Parameters.AddWithValue("@dni", p_dni);
                        object result = cmdHistorial.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                            idHistorial = Convert.ToInt32(result);
                    }

                    if (idHistorial == 0)
                    {
                        MostrarMensaje("no se encontró historial para este paciente");
                        return;
                    }

                    // obtener todos los registros del historial
                    string queryRegistros = @"
                        SELECT id_registro
                        FROM Registro
                        WHERE id_historial = @id_historial
                        ORDER BY fecha_registro DESC, id_registro DESC"

                    using (SqlCommand cmdRegistros = new SqlCommand(queryRegistros, db))
                    {
                        cmdRegistros.Parameters.AddWithValue("@id_historial", idHistorial);

                        using (SqlDataReader reader = cmdRegistros.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MostrarMensaje("no hay registros cargados para este paciente");
                                return;
                            }

                            panelContenedorRegistros.Controls.Clear();
                            int posY = 10;

                            while (reader.Read())
                            {
                                int idRegistro = Convert.ToInt32(reader["id_registro"]);

                                PanelRegistro panel = new PanelRegistro(idHistorial, idRegistro);
                                panel.Dock = DockStyle.None;
                                panel.Width = panelContenedorRegistros.ClientSize.Width - 25;
                                panel.AutoSize = true;
                                panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                                panel.Margin = new Padding(6);
                                panel.Location = new Point(10, posY);

                                panelContenedorRegistros.Controls.Add(panel);
                                posY += panel.Height + 10;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("error al cargar el historial clínico: " + ex.Message);
            }
        }*/


        private void bPdfRegistros_Click(object sender, EventArgs e)
        {
            string textoDNI = tBusquedaDNI.Text.Trim();

            if (string.IsNullOrEmpty(textoDNI))
            {
                MessageBox.Show("Debe ingresar el DNI del paciente antes de descargar el PDF.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textoDNI, out int dniBusqueda))
            {
                MessageBox.Show("El DNI ingresado no es válido.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener los registros del paciente
            List<Registro> registros = ObtenerRegistrosPaciente(dniBusqueda);

            if (registros == null || registros.Count == 0)
            {
                MessageBox.Show("No hay registros para este paciente.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Historial_{dniBusqueda}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GenerarPDFPaciente(dniBusqueda, registros, sfd.FileName);
                        MessageBox.Show("El PDF se generó correctamente.",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar el PDF: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GenerarPDFPaciente(int dni, List<Registro> registros, string rutaArchivo)
        {
            if (registros == null || registros.Count == 0)
                return;

            iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 50, 50, 50, 50);
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                PdfWriter.GetInstance(document, fs);
                document.Open();

                // Fuentes
                var tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var seccionFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var textoFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);

                // --- ENCABEZADO DEL PACIENTE ---
                Registro primerRegistro = registros[0];
                document.Add(new Paragraph("Historial Clínico del Paciente", tituloFont));
                document.Add(new Paragraph("\n"));
                document.Add(new Paragraph($"Nombre: {primerRegistro.NombrePaciente}", textoFont));
                document.Add(new Paragraph($"DNI: {primerRegistro.DniPaciente}", textoFont));
                document.Add(new Paragraph($"Fecha de generación: {DateTime.Now.ToShortDateString()}", textoFont));
                document.Add(new Paragraph("\n--------------------------------------------------\n"));

                // --- REGISTROS MÉDICOS ---
                foreach (var reg in registros)
                {
                    document.Add(new Paragraph($"Tipo de registro: {reg.TipoRegistro}", seccionFont));
                    document.Add(new Paragraph($"Fecha: {reg.Fecha.ToShortDateString()}", textoFont));
                    document.Add(new Paragraph($"Profesional: {reg.Profesional}", textoFont));
                    document.Add(new Paragraph($"Medicación: {reg.Medicacion}", textoFont));
                    document.Add(new Paragraph($"Observaciones: {reg.Observaciones}", textoFont));
                    document.Add(new Paragraph("--------------------------------------------------\n"));
                }

                document.Close();
            }
        }

        // Clase auxiliar
        public class Registro
        {
            public string TipoRegistro { get; set; }
            public DateTime Fecha { get; set; }
            public string Observaciones { get; set; }
            public string Medicacion { get; set; }
            public string Profesional { get; set; }
            public string NombrePaciente { get; set; }
            public string DniPaciente { get; set; }
        }

        // Obtiene toda la información del paciente y sus registros
        private List<Registro> ObtenerRegistrosPaciente(int dniPaciente)
        {
            List<Registro> registros = new List<Registro>();

            string query = @"
                            SELECT 
                                p.nombre_paciente AS NombrePaciente,
                                p.dni_paciente AS DniPaciente,
                                tr.nombre_registro AS TipoRegistro,
                                r.fecha_registro AS Fecha,
                                r.observaciones AS Observaciones,
                                ISNULL(m.nombre_medicacion, 'Ninguna') AS Medicacion,
                                u.nombre_usuario AS Profesional
                            FROM Registro r
                            INNER JOIN Paciente p ON r.dni_paciente = p.dni_paciente
                            INNER JOIN Tipo_registro tr ON r.id_tipo_registro = tr.id_tipo_registro
                            LEFT JOIN Registro_medicacion rm ON r.id_registro = rm.id_registro
                            LEFT JOIN Medicacion m ON rm.id_medicacion = m.id_medicacion
                            INNER JOIN Usuarios u ON r.id_usuario = u.id_usuario
                            WHERE p.dni_paciente = @dni
                            ORDER BY r.fecha_registro DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@dni", dniPaciente);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Registro registro = new Registro
                    {
                        NombrePaciente = reader["NombrePaciente"].ToString(),
                        DniPaciente = reader["DniPaciente"].ToString(),
                        TipoRegistro = reader["TipoRegistro"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        Observaciones = reader["Observaciones"].ToString(),
                        Medicacion = reader["Medicacion"].ToString(),
                        Profesional = reader["Profesional"].ToString()
                    };

                    registros.Add(registro);
                }

                reader.Close();
            }

            return registros;
        }

    }
}
