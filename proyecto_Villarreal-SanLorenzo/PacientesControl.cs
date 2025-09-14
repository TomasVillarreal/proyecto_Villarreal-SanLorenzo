//Es importante tener esto
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        string connectionString = "Server=localhost;Database=proyecto_Villarreal-SanLorenzo;Trusted_Connection=True;";


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
            } else if (columnaClickeada.Name == "cEditarPaciente")
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

        }

        public void CargarDatos()
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

                        dgPaciente.Rows.Clear();

                        //Read es una funcion que nos permite leer la siguiente fila de una tabla, 
                        // tal que devuelve true si hay filas, o false en caso de que no haya.
                        while (reader.Read())
                        {
                            dgPaciente.Rows.Add(
                                //De esta forma se accede al valor de la columna "dni_paciente" de la fila en la cual el reader se encuentra en ese momento.
                                reader["dni_paciente"],
                                reader["nombre_completo"],
                                reader["telefono_paciente"]
                            );
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

        private void bRegistrarPaciente_Click(object sender, EventArgs e)
        {
            RegistrarPacienteControl registrarPaciente = new RegistrarPacienteControl();

            registrarPaciente.AbrirOtroControl += this.AbrirOtroControl;
            registrarPaciente.ControlPadre = this;

            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, registrarPaciente, false));
        }

        private void PacientesControl_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
