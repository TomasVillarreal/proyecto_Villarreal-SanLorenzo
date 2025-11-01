namespace proyecto_Villarreal_SanLorenzo
{
    partial class AgregarRegistroControl
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
            bAtras = new Button();
            lErrorObservaciones = new Label();
            lErrorTipoRegistro = new Label();
            lMedicacion = new Label();
            lObservaciones = new Label();
            lTipoRegistro = new Label();
            lDniPacienteRegistro = new Label();
            lApellidoPacienteRegistro = new Label();
            lNombrePacienteRegistro = new Label();
            tObservaciones = new TextBox();
            tDniPacienteRegistro = new TextBox();
            tApellidoPacienteRegistro = new TextBox();
            tNombrePacienteRegistro = new TextBox();
            comboBoxTipoRegistro = new ComboBox();
            comboBoxMedicacion = new ComboBox();
            lErrorMedicacion = new Label();
            bGuardarRegistro = new Button();
            lDosis = new Label();
            tDosis = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // bAtras
            // 
            bAtras.BackColor = Color.Transparent;
            bAtras.ForeColor = Color.Black;
            bAtras.Image = Resource1.flecha_izq;
            bAtras.Location = new Point(768, 27);
            bAtras.Margin = new Padding(3, 4, 3, 4);
            bAtras.Name = "bAtras";
            bAtras.Size = new Size(41, 41);
            bAtras.TabIndex = 37;
            bAtras.UseVisualStyleBackColor = false;
            bAtras.Click += bAtras_Click;
            // 
            // lErrorObservaciones
            // 
            lErrorObservaciones.AutoSize = true;
            lErrorObservaciones.ForeColor = Color.Red;
            lErrorObservaciones.Location = new Point(51, 448);
            lErrorObservaciones.Name = "lErrorObservaciones";
            lErrorObservaciones.Size = new Size(50, 20);
            lErrorObservaciones.TabIndex = 36;
            lErrorObservaciones.Text = "label2";
            lErrorObservaciones.Visible = false;
            // 
            // lErrorTipoRegistro
            // 
            lErrorTipoRegistro.AutoSize = true;
            lErrorTipoRegistro.ForeColor = Color.Red;
            lErrorTipoRegistro.Location = new Point(53, 337);
            lErrorTipoRegistro.Name = "lErrorTipoRegistro";
            lErrorTipoRegistro.Size = new Size(50, 20);
            lErrorTipoRegistro.TabIndex = 35;
            lErrorTipoRegistro.Text = "label1";
            lErrorTipoRegistro.Visible = false;
            // 
            // lMedicacion
            // 
            lMedicacion.AutoSize = true;
            lMedicacion.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lMedicacion.Location = new Point(53, 485);
            lMedicacion.Name = "lMedicacion";
            lMedicacion.Size = new Size(111, 25);
            lMedicacion.TabIndex = 31;
            lMedicacion.Text = "Medicación";
            // 
            // lObservaciones
            // 
            lObservaciones.AutoSize = true;
            lObservaciones.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lObservaciones.Location = new Point(53, 371);
            lObservaciones.Name = "lObservaciones";
            lObservaciones.Size = new Size(137, 25);
            lObservaciones.TabIndex = 30;
            lObservaciones.Text = "Observaciones";
            // 
            // lTipoRegistro
            // 
            lTipoRegistro.AutoSize = true;
            lTipoRegistro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTipoRegistro.Location = new Point(53, 257);
            lTipoRegistro.Name = "lTipoRegistro";
            lTipoRegistro.Size = new Size(146, 25);
            lTipoRegistro.TabIndex = 29;
            lTipoRegistro.Text = "Tipo de registro";
            // 
            // lDniPacienteRegistro
            // 
            lDniPacienteRegistro.AutoSize = true;
            lDniPacienteRegistro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lDniPacienteRegistro.Location = new Point(51, 169);
            lDniPacienteRegistro.Name = "lDniPacienteRegistro";
            lDniPacienteRegistro.Size = new Size(47, 25);
            lDniPacienteRegistro.TabIndex = 28;
            lDniPacienteRegistro.Text = "DNI";
            // 
            // lApellidoPacienteRegistro
            // 
            lApellidoPacienteRegistro.AutoSize = true;
            lApellidoPacienteRegistro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lApellidoPacienteRegistro.Location = new Point(499, 84);
            lApellidoPacienteRegistro.Name = "lApellidoPacienteRegistro";
            lApellidoPacienteRegistro.Size = new Size(83, 25);
            lApellidoPacienteRegistro.TabIndex = 27;
            lApellidoPacienteRegistro.Text = "Apellido";
            // 
            // lNombrePacienteRegistro
            // 
            lNombrePacienteRegistro.AutoSize = true;
            lNombrePacienteRegistro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNombrePacienteRegistro.Location = new Point(53, 84);
            lNombrePacienteRegistro.Name = "lNombrePacienteRegistro";
            lNombrePacienteRegistro.Size = new Size(83, 25);
            lNombrePacienteRegistro.TabIndex = 26;
            lNombrePacienteRegistro.Text = "Nombre";
            // 
            // tObservaciones
            // 
            tObservaciones.Location = new Point(53, 413);
            tObservaciones.Margin = new Padding(3, 4, 3, 4);
            tObservaciones.Name = "tObservaciones";
            tObservaciones.Size = new Size(756, 27);
            tObservaciones.TabIndex = 24;
            // 
            // tDniPacienteRegistro
            // 
            tDniPacienteRegistro.Location = new Point(51, 214);
            tDniPacienteRegistro.Margin = new Padding(3, 4, 3, 4);
            tDniPacienteRegistro.Name = "tDniPacienteRegistro";
            tDniPacienteRegistro.ReadOnly = true;
            tDniPacienteRegistro.Size = new Size(756, 27);
            tDniPacienteRegistro.TabIndex = 22;
            // 
            // tApellidoPacienteRegistro
            // 
            tApellidoPacienteRegistro.Location = new Point(499, 124);
            tApellidoPacienteRegistro.Margin = new Padding(3, 4, 3, 4);
            tApellidoPacienteRegistro.Name = "tApellidoPacienteRegistro";
            tApellidoPacienteRegistro.ReadOnly = true;
            tApellidoPacienteRegistro.Size = new Size(310, 27);
            tApellidoPacienteRegistro.TabIndex = 21;
            // 
            // tNombrePacienteRegistro
            // 
            tNombrePacienteRegistro.Location = new Point(53, 124);
            tNombrePacienteRegistro.Margin = new Padding(3, 4, 3, 4);
            tNombrePacienteRegistro.Name = "tNombrePacienteRegistro";
            tNombrePacienteRegistro.ReadOnly = true;
            tNombrePacienteRegistro.Size = new Size(310, 27);
            tNombrePacienteRegistro.TabIndex = 20;
            // 
            // comboBoxTipoRegistro
            // 
            comboBoxTipoRegistro.FormattingEnabled = true;
            comboBoxTipoRegistro.Location = new Point(53, 294);
            comboBoxTipoRegistro.Name = "comboBoxTipoRegistro";
            comboBoxTipoRegistro.Size = new Size(756, 28);
            comboBoxTipoRegistro.TabIndex = 39;
            // 
            // comboBoxMedicacion
            // 
            comboBoxMedicacion.FormattingEnabled = true;
            comboBoxMedicacion.Location = new Point(53, 523);
            comboBoxMedicacion.Name = "comboBoxMedicacion";
            comboBoxMedicacion.Size = new Size(756, 28);
            comboBoxMedicacion.TabIndex = 40;
            comboBoxMedicacion.SelectedIndexChanged += comboBoxMedicacion_SelectedIndexChanged;
            // 
            // lErrorMedicacion
            // 
            lErrorMedicacion.AutoSize = true;
            lErrorMedicacion.ForeColor = Color.Red;
            lErrorMedicacion.Location = new Point(51, 563);
            lErrorMedicacion.Name = "lErrorMedicacion";
            lErrorMedicacion.Size = new Size(50, 20);
            lErrorMedicacion.TabIndex = 41;
            lErrorMedicacion.Text = "label3";
            lErrorMedicacion.Visible = false;
            // 
            // bGuardarRegistro
            // 
            bGuardarRegistro.BackColor = Color.Black;
            bGuardarRegistro.ForeColor = Color.Transparent;
            bGuardarRegistro.Location = new Point(331, 672);
            bGuardarRegistro.Margin = new Padding(3, 4, 3, 4);
            bGuardarRegistro.Name = "bGuardarRegistro";
            bGuardarRegistro.Size = new Size(138, 48);
            bGuardarRegistro.TabIndex = 42;
            bGuardarRegistro.Text = "Guardar registro";
            bGuardarRegistro.TextImageRelation = TextImageRelation.ImageBeforeText;
            bGuardarRegistro.UseVisualStyleBackColor = false;
            bGuardarRegistro.Click += bGuardarRegistro_Click;
            // 
            // lDosis
            // 
            lDosis.AutoSize = true;
            lDosis.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lDosis.Location = new Point(51, 596);
            lDosis.Name = "lDosis";
            lDosis.Size = new Size(58, 25);
            lDosis.TabIndex = 43;
            lDosis.Text = "Dosis";
            // 
            // tDosis
            // 
            tDosis.Location = new Point(53, 625);
            tDosis.Margin = new Padding(3, 4, 3, 4);
            tDosis.Name = "tDosis";
            tDosis.Size = new Size(756, 27);
            tDosis.TabIndex = 44;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Red;
            label7.Location = new Point(53, 656);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 45;
            label7.Text = "label4";
            label7.Visible = false;
            // 
            // AgregarRegistroControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label7);
            Controls.Add(tDosis);
            Controls.Add(lDosis);
            Controls.Add(bGuardarRegistro);
            Controls.Add(lErrorMedicacion);
            Controls.Add(comboBoxMedicacion);
            Controls.Add(comboBoxTipoRegistro);
            Controls.Add(bAtras);
            Controls.Add(lErrorObservaciones);
            Controls.Add(lErrorTipoRegistro);
            Controls.Add(lMedicacion);
            Controls.Add(lObservaciones);
            Controls.Add(lTipoRegistro);
            Controls.Add(lDniPacienteRegistro);
            Controls.Add(lApellidoPacienteRegistro);
            Controls.Add(lNombrePacienteRegistro);
            Controls.Add(tObservaciones);
            Controls.Add(tDniPacienteRegistro);
            Controls.Add(tApellidoPacienteRegistro);
            Controls.Add(tNombrePacienteRegistro);
            Name = "AgregarRegistroControl";
            Size = new Size(878, 767);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bAtras;
        private Label lErrorObservaciones;
        private Label lErrorTipoRegistro;
        private Label lMedicacion;
        private Label lObservaciones;
        private Label lTipoRegistro;
        private Label lDniPacienteRegistro;
        private Label lApellidoPacienteRegistro;
        private Label lNombrePacienteRegistro;
        private TextBox tObservaciones;
        private TextBox tDniPacienteRegistro;
        private TextBox tApellidoPacienteRegistro;
        private TextBox tNombrePacienteRegistro;
        private ComboBox comboBoxTipoRegistro;
        private ComboBox comboBoxMedicacion;
        private Label lErrorMedicacion;
        private Button bGuardarRegistro;
        private Label lDosis;
        private TextBox tDosis;
        private Label label7;
    }
}
