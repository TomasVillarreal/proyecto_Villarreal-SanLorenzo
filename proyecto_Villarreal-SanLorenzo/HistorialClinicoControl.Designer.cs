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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialClinicoControl));
            lTituloHC = new Label();
            lSubtituloHC = new Label();
            panelFiltros = new Panel();
            bPdfRegistros = new Button();
            bAgregarRegistroPaciente = new Button();
            lDniPaciente = new Label();
            tBusquedaDNI = new TextBox();
            labelSubtitulo = new Label();
            lFiltros = new Label();
            panelContenedorRegistros = new FlowLayoutPanel();
            panelFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // lTituloHC
            // 
            lTituloHC.AutoSize = true;
            lTituloHC.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloHC.Location = new Point(29, 9);
            lTituloHC.Name = "lTituloHC";
            lTituloHC.Size = new Size(152, 25);
            lTituloHC.TabIndex = 2;
            lTituloHC.Text = "Historial Clinico";
            // 
            // lSubtituloHC
            // 
            lSubtituloHC.AutoSize = true;
            lSubtituloHC.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtituloHC.ForeColor = SystemColors.ControlDark;
            lSubtituloHC.Location = new Point(29, 33);
            lSubtituloHC.Name = "lSubtituloHC";
            lSubtituloHC.Size = new Size(241, 15);
            lSubtituloHC.TabIndex = 3;
            lSubtituloHC.Text = "Consulta el historial medico de los pacientes";
            // 
            // panelFiltros
            // 
            panelFiltros.BackColor = Color.White;
            panelFiltros.Controls.Add(bPdfRegistros);
            panelFiltros.Controls.Add(bAgregarRegistroPaciente);
            panelFiltros.Controls.Add(lDniPaciente);
            panelFiltros.Controls.Add(tBusquedaDNI);
            panelFiltros.Controls.Add(labelSubtitulo);
            panelFiltros.Controls.Add(lFiltros);
            panelFiltros.Location = new Point(29, 50);
            panelFiltros.Margin = new Padding(3, 2, 3, 2);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(716, 113);
            panelFiltros.TabIndex = 4;
            // 
            // bPdfRegistros
            // 
            bPdfRegistros.BackColor = Color.Transparent;
            bPdfRegistros.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bPdfRegistros.ForeColor = Color.Black;
            bPdfRegistros.Image = (Image)resources.GetObject("bPdfRegistros.Image");
            bPdfRegistros.Location = new Point(592, 48);
            bPdfRegistros.Name = "bPdfRegistros";
            bPdfRegistros.Size = new Size(121, 36);
            bPdfRegistros.TabIndex = 15;
            bPdfRegistros.Text = "Registros";
            bPdfRegistros.TextImageRelation = TextImageRelation.ImageBeforeText;
            bPdfRegistros.UseVisualStyleBackColor = false;
            bPdfRegistros.Click += bPdfRegistros_Click;
            // 
            // bAgregarRegistroPaciente
            // 
            bAgregarRegistroPaciente.BackColor = SystemColors.Highlight;
            bAgregarRegistroPaciente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bAgregarRegistroPaciente.ForeColor = Color.White;
            bAgregarRegistroPaciente.Image = Resource1.plus_icon;
            bAgregarRegistroPaciente.Location = new Point(592, 7);
            bAgregarRegistroPaciente.Name = "bAgregarRegistroPaciente";
            bAgregarRegistroPaciente.Size = new Size(121, 36);
            bAgregarRegistroPaciente.TabIndex = 13;
            bAgregarRegistroPaciente.Text = "Agregar Registro";
            bAgregarRegistroPaciente.TextImageRelation = TextImageRelation.ImageBeforeText;
            bAgregarRegistroPaciente.UseVisualStyleBackColor = false;
            bAgregarRegistroPaciente.Visible = false;
            bAgregarRegistroPaciente.Click += bAgregarRegistroPaciente_Click;
            // 
            // lDniPaciente
            // 
            lDniPaciente.AutoSize = true;
            lDniPaciente.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lDniPaciente.Location = new Point(13, 53);
            lDniPaciente.Name = "lDniPaciente";
            lDniPaciente.Size = new Size(38, 21);
            lDniPaciente.TabIndex = 9;
            lDniPaciente.Text = "DNI";
            // 
            // tBusquedaDNI
            // 
            tBusquedaDNI.ForeColor = Color.DarkGray;
            tBusquedaDNI.Location = new Point(13, 76);
            tBusquedaDNI.Margin = new Padding(3, 2, 3, 2);
            tBusquedaDNI.Name = "tBusquedaDNI";
            tBusquedaDNI.Size = new Size(403, 23);
            tBusquedaDNI.TabIndex = 6;
            tBusquedaDNI.Text = "Buscar por DNI";
            tBusquedaDNI.KeyDown += tBusquedaDNI_KeyDown;
            tBusquedaDNI.KeyPress += tBusquedaDNI_KeyPress;
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitulo.ForeColor = Color.Black;
            labelSubtitulo.Location = new Point(13, 28);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new Size(360, 15);
            labelSubtitulo.TabIndex = 5;
            labelSubtitulo.Text = "Busque los registros de un paciente por su DNI y nombre completo";
            // 
            // lFiltros
            // 
            lFiltros.AutoSize = true;
            lFiltros.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lFiltros.Location = new Point(13, 7);
            lFiltros.Name = "lFiltros";
            lFiltros.Size = new Size(159, 21);
            lFiltros.TabIndex = 5;
            lFiltros.Text = "Filtros de Búsqueda";
            // 
            // panelContenedorRegistros
            // 
            panelContenedorRegistros.Anchor = AnchorStyles.None;
            panelContenedorRegistros.AutoScroll = true;
            panelContenedorRegistros.BackColor = Color.White;
            panelContenedorRegistros.FlowDirection = FlowDirection.TopDown;
            panelContenedorRegistros.Location = new Point(29, 169);
            panelContenedorRegistros.Name = "panelContenedorRegistros";
            panelContenedorRegistros.Size = new Size(716, 396);
            panelContenedorRegistros.TabIndex = 5;
            panelContenedorRegistros.WrapContents = false;
            // 
            // HistorialClinicoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContenedorRegistros);
            Controls.Add(panelFiltros);
            Controls.Add(lSubtituloHC);
            Controls.Add(lTituloHC);
            Margin = new Padding(3, 2, 3, 2);
            Name = "HistorialClinicoControl";
            Load += HistorialClinicoControl_Load;
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lTituloHC;
        private Label lSubtituloHC;
        private Panel panelFiltros;
        private Label labelSubtitulo;
        private Label lFiltros;
        private Label lDniPaciente;
        private TextBox tBusquedaDNI;
        private DataGridView dgPaciente;
        private Button bAgregarRegistroPaciente;
        private FlowLayoutPanel panelContenedorRegistros;
        private Button bPdfRegistros;
    }
}
