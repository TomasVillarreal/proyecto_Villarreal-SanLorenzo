namespace proyecto_Villarreal_SanLorenzo
{
    partial class PersonalControl
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
            dgPersonal = new DataGridView();
            cDniPersonal = new DataGridViewTextBoxColumn();
            cNombrePersonal = new DataGridViewTextBoxColumn();
            cRol = new DataGridViewTextBoxColumn();
            cTelefonoPersonal = new DataGridViewTextBoxColumn();
            cEmailPersonal = new DataGridViewTextBoxColumn();
            cEditarPersonal = new DataGridViewButtonColumn();
            cEliminarPersonal = new DataGridViewButtonColumn();
            tBusquedaPersonal = new TextBox();
            lListaPersonal = new Label();
            lTituloPersonal = new Label();
            lSubtituloPersonal = new Label();
            bRegistrarPersonal = new Button();
            panelBordes1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgPersonal).BeginInit();
            SuspendLayout();
            // 
            // panelBordes1
            // 
            panelBordes1.BackColor = Color.White;
            panelBordes1.Controls.Add(dgPersonal);
            panelBordes1.Controls.Add(tBusquedaPersonal);
            panelBordes1.Controls.Add(lListaPersonal);
            panelBordes1.Location = new Point(23, 131);
            panelBordes1.Name = "panelBordes1";
            panelBordes1.Size = new Size(723, 417);
            panelBordes1.TabIndex = 0;
            // 
            // dgPersonal
            // 
            dgPersonal.AllowUserToAddRows = false;
            dgPersonal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPersonal.BackgroundColor = Color.White;
            dgPersonal.BorderStyle = BorderStyle.None;
            dgPersonal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPersonal.Columns.AddRange(new DataGridViewColumn[] { cDniPersonal, cNombrePersonal, cRol, cTelefonoPersonal, cEmailPersonal, cEditarPersonal, cEliminarPersonal });
            dgPersonal.Location = new Point(13, 81);
            dgPersonal.Name = "dgPersonal";
            dgPersonal.Size = new Size(697, 322);
            dgPersonal.TabIndex = 4;
            dgPersonal.CellContentClick += dgPaciente_CellContentClick;
            // 
            // cDniPersonal
            // 
            cDniPersonal.HeaderText = "DNI";
            cDniPersonal.Name = "cDniPersonal";
            // 
            // cNombrePersonal
            // 
            cNombrePersonal.HeaderText = "Nombre";
            cNombrePersonal.Name = "cNombrePersonal";
            // 
            // cRol
            // 
            cRol.HeaderText = "Rol";
            cRol.Name = "cRol";
            // 
            // cTelefonoPersonal
            // 
            cTelefonoPersonal.HeaderText = "Telefono";
            cTelefonoPersonal.Name = "cTelefonoPersonal";
            // 
            // cEmailPersonal
            // 
            cEmailPersonal.HeaderText = "Email";
            cEmailPersonal.Name = "cEmailPersonal";
            cEmailPersonal.Resizable = DataGridViewTriState.True;
            cEmailPersonal.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cEditarPersonal
            // 
            cEditarPersonal.HeaderText = "Editar";
            cEditarPersonal.Name = "cEditarPersonal";
            cEditarPersonal.Text = "Editar";
            // 
            // cEliminarPersonal
            // 
            cEliminarPersonal.HeaderText = "Eliminar";
            cEliminarPersonal.Name = "cEliminarPersonal";
            cEliminarPersonal.Text = "Eliminar";
            // 
            // tBusquedaPersonal
            // 
            tBusquedaPersonal.ForeColor = SystemColors.ActiveBorder;
            tBusquedaPersonal.Location = new Point(13, 36);
            tBusquedaPersonal.Name = "tBusquedaPersonal";
            tBusquedaPersonal.Size = new Size(248, 23);
            tBusquedaPersonal.TabIndex = 3;
            tBusquedaPersonal.Text = "Buscar por DNI";
            // 
            // lListaPersonal
            // 
            lListaPersonal.AutoSize = true;
            lListaPersonal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lListaPersonal.Location = new Point(12, 12);
            lListaPersonal.Name = "lListaPersonal";
            lListaPersonal.Size = new Size(131, 21);
            lListaPersonal.TabIndex = 2;
            lListaPersonal.Text = "Lista de Personal";
            // 
            // lTituloPersonal
            // 
            lTituloPersonal.AutoSize = true;
            lTituloPersonal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloPersonal.Location = new Point(23, 42);
            lTituloPersonal.Name = "lTituloPersonal";
            lTituloPersonal.Size = new Size(188, 25);
            lTituloPersonal.TabIndex = 1;
            lTituloPersonal.Text = "Gestion de Personal";
            // 
            // lSubtituloPersonal
            // 
            lSubtituloPersonal.AutoSize = true;
            lSubtituloPersonal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtituloPersonal.ForeColor = SystemColors.ControlDark;
            lSubtituloPersonal.Location = new Point(23, 67);
            lSubtituloPersonal.Name = "lSubtituloPersonal";
            lSubtituloPersonal.Size = new Size(290, 15);
            lSubtituloPersonal.TabIndex = 2;
            lSubtituloPersonal.Text = "Sistema de registro y gestion del personal de la clinica";
            // 
            // bRegistrarPersonal
            // 
            bRegistrarPersonal.BackColor = SystemColors.Highlight;
            bRegistrarPersonal.ForeColor = Color.Transparent;
            bRegistrarPersonal.Image = Resource1.plus_icon;
            bRegistrarPersonal.Location = new Point(637, 42);
            bRegistrarPersonal.Name = "bRegistrarPersonal";
            bRegistrarPersonal.Size = new Size(96, 40);
            bRegistrarPersonal.TabIndex = 3;
            bRegistrarPersonal.Text = "Registrar Personal";
            bRegistrarPersonal.TextImageRelation = TextImageRelation.ImageBeforeText;
            bRegistrarPersonal.UseVisualStyleBackColor = false;
            bRegistrarPersonal.Click += bRegistrarPersonal_Click;
            // 
            // PersonalControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bRegistrarPersonal);
            Controls.Add(lSubtituloPersonal);
            Controls.Add(lTituloPersonal);
            Controls.Add(panelBordes1);
            Name = "PersonalControl";
            panelBordes1.ResumeLayout(false);
            panelBordes1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgPersonal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PanelBordes panelBordes1;
        private Label lTituloPersonal;
        private Label lSubtituloPersonal;
        private Button bRegistrarPersonal;
        private TextBox tBusquedaPersonal;
        private Label lListaPersonal;
        private DataGridView dgPersonal;
        private DataGridViewTextBoxColumn cDniPersonal;
        private DataGridViewTextBoxColumn cNombrePersonal;
        private DataGridViewTextBoxColumn cRol;
        private DataGridViewTextBoxColumn cTelefonoPersonal;
        private DataGridViewTextBoxColumn cEmailPersonal;
        private DataGridViewButtonColumn cEditarPersonal;
        private DataGridViewButtonColumn cEliminarPersonal;
    }
}
