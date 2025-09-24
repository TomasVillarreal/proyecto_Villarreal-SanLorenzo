//Es importante tener esto
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class PacientesControl : UserControlProyecto
    {

        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;
        /* Creacion del string que nos permitira la conexion a la base de datos.
         * El trusted_connection nos permite el ingreso a la bd en caso de que la forma de autenticacion sea 
         * a traves de la cuenta de la computadora, en caso contrario se debera especificar el usuario y contraseña adecuado.
         * El localhost sirve para determinar si el server de sql se encuentra en la pc. Tambien podria ser usado el nombre
         * exacto de la conexion, como por ejemplo DESKTOP-ASD/MSSQL. 
         */
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";


        public PacientesControl()
        {
            InitializeComponent();
        }

        private void dgPaciente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgPaciente.Rows[e.RowIndex].Cells["cDniPaciente"].Value == null) return;

            DataGridViewColumn columnaClickeada = dgPaciente.Columns[e.ColumnIndex];
            DataGridViewRow pacienteClickeado = dgPaciente.Rows[e.RowIndex];
            int dni = 0;

            if (columnaClickeada.Name == "cEliminarPaciente")
            {
                DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    object valorCelda = pacienteClickeado.Cells["cDniPaciente"].Value;

                    if (valorCelda != null && int.TryParse(valorCelda.ToString(), out dni))
                    {
                        /* 
                         * Se hace un try catch para poder agarrar las excepciones en aquellos casos en los cual ocurra
                         * un error con la bd, ya sea su conexion o algun error en lo que respecta a las queries.
                         */
                        try
                        {
                            //Se establece la conexion a la base de datos
                            using (SqlConnection db = new SqlConnection(connectionString))
                            {
                                //Se genera la query para el update, en este caso.
                                string queryEliminarLogico = "UPDATE Paciente SET visible = 0 WHERE dni_paciente = @dni";

                                // Se utiliza un using para la creacion y ejecucion de la query.
                                using (SqlCommand cmd = new SqlCommand(queryEliminarLogico, db))
                                {
                                    //Con este comando agregamos valores a todos aquellos datos que posean el @... en nuestra query
                                    cmd.Parameters.AddWithValue("@dni", dni);

                                    db.Open();
                                    //Este comando se utiliza para ejecutar todas aquellas queries que sean con respecto a la modificacion de alguna tabla/fila.
                                    //No lee elementos. Para eso se utiliza el DataReader.
                                    cmd.ExecuteNonQuery();
                                    db.Close();
                                }
                            }
                            dgPaciente.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Se ha eliminado al paciente de DNI " + dni, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //Si ocurre un error, mostrar el mensaje.
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            else if (columnaClickeada.Name == "cEditarPaciente")
            {
                object valorCelda = pacienteClickeado.Cells["cDniPaciente"].Value;

                if (valorCelda != null && int.TryParse(valorCelda.ToString(), out dni))
                {
                    RegistrarPacienteControl registrarPaciente = new RegistrarPacienteControl(dni);

                    registrarPaciente.AbrirOtroControl += this.AbrirOtroControl;
                    registrarPaciente.ControlPadre = this;

                    AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(dni, registrarPaciente, true));
                }
            }
            else if (columnaClickeada.Name == "cReactivarPaciente")
            {
                object valorCelda = pacienteClickeado.Cells["cDniPaciente"].Value;
                if (valorCelda != null && int.TryParse(valorCelda.ToString(), out dni))
                {
                    try
                    {
                        using (SqlConnection db = new SqlConnection(connectionString))
                        {
                            string queryEliminarLogico = "UPDATE Paciente SET visible = 1 WHERE dni_paciente = @dni";

                            using (SqlCommand cmd = new SqlCommand(queryEliminarLogico, db))
                            {
                                cmd.Parameters.AddWithValue("@dni", dni);

                                db.Open();
                                cmd.ExecuteNonQuery();
                                db.Close();
                            }
                        }
                        dgPaciente.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Se ha reactivado al paciente de DNI " + dni, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        /* Funcion que tiene como objetivo cambiarle el headertext a las columnas agregadas
         * por el datatable al datagrid, y que tiene como objetivo tambien agregarle manualmente
         * unos botones y colocarlos al final del datatable, para poder realizar el CRUD.
         */
        public void AgregarBotonesTabla()
        {
            // Agrego los botones a datagrid.
            DataGridViewButtonColumn btnHistorial = new DataGridViewButtonColumn();
            btnHistorial.Name = "cHistorial";
            btnHistorial.HeaderText = "Ver Historial";
            btnHistorial.Text = "Ver";
            btnHistorial.UseColumnTextForButtonValue = true;
            btnHistorial.DisplayIndex = dgPaciente.Columns.Count;
            dgPaciente.Columns.Add(btnHistorial);

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "cEditarPaciente";
            btnEditar.HeaderText = "Editar";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.DisplayIndex = dgPaciente.Columns.Count;
            dgPaciente.Columns.Add(btnEditar);

            if (rbVisibles.Checked)
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "cEliminarPaciente";
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "X";
                btnEliminar.UseColumnTextForButtonValue = true;
                btnEliminar.DisplayIndex = dgPaciente.Columns.Count;
                dgPaciente.Columns.Add(btnEliminar);
            }
            else if (rbEliminados.Checked)
            {
                DataGridViewButtonColumn btnReactivar = new DataGridViewButtonColumn();
                btnReactivar.Name = "cReactivarPaciente";
                btnReactivar.HeaderText = "Reactivar";
                btnReactivar.Text = "Reactivar";
                btnReactivar.UseColumnTextForButtonValue = true;
                btnReactivar.DisplayIndex = dgPaciente.Columns.Count;
                dgPaciente.Columns.Add(btnReactivar);
            }

        }

        public void CargarDatosPacientesVisibles()
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string query = "SELECT dni_paciente, nombre_paciente + ' ' + apellido_paciente AS nombre_completo, telefono_paciente FROM Paciente WHERE visible = 1";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        db.Open();
                        //Creacion del elemento que nos permitira la lectura de datos de una tabla de una bd.
                        //Solo sirve para lectura, no para la ejecucion de queries que modifican algun valor.
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Creo un datatable y agrego los unicos campos que me interesan mostrar en el datagrid
                        DataTable dt = new DataTable();
                        dt.Columns.Add("cDniPaciente");
                        dt.Columns.Add("cNombrePaciente");
                        dt.Columns.Add("cTelefonoPaciente");

                        //Read es una funcion que nos permite leer la siguiente fila de una tabla, 
                        // tal que devuelve true si hay filas, o false en caso de que no haya.
                        while (reader.Read())
                        {
                            // Agrego los valores que leyo el reader al datatable
                            dt.Rows.Add(
                                reader["dni_paciente"],
                                reader["nombre_completo"],
                                reader["telefono_paciente"]
                            );
                        }
                        db.Close();

                        // Limpio el datasource que tenia previamente la tabla, y sus filas.
                        dgPaciente.DataSource = null;
                        dgPaciente.Columns.Clear();

                        // Agrego el datatable como el datasource de mi datagrid
                        dgPaciente.DataSource = dt;

                        // Cambio los nombres de las columnas
                        dgPaciente.Columns["cDniPaciente"].HeaderText = "DNI";
                        dgPaciente.Columns["cNombrePaciente"].HeaderText = "Nombre";
                        dgPaciente.Columns["cTelefonoPaciente"].HeaderText = "Teléfono";

                        // Arreglo algunas cosas del datagrid para que quede bien y se puedan usar los botones.
                        AgregarBotonesTabla();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarDatosPacientesEliminados()
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    string query = "SELECT dni_paciente, nombre_paciente + ' ' + apellido_paciente AS nombre_completo, telefono_paciente FROM Paciente WHERE visible = 0";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        db.Open();
                        //Creacion del elemento que nos permitira la lectura de datos de una tabla de una bd.
                        //Solo sirve para lectura, no para la ejecucion de queries que modifican algun valor.
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Creo un datatable y agrego los unicos campos que me interesan mostrar en el datagrid
                        DataTable dt = new DataTable();
                        dt.Columns.Add("cDniPaciente");
                        dt.Columns.Add("cNombrePaciente");
                        dt.Columns.Add("cTelefonoPaciente");

                        //Read es una funcion que nos permite leer la siguiente fila de una tabla, 
                        // tal que devuelve true si hay filas, o false en caso de que no haya.
                        while (reader.Read())
                        {
                            // Agrego los valores que leyo el reader al datatable
                            dt.Rows.Add(
                                reader["dni_paciente"],
                                reader["nombre_completo"],
                                reader["telefono_paciente"]
                            );
                        }
                        db.Close();

                        // Limpio el datasource que tenia previamente la tabla, y sus filas.
                        dgPaciente.DataSource = null;
                        dgPaciente.Columns.Clear();

                        // Agrego el datatable como el datasource de mi datagrid
                        dgPaciente.DataSource = dt;

                        // Cambio los nombres de las columnas
                        dgPaciente.Columns["cDniPaciente"].HeaderText = "DNI";
                        dgPaciente.Columns["cNombrePaciente"].HeaderText = "Nombre";
                        dgPaciente.Columns["cTelefonoPaciente"].HeaderText = "Teléfono";

                        // Arreglo algunas cosas del datagrid para que quede bien y se puedan usar los botones.
                        AgregarBotonesTabla();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bRegistrarPaciente_Click(object sender, EventArgs e)
        {
            RegistrarPacienteControl registrarPaciente = new RegistrarPacienteControl();

            registrarPaciente.AbrirOtroControl += this.AbrirOtroControl;
            registrarPaciente.ControlPadre = this;

            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, registrarPaciente, false));
        }

        private void PacientesControl_Load(object sender, EventArgs e)
        {
            CargarDatosPacientesVisibles();
            PlaceholderBusqueda(tBusquedaPacientes, "Buscar por DNI...");
        }

        // Funcion para denegar el ingreso de caracteres no numericos en la busqueda de pacientes por su dni
        private void tBusquedaPacientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^\d$") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        /* 
         * Funcion para colocar un placeholder (texto fantasma) que aparecera siempre que el textbox
         * de busqueda de pacientes por dni este vacio y no tenga un focus encima, y desaparecera
         * en caso contrario
         */
        private void PlaceholderBusqueda(TextBox txt, string placeholder)
        {
            // Coloco el texto pasado como argumento al textbos pasado como argumento
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

        // Funcion para realizar la busqueda del DNI del paciente, cuando este apriete enter
        private void tBusquedaPacientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Si lo que el usuario aprieta es un numero, entonces muestro el paciente con ese dni
                if (int.TryParse(tBusquedaPacientes.Text, out int dni_busqueda))
                {
                    (dgPaciente.DataSource as DataTable).DefaultView.RowFilter =
                     $"cDniPaciente LIKE '%{dni_busqueda}%'";
                }
                // Si el textbox esta vacio y aprieta enter, entonces muestro todo
                else if (string.IsNullOrWhiteSpace(tBusquedaPacientes.Text))
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

        private void rbVisibles_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatosPacientesVisibles();
        }

        private void rbEliminados_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatosPacientesEliminados();
        }
    }
}
