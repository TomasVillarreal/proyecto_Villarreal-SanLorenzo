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
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lSubtituloConsultas = new Label();
            lTituloConsultas = new Label();
            lTituloDashboard = new Label();
            lSubtituloDashboard = new Label();
            panelBordes1 = new PanelBordes();
            lNumeroPacientesActivos = new Label();
            lPacientesActivos = new Label();
            panelBordes2 = new PanelBordes();
            label8 = new Label();
            label7 = new Label();
            lSubtitloPacientes = new Label();
            lTituloPacientes = new Label();
            panelContenedorPacientes = new FlowLayoutPanel();
            panelBordes3 = new PanelBordes();
            pbActividadReciente.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelBordes1.SuspendLayout();
            panelBordes2.SuspendLayout();
            panelBordes3.SuspendLayout();
            SuspendLayout();
            // 
            // pbActividadReciente
            // 
            pbActividadReciente.BackColor = Color.White;
            pbActividadReciente.Controls.Add(panel1);
            pbActividadReciente.Controls.Add(lSubtituloConsultas);
            pbActividadReciente.Controls.Add(lTituloConsultas);
            pbActividadReciente.Location = new Point(20, 263);
            pbActividadReciente.Name = "pbActividadReciente";
            pbActividadReciente.Size = new Size(355, 288);
            pbActividadReciente.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(16, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 46);
            panel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(267, 10);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 8;
            label3.Text = "20/09/25";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(31, 25);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 7;
            label2.Text = "Consulta medica";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 10);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 6;
            label1.Text = "Maria Gonzalez";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Resource1.exclamation;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
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
            panelBordes2.Controls.Add(label8);
            panelBordes2.Controls.Add(label7);
            panelBordes2.Location = new Point(436, 115);
            panelBordes2.Name = "panelBordes2";
            panelBordes2.Size = new Size(312, 118);
            panelBordes2.TabIndex = 4;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(163, 50);
            label8.Name = "label8";
            label8.Size = new Size(23, 25);
            label8.TabIndex = 6;
            label8.Text = "3";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(7, 16);
            label7.Name = "label7";
            label7.Size = new Size(271, 21);
            label7.TabIndex = 1;
            label7.Text = "Promedio de registros por paciente";
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
            // panelBordes3
            // 
            panelBordes3.BackColor = Color.White;
            panelBordes3.Controls.Add(panelContenedorPacientes);
            panelBordes3.Controls.Add(lTituloPacientes);
            panelBordes3.Controls.Add(lSubtitloPacientes);
            panelBordes3.Location = new Point(397, 263);
            panelBordes3.Name = "panelBordes3";
            panelBordes3.Size = new Size(355, 288);
            panelBordes3.TabIndex = 5;
            // 
            // HomeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelBordes3);
            Controls.Add(panelBordes2);
            Controls.Add(panelBordes1);
            Controls.Add(lSubtituloDashboard);
            Controls.Add(lTituloDashboard);
            Controls.Add(pbActividadReciente);
            Name = "HomeControl";
            Load += HomeControl_Load;
            pbActividadReciente.ResumeLayout(false);
            pbActividadReciente.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelBordes1.ResumeLayout(false);
            panelBordes1.PerformLayout();
            panelBordes2.ResumeLayout(false);
            panelBordes2.PerformLayout();
            panelBordes3.ResumeLayout(false);
            panelBordes3.PerformLayout();
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
        private Label label1;
        private Label lSubtituloConsultas;
        private Label lTituloConsultas;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private Label lSubtitloPacientes;
        private Label lTituloPacientes;
        private Label label7;
        private Label label8;
        private FlowLayoutPanel panelContenedorPacientes;
        private PanelBordes panelBordes3;
    }
}
