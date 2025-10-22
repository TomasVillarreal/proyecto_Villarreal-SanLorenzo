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
            CargarTiposIntervencion();

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

        //Funcion que carga los registros del historial medico del paciente en caso de que tenga
        // y siempre y cuando se busque al mismo por su DNI previamente
        private void CargarHistoriales(int p_dniPaciente)
        {
            // Limpiamos siempre antes de agregar
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

                    // si no hay historial asociado
                    if (idHistorial == 0)
                    {
                        panelContenedorRegistros.Controls.Clear();
                        panelContenedorRegistros.Controls.Add(CrearPanelMensaje("para este paciente"));
                        return;
                    }

                    // obtener registros del historial
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
                                panelContenedorRegistros.Controls.Clear();
                                panelContenedorRegistros.Controls.Add(CrearPanelMensaje("para este paciente"));
                            }
                            else
                            {
                                while (reader.Read())
                                {
                                    int idRegistro = Convert.ToInt32(reader["id_registro"]);

                                    PanelRegistro panel = new PanelRegistro(idHistorial, idRegistro);
                                    panel.Dock = DockStyle.None;
                                    panel.Width = panelContenedorRegistros.ClientSize.Width - 20;
                                    panel.AutoSize = false;
                                    panel.Height = 80;
                                    panel.Margin = new Padding(4);


                                    panelContenedorRegistros.Controls.Add(panel);
                                    panelContenedorRegistros.Controls.SetChildIndex(panel, 0);
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


        private void tBusquedaDNI_KeyPress(object sender, KeyPressEventArgs e)//Funcion que no permite el ingreso de caracteres no numéricos
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^\d$") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void MostrarRegistrosPorTipo(string tipoSeleccionado)
        {
            panelContenedorRegistros.Controls.Clear();

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT r.id_historial, r.id_registro
            FROM Registro r
            INNER JOIN Tipo_registro tr ON r.id_tipo_registro = tr.id_tipo_registro
            WHERE tr.nombre_registro = @tipo";

                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipoSeleccionado);
                    db.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            panelContenedorRegistros.Controls.Add(CrearPanelMensaje("No se encontraron registros para este tipo de intervención."));
                            return;
                        }

                        while (reader.Read())
                        {
                            int idHistorial = Convert.ToInt32(reader["id_historial"]);
                            int idRegistro = Convert.ToInt32(reader["id_registro"]);

                            // Crear el panel para ese registro
                            PanelRegistro panel = new PanelRegistro(idHistorial, idRegistro);
                            panel.Dock = DockStyle.Top;
                            panel.Margin = new Padding(4);

                            // Agregar al contenedor
                            panelContenedorRegistros.Controls.Add(panel);
                            panelContenedorRegistros.Controls.SetChildIndex(panel, 0);
                        }
                    }
                }
            }
        }



        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e) //Funcion que permite buscar por tipo de intervencion
        {
            if (comboBoxCategoria.SelectedIndex <= 0) // Placeholder o nada seleccionado
                return;

            string tipoSeleccionado = comboBoxCategoria.Text; // o SelectedValue si preferís
            MostrarRegistrosPorTipo(tipoSeleccionado);
        }

        //Funcion que carga al comboBox los tipos de intervencion realizadas en la clinica
        private void CargarTiposIntervencion()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT nombre_registro, id_tipo_registro FROM Tipo_registro WHERE nombre_registro IS NOT NULL AND LTRIM(RTRIM(nombre_registro)) <> ''",
                    connection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    //Se crea una fila "placeholder" manual antes de asignar el DataSource
                    DataRow row = dataTable.NewRow();
                    row["nombre_registro"] = "Buscar por tipo de intervención...";
                    row["id_tipo_registro"] = 0; //Valor por defecto
                    dataTable.Rows.InsertAt(row, 0);

                    comboBoxCategoria.DataSource = dataTable;
                    comboBoxCategoria.DisplayMember = "nombre_registro";
                    comboBoxCategoria.ValueMember = "id_tipo_registro";

                    // Seleccionamos el placeholder por defecto
                    comboBoxCategoria.SelectedIndex = 0;

                    // Aplicamos estilo visual (gris) para que parezca placeholder
                    comboBoxCategoria.ForeColor = Color.Gray;

                    // Cuando el usuario hace clic, si está en el placeholder, cambia el color
                    comboBoxCategoria.SelectedIndexChanged += (s, e) =>
                    {
                        if (comboBoxCategoria.SelectedIndex == 0)
                        {
                            comboBoxCategoria.ForeColor = Color.Gray;
                            MessageBox.Show("Por favor seleccione un tipo de intervención válido.");
                            return;
                        }
                        else
                        {
                            comboBoxCategoria.ForeColor = Color.Black;
                        }
                    };
                }

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los tipos de intervención.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void bRegistrarPaciente_Click(object sender, EventArgs e)
        {
            AgregarRegistroControl agregarRegistro = new AgregarRegistroControl(Convert.ToInt32(tBusquedaDNI.Text));

            agregarRegistro.controlPadreRegistro = this;
            agregarRegistro.AbrirOtroControl += this.AbrirOtroControl;

            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, agregarRegistro, false));

        }
    }
}
