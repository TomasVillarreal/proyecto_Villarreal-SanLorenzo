using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class PacientesControl : UserControlProyecto
    {
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
                        // Aquí dni ya tiene el valor
                        dgPaciente.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Se ha eliminado al paciente de DNI " + dni, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }   
    }
}
