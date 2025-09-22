namespace proyecto_Villarreal_SanLorenzo
{
    partial class VerUsuarioControl
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
            bAgregarUsuario = new Button();
            bEliminarUsuario = new Button();
            bEditarUsuario = new Button();
            lEmail = new Label();
            flowLayoutPanel6 = new FlowLayoutPanel();
            tbEmail = new TextBox();
            lTelefonoUsuario = new Label();
            lApellidoUsuario = new Label();
            lNomUsuario = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            tbNomUsuario = new TextBox();
            flowLayoutPanel7 = new FlowLayoutPanel();
            tbTelefono = new TextBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            tbApellidoUsuario = new TextBox();
            dataGridViewUsuarios = new DataGridView();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            SuspendLayout();
            // 
            // bAgregarUsuario
            // 
            bAgregarUsuario.Cursor = Cursors.Hand;
            bAgregarUsuario.FlatAppearance.BorderColor = Color.Silver;
            bAgregarUsuario.FlatAppearance.MouseDownBackColor = Color.LightGray;
            bAgregarUsuario.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            bAgregarUsuario.FlatStyle = FlatStyle.Flat;
            bAgregarUsuario.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bAgregarUsuario.ForeColor = Color.Black;
            bAgregarUsuario.Location = new Point(68, 251);
            bAgregarUsuario.Name = "bAgregarUsuario";
            bAgregarUsuario.Size = new Size(209, 29);
            bAgregarUsuario.TabIndex = 44;
            bAgregarUsuario.Text = "Agregar nuevo usuario";
            bAgregarUsuario.UseVisualStyleBackColor = true;
            bAgregarUsuario.Click += bAgregarUsuario_Click;
            // 
            // bEliminarUsuario
            // 
            bEliminarUsuario.Cursor = Cursors.Hand;
            bEliminarUsuario.FlatAppearance.BorderColor = Color.Silver;
            bEliminarUsuario.FlatAppearance.MouseDownBackColor = Color.LightGray;
            bEliminarUsuario.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            bEliminarUsuario.FlatStyle = FlatStyle.Flat;
            bEliminarUsuario.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bEliminarUsuario.ForeColor = Color.Black;
            bEliminarUsuario.Location = new Point(519, 251);
            bEliminarUsuario.Name = "bEliminarUsuario";
            bEliminarUsuario.Size = new Size(146, 29);
            bEliminarUsuario.TabIndex = 43;
            bEliminarUsuario.Text = "Eliminar usuario";
            bEliminarUsuario.UseVisualStyleBackColor = true;
            bEliminarUsuario.Click += bEliminarUsuario_Click;
            // 
            // bEditarUsuario
            // 
            bEditarUsuario.Cursor = Cursors.Hand;
            bEditarUsuario.FlatAppearance.BorderColor = Color.Silver;
            bEditarUsuario.FlatAppearance.MouseDownBackColor = Color.LightGray;
            bEditarUsuario.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            bEditarUsuario.FlatStyle = FlatStyle.Flat;
            bEditarUsuario.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bEditarUsuario.ForeColor = Color.Black;
            bEditarUsuario.Location = new Point(328, 251);
            bEditarUsuario.Name = "bEditarUsuario";
            bEditarUsuario.Size = new Size(141, 29);
            bEditarUsuario.TabIndex = 42;
            bEditarUsuario.Text = "Editar usuario";
            bEditarUsuario.UseVisualStyleBackColor = true;
            bEditarUsuario.Click += bEditarUsuario_Click;
            // 
            // lEmail
            // 
            lEmail.AccessibleRole = AccessibleRole.None;
            lEmail.AutoSize = true;
            lEmail.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lEmail.Location = new Point(422, 148);
            lEmail.Name = "lEmail";
            lEmail.Size = new Size(59, 25);
            lEmail.TabIndex = 40;
            lEmail.Text = "Email";
            lEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(tbEmail);
            flowLayoutPanel6.Location = new Point(422, 176);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(280, 37);
            flowLayoutPanel6.TabIndex = 41;
            // 
            // tbEmail
            // 
            tbEmail.Cursor = Cursors.Hand;
            tbEmail.ForeColor = Color.Black;
            tbEmail.Location = new Point(3, 3);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(266, 27);
            tbEmail.TabIndex = 18;
            // 
            // lTelefonoUsuario
            // 
            lTelefonoUsuario.AccessibleRole = AccessibleRole.None;
            lTelefonoUsuario.AutoSize = true;
            lTelefonoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTelefonoUsuario.Location = new Point(417, 60);
            lTelefonoUsuario.Name = "lTelefonoUsuario";
            lTelefonoUsuario.Size = new Size(85, 25);
            lTelefonoUsuario.TabIndex = 34;
            lTelefonoUsuario.Text = "Telefono";
            lTelefonoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lApellidoUsuario
            // 
            lApellidoUsuario.AccessibleRole = AccessibleRole.None;
            lApellidoUsuario.AutoSize = true;
            lApellidoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lApellidoUsuario.Location = new Point(65, 148);
            lApellidoUsuario.Name = "lApellidoUsuario";
            lApellidoUsuario.Size = new Size(83, 25);
            lApellidoUsuario.TabIndex = 35;
            lApellidoUsuario.Text = "Apellido";
            lApellidoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lNomUsuario
            // 
            lNomUsuario.AccessibleRole = AccessibleRole.None;
            lNomUsuario.AutoSize = true;
            lNomUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNomUsuario.Location = new Point(65, 57);
            lNomUsuario.Name = "lNomUsuario";
            lNomUsuario.Size = new Size(83, 25);
            lNomUsuario.TabIndex = 36;
            lNomUsuario.Text = "Nombre";
            lNomUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(tbNomUsuario);
            flowLayoutPanel4.Location = new Point(65, 87);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(301, 37);
            flowLayoutPanel4.TabIndex = 37;
            // 
            // tbNomUsuario
            // 
            tbNomUsuario.Cursor = Cursors.Hand;
            tbNomUsuario.ForeColor = Color.Black;
            tbNomUsuario.Location = new Point(3, 3);
            tbNomUsuario.Name = "tbNomUsuario";
            tbNomUsuario.Size = new Size(286, 27);
            tbNomUsuario.TabIndex = 18;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Controls.Add(tbTelefono);
            flowLayoutPanel7.Location = new Point(419, 88);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(283, 37);
            flowLayoutPanel7.TabIndex = 39;
            // 
            // tbTelefono
            // 
            tbTelefono.Cursor = Cursors.Hand;
            tbTelefono.ForeColor = Color.Black;
            tbTelefono.Location = new Point(3, 3);
            tbTelefono.Name = "tbTelefono";
            tbTelefono.Size = new Size(269, 27);
            tbTelefono.TabIndex = 18;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(tbApellidoUsuario);
            flowLayoutPanel5.Location = new Point(65, 176);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(301, 37);
            flowLayoutPanel5.TabIndex = 38;
            // 
            // tbApellidoUsuario
            // 
            tbApellidoUsuario.Cursor = Cursors.Hand;
            tbApellidoUsuario.ForeColor = Color.Black;
            tbApellidoUsuario.Location = new Point(3, 3);
            tbApellidoUsuario.Name = "tbApellidoUsuario";
            tbApellidoUsuario.Size = new Size(286, 27);
            tbApellidoUsuario.TabIndex = 18;
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.BackgroundColor = Color.White;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(33, 302);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.RowHeadersWidth = 51;
            dataGridViewUsuarios.Size = new Size(732, 270);
            dataGridViewUsuarios.TabIndex = 45;
            dataGridViewUsuarios.CellClick += dataGridViewUsuarios_CellClick;
            // 
            // VerUsuarioControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewUsuarios);
            Controls.Add(bAgregarUsuario);
            Controls.Add(bEliminarUsuario);
            Controls.Add(bEditarUsuario);
            Controls.Add(lEmail);
            Controls.Add(flowLayoutPanel6);
            Controls.Add(lTelefonoUsuario);
            Controls.Add(lApellidoUsuario);
            Controls.Add(lNomUsuario);
            Controls.Add(flowLayoutPanel4);
            Controls.Add(flowLayoutPanel7);
            Controls.Add(flowLayoutPanel5);
            Name = "VerUsuarioControl";
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bAgregarUsuario;
        private Button bEliminarUsuario;
        private Button bEditarUsuario;
        private Label lEmail;
        private FlowLayoutPanel flowLayoutPanel6;
        private TextBox tbEmail;
        private Label lTelefonoUsuario;
        private Label lApellidoUsuario;
        private Label lNomUsuario;
        private FlowLayoutPanel flowLayoutPanel4;
        private TextBox tbNomUsuario;
        private FlowLayoutPanel flowLayoutPanel7;
        private TextBox tbTelefono;
        private FlowLayoutPanel flowLayoutPanel5;
        private TextBox tbApellidoUsuario;
        private DataGridView dataGridViewUsuarios;
    }
}
