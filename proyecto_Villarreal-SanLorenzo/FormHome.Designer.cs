using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace proyecto_Villarreal_SanLorenzo
{
    partial class FormHome
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
            components = new System.ComponentModel.Container();
            panelSidebar = new Panel();
            bAgregarPersonal = new BotonSidebar();
            bUsuarios = new BotonSidebar();
            bBackup = new BotonSidebar();
            bCerrarSesion = new BotonSidebar();
            bPacientes = new BotonSidebar();
            bHistorial = new BotonSidebar();
            bHome = new BotonSidebar();
            label1 = new Label();
            labelSH = new Label();
            labelClinicks = new Label();
            lNombreUsuario = new Label();
            lRol = new Label();
            panelDefault = new Panel();
            timerBackup = new System.Windows.Forms.Timer(components);
            flowLayoutPanelUsuario = new FlowLayoutPanel();
            panelSidebar.SuspendLayout();
            flowLayoutPanelUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.AutoScroll = true;
            panelSidebar.Controls.Add(bAgregarPersonal);
            panelSidebar.Controls.Add(bUsuarios);
            panelSidebar.Controls.Add(bBackup);
            panelSidebar.Controls.Add(bCerrarSesion);
            panelSidebar.Controls.Add(bPacientes);
            panelSidebar.Controls.Add(bHistorial);
            panelSidebar.Controls.Add(bHome);
            panelSidebar.Controls.Add(label1);
            panelSidebar.Controls.Add(labelSH);
            panelSidebar.Controls.Add(labelClinicks);
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(229, 873);
            panelSidebar.TabIndex = 0;
            panelSidebar.Paint += panelSidebar_Paint;
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
            bAgregarPersonal.Location = new Point(14, 750);
            bAgregarPersonal.Margin = new Padding(3, 4, 3, 4);
            bAgregarPersonal.Name = "bAgregarPersonal";
            bAgregarPersonal.NormalColor = Color.White;
            bAgregarPersonal.Size = new Size(200, 31);
            bAgregarPersonal.TabIndex = 18;
            bAgregarPersonal.TabStop = false;
            bAgregarPersonal.Text = "Agregar Personal";
            bAgregarPersonal.TextImageRelation = TextImageRelation.ImageBeforeText;
            bAgregarPersonal.UseVisualStyleBackColor = true;
            bAgregarPersonal.Click += bAgregarPersonal_Click;
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
            bUsuarios.Location = new Point(11, 324);
            bUsuarios.Margin = new Padding(3, 4, 3, 4);
            bUsuarios.Name = "bUsuarios";
            bUsuarios.NormalColor = Color.White;
            bUsuarios.Size = new Size(211, 31);
            bUsuarios.TabIndex = 17;
            bUsuarios.TabStop = false;
            bUsuarios.Text = "Usuarios";
            bUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            bUsuarios.UseVisualStyleBackColor = true;
            bUsuarios.Click += bUsuarios_Click;
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
            bBackup.Location = new Point(14, 789);
            bBackup.Margin = new Padding(3, 4, 3, 4);
            bBackup.Name = "bBackup";
            bBackup.NormalColor = Color.White;
            bBackup.Size = new Size(200, 31);
            bBackup.TabIndex = 12;
            bBackup.TabStop = false;
            bBackup.Text = "Realizar Backup";
            bBackup.TextImageRelation = TextImageRelation.ImageBeforeText;
            bBackup.UseVisualStyleBackColor = true;
            bBackup.Click += bBackup_Click;
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
            bCerrarSesion.Location = new Point(14, 828);
            bCerrarSesion.Margin = new Padding(3, 4, 3, 4);
            bCerrarSesion.Name = "bCerrarSesion";
            bCerrarSesion.NormalColor = Color.White;
            bCerrarSesion.Size = new Size(200, 31);
            bCerrarSesion.TabIndex = 10;
            bCerrarSesion.TabStop = false;
            bCerrarSesion.Text = "Cerrar Sesión";
            bCerrarSesion.TextImageRelation = TextImageRelation.ImageBeforeText;
            bCerrarSesion.UseVisualStyleBackColor = true;
            bCerrarSesion.Click += bCerrarSesion_Click;
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
            bHistorial.Click += bHistorial_Click;
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
            label1.Location = new Point(12, 167);
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
            labelSH.Location = new Point(22, 75);
            labelSH.Name = "labelSH";
            labelSH.Size = new Size(188, 25);
            labelSH.TabIndex = 2;
            labelSH.Text = "Sistema Hospitalario";
            labelSH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelClinicks
            // 
            labelClinicks.AutoSize = true;
            labelClinicks.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClinicks.Location = new Point(65, 42);
            labelClinicks.Name = "labelClinicks";
            labelClinicks.Size = new Size(95, 32);
            labelClinicks.TabIndex = 1;
            labelClinicks.Text = "Clinicks";
            labelClinicks.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lNombreUsuario
            // 
            lNombreUsuario.AutoSize = true;
            lNombreUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNombreUsuario.Location = new Point(3, 0);
            lNombreUsuario.Name = "lNombreUsuario";
            lNombreUsuario.Size = new Size(155, 20);
            lNombreUsuario.TabIndex = 1;
            lNombreUsuario.Text = "Dr Emanuel Gonzalez";
            // 
            // lRol
            // 
            lRol.AutoSize = true;
            lRol.BackColor = Color.DodgerBlue;
            lRol.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lRol.ForeColor = Color.White;
            lRol.Location = new Point(3, 20);
            lRol.Name = "lRol";
            lRol.Size = new Size(60, 20);
            lRol.TabIndex = 2;
            lRol.Text = "Medico";
            // 
            // panelDefault
            // 
            panelDefault.BackColor = Color.FromArgb(245, 245, 245);
            panelDefault.Location = new Point(274, 77);
            panelDefault.Margin = new Padding(3, 4, 3, 4);
            panelDefault.Name = "panelDefault";
            panelDefault.Size = new Size(878, 767);
            panelDefault.TabIndex = 3;
            panelDefault.Paint += panelDefault_Paint;
            // 
            // flowLayoutPanelUsuario
            // 
            flowLayoutPanelUsuario.Controls.Add(lNombreUsuario);
            flowLayoutPanelUsuario.Controls.Add(lRol);
            flowLayoutPanelUsuario.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelUsuario.Location = new Point(995, 22);
            flowLayoutPanelUsuario.Name = "flowLayoutPanelUsuario";
            flowLayoutPanelUsuario.Size = new Size(179, 48);
            flowLayoutPanelUsuario.TabIndex = 4;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1186, 873);
            Controls.Add(flowLayoutPanelUsuario);
            Controls.Add(panelDefault);
            Controls.Add(panelSidebar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormHome";
            Text = "FormHome";
            Load += FormHome_Load;
            Resize += FormHome_Resize;
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            flowLayoutPanelUsuario.ResumeLayout(false);
            flowLayoutPanelUsuario.PerformLayout();
            ResumeLayout(false);
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
        private BotonSidebar bCerrarSesion;
        private Label lNombreUsuario;
        private Label lRol;
        private Panel panelDefault;
        private System.Windows.Forms.Timer timerBackup;
        private FlowLayoutPanel flowLayoutPanelUsuario;
        private BotonSidebar bUsuarios;
        private BotonSidebar bAgregarPersonal;
    }
}
