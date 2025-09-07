using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class PacientesControl : UserControlProyecto
    {

        public event EventHandler AbrirOtroControl;
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

            if (columnaClickeada.HeaderText == "cEliminarPaciente")
            {
                DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    object valorCelda = pacienteClickeado.Cells["DNI"].Value;

                    if (valorCelda != null && int.TryParse(valorCelda.ToString(), out dni))
                    {
                        dgPaciente.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Se ha eliminado al paciente de DNI " + dni, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void CargarDatos()
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT dni_paciente, nombre_paciente + ' ' + apellido_paciente AS nombre_completo, telefono_paciente FROM Paciente";

                SqlCommand cmd = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                dgPaciente.Rows.Clear(); // limpiar filas anteriores

                while (reader.Read())
                {
                    dgPaciente.Rows.Add(
                        reader["dni_paciente"],
                        reader["nombre_completo"],
                        reader["telefono_paciente"]
                    );
                }

                db.Close();
            }
        }

        private void bRegistrarPaciente_Click(object sender, EventArgs e)
        {
            AbrirOtroControl?.Invoke(this, EventArgs.Empty);
        }

        private void PacientesControl_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
