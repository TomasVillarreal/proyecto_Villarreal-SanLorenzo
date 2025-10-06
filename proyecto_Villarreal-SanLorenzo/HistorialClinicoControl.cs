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
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;
        public HistorialClinicoControl()
        {
            InitializeComponent();
        }

        private void HistorialClinicoControl_Load(object sender, EventArgs e)
        {
            PlaceholderBusqueda(tBusquedaDNI, "Buscar por DNI...");
            PlaceholderBusqueda(comboBoxCategoria, "Buscar por tipo de intervención...");
            //cargarDatosPacientes();
            CargarIntervenciones();
        }

        private void tBusquedaDNI_KeyDown(object sender, KeyEventArgs e)//Funcion que busca al paciente por su DNI.
        { 

            if (e.KeyCode == Keys.Enter)
            {
                // Si lo que el usuario aprieta es un numero, entonces muestro el paciente con ese dni
                if (int.TryParse(tBusquedaDNI.Text, out int dni_busqueda))
                {
                    (dgPaciente.DataSource as DataTable).DefaultView.RowFilter =
                     $"cDniPaciente LIKE '%{dni_busqueda}%'";
                }
                // Si el textbox esta vacio y aprieta enter, entonces se muestra el paciente
                else if (string.IsNullOrWhiteSpace(tBusquedaDNI.Text))
                {

                    (dgPaciente.DataSource as DataTable).DefaultView.RowFilter = "";
                }
                // Si no escribio un numero, muestro mensaje de error
                else
                {
                    MessageBox.Show("El DNI ingresado es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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

        private void comboBoxCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            //Agregar funcionalidad para buscar por tipo de intervencion
        }

        private void CargarIntervenciones()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=proyecto_Villarreal_SanLorenzo;Integrated Security=True;TrustServerCertificate=True;";

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
        }//Funcion que carga al comboBox los tipos de registros


    }
}
