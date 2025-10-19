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
            lErrorTelefono = new Label();
            lErrorDireccion = new Label();
            lErrorDni = new Label();
            lErrorApellido = new Label();
            lErrorNombre = new Label();
            lMedicacion = new Label();
            lObservaciones = new Label();
            lTipoRegistro = new Label();
            lDniPacienteRegistro = new Label();
            lApellidoPacienteRegistro = new Label();
            lNombrePacienteRegistro = new Label();
            tTelefonoPacienteRegistro = new TextBox();
            tDniPacienteRegistro = new TextBox();
            tApellidoPacienteRegistro = new TextBox();
            tNombrePacienteRegistro = new TextBox();
            comboBoxTipoRegistro = new ComboBox();
            comboBoxMedicacion = new ComboBox();
            label6 = new Label();
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
            // 
            // lErrorTelefono
            // 
            lErrorTelefono.AutoSize = true;
            lErrorTelefono.ForeColor = Color.Red;
            lErrorTelefono.Location = new Point(51, 495);
            lErrorTelefono.Name = "lErrorTelefono";
            lErrorTelefono.Size = new Size(50, 20);
            lErrorTelefono.TabIndex = 36;
            lErrorTelefono.Text = "label5";
            lErrorTelefono.Visible = false;
            // 
            // lErrorDireccion
            // 
            lErrorDireccion.AutoSize = true;
            lErrorDireccion.ForeColor = Color.Red;
            lErrorDireccion.Location = new Point(53, 383);
            lErrorDireccion.Name = "lErrorDireccion";
            lErrorDireccion.Size = new Size(50, 20);
            lErrorDireccion.TabIndex = 35;
            lErrorDireccion.Text = "label4";
            lErrorDireccion.Visible = false;
            // 
            // lErrorDni
            // 
            lErrorDni.AutoSize = true;
            lErrorDni.ForeColor = Color.Red;
            lErrorDni.Location = new Point(53, 267);
            lErrorDni.Name = "lErrorDni";
            lErrorDni.Size = new Size(50, 20);
            lErrorDni.TabIndex = 34;
            lErrorDni.Text = "label3";
            lErrorDni.Visible = false;
            // 
            // lErrorApellido
            // 
            lErrorApellido.AutoSize = true;
            lErrorApellido.ForeColor = Color.Red;
            lErrorApellido.Location = new Point(499, 159);
            lErrorApellido.Name = "lErrorApellido";
            lErrorApellido.Size = new Size(50, 20);
            lErrorApellido.TabIndex = 33;
            lErrorApellido.Text = "label2";
            lErrorApellido.Visible = false;
            // 
            // lErrorNombre
            // 
            lErrorNombre.AutoSize = true;
            lErrorNombre.ForeColor = Color.Red;
            lErrorNombre.Location = new Point(53, 159);
            lErrorNombre.Name = "lErrorNombre";
            lErrorNombre.Size = new Size(50, 20);
            lErrorNombre.TabIndex = 32;
            lErrorNombre.Text = "label1";
            lErrorNombre.Visible = false;
            // 
            // lMedicacion
            // 
            lMedicacion.AutoSize = true;
            lMedicacion.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lMedicacion.Location = new Point(53, 531);
            lMedicacion.Name = "lMedicacion";
            lMedicacion.Size = new Size(111, 25);
            lMedicacion.TabIndex = 31;
            lMedicacion.Text = "Medicación";
            // 
            // lObservaciones
            // 
            lObservaciones.AutoSize = true;
            lObservaciones.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lObservaciones.Location = new Point(53, 418);
            lObservaciones.Name = "lObservaciones";
            lObservaciones.Size = new Size(137, 25);
            lObservaciones.TabIndex = 30;
            lObservaciones.Text = "Observaciones";
            // 
            // lTipoRegistro
            // 
            lTipoRegistro.AutoSize = true;
            lTipoRegistro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTipoRegistro.Location = new Point(53, 303);
            lTipoRegistro.Name = "lTipoRegistro";
            lTipoRegistro.Size = new Size(146, 25);
            lTipoRegistro.TabIndex = 29;
            lTipoRegistro.Text = "Tipo de registro";
            // 
            // lDniPacienteRegistro
            // 
            lDniPacienteRegistro.AutoSize = true;
            lDniPacienteRegistro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lDniPacienteRegistro.Location = new Point(53, 187);
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
            // tTelefonoPacienteRegistro
            // 
            tTelefonoPacienteRegistro.Location = new Point(53, 460);
            tTelefonoPacienteRegistro.Margin = new Padding(3, 4, 3, 4);
            tTelefonoPacienteRegistro.Name = "tTelefonoPacienteRegistro";
            tTelefonoPacienteRegistro.Size = new Size(756, 27);
            tTelefonoPacienteRegistro.TabIndex = 24;
            // 
            // tDniPacienteRegistro
            // 
            tDniPacienteRegistro.Location = new Point(53, 232);
            tDniPacienteRegistro.Margin = new Padding(3, 4, 3, 4);
            tDniPacienteRegistro.Name = "tDniPacienteRegistro";
            tDniPacienteRegistro.Size = new Size(756, 27);
            tDniPacienteRegistro.TabIndex = 22;
            // 
            // tApellidoPacienteRegistro
            // 
            tApellidoPacienteRegistro.Location = new Point(499, 124);
            tApellidoPacienteRegistro.Margin = new Padding(3, 4, 3, 4);
            tApellidoPacienteRegistro.Name = "tApellidoPacienteRegistro";
            tApellidoPacienteRegistro.Size = new Size(310, 27);
            tApellidoPacienteRegistro.TabIndex = 21;
            // 
            // tNombrePacienteRegistro
            // 
            tNombrePacienteRegistro.Location = new Point(53, 124);
            tNombrePacienteRegistro.Margin = new Padding(3, 4, 3, 4);
            tNombrePacienteRegistro.Name = "tNombrePacienteRegistro";
            tNombrePacienteRegistro.Size = new Size(310, 27);
            tNombrePacienteRegistro.TabIndex = 20;
            // 
            // comboBoxTipoRegistro
            // 
            comboBoxTipoRegistro.FormattingEnabled = true;
            comboBoxTipoRegistro.Location = new Point(53, 340);
            comboBoxTipoRegistro.Name = "comboBoxTipoRegistro";
            comboBoxTipoRegistro.Size = new Size(756, 28);
            comboBoxTipoRegistro.TabIndex = 39;
            // 
            // comboBoxMedicacion
            // 
            comboBoxMedicacion.FormattingEnabled = true;
            comboBoxMedicacion.Location = new Point(53, 569);
            comboBoxMedicacion.Name = "comboBoxMedicacion";
            comboBoxMedicacion.Size = new Size(756, 28);
            comboBoxMedicacion.TabIndex = 40;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(53, 611);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 41;
            label6.Text = "label6";
            label6.Visible = false;
            // 
            // AgregarRegistroControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label6);
            Controls.Add(comboBoxMedicacion);
            Controls.Add(comboBoxTipoRegistro);
            Controls.Add(bAtras);
            Controls.Add(lErrorTelefono);
            Controls.Add(lErrorDireccion);
            Controls.Add(lErrorDni);
            Controls.Add(lErrorApellido);
            Controls.Add(lErrorNombre);
            Controls.Add(lMedicacion);
            Controls.Add(lObservaciones);
            Controls.Add(lTipoRegistro);
            Controls.Add(lDniPacienteRegistro);
            Controls.Add(lApellidoPacienteRegistro);
            Controls.Add(lNombrePacienteRegistro);
            Controls.Add(tTelefonoPacienteRegistro);
            Controls.Add(tDniPacienteRegistro);
            Controls.Add(tApellidoPacienteRegistro);
            Controls.Add(tNombrePacienteRegistro);
            Name = "AgregarRegistroControl";
            Size = new Size(878, 767);
            Load += AgregarRegistroControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bAtras;
        private Label lErrorTelefono;
        private Label lErrorDireccion;
        private Label lErrorDni;
        private Label lErrorApellido;
        private Label lErrorNombre;
        private Label lMedicacion;
        private Label lObservaciones;
        private Label lTipoRegistro;
        private Label lDniPacienteRegistro;
        private Label lApellidoPacienteRegistro;
        private Label lNombrePacienteRegistro;
        private TextBox tTelefonoPacienteRegistro;
        private TextBox tDniPacienteRegistro;
        private TextBox tApellidoPacienteRegistro;
        private TextBox tNombrePacienteRegistro;
        private ComboBox comboBoxTipoRegistro;
        private ComboBox comboBoxMedicacion;
        private Label label6;
    }
}
