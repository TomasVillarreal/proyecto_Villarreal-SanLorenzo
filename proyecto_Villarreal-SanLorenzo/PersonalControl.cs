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
    public partial class PersonalControl : UserControlProyecto
    {
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;

        public PersonalControl()
        {
            InitializeComponent();
        }

        private void dgPaciente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgPersonal.Rows[e.RowIndex].Cells["cDniPaciente"].Value == null) return;

            DataGridViewColumn columnaClickeada = dgPersonal.Columns[e.ColumnIndex];
            DataGridViewRow pacienteClickeado = dgPersonal.Rows[e.RowIndex];
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
                        dgPersonal.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Se ha eliminado al paciente de DNI " + dni, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void bRegistrarPersonal_Click(object sender, EventArgs e)
        {
            RegistrarUsuarioControl registrarUsuario = new RegistrarUsuarioControl();
            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, registrarUsuario, false));
        }
    }
}
