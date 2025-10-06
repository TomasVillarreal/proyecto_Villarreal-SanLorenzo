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
            bRegistrarPaciente = new Button();
            lIntervencion = new Label();
            lDniPaciente = new Label();
            comboBoxCategoria = new ComboBox();
            tBusquedaDNI = new TextBox();
            labelSubtitulo = new Label();
            lFiltros = new Label();
            panelRegistrosPacientes = new Panel();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lFechaInt = new Label();
            lFecha = new Label();
            bEditar = new Button();
            bDetalles = new Button();
            lObservaciones2 = new Label();
            lObservaciones = new Label();
            lNombreProfesional = new Label();
            lProfesional = new Label();
            lTagTipo = new Label();
            panelFiltros.SuspendLayout();
            panelRegistrosPacientes.SuspendLayout();
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
            panelFiltros.Controls.Add(bRegistrarPaciente);
            panelFiltros.Controls.Add(lIntervencion);
            panelFiltros.Controls.Add(lDniPaciente);
            panelFiltros.Controls.Add(comboBoxCategoria);
            panelFiltros.Controls.Add(tBusquedaDNI);
            panelFiltros.Controls.Add(labelSubtitulo);
            panelFiltros.Controls.Add(lFiltros);
            panelFiltros.Location = new Point(33, 67);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(583, 254);
            panelFiltros.TabIndex = 4;
            // 
            // bRegistrarPaciente
            // 
            bRegistrarPaciente.BackColor = Color.Transparent;
            bRegistrarPaciente.ForeColor = Color.Black;
            bRegistrarPaciente.Image = Resource1.plus_icon;
            bRegistrarPaciente.Location = new Point(453, 21);
            bRegistrarPaciente.Margin = new Padding(3, 4, 3, 4);
            bRegistrarPaciente.Name = "bRegistrarPaciente";
            bRegistrarPaciente.Size = new Size(114, 53);
            bRegistrarPaciente.TabIndex = 13;
            bRegistrarPaciente.Text = "Agregar Registro";
            bRegistrarPaciente.TextImageRelation = TextImageRelation.ImageBeforeText;
            bRegistrarPaciente.UseVisualStyleBackColor = false;
            // 
            // lIntervencion
            // 
            lIntervencion.AutoSize = true;
            lIntervencion.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lIntervencion.Location = new Point(15, 165);
            lIntervencion.Name = "lIntervencion";
            lIntervencion.Size = new Size(127, 28);
            lIntervencion.TabIndex = 11;
            lIntervencion.Text = "Intervención";
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
            // comboBoxCategoria
            // 
            comboBoxCategoria.ForeColor = Color.DarkGray;
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(15, 196);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(460, 28);
            comboBoxCategoria.TabIndex = 7;
            comboBoxCategoria.Text = "Buscar por intevención";
            comboBoxCategoria.KeyDown += comboBoxCategoria_KeyDown;
            // 
            // tBusquedaDNI
            // 
            tBusquedaDNI.ForeColor = Color.DarkGray;
            tBusquedaDNI.Location = new Point(15, 102);
            tBusquedaDNI.Name = "tBusquedaDNI";
            tBusquedaDNI.Size = new Size(460, 27);
            tBusquedaDNI.TabIndex = 6;
            tBusquedaDNI.Text = "Busca por DNI";
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
            // panelRegistrosPacientes
            // 
            panelRegistrosPacientes.BackColor = Color.White;
            panelRegistrosPacientes.Controls.Add(label6);
            panelRegistrosPacientes.Controls.Add(button1);
            panelRegistrosPacientes.Controls.Add(button2);
            panelRegistrosPacientes.Controls.Add(label1);
            panelRegistrosPacientes.Controls.Add(label2);
            panelRegistrosPacientes.Controls.Add(label3);
            panelRegistrosPacientes.Controls.Add(label4);
            panelRegistrosPacientes.Controls.Add(label5);
            panelRegistrosPacientes.Controls.Add(lFechaInt);
            panelRegistrosPacientes.Controls.Add(lFecha);
            panelRegistrosPacientes.Controls.Add(bEditar);
            panelRegistrosPacientes.Controls.Add(bDetalles);
            panelRegistrosPacientes.Controls.Add(lObservaciones2);
            panelRegistrosPacientes.Controls.Add(lObservaciones);
            panelRegistrosPacientes.Controls.Add(lNombreProfesional);
            panelRegistrosPacientes.Controls.Add(lProfesional);
            panelRegistrosPacientes.Controls.Add(lTagTipo);
            panelRegistrosPacientes.Location = new Point(33, 327);
            panelRegistrosPacientes.Name = "panelRegistrosPacientes";
            panelRegistrosPacientes.Size = new Size(808, 417);
            panelRegistrosPacientes.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DarkGray;
            label6.Location = new Point(601, 305);
            label6.Name = "label6";
            label6.Size = new Size(137, 20);
            label6.TabIndex = 29;
            label6.Text = "2025-10-11 11:15";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlDark;
            button1.Location = new Point(142, 384);
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
            button2.Location = new Point(15, 384);
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
            label1.Location = new Point(129, 343);
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
            label2.Location = new Point(15, 343);
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
            label3.Location = new Point(112, 305);
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
            label4.Location = new Point(15, 305);
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
            label5.Location = new Point(15, 276);
            label5.Name = "label5";
            label5.Size = new Size(101, 20);
            label5.TabIndex = 22;
            label5.Text = "Medicamento";
            // 
            // lFechaInt
            // 
            lFechaInt.AutoSize = true;
            lFechaInt.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lFechaInt.Location = new Point(594, 25);
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
            lFecha.Location = new Point(594, 53);
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
            lTagTipo.Location = new Point(15, 13);
            lTagTipo.Name = "lTagTipo";
            lTagTipo.Size = new Size(100, 20);
            lTagTipo.TabIndex = 13;
            lTagTipo.Text = "Control rutina";
            // 
            // HistorialClinicoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelRegistrosPacientes);
            Controls.Add(panelFiltros);
            Controls.Add(lSubtituloHC);
            Controls.Add(lTituloHC);
            Name = "HistorialClinicoControl";
            Size = new Size(878, 767);
            Load += HistorialClinicoControl_Load;
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            panelRegistrosPacientes.ResumeLayout(false);
            panelRegistrosPacientes.PerformLayout();
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
        private Label lIntervencion;
        private Label lDniPaciente;
        private Panel panelRegistrosPacientes;
        private Button bEditar;
        private Button bDetalles;
        private Label lObservaciones2;
        private Label lObservaciones;
        private Label lNombreProfesional;
        private Label lProfesional;
        private Label lTagTipo;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lFechaInt;
        private Label lFecha;
        private Label label6;
        private TextBox tBusquedaDNI;
        private DataGridView dgPaciente;
        private Button bRegistrarPaciente;
    }
}
