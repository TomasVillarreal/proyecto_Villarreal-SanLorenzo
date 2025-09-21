using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proyecto_Villarreal_SanLorenzo
{
    public partial class BackupControl : UserControlProyecto
    {
        // Atributo que nos permitira acceder al temporizador generado en el form principal
        private FormHome FormPadre { get; set; }

        public BackupControl()
        {
            InitializeComponent();
        }

        /*
         * Cuando se cargue el control, se coloca la visibilidad del boton que nos
         * permite parar el timer en base a si el timer del form padre esta marchando o no.
         */
        private void BackupControl_Load(object sender, EventArgs e)
        {
            // Si el atributo padre existe, entonces:
            if(FormPadre != null)
            {
                // La visibilidad del boton es hecha en base al bool que retorna la funcion
                // de marcha timer del form padre
                bPararIntevaloBackup.Visible = FormPadre?.MarchaTimer() ?? false;
            }
        }

        // Setter publico que nos permite cambiar el atributo form padre de este usercontrol
        public void EstablecerFormPadre (FormHome form)
        {
            FormPadre = form;
        }

        // Si se aprieta el boton para seleccionar la ruta, hacemos esto:
        private void bRutaBackup_Click(object sender, EventArgs e)
        {
            // cambiamos la descripcion del file browser dialog.
            fbgBusquedaCarpetaBackups.Description = "Selecciona la carpeta donde guardaras los backups de la base de datos";
            // Si se aprieta el boton de ok del dialogo, y se selecciono efectivamente una carpeta:
            if (fbgBusquedaCarpetaBackups.ShowDialog() == DialogResult.OK &&
            !string.IsNullOrWhiteSpace(fbgBusquedaCarpetaBackups.SelectedPath))
            {
                // Cambiamos el texto del textbox de la ruta.
                string rutaCarpeta = fbgBusquedaCarpetaBackups.SelectedPath;
                tRutaBackup.Text = rutaCarpeta;
            }

        }

        // Limitamos lo que se puede escribir el usuario en el temporizador a solo digitos
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Funcion que hace visible un panel en base a si el usuario eligio Si o No en el combobox.
        private void cbDecisionBackup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDecisionBackup.SelectedItem.ToString() == "No")
            {
                pBackupOcultar.Visible = false;
                bPararIntevaloBackup.Visible = false;
            }
            else
            {
                pBackupOcultar.Visible = true;
            }
        }

        // Funcion que calcula y devuelve el tiempo pasado como argumento a segundos
        private int CalculoMiliegundos(string total)
        {
            // Si no se selecciono un tiempo valido en el combobox, mostramos msj de error.
            if (cbSeleccionTiempo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una unidad de tiempo valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Calculamos el tiempo y lo devolvemos.
            switch (cbSeleccionTiempo.SelectedItem.ToString())
            {
                case "Minutos":
                    return int.Parse(total) * 60 * 1000;

                case "Horas":
                    return int.Parse(total) * 60 * 60 * 1000;

                case "Dias":
                    return int.Parse(total) * 24 * 60 * 60 * 1000;

                default:
                    return 0;
            }
        }


        // Funcion que activa al apretar el boton de realizar backup
        private void bRealizarBackup_Click(object sender, EventArgs e)
        {
            // Si no se selecciono una decision en el combobox, mostramos mensaj de error
            if (cbDecisionBackup.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una opcion antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Si se selecciono la opcion de "No", solo realizamos el backup
            else if (cbDecisionBackup.SelectedItem.ToString() == "No")
            {
                FormPadre?.RealizarBackup(tRutaBackup.Text);
            }
            // Si se selecciono otra opcion (osea si), entonces:
            else
            {
                // realizamos un backup, iniciamos el timer, y hacemos visible el boton de parar el timer.
                FormPadre?.RealizarBackup(tRutaBackup.Text);
                FormPadre?.IniciarTimerBackup(CalculoMiliegundos(tTiempoTimer.Text), tRutaBackup.Text);
                bPararIntevaloBackup.Visible = true;
                MessageBox.Show("Se ha comenzado a realizar backups de forma periodica!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Funcion que para el timer si se aprieta el boton correspondiente.
        private void bPararIntevaloBackup_Click(object sender, EventArgs e)
        {
            FormPadre?.PararTimer();
            MessageBox.Show("Se detuvo la creacion de backups!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bPararIntevaloBackup.Visible=false;
        }
        
    }
}
