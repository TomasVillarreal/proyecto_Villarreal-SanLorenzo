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
            dgPaciente = new DataGridView();
            tBusquedaPacientes = new TextBox();
            lListaPacientes = new Label();
            lTituloPacientes = new Label();
            lSubtituloPacientes = new Label();
            bRegistrarPaciente = new Button();
            cNombrePaciente = new DataGridViewTextBoxColumn();
            cDniPaciente = new DataGridViewTextBoxColumn();
            cTelefonoPaciente = new DataGridViewTextBoxColumn();
            cHistorial = new DataGridViewButtonColumn();
            cEditarPaciente = new DataGridViewButtonColumn();
            cEliminarPaciente = new DataGridViewButtonColumn();
            panelBordes1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgPaciente).BeginInit();
            SuspendLayout();
            // 
            // panelBordes1
            // 
            panelBordes1.BackColor = Color.White;
            panelBordes1.Controls.Add(dgPaciente);
            panelBordes1.Controls.Add(tBusquedaPacientes);
            panelBordes1.Controls.Add(lListaPacientes);
            panelBordes1.Location = new Point(23, 131);
            panelBordes1.Name = "panelBordes1";
            panelBordes1.Size = new Size(723, 417);
            panelBordes1.TabIndex = 0;
            // 
            // dgPaciente
            // 
            dgPaciente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPaciente.BackgroundColor = Color.White;
            dgPaciente.BorderStyle = BorderStyle.None;
            dgPaciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPaciente.Columns.AddRange(new DataGridViewColumn[] { cNombrePaciente, cDniPaciente, cTelefonoPaciente, cHistorial, cEditarPaciente, cEliminarPaciente });
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
            bRegistrarPaciente.Image = Resource1.circulo_plus;
            bRegistrarPaciente.Location = new Point(637, 42);
            bRegistrarPaciente.Name = "bRegistrarPaciente";
            bRegistrarPaciente.Size = new Size(96, 40);
            bRegistrarPaciente.TabIndex = 3;
            bRegistrarPaciente.Text = "Registrar Paciente";
            bRegistrarPaciente.TextImageRelation = TextImageRelation.ImageBeforeText;
            bRegistrarPaciente.UseVisualStyleBackColor = false;
            // 
            // cNombrePaciente
            // 
            cNombrePaciente.HeaderText = "Nombre";
            cNombrePaciente.Name = "cNombrePaciente";
            // 
            // cDniPaciente
            // 
            cDniPaciente.HeaderText = "DNI";
            cDniPaciente.Name = "cDniPaciente";
            // 
            // cTelefonoPaciente
            // 
            cTelefonoPaciente.HeaderText = "Telefono";
            cTelefonoPaciente.Name = "cTelefonoPaciente";
            // 
            // cHistorial
            // 
            cHistorial.HeaderText = "Ver Historial";
            cHistorial.Name = "cHistorial";
            cHistorial.Text = "Ver Historial";
            // 
            // cEditarPaciente
            // 
            cEditarPaciente.HeaderText = "Editar";
            cEditarPaciente.Name = "cEditarPaciente";
            cEditarPaciente.Text = "Editar";
            // 
            // cEliminarPaciente
            // 
            cEliminarPaciente.HeaderText = "Eliminar";
            cEliminarPaciente.Name = "cEliminarPaciente";
            cEliminarPaciente.Text = "Eliminar";
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
        private DataGridViewTextBoxColumn cNombrePaciente;
        private DataGridViewTextBoxColumn cDniPaciente;
        private DataGridViewTextBoxColumn cTelefonoPaciente;
        private DataGridViewButtonColumn cHistorial;
        private DataGridViewButtonColumn cEditarPaciente;
        private DataGridViewButtonColumn cEliminarPaciente;
    }
}
