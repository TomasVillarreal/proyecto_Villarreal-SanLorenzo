using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    public class FilasUltimaActividad : Panel
    {
        /* Dni, y nro registro e historial son datos necesarios para poder
         * cargar los datos de la respectiva fila que estamos intentando crear */
        int dni = 0;
        int nro_registro = 0;
        int nro_historial = 0;
        // Booleano para poder diferenciar que tipo de fila estamos intentando crear
        bool nuevosPacientes;
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";
        // Evento con el que podremos irnos a otros uc cuando se clickea en la fila
        public event EventHandler ClickFila;

        // Constructor que hace las cosas basicas de la fila
        public FilasUltimaActividad(int p_dni, int p_nro_registro, int p_nro_historial, bool p_nuevosPacientes)
        {
            // Lo pone pituco cambiandole el color y tamaño
            this.BackColor = Color.White;
            this.Size = new Size(300, 46);

            // Se van asignando los datos de los parametros a los atributos
            this.nuevosPacientes = p_nuevosPacientes;
            if (p_dni != 0) this.dni = p_dni;
            if (p_nro_registro != 0) this.nro_registro = p_nro_registro;
            if (p_nro_historial != 0) this.nro_historial = p_nro_historial;

            // Se suscribe el evento que ocurre cuando se hace click sobre la fila
            this.Click += OnClickGeneral;

            InitializeComponents();
        }

        // Si se hace click sobre la fila, se invoca al eventhandler de los atributos
        private void OnClickGeneral(object? sender, EventArgs e)
        {
            ClickFila?.Invoke(this, EventArgs.Empty);
        }

        // Evento que carga todos los labels y cosas de la fila
        private void InitializeComponents()
        {
            // Se crean las cosas
            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Left;
            pb.Size = new Size(25, 46);
            pb.SizeMode = PictureBoxSizeMode.Zoom;

            Label lNombrePaciente = new Label();
            lNombrePaciente.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lNombrePaciente.AutoSize = true;
            lNombrePaciente.Location = new Point(pb.Right + 10, 10);
            lNombrePaciente.Text = ObtenerNombrePaciente();

            Label lDescripcion = new Label();
            lDescripcion.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lDescripcion.AutoSize = true;
            lDescripcion.Location = new Point(pb.Right + 10, 25);
            lDescripcion.Text = nuevosPacientes ? "Registrado por " + ObtenerNombreMedico() : ObtenerTipoRegistro();

            Label lFecha = new Label();
            lFecha.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lFecha.AutoSize = true;
            lFecha.Location = new Point(this.Width - 67, 10);
            lFecha.Text = ObtenerFecha();

            pb.Image = nuevosPacientes ? Resource1.plus : Resource1.exclamation;

            // Se añaden esas cosas al panel
            this.Controls.Add(pb);
            this.Controls.Add(lNombrePaciente);
            this.Controls.Add(lDescripcion);
            this.Controls.Add(lFecha);

            // Recorremos cada una de esas cosas y:
            foreach (Control c in this.Controls)
            {
                /* Le asignamos a todas y cada una de esas cosas los metodos
                 * que hacen que la fila cambie de color si esta se le hace hover o si
                 * se sale del hover. Se hace esto para que la fila siga cambiando de 
                 * color incluso si se hace hover sobre los labels y demas*/
                c.MouseEnter += (s, e) => this.OnMouseEnter(e);
                c.MouseLeave += (s, e) => this.OnMouseLeave(e);
                // Lo mismo que lo del hover, pero para que se pueda clickear incluso sobre los labels.
                c.Click += (s, e) => OnClickGeneral(this, e);
            }
        }

        // Funcion que accede a BD para obtener el nombre del  que hizo lo que sea q representa la fila
        private string ObtenerNombrePaciente()
        {
            string nombre_completo = "";
            // Obtenemos el nombre desde la bd
            using(SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre_paciente + ' ' + apellido_paciente AS nombre_completo " +
                    "FROM Paciente WHERE dni_paciente = @dni";
                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@dni", this.dni);
                    db.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // avanza al primer registro
                    {
                        nombre_completo = reader["nombre_completo"].ToString();
                    }
                }
                db.Close();
            }
            // Creamos un culture info para poder capitalizar el nombre y apellido
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(nombre_completo);
        }

        // Funcion para obtener la fecha de lo q sea que representa la fila
        private string ObtenerFecha()
        {
            string fecha = "";
            string query = "";
            string nombre_columna = "";

            // Si estamos haciendo una fila para representar a un paciente, creamos una query
                if (nuevosPacientes)
                {
                    query = "SELECT fecha_creacion_registro " +
                        "FROM Paciente WHERE dni_paciente = @dni";
                    nombre_columna = "fecha_creacion_registro";
                // Si no, y buscamos representar un registro, creamos otra query
                } else
                {
                    query = "SELECT fecha_registro " +
                            "FROM Registro WHERE id_historial = @nro_historial AND id_registro = @nro_registro AND dni_paciente = @dni";
                    nombre_columna = "fecha_registro";
                }
                // Y ahora obtengo la fecha
                using (SqlConnection db = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@dni", this.dni);
                        if (!nuevosPacientes)
                        {
                            cmd.Parameters.AddWithValue("@nro_historial", this.nro_historial);
                            cmd.Parameters.AddWithValue("@nro_registro", this.nro_registro);
                        }
                        db.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) // avanza al primer registro
                        {
                            DateTime fechaDT = (DateTime)reader[nombre_columna];
                            fecha = fechaDT.ToString("dd/MM/yyyy");
                        }
                    }
                    db.Close();
                }
            return fecha;
        }


        // Funcion que accede a BD para obtener el nombre del medico que hizo lo que sea q representa la fila
        // Basicamente hace lo mismo q la funcion para obtener el nombre del paciente
        private string ObtenerNombreMedico()
        {
            string nombre_completo = "";
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT m.nombre_usuario + ' ' + m.apellido_usuario AS nombre_completo " +
                    "FROM Paciente p INNER JOIN Usuarios m ON p.usuario_creacion_registro = m.id_usuario " +
                    "WHERE p.dni_paciente = @dni";
                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@dni", this.dni);
                    db.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // avanza al primer registro
                    {
                        nombre_completo = reader["nombre_completo"].ToString();
                    }
                }
                db.Close();
            }
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(nombre_completo);
        }

        // Funcion para obtener el tipo de registro
        private string ObtenerTipoRegistro()
        {
            string nombre_registro = "";
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT tr.nombre_registro " +
                    "FROM Registro r INNER JOIN Tipo_registro tr ON r.id_tipo_registro = tr.id_tipo_registro " +
                    "WHERE r.id_historial = @nro_historial AND r.id_registro = @nro_registro AND r.dni_paciente = @dni";
                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@dni", this.dni);
                    cmd.Parameters.AddWithValue("@nro_registro", this.nro_registro);
                    cmd.Parameters.AddWithValue("@nro_historial", this.nro_historial);
                    db.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // avanza al primer registro
                    {
                        nombre_registro = reader["nombre_registro"].ToString();
                    }
                }
                db.Close();
            }
            return nombre_registro;
        }

        // Evento que ocurre cuando se hace hover sobre la fila y le cambia el color
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Color.FromArgb(240, 240, 240);
        }

        // Evento que ocurre cuando se sale del hover sobre la fila y le cambia el color
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Color.White;
        }
    }
}
