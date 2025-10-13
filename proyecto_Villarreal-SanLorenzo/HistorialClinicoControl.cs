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
            dgvRegistrosPacientes.Visible = false; //No visible cuando se carga la vista.

            //Se muestra el mensaje inicial
            panelRegistrosPacientes.Controls.Clear();
            panelRegistrosPacientes.Controls.Add(CrearPanelMensaje("Ingrese un DNI"));

            //Se inicializa el DGV vacio
            dgvRegistrosPacientes.DataSource = new DataTable();
        }

        private void tBusquedaDNI_KeyDown(object sender, KeyEventArgs e)//Funcion que busca al paciente por su DNI.
        {
            if (e.KeyCode != Keys.Enter) return;

            // se valdia el dni
            string txt = tBusquedaDNI.Text.Trim();
            if (!int.TryParse(txt, out int dniBusqueda))
            {
                MessageBox.Show("El DNI ingresado es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CargarHistorial(dniBusqueda);

        }

        //Funcion que carga los registros del historial medico del paciente en caso de que tenga
        // y siempre y cuando se busque al mismo por su DNI previamente
        private void CargarHistorial(int dni_buscado)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection db = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(@"
                SELECT 
                    r.id_registro,
                    r.id_historial,
                    r.dni_paciente,
                    r.fecha_registro,
                    r.observaciones,
                    u.nombre_usuario AS profesional
                FROM Registro r
                INNER JOIN Usuarios u ON r.id_usuario = u.id_usuario
                WHERE r.dni_paciente = @dni_paciente
                ORDER BY r.fecha_registro DESC;", db))
                {
                    cmd.Parameters.Add("@dni_paciente", SqlDbType.Int).Value = dni_buscado;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                // Se limpia el mensaje predeterminado
                panelRegistrosPacientes.Controls.Clear();

                if (dt.Rows.Count > 0)
                {
                    // Si hay registros: mostramos el dgv y lo llenamos
                    dgvRegistrosPacientes.AutoGenerateColumns = true;
                    dgvRegistrosPacientes.DataSource = dt;
                    dgvRegistrosPacientes.Visible = true;

                    // Se renombran los headers (solo si hay columnas)
                    RenombrarHeaders(dgvRegistrosPacientes);

                    //se ocultan las columnas con IDs
                    if (dgvRegistrosPacientes.Columns.Contains("id_registro"))
                        dgvRegistrosPacientes.Columns["id_registro"].Visible = false;
                    if (dgvRegistrosPacientes.Columns.Contains("id_historial"))
                        dgvRegistrosPacientes.Columns["id_historial"].Visible = false;

                    panelRegistrosPacientes.Visible = false;
                }
                else
                {
                    // Si no hay registros: se oculta el dgv y se muestra un mensaje
                    dgvRegistrosPacientes.DataSource = null;
                    dgvRegistrosPacientes.Visible = false;

                    var panel = CrearPanelMensaje("intente nuevamente");
                    panel.Location = new Point(10, 10);
                    panelRegistrosPacientes.Controls.Add(panel);
                }

                RenombrarHeaders(dgvRegistrosPacientes);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar los historiales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // para una interfaz consistente
                dgvRegistrosPacientes.DataSource = null;
                dgvRegistrosPacientes.Visible = false;
                panelRegistrosPacientes.Controls.Clear();
                panelRegistrosPacientes.Controls.Add(CrearPanelMensaje("Error de conexión"));
            }
        }


        private void tBusquedaDNI_KeyPress(object sender, KeyPressEventArgs e)//Funcion que no permite el ingreso de caracteres no numéricos
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^\d$") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void comboBoxCategoria_KeyDown(object sender, KeyEventArgs e) //Agregar funcionalidad para buscar por tipo de intervencion
        {

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

        //Funcion que renombra los headers del datatable
        public void RenombrarHeaders(DataGridView grid)//Funcion que renombra el nombre de los headers del datagridview
        {
            foreach (DataGridViewColumn col in grid.Columns)
            {
                //Reemplaza los guiones bajos por espacios
                string header = col.HeaderText.Replace("_", " ");

                //Convierte la primera letra a mayúscula y el resto a minúscula
                if (header.Length > 0)
                    header = char.ToUpper(header[0]) + header.Substring(1).ToLower();

                col.HeaderText = header;
            }

        }

        private void bRegistrarPaciente_Click(object sender, EventArgs e) //Aregar Funcionalidad
        {

        }
    }
}
