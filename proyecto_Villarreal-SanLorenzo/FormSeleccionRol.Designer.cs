namespace proyecto_Villarreal_SanLorenzo
{
    partial class FormSeleccionRol
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
            lRol = new Label();
            comboBoxRoles = new ComboBox();
            bIniciarSesion = new Button();
            SuspendLayout();
            // 
            // lRol
            // 
            lRol.AccessibleRole = AccessibleRole.None;
            lRol.AutoSize = true;
            lRol.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lRol.Location = new Point(25, 57);
            lRol.Name = "lRol";
            lRol.Size = new Size(287, 25);
            lRol.TabIndex = 26;
            lRol.Text = "Seleccione un rol para continuar";
            lRol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxRoles
            // 
            comboBoxRoles.FormattingEnabled = true;
            comboBoxRoles.Location = new Point(332, 58);
            comboBoxRoles.Name = "comboBoxRoles";
            comboBoxRoles.Size = new Size(275, 28);
            comboBoxRoles.TabIndex = 27;
            // 
            // bIniciarSesion
            // 
            bIniciarSesion.Cursor = Cursors.Hand;
            bIniciarSesion.FlatAppearance.BorderColor = Color.Silver;
            bIniciarSesion.FlatAppearance.MouseDownBackColor = Color.LightGray;
            bIniciarSesion.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            bIniciarSesion.FlatStyle = FlatStyle.Flat;
            bIniciarSesion.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bIniciarSesion.ForeColor = Color.Black;
            bIniciarSesion.Location = new Point(630, 58);
            bIniciarSesion.Name = "bIniciarSesion";
            bIniciarSesion.Size = new Size(122, 29);
            bIniciarSesion.TabIndex = 29;
            bIniciarSesion.Text = "Iniciar Sesión";
            bIniciarSesion.UseVisualStyleBackColor = true;
            bIniciarSesion.Click += bIniciarSesion_Click;
            // 
            // FormSeleccionRol
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 125);
            Controls.Add(bIniciarSesion);
            Controls.Add(comboBoxRoles);
            Controls.Add(lRol);
            Name = "FormSeleccionRol";
            Text = "FormSeleccionRol";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lRol;
        private ComboBox comboBoxRoles;
        private Button bIniciarSesion;
    }
}