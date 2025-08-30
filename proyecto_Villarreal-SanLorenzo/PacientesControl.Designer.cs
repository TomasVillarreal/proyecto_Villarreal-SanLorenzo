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
            lTituloPacientes = new Label();
            lSubtituloPacientes = new Label();
            bRegistrarPaciente = new Button();
            lListaPacientes = new Label();
            tBusquedaPacientes = new TextBox();
            panelBordes1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBordes1
            // 
            panelBordes1.BackColor = Color.White;
            panelBordes1.Controls.Add(tBusquedaPacientes);
            panelBordes1.Controls.Add(lListaPacientes);
            panelBordes1.Location = new Point(23, 131);
            panelBordes1.Name = "panelBordes1";
            panelBordes1.Size = new Size(723, 417);
            panelBordes1.TabIndex = 0;
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
            bRegistrarPaciente.Location = new Point(629, 45);
            bRegistrarPaciente.Name = "bRegistrarPaciente";
            bRegistrarPaciente.Size = new Size(96, 37);
            bRegistrarPaciente.TabIndex = 3;
            bRegistrarPaciente.Text = "Registrar Paciente";
            bRegistrarPaciente.UseVisualStyleBackColor = false;
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
            // tBusquedaPacientes
            // 
            tBusquedaPacientes.ForeColor = SystemColors.ActiveBorder;
            tBusquedaPacientes.Location = new Point(13, 36);
            tBusquedaPacientes.Name = "tBusquedaPacientes";
            tBusquedaPacientes.Size = new Size(248, 23);
            tBusquedaPacientes.TabIndex = 3;
            tBusquedaPacientes.Text = "Buscar por DNI";
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
    }
}
