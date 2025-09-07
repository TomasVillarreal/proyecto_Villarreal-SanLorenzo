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
        private Form1 FormPadre { get; set; }

        public BackupControl()
        {
            InitializeComponent();
        }

        private void BackupControl_Load(object sender, EventArgs e)
        {
            if(FormPadre != null)
            {
                bPararIntevaloBackup.Visible = FormPadre?.MarchaTimer() ?? false;
            }
        }

        public void EstablecerFormPadre (Form1 form)
        {
            FormPadre = form;
        }

        private void bRutaBackup_Click(object sender, EventArgs e)
        {
            fbgBusquedaCarpetaBackups.Description = "Selecciona la carpeta donde guardaras los backups de la base de datos";
            if (fbgBusquedaCarpetaBackups.ShowDialog() == DialogResult.OK &&
            !string.IsNullOrWhiteSpace(fbgBusquedaCarpetaBackups.SelectedPath))
            {
                string rutaCarpeta = fbgBusquedaCarpetaBackups.SelectedPath;
                tRutaBackup.Text = rutaCarpeta;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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

        private int CalculoMiliegundos(string total)
        {
            if (cbSeleccionTiempo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una unidad de tiempo valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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

        private void bRealizarBackup_Click(object sender, EventArgs e)
        {
            if (cbDecisionBackup.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una opcion antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbDecisionBackup.SelectedItem.ToString() == "No")
            {
                FormPadre?.RealizarBackup(tRutaBackup.Text);
            }
            else
            {
                FormPadre?.RealizarBackup(tRutaBackup.Text);
                FormPadre?.IniciarTimerBackup(CalculoMiliegundos(tTiempoTimer.Text), tRutaBackup.Text);
                bPararIntevaloBackup.Visible = true;
                MessageBox.Show("Se ha comenzado a realizar backups de forma periodica!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bPararIntevaloBackup_Click(object sender, EventArgs e)
        {
            FormPadre?.PararTimer();
            MessageBox.Show("Se detuvo la creacion de backups!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bPararIntevaloBackup.Visible=false;
        }

        
    }
}
