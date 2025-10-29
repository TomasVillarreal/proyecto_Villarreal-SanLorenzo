namespace proyecto_Villarreal_SanLorenzo
{
    partial class EditarRegistroControl
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
            label7 = new Label();
            tDosis = new TextBox();
            lDosis = new Label();
            bGuardarCambios = new Button();
            lErrorMedicacion = new Label();
            comboBoxMedicacion = new ComboBox();
            comboBoxTipoRegistro = new ComboBox();
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
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Red;
            label7.Location = new Point(62, 666);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 65;
            label7.Text = "label4";
            label7.Visible = false;
            // 
            // tDosis
            // 
            tDosis.Location = new Point(62, 635);
            tDosis.Margin = new Padding(3, 4, 3, 4);
            tDosis.Name = "tDosis";
            tDosis.Size = new Size(756, 27);
            tDosis.TabIndex = 64;
            // 
            // lDosis
            // 
            lDosis.AutoSize = true;
            lDosis.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lDosis.Location = new Point(60, 606);
            lDosis.Name = "lDosis";
            lDosis.Size = new Size(58, 25);
            lDosis.TabIndex = 63;
            lDosis.Text = "Dosis";
            // 
            // bGuardarCambios
            // 
            bGuardarCambios.BackColor = Color.Transparent;
            bGuardarCambios.ForeColor = Color.Black;
            bGuardarCambios.Location = new Point(323, 681);
            bGuardarCambios.Margin = new Padding(3, 4, 3, 4);
            bGuardarCambios.Name = "bGuardarCambios";
            bGuardarCambios.Size = new Size(138, 48);
            bGuardarCambios.TabIndex = 62;
            bGuardarCambios.Text = "Guardar cambios";
            bGuardarCambios.TextImageRelation = TextImageRelation.ImageBeforeText;
            bGuardarCambios.UseVisualStyleBackColor = false;
            // 
            // lErrorMedicacion
            // 
            lErrorMedicacion.AutoSize = true;
            lErrorMedicacion.ForeColor = Color.Red;
            lErrorMedicacion.Location = new Point(60, 573);
            lErrorMedicacion.Name = "lErrorMedicacion";
            lErrorMedicacion.Size = new Size(50, 20);
            lErrorMedicacion.TabIndex = 61;
            lErrorMedicacion.Text = "label3";
            lErrorMedicacion.Visible = false;
            // 
            // comboBoxMedicacion
            // 
            comboBoxMedicacion.FormattingEnabled = true;
            comboBoxMedicacion.Location = new Point(62, 533);
            comboBoxMedicacion.Name = "comboBoxMedicacion";
            comboBoxMedicacion.Size = new Size(756, 28);
            comboBoxMedicacion.TabIndex = 60;
            comboBoxMedicacion.SelectedIndexChanged += comboBoxMedicacion_SelectedIndexChanged;
            // 
            // comboBoxTipoRegistro
            // 
            comboBoxTipoRegistro.FormattingEnabled = true;
            comboBoxTipoRegistro.Location = new Point(62, 304);
            comboBoxTipoRegistro.Name = "comboBoxTipoRegistro";
            comboBoxTipoRegistro.Size = new Size(756, 28);
            comboBoxTipoRegistro.TabIndex = 59;
            // 
            // bAtras
            // 
            bAtras.BackColor = Color.Transparent;
            bAtras.ForeColor = Color.Black;
            bAtras.Image = Resource1.flecha_izq;
            bAtras.Location = new Point(777, 37);
            bAtras.Margin = new Padding(3, 4, 3, 4);
            bAtras.Name = "bAtras";
            bAtras.Size = new Size(41, 41);
            bAtras.TabIndex = 58;
            bAtras.UseVisualStyleBackColor = false;
            bAtras.Click += bAtras_Click;
            // 
            // lErrorObservaciones
            // 
            lErrorObservaciones.AutoSize = true;
            lErrorObservaciones.ForeColor = Color.Red;
            lErrorObservaciones.Location = new Point(60, 458);
            lErrorObservaciones.Name = "lErrorObservaciones";
            lErrorObservaciones.Size = new Size(50, 20);
            lErrorObservaciones.TabIndex = 57;
            lErrorObservaciones.Text = "label2";
            lErrorObservaciones.Visible = false;
            // 
            // lErrorTipoRegistro
            // 
            lErrorTipoRegistro.AutoSize = true;
            lErrorTipoRegistro.ForeColor = Color.Red;
            lErrorTipoRegistro.Location = new Point(62, 347);
            lErrorTipoRegistro.Name = "lErrorTipoRegistro";
            lErrorTipoRegistro.Size = new Size(50, 20);
            lErrorTipoRegistro.TabIndex = 56;
            lErrorTipoRegistro.Text = "label1";
            lErrorTipoRegistro.Visible = false;
            // 
            // lMedicacion
            // 
            lMedicacion.AutoSize = true;
            lMedicacion.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lMedicacion.Location = new Point(62, 495);
            lMedicacion.Name = "lMedicacion";
            lMedicacion.Size = new Size(111, 25);
            lMedicacion.TabIndex = 55;
            lMedicacion.Text = "Medicación";
            // 
            // lObservaciones
            // 
            lObservaciones.AutoSize = true;
            lObservaciones.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lObservaciones.Location = new Point(62, 381);
            lObservaciones.Name = "lObservaciones";
            lObservaciones.Size = new Size(137, 25);
            lObservaciones.TabIndex = 54;
            lObservaciones.Text = "Observaciones";
            // 
            // lTipoRegistro
            // 
            lTipoRegistro.AutoSize = true;
            lTipoRegistro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTipoRegistro.Location = new Point(62, 267);
            lTipoRegistro.Name = "lTipoRegistro";
            lTipoRegistro.Size = new Size(146, 25);
            lTipoRegistro.TabIndex = 53;
            lTipoRegistro.Text = "Tipo de registro";
            // 
            // lDniPacienteRegistro
            // 
            lDniPacienteRegistro.AutoSize = true;
            lDniPacienteRegistro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lDniPacienteRegistro.Location = new Point(60, 179);
            lDniPacienteRegistro.Name = "lDniPacienteRegistro";
            lDniPacienteRegistro.Size = new Size(47, 25);
            lDniPacienteRegistro.TabIndex = 52;
            lDniPacienteRegistro.Text = "DNI";
            // 
            // lApellidoPacienteRegistro
            // 
            lApellidoPacienteRegistro.AutoSize = true;
            lApellidoPacienteRegistro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lApellidoPacienteRegistro.Location = new Point(508, 94);
            lApellidoPacienteRegistro.Name = "lApellidoPacienteRegistro";
            lApellidoPacienteRegistro.Size = new Size(83, 25);
            lApellidoPacienteRegistro.TabIndex = 51;
            lApellidoPacienteRegistro.Text = "Apellido";
            // 
            // lNombrePacienteRegistro
            // 
            lNombrePacienteRegistro.AutoSize = true;
            lNombrePacienteRegistro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lNombrePacienteRegistro.Location = new Point(62, 94);
            lNombrePacienteRegistro.Name = "lNombrePacienteRegistro";
            lNombrePacienteRegistro.Size = new Size(83, 25);
            lNombrePacienteRegistro.TabIndex = 50;
            lNombrePacienteRegistro.Text = "Nombre";
            // 
            // tObservaciones
            // 
            tObservaciones.Location = new Point(62, 423);
            tObservaciones.Margin = new Padding(3, 4, 3, 4);
            tObservaciones.Name = "tObservaciones";
            tObservaciones.Size = new Size(756, 27);
            tObservaciones.TabIndex = 49;
            // 
            // tDniPacienteRegistro
            // 
            tDniPacienteRegistro.Location = new Point(60, 224);
            tDniPacienteRegistro.Margin = new Padding(3, 4, 3, 4);
            tDniPacienteRegistro.Name = "tDniPacienteRegistro";
            tDniPacienteRegistro.ReadOnly = true;
            tDniPacienteRegistro.Size = new Size(756, 27);
            tDniPacienteRegistro.TabIndex = 48;
            // 
            // tApellidoPacienteRegistro
            // 
            tApellidoPacienteRegistro.Location = new Point(508, 134);
            tApellidoPacienteRegistro.Margin = new Padding(3, 4, 3, 4);
            tApellidoPacienteRegistro.Name = "tApellidoPacienteRegistro";
            tApellidoPacienteRegistro.ReadOnly = true;
            tApellidoPacienteRegistro.Size = new Size(310, 27);
            tApellidoPacienteRegistro.TabIndex = 47;
            // 
            // tNombrePacienteRegistro
            // 
            tNombrePacienteRegistro.Location = new Point(62, 134);
            tNombrePacienteRegistro.Margin = new Padding(3, 4, 3, 4);
            tNombrePacienteRegistro.Name = "tNombrePacienteRegistro";
            tNombrePacienteRegistro.ReadOnly = true;
            tNombrePacienteRegistro.Size = new Size(310, 27);
            tNombrePacienteRegistro.TabIndex = 46;
            // 
            // EditarRegistroControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label7);
            Controls.Add(tDosis);
            Controls.Add(lDosis);
            Controls.Add(bGuardarCambios);
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
            Name = "EditarRegistroControl";
            Size = new Size(878, 767);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private TextBox tDosis;
        private Label lDosis;
        private Button bGuardarCambios;
        private Label lErrorMedicacion;
        private ComboBox comboBoxMedicacion;
        private ComboBox comboBoxTipoRegistro;
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
    }
}
