namespace proyecto_Villarreal_SanLorenzo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
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
            lRolUsuario = new Label();
            panelDefault = new Panel();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.AutoScroll = true;
            panelSidebar.Controls.Add(bBackup);
            panelSidebar.Controls.Add(bAgregarPersonal);
            panelSidebar.Controls.Add(bCerrarSesion);
            panelSidebar.Controls.Add(bPacientes);
            panelSidebar.Controls.Add(bHistorial);
            panelSidebar.Controls.Add(bHome);
            panelSidebar.Controls.Add(label1);
            panelSidebar.Controls.Add(labelSH);
            panelSidebar.Controls.Add(labelClinicks);
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(200, 655);
            panelSidebar.TabIndex = 0;
            panelSidebar.Paint += panelSidebar_Paint;
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
            bBackup.Location = new Point(12, 552);
            bBackup.Name = "bBackup";
            bBackup.NormalColor = Color.White;
            bBackup.Size = new Size(175, 23);
            bBackup.TabIndex = 12;
            bBackup.TabStop = false;
            bBackup.Text = "Realizar Backup";
            bBackup.TextImageRelation = TextImageRelation.ImageBeforeText;
            bBackup.UseVisualStyleBackColor = true;
            bBackup.Click += bBackup_Click;
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
            bAgregarPersonal.Location = new Point(12, 581);
            bAgregarPersonal.Name = "bAgregarPersonal";
            bAgregarPersonal.NormalColor = Color.White;
            bAgregarPersonal.Size = new Size(175, 23);
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
            bCerrarSesion.Location = new Point(12, 610);
            bCerrarSesion.Name = "bCerrarSesion";
            bCerrarSesion.NormalColor = Color.White;
            bCerrarSesion.Size = new Size(175, 23);
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
            bPacientes.Location = new Point(12, 214);
            bPacientes.Name = "bPacientes";
            bPacientes.NormalColor = Color.White;
            bPacientes.Size = new Size(175, 23);
            bPacientes.TabIndex = 8;
            bPacientes.TabStop = false;
            bPacientes.Text = "Pacientes";
            bPacientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            bPacientes.UseVisualStyleBackColor = true;
            bPacientes.Click += bPacientes_Click;
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
            bHistorial.Location = new Point(12, 185);
            bHistorial.Name = "bHistorial";
            bHistorial.NormalColor = Color.White;
            bHistorial.Size = new Size(175, 23);
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
            bHome.Location = new Point(12, 156);
            bHome.Name = "bHome";
            bHome.NormalColor = Color.White;
            bHome.Size = new Size(175, 23);
            bHome.TabIndex = 4;
            bHome.TabStop = false;
            bHome.Text = "Home";
            bHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            bHome.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 125);
            label1.Name = "label1";
            label1.Size = new Size(161, 17);
            label1.TabIndex = 3;
            label1.Text = "NAVEGACION PRINCIPAL";
            // 
            // labelSH
            // 
            labelSH.AccessibleRole = AccessibleRole.None;
            labelSH.AutoSize = true;
            labelSH.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSH.Location = new Point(30, 58);
            labelSH.Name = "labelSH";
            labelSH.Size = new Size(148, 20);
            labelSH.TabIndex = 2;
            labelSH.Text = "Sistema Hospitalario";
            labelSH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelClinicks
            // 
            labelClinicks.AutoSize = true;
            labelClinicks.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClinicks.Location = new Point(67, 33);
            labelClinicks.Name = "labelClinicks";
            labelClinicks.Size = new Size(77, 25);
            labelClinicks.TabIndex = 1;
            labelClinicks.Text = "Clinicks";
            labelClinicks.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lNombreUsuario
            // 
            lNombreUsuario.AutoSize = true;
            lNombreUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNombreUsuario.Location = new Point(887, 18);
            lNombreUsuario.Name = "lNombreUsuario";
            lNombreUsuario.Size = new Size(121, 15);
            lNombreUsuario.TabIndex = 1;
            lNombreUsuario.Text = "Dr Emanuel Gonzalez";
            // 
            // lRolUsuario
            // 
            lRolUsuario.AutoSize = true;
            lRolUsuario.BackColor = Color.DodgerBlue;
            lRolUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lRolUsuario.ForeColor = Color.White;
            lRolUsuario.Location = new Point(923, 33);
            lRolUsuario.Name = "lRolUsuario";
            lRolUsuario.Size = new Size(47, 15);
            lRolUsuario.TabIndex = 2;
            lRolUsuario.Text = "Medico";
            // 
            // panelDefault
            // 
            panelDefault.BackColor = Color.FromArgb(245, 245, 245);
            panelDefault.Location = new Point(240, 58);
            panelDefault.Name = "panelDefault";
            panelDefault.Size = new Size(768, 575);
            panelDefault.TabIndex = 3;
            panelDefault.Paint += panelDefault_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1038, 655);
            Controls.Add(panelDefault);
            Controls.Add(lRolUsuario);
            Controls.Add(lNombreUsuario);
            Controls.Add(panelSidebar);
            Name = "Form1";
            Text = "Form1";
            Resize += Form1_Resize;
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSidebar;
        private Label labelClinicks;
        private Label label1;
        private Label labelSH;
        private BotonSidebar bHome;
        private BotonSidebar bPacientes;
        private BotonSidebar bHistorial;
        private BotonSidebar bBackup;
        private BotonSidebar bAgregarPersonal;
        private BotonSidebar bCerrarSesion;
        private Label lNombreUsuario;
        private Label lRolUsuario;
        private Panel panelDefault;
    }
}
