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
    public partial class Form_nuevo_usuario : Form
    {
        public Form_nuevo_usuario()
        {
            InitializeComponent();
        }

        private void botonSidebar2_Click(object sender, EventArgs e)
        {
            Form_nuevo_usuario formularioUsuarios = new Form_nuevo_usuario();
            formularioUsuarios.Show();
            this.Close();
        }
    }
}
