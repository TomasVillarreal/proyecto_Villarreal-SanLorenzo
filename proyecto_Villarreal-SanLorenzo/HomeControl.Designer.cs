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
            panelBordes3 = new PanelBordes();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lSubtituloActividad = new Label();
            lTituloActividad = new Label();
            lTituloDashboard = new Label();
            lSubtituloDashboard = new Label();
            panelBordes1 = new PanelBordes();
            lNumeroPacientesActivos = new Label();
            lPacientesActivos = new Label();
            panelBordes2 = new PanelBordes();
            label2 = new Label();
            pbActividadReciente.SuspendLayout();
            panelBordes3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelBordes1.SuspendLayout();
            SuspendLayout();
            // 
            // pbActividadReciente
            // 
            pbActividadReciente.BackColor = Color.White;
            pbActividadReciente.Controls.Add(panelBordes3);
            pbActividadReciente.Controls.Add(lSubtituloActividad);
            pbActividadReciente.Controls.Add(lTituloActividad);
            pbActividadReciente.Location = new Point(20, 263);
            pbActividadReciente.Name = "pbActividadReciente";
            pbActividadReciente.Size = new Size(355, 288);
            pbActividadReciente.TabIndex = 0;
            // 
            // panelBordes3
            // 
            panelBordes3.BackColor = Color.White;
            panelBordes3.Controls.Add(label2);
            panelBordes3.Controls.Add(label1);
            panelBordes3.Controls.Add(pictureBox1);
            panelBordes3.Location = new Point(21, 67);
            panelBordes3.Name = "panelBordes3";
            panelBordes3.Size = new Size(316, 40);
            panelBordes3.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 5);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 5;
            label1.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Resource1.circulo_plus;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lSubtituloActividad
            // 
            lSubtituloActividad.AutoSize = true;
            lSubtituloActividad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtituloActividad.ForeColor = SystemColors.ControlDark;
            lSubtituloActividad.Location = new Point(16, 38);
            lSubtituloActividad.Name = "lSubtituloActividad";
            lSubtituloActividad.Size = new Size(167, 15);
            lSubtituloActividad.TabIndex = 1;
            lSubtituloActividad.Text = "Ultimas acciones en el sistema";
            // 
            // lTituloActividad
            // 
            lTituloActividad.AutoSize = true;
            lTituloActividad.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloActividad.Location = new Point(16, 13);
            lTituloActividad.Name = "lTituloActividad";
            lTituloActividad.Size = new Size(175, 25);
            lTituloActividad.TabIndex = 0;
            lTituloActividad.Text = "Actividad Reciente";
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
            panelBordes2.Location = new Point(436, 115);
            panelBordes2.Name = "panelBordes2";
            panelBordes2.Size = new Size(312, 118);
            panelBordes2.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDark;
            label2.Location = new Point(34, 20);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 6;
            label2.Text = "label2";
            // 
            // HomeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelBordes2);
            Controls.Add(panelBordes1);
            Controls.Add(lSubtituloDashboard);
            Controls.Add(lTituloDashboard);
            Controls.Add(pbActividadReciente);
            Name = "HomeControl";
            Load += HomeControl_Load;
            pbActividadReciente.ResumeLayout(false);
            pbActividadReciente.PerformLayout();
            panelBordes3.ResumeLayout(false);
            panelBordes3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelBordes1.ResumeLayout(false);
            panelBordes1.PerformLayout();
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
        private PanelBordes panelBordes3;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
    }
}
