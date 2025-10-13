namespace proyecto_Villarreal_SanLorenzo
{
    partial class InformeControl
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
            lSubtituloDashboard = new Label();
            lTituloDashboard = new Label();
            lSeleccion = new Label();
            cbDecisionIntervalo = new ComboBox();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            label12 = new Label();
            label11 = new Label();
            panelSeleccionIntervalo = new Panel();
            panelBordes1 = new PanelBordes();
            lFecha = new Label();
            lMedicoActivo = new Label();
            lPromedioRegistros = new Label();
            lTotalRegistros = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            bActualizarGrafico = new Button();
            panelGrafico = new PanelBordes();
            rbFechas = new RadioButton();
            rbMedicos = new RadioButton();
            panelSeleccionIntervalo.SuspendLayout();
            panelBordes1.SuspendLayout();
            SuspendLayout();
            // 
            // lSubtituloDashboard
            // 
            lSubtituloDashboard.AutoSize = true;
            lSubtituloDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtituloDashboard.ForeColor = SystemColors.ControlDark;
            lSubtituloDashboard.Location = new Point(42, 58);
            lSubtituloDashboard.Name = "lSubtituloDashboard";
            lSubtituloDashboard.Size = new Size(187, 15);
            lSubtituloDashboard.TabIndex = 7;
            lSubtituloDashboard.Text = "Consulte el informe de un medico";
            // 
            // lTituloDashboard
            // 
            lTituloDashboard.AutoSize = true;
            lTituloDashboard.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloDashboard.Location = new Point(42, 33);
            lTituloDashboard.Name = "lTituloDashboard";
            lTituloDashboard.Size = new Size(92, 25);
            lTituloDashboard.TabIndex = 6;
            lTituloDashboard.Text = "Informes";
            // 
            // lSeleccion
            // 
            lSeleccion.AutoSize = true;
            lSeleccion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSeleccion.ForeColor = SystemColors.ControlDark;
            lSeleccion.Location = new Point(302, 41);
            lSeleccion.Name = "lSeleccion";
            lSeleccion.Size = new Size(181, 15);
            lSeleccion.TabIndex = 9;
            lSeleccion.Text = "Seleccione el intervalo de tiempo";
            // 
            // cbDecisionIntervalo
            // 
            cbDecisionIntervalo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDecisionIntervalo.FormattingEnabled = true;
            cbDecisionIntervalo.Items.AddRange(new object[] { "Todos los tiempos", "Ultima semana", "Ultimo mes", "Ultimo año", "Personalizado" });
            cbDecisionIntervalo.Location = new Point(302, 59);
            cbDecisionIntervalo.Name = "cbDecisionIntervalo";
            cbDecisionIntervalo.Size = new Size(121, 23);
            cbDecisionIntervalo.TabIndex = 10;
            cbDecisionIntervalo.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(107, 18);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(81, 23);
            dtpFechaFin.TabIndex = 13;
            dtpFechaFin.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpFechaFin.Leave += dtpFechaFin_Leave;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(3, 18);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(81, 23);
            dtpFechaInicio.TabIndex = 12;
            dtpFechaInicio.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpFechaInicio.Leave += dtpFechaInicio_Leave;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ControlDark;
            label12.Location = new Point(107, 0);
            label12.Name = "label12";
            label12.Size = new Size(64, 15);
            label12.TabIndex = 11;
            label12.Text = "Fecha final";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ControlDark;
            label11.Location = new Point(3, 0);
            label11.Name = "label11";
            label11.Size = new Size(72, 15);
            label11.TabIndex = 10;
            label11.Text = "Fecha inicial";
            // 
            // panelSeleccionIntervalo
            // 
            panelSeleccionIntervalo.Controls.Add(label11);
            panelSeleccionIntervalo.Controls.Add(dtpFechaFin);
            panelSeleccionIntervalo.Controls.Add(label12);
            panelSeleccionIntervalo.Controls.Add(dtpFechaInicio);
            panelSeleccionIntervalo.Location = new Point(495, 41);
            panelSeleccionIntervalo.Name = "panelSeleccionIntervalo";
            panelSeleccionIntervalo.Size = new Size(227, 43);
            panelSeleccionIntervalo.TabIndex = 14;
            panelSeleccionIntervalo.Visible = false;
            // 
            // panelBordes1
            // 
            panelBordes1.BackColor = Color.White;
            panelBordes1.Controls.Add(lFecha);
            panelBordes1.Controls.Add(lMedicoActivo);
            panelBordes1.Controls.Add(lPromedioRegistros);
            panelBordes1.Controls.Add(lTotalRegistros);
            panelBordes1.Controls.Add(label4);
            panelBordes1.Controls.Add(label3);
            panelBordes1.Controls.Add(label2);
            panelBordes1.Controls.Add(label1);
            panelBordes1.Location = new Point(42, 407);
            panelBordes1.Name = "panelBordes1";
            panelBordes1.Size = new Size(680, 130);
            panelBordes1.TabIndex = 15;
            // 
            // lFecha
            // 
            lFecha.AutoSize = true;
            lFecha.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold);
            lFecha.Location = new Point(527, 89);
            lFecha.Name = "lFecha";
            lFecha.Size = new Size(78, 17);
            lFecha.TabIndex = 7;
            lFecha.Text = "01/01/1900";
            // 
            // lMedicoActivo
            // 
            lMedicoActivo.AutoSize = true;
            lMedicoActivo.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold);
            lMedicoActivo.Location = new Point(508, 41);
            lMedicoActivo.Name = "lMedicoActivo";
            lMedicoActivo.Size = new Size(46, 17);
            lMedicoActivo.TabIndex = 6;
            lMedicoActivo.Text = "label5";
            // 
            // lPromedioRegistros
            // 
            lPromedioRegistros.AutoSize = true;
            lPromedioRegistros.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold);
            lPromedioRegistros.Location = new Point(70, 89);
            lPromedioRegistros.Name = "lPromedioRegistros";
            lPromedioRegistros.Size = new Size(46, 17);
            lPromedioRegistros.TabIndex = 5;
            lPromedioRegistros.Text = "label5";
            // 
            // lTotalRegistros
            // 
            lTotalRegistros.AutoSize = true;
            lTotalRegistros.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold);
            lTotalRegistros.Location = new Point(79, 41);
            lTotalRegistros.Name = "lTotalRegistros";
            lTotalRegistros.Size = new Size(22, 17);
            lTotalRegistros.TabIndex = 4;
            lTotalRegistros.Text = "10";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 68);
            label4.Name = "label4";
            label4.Size = new Size(230, 21);
            label4.TabIndex = 3;
            label4.Text = "Promedio de registros por dia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(488, 68);
            label3.Name = "label3";
            label3.Size = new Size(167, 21);
            label3.TabIndex = 2;
            label3.Text = "Día con más actividad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(508, 20);
            label2.Name = "label2";
            label2.Size = new Size(147, 21);
            label2.TabIndex = 1;
            label2.Text = "Medico más activo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 20);
            label1.Name = "label1";
            label1.Size = new Size(137, 21);
            label1.TabIndex = 0;
            label1.Text = "Total de registros";
            // 
            // bActualizarGrafico
            // 
            bActualizarGrafico.BackColor = Color.Black;
            bActualizarGrafico.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bActualizarGrafico.ForeColor = Color.White;
            bActualizarGrafico.Location = new Point(302, 88);
            bActualizarGrafico.Name = "bActualizarGrafico";
            bActualizarGrafico.Size = new Size(78, 34);
            bActualizarGrafico.TabIndex = 17;
            bActualizarGrafico.Text = "Actualizar";
            bActualizarGrafico.UseVisualStyleBackColor = false;
            bActualizarGrafico.Click += bActualizarGrafico_Click;
            // 
            // panelGrafico
            // 
            panelGrafico.BackColor = Color.White;
            panelGrafico.Location = new Point(42, 146);
            panelGrafico.Name = "panelGrafico";
            panelGrafico.Size = new Size(680, 241);
            panelGrafico.TabIndex = 18;
            // 
            // rbFechas
            // 
            rbFechas.AutoSize = true;
            rbFechas.Checked = true;
            rbFechas.Location = new Point(501, 121);
            rbFechas.Name = "rbFechas";
            rbFechas.Size = new Size(95, 19);
            rbFechas.TabIndex = 19;
            rbFechas.TabStop = true;
            rbFechas.Text = "Segun fechas";
            rbFechas.UseVisualStyleBackColor = true;
            rbFechas.CheckedChanged += rbFechas_CheckedChanged;
            // 
            // rbMedicos
            // 
            rbMedicos.AutoSize = true;
            rbMedicos.Location = new Point(616, 121);
            rbMedicos.Name = "rbMedicos";
            rbMedicos.Size = new Size(106, 19);
            rbMedicos.TabIndex = 20;
            rbMedicos.Text = "Segun medicos";
            rbMedicos.UseVisualStyleBackColor = true;
            rbMedicos.CheckedChanged += rbMedicos_CheckedChanged;
            // 
            // InformeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rbMedicos);
            Controls.Add(rbFechas);
            Controls.Add(panelGrafico);
            Controls.Add(bActualizarGrafico);
            Controls.Add(panelBordes1);
            Controls.Add(panelSeleccionIntervalo);
            Controls.Add(cbDecisionIntervalo);
            Controls.Add(lSeleccion);
            Controls.Add(lSubtituloDashboard);
            Controls.Add(lTituloDashboard);
            Margin = new Padding(3, 2, 3, 2);
            Name = "InformeControl";
            Load += InformeControl_Load;
            panelSeleccionIntervalo.ResumeLayout(false);
            panelSeleccionIntervalo.PerformLayout();
            panelBordes1.ResumeLayout(false);
            panelBordes1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lSubtituloDashboard;
        private Label lTituloDashboard;
        private Label lSeleccion;
        private ComboBox cbDecisionIntervalo;
        private Label label12;
        private Label label11;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaInicio;
        private Panel panelSeleccionIntervalo;
        private PanelBordes panelBordes1;
        private Label lFecha;
        private Label lMedicoActivo;
        private Label lPromedioRegistros;
        private Label lTotalRegistros;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button bActualizarGrafico;
        private PanelBordes panelGrafico;
        private RadioButton rbFechas;
        private RadioButton rbMedicos;
    }
}
