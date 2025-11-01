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
                                            ORDER BY fecha_registro DESC;";

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

                                panel.AbrirOtroControl += this.AbrirOtroControl;
                                panelContenedorRegistros.Controls.Add(panel);
                                panelContenedorRegistros.Controls.SetChildIndex(panel, 0);

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
                                            ORDER BY fecha_registro DESC;";

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

                                    PanelRegistro panel = new PanelRegistro(idHistorial, idRegistro);
                                    panel.Dock = DockStyle.None;
                                    panel.Width = panelContenedorRegistros.ClientSize.Width - 25;
                                    panel.AutoSize = true;
                                    panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                                    panel.Margin = new Padding(6);
                                    panel.Location = new Point(10, posY);

                                    panel.AbrirOtroControl += this.AbrirOtroControl;
                                    panelContenedorRegistros.Controls.Add(panel);

                                    panelContenedorRegistros.Controls.Add(panel);
                                    panelContenedorRegistros.Controls.SetChildIndex(panel, 0);

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
                        ORDER BY fecha_registro DESC;";

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
                                panelContenedorRegistros.Controls.SetChildIndex(panel, 0);

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


        /*private void bPdfRegistros_Click(object sender, EventArgs e)//Funcion que descarga los registros del paciente en formato PDF
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

            // Elegir ubicación del archivo
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
            sfd.FileName = $"Historial_{dniBusqueda}.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                GenerarPDFPaciente(dniBusqueda, registros, sfd.FileName);
                MessageBox.Show("El PDF se generó correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GenerarPDFPaciente(int dni, List<Registro> registros, string rutaArchivo)//Funcion que genera un PDF con los registros del paciente
        {
            Document doc = new Document(PageSize.A4, 40, 40, 50, 40);

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Encabezado
                Paragraph titulo = new Paragraph($"Historial clínico del paciente (DNI: {dni})",
                    new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(new Paragraph("\n"));

                // Iterar registros
                foreach (var reg in registros)
                {
                    doc.Add(new Paragraph($"🩺 Tipo de registro: {reg.TipoRegistro}",
                        new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));

                    doc.Add(new Paragraph($"👨‍⚕️ Profesional: {reg.Profesional}"));
                    doc.Add(new Paragraph($"📅 Fecha: {reg.Fecha.ToShortDateString()}"));
                    doc.Add(new Paragraph($"💊 Medicación: {reg.Medicacion}"));
                    doc.Add(new Paragraph($"📝 Observaciones: {reg.Observaciones}"));
                    doc.Add(new Paragraph("--------------------------------------------------"));
                }

                doc.Close();
            }
        }

        public class Registro
        {
            public string TipoRegistro { get; set; }
            public DateTime Fecha { get; set; }
            public string Observaciones { get; set; }
            public string Medicacion { get; set; }
            public string Profesional { get; set; }
        }*/

    }
}
