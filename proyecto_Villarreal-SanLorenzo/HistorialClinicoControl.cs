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
    public partial class HistorialClinicoControl : UserControlProyecto
    {
        public event EventHandler<AbrirEdicionEventArgs> AbrirOtroControl;
        public HistorialClinicoControl()
        {
            InitializeComponent();
        }
    }
}
