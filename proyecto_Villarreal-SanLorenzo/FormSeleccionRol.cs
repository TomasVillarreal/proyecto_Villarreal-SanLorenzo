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
    public partial class FormSeleccionRol : Form
    {
        public string RolSeleccionado { get; private set; }
        public FormSeleccionRol(List<string> roles)
        {
            InitializeComponent();
            comboBoxRoles.DataSource = roles;
        }

        private void bIniciarSesion_Click(object sender, EventArgs e)
        {
            if (comboBoxRoles.SelectedItem != null)
            {
                RolSeleccionado = comboBoxRoles.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debes seleccionar un rol para continuar.");
            }
        }
    }
}
