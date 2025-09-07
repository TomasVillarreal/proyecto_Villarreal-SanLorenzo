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
    public partial class Form_login : Form
    {
        private bool mostrando = false; //Utilizado para el btn que muestra la oculta el password.

        public Form_login()
        {
            InitializeComponent();
        }

        private void bIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text.Trim();
            string password = tbPass.Text.Trim();

            if (usuario == "admin" && password == "1234")
            {
                Form1 formHome = new Form1();
                formHome.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos!",
                    "Error inicio de sesión", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void bOjo_Click(object sender, EventArgs e)
        {

        }
    }
}
