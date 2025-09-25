using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//Es importante usar esto.
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
    public partial class RegistrarPacienteControl : UserControlProyecto
    {
        // Linea de conexion a la bd
        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";
        // Event handler utilizado para poder ir hacia la vista de Pacientes una vez ingresado un paciente
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;
        // Atributo que permite determinar cual es el control que llama a esta vista, para poder volver hacia el control que lo llamo
        public PacientesControl ControlPadre;
        // Atributo que nos permitira buscar y cargar los datos de un paciente que se busca editar
        int dni = 0;

        public RegistrarPacienteControl()
        {
            InitializeComponent();
        }

        // Constructor que nos permitira crear un control de este tipo con un DNI, lo cual significa que 
        // estamos buscando editar un paciente
        public RegistrarPacienteControl(int p_dni)
        {
            InitializeComponent();
            this.dni = p_dni;

            // Si el DNI pasado es distinto de 0, entonces cargamos los datos y cambiamos el texto del boton de registrar a editar
            if (dni != 0)
            {
                this.CargarDatos(p_dni);
                bRegistrarPaciente.Text = "Editar Paciente";
                tDniPacienteRegistro.ReadOnly = true;
            }
        }

        // Funcion que nos permitira rellenar todos y cada uno de los textbox del usercontrol con los datos del paciente
        // cuyo DNI coincida con el que se pasa como argumento
        private void CargarDatos(int p_dni)
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Selecciono todas las columnas de la fila cuyo DNI coincida con el que se le fue pasado como argumento
                    string query = "SELECT * FROM Paciente WHERE dni_paciente = @dni";
                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@dni", p_dni);
                        db.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            // Relleno todos y cada uno de los controles con los datos del paciente
                            tApellidoPacienteRegistro.Text = reader["apellido_paciente"].ToString(); ;
                            tNombrePacienteRegistro.Text = reader["nombre_paciente"].ToString(); ;
                            tDniPacienteRegistro.Text = reader["dni_paciente"].ToString();
                            tTelefonoPacienteRegistro.Text = reader["telefono_paciente"].ToString();
                            tDireccionPacienteRegistro.Text = reader["direccion_paciente"].ToString();
                            if (!reader.IsDBNull(reader.GetOrdinal("fecha_nacimiento_paciente")))
                            {
                                tFechaPacienteRegistro.Value = reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento_paciente"));
                            }
                        }

                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Funcion que nos permitira el registro de un paciente
        private void RegistrarPaciente()
        {
            Dictionary<string, object> diccionario = CrearDiccionario();

            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Creamos la query para agregar el paciente
                    string queryAgregar = "INSERT INTO Paciente (dni_paciente, nombre_paciente, apellido_paciente, direccion_paciente," +
                        "telefono_paciente, fecha_nacimiento_paciente, usuario_creacion_registro) VALUES (@dni, @nombre, @apellido, @direccion," +
                        "@telefono, @fecha_nacimiento, @usuario_creacion)";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, db))
                    {
                        // Rellenamos con los datos que se encontraban en el diccionario
                        cmd.Parameters.AddWithValue("@dni", Convert.ToInt32(diccionario["dni"]));
                        cmd.Parameters.AddWithValue("@nombre", diccionario["nombre"].ToString());
                        cmd.Parameters.AddWithValue("@apellido", diccionario["apellido"].ToString());
                        cmd.Parameters.AddWithValue("@direccion", diccionario["direccion"].ToString());
                        cmd.Parameters.AddWithValue("@telefono", Convert.ToInt64(diccionario["telefono"]));
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", diccionario["fecha_nacimiento"]);
                        cmd.Parameters.AddWithValue("@usuario_creacion", SesionUsuario.id_usuario);

                        // Ejecutamos la query
                        db.Open();
                        cmd.ExecuteNonQuery();
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Este numero de excepcion indica que ha ocurrido una excepcion de PK duplicada
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Ya existe un paciente con ese DNI", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Este numero de excepcioon indica que ha ocurrido un duplicado en algun campo unico
                else if (ex.Number == 2601)
                {
                    MessageBox.Show("Se esta intentando crear un registro con un valor unico repetido",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la base de datos: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Funcion que crea un diccionario tal que sus claves seran los nombres de los distintos tipos de datos que se colocaron 
        // en el usercontrol, y cuyos valores son efectivamente estos datos
        private Dictionary<string, object> CrearDiccionario()
        {
            // Creo el diccionario, asigno las claves con los valores y lo devuelvo
            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic.Add("dni", tDniPacienteRegistro.Text);
            dic.Add("nombre", tNombrePacienteRegistro.Text);
            dic.Add("apellido", tApellidoPacienteRegistro.Text);
            dic.Add("direccion", tDireccionPacienteRegistro.Text);
            dic.Add("telefono", tTelefonoPacienteRegistro.Text);
            dic.Add("fecha_nacimiento", tFechaPacienteRegistro.Value.Date);

            return dic;
        }

        // Funcion  para editar un paciente, tal que los datos de este fueron cargados en la funcion de CargarDatos
        private void EditarPaciente()
        {
            Dictionary<string, object> diccionario = CrearDiccionario();
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Creo la query, asigno los datos del diccionario y ejecuto la query
                    string queryAgregar = "UPDATE Paciente SET nombre_paciente=@nombre, apellido_paciente=@apellido, " +
                        "direccion_paciente=@direccion,telefono_paciente=@telefono, fecha_nacimiento_paciente=@fecha_nacimiento, " +
                        "fecha_modificacion_registro = @fechaHoy, usuario_modif_registro = @usuario_modif "
                        + "WHERE dni_paciente = @dni";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, db))
                    {

                        cmd.Parameters.AddWithValue("@dni", Convert.ToInt32(diccionario["dni"]));
                        cmd.Parameters.AddWithValue("@nombre", diccionario["nombre"].ToString());
                        cmd.Parameters.AddWithValue("@apellido", diccionario["apellido"].ToString());
                        cmd.Parameters.AddWithValue("@direccion", diccionario["direccion"].ToString());
                        cmd.Parameters.AddWithValue("@telefono", Convert.ToInt64(diccionario["telefono"]));
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", diccionario["fecha_nacimiento"]);
                        cmd.Parameters.AddWithValue("@fechaHoy", DateTime.Today);
                        cmd.Parameters.AddWithValue("@usuario_modif", SesionUsuario.id_usuario);


                        db.Open();
                        cmd.ExecuteNonQuery();
                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Este numero de excepcion indica que ha ocurrido una excepcion de PK duplicada
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Ya existe un paciente con ese DNI", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Este numero de excepcioon indica que ha ocurrido un duplicado en algun campo unico
                else if (ex.Number == 2601)
                {
                    MessageBox.Show("Se esta intentando crear un registro con un valor unico repetido",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la base de datos: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento que sucede al hacer click en el boton de registrar paciente
        private void bRegistrarPaciente_Click(object sender, EventArgs e)
        {
            ApretarEnter();
        }

        /* Funcion que nos permite hacer dos cosas. La primera, devuelve un booleano basado en si hubo algun error
         * en los datos ingresados en los textbox, dentro de las cosas permitidas. 
         * La segunda, en base a si hubo estos errores, hace visible unos labels (anteriormente invisibles) y les 
         * modifica el texto para poder mostrarle al usuario que cosas puso mal.
        */
        private bool DetectarErrores(Dictionary<string, object> dic)
        {
            // Booleano que luego se devolvera.
            bool todoBien = true;

            // Recorro uno a uno las claves del diccionario pasado como argumento
            foreach (var clave in dic.Keys)
            {
                // Obtengo el valor que esta asociado en una clave del diccionario (en caso de que exista)
                string valor = dic[clave]?.ToString() ?? "";
                /* Creo un string que luego servira para poder acceder al label de error correspondiente
                 * a dicho tipo de dato. Este string esta formado por la primera parte que corresponde al
                 * formato del label "lError" y una segunda parte cuyo valor depende de la clave. Por ejemplo,
                 * si la clave es 'dni', lo que hago es capitalizar la primera letra, y le concateno esto
                 * a la parte del formato, de tal forma que quede lErrorDni, tal que esto coincide con el 
                 * nombre el cual se le puso al label invisible
                 */
                string lblErrorNombre = "lError" + char.ToUpper(clave[0]) + clave.Substring(1);

                // Busco el label cuyo nombre coincide con el string creado arriba. El bool
                // pasado como argumento sirve para ver si se quiere buscar sobre todos los controles hijo.
                Control[] controles = this.Controls.Find(lblErrorNombre, true);
                // Si el vector con controles esta vacio, o si no es un label, nos salteamos esta iteracion.
                // En caso de que si sea un label, se le asigna el nombre de lblError.
                if (controles.Length == 0 || !(controles[0] is Label lblError))
                    continue;

                /*
                 * Colocamos la visibilidad del label error en falso, asi si se verifica mas de una vez
                 * al registro este no queda visible por los intentos anteriores
                 */
                lblError.Visible = false;

                // Si el valor esta vacio, mostramos mensaje de error en el label. Esto afecta a todos los tipos de dato.
                if (string.IsNullOrWhiteSpace(valor))
                {
                    lblError.Visible = true;
                    lblError.Text = "Por favor rellene este campo";
                    todoBien = false;
                }
                else
                {
                    // Si el valor no esta vacio, verificamos que tipo de dato es y mostramos un dato diferente en cada caso
                    switch (clave)
                    {
                        // Si el valor es un dni:
                        case "dni":
                            /* 
                             * Si el dni no cumple este sea un numero, o no cumple que 7 < dni < 8,
                             * entonces mostramos mensaje de error
                             */
                            if (!int.TryParse(valor, out int dniVal) || valor.Length < 7 || valor.Length > 8)
                            {
                                lblError.Visible = true;
                                lblError.Text = "Por favor inserte un DNI válido";
                                todoBien = false;
                            }
                            break;
                        case "telefono":
                            // Si el telefono es distinto de diez, o hay caracteres que no son digitos, mostramos msj de error.
                            if (valor.Length != 10 || !valor.All(char.IsDigit))
                            {
                                lblError.Visible = true;
                                lblError.Text = "Por favor inserte un numero de teléfono válido";
                                todoBien = false;
                            }
                            break;
                        case "direccion":
                            /*
                             * La direccion es un tipo de dato varchar tanto en el textbox como en el sql, pero la
                             * direccion no puede ser unicamente numeros. En caso de que la direccion tenga unicamente
                             * numeros, mostramos msj de error.
                             */
                            if (valor.All(char.IsDigit))
                            {
                                lblError.Visible = true;
                                lblError.Text = "Por favor inserte una dirección válida";
                                todoBien = false;
                            }
                            break;
                    }
                }
            }

            return todoBien;
        }


        // Funcion que nos permitira hacer las acciones que respectan al boton de registro
        private void ApretarEnter()
        {
            Dictionary<string, object> diccionario = CrearDiccionario();
            // Si no hay errores detectados, entonces:
            if (DetectarErrores(diccionario))
            {
                // Si no hay un DNI colocado como atributo, entonces es un registro
                if (this.dni == 0)
                {
                    this.RegistrarPaciente();
                }
                // Si hay un DNI colocado, entonces es una edicion.
                else
                {
                    this.EditarPaciente();
                }
                // Una vez hecha la accion, volvemos al control que nos llamo.
                ControlPadre?.CargarDatosPacientesVisibles();
                AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(0, this.ControlPadre, false));
            }
        }

        // Esta funcion lo que hace es que si un textbox tiene el foco, y se aprieta el enter, se apriete
        // la misma funcion que se llama al apretar el boton de registro
        private void textBoxControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
                ApretarEnter();
            }
        }

        // de aca en adelante son las funciones que limitan lo que el usuario puede escribir
        private void tbTextoCaracteresPacienteRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tbNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^\d$") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tbDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9\s]") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void RegistrarPacienteControl_Load(object sender, EventArgs e)
        {
            tFechaPacienteRegistro.MaxDate = DateTime.Today;
        }

        private void bAtras_Click(object sender, EventArgs e)
        {
            // Volvemos al control que nos llamo.
            ControlPadre?.CargarDatosPacientesVisibles();
            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(0, this.ControlPadre, false));
        }
    }
}
