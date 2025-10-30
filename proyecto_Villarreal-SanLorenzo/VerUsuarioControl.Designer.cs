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
            bEliminarUsuario = new Button();
            lEmail = new Label();
            tbEmail = new TextBox();
            lTelefonoUsuario = new Label();
            lApellidoUsuario = new Label();
            lNomUsuario = new Label();
            tbNomUsuario = new TextBox();
            tbTelefono = new TextBox();
            tbApellidoUsuario = new TextBox();
            dataGridViewUsuarios = new DataGridView();
            lErrorNombre = new Label();
            lErrorApellido = new Label();
            lErrorEmail = new Label();
            lErrorTelefono = new Label();
            lSubtituloPacientes = new Label();
            lTituloPacientes = new Label();
            rbUsuariosVisibles = new RadioButton();
            rbUsuariosEliminados = new RadioButton();
            bEditarUsuario = new Button();
            bAgregarUsuario = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            SuspendLayout();
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
            bEliminarUsuario.Location = new Point(427, 307);
            bEliminarUsuario.Margin = new Padding(3, 2, 3, 2);
            bEliminarUsuario.Name = "bEliminarUsuario";
            bEliminarUsuario.Size = new Size(128, 30);
            bEliminarUsuario.TabIndex = 6;
            bEliminarUsuario.Text = "Eliminar usuario";
            bEliminarUsuario.UseVisualStyleBackColor = true;
            bEliminarUsuario.Click += bEliminarUsuario_Click;
            // 
            // lEmail
            // 
            lEmail.AccessibleRole = AccessibleRole.None;
            lEmail.AutoSize = true;
            lEmail.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lEmail.Location = new Point(60, 161);
            lEmail.Name = "lEmail";
            lEmail.Size = new Size(46, 20);
            lEmail.TabIndex = 40;
            lEmail.Text = "Email";
            lEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbEmail
            // 
            tbEmail.Cursor = Cursors.Hand;
            tbEmail.ForeColor = Color.Black;
            tbEmail.Location = new Point(60, 183);
            tbEmail.Margin = new Padding(3, 2, 3, 2);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(645, 23);
            tbEmail.TabIndex = 2;
            // 
            // lTelefonoUsuario
            // 
            lTelefonoUsuario.AccessibleRole = AccessibleRole.None;
            lTelefonoUsuario.AutoSize = true;
            lTelefonoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTelefonoUsuario.Location = new Point(60, 235);
            lTelefonoUsuario.Name = "lTelefonoUsuario";
            lTelefonoUsuario.Size = new Size(68, 20);
            lTelefonoUsuario.TabIndex = 34;
            lTelefonoUsuario.Text = "Telefono";
            lTelefonoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lApellidoUsuario
            // 
            lApellidoUsuario.AccessibleRole = AccessibleRole.None;
            lApellidoUsuario.AutoSize = true;
            lApellidoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lApellidoUsuario.Location = new Point(417, 83);
            lApellidoUsuario.Name = "lApellidoUsuario";
            lApellidoUsuario.Size = new Size(66, 20);
            lApellidoUsuario.TabIndex = 35;
            lApellidoUsuario.Text = "Apellido";
            lApellidoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lNomUsuario
            // 
            lNomUsuario.AccessibleRole = AccessibleRole.None;
            lNomUsuario.AutoSize = true;
            lNomUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNomUsuario.Location = new Point(57, 83);
            lNomUsuario.Name = "lNomUsuario";
            lNomUsuario.Size = new Size(66, 20);
            lNomUsuario.TabIndex = 36;
            lNomUsuario.Text = "Nombre";
            lNomUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbNomUsuario
            // 
            tbNomUsuario.Cursor = Cursors.Hand;
            tbNomUsuario.ForeColor = Color.Black;
            tbNomUsuario.Location = new Point(60, 105);
            tbNomUsuario.Margin = new Padding(3, 2, 3, 2);
            tbNomUsuario.Name = "tbNomUsuario";
            tbNomUsuario.Size = new Size(288, 23);
            tbNomUsuario.TabIndex = 0;
            tbNomUsuario.KeyPress += tbTextoCaracteresPacienteRegistro_KeyPress;
            // 
            // tbTelefono
            // 
            tbTelefono.Cursor = Cursors.Hand;
            tbTelefono.ForeColor = Color.Black;
            tbTelefono.Location = new Point(60, 257);
            tbTelefono.Margin = new Padding(3, 2, 3, 2);
            tbTelefono.Name = "tbTelefono";
            tbTelefono.Size = new Size(645, 23);
            tbTelefono.TabIndex = 3;
            tbTelefono.KeyPress += tbNumerico_KeyPress;
            // 
            // tbApellidoUsuario
            // 
            tbApellidoUsuario.Cursor = Cursors.Hand;
            tbApellidoUsuario.ForeColor = Color.Black;
            tbApellidoUsuario.Location = new Point(417, 105);
            tbApellidoUsuario.Margin = new Padding(3, 2, 3, 2);
            tbApellidoUsuario.Name = "tbApellidoUsuario";
            tbApellidoUsuario.Size = new Size(288, 23);
            tbApellidoUsuario.TabIndex = 1;
            tbApellidoUsuario.KeyPress += tbTextoCaracteresPacienteRegistro_KeyPress;
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.BackgroundColor = Color.White;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(57, 352);
            dataGridViewUsuarios.Margin = new Padding(3, 2, 3, 2);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.RowHeadersWidth = 51;
            dataGridViewUsuarios.Size = new Size(648, 189);
            dataGridViewUsuarios.TabIndex = 45;
            dataGridViewUsuarios.CellClick += dataGridViewUsuarios_CellClick;
            // 
            // lErrorNombre
            // 
            lErrorNombre.AutoSize = true;
            lErrorNombre.ForeColor = Color.Red;
            lErrorNombre.Location = new Point(60, 130);
            lErrorNombre.Name = "lErrorNombre";
            lErrorNombre.Size = new Size(38, 15);
            lErrorNombre.TabIndex = 46;
            lErrorNombre.Text = "label1";
            lErrorNombre.Visible = false;
            // 
            // lErrorApellido
            // 
            lErrorApellido.AutoSize = true;
            lErrorApellido.ForeColor = Color.Red;
            lErrorApellido.Location = new Point(417, 130);
            lErrorApellido.Name = "lErrorApellido";
            lErrorApellido.Size = new Size(38, 15);
            lErrorApellido.TabIndex = 47;
            lErrorApellido.Text = "label2";
            lErrorApellido.Visible = false;
            // 
            // lErrorEmail
            // 
            lErrorEmail.AutoSize = true;
            lErrorEmail.ForeColor = Color.Red;
            lErrorEmail.Location = new Point(60, 208);
            lErrorEmail.Name = "lErrorEmail";
            lErrorEmail.Size = new Size(38, 15);
            lErrorEmail.TabIndex = 48;
            lErrorEmail.Text = "label3";
            lErrorEmail.Visible = false;
            // 
            // lErrorTelefono
            // 
            lErrorTelefono.AutoSize = true;
            lErrorTelefono.ForeColor = Color.Red;
            lErrorTelefono.Location = new Point(60, 282);
            lErrorTelefono.Name = "lErrorTelefono";
            lErrorTelefono.Size = new Size(38, 15);
            lErrorTelefono.TabIndex = 49;
            lErrorTelefono.Text = "label4";
            lErrorTelefono.Visible = false;
            // 
            // lSubtituloPacientes
            // 
            lSubtituloPacientes.AutoSize = true;
            lSubtituloPacientes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtituloPacientes.ForeColor = SystemColors.ControlDark;
            lSubtituloPacientes.Location = new Point(60, 49);
            lSubtituloPacientes.Name = "lSubtituloPacientes";
            lSubtituloPacientes.Size = new Size(169, 15);
            lSubtituloPacientes.TabIndex = 51;
            lSubtituloPacientes.Text = "Sistema de gestion de usuarios";
            // 
            // lTituloPacientes
            // 
            lTituloPacientes.AutoSize = true;
            lTituloPacientes.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTituloPacientes.Location = new Point(57, 24);
            lTituloPacientes.Name = "lTituloPacientes";
            lTituloPacientes.Size = new Size(189, 25);
            lTituloPacientes.TabIndex = 50;
            lTituloPacientes.Text = "Gestion de Usuarios";
            // 
            // rbUsuariosVisibles
            // 
            rbUsuariosVisibles.AutoSize = true;
            rbUsuariosVisibles.Checked = true;
            rbUsuariosVisibles.Location = new Point(582, 295);
            rbUsuariosVisibles.Name = "rbUsuariosVisibles";
            rbUsuariosVisibles.Size = new Size(112, 19);
            rbUsuariosVisibles.TabIndex = 52;
            rbUsuariosVisibles.TabStop = true;
            rbUsuariosVisibles.Text = "Usuarios Visibles";
            rbUsuariosVisibles.UseVisualStyleBackColor = true;
            rbUsuariosVisibles.CheckedChanged += rbUsuariosVisibles_CheckedChanged;
            // 
            // rbUsuariosEliminados
            // 
            rbUsuariosEliminados.AutoSize = true;
            rbUsuariosEliminados.Location = new Point(582, 318);
            rbUsuariosEliminados.Name = "rbUsuariosEliminados";
            rbUsuariosEliminados.Size = new Size(131, 19);
            rbUsuariosEliminados.TabIndex = 53;
            rbUsuariosEliminados.Text = "Usuarios Eliminados";
            rbUsuariosEliminados.UseVisualStyleBackColor = true;
            rbUsuariosEliminados.CheckedChanged += rbUsuariosEliminados_CheckedChanged;
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
            bEditarUsuario.Location = new Point(270, 307);
            bEditarUsuario.Margin = new Padding(3, 2, 3, 2);
            bEditarUsuario.Name = "bEditarUsuario";
            bEditarUsuario.Size = new Size(123, 30);
            bEditarUsuario.TabIndex = 4;
            bEditarUsuario.Text = "Editar usuario";
            bEditarUsuario.UseVisualStyleBackColor = true;
            bEditarUsuario.Click += bEditarUsuario_Click;
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
            bAgregarUsuario.Location = new Point(57, 307);
            bAgregarUsuario.Margin = new Padding(3, 2, 3, 2);
            bAgregarUsuario.Name = "bAgregarUsuario";
            bAgregarUsuario.Size = new Size(183, 30);
            bAgregarUsuario.TabIndex = 5;
            bAgregarUsuario.Text = "Agregar nuevo usuario";
            bAgregarUsuario.UseVisualStyleBackColor = true;
            bAgregarUsuario.Click += bAgregarUsuario_Click;
            // 
            // VerUsuarioControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rbUsuariosEliminados);
            Controls.Add(rbUsuariosVisibles);
            Controls.Add(lSubtituloPacientes);
            Controls.Add(lTituloPacientes);
            Controls.Add(lErrorTelefono);
            Controls.Add(lErrorEmail);
            Controls.Add(tbEmail);
            Controls.Add(tbTelefono);
            Controls.Add(lErrorApellido);
            Controls.Add(lErrorNombre);
            Controls.Add(tbApellidoUsuario);
            Controls.Add(tbNomUsuario);
            Controls.Add(dataGridViewUsuarios);
            Controls.Add(bAgregarUsuario);
            Controls.Add(bEliminarUsuario);
            Controls.Add(bEditarUsuario);
            Controls.Add(lEmail);
            Controls.Add(lTelefonoUsuario);
            Controls.Add(lApellidoUsuario);
            Controls.Add(lNomUsuario);
            Margin = new Padding(3, 2, 3, 2);
            Name = "VerUsuarioControl";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bAgregarUsuario1;
        private Button bEliminarUsuario;
        private Button bEditarUsuario1;
        private Label lEmail;
        private TextBox tbEmail;
        private Label lTelefonoUsuario;
        private Label lApellidoUsuario;
        private Label lNomUsuario;
        private TextBox tbNomUsuario;
        private TextBox tbTelefono;
        private TextBox tbApellidoUsuario;
        private DataGridView dataGridViewUsuarios;
        private Label lErrorNombre;
        private Label lErrorApellido;
        private Label lErrorEmail;
        private Label lErrorTelefono;
        private Label lSubtituloPacientes;
        private Label lTituloPacientes;
        private RadioButton rbUsuariosVisibles;
        private RadioButton rbUsuariosEliminados;
        private Button bEditarUsuario;
        private Button bAgregarUsuario;
    }
}
