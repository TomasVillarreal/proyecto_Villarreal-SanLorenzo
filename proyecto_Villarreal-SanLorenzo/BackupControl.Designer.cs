namespace proyecto_Villarreal_SanLorenzo
{
    partial class BackupControl
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
            lTituloBackup = new Label();
            panelBordes1 = new PanelBordes();
            bPararIntevaloBackup = new Button();
            pBackupOcultar = new Panel();
            cbSeleccionTiempo = new ComboBox();
            tTiempoTimer = new TextBox();
            lBackup3 = new Label();
            lBackup2 = new Label();
            cbDecisionBackup = new ComboBox();
            bRealizarBackup = new Button();
            tRutaBackup = new TextBox();
            bRutaBackup = new Button();
            lBackup1 = new Label();
            lSubtituloBackup = new Label();
            fbgBusquedaCarpetaBackups = new FolderBrowserDialog();
            panelBordes1.SuspendLayout();
            pBackupOcultar.SuspendLayout();
            SuspendLayout();
            // 
            // lTituloBackup
            // 
            lTituloBackup.AutoSize = true;
            lTituloBackup.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloBackup.Location = new Point(23, 42);
            lTituloBackup.Name = "lTituloBackup";
            lTituloBackup.Size = new Size(152, 25);
            lTituloBackup.TabIndex = 0;
            lTituloBackup.Text = "Realizar Backup";
            // 
            // panelBordes1
            // 
            panelBordes1.BackColor = Color.White;
            panelBordes1.Controls.Add(bPararIntevaloBackup);
            panelBordes1.Controls.Add(pBackupOcultar);
            panelBordes1.Controls.Add(lBackup2);
            panelBordes1.Controls.Add(cbDecisionBackup);
            panelBordes1.Controls.Add(bRealizarBackup);
            panelBordes1.Controls.Add(tRutaBackup);
            panelBordes1.Controls.Add(bRutaBackup);
            panelBordes1.Controls.Add(lBackup1);
            panelBordes1.Location = new Point(23, 156);
            panelBordes1.Name = "panelBordes1";
            panelBordes1.Size = new Size(724, 399);
            panelBordes1.TabIndex = 1;
            // 
            // bPararIntevaloBackup
            // 
            bPararIntevaloBackup.BackColor = Color.Black;
            bPararIntevaloBackup.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bPararIntevaloBackup.ForeColor = Color.White;
            bPararIntevaloBackup.Location = new Point(548, 350);
            bPararIntevaloBackup.Name = "bPararIntevaloBackup";
            bPararIntevaloBackup.Size = new Size(156, 34);
            bPararIntevaloBackup.TabIndex = 9;
            bPararIntevaloBackup.Text = "Parar intervalo del backup";
            bPararIntevaloBackup.UseVisualStyleBackColor = false;
            bPararIntevaloBackup.Visible = false;
            bPararIntevaloBackup.Click += bPararIntevaloBackup_Click;
            // 
            // pBackupOcultar
            // 
            pBackupOcultar.Controls.Add(cbSeleccionTiempo);
            pBackupOcultar.Controls.Add(tTiempoTimer);
            pBackupOcultar.Controls.Add(lBackup3);
            pBackupOcultar.Location = new Point(3, 146);
            pBackupOcultar.Name = "pBackupOcultar";
            pBackupOcultar.Size = new Size(701, 181);
            pBackupOcultar.TabIndex = 8;
            pBackupOcultar.Visible = false;
            // 
            // cbSeleccionTiempo
            // 
            cbSeleccionTiempo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSeleccionTiempo.FormattingEnabled = true;
            cbSeleccionTiempo.Items.AddRange(new object[] { "Minutos", "Horas", "Dias" });
            cbSeleccionTiempo.Location = new Point(172, 34);
            cbSeleccionTiempo.Name = "cbSeleccionTiempo";
            cbSeleccionTiempo.Size = new Size(121, 23);
            cbSeleccionTiempo.TabIndex = 10;
            // 
            // tTiempoTimer
            // 
            tTiempoTimer.Location = new Point(19, 34);
            tTiempoTimer.Name = "tTiempoTimer";
            tTiempoTimer.Size = new Size(121, 23);
            tTiempoTimer.TabIndex = 9;
            tTiempoTimer.KeyPress += textBox1_KeyPress;
            // 
            // lBackup3
            // 
            lBackup3.AutoSize = true;
            lBackup3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lBackup3.Location = new Point(19, 10);
            lBackup3.Name = "lBackup3";
            lBackup3.Size = new Size(447, 21);
            lBackup3.TabIndex = 8;
            lBackup3.Text = "¿Cada cuanto desea realizar el backup de forma automatica?";
            // 
            // lBackup2
            // 
            lBackup2.AutoSize = true;
            lBackup2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lBackup2.Location = new Point(22, 93);
            lBackup2.Name = "lBackup2";
            lBackup2.Size = new Size(467, 21);
            lBackup2.TabIndex = 7;
            lBackup2.Text = "¿Desea realizar usted backup de forma periodica y automatica?";
            // 
            // cbDecisionBackup
            // 
            cbDecisionBackup.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDecisionBackup.FormattingEnabled = true;
            cbDecisionBackup.Items.AddRange(new object[] { "Si", "No" });
            cbDecisionBackup.Location = new Point(22, 117);
            cbDecisionBackup.Name = "cbDecisionBackup";
            cbDecisionBackup.Size = new Size(121, 23);
            cbDecisionBackup.TabIndex = 6;
            cbDecisionBackup.SelectedIndexChanged += cbDecisionBackup_SelectedIndexChanged;
            // 
            // bRealizarBackup
            // 
            bRealizarBackup.BackColor = Color.Black;
            bRealizarBackup.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bRealizarBackup.ForeColor = Color.White;
            bRealizarBackup.Location = new Point(266, 350);
            bRealizarBackup.Name = "bRealizarBackup";
            bRealizarBackup.Size = new Size(144, 34);
            bRealizarBackup.TabIndex = 5;
            bRealizarBackup.Text = "Realizar Backup";
            bRealizarBackup.UseVisualStyleBackColor = false;
            bRealizarBackup.Click += bRealizarBackup_Click;
            // 
            // tRutaBackup
            // 
            tRutaBackup.BackColor = Color.White;
            tRutaBackup.Location = new Point(122, 56);
            tRutaBackup.Name = "tRutaBackup";
            tRutaBackup.ReadOnly = true;
            tRutaBackup.Size = new Size(582, 23);
            tRutaBackup.TabIndex = 4;
            // 
            // bRutaBackup
            // 
            bRutaBackup.Location = new Point(22, 56);
            bRutaBackup.Name = "bRutaBackup";
            bRutaBackup.Size = new Size(75, 23);
            bRutaBackup.TabIndex = 3;
            bRutaBackup.Text = "Ruta";
            bRutaBackup.UseVisualStyleBackColor = true;
            bRutaBackup.Click += bRutaBackup_Click;
            // 
            // lBackup1
            // 
            lBackup1.AutoSize = true;
            lBackup1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lBackup1.Location = new Point(22, 23);
            lBackup1.Name = "lBackup1";
            lBackup1.Size = new Size(388, 21);
            lBackup1.TabIndex = 0;
            lBackup1.Text = "Seleccione el lugar donde desea realizar los backup ";
            // 
            // lSubtituloBackup
            // 
            lSubtituloBackup.AutoSize = true;
            lSubtituloBackup.ForeColor = SystemColors.ControlDark;
            lSubtituloBackup.Location = new Point(23, 67);
            lSubtituloBackup.Name = "lSubtituloBackup";
            lSubtituloBackup.Size = new Size(318, 15);
            lSubtituloBackup.TabIndex = 2;
            lSubtituloBackup.Text = "Realizar backup de la base de datos de forma automatizada";
            // 
            // BackupControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lSubtituloBackup);
            Controls.Add(panelBordes1);
            Controls.Add(lTituloBackup);
            Name = "BackupControl";
            Load += BackupControl_Load;
            panelBordes1.ResumeLayout(false);
            panelBordes1.PerformLayout();
            pBackupOcultar.ResumeLayout(false);
            pBackupOcultar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lTituloBackup;
        private PanelBordes panelBordes1;
        private Label lBackup1;
        private Label lSubtituloBackup;
        private Button bRutaBackup;
        private TextBox tRutaBackup;
        private Button bRealizarBackup;
        private ComboBox cbDecisionBackup;
        private Label lBackup2;
        private Panel pBackupOcultar;
        private ComboBox cbSeleccionTiempo;
        private TextBox tTiempoTimer;
        private Label lBackup3;
        private Button bPararIntevaloBackup;
        private FolderBrowserDialog fbgBusquedaCarpetaBackups;
    }
}
