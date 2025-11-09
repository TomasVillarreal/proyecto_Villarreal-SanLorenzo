using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class EditarRegistroControl : UserControlProyecto
    {
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;

        public HistorialClinicoControl controlPadreRegistro;

        string connectionString = "Server=localhost;Database=proyecto_Villarreal_SanLorenzo;Trusted_Connection=True;";

        int dni = 0;
        int idRegistroActual = 0;
        int historial = 0;


        public EditarRegistroControl(int p_dni, int historial, int p_registro_actual = 0)
        {
            InitializeComponent();

            dni = p_dni;
            idRegistroActual = p_registro_actual;

            CargarDatosPaciente(dni);
            CargarTiposRegistro();
            CargarMedicaciones();

            if (idRegistroActual > 0)
                CargarRegistroParaEdicion(idRegistroActual);

            lDosis.Visible = false;
            tDosis.Visible = false;
        }

        public void CargarRegistroParaEdicion(int idRegistro)//Funcion que carga los datos del registro de acuerdo al id que se pasa por parametro para editar
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            r.observaciones, 
                            r.id_historial,
                            tr.nombre_registro, 
                            m.nombre_medicacion, 
                            m.dosis_medicacion AS dosis
                        FROM Registro r
                        LEFT JOIN Tipo_registro tr ON r.id_tipo_registro = tr.id_tipo_registro
                        LEFT JOIN Registro_medicacion rm ON r.id_registro = rm.id_registro
                        LEFT JOIN Medicacion m ON rm.id_medicacion = m.id_medicacion
                        WHERE r.id_registro = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idRegistro);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //se guarda el id del historial
                                this.historial = Convert.ToInt32(reader["id_historial"]);

                                // observaciones
                                tObservaciones.Text = reader["observaciones"]?.ToString() ?? string.Empty;

                                // tipo de registro
                                string tipo = reader["nombre_registro"]?.ToString();
                                if (!string.IsNullOrEmpty(tipo))
                                    comboBoxTipoRegistro.SelectedItem = tipo;

                                // medicación (nombre)
                                string medicacion = reader["nombre_medicacion"]?.ToString();
                                if (!string.IsNullOrEmpty(medicacion))
                                {
                                    comboBoxMedicacion.SelectedItem = medicacion;
                                    lDosis.Visible = true;
                                    tDosis.Visible = true;
                                    tDosis.Text = reader["dosis"]?.ToString() ?? string.Empty;
                                }
                                else
                                {
                                    comboBoxMedicacion.SelectedIndex = 0; // "(ninguna)"
                                    lDosis.Visible = false;
                                    tDosis.Visible = false;
                                    tDosis.Text = string.Empty;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el registro en la base de datos.", 
                                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
        }

        this.idRegistroActual = idRegistro;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al cargar el registro para edición: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }

        private void CargarTiposRegistro()//Funcion que carga los tipos de registros al combobox
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    string query = "SELECT nombre_registro FROM Tipo_registro ORDER BY nombre_registro;";
                    using (SqlCommand cmd = new SqlCommand(query, db))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBoxTipoRegistro.Items.Clear();

                        while (reader.Read())
                        {
                            comboBoxTipoRegistro.Items.Add(reader["nombre_registro"].ToString());
                        }
                    }

                    comboBoxTipoRegistro.SelectedIndex = 0; // valor inicial
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de registro: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMedicaciones()//Funcion que carga las medicaciones al combobox
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    string query = "SELECT nombre_medicacion FROM Medicacion ORDER BY nombre_medicacion;";
                    using (SqlCommand cmd = new SqlCommand(query, db))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBoxMedicacion.Items.Clear();

                        // 🔹 Insertamos opción "(ninguna)" al principio
                        comboBoxMedicacion.Items.Add("(ninguna)");

                        while (reader.Read())
                        {
                            comboBoxMedicacion.Items.Add(reader["nombre_medicacion"].ToString());
                        }
                    }

                    comboBoxMedicacion.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBoxMedicacion.SelectedIndex = 0; // "(ninguna)" como valor por defecto
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las medicaciones: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosPaciente(int p_dni)
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Selecciono todas las columnas de la fila cuyo DNI coincida con el que se le fue pasado como argumento
                    string query = "SELECT dni_paciente, nombre_paciente, apellido_paciente FROM Paciente WHERE dni_paciente = @dni";
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
                        }

                        db.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error con la base de datos! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Funcion que carga los datos del paciente
        private void bAtras_Click(object sender, EventArgs e)//Funcion que permite volver a la vista anterior
        {
            var parent = this.Parent; // obtenemos el contenedor del control actual

            if (parent != null && controlPadreRegistro != null)
            {
                controlPadreRegistro.CargarHistoriales(dni);
                parent.Controls.Clear();
                parent.Controls.Add(controlPadreRegistro);
                controlPadreRegistro.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("No se pudo volver atrás.");
            }
        }
        private void comboBoxMedicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si la opción elegida es distinta de "(ninguna)", mostramos dosis
            if (comboBoxMedicacion.SelectedItem == null || comboBoxMedicacion.SelectedItem.ToString() == "(ninguna)")
            {
                lDosis.Visible = false;
                tDosis.Visible = false;
                tDosis.Text = string.Empty;

            }
            else
            {
                lDosis.Visible = true;
                tDosis.Visible = true;

            }
        }//Funcion que permite mostrar el textbox de la dosis solo si se seleccionó un medicamento

        private void bGuardarCambios_Click(object sender, EventArgs e)//Funcion que mediante el click del boton, guarda los cambios del registro
        {
            bool exito = false;
            var parent = this.Parent;
            int filas = 0;
            Dictionary<string, object> diccionario = CrearDiccionario();

            if (DetectarErrores(diccionario))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // aca se actualiaz el registro
                        string updateRegistro = @"
                                                UPDATE Registro
                                                SET observaciones = @obs,
                                                    id_tipo_registro = (SELECT id_tipo_registro FROM Tipo_registro WHERE nombre_registro = @tipo),
                                                    fecha_modificacion = GETDATE()
                                                WHERE id_registro = @id";

                        using (SqlCommand cmd = new SqlCommand(updateRegistro, conn))
                        {
                            cmd.Parameters.AddWithValue("@obs", tObservaciones.Text.Trim());
                            cmd.Parameters.AddWithValue("@tipo", comboBoxTipoRegistro.SelectedItem?.ToString());
                            cmd.Parameters.AddWithValue("@id", idRegistroActual);

                            // CORRECCIÓN: Ejecutar UNA sola vez.
                            filas = cmd.ExecuteNonQuery();
                        }

                        // para la medicacion
                        string medicacion = comboBoxMedicacion.SelectedItem?.ToString();

                        if (filas > 0)
                        {
                            MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            exito = true;
                        }
                        else
                        {
                            MessageBox.Show("No se realizaron cambios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            exito = false;
                        }

                        // si no se selecciona medicacion, se cambia la actual por ninguna
                        if (medicacion == "(ninguna)" || medicacion == null)
                        {
                            string deleteMed = "DELETE FROM Registro_medicacion WHERE id_registro = @id";
                            using (SqlCommand cmd = new SqlCommand(deleteMed, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", idRegistroActual);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // primero borro la medicacion anterior (si la hay)
                            string deleteMed = "DELETE FROM Registro_medicacion WHERE id_registro = @id";
                            using (SqlCommand cmd = new SqlCommand(deleteMed, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", idRegistroActual);
                                cmd.ExecuteNonQuery();
                            }

                            // ahora obtengo el id_medicacion desde la tabla Medicacion
                            int idMedicacion = 0;

                            string queryMed = @"SELECT id_medicacion FROM Medicacion WHERE nombre_medicacion = @med";
                            using (SqlCommand cmdMed = new SqlCommand(queryMed, conn))
                            {
                                cmdMed.Parameters.AddWithValue("@med", medicacion);
                                object result = cmdMed.ExecuteScalar();
                                if (result != null)
                                    idMedicacion = Convert.ToInt32(result);
                            }

                            // inserto en la tabla de registro_medicacion, que no hay dosis
                            string insertMed = @"
                                        INSERT INTO Registro_medicacion (id_registro, id_historial, dni_paciente, id_usuario, id_medicacion)
                                        VALUES (
                                            @idRegistro,
                                            (SELECT id_historial FROM Registro WHERE id_registro = @idRegistro),
                                            (SELECT dni_paciente FROM Registro WHERE id_registro = @idRegistro),
                                            @idUsuario,
                                            @idMedicacion
                                        )";

                            using (SqlCommand cmd = new SqlCommand(insertMed, conn))
                            {
                                cmd.Parameters.AddWithValue("@idRegistro", idRegistroActual);
                                cmd.Parameters.AddWithValue("@idUsuario", SesionUsuario.id_usuario);
                                cmd.Parameters.AddWithValue("@idMedicacion", idMedicacion);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        exito = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los cambios: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    exito = false;
                }
            }

            if (exito && parent != null && controlPadreRegistro != null)
            {
                controlPadreRegistro.CargarHistoriales(dni, idRegistroActual);
                controlPadreRegistro.ResaltarRegistro(this.historial, idRegistroActual, dni);
                parent.Controls.Clear();
                parent.Controls.Add(controlPadreRegistro);
                controlPadreRegistro.Dock = DockStyle.Fill;
            }
        }

        // Funcion que crea un diccionario tal que sus claves seran los nombres de los distintos tipos de datos que se colocaron 
        // en el usercontrol, y cuyos valores son efectivamente estos datos
        private Dictionary<string, object> CrearDiccionario()
        {
            // Creo el diccionario, asigno las claves con los valores y lo devuelvo
            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic.Add("observaciones", tObservaciones.Text);
            dic.Add("tipoRegistro", comboBoxTipoRegistro.Text);
            dic.Add("medicacion", comboBoxMedicacion.Text);
            dic.Add("dosis", tDosis.Text);

            return dic;
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
                 * si la clave es 'nombre', lo que hago es capitalizar la primera letra, y le concateno esto
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
                        case "tipoRegistro":
                            // Si tipoRegistro es una selección inválida (ej: item guía)
                            if (valor == "Seleccione...")
                            {
                                lblError.Visible = true;
                                lblError.Text = "Por favor seleccione un tipo de registro";
                                todoBien = false;
                            }
                            break;

                        case "medicacion":
                            // En medicacion solo verificamos que no esté vacío porque es un combo predefinido
                            break;

                        case "dosis":
                            // Si dosis no es numérica o no es mayor a cero
                            if (!double.TryParse(valor, out double dosisNum) || dosisNum <= 0)
                            {
                                lblError.Visible = true;
                                lblError.Text = "Por favor inserte una dosis válida (> 0)";
                                todoBien = false;
                            }
                            break;

                        case "observaciones":
                            // Observaciones puede ser libre, no se aplica validación extra
                            break;
                    }
                }
            }

            return todoBien;
        }
    }
}
