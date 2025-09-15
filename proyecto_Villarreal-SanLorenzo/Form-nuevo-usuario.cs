using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net; //Usado para hashear el password

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class Form_nuevo_usuario : Form
    {
        private bool passVisible = false; //Utilizado para el btn que muestra la oculta el password.
        public Form_nuevo_usuario()
        {
            this.InitializeComponent();
        }

        private void botonSidebar2_Click(object sender, EventArgs e)
        {
            Form_nuevo_usuario formularioUsuarios = new Form_nuevo_usuario();
            formularioUsuarios.Show();
            this.Close();
        }

        private int rbRolCheck(object sender, EventArgs e)
        {
            int rol = 0;
            if (rbMedico.Checked)
            {
                lTitulo2.Text = "Médico";
                lTitulo2.ForeColor = Color.Black;
                flowLayoutPanel10.Visible = true;
                rol = 2;
            }
            else if (rbEnfermero.Checked)
            {
                lTitulo2.Text = "Enfermero";
                lTitulo2.ForeColor = Color.Black;
                flowLayoutPanel10.Visible = true;
                rol = 3;
            }
            else if (rbPersonalAdmin.Checked)
            {
                lTitulo2.Text = "Administrativo";
                lTitulo2.ForeColor = Color.Black;
                flowLayoutPanel10.Visible = false;
                rol = 4;

            }
            else if (rbGerente.Checked)
            {
                lTitulo2.Text = "Gerente";
                lTitulo2.ForeColor = Color.Black;
                flowLayoutPanel10.Visible = false;
                rol = 1;

            }
            return rol;
        }

        public bool CheckRadioButtons()
        {
            foreach (Control control in flowLayoutPanel10.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton rb = (RadioButton)control;
                    if (rb.Checked)
                    {
                        return true;//Hay un radioButton seleccionado
                    }
                }
            }
            return false; //Ninguno fue seleccionado
        }

        private void tbNomUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permite letras, la tecla de retroceso y espacio en caso de nombres compuestos
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; //Evita el ingreso de caracteres no deseados o numeros
            }
        }

        private void tbApellidoUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            //Verifica si el usuario ingreso el carácter '@'
            if (!tbEmail.Text.Contains("@"))
            {
                //Si no lo contiene, muestra un mensaje de error
                MessageBox.Show("El correo electrónico debe contener un '@'.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Cancela la validación
                e.Cancel = true;
            }
        }

        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permite que el usuario solo ingrese numeros (0-9) y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; //Cancela la entrada de cualquier otro carácter
            }
        }

        private void bMostrarPass_Click(object sender, EventArgs e)
        {
            if (passVisible == false)
            {
                tbPassUsuario.PasswordChar = '\0';
                bMostrarPass.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoCerrado;
                passVisible = true;
            }
            else
            {
                tbPassUsuario.PasswordChar = '*';
                bMostrarPass.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoAbierto;
                passVisible = false;
            }
        }

        private void bMostrarConfPass_Click(object sender, EventArgs e)
        {
            if (passVisible == false)
            {
                tbConfirmPass.PasswordChar = '\0';
                bMostrarPass.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoCerrado;
                passVisible = true;
            }
            else
            {
                tbConfirmPass.PasswordChar = '*';
                bMostrarPass.Image = proyecto_Villarreal_SanLorenzo.Resource1.ojoAbierto;
                passVisible = false;
            }

        }

        private bool CheckPassword()//Metodo que compara la contraseña y la confirmacion de contraseña
        {
            string password = tbPassUsuario.Text;
            string confirmPassword = tbConfirmPass.Text;

            if (password == confirmPassword)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Error al confirmar la contraseña.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        private string HashPassword(string password)//Metodo que hashea el password
        {
            //Hashea la contraseña con una salt de 12
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        private bool VerfiPassword(string password, string hashedPassword)//Metodo que verifica el password con el hash
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        private void bRegistrarUsuario_Click(object sender, EventArgs e)
        {

            if (cbEspecialidades.SelectedIndex < 0)
            {
                //Si no hay una especialidad seleccionada, muestra un mensaje de error
                MessageBox.Show("Debe seleccionar una Especialidad.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //Detiene la ejecución del método
            }

            string nombreUsuario = tbNomUsuario.Text.Trim().ToLower();
            string apellidoUsuario = tbApellidoUsuario.Text.Trim().ToLower();
            string emailUsuario = tbEmail.Text.Trim().ToLower();
            string telefono_string = tbTelefono.Text.Trim();
            long telefono_usuario = Convert.ToInt64(telefono_string);//Este se guarad en la bd
            string password_usuario = tbPassUsuario.Text;
            string passwrod_usuario_hash = HashPassword(password_usuario);//Este se guarad en la bd
            int id_rol = rbRolCheck(sender, e);//Llamo al metodo y asigno su valor de retorno a la variable
            //string especialidad = cbEspecialidades.Text;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(apellidoUsuario) || string.IsNullOrEmpty(emailUsuario) ||
                string.IsNullOrEmpty(telefono_string) || string.IsNullOrEmpty(password_usuario))
            {
                MessageBox.Show("Debe completar todos los campos!",
                    "Error inicio de sesión", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {

            }catch(Exception ex)
            {

            }
        }

        public static void CrearUsuario()
        {

        }
    }
}
