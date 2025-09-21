namespace proyecto_Villarreal_SanLorenzo
{
    partial class FormVerUsuarios
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
            lRol = new Label();
            lNombreUsuario = new Label();
            dataGridViewUsuarios = new DataGridView();
            lTelefonoUsuario = new Label();
            lApellidoUsuario = new Label();
            lNomUsuario = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            tbNomUsuario = new TextBox();
            flowLayoutPanel7 = new FlowLayoutPanel();
            tbTelefono = new TextBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            tbApellidoUsuario = new TextBox();
            lEmail = new Label();
            flowLayoutPanel6 = new FlowLayoutPanel();
            tbEmail = new TextBox();
            bEditarUsuario = new Button();
            bEliminarUsuario = new Button();
            bAgregarUsuario = new Button();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.AutoScroll = true;
            panelSidebar.BackColor = Color.White;
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
            panelSidebar.Location = new Point(3, -4);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(232, 765);
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
            bUsuarios.Location = new Point(3, 324);
            bUsuarios.Margin = new Padding(3, 4, 3, 4);
            bUsuarios.Name = "bUsuarios";
            bUsuarios.NormalColor = Color.White;
            bUsuarios.Size = new Size(230, 31);
            bUsuarios.TabIndex = 16;
            bUsuarios.TabStop = false;
            bUsuarios.Text = "Usuarios";
            bUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            bUsuarios.UseVisualStyleBackColor = true;
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
            bSalir.Location = new Point(16, 722);
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
            bPersonal.Location = new Point(22, 644);
            bPersonal.Margin = new Padding(3, 4, 3, 4);
            bPersonal.Name = "bPersonal";
            bPersonal.NormalColor = Color.White;
            bPersonal.Size = new Size(200, 31);
            bPersonal.TabIndex = 14;
            bPersonal.TabStop = false;
            bPersonal.Text = "Agregar Personal";
            bPersonal.TextImageRelation = TextImageRelation.ImageBeforeText;
            bPersonal.UseVisualStyleBackColor = true;
            bPersonal.Click += bPersonal_Click;
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
            botonSidebar1.Location = new Point(16, 683);
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
            bBackup.Location = new Point(24, 1421);
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
            bAgregarPersonal.Location = new Point(24, 1460);
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
            bCerrarSesion.Location = new Point(13, 1499);
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
            bPacientes.Location = new Point(14, 285);
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
            bHistorial.Location = new Point(14, 247);
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
            bHome.Location = new Point(14, 208);
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
            label1.Location = new Point(12, 164);
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
            labelSH.Location = new Point(46, 81);
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
            labelClinicks.Location = new Point(69, 49);
            labelClinicks.Name = "labelClinicks";
            labelClinicks.Size = new Size(95, 32);
            labelClinicks.TabIndex = 1;
            labelClinicks.Text = "Clinicks";
            labelClinicks.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lRol
            // 
            lRol.AutoSize = true;
            lRol.BackColor = SystemColors.Highlight;
            lRol.BorderStyle = BorderStyle.FixedSingle;
            lRol.FlatStyle = FlatStyle.Flat;
            lRol.ForeColor = Color.White;
            lRol.Location = new Point(1096, 31);
            lRol.Name = "lRol";
            lRol.Size = new Size(108, 22);
            lRol.TabIndex = 8;
            lRol.Text = "Administrativo";
            lRol.TextAlign = ContentAlignment.TopCenter;
            // 
            // lNombreUsuario
            // 
            lNombreUsuario.AutoSize = true;
            lNombreUsuario.BorderStyle = BorderStyle.FixedSingle;
            lNombreUsuario.FlatStyle = FlatStyle.Flat;
            lNombreUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNombreUsuario.ForeColor = Color.Black;
            lNombreUsuario.Location = new Point(1081, 9);
            lNombreUsuario.Name = "lNombreUsuario";
            lNombreUsuario.Size = new Size(138, 22);
            lNombreUsuario.TabIndex = 7;
            lNombreUsuario.Text = "Emanuel Gonzalez";
            lNombreUsuario.TextAlign = ContentAlignment.TopCenter;
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(257, 328);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.RowHeadersWidth = 51;
            dataGridViewUsuarios.Size = new Size(935, 433);
            dataGridViewUsuarios.TabIndex = 9;
            // 
            // lTelefonoUsuario
            // 
            lTelefonoUsuario.AccessibleRole = AccessibleRole.None;
            lTelefonoUsuario.AutoSize = true;
            lTelefonoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTelefonoUsuario.Location = new Point(698, 88);
            lTelefonoUsuario.Name = "lTelefonoUsuario";
            lTelefonoUsuario.Size = new Size(85, 25);
            lTelefonoUsuario.TabIndex = 23;
            lTelefonoUsuario.Text = "Telefono";
            lTelefonoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lApellidoUsuario
            // 
            lApellidoUsuario.AccessibleRole = AccessibleRole.None;
            lApellidoUsuario.AutoSize = true;
            lApellidoUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lApellidoUsuario.Location = new Point(346, 176);
            lApellidoUsuario.Name = "lApellidoUsuario";
            lApellidoUsuario.Size = new Size(83, 25);
            lApellidoUsuario.TabIndex = 24;
            lApellidoUsuario.Text = "Apellido";
            lApellidoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lNomUsuario
            // 
            lNomUsuario.AccessibleRole = AccessibleRole.None;
            lNomUsuario.AutoSize = true;
            lNomUsuario.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNomUsuario.Location = new Point(346, 85);
            lNomUsuario.Name = "lNomUsuario";
            lNomUsuario.Size = new Size(83, 25);
            lNomUsuario.TabIndex = 25;
            lNomUsuario.Text = "Nombre";
            lNomUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(tbNomUsuario);
            flowLayoutPanel4.Location = new Point(346, 115);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(326, 37);
            flowLayoutPanel4.TabIndex = 26;
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
            flowLayoutPanel7.Location = new Point(700, 116);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(326, 37);
            flowLayoutPanel7.TabIndex = 28;
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
            flowLayoutPanel5.Location = new Point(346, 204);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(326, 37);
            flowLayoutPanel5.TabIndex = 27;
            // 
            // tbApellidoUsuario
            // 
            tbApellidoUsuario.Cursor = Cursors.Hand;
            tbApellidoUsuario.ForeColor = Color.Black;
            tbApellidoUsuario.Location = new Point(3, 3);
            tbApellidoUsuario.Name = "tbApellidoUsuario";
            tbApellidoUsuario.Size = new Size(269, 27);
            tbApellidoUsuario.TabIndex = 18;
            // 
            // lEmail
            // 
            lEmail.AccessibleRole = AccessibleRole.None;
            lEmail.AutoSize = true;
            lEmail.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lEmail.Location = new Point(703, 176);
            lEmail.Name = "lEmail";
            lEmail.Size = new Size(59, 25);
            lEmail.TabIndex = 29;
            lEmail.Text = "Email";
            lEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(tbEmail);
            flowLayoutPanel6.Location = new Point(703, 204);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(323, 37);
            flowLayoutPanel6.TabIndex = 30;
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
            // bEditarUsuario
            // 
            bEditarUsuario.Cursor = Cursors.Hand;
            bEditarUsuario.FlatAppearance.BorderColor = Color.Silver;
            bEditarUsuario.FlatAppearance.MouseDownBackColor = Color.LightGray;
            bEditarUsuario.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            bEditarUsuario.FlatStyle = FlatStyle.Flat;
            bEditarUsuario.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bEditarUsuario.ForeColor = Color.Black;
            bEditarUsuario.Location = new Point(642, 279);
            bEditarUsuario.Name = "bEditarUsuario";
            bEditarUsuario.Size = new Size(141, 29);
            bEditarUsuario.TabIndex = 31;
            bEditarUsuario.Text = "Editar usuario";
            bEditarUsuario.UseVisualStyleBackColor = true;
            bEditarUsuario.Click += bEditarUsuario_Click;
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
            bEliminarUsuario.Location = new Point(880, 279);
            bEliminarUsuario.Name = "bEliminarUsuario";
            bEliminarUsuario.Size = new Size(146, 29);
            bEliminarUsuario.TabIndex = 32;
            bEliminarUsuario.Text = "Eliminar usuario";
            bEliminarUsuario.UseVisualStyleBackColor = true;
            bEliminarUsuario.Click += bEliminarUsuario_Click;
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
            bAgregarUsuario.Location = new Point(349, 279);
            bAgregarUsuario.Name = "bAgregarUsuario";
            bAgregarUsuario.Size = new Size(209, 29);
            bAgregarUsuario.TabIndex = 33;
            bAgregarUsuario.Text = "Agregar nuevo usuario";
            bAgregarUsuario.UseVisualStyleBackColor = true;
            bAgregarUsuario.Click += bAgregarUsuario_Click;
            // 
            // FormVerUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 764);
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
            Controls.Add(dataGridViewUsuarios);
            Controls.Add(lRol);
            Controls.Add(lNombreUsuario);
            Controls.Add(panelSidebar);
            Name = "FormVerUsuarios";
            Text = "FormVerUsuarios";
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
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
        private DataGridView dataGridViewUsuarios;
        private Label lTelefonoUsuario;
        private Label lApellidoUsuario;
        private Label lNomUsuario;
        private FlowLayoutPanel flowLayoutPanel4;
        private TextBox tbNomUsuario;
        private FlowLayoutPanel flowLayoutPanel7;
        private TextBox tbTelefono;
        private FlowLayoutPanel flowLayoutPanel5;
        private TextBox tbApellidoUsuario;
        private Label lEmail;
        private FlowLayoutPanel flowLayoutPanel6;
        private TextBox tbEmail;
        private Button bEditarUsuario;
        private Button bEliminarUsuario;
        private Button bAgregarUsuario;
        private BotonSidebar bUsuarios;
        public Label lRol;
        public Label lNombreUsuario;
    }
}