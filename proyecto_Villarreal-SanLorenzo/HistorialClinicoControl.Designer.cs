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
            lIntervencion = new Label();
            lNombrePaciente = new Label();
            lDniPaciente = new Label();
            textBoxNombrePaciente = new TextBox();
            comboBoxCategoria = new ComboBox();
            textBoxDNI = new TextBox();
            labelSubtitulo = new Label();
            lFiltros = new Label();
            panelInfo = new Panel();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lMedicamento = new Label();
            lFechaInt = new Label();
            lFecha = new Label();
            bEditar = new Button();
            bDetalles = new Button();
            lObservaciones2 = new Label();
            lObservaciones = new Label();
            lNombreProfesional = new Label();
            lProfesional = new Label();
            lTagTipo = new Label();
            lConsulta = new Label();
            panelFiltros.SuspendLayout();
            panelInfo.SuspendLayout();
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
            panelFiltros.Controls.Add(lIntervencion);
            panelFiltros.Controls.Add(lNombrePaciente);
            panelFiltros.Controls.Add(lDniPaciente);
            panelFiltros.Controls.Add(textBoxNombrePaciente);
            panelFiltros.Controls.Add(comboBoxCategoria);
            panelFiltros.Controls.Add(textBoxDNI);
            panelFiltros.Controls.Add(labelSubtitulo);
            panelFiltros.Controls.Add(lFiltros);
            panelFiltros.Location = new Point(33, 67);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(713, 155);
            panelFiltros.TabIndex = 4;
            // 
            // lIntervencion
            // 
            lIntervencion.AutoSize = true;
            lIntervencion.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lIntervencion.Location = new Point(496, 70);
            lIntervencion.Name = "lIntervencion";
            lIntervencion.Size = new Size(127, 28);
            lIntervencion.TabIndex = 11;
            lIntervencion.Text = "Intervención";
            // 
            // lNombrePaciente
            // 
            lNombrePaciente.AutoSize = true;
            lNombrePaciente.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNombrePaciente.Location = new Point(257, 70);
            lNombrePaciente.Name = "lNombrePaciente";
            lNombrePaciente.Size = new Size(87, 28);
            lNombrePaciente.TabIndex = 10;
            lNombrePaciente.Text = "Nombre";
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
            // textBoxNombrePaciente
            // 
            textBoxNombrePaciente.ForeColor = Color.DarkGray;
            textBoxNombrePaciente.Location = new Point(256, 101);
            textBoxNombrePaciente.Name = "textBoxNombrePaciente";
            textBoxNombrePaciente.Size = new Size(196, 27);
            textBoxNombrePaciente.TabIndex = 8;
            textBoxNombrePaciente.Text = "Nombre paciente";
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.ForeColor = Color.DarkGray;
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(496, 102);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(196, 28);
            comboBoxCategoria.TabIndex = 7;
            comboBoxCategoria.Text = "Todos los tipos";
            // 
            // textBoxDNI
            // 
            textBoxDNI.ForeColor = Color.DarkGray;
            textBoxDNI.Location = new Point(15, 102);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.Size = new Size(198, 27);
            textBoxDNI.TabIndex = 6;
            textBoxDNI.Text = "Busca por DNI";
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
            // panelInfo
            // 
            panelInfo.BackColor = Color.White;
            panelInfo.Controls.Add(label6);
            panelInfo.Controls.Add(button1);
            panelInfo.Controls.Add(button2);
            panelInfo.Controls.Add(label1);
            panelInfo.Controls.Add(label2);
            panelInfo.Controls.Add(label3);
            panelInfo.Controls.Add(label4);
            panelInfo.Controls.Add(label5);
            panelInfo.Controls.Add(lMedicamento);
            panelInfo.Controls.Add(lFechaInt);
            panelInfo.Controls.Add(lFecha);
            panelInfo.Controls.Add(bEditar);
            panelInfo.Controls.Add(bDetalles);
            panelInfo.Controls.Add(lObservaciones2);
            panelInfo.Controls.Add(lObservaciones);
            panelInfo.Controls.Add(lNombreProfesional);
            panelInfo.Controls.Add(lProfesional);
            panelInfo.Controls.Add(lTagTipo);
            panelInfo.Controls.Add(lConsulta);
            panelInfo.Location = new Point(33, 228);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(713, 344);
            panelInfo.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DarkGray;
            label6.Location = new Point(496, 232);
            label6.Name = "label6";
            label6.Size = new Size(137, 20);
            label6.TabIndex = 29;
            label6.Text = "2025-10-11 11:15";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlDark;
            button1.Location = new Point(142, 311);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 28;
            button1.Text = "Editar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonShadow;
            button2.Location = new Point(15, 311);
            button2.Name = "button2";
            button2.Size = new Size(115, 29);
            button2.TabIndex = 27;
            button2.Text = "Ver detalles";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(129, 270);
            label1.Name = "label1";
            label1.Size = new Size(190, 20);
            label1.TabIndex = 26;
            label1.Text = "Amoxicilina 500mg via oral";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(15, 270);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 25;
            label2.Text = "Observaciones:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(112, 232);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 24;
            label3.Text = "Jorge Perez";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(15, 232);
            label4.Name = "label4";
            label4.Size = new Size(92, 20);
            label4.TabIndex = 23;
            label4.Text = "Profesional:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.DarkGreen;
            label5.ForeColor = Color.White;
            label5.Location = new Point(226, 196);
            label5.Name = "label5";
            label5.Size = new Size(101, 20);
            label5.TabIndex = 22;
            label5.Text = "Medicamento";
            // 
            // lMedicamento
            // 
            lMedicamento.AutoSize = true;
            lMedicamento.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lMedicamento.ForeColor = Color.Black;
            lMedicamento.Location = new Point(15, 196);
            lMedicamento.Name = "lMedicamento";
            lMedicamento.Size = new Size(205, 20);
            lMedicamento.TabIndex = 21;
            lMedicamento.Text = "Administración medicamento";
            // 
            // lFechaInt
            // 
            lFechaInt.AutoSize = true;
            lFechaInt.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lFechaInt.Location = new Point(496, 23);
            lFechaInt.Name = "lFechaInt";
            lFechaInt.Size = new Size(144, 28);
            lFechaInt.TabIndex = 12;
            lFechaInt.Text = "Fecha Registro";
            // 
            // lFecha
            // 
            lFecha.AutoSize = true;
            lFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lFecha.ForeColor = Color.DarkGray;
            lFecha.Location = new Point(496, 51);
            lFecha.Name = "lFecha";
            lFecha.Size = new Size(137, 20);
            lFecha.TabIndex = 20;
            lFecha.Text = "2025-06-28 10:30";
            // 
            // bEditar
            // 
            bEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bEditar.ForeColor = SystemColors.ControlDark;
            bEditar.Location = new Point(142, 125);
            bEditar.Name = "bEditar";
            bEditar.Size = new Size(94, 29);
            bEditar.TabIndex = 19;
            bEditar.Text = "Editar";
            bEditar.UseVisualStyleBackColor = true;
            // 
            // bDetalles
            // 
            bDetalles.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bDetalles.ForeColor = SystemColors.ButtonShadow;
            bDetalles.Location = new Point(15, 125);
            bDetalles.Name = "bDetalles";
            bDetalles.Size = new Size(115, 29);
            bDetalles.TabIndex = 18;
            bDetalles.Text = "Ver detalles";
            bDetalles.UseVisualStyleBackColor = true;
            // 
            // lObservaciones2
            // 
            lObservaciones2.AutoSize = true;
            lObservaciones2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lObservaciones2.ForeColor = Color.Black;
            lObservaciones2.Location = new Point(129, 84);
            lObservaciones2.Name = "lObservaciones2";
            lObservaciones2.Size = new Size(174, 20);
            lObservaciones2.TabIndex = 17;
            lObservaciones2.Text = "Paciente en  buen estado";
            // 
            // lObservaciones
            // 
            lObservaciones.AutoSize = true;
            lObservaciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lObservaciones.ForeColor = Color.Black;
            lObservaciones.Location = new Point(15, 84);
            lObservaciones.Name = "lObservaciones";
            lObservaciones.Size = new Size(115, 20);
            lObservaciones.TabIndex = 16;
            lObservaciones.Text = "Observaciones:";
            // 
            // lNombreProfesional
            // 
            lNombreProfesional.AutoSize = true;
            lNombreProfesional.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lNombreProfesional.ForeColor = Color.Black;
            lNombreProfesional.Location = new Point(112, 46);
            lNombreProfesional.Name = "lNombreProfesional";
            lNombreProfesional.Size = new Size(84, 20);
            lNombreProfesional.TabIndex = 15;
            lNombreProfesional.Text = "Jorge Perez";
            // 
            // lProfesional
            // 
            lProfesional.AutoSize = true;
            lProfesional.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lProfesional.ForeColor = Color.Black;
            lProfesional.Location = new Point(15, 46);
            lProfesional.Name = "lProfesional";
            lProfesional.Size = new Size(92, 20);
            lProfesional.TabIndex = 14;
            lProfesional.Text = "Profesional:";
            // 
            // lTagTipo
            // 
            lTagTipo.AutoSize = true;
            lTagTipo.BackColor = Color.Black;
            lTagTipo.ForeColor = Color.White;
            lTagTipo.Location = new Point(142, 10);
            lTagTipo.Name = "lTagTipo";
            lTagTipo.Size = new Size(100, 20);
            lTagTipo.TabIndex = 13;
            lTagTipo.Text = "Control rutina";
            // 
            // lConsulta
            // 
            lConsulta.AutoSize = true;
            lConsulta.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lConsulta.ForeColor = Color.Black;
            lConsulta.Location = new Point(15, 10);
            lConsulta.Name = "lConsulta";
            lConsulta.Size = new Size(121, 20);
            lConsulta.TabIndex = 12;
            lConsulta.Text = "Control de rutina";
            // 
            // HistorialClinicoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelInfo);
            Controls.Add(panelFiltros);
            Controls.Add(lSubtituloHC);
            Controls.Add(lTituloHC);
            Name = "HistorialClinicoControl";
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lTituloHC;
        private Label lSubtituloHC;
        private Panel panelFiltros;
        private Label labelSubtitulo;
        private Label lFiltros;
        private ComboBox comboBoxCategoria;
        private TextBox textBoxDNI;
        private TextBox textBoxNombrePaciente;
        private Label lIntervencion;
        private Label lNombrePaciente;
        private Label lDniPaciente;
        private Panel panelInfo;
        private Button bEditar;
        private Button bDetalles;
        private Label lObservaciones2;
        private Label lObservaciones;
        private Label lNombreProfesional;
        private Label lProfesional;
        private Label lTagTipo;
        private Label lConsulta;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lMedicamento;
        private Label lFechaInt;
        private Label lFecha;
        private Label label6;
    }
}
