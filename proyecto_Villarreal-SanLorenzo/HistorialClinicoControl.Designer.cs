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
            dgvRegistrosPacientes = new DataGridView();
            panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistrosPacientes).BeginInit();
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
            panelRegistrosPacientes.Location = new Point(33, 327);
            panelRegistrosPacientes.Name = "panelRegistrosPacientes";
            panelRegistrosPacientes.Size = new Size(808, 87);
            panelRegistrosPacientes.TabIndex = 12;
            // 
            // dgvRegistrosPacientes
            // 
            dgvRegistrosPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistrosPacientes.Location = new Point(33, 420);
            dgvRegistrosPacientes.Name = "dgvRegistrosPacientes";
            dgvRegistrosPacientes.RowHeadersWidth = 51;
            dgvRegistrosPacientes.Size = new Size(808, 188);
            dgvRegistrosPacientes.TabIndex = 13;
            // 
            // HistorialClinicoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvRegistrosPacientes);
            Controls.Add(panelRegistrosPacientes);
            Controls.Add(panelFiltros);
            Controls.Add(lSubtituloHC);
            Controls.Add(lTituloHC);
            Name = "HistorialClinicoControl";
            Size = new Size(878, 767);
            Load += HistorialClinicoControl_Load;
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistrosPacientes).EndInit();
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
        private TextBox tBusquedaDNI;
        private DataGridView dgPaciente;
        private Button bRegistrarPaciente;
        private DataGridView dgvRegistrosPacientes;
    }
}
