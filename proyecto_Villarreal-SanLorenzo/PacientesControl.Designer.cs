namespace proyecto_Villarreal_SanLorenzo
{
    partial class PacientesControl
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
            panelBordes1 = new PanelBordes();
            rbEliminados = new RadioButton();
            rbVisibles = new RadioButton();
            dgPaciente = new DataGridView();
            tBusquedaPacientes = new TextBox();
            lListaPacientes = new Label();
            lTituloPacientes = new Label();
            lSubtituloPacientes = new Label();
            bRegistrarPaciente = new Button();
            panelBordes1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgPaciente).BeginInit();
            SuspendLayout();
            // 
            // panelBordes1
            // 
            panelBordes1.BackColor = Color.White;
            panelBordes1.Controls.Add(rbEliminados);
            panelBordes1.Controls.Add(rbVisibles);
            panelBordes1.Controls.Add(dgPaciente);
            panelBordes1.Controls.Add(tBusquedaPacientes);
            panelBordes1.Controls.Add(lListaPacientes);
            panelBordes1.Location = new Point(23, 131);
            panelBordes1.Name = "panelBordes1";
            panelBordes1.Size = new Size(723, 417);
            panelBordes1.TabIndex = 0;
            // 
            // rbEliminados
            // 
            rbEliminados.AutoSize = true;
            rbEliminados.Location = new Point(574, 40);
            rbEliminados.Name = "rbEliminados";
            rbEliminados.Size = new Size(136, 19);
            rbEliminados.TabIndex = 6;
            rbEliminados.Text = "Pacientes eliminados";
            rbEliminados.UseVisualStyleBackColor = true;
            rbEliminados.CheckedChanged += rbEliminados_CheckedChanged;
            // 
            // rbVisibles
            // 
            rbVisibles.AutoSize = true;
            rbVisibles.Checked = true;
            rbVisibles.Location = new Point(436, 40);
            rbVisibles.Name = "rbVisibles";
            rbVisibles.Size = new Size(116, 19);
            rbVisibles.TabIndex = 5;
            rbVisibles.TabStop = true;
            rbVisibles.Text = "Pacientes visibles";
            rbVisibles.UseVisualStyleBackColor = true;
            rbVisibles.CheckedChanged += rbVisibles_CheckedChanged;
            // 
            // dgPaciente
            // 
            dgPaciente.AllowUserToAddRows = false;
            dgPaciente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPaciente.BackgroundColor = Color.White;
            dgPaciente.BorderStyle = BorderStyle.None;
            dgPaciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPaciente.Location = new Point(13, 81);
            dgPaciente.Name = "dgPaciente";
            dgPaciente.Size = new Size(697, 322);
            dgPaciente.TabIndex = 4;
            dgPaciente.CellContentClick += dgPaciente_CellContentClick;
            // 
            // tBusquedaPacientes
            // 
            tBusquedaPacientes.ForeColor = SystemColors.ActiveBorder;
            tBusquedaPacientes.Location = new Point(13, 36);
            tBusquedaPacientes.Name = "tBusquedaPacientes";
            tBusquedaPacientes.Size = new Size(248, 23);
            tBusquedaPacientes.TabIndex = 3;
            tBusquedaPacientes.Text = "Buscar por DNI";
            tBusquedaPacientes.KeyDown += tBusquedaPacientes_KeyDown;
            tBusquedaPacientes.KeyPress += tBusquedaPacientes_KeyPress;
            // 
            // lListaPacientes
            // 
            lListaPacientes.AutoSize = true;
            lListaPacientes.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lListaPacientes.Location = new Point(12, 12);
            lListaPacientes.Name = "lListaPacientes";
            lListaPacientes.Size = new Size(139, 21);
            lListaPacientes.TabIndex = 2;
            lListaPacientes.Text = "Lista de Pacientes";
            // 
            // lTituloPacientes
            // 
            lTituloPacientes.AutoSize = true;
            lTituloPacientes.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloPacientes.Location = new Point(23, 42);
            lTituloPacientes.Name = "lTituloPacientes";
            lTituloPacientes.Size = new Size(195, 25);
            lTituloPacientes.TabIndex = 1;
            lTituloPacientes.Text = "Gestion de Pacientes";
            // 
            // lSubtituloPacientes
            // 
            lSubtituloPacientes.AutoSize = true;
            lSubtituloPacientes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtituloPacientes.ForeColor = SystemColors.ControlDark;
            lSubtituloPacientes.Location = new Point(23, 67);
            lSubtituloPacientes.Name = "lSubtituloPacientes";
            lSubtituloPacientes.Size = new Size(227, 15);
            lSubtituloPacientes.TabIndex = 2;
            lSubtituloPacientes.Text = "Sistema de registro y gestion de pacientes";
            // 
            // bRegistrarPaciente
            // 
            bRegistrarPaciente.BackColor = SystemColors.Highlight;
            bRegistrarPaciente.ForeColor = Color.Transparent;
            bRegistrarPaciente.Image = Resource1.plus_icon;
            bRegistrarPaciente.Location = new Point(637, 42);
            bRegistrarPaciente.Name = "bRegistrarPaciente";
            bRegistrarPaciente.Size = new Size(96, 40);
            bRegistrarPaciente.TabIndex = 3;
            bRegistrarPaciente.Text = "Registrar Paciente";
            bRegistrarPaciente.TextImageRelation = TextImageRelation.ImageBeforeText;
            bRegistrarPaciente.UseVisualStyleBackColor = false;
            bRegistrarPaciente.Click += bRegistrarPaciente_Click;
            // 
            // PacientesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bRegistrarPaciente);
            Controls.Add(lSubtituloPacientes);
            Controls.Add(lTituloPacientes);
            Controls.Add(panelBordes1);
            Name = "PacientesControl";
            Load += PacientesControl_Load;
            panelBordes1.ResumeLayout(false);
            panelBordes1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgPaciente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PanelBordes panelBordes1;
        private Label lTituloPacientes;
        private Label lSubtituloPacientes;
        private Button bRegistrarPaciente;
        private TextBox tBusquedaPacientes;
        private Label lListaPacientes;
        private DataGridView dgPaciente;
        private RadioButton rbEliminados;
        private RadioButton rbVisibles;
    }
}
