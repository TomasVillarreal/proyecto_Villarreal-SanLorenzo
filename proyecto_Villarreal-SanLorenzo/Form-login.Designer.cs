namespace proyecto_Villarreal_SanLorenzo
{
    partial class Form_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_login));
            labelClinicks = new Label();
            labelBienvenido = new Label();
            labelA = new Label();
            labelSH = new Label();
            tbUsuario = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            labelUsuario = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            pictureBox2 = new PictureBox();
            labelPass = new Label();
            tbPass = new TextBox();
            bIniciarSesion = new Button();
            bMostrarPass = new Button();
            button1 = new Button();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // labelClinicks
            // 
            labelClinicks.AutoSize = true;
            labelClinicks.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClinicks.Location = new Point(313, 139);
            labelClinicks.Name = "labelClinicks";
            labelClinicks.Size = new Size(95, 32);
            labelClinicks.TabIndex = 2;
            labelClinicks.Text = "Clinicks";
            labelClinicks.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelBienvenido
            // 
            labelBienvenido.AutoSize = true;
            labelBienvenido.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBienvenido.Location = new Point(296, 45);
            labelBienvenido.Name = "labelBienvenido";
            labelBienvenido.Size = new Size(135, 32);
            labelBienvenido.TabIndex = 3;
            labelBienvenido.Text = "Bienvenido";
            labelBienvenido.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelA
            // 
            labelA.AutoSize = true;
            labelA.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelA.Location = new Point(342, 93);
            labelA.Name = "labelA";
            labelA.Size = new Size(30, 32);
            labelA.TabIndex = 4;
            labelA.Text = "A";
            labelA.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelSH
            // 
            labelSH.AccessibleRole = AccessibleRole.None;
            labelSH.AutoSize = true;
            labelSH.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSH.Location = new Point(233, 190);
            labelSH.Name = "labelSH";
            labelSH.Size = new Size(286, 25);
            labelSH.TabIndex = 6;
            labelSH.Text = "Sistema de Gestión de Pacientes";
            labelSH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbUsuario
            // 
            tbUsuario.BackColor = Color.WhiteSmoke;
            tbUsuario.BorderStyle = BorderStyle.FixedSingle;
            tbUsuario.Cursor = Cursors.Hand;
            tbUsuario.ForeColor = Color.Black;
            tbUsuario.Location = new Point(358, 256);
            tbUsuario.Name = "tbUsuario";
            tbUsuario.Size = new Size(189, 27);
            tbUsuario.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(labelUsuario);
            flowLayoutPanel1.Location = new Point(180, 257);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(156, 31);
            flowLayoutPanel1.TabIndex = 9;
            flowLayoutPanel1.WrapContents = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 23);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelUsuario
            // 
            labelUsuario.Anchor = AnchorStyles.None;
            labelUsuario.AutoSize = true;
            labelUsuario.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUsuario.Location = new Point(40, 4);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(82, 20);
            labelUsuario.TabIndex = 0;
            labelUsuario.Text = "Usuario";
            labelUsuario.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(pictureBox2);
            flowLayoutPanel2.Controls.Add(labelPass);
            flowLayoutPanel2.Location = new Point(180, 306);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(159, 41);
            flowLayoutPanel2.TabIndex = 10;
            flowLayoutPanel2.WrapContents = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(31, 35);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // labelPass
            // 
            labelPass.Anchor = AnchorStyles.None;
            labelPass.AutoSize = true;
            labelPass.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPass.Location = new Point(40, 10);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(116, 20);
            labelPass.TabIndex = 0;
            labelPass.Text = "Contraseña";
            labelPass.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbPass
            // 
            tbPass.BackColor = Color.WhiteSmoke;
            tbPass.BorderStyle = BorderStyle.FixedSingle;
            tbPass.Cursor = Cursors.Hand;
            tbPass.ForeColor = Color.Black;
            tbPass.Location = new Point(358, 317);
            tbPass.Name = "tbPass";
            tbPass.PasswordChar = '*';
            tbPass.Size = new Size(189, 27);
            tbPass.TabIndex = 11;
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
            bIniciarSesion.Location = new Point(192, 385);
            bIniciarSesion.Name = "bIniciarSesion";
            bIniciarSesion.Size = new Size(122, 29);
            bIniciarSesion.TabIndex = 12;
            bIniciarSesion.Text = "Iniciar Sesión";
            bIniciarSesion.UseVisualStyleBackColor = true;
            bIniciarSesion.Click += bIniciarSesion_Click;
            // 
            // bMostrarPass
            // 
            bMostrarPass.Cursor = Cursors.Hand;
            bMostrarPass.FlatAppearance.BorderColor = Color.Silver;
            bMostrarPass.FlatAppearance.MouseDownBackColor = Color.LightGray;
            bMostrarPass.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            bMostrarPass.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bMostrarPass.ForeColor = Color.Black;
            bMostrarPass.Image = Resource1.ojoCerrado;
            bMostrarPass.Location = new Point(553, 317);
            bMostrarPass.Name = "bMostrarPass";
            bMostrarPass.Size = new Size(33, 29);
            bMostrarPass.TabIndex = 13;
            bMostrarPass.UseVisualStyleBackColor = true;
            bMostrarPass.Click += bMostrarPass_Click;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.Silver;
            button1.FlatAppearance.MouseDownBackColor = Color.LightGray;
            button1.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Image = Resource1.cerrar_sesion__1_;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(386, 385);
            button1.Name = "button1";
            button1.Size = new Size(123, 29);
            button1.TabIndex = 14;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form_login
            // 
            AcceptButton = bIniciarSesion;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 512);
            Controls.Add(button1);
            Controls.Add(bMostrarPass);
            Controls.Add(bIniciarSesion);
            Controls.Add(tbPass);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tbUsuario);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(labelSH);
            Controls.Add(labelA);
            Controls.Add(labelBienvenido);
            Controls.Add(labelClinicks);
            Name = "Form_login";
            Text = "Form_login";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelClinicks;
        private Label labelBienvenido;
        private Label labelA;
        private Label labelSH;
        private TextBox tbUsuario;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
        private Label labelUsuario;
        private FlowLayoutPanel flowLayoutPanel2;
        private PictureBox pictureBox2;
        private Label labelPass;
        private TextBox tbPass;
        private Button bIniciarSesion;
        private Button bMostrarPass;
        private Button button1;
    }
}