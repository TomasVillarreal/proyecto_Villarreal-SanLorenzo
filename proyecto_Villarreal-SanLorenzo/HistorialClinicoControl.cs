using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            PlaceholderBusqueda(tBusquedaNyA, "Buscar por nombre y apellido...");

            //Se muestra el mensaje inicial
            panelContenedorRegistros.Controls.Clear();
            panelContenedorRegistros.Controls.Add(CrearPanelMensaje("Ingrese un DNI"));

        }

        private void tBusquedaDNI_KeyDown(object sender, KeyEventArgs e)//Funcion que busca al paciente por su DNI.
        {
            if (e.KeyCode != Keys.Enter) return;

            string txt = tBusquedaDNI.Text.Trim();
            if (!int.TryParse(txt, out int dniBusqueda))
            {
                MessageBox.Show("El DNI ingresado es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // evita que Enter "salte" y dispare otros comportamientos
            e.Handled = true;
            e.SuppressKeyPress = true;

            CargarHistoriales(dniBusqueda);

        }

        private void tBusquedaNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string textoBusqueda = tBusquedaNyA.Text.Trim();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                MessageBox.Show("Ingrese un nombre o apellido para realizar la búsqueda.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Evita que Enter genere sonido o cambie el foco
            e.Handled = true;
            e.SuppressKeyPress = true;

            panelContenedorRegistros.Controls.Clear();

            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    string query = @"
                                    SELECT dni_paciente, nombre_paciente, apellido_paciente
                                    FROM Paciente
                                    WHERE nombre_paciente LIKE @nombre OR apellido_paciente LIKE @apellido
                                    ORDER BY apellido_paciente, nombre_paciente;";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@nombre", "%" + textoBusqueda + "%");
                        cmd.Parameters.AddWithValue("@apellido", "%" + textoBusqueda + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                panelContenedorRegistros.Controls.Add(CrearPanelMensaje("no se encontraron pacientes con ese nombre."));
                                return;
                            }

                            while (reader.Read())
                            {
                                int dniPaciente = Convert.ToInt32(reader["dni_paciente"]);
                                string nombre = reader["nombre_paciente"].ToString();
                                string apellido = reader["apellido_paciente"].ToString();

                                Label lblPaciente = new Label();
                                lblPaciente.Text = $"{apellido}, {nombre} (DNI: {dniPaciente})";
                                lblPaciente.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                lblPaciente.AutoSize = true;
                                lblPaciente.Margin = new Padding(6, 12, 6, 4);

                                panelContenedorRegistros.Controls.Add(lblPaciente);

                                // Cargar los historiales de este paciente debajo
                                CargarHistoriales(dniPaciente);
                            }
                        }
                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar pacientes: " + ex.Message);
            }
        }

        private void CargarHistoriales(int p_dniPaciente)
        {
            panelContenedorRegistros.Controls.Clear();

            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // buscar id_historial del paciente
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
                        panelContenedorRegistros.Controls.Add(CrearPanelMensaje("para este paciente"));
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
                                panelContenedorRegistros.Controls.Add(CrearPanelMensaje("para este paciente"));
                            }
                            else
                            {
                                int posY = 10; // para espaciar visualmente los paneles

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

                        db.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historiales: " + ex.Message);
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
            AgregarRegistroControl agregarRegistro = new AgregarRegistroControl(Convert.ToInt32(tBusquedaDNI.Text));

            agregarRegistro.controlPadreRegistro = this;
            agregarRegistro.AbrirOtroControl += this.AbrirOtroControl;

            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, agregarRegistro, false));
        }

        //Metodo que crea un mensaje que se muestra en el panel del registro de los pacientes
        // y se utiliza para que el usuario deba buscar un paciente por su dni para ver el historial
        private Panel CrearPanelMensaje(string texto)
        {
            Panel panelMensaje = new Panel();
            panelMensaje.Size = new Size(500, 80);

            PictureBox pb = new PictureBox();
            pb.Location = new Point(15, 20);
            pb.Size = new Size(32, 32);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = Resource1.question;

            Label lbl = new Label();
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbl.AutoSize = false;
            lbl.Size = new Size(430, 40);
            lbl.Location = new Point(pb.Right + 15, 20);
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Text = "No se han encontrado registros " + texto + ".";

            panelMensaje.Controls.Add(pb);
            panelMensaje.Controls.Add(lbl);

            return panelMensaje;

        }//CORREGIR
    }
}
