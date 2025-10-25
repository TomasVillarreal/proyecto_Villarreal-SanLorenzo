namespace proyecto_Villarreal_SanLorenzo
{
    partial class InformeMedicosEnfermeros
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
            panelGrafico = new PanelBordes();
            bActualizarGrafico = new Button();
            panelInfo = new PanelBordes();
            lFecha = new Label();
            lTipoConsulta = new Label();
            lPromedioRegistros = new Label();
            lTotalRegistros = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelSeleccionIntervalo = new Panel();
            label11 = new Label();
            dtpFechaFin = new DateTimePicker();
            label12 = new Label();
            dtpFechaInicio = new DateTimePicker();
            cbDecisionIntervalo = new ComboBox();
            lSeleccion = new Label();
            lSubtituloDashboard = new Label();
            lTituloDashboard = new Label();
            rbTiempos = new RadioButton();
            rbTipoConsulta = new RadioButton();
            panelInfo.SuspendLayout();
            panelSeleccionIntervalo.SuspendLayout();
            SuspendLayout();
            // 
            // panelGrafico
            // 
            panelGrafico.BackColor = Color.White;
            panelGrafico.Location = new Point(44, 148);
            panelGrafico.Name = "panelGrafico";
            panelGrafico.Size = new Size(680, 241);
            panelGrafico.TabIndex = 31;
            // 
            // bActualizarGrafico
            // 
            bActualizarGrafico.BackColor = Color.Black;
            bActualizarGrafico.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bActualizarGrafico.ForeColor = Color.White;
            bActualizarGrafico.Location = new Point(304, 90);
            bActualizarGrafico.Name = "bActualizarGrafico";
            bActualizarGrafico.Size = new Size(78, 34);
            bActualizarGrafico.TabIndex = 30;
            bActualizarGrafico.Text = "Actualizar";
            bActualizarGrafico.UseVisualStyleBackColor = false;
            bActualizarGrafico.Click += bActualizarGrafico_Click;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.White;
            panelInfo.Controls.Add(lFecha);
            panelInfo.Controls.Add(lTipoConsulta);
            panelInfo.Controls.Add(lPromedioRegistros);
            panelInfo.Controls.Add(lTotalRegistros);
            panelInfo.Controls.Add(label4);
            panelInfo.Controls.Add(label3);
            panelInfo.Controls.Add(label2);
            panelInfo.Controls.Add(label1);
            panelInfo.Location = new Point(44, 409);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(680, 130);
            panelInfo.TabIndex = 29;
            // 
            // lFecha
            // 
            lFecha.AutoSize = true;
            lFecha.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold);
            lFecha.Location = new Point(529, 91);
            lFecha.Name = "lFecha";
            lFecha.Size = new Size(78, 17);
            lFecha.TabIndex = 15;
            lFecha.Text = "01/01/1900";
            // 
            // lTipoConsulta
            // 
            lTipoConsulta.AutoSize = true;
            lTipoConsulta.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold);
            lTipoConsulta.Location = new Point(410, 43);
            lTipoConsulta.Name = "lTipoConsulta";
            lTipoConsulta.Size = new Size(46, 17);
            lTipoConsulta.TabIndex = 14;
            lTipoConsulta.Text = "label5";
            // 
            // lPromedioRegistros
            // 
            lPromedioRegistros.AutoSize = true;
            lPromedioRegistros.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold);
            lPromedioRegistros.Location = new Point(72, 91);
            lPromedioRegistros.Name = "lPromedioRegistros";
            lPromedioRegistros.Size = new Size(46, 17);
            lPromedioRegistros.TabIndex = 13;
            lPromedioRegistros.Text = "label5";
            // 
            // lTotalRegistros
            // 
            lTotalRegistros.AutoSize = true;
            lTotalRegistros.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold);
            lTotalRegistros.Location = new Point(81, 43);
            lTotalRegistros.Name = "lTotalRegistros";
            lTotalRegistros.Size = new Size(22, 17);
            lTotalRegistros.TabIndex = 12;
            lTotalRegistros.Text = "10";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 70);
            label4.Name = "label4";
            label4.Size = new Size(230, 21);
            label4.TabIndex = 11;
            label4.Text = "Promedio de registros por dia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(490, 70);
            label3.Name = "label3";
            label3.Size = new Size(167, 21);
            label3.TabIndex = 10;
            label3.Text = "Día con más actividad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(410, 22);
            label2.Name = "label2";
            label2.Size = new Size(264, 21);
            label2.TabIndex = 9;
            label2.Text = "Tipo de consulta con mas registros";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 22);
            label1.Name = "label1";
            label1.Size = new Size(137, 21);
            label1.TabIndex = 8;
            label1.Text = "Total de registros";
            // 
            // panelSeleccionIntervalo
            // 
            panelSeleccionIntervalo.Controls.Add(label11);
            panelSeleccionIntervalo.Controls.Add(dtpFechaFin);
            panelSeleccionIntervalo.Controls.Add(label12);
            panelSeleccionIntervalo.Controls.Add(dtpFechaInicio);
            panelSeleccionIntervalo.Location = new Point(497, 43);
            panelSeleccionIntervalo.Name = "panelSeleccionIntervalo";
            panelSeleccionIntervalo.Size = new Size(227, 43);
            panelSeleccionIntervalo.TabIndex = 28;
            panelSeleccionIntervalo.Visible = false;
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
            // cbDecisionIntervalo
            // 
            cbDecisionIntervalo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDecisionIntervalo.FormattingEnabled = true;
            cbDecisionIntervalo.Items.AddRange(new object[] { "Todos los tiempos", "Ultima semana", "Ultimo mes", "Ultimo año", "Personalizado" });
            cbDecisionIntervalo.Location = new Point(304, 61);
            cbDecisionIntervalo.Name = "cbDecisionIntervalo";
            cbDecisionIntervalo.Size = new Size(121, 23);
            cbDecisionIntervalo.TabIndex = 27;
            cbDecisionIntervalo.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lSeleccion
            // 
            lSeleccion.AutoSize = true;
            lSeleccion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSeleccion.ForeColor = SystemColors.ControlDark;
            lSeleccion.Location = new Point(304, 43);
            lSeleccion.Name = "lSeleccion";
            lSeleccion.Size = new Size(181, 15);
            lSeleccion.TabIndex = 26;
            lSeleccion.Text = "Seleccione el intervalo de tiempo";
            // 
            // lSubtituloDashboard
            // 
            lSubtituloDashboard.AutoSize = true;
            lSubtituloDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtituloDashboard.ForeColor = SystemColors.ControlDark;
            lSubtituloDashboard.Location = new Point(44, 60);
            lSubtituloDashboard.Name = "lSubtituloDashboard";
            lSubtituloDashboard.Size = new Size(187, 15);
            lSubtituloDashboard.TabIndex = 25;
            lSubtituloDashboard.Text = "Consulte el informe de un medico";
            // 
            // lTituloDashboard
            // 
            lTituloDashboard.AutoSize = true;
            lTituloDashboard.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloDashboard.Location = new Point(44, 35);
            lTituloDashboard.Name = "lTituloDashboard";
            lTituloDashboard.Size = new Size(92, 25);
            lTituloDashboard.TabIndex = 24;
            lTituloDashboard.Text = "Informes";
            // 
            // rbTiempos
            // 
            rbTiempos.AutoSize = true;
            rbTiempos.Checked = true;
            rbTiempos.Location = new Point(454, 123);
            rbTiempos.Name = "rbTiempos";
            rbTiempos.Size = new Size(104, 19);
            rbTiempos.TabIndex = 32;
            rbTiempos.TabStop = true;
            rbTiempos.Text = "Segun tiempos";
            rbTiempos.UseVisualStyleBackColor = true;
            rbTiempos.CheckedChanged += rbTiempos_CheckedChanged;
            // 
            // rbTipoConsulta
            // 
            rbTipoConsulta.AutoSize = true;
            rbTipoConsulta.Location = new Point(573, 123);
            rbTipoConsulta.Name = "rbTipoConsulta";
            rbTipoConsulta.Size = new Size(151, 19);
            rbTipoConsulta.TabIndex = 33;
            rbTipoConsulta.Text = "Segun tipos de consulta";
            rbTipoConsulta.UseVisualStyleBackColor = true;
            rbTipoConsulta.CheckedChanged += rbTipoConsulta_CheckedChanged;
            // 
            // InformeMedicosEnfermeros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rbTipoConsulta);
            Controls.Add(rbTiempos);
            Controls.Add(panelGrafico);
            Controls.Add(bActualizarGrafico);
            Controls.Add(panelInfo);
            Controls.Add(panelSeleccionIntervalo);
            Controls.Add(cbDecisionIntervalo);
            Controls.Add(lSeleccion);
            Controls.Add(lSubtituloDashboard);
            Controls.Add(lTituloDashboard);
            Name = "InformeMedicosEnfermeros";
            Load += InformeMedicosEnfermeros_Load;
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            panelSeleccionIntervalo.ResumeLayout(false);
            panelSeleccionIntervalo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PanelBordes panelGrafico;
        private Button bActualizarGrafico;
        private PanelBordes panelInfo;
        private Panel panelSeleccionIntervalo;
        private Label label11;
        private DateTimePicker dtpFechaFin;
        private Label label12;
        private DateTimePicker dtpFechaInicio;
        private ComboBox cbDecisionIntervalo;
        private Label lSeleccion;
        private Label lSubtituloDashboard;
        private Label lTituloDashboard;
        private RadioButton rbTiempos;
        private RadioButton rbTipoConsulta;
        private Label lFecha;
        private Label lTipoConsulta;
        private Label lPromedioRegistros;
        private Label lTotalRegistros;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
