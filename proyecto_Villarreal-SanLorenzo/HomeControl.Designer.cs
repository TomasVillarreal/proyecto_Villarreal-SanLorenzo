namespace proyecto_Villarreal_SanLorenzo
{
    partial class HomeControl
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
            pbActividadReciente = new PanelBordes();
            panelContenedorRegistros = new FlowLayoutPanel();
            lSubtituloConsultas = new Label();
            lTituloConsultas = new Label();
            lTituloDashboard = new Label();
            lSubtituloDashboard = new Label();
            panelBordes1 = new PanelBordes();
            lNumeroPacientesActivos = new Label();
            lPacientesActivos = new Label();
            panelBordes2 = new PanelBordes();
            lNroPromedioRegistros = new Label();
            lPromedioRegistros = new Label();
            lSubtitloPacientes = new Label();
            lTituloPacientes = new Label();
            panelContenedorPacientes = new FlowLayoutPanel();
            pbPacientesRecientes = new PanelBordes();
            pbActividadReciente.SuspendLayout();
            panelBordes1.SuspendLayout();
            panelBordes2.SuspendLayout();
            pbPacientesRecientes.SuspendLayout();
            SuspendLayout();
            // 
            // pbActividadReciente
            // 
            pbActividadReciente.BackColor = Color.White;
            pbActividadReciente.Controls.Add(panelContenedorRegistros);
            pbActividadReciente.Controls.Add(lSubtituloConsultas);
            pbActividadReciente.Controls.Add(lTituloConsultas);
            pbActividadReciente.Location = new Point(20, 263);
            pbActividadReciente.Name = "pbActividadReciente";
            pbActividadReciente.Size = new Size(355, 288);
            pbActividadReciente.TabIndex = 0;
            // 
            // panelContenedorRegistros
            // 
            panelContenedorRegistros.Anchor = AnchorStyles.None;
            panelContenedorRegistros.AutoScroll = true;
            panelContenedorRegistros.BackColor = Color.White;
            panelContenedorRegistros.FlowDirection = FlowDirection.TopDown;
            panelContenedorRegistros.Location = new Point(16, 65);
            panelContenedorRegistros.Name = "panelContenedorRegistros";
            panelContenedorRegistros.Size = new Size(327, 206);
            panelContenedorRegistros.TabIndex = 4;
            panelContenedorRegistros.WrapContents = false;
            // 
            // lSubtituloConsultas
            // 
            lSubtituloConsultas.AutoSize = true;
            lSubtituloConsultas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtituloConsultas.ForeColor = SystemColors.ControlDark;
            lSubtituloConsultas.Location = new Point(16, 38);
            lSubtituloConsultas.Name = "lSubtituloConsultas";
            lSubtituloConsultas.Size = new Size(167, 15);
            lSubtituloConsultas.TabIndex = 1;
            lSubtituloConsultas.Text = "Ultimas acciones en el sistema";
            // 
            // lTituloConsultas
            // 
            lTituloConsultas.AutoSize = true;
            lTituloConsultas.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloConsultas.Location = new Point(16, 13);
            lTituloConsultas.Name = "lTituloConsultas";
            lTituloConsultas.Size = new Size(186, 25);
            lTituloConsultas.TabIndex = 0;
            lTituloConsultas.Text = "Consultas Recientes";
            // 
            // lTituloDashboard
            // 
            lTituloDashboard.AutoSize = true;
            lTituloDashboard.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloDashboard.Location = new Point(20, 48);
            lTituloDashboard.Name = "lTituloDashboard";
            lTituloDashboard.Size = new Size(109, 25);
            lTituloDashboard.TabIndex = 1;
            lTituloDashboard.Text = "Dashboard";
            // 
            // lSubtituloDashboard
            // 
            lSubtituloDashboard.AutoSize = true;
            lSubtituloDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtituloDashboard.ForeColor = SystemColors.ControlDark;
            lSubtituloDashboard.Location = new Point(20, 73);
            lSubtituloDashboard.Name = "lSubtituloDashboard";
            lSubtituloDashboard.Size = new Size(160, 15);
            lSubtituloDashboard.TabIndex = 2;
            lSubtituloDashboard.Text = "Resumen general del sistema";
            // 
            // panelBordes1
            // 
            panelBordes1.BackColor = Color.White;
            panelBordes1.Controls.Add(lNumeroPacientesActivos);
            panelBordes1.Controls.Add(lPacientesActivos);
            panelBordes1.Location = new Point(20, 115);
            panelBordes1.Name = "panelBordes1";
            panelBordes1.Size = new Size(312, 118);
            panelBordes1.TabIndex = 3;
            // 
            // lNumeroPacientesActivos
            // 
            lNumeroPacientesActivos.Anchor = AnchorStyles.None;
            lNumeroPacientesActivos.AutoSize = true;
            lNumeroPacientesActivos.BackColor = Color.White;
            lNumeroPacientesActivos.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNumeroPacientesActivos.Location = new Point(146, 50);
            lNumeroPacientesActivos.Name = "lNumeroPacientesActivos";
            lNumeroPacientesActivos.Size = new Size(23, 25);
            lNumeroPacientesActivos.TabIndex = 5;
            lNumeroPacientesActivos.Text = "0";
            lNumeroPacientesActivos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lPacientesActivos
            // 
            lPacientesActivos.AutoSize = true;
            lPacientesActivos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lPacientesActivos.Location = new Point(34, 16);
            lPacientesActivos.Name = "lPacientesActivos";
            lPacientesActivos.Size = new Size(235, 21);
            lPacientesActivos.TabIndex = 0;
            lPacientesActivos.Text = "Pacientes activos en el hospital";
            // 
            // panelBordes2
            // 
            panelBordes2.BackColor = Color.White;
            panelBordes2.Controls.Add(lNroPromedioRegistros);
            panelBordes2.Controls.Add(lPromedioRegistros);
            panelBordes2.Location = new Point(436, 115);
            panelBordes2.Name = "panelBordes2";
            panelBordes2.Size = new Size(312, 118);
            panelBordes2.TabIndex = 4;
            // 
            // lNroPromedioRegistros
            // 
            lNroPromedioRegistros.Anchor = AnchorStyles.None;
            lNroPromedioRegistros.AutoSize = true;
            lNroPromedioRegistros.BackColor = Color.White;
            lNroPromedioRegistros.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNroPromedioRegistros.Location = new Point(140, 50);
            lNroPromedioRegistros.Name = "lNroPromedioRegistros";
            lNroPromedioRegistros.Size = new Size(23, 25);
            lNroPromedioRegistros.TabIndex = 6;
            lNroPromedioRegistros.Text = "0";
            lNroPromedioRegistros.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lPromedioRegistros
            // 
            lPromedioRegistros.AutoSize = true;
            lPromedioRegistros.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lPromedioRegistros.Location = new Point(21, 16);
            lPromedioRegistros.Name = "lPromedioRegistros";
            lPromedioRegistros.Size = new Size(271, 21);
            lPromedioRegistros.TabIndex = 1;
            lPromedioRegistros.Text = "Promedio de registros por paciente";
            // 
            // lSubtitloPacientes
            // 
            lSubtitloPacientes.Anchor = AnchorStyles.None;
            lSubtitloPacientes.AutoSize = true;
            lSubtitloPacientes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtitloPacientes.ForeColor = SystemColors.ControlDark;
            lSubtitloPacientes.Location = new Point(16, 38);
            lSubtitloPacientes.Name = "lSubtitloPacientes";
            lSubtitloPacientes.Size = new Size(227, 15);
            lSubtitloPacientes.TabIndex = 1;
            lSubtitloPacientes.Text = "Pacientes registrados en la ultima semana";
            // 
            // lTituloPacientes
            // 
            lTituloPacientes.Anchor = AnchorStyles.None;
            lTituloPacientes.AutoSize = true;
            lTituloPacientes.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloPacientes.Location = new Point(15, 13);
            lTituloPacientes.Name = "lTituloPacientes";
            lTituloPacientes.Size = new Size(302, 25);
            lTituloPacientes.TabIndex = 0;
            lTituloPacientes.Text = "Pacientes Registrados Hace Poco";
            // 
            // panelContenedorPacientes
            // 
            panelContenedorPacientes.Anchor = AnchorStyles.None;
            panelContenedorPacientes.AutoScroll = true;
            panelContenedorPacientes.BackColor = Color.White;
            panelContenedorPacientes.FlowDirection = FlowDirection.TopDown;
            panelContenedorPacientes.Location = new Point(15, 65);
            panelContenedorPacientes.Name = "panelContenedorPacientes";
            panelContenedorPacientes.Size = new Size(327, 206);
            panelContenedorPacientes.TabIndex = 3;
            panelContenedorPacientes.WrapContents = false;
            // 
            // pbPacientesRecientes
            // 
            pbPacientesRecientes.BackColor = Color.White;
            pbPacientesRecientes.Controls.Add(panelContenedorPacientes);
            pbPacientesRecientes.Controls.Add(lTituloPacientes);
            pbPacientesRecientes.Controls.Add(lSubtitloPacientes);
            pbPacientesRecientes.Location = new Point(397, 263);
            pbPacientesRecientes.Name = "pbPacientesRecientes";
            pbPacientesRecientes.Size = new Size(355, 288);
            pbPacientesRecientes.TabIndex = 5;
            // 
            // HomeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbPacientesRecientes);
            Controls.Add(panelBordes2);
            Controls.Add(panelBordes1);
            Controls.Add(lSubtituloDashboard);
            Controls.Add(lTituloDashboard);
            Controls.Add(pbActividadReciente);
            Name = "HomeControl";
            Load += HomeControl_Load;
            pbActividadReciente.ResumeLayout(false);
            pbActividadReciente.PerformLayout();
            panelBordes1.ResumeLayout(false);
            panelBordes1.PerformLayout();
            panelBordes2.ResumeLayout(false);
            panelBordes2.PerformLayout();
            pbPacientesRecientes.ResumeLayout(false);
            pbPacientesRecientes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PanelBordes pbActividadReciente;
        private Label lTituloActividad;
        private Label lSubtituloActividad;
        private Label lTituloDashboard;
        private Label lSubtituloDashboard;
        private PanelBordes panelBordes1;
        private PanelBordes panelBordes2;
        private Label lNumeroPacientesActivos;
        private Label lPacientesActivos;
        private Label lSubtituloConsultas;
        private Label lTituloConsultas;
        private Label lSubtitloPacientes;
        private Label lTituloPacientes;
        private Label lPromedioRegistros;
        private Label lNroPromedioRegistros;
        private FlowLayoutPanel panelContenedorPacientes;
        private PanelBordes pbPacientesRecientes;
        private FlowLayoutPanel panelContenedorRegistros;
    }
}
