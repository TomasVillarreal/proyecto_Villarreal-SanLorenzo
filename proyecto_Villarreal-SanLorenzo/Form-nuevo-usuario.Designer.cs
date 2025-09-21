namespace proyecto_Villarreal_SanLorenzo
{
    partial class Form_nuevo_usuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            bUsuarios = new BotonSidebar();
            bSalir = new BotonSidebar();
            bPersonal = new BotonSidebar();
            botonSidebar1 = new BotonSidebar();
            bBackup = new BotonSidebar();
            bAgregarPersonal = new BotonSidebar();
            bCerrarSesion = new BotonSidebar();
            bPacientes = new BotonSidebar();
            bHistorial = new BotonSidebar();
            bHome = new BotonSidebar();
            label1 = new Label();
            labelSH = new Label();
            labelClinicks = new Label();
            lNombreUsuario = new Label();
            lRol = new Label();
            flowLayoutPanel5 = new FlowLayoutPanel();
            tbApellidoUsuario = new TextBox();
            lApellidoUsuario = new Label();
            flowLayoutPanel6 = new FlowLayoutPanel();
            tbEmail = new TextBox();
            lEmail = new Label();
            lTelefonoUsuario = new Label();
            flowLayoutPanel9 = new FlowLayoutPanel();
            tbConfirmPass = new TextBox();
            bMostrarConfPass2 = new Button();
            lConfirmPass = new Label();
            flowLayoutPanel8 = new FlowLayoutPanel();
            tbPassUsuario = new TextBox();
            bMostrarPass1 = new Button();
            lPassUsuario = new Label();
            lNomUsuario = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lTitulo1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label2 = new Label();
            label4 = new Label();
            panelFormularios = new Panel();
            lEspecialidad = new Label();
            label3 = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            comboBoxRoles = new ComboBox();
            bRegistrarUsuario = new Button();
            flowLayoutPanel4 = new FlowLayoutPanel();
            tbNomUsuario = new TextBox();
            flowLayoutPanel10 = new FlowLayoutPanel();
            comboBoxEsp = new ComboBox();
            flowLayoutPanel7 = new FlowLayoutPanel();
            tbTelefono = new TextBox();
            panelSidebar.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panelFormularios.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel10.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.AutoScroll = true;
            panelSidebar.Controls.Add(bUsuarios);
            panelSidebar.Controls.Add(bSalir);
            panelSidebar.Controls.Add(bPersonal);
            panelSidebar.Controls.Add(botonSidebar1);
            panelSidebar.Controls.Add(bBackup);
            panelSidebar.Controls.Add(bAgregarPersonal);
            panelSidebar.Controls.Add(bCerrarSesion);
            panelSidebar.Controls.Add(bPacientes);
            panelSidebar.Controls.Add(bHistorial);
            panelSidebar.Controls.Add(bHome);
            panelSidebar.Controls.Add(label1);
            panelSidebar.Controls.Add(labelSH);
            panelSidebar.Controls.Add(labelClinicks);
            panelSidebar.Location = new Point(-3, -29);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(246, 818);
            panelSidebar.TabIndex = 1;
            // 
            // bUsuarios
            // 
            bUsuarios.Anchor = AnchorStyles.Bottom;
            bUsuarios.BorderRadius = 10;
            bUsuarios.ClickColor = Color.FromArgb(192, 192, 192);
            bUsuarios.FlatAppearance.BorderSize = 0;
            bUsuarios.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bUsuarios.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bUsuarios.FlatStyle = FlatStyle.Flat;
            bUsuarios.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bUsuarios.HoverColor = Color.FromArgb(224, 224, 224);
            bUsuarios.Image = Resource1.user_interface;
            bUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            bUsuarios.IsActive = false;
            bUsuarios.Location = new Point(10, 316);
            bUsuarios.Margin = new Padding(3, 4, 3, 4);
            bUsuarios.Name = "bUsuarios";
            bUsuarios.NormalColor = Color.White;
            bUsuarios.Size = new Size(230, 31);
            bUsuarios.TabIndex = 17;
            bUsuarios.TabStop = false;
            bUsuarios.Text = "Usuarios";
            bUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            bUsuarios.UseVisualStyleBackColor = true;
            bUsuarios.Click += bUsuarios_Click;
            // 
            // bSalir
            // 
            bSalir.Anchor = AnchorStyles.Bottom;
            bSalir.BorderRadius = 10;
            bSalir.ClickColor = Color.FromArgb(192, 192, 192);
            bSalir.FlatAppearance.BorderSize = 0;
            bSalir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bSalir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bSalir.FlatStyle = FlatStyle.Flat;
            bSalir.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bSalir.HoverColor = Color.FromArgb(224, 224, 224);
            bSalir.Image = Resource1.box_arrow_right;
            bSalir.ImageAlign = ContentAlignment.MiddleLeft;
            bSalir.IsActive = false;
            bSalir.Location = new Point(18, 777);
            bSalir.Margin = new Padding(3, 4, 3, 4);
            bSalir.Name = "bSalir";
            bSalir.NormalColor = Color.White;
            bSalir.Size = new Size(200, 31);
            bSalir.TabIndex = 15;
            bSalir.TabStop = false;
            bSalir.Text = "Cerrar Sesión";
            bSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            bSalir.UseVisualStyleBackColor = true;
            bSalir.Click += bSalir_Click;
            // 
            // bPersonal
            // 
            bPersonal.Anchor = AnchorStyles.Bottom;
            bPersonal.BorderRadius = 10;
            bPersonal.ClickColor = Color.FromArgb(192, 192, 192);
            bPersonal.FlatAppearance.BorderSize = 0;
            bPersonal.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bPersonal.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bPersonal.FlatStyle = FlatStyle.Flat;
            bPersonal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bPersonal.HoverColor = Color.FromArgb(224, 224, 224);
            bPersonal.Image = Resource1.plus_square;
            bPersonal.ImageAlign = ContentAlignment.MiddleLeft;
            bPersonal.IsActive = false;
            bPersonal.Location = new Point(18, 738);
            bPersonal.Margin = new Padding(3, 4, 3, 4);
            bPersonal.Name = "bPersonal";
            bPersonal.NormalColor = Color.White;
            bPersonal.Size = new Size(200, 31);
            bPersonal.TabIndex = 14;
            bPersonal.TabStop = false;
            bPersonal.Text = "Agregar Personal";
            bPersonal.TextImageRelation = TextImageRelation.ImageBeforeText;
            bPersonal.UseVisualStyleBackColor = true;
            // 
            // botonSidebar1
            // 
            botonSidebar1.Anchor = AnchorStyles.Bottom;
            botonSidebar1.BorderRadius = 10;
            botonSidebar1.ClickColor = Color.FromArgb(192, 192, 192);
            botonSidebar1.FlatAppearance.BorderSize = 0;
            botonSidebar1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            botonSidebar1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            botonSidebar1.FlatStyle = FlatStyle.Flat;
            botonSidebar1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            botonSidebar1.HoverColor = Color.FromArgb(224, 224, 224);
            botonSidebar1.Image = Resource1.file_earmark_arrow_down;
            botonSidebar1.ImageAlign = ContentAlignment.MiddleLeft;
            botonSidebar1.IsActive = false;
            botonSidebar1.Location = new Point(18, 699);
            botonSidebar1.Margin = new Padding(3, 4, 3, 4);
            botonSidebar1.Name = "botonSidebar1";
            botonSidebar1.NormalColor = Color.White;
            botonSidebar1.Size = new Size(200, 31);
            botonSidebar1.TabIndex = 13;
            botonSidebar1.TabStop = false;
            botonSidebar1.Text = "Realizar Backup";
            botonSidebar1.TextImageRelation = TextImageRelation.ImageBeforeText;
            botonSidebar1.UseVisualStyleBackColor = true;
            // 
            // bBackup
            // 
            bBackup.Anchor = AnchorStyles.Bottom;
            bBackup.BorderRadius = 10;
            bBackup.ClickColor = Color.FromArgb(192, 192, 192);
            bBackup.FlatAppearance.BorderSize = 0;
            bBackup.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bBackup.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bBackup.FlatStyle = FlatStyle.Flat;
            bBackup.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bBackup.HoverColor = Color.FromArgb(224, 224, 224);
            bBackup.Image = Resource1.file_earmark_arrow_down;
            bBackup.ImageAlign = ContentAlignment.MiddleLeft;
            bBackup.IsActive = false;
            bBackup.Location = new Point(119, 1454);
            bBackup.Margin = new Padding(3, 4, 3, 4);
            bBackup.Name = "bBackup";
            bBackup.NormalColor = Color.White;
            bBackup.Size = new Size(200, 31);
            bBackup.TabIndex = 12;
            bBackup.TabStop = false;
            bBackup.Text = "Realizar Backup";
            bBackup.TextImageRelation = TextImageRelation.ImageBeforeText;
            bBackup.UseVisualStyleBackColor = true;
            // 
            // bAgregarPersonal
            // 
            bAgregarPersonal.Anchor = AnchorStyles.Bottom;
            bAgregarPersonal.BorderRadius = 10;
            bAgregarPersonal.ClickColor = Color.FromArgb(192, 192, 192);
            bAgregarPersonal.FlatAppearance.BorderSize = 0;
            bAgregarPersonal.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bAgregarPersonal.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bAgregarPersonal.FlatStyle = FlatStyle.Flat;
            bAgregarPersonal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bAgregarPersonal.HoverColor = Color.FromArgb(224, 224, 224);
            bAgregarPersonal.Image = Resource1.plus_square;
            bAgregarPersonal.ImageAlign = ContentAlignment.MiddleLeft;
            bAgregarPersonal.IsActive = false;
            bAgregarPersonal.Location = new Point(119, 1493);
            bAgregarPersonal.Margin = new Padding(3, 4, 3, 4);
            bAgregarPersonal.Name = "bAgregarPersonal";
            bAgregarPersonal.NormalColor = Color.White;
            bAgregarPersonal.Size = new Size(200, 31);
            bAgregarPersonal.TabIndex = 11;
            bAgregarPersonal.TabStop = false;
            bAgregarPersonal.Text = "Agregar Personal";
            bAgregarPersonal.TextImageRelation = TextImageRelation.ImageBeforeText;
            bAgregarPersonal.UseVisualStyleBackColor = true;
            // 
            // bCerrarSesion
            // 
            bCerrarSesion.Anchor = AnchorStyles.Bottom;
            bCerrarSesion.BorderRadius = 10;
            bCerrarSesion.ClickColor = Color.FromArgb(192, 192, 192);
            bCerrarSesion.FlatAppearance.BorderSize = 0;
            bCerrarSesion.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bCerrarSesion.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bCerrarSesion.FlatStyle = FlatStyle.Flat;
            bCerrarSesion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bCerrarSesion.HoverColor = Color.FromArgb(224, 224, 224);
            bCerrarSesion.Image = Resource1.box_arrow_right;
            bCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            bCerrarSesion.IsActive = false;
            bCerrarSesion.Location = new Point(119, 1531);
            bCerrarSesion.Margin = new Padding(3, 4, 3, 4);
            bCerrarSesion.Name = "bCerrarSesion";
            bCerrarSesion.NormalColor = Color.White;
            bCerrarSesion.Size = new Size(200, 31);
            bCerrarSesion.TabIndex = 10;
            bCerrarSesion.TabStop = false;
            bCerrarSesion.Text = "Cerrar Sesión";
            bCerrarSesion.TextImageRelation = TextImageRelation.ImageBeforeText;
            bCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // bPacientes
            // 
            bPacientes.BorderRadius = 10;
            bPacientes.ClickColor = Color.FromArgb(192, 192, 192);
            bPacientes.FlatAppearance.BorderSize = 0;
            bPacientes.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bPacientes.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bPacientes.FlatStyle = FlatStyle.Flat;
            bPacientes.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bPacientes.HoverColor = Color.FromArgb(224, 224, 224);
            bPacientes.Image = Resource1.people_fill;
            bPacientes.ImageAlign = ContentAlignment.MiddleLeft;
            bPacientes.IsActive = false;
            bPacientes.Location = new Point(30, 285);
            bPacientes.Margin = new Padding(3, 4, 3, 4);
            bPacientes.Name = "bPacientes";
            bPacientes.NormalColor = Color.White;
            bPacientes.Size = new Size(200, 31);
            bPacientes.TabIndex = 8;
            bPacientes.TabStop = false;
            bPacientes.Text = "Pacientes";
            bPacientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            bPacientes.UseVisualStyleBackColor = true;
            // 
            // bHistorial
            // 
            bHistorial.BorderRadius = 10;
            bHistorial.ClickColor = Color.FromArgb(192, 192, 192);
            bHistorial.FlatAppearance.BorderSize = 0;
            bHistorial.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bHistorial.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bHistorial.FlatStyle = FlatStyle.Flat;
            bHistorial.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bHistorial.HoverColor = Color.FromArgb(224, 224, 224);
            bHistorial.Image = Resource1.file_post;
            bHistorial.ImageAlign = ContentAlignment.MiddleLeft;
            bHistorial.IsActive = false;
            bHistorial.Location = new Point(30, 246);
            bHistorial.Margin = new Padding(3, 4, 3, 4);
            bHistorial.Name = "bHistorial";
            bHistorial.NormalColor = Color.White;
            bHistorial.Size = new Size(200, 31);
            bHistorial.TabIndex = 6;
            bHistorial.TabStop = false;
            bHistorial.Text = "Historial Medico";
            bHistorial.TextImageRelation = TextImageRelation.ImageBeforeText;
            bHistorial.UseVisualStyleBackColor = true;
            // 
            // bHome
            // 
            bHome.BorderRadius = 10;
            bHome.ClickColor = Color.FromArgb(192, 192, 192);
            bHome.FlatAppearance.BorderSize = 0;
            bHome.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bHome.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bHome.FlatStyle = FlatStyle.Flat;
            bHome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bHome.HoverColor = Color.FromArgb(224, 224, 224);
            bHome.Image = Resource1.house_door1;
            bHome.ImageAlign = ContentAlignment.MiddleLeft;
            bHome.IsActive = false;
            bHome.Location = new Point(30, 208);
            bHome.Margin = new Padding(3, 4, 3, 4);
            bHome.Name = "bHome";
            bHome.NormalColor = Color.White;
            bHome.Size = new Size(200, 31);
            bHome.TabIndex = 4;
            bHome.TabStop = false;
            bHome.Text = "Home";
            bHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            bHome.UseVisualStyleBackColor = true;
            bHome.Click += bHome_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 167);
            label1.Name = "label1";
            label1.Size = new Size(210, 23);
            label1.TabIndex = 3;
            label1.Text = "NAVEGACION PRINCIPAL";
            // 
            // labelSH
            // 
            labelSH.AccessibleRole = AccessibleRole.None;
            labelSH.AutoSize = true;
            labelSH.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSH.Location = new Point(54, 76);
            labelSH.Name = "labelSH";
            labelSH.Size = new Size(142, 25);
            labelSH.TabIndex = 2;
            labelSH.Text = "Sistema Clínico";
            labelSH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelClinicks
            // 
            labelClinicks.AutoSize = true;
            labelClinicks.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClinicks.Location = new Point(77, 44);
            labelClinicks.Name = "labelClinicks";
            labelClinicks.Size = new Size(95, 32);
            labelClinicks.TabIndex = 1;
            labelClinicks.Text = "Clinicks";
            labelClinicks.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lNombreUsuario
            // 
            lNombreUsuario.AutoSize = true;
            lNombreUsuario.BorderStyle = BorderStyle.FixedSingle;
            lNombreUsuario.FlatStyle = FlatStyle.Flat;
            lNombreUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNombreUsuario.ForeColor = Color.Black;
            lNombreUsuario.Location = new Point(1243, 9);
            lNombreUsuario.Name = "lNombreUsuario";
            lNombreUsuario.Size = new Size(138, 22);
            lNombreUsuario.TabIndex = 6;
            lNombreUsuario.Text = "Emanuel Gonzalez";
            lNombreUsuario.TextAlign = ContentAlignment.TopCenter;
            // 
            // lRol
            // 
            lRol.AutoSize = true;
            lRol.BackColor = SystemColors.Highlight;
            lRol.BorderStyle = BorderStyle.FixedSingle;
            lRol.FlatStyle = FlatStyle.Flat;
            lRol.ForeColor = Color.White;
            lRol.Location = new Point(1262, 31);
            lRol.Name = "lRol";
            lRol.Size = new Size(108, 22);
            lRol.TabIndex = 7;
            lRol.Text = "Administrativo";
            lRol.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(tbApellidoUsuario);
            flowLayoutPanel5.Location = new Point(114, 341);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(326, 37);
            flowLayoutPanel5.TabIndex = 21;
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
            // lApellidoUsuario
            // 
            lApellidoUsuario.AccessibleRole = AccessibleRole.None;
            lApellidoUsuario.AutoSize = true;
            lApellidoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lApellidoUsuario.Location = new Point(114, 313);
            lApellidoUsuario.Name = "lApellidoUsuario";
            lApellidoUsuario.Size = new Size(83, 25);
            lApellidoUsuario.TabIndex = 16;
            lApellidoUsuario.Text = "Apellido";
            lApellidoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(tbEmail);
            flowLayoutPanel6.Location = new Point(580, 128);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(342, 37);
            flowLayoutPanel6.TabIndex = 21;
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
            // lEmail
            // 
            lEmail.AccessibleRole = AccessibleRole.None;
            lEmail.AutoSize = true;
            lEmail.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lEmail.Location = new Point(580, 100);
            lEmail.Name = "lEmail";
            lEmail.Size = new Size(59, 25);
            lEmail.TabIndex = 16;
            lEmail.Text = "Email";
            lEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lTelefonoUsuario
            // 
            lTelefonoUsuario.AccessibleRole = AccessibleRole.None;
            lTelefonoUsuario.AutoSize = true;
            lTelefonoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTelefonoUsuario.Location = new Point(117, 426);
            lTelefonoUsuario.Name = "lTelefonoUsuario";
            lTelefonoUsuario.Size = new Size(85, 25);
            lTelefonoUsuario.TabIndex = 16;
            lTelefonoUsuario.Text = "Telefono";
            lTelefonoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.Controls.Add(tbConfirmPass);
            flowLayoutPanel9.Controls.Add(bMostrarConfPass2);
            flowLayoutPanel9.Location = new Point(586, 341);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            flowLayoutPanel9.Size = new Size(339, 43);
            flowLayoutPanel9.TabIndex = 23;
            // 
            // tbConfirmPass
            // 
            tbConfirmPass.Cursor = Cursors.Hand;
            tbConfirmPass.ForeColor = Color.Black;
            tbConfirmPass.Location = new Point(3, 3);
            tbConfirmPass.Name = "tbConfirmPass";
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
            // lConfirmPass
            // 
            lConfirmPass.AccessibleRole = AccessibleRole.None;
            lConfirmPass.AutoSize = true;
            lConfirmPass.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lConfirmPass.Location = new Point(583, 313);
            lConfirmPass.Name = "lConfirmPass";
            lConfirmPass.Size = new Size(201, 25);
            lConfirmPass.TabIndex = 16;
            lConfirmPass.Text = "Confirmar Contraseña";
            lConfirmPass.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(tbPassUsuario);
            flowLayoutPanel8.Controls.Add(bMostrarPass1);
            flowLayoutPanel8.Location = new Point(586, 232);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(339, 39);
            flowLayoutPanel8.TabIndex = 22;
            // 
            // tbPassUsuario
            // 
            tbPassUsuario.Cursor = Cursors.Hand;
            tbPassUsuario.ForeColor = Color.Black;
            tbPassUsuario.Location = new Point(3, 3);
            tbPassUsuario.Name = "tbPassUsuario";
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
            // lPassUsuario
            // 
            lPassUsuario.AccessibleRole = AccessibleRole.None;
            lPassUsuario.AutoSize = true;
            lPassUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lPassUsuario.Location = new Point(583, 199);
            lPassUsuario.Name = "lPassUsuario";
            lPassUsuario.Size = new Size(109, 25);
            lPassUsuario.TabIndex = 16;
            lPassUsuario.Text = "Contraseña";
            lPassUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lNomUsuario
            // 
            lNomUsuario.AccessibleRole = AccessibleRole.None;
            lNomUsuario.AutoSize = true;
            lNomUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNomUsuario.Location = new Point(114, 205);
            lNomUsuario.Name = "lNomUsuario";
            lNomUsuario.Size = new Size(83, 25);
            lNomUsuario.TabIndex = 16;
            lNomUsuario.Text = "Nombre";
            lNomUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lTitulo1);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Location = new Point(335, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(415, 35);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // lTitulo1
            // 
            lTitulo1.AutoSize = true;
            lTitulo1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTitulo1.Location = new Point(3, 0);
            lTitulo1.Name = "lTitulo1";
            lTitulo1.Size = new Size(399, 32);
            lTitulo1.TabIndex = 16;
            lTitulo1.Text = "Ingrese los datos del nuevo usuario";
            lTitulo1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(label4);
            flowLayoutPanel2.Location = new Point(3, 35);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(488, 36);
            flowLayoutPanel2.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(312, 32);
            label2.TabIndex = 16;
            label2.Text = "Ingrese los datos del nuevo";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(321, 0);
            label4.Name = "label4";
            label4.Size = new Size(97, 32);
            label4.TabIndex = 17;
            label4.Text = "Usuario";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFormularios
            // 
            panelFormularios.BackColor = SystemColors.Control;
            panelFormularios.Controls.Add(lEspecialidad);
            panelFormularios.Controls.Add(label3);
            panelFormularios.Controls.Add(flowLayoutPanel3);
            panelFormularios.Controls.Add(lConfirmPass);
            panelFormularios.Controls.Add(lPassUsuario);
            panelFormularios.Controls.Add(lTelefonoUsuario);
            panelFormularios.Controls.Add(lEmail);
            panelFormularios.Controls.Add(lApellidoUsuario);
            panelFormularios.Controls.Add(lNomUsuario);
            panelFormularios.Controls.Add(bRegistrarUsuario);
            panelFormularios.Controls.Add(flowLayoutPanel1);
            panelFormularios.Controls.Add(flowLayoutPanel4);
            panelFormularios.Controls.Add(flowLayoutPanel10);
            panelFormularios.Controls.Add(flowLayoutPanel8);
            panelFormularios.Controls.Add(flowLayoutPanel9);
            panelFormularios.Controls.Add(flowLayoutPanel7);
            panelFormularios.Controls.Add(flowLayoutPanel6);
            panelFormularios.Controls.Add(flowLayoutPanel5);
            panelFormularios.Location = new Point(258, 56);
            panelFormularios.Name = "panelFormularios";
            panelFormularios.Size = new Size(1112, 733);
            panelFormularios.TabIndex = 8;
            // 
            // lEspecialidad
            // 
            lEspecialidad.AccessibleRole = AccessibleRole.None;
            lEspecialidad.AutoSize = true;
            lEspecialidad.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lEspecialidad.Location = new Point(589, 426);
            lEspecialidad.Name = "lEspecialidad";
            lEspecialidad.Size = new Size(117, 25);
            lEspecialidad.TabIndex = 16;
            lEspecialidad.Text = "Especialidad";
            lEspecialidad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AccessibleRole = AccessibleRole.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(114, 100);
            label3.Name = "label3";
            label3.Size = new Size(39, 25);
            label3.TabIndex = 25;
            label3.Text = "Rol";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(comboBoxRoles);
            flowLayoutPanel3.Location = new Point(114, 128);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(320, 37);
            flowLayoutPanel3.TabIndex = 26;
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
            bRegistrarUsuario.Location = new Point(402, 558);
            bRegistrarUsuario.Name = "bRegistrarUsuario";
            bRegistrarUsuario.Size = new Size(237, 47);
            bRegistrarUsuario.TabIndex = 24;
            bRegistrarUsuario.Text = "Registrar usuario";
            bRegistrarUsuario.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(tbNomUsuario);
            flowLayoutPanel4.Location = new Point(114, 235);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(326, 37);
            flowLayoutPanel4.TabIndex = 20;
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
            flowLayoutPanel10.Location = new Point(588, 457);
            flowLayoutPanel10.Name = "flowLayoutPanel10";
            flowLayoutPanel10.Size = new Size(312, 36);
            flowLayoutPanel10.TabIndex = 23;
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
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Controls.Add(tbTelefono);
            flowLayoutPanel7.Location = new Point(119, 454);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(326, 37);
            flowLayoutPanel7.TabIndex = 22;
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
            // 
            // Form_nuevo_usuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1393, 792);
            Controls.Add(panelFormularios);
            Controls.Add(lRol);
            Controls.Add(lNombreUsuario);
            Controls.Add(panelSidebar);
            Name = "Form_nuevo_usuario";
            Text = "Form_nuevo_usuario";
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            panelFormularios.ResumeLayout(false);
            panelFormularios.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel10.ResumeLayout(false);
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSidebar;
        private BotonSidebar bBackup;
        private BotonSidebar bAgregarPersonal;
        private BotonSidebar bCerrarSesion;
        private BotonSidebar bPacientes;
        private BotonSidebar bHistorial;
        private BotonSidebar bHome;
        private Label label1;
        private Label labelSH;
        private Label labelClinicks;
        private BotonSidebar botonSidebar1;
        private BotonSidebar bPersonal;
        private BotonSidebar bSalir;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label lApellidoUsuario;
        private TextBox tbApellidoUsuario;
        private FlowLayoutPanel flowLayoutPanel6;
        private Label lEmail;
        private TextBox tbEmail;
        private Label lTelefonoUsuario;
        private FlowLayoutPanel flowLayoutPanel9;
        private Label lConfirmPass;
        private TextBox tbConfirmPass;
        private Button bMostrarConfPass2;
        private FlowLayoutPanel flowLayoutPanel8;
        private Label lPassUsuario;
        private TextBox tbPassUsuario;
        private Button bMostrarPass1;
        private Label lNomUsuario;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lTitulo1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private Label label4;
        private Panel panelFormularios;
        private Button bRegistrarUsuario;
        private Label lEspecialidad;
        private ComboBox comboBoxEsp;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel3;
        private ComboBox comboBoxRoles;
        private FlowLayoutPanel flowLayoutPanel4;
        private TextBox tbNomUsuario;
        private FlowLayoutPanel flowLayoutPanel10;
        private FlowLayoutPanel flowLayoutPanel7;
        private TextBox tbTelefono;
        private BotonSidebar bUsuarios;
        public Label lNombreUsuario;
        public Label lRol;
    }
}