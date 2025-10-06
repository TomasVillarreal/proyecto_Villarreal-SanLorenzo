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
            PlaceholderBusqueda(comboBoxCategoria, "Buscar por tipo de intervención...");
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
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(tBusquedaDNI.Text.Trim(), out int dniBusqueda))
                {
                    CargarHistorial(dniBusqueda.ToString());
                }
                else
                {
                    MessageBox.Show("El DNI ingresado es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            panelRegistrosPacientes.Visible = false;//Se oculta el panel con el mensaje de ingreso de DNI.
            dgvRegistrosPacientes.Visible = true;//Se muestra el dgv de los registros
        }

        private void tBusquedaDNI_KeyPress(object sender, KeyPressEventArgs e)//Funcion que no permite el ingreso de caracteres no numéricos
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^\d$") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void comboBoxCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            //Agregar funcionalidad para buscar por tipo de intervencion
        }

        //Funcion que carga al comboBox los tipos de intervencion realizadas en la clinica
        private void CargarTiposIntervencion()
        {
            using (SqlConnection connecction = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT nombre_registro, id_tipo_registro FROM Tipo_registro WHERE nombre_registro IS NOT NULL AND LTRIM(RTRIM(nombre_registro)) <> ''", connecction))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    comboBoxCategoria.DataSource = dataTable;
                    comboBoxCategoria.DisplayMember = "nombre_registro";
                    comboBoxCategoria.ValueMember = "id_tipo_registro";

                }
                try
                {
                    connecction.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los roles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Funcion que carga los registros del historial medico del paciente en caso de que tenga
        // y siempre y cuando se busque al mismo por su DNI previamente
        private void CargarHistorial(string dni_buscado)
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    r.id_registro,
                    r.dni_paciente,
                    r.id_historial,
                    r.fecha_registro,
                    r.observaciones,
                    u.nombre_usuario AS profesional
                FROM Registro r
                INNER JOIN Usuarios u ON r.id_usuario = u.id_usuario
                WHERE r.dni_paciente = @dni_paciente;";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, db);
                    adapter.SelectCommand.Parameters.AddWithValue("@dni_paciente", dni_buscado);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvRegistrosPacientes.AutoGenerateColumns = true;
                    dgvRegistrosPacientes.DataSource = dt;

                    //Si no hay resultados, se muestra un mensaje
                    panelRegistrosPacientes.Controls.Clear();
                    if (dt.Rows.Count == 0)
                    {
                        panelRegistrosPacientes.Controls.Add(CrearPanelMensaje("El paciente ingresado no posee registros"));
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar los historiales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            lbl.Text = "No se han encontrado registros: " + texto + ".";

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

        private void PlaceholderBusqueda(ComboBox txt, string placeholder)//Funcion que coloca un texto fantasma en caso de estar vacio
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


    }
}
