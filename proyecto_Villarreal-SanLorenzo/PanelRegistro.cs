using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Villarreal_SanLorenzo
{
    public class PanelRegistro : Panel
    {
        public  PanelRegistro()
        {
            CargarComponentes();
        }

        public void CargarComponentes()
        {
            // crear el botón
            Button boton = new Button();
            boton.Text = "Registrar Paciente";
            boton.Size = new Size(150, 40);
            boton.Location = new Point(20, 20);

            // suscribir el evento click
            boton.Click += bboton_Click;

            // agregar el botón al panel (asegúrate de tener un contenedor visual)
            // si PanelRegistro hereda de Panel o UserControl:
            this.Controls.Add(boton);
        }

        private void bboton_Click (object sender, EventArgs e) //Aregar Funcionalidad
        {
            AgregarRegistroControl agregarRegistro = new AgregarRegistroControl(12345678);

            agregarRegistro.AbrirOtroControl += this.AbrirOtroControl;

            AbrirOtroControl?.Invoke(this, new AbrirEdicionEventArgs(null, agregarRegistro, false));

        }

        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;


    }
}
