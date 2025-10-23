namespace proyecto_Villarreal_SanLorenzo
{
    partial class HistorialClinicoControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lTituloHC = new Label();
            lSubtituloHC = new Label();
            panelFiltros = new Panel();
            tBusquedaNyA = new TextBox();
            bAgregarRegistroPaciente = new Button();
            lNyAPaciente = new Label();
            lDniPaciente = new Label();
            tBusquedaDNI = new TextBox();
            labelSubtitulo = new Label();
            lFiltros = new Label();
            panelContenedorRegistros = new FlowLayoutPanel();
            panelFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // lTituloHC
            // 
            lTituloHC.AutoSize = true;
            lTituloHC.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloHC.Location = new Point(33, 12);
            lTituloHC.Name = "lTituloHC";
            lTituloHC.Size = new Size(196, 32);
            lTituloHC.TabIndex = 2;
            lTituloHC.Text = "Historial Clinico";
            // 
            // lSubtituloHC
            // 
            lSubtituloHC.AutoSize = true;
            lSubtituloHC.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtituloHC.ForeColor = SystemColors.ControlDark;
            lSubtituloHC.Location = new Point(33, 44);
            lSubtituloHC.Name = "lSubtituloHC";
            lSubtituloHC.Size = new Size(304, 20);
            lSubtituloHC.TabIndex = 3;
            lSubtituloHC.Text = "Consulta el historial medico de los pacientes";
            // 
            // panelFiltros
            // 
            panelFiltros.BackColor = Color.White;
            panelFiltros.Controls.Add(tBusquedaNyA);
            panelFiltros.Controls.Add(bAgregarRegistroPaciente);
            panelFiltros.Controls.Add(lNyAPaciente);
            panelFiltros.Controls.Add(lDniPaciente);
            panelFiltros.Controls.Add(tBusquedaDNI);
            panelFiltros.Controls.Add(labelSubtitulo);
            panelFiltros.Controls.Add(lFiltros);
            panelFiltros.Location = new Point(33, 67);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(818, 256);
            panelFiltros.TabIndex = 4;
            // 
            // tBusquedaNyA
            // 
            tBusquedaNyA.ForeColor = Color.DarkGray;
            tBusquedaNyA.Location = new Point(15, 196);
            tBusquedaNyA.Name = "tBusquedaNyA";
            tBusquedaNyA.Size = new Size(460, 27);
            tBusquedaNyA.TabIndex = 14;
            tBusquedaNyA.Text = "Buscar por nombre y apellido";
            // 
            // bAgregarRegistroPaciente
            // 
            bAgregarRegistroPaciente.BackColor = Color.Transparent;
            bAgregarRegistroPaciente.ForeColor = Color.Black;
            bAgregarRegistroPaciente.Image = Resource1.plus_icon;
            bAgregarRegistroPaciente.Location = new Point(677, 9);
            bAgregarRegistroPaciente.Margin = new Padding(3, 4, 3, 4);
            bAgregarRegistroPaciente.Name = "bAgregarRegistroPaciente";
            bAgregarRegistroPaciente.Size = new Size(138, 48);
            bAgregarRegistroPaciente.TabIndex = 13;
            bAgregarRegistroPaciente.Text = "Agregar Registro";
            bAgregarRegistroPaciente.TextImageRelation = TextImageRelation.ImageBeforeText;
            bAgregarRegistroPaciente.UseVisualStyleBackColor = false;
            bAgregarRegistroPaciente.Click += bAgregarRegistroPaciente_Click;
            // 
            // lNyAPaciente
            // 
            lNyAPaciente.AutoSize = true;
            lNyAPaciente.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNyAPaciente.Location = new Point(15, 165);
            lNyAPaciente.Name = "lNyAPaciente";
            lNyAPaciente.Size = new Size(184, 28);
            lNyAPaciente.TabIndex = 11;
            lNyAPaciente.Text = "Nombre y Apellido";
            // 
            // lDniPaciente
            // 
            lDniPaciente.AutoSize = true;
            lDniPaciente.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lDniPaciente.Location = new Point(15, 71);
            lDniPaciente.Name = "lDniPaciente";
            lDniPaciente.Size = new Size(47, 28);
            lDniPaciente.TabIndex = 9;
            lDniPaciente.Text = "DNI";
            // 
            // tBusquedaDNI
            // 
            tBusquedaDNI.ForeColor = Color.DarkGray;
            tBusquedaDNI.Location = new Point(15, 102);
            tBusquedaDNI.Name = "tBusquedaDNI";
            tBusquedaDNI.Size = new Size(460, 27);
            tBusquedaDNI.TabIndex = 6;
            tBusquedaDNI.Text = "Buscar por DNI";
            tBusquedaDNI.KeyDown += tBusquedaDNI_KeyDown;
            tBusquedaDNI.KeyPress += tBusquedaDNI_KeyPress;
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitulo.ForeColor = Color.Black;
            labelSubtitulo.Location = new Point(15, 37);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new Size(298, 20);
            labelSubtitulo.TabIndex = 5;
            labelSubtitulo.Text = "Seleccione un paciente  para ver su historial";
            // 
            // lFiltros
            // 
            lFiltros.AutoSize = true;
            lFiltros.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lFiltros.Location = new Point(15, 9);
            lFiltros.Name = "lFiltros";
            lFiltros.Size = new Size(198, 28);
            lFiltros.TabIndex = 5;
            lFiltros.Text = "Filtros de Búsqueda";
            // 
            // panelContenedorRegistros
            // 
            panelContenedorRegistros.Anchor = AnchorStyles.None;
            panelContenedorRegistros.AutoScroll = true;
            panelContenedorRegistros.BackColor = Color.White;
            panelContenedorRegistros.FlowDirection = FlowDirection.TopDown;
            panelContenedorRegistros.Location = new Point(33, 330);
            panelContenedorRegistros.Margin = new Padding(3, 4, 3, 4);
            panelContenedorRegistros.Name = "panelContenedorRegistros";
            panelContenedorRegistros.Size = new Size(818, 275);
            panelContenedorRegistros.TabIndex = 5;
            panelContenedorRegistros.WrapContents = false;
            // 
            // HistorialClinicoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContenedorRegistros);
            Controls.Add(panelFiltros);
            Controls.Add(lSubtituloHC);
            Controls.Add(lTituloHC);
            Name = "HistorialClinicoControl";
            Size = new Size(878, 767);
            Load += HistorialClinicoControl_Load;
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lTituloHC;
        private Label lSubtituloHC;
        private Panel panelFiltros;
        private Label labelSubtitulo;
        private Label lFiltros;
        private Label lNyAPaciente;
        private Label lDniPaciente;
        private TextBox tBusquedaDNI;
        private DataGridView dgPaciente;
        private Button bAgregarRegistroPaciente;
        private FlowLayoutPanel panelContenedorRegistros;
        private TextBox tBusquedaNyA;
    }
}
