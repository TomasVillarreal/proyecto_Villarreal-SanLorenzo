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
            flowLayoutPanel3 = new FlowLayoutPanel();
            comboBoxRoles = new ComboBox();
            lConfirmPass = new Label();
            lPassUsuario = new Label();
            lTelefonoUsuario = new Label();
            lEmail = new Label();
            lApellidoUsuario = new Label();
            lNomUsuario = new Label();
            bRegistrarUsuario = new Button();
            lTitulo1 = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            tbNomUsuario = new TextBox();
            flowLayoutPanel10 = new FlowLayoutPanel();
            comboBoxEsp = new ComboBox();
            flowLayoutPanel8 = new FlowLayoutPanel();
            tbPassUsuario = new TextBox();
            bMostrarPass1 = new Button();
            flowLayoutPanel9 = new FlowLayoutPanel();
            tbConfirmPass = new TextBox();
            bMostrarConfPass2 = new Button();
            flowLayoutPanel7 = new FlowLayoutPanel();
            tbTelefono = new TextBox();
            flowLayoutPanel6 = new FlowLayoutPanel();
            tbEmail = new TextBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            tbApellidoUsuario = new TextBox();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel10.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // lEspecialidad
            // 
            lEspecialidad.AccessibleRole = AccessibleRole.None;
            lEspecialidad.AutoSize = true;
            lEspecialidad.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lEspecialidad.Location = new Point(427, 402);
            lEspecialidad.Name = "lEspecialidad";
            lEspecialidad.Size = new Size(117, 25);
            lEspecialidad.TabIndex = 28;
            lEspecialidad.Text = "Especialidad";
            lEspecialidad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lRol
            // 
            lRol.AccessibleRole = AccessibleRole.None;
            lRol.AutoSize = true;
            lRol.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lRol.Location = new Point(25, 76);
            lRol.Name = "lRol";
            lRol.Size = new Size(39, 25);
            lRol.TabIndex = 43;
            lRol.Text = "Rol";
            lRol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(comboBoxRoles);
            flowLayoutPanel3.Location = new Point(25, 104);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(303, 37);
            flowLayoutPanel3.TabIndex = 44;
            // 
            // comboBoxRoles
            // 
            comboBoxRoles.FormattingEnabled = true;
            comboBoxRoles.Location = new Point(3, 3);
            comboBoxRoles.Name = "comboBoxRoles";
            comboBoxRoles.Size = new Size(286, 28);
            comboBoxRoles.TabIndex = 0;
            comboBoxRoles.SelectedIndexChanged += comboBoxRoles_SelectedIndexChanged;
            // 
            // lConfirmPass
            // 
            lConfirmPass.AccessibleRole = AccessibleRole.None;
            lConfirmPass.AutoSize = true;
            lConfirmPass.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lConfirmPass.Location = new Point(427, 289);
            lConfirmPass.Name = "lConfirmPass";
            lConfirmPass.Size = new Size(201, 25);
            lConfirmPass.TabIndex = 33;
            lConfirmPass.Text = "Confirmar Contraseña";
            lConfirmPass.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lPassUsuario
            // 
            lPassUsuario.AccessibleRole = AccessibleRole.None;
            lPassUsuario.AutoSize = true;
            lPassUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lPassUsuario.Location = new Point(427, 167);
            lPassUsuario.Name = "lPassUsuario";
            lPassUsuario.Size = new Size(109, 25);
            lPassUsuario.TabIndex = 34;
            lPassUsuario.Text = "Contraseña";
            lPassUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lTelefonoUsuario
            // 
            lTelefonoUsuario.AccessibleRole = AccessibleRole.None;
            lTelefonoUsuario.AutoSize = true;
            lTelefonoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTelefonoUsuario.Location = new Point(23, 402);
            lTelefonoUsuario.Name = "lTelefonoUsuario";
            lTelefonoUsuario.Size = new Size(85, 25);
            lTelefonoUsuario.TabIndex = 31;
            lTelefonoUsuario.Text = "Telefono";
            lTelefonoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lEmail
            // 
            lEmail.AccessibleRole = AccessibleRole.None;
            lEmail.AutoSize = true;
            lEmail.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lEmail.Location = new Point(433, 76);
            lEmail.Name = "lEmail";
            lEmail.Size = new Size(59, 25);
            lEmail.TabIndex = 30;
            lEmail.Text = "Email";
            lEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lApellidoUsuario
            // 
            lApellidoUsuario.AccessibleRole = AccessibleRole.None;
            lApellidoUsuario.AutoSize = true;
            lApellidoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lApellidoUsuario.Location = new Point(25, 289);
            lApellidoUsuario.Name = "lApellidoUsuario";
            lApellidoUsuario.Size = new Size(83, 25);
            lApellidoUsuario.TabIndex = 29;
            lApellidoUsuario.Text = "Apellido";
            lApellidoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lNomUsuario
            // 
            lNomUsuario.AccessibleRole = AccessibleRole.None;
            lNomUsuario.AutoSize = true;
            lNomUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNomUsuario.Location = new Point(25, 167);
            lNomUsuario.Name = "lNomUsuario";
            lNomUsuario.Size = new Size(83, 25);
            lNomUsuario.TabIndex = 32;
            lNomUsuario.Text = "Nombre";
            lNomUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bRegistrarUsuario
            // 
            bRegistrarUsuario.BackColor = Color.White;
            bRegistrarUsuario.Cursor = Cursors.Hand;
            bRegistrarUsuario.FlatAppearance.BorderColor = Color.Silver;
            bRegistrarUsuario.FlatAppearance.MouseDownBackColor = Color.LightGray;
            bRegistrarUsuario.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            bRegistrarUsuario.FlatStyle = FlatStyle.Flat;
            bRegistrarUsuario.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bRegistrarUsuario.ForeColor = Color.Black;
            bRegistrarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            bRegistrarUsuario.Location = new Point(255, 496);
            bRegistrarUsuario.Name = "bRegistrarUsuario";
            bRegistrarUsuario.Size = new Size(237, 47);
            bRegistrarUsuario.TabIndex = 42;
            bRegistrarUsuario.Text = "Registrar usuario";
            bRegistrarUsuario.UseVisualStyleBackColor = false;
            bRegistrarUsuario.Click += bRegistrarUsuario_Click;
            // 
            // lTitulo1
            // 
            lTitulo1.AutoSize = true;
            lTitulo1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTitulo1.Location = new Point(179, 19);
            lTitulo1.Name = "lTitulo1";
            lTitulo1.Size = new Size(399, 32);
            lTitulo1.TabIndex = 16;
            lTitulo1.Text = "Ingrese los datos del nuevo usuario";
            lTitulo1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(tbNomUsuario);
            flowLayoutPanel4.Location = new Point(25, 197);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(303, 37);
            flowLayoutPanel4.TabIndex = 35;
            // 
            // tbNomUsuario
            // 
            tbNomUsuario.Cursor = Cursors.Hand;
            tbNomUsuario.ForeColor = Color.Black;
            tbNomUsuario.Location = new Point(3, 3);
            tbNomUsuario.Name = "tbNomUsuario";
            tbNomUsuario.Size = new Size(286, 27);
            tbNomUsuario.TabIndex = 18;
            tbNomUsuario.KeyPress += tbNomUsuario_KeyPress;
            // 
            // flowLayoutPanel10
            // 
            flowLayoutPanel10.Controls.Add(comboBoxEsp);
            flowLayoutPanel10.Location = new Point(426, 433);
            flowLayoutPanel10.Name = "flowLayoutPanel10";
            flowLayoutPanel10.Size = new Size(312, 36);
            flowLayoutPanel10.TabIndex = 40;
            // 
            // comboBoxEsp
            // 
            comboBoxEsp.ForeColor = Color.Black;
            comboBoxEsp.FormattingEnabled = true;
            comboBoxEsp.Items.AddRange(new object[] { "Clínica", "Obstetricia", "Pediatría", "Cardiología" });
            comboBoxEsp.Location = new Point(3, 3);
            comboBoxEsp.Name = "comboBoxEsp";
            comboBoxEsp.Size = new Size(292, 28);
            comboBoxEsp.TabIndex = 25;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(tbPassUsuario);
            flowLayoutPanel8.Controls.Add(bMostrarPass1);
            flowLayoutPanel8.Location = new Point(430, 200);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(339, 39);
            flowLayoutPanel8.TabIndex = 38;
            // 
            // tbPassUsuario
            // 
            tbPassUsuario.Cursor = Cursors.Hand;
            tbPassUsuario.ForeColor = Color.Black;
            tbPassUsuario.Location = new Point(3, 3);
            tbPassUsuario.Name = "tbPassUsuario";
            tbPassUsuario.PasswordChar = '*';
            tbPassUsuario.Size = new Size(286, 27);
            tbPassUsuario.TabIndex = 18;
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
            bMostrarPass1.Location = new Point(295, 3);
            bMostrarPass1.Name = "bMostrarPass1";
            bMostrarPass1.Size = new Size(33, 29);
            bMostrarPass1.TabIndex = 20;
            bMostrarPass1.UseVisualStyleBackColor = true;
            bMostrarPass1.Click += bMostrarPass1_Click;
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.Controls.Add(tbConfirmPass);
            flowLayoutPanel9.Controls.Add(bMostrarConfPass2);
            flowLayoutPanel9.Location = new Point(430, 317);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            flowLayoutPanel9.Size = new Size(339, 43);
            flowLayoutPanel9.TabIndex = 41;
            // 
            // tbConfirmPass
            // 
            tbConfirmPass.Cursor = Cursors.Hand;
            tbConfirmPass.ForeColor = Color.Black;
            tbConfirmPass.Location = new Point(3, 3);
            tbConfirmPass.Name = "tbConfirmPass";
            tbConfirmPass.PasswordChar = '*';
            tbConfirmPass.Size = new Size(286, 27);
            tbConfirmPass.TabIndex = 18;
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
            bMostrarConfPass2.Location = new Point(295, 3);
            bMostrarConfPass2.Name = "bMostrarConfPass2";
            bMostrarConfPass2.Size = new Size(33, 29);
            bMostrarConfPass2.TabIndex = 20;
            bMostrarConfPass2.UseVisualStyleBackColor = true;
            bMostrarConfPass2.Click += bMostrarConfPass2_Click;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Controls.Add(tbTelefono);
            flowLayoutPanel7.Location = new Point(25, 430);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(303, 37);
            flowLayoutPanel7.TabIndex = 39;
            // 
            // tbTelefono
            // 
            tbTelefono.Cursor = Cursors.Hand;
            tbTelefono.ForeColor = Color.Black;
            tbTelefono.Location = new Point(3, 3);
            tbTelefono.Name = "tbTelefono";
            tbTelefono.Size = new Size(281, 27);
            tbTelefono.TabIndex = 18;
            tbTelefono.KeyPress += tbTelefono_KeyPress;
            tbTelefono.Validating += tbTelefono_Validating;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(tbEmail);
            flowLayoutPanel6.Location = new Point(433, 104);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(305, 37);
            flowLayoutPanel6.TabIndex = 36;
            // 
            // tbEmail
            // 
            tbEmail.Cursor = Cursors.Hand;
            tbEmail.ForeColor = Color.Black;
            tbEmail.Location = new Point(3, 3);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(286, 27);
            tbEmail.TabIndex = 18;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(tbApellidoUsuario);
            flowLayoutPanel5.Location = new Point(25, 317);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(303, 37);
            flowLayoutPanel5.TabIndex = 37;
            // 
            // tbApellidoUsuario
            // 
            tbApellidoUsuario.Cursor = Cursors.Hand;
            tbApellidoUsuario.ForeColor = Color.Black;
            tbApellidoUsuario.Location = new Point(3, 3);
            tbApellidoUsuario.Name = "tbApellidoUsuario";
            tbApellidoUsuario.Size = new Size(286, 27);
            tbApellidoUsuario.TabIndex = 18;
            tbApellidoUsuario.KeyPress += tbApellidoUsuario_KeyPress;
            // 
            // NuevoUsuarioControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lTitulo1);
            Controls.Add(lEspecialidad);
            Controls.Add(lRol);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(lConfirmPass);
            Controls.Add(lPassUsuario);
            Controls.Add(lTelefonoUsuario);
            Controls.Add(lEmail);
            Controls.Add(lApellidoUsuario);
            Controls.Add(lNomUsuario);
            Controls.Add(bRegistrarUsuario);
            Controls.Add(flowLayoutPanel4);
            Controls.Add(flowLayoutPanel10);
            Controls.Add(flowLayoutPanel8);
            Controls.Add(flowLayoutPanel9);
            Controls.Add(flowLayoutPanel7);
            Controls.Add(flowLayoutPanel6);
            Controls.Add(flowLayoutPanel5);
            Name = "NuevoUsuarioControl";
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel10.ResumeLayout(false);
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lEspecialidad;
        private Label lRol;
        private FlowLayoutPanel flowLayoutPanel3;
        private ComboBox comboBoxRoles;
        private Label lConfirmPass;
        private Label lPassUsuario;
        private Label lTelefonoUsuario;
        private Label lEmail;
        private Label lApellidoUsuario;
        private Label lNomUsuario;
        private Button bRegistrarUsuario;
        private Label lTitulo1;
        private FlowLayoutPanel flowLayoutPanel4;
        private TextBox tbNomUsuario;
        private FlowLayoutPanel flowLayoutPanel10;
        private ComboBox comboBoxEsp;
        private FlowLayoutPanel flowLayoutPanel8;
        private TextBox tbPassUsuario;
        private Button bMostrarPass1;
        private FlowLayoutPanel flowLayoutPanel9;
        private TextBox tbConfirmPass;
        private Button bMostrarConfPass2;
        private FlowLayoutPanel flowLayoutPanel7;
        private TextBox tbTelefono;
        private FlowLayoutPanel flowLayoutPanel6;
        private TextBox tbEmail;
        private FlowLayoutPanel flowLayoutPanel5;
        private TextBox tbApellidoUsuario;
    }
}
