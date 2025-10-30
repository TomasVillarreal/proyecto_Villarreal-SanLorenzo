namespace proyecto_Villarreal_SanLorenzo
{
    partial class NuevoUsuarioControl
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
            lEspecialidad = new Label();
            lRol = new Label();
            lConfirmPass = new Label();
            lPassUsuario = new Label();
            lTelefonoUsuario = new Label();
            lEmail = new Label();
            lApellidoUsuario = new Label();
            lNomUsuario = new Label();
            lTitulo1 = new Label();
            tbNomUsuario = new TextBox();
            comboBoxEsp = new ComboBox();
            flowLayoutPanel8 = new FlowLayoutPanel();
            tbPassUsuario = new TextBox();
            bMostrarPass1 = new Button();
            flowLayoutPanel9 = new FlowLayoutPanel();
            tbConfirmPass = new TextBox();
            bMostrarConfPass2 = new Button();
            tbTelefono = new TextBox();
            tbEmail = new TextBox();
            tbApellidoUsuario = new TextBox();
            comboBoxRoles = new ComboBox();
            lErrorNombre = new Label();
            lErrorApellido = new Label();
            lErrorEmail = new Label();
            lErrorTelefono = new Label();
            lErrorConfirmPass = new Label();
            lErrorPass = new Label();
            bRegistrarUsuario = new Button();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            SuspendLayout();
            // 
            // lEspecialidad
            // 
            lEspecialidad.AccessibleRole = AccessibleRole.None;
            lEspecialidad.AutoSize = true;
            lEspecialidad.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lEspecialidad.Location = new Point(60, 410);
            lEspecialidad.Name = "lEspecialidad";
            lEspecialidad.Size = new Size(93, 20);
            lEspecialidad.TabIndex = 28;
            lEspecialidad.Text = "Especialidad";
            lEspecialidad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lRol
            // 
            lRol.AccessibleRole = AccessibleRole.None;
            lRol.AutoSize = true;
            lRol.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lRol.Location = new Point(60, 65);
            lRol.Name = "lRol";
            lRol.Size = new Size(31, 20);
            lRol.TabIndex = 43;
            lRol.Text = "Rol";
            lRol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lConfirmPass
            // 
            lConfirmPass.AccessibleRole = AccessibleRole.None;
            lConfirmPass.AutoSize = true;
            lConfirmPass.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lConfirmPass.Location = new Point(404, 331);
            lConfirmPass.Name = "lConfirmPass";
            lConfirmPass.Size = new Size(159, 20);
            lConfirmPass.TabIndex = 33;
            lConfirmPass.Text = "Confirmar Contraseña";
            lConfirmPass.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lPassUsuario
            // 
            lPassUsuario.AccessibleRole = AccessibleRole.None;
            lPassUsuario.AutoSize = true;
            lPassUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lPassUsuario.Location = new Point(60, 331);
            lPassUsuario.Name = "lPassUsuario";
            lPassUsuario.Size = new Size(86, 20);
            lPassUsuario.TabIndex = 34;
            lPassUsuario.Text = "Contraseña";
            lPassUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lTelefonoUsuario
            // 
            lTelefonoUsuario.AccessibleRole = AccessibleRole.None;
            lTelefonoUsuario.AutoSize = true;
            lTelefonoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTelefonoUsuario.Location = new Point(60, 263);
            lTelefonoUsuario.Name = "lTelefonoUsuario";
            lTelefonoUsuario.Size = new Size(68, 20);
            lTelefonoUsuario.TabIndex = 31;
            lTelefonoUsuario.Text = "Telefono";
            lTelefonoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lEmail
            // 
            lEmail.AccessibleRole = AccessibleRole.None;
            lEmail.AutoSize = true;
            lEmail.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lEmail.Location = new Point(60, 195);
            lEmail.Name = "lEmail";
            lEmail.Size = new Size(46, 20);
            lEmail.TabIndex = 30;
            lEmail.Text = "Email";
            lEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lApellidoUsuario
            // 
            lApellidoUsuario.AccessibleRole = AccessibleRole.None;
            lApellidoUsuario.AutoSize = true;
            lApellidoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lApellidoUsuario.Location = new Point(404, 128);
            lApellidoUsuario.Name = "lApellidoUsuario";
            lApellidoUsuario.Size = new Size(66, 20);
            lApellidoUsuario.TabIndex = 29;
            lApellidoUsuario.Text = "Apellido";
            lApellidoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lNomUsuario
            // 
            lNomUsuario.AccessibleRole = AccessibleRole.None;
            lNomUsuario.AutoSize = true;
            lNomUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNomUsuario.Location = new Point(60, 128);
            lNomUsuario.Name = "lNomUsuario";
            lNomUsuario.Size = new Size(66, 20);
            lNomUsuario.TabIndex = 32;
            lNomUsuario.Text = "Nombre";
            lNomUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lTitulo1
            // 
            lTitulo1.AutoSize = true;
            lTitulo1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTitulo1.Location = new Point(222, 15);
            lTitulo1.Name = "lTitulo1";
            lTitulo1.Size = new Size(313, 25);
            lTitulo1.TabIndex = 16;
            lTitulo1.Text = "Ingrese los datos del nuevo usuario";
            lTitulo1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbNomUsuario
            // 
            tbNomUsuario.Cursor = Cursors.Hand;
            tbNomUsuario.ForeColor = Color.Black;
            tbNomUsuario.Location = new Point(60, 150);
            tbNomUsuario.Margin = new Padding(3, 2, 3, 2);
            tbNomUsuario.Name = "tbNomUsuario";
            tbNomUsuario.Size = new Size(288, 23);
            tbNomUsuario.TabIndex = 1;
            tbNomUsuario.KeyPress += tbNomUsuario_KeyPress;
            // 
            // comboBoxEsp
            // 
            comboBoxEsp.ForeColor = Color.Black;
            comboBoxEsp.FormattingEnabled = true;
            comboBoxEsp.Items.AddRange(new object[] { "Clínica", "Obstetricia", "Pediatría", "Cardiología" });
            comboBoxEsp.Location = new Point(60, 432);
            comboBoxEsp.Margin = new Padding(3, 2, 3, 2);
            comboBoxEsp.Name = "comboBoxEsp";
            comboBoxEsp.Size = new Size(288, 23);
            comboBoxEsp.TabIndex = 7;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(tbPassUsuario);
            flowLayoutPanel8.Controls.Add(bMostrarPass1);
            flowLayoutPanel8.Location = new Point(60, 353);
            flowLayoutPanel8.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(297, 29);
            flowLayoutPanel8.TabIndex = 38;
            // 
            // tbPassUsuario
            // 
            tbPassUsuario.Cursor = Cursors.Hand;
            tbPassUsuario.ForeColor = Color.Black;
            tbPassUsuario.Location = new Point(3, 2);
            tbPassUsuario.Margin = new Padding(3, 2, 3, 2);
            tbPassUsuario.Name = "tbPassUsuario";
            tbPassUsuario.PasswordChar = '*';
            tbPassUsuario.Size = new Size(251, 23);
            tbPassUsuario.TabIndex = 5;
            // 
            // bMostrarPass1
            // 
            bMostrarPass1.Cursor = Cursors.Hand;
            bMostrarPass1.FlatAppearance.BorderColor = Color.Silver;
            bMostrarPass1.FlatAppearance.MouseDownBackColor = Color.LightGray;
            bMostrarPass1.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            bMostrarPass1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bMostrarPass1.ForeColor = Color.Black;
            bMostrarPass1.Image = Resource1.ojoCerrado;
            bMostrarPass1.Location = new Point(260, 2);
            bMostrarPass1.Margin = new Padding(3, 2, 3, 2);
            bMostrarPass1.Name = "bMostrarPass1";
            bMostrarPass1.Size = new Size(29, 22);
            bMostrarPass1.TabIndex = 20;
            bMostrarPass1.UseVisualStyleBackColor = true;
            bMostrarPass1.Click += bMostrarPass1_Click;
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.Controls.Add(tbConfirmPass);
            flowLayoutPanel9.Controls.Add(bMostrarConfPass2);
            flowLayoutPanel9.Location = new Point(404, 353);
            flowLayoutPanel9.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            flowLayoutPanel9.Size = new Size(297, 32);
            flowLayoutPanel9.TabIndex = 41;
            // 
            // tbConfirmPass
            // 
            tbConfirmPass.Cursor = Cursors.Hand;
            tbConfirmPass.ForeColor = Color.Black;
            tbConfirmPass.Location = new Point(3, 2);
            tbConfirmPass.Margin = new Padding(3, 2, 3, 2);
            tbConfirmPass.Name = "tbConfirmPass";
            tbConfirmPass.PasswordChar = '*';
            tbConfirmPass.Size = new Size(251, 23);
            tbConfirmPass.TabIndex = 6;
            // 
            // bMostrarConfPass2
            // 
            bMostrarConfPass2.Cursor = Cursors.Hand;
            bMostrarConfPass2.FlatAppearance.BorderColor = Color.Silver;
            bMostrarConfPass2.FlatAppearance.MouseDownBackColor = Color.LightGray;
            bMostrarConfPass2.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            bMostrarConfPass2.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bMostrarConfPass2.ForeColor = Color.Black;
            bMostrarConfPass2.Image = Resource1.ojoCerrado;
            bMostrarConfPass2.Location = new Point(260, 2);
            bMostrarConfPass2.Margin = new Padding(3, 2, 3, 2);
            bMostrarConfPass2.Name = "bMostrarConfPass2";
            bMostrarConfPass2.Size = new Size(29, 22);
            bMostrarConfPass2.TabIndex = 20;
            bMostrarConfPass2.UseVisualStyleBackColor = true;
            bMostrarConfPass2.Click += bMostrarConfPass2_Click;
            // 
            // tbTelefono
            // 
            tbTelefono.Cursor = Cursors.Hand;
            tbTelefono.ForeColor = Color.Black;
            tbTelefono.Location = new Point(60, 285);
            tbTelefono.Margin = new Padding(3, 2, 3, 2);
            tbTelefono.Name = "tbTelefono";
            tbTelefono.Size = new Size(631, 23);
            tbTelefono.TabIndex = 4;
            tbTelefono.KeyPress += tbTelefono_KeyPress;
            // 
            // tbEmail
            // 
            tbEmail.Cursor = Cursors.Hand;
            tbEmail.ForeColor = Color.Black;
            tbEmail.Location = new Point(60, 217);
            tbEmail.Margin = new Padding(3, 2, 3, 2);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(631, 23);
            tbEmail.TabIndex = 3;
            // 
            // tbApellidoUsuario
            // 
            tbApellidoUsuario.Cursor = Cursors.Hand;
            tbApellidoUsuario.ForeColor = Color.Black;
            tbApellidoUsuario.Location = new Point(403, 150);
            tbApellidoUsuario.Margin = new Padding(3, 2, 3, 2);
            tbApellidoUsuario.Name = "tbApellidoUsuario";
            tbApellidoUsuario.Size = new Size(288, 23);
            tbApellidoUsuario.TabIndex = 2;
            tbApellidoUsuario.KeyPress += tbApellidoUsuario_KeyPress;
            // 
            // comboBoxRoles
            // 
            comboBoxRoles.FormattingEnabled = true;
            comboBoxRoles.Location = new Point(60, 87);
            comboBoxRoles.Margin = new Padding(3, 2, 3, 2);
            comboBoxRoles.Name = "comboBoxRoles";
            comboBoxRoles.Size = new Size(288, 23);
            comboBoxRoles.TabIndex = 0;
            comboBoxRoles.SelectedIndexChanged += comboBoxRoles_SelectedIndexChanged;
            // 
            // lErrorNombre
            // 
            lErrorNombre.AutoSize = true;
            lErrorNombre.ForeColor = Color.Red;
            lErrorNombre.Location = new Point(60, 175);
            lErrorNombre.Name = "lErrorNombre";
            lErrorNombre.Size = new Size(38, 15);
            lErrorNombre.TabIndex = 44;
            lErrorNombre.Text = "label1";
            lErrorNombre.Visible = false;
            // 
            // lErrorApellido
            // 
            lErrorApellido.AutoSize = true;
            lErrorApellido.ForeColor = Color.Red;
            lErrorApellido.Location = new Point(404, 175);
            lErrorApellido.Name = "lErrorApellido";
            lErrorApellido.Size = new Size(38, 15);
            lErrorApellido.TabIndex = 45;
            lErrorApellido.Text = "label2";
            lErrorApellido.Visible = false;
            // 
            // lErrorEmail
            // 
            lErrorEmail.AutoSize = true;
            lErrorEmail.ForeColor = Color.Red;
            lErrorEmail.Location = new Point(60, 242);
            lErrorEmail.Name = "lErrorEmail";
            lErrorEmail.Size = new Size(38, 15);
            lErrorEmail.TabIndex = 46;
            lErrorEmail.Text = "label3";
            lErrorEmail.Visible = false;
            // 
            // lErrorTelefono
            // 
            lErrorTelefono.AutoSize = true;
            lErrorTelefono.ForeColor = Color.Red;
            lErrorTelefono.Location = new Point(60, 310);
            lErrorTelefono.Name = "lErrorTelefono";
            lErrorTelefono.Size = new Size(38, 15);
            lErrorTelefono.TabIndex = 47;
            lErrorTelefono.Text = "label4";
            lErrorTelefono.Visible = false;
            // 
            // lErrorConfirmPass
            // 
            lErrorConfirmPass.AutoSize = true;
            lErrorConfirmPass.ForeColor = Color.Red;
            lErrorConfirmPass.Location = new Point(407, 380);
            lErrorConfirmPass.Name = "lErrorConfirmPass";
            lErrorConfirmPass.Size = new Size(38, 15);
            lErrorConfirmPass.TabIndex = 49;
            lErrorConfirmPass.Text = "label6";
            lErrorConfirmPass.Visible = false;
            // 
            // lErrorPass
            // 
            lErrorPass.AutoSize = true;
            lErrorPass.ForeColor = Color.Red;
            lErrorPass.Location = new Point(60, 380);
            lErrorPass.Name = "lErrorPass";
            lErrorPass.Size = new Size(38, 15);
            lErrorPass.TabIndex = 48;
            lErrorPass.Text = "label5";
            lErrorPass.Visible = false;
            // 
            // bRegistrarUsuario
            // 
            bRegistrarUsuario.BackColor = Color.Black;
            bRegistrarUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bRegistrarUsuario.ForeColor = Color.White;
            bRegistrarUsuario.Location = new Point(263, 474);
            bRegistrarUsuario.Name = "bRegistrarUsuario";
            bRegistrarUsuario.Size = new Size(207, 34);
            bRegistrarUsuario.TabIndex = 50;
            bRegistrarUsuario.Text = "Registrar usuario";
            bRegistrarUsuario.UseVisualStyleBackColor = false;
            // 
            // NuevoUsuarioControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bRegistrarUsuario);
            Controls.Add(lErrorConfirmPass);
            Controls.Add(lErrorPass);
            Controls.Add(lErrorTelefono);
            Controls.Add(lErrorEmail);
            Controls.Add(lErrorApellido);
            Controls.Add(lErrorNombre);
            Controls.Add(comboBoxEsp);
            Controls.Add(tbTelefono);
            Controls.Add(tbEmail);
            Controls.Add(tbApellidoUsuario);
            Controls.Add(tbNomUsuario);
            Controls.Add(comboBoxRoles);
            Controls.Add(lTitulo1);
            Controls.Add(lEspecialidad);
            Controls.Add(lRol);
            Controls.Add(lConfirmPass);
            Controls.Add(lPassUsuario);
            Controls.Add(lTelefonoUsuario);
            Controls.Add(lEmail);
            Controls.Add(lApellidoUsuario);
            Controls.Add(lNomUsuario);
            Controls.Add(flowLayoutPanel8);
            Controls.Add(flowLayoutPanel9);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NuevoUsuarioControl";
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lEspecialidad;
        private Label lRol;
        private Label lConfirmPass;
        private Label lPassUsuario;
        private Label lTelefonoUsuario;
        private Label lEmail;
        private Label lApellidoUsuario;
        private Label lNomUsuario;
        private Label lTitulo1;
        private TextBox tbNomUsuario;
        private ComboBox comboBoxEsp;
        private FlowLayoutPanel flowLayoutPanel8;
        private TextBox tbPassUsuario;
        private Button bMostrarPass1;
        private FlowLayoutPanel flowLayoutPanel9;
        private TextBox tbConfirmPass;
        private Button bMostrarConfPass2;
        private TextBox tbTelefono;
        private TextBox tbEmail;
        private TextBox tbApellidoUsuario;
        private ComboBox comboBoxRoles;
        private Label lErrorNombre;
        private Label lErrorApellido;
        private Label lErrorEmail;
        private Label lErrorTelefono;
        private Label lErrorConfirmPass;
        private Label lErrorPass;
        private Button bRegistrarUsuario;
    }
}
