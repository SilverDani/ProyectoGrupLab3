namespace TecnoService.Desktop.Ventanas
{
    partial class IngresoDis
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
            panel1 = new Panel();
            btnCerrar = new PictureBox();
            panel2 = new Panel();
            btnAgregarMarca = new Button();
            cmbMarca = new ComboBox();
            txtTelefono = new TextBox();
            txtDocumento = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            txtModelo = new TextBox();
            btnIngresarDis = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(btnCerrar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(598, 30);
            panel1.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.cerrar_ventana;
            btnCerrar.Location = new Point(565, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(30, 30);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 2;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(btnAgregarMarca);
            panel2.Controls.Add(cmbMarca);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(txtDocumento);
            panel2.Controls.Add(txtApellido);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(txtModelo);
            panel2.Controls.Add(btnIngresarDis);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(598, 517);
            panel2.TabIndex = 1;
            // 
            // btnAgregarMarca
            // 
            btnAgregarMarca.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnAgregarMarca.Location = new Point(230, 81);
            btnAgregarMarca.Margin = new Padding(0);
            btnAgregarMarca.Name = "btnAgregarMarca";
            btnAgregarMarca.Size = new Size(25, 25);
            btnAgregarMarca.TabIndex = 13;
            btnAgregarMarca.Text = "+";
            btnAgregarMarca.UseVisualStyleBackColor = true;
            btnAgregarMarca.Click += btnAgregarMarca_Click;
            // 
            // cmbMarca
            // 
            cmbMarca.Font = new Font("Times New Roman", 12F);
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(32, 76);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(192, 30);
            cmbMarca.TabIndex = 12;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Times New Roman", 12F);
            txtTelefono.Location = new Point(271, 347);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(273, 30);
            txtTelefono.TabIndex = 11;
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Times New Roman", 12F);
            txtDocumento.Location = new Point(275, 256);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(273, 30);
            txtDocumento.TabIndex = 10;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Times New Roman", 12F);
            txtApellido.Location = new Point(271, 159);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(273, 30);
            txtApellido.TabIndex = 9;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Times New Roman", 12F);
            txtNombre.Location = new Point(271, 76);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(273, 30);
            txtNombre.TabIndex = 8;
            // 
            // txtModelo
            // 
            txtModelo.Font = new Font("Times New Roman", 12F);
            txtModelo.Location = new Point(32, 170);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(192, 30);
            txtModelo.TabIndex = 7;
            // 
            // btnIngresarDis
            // 
            btnIngresarDis.Font = new Font("Times New Roman", 12F);
            btnIngresarDis.Location = new Point(153, 410);
            btnIngresarDis.Name = "btnIngresarDis";
            btnIngresarDis.Size = new Size(168, 71);
            btnIngresarDis.TabIndex = 6;
            btnIngresarDis.Text = "Ingresaar Dispositivo";
            btnIngresarDis.UseVisualStyleBackColor = true;
            btnIngresarDis.Click += btnIngresarDis_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label6.Location = new Point(271, 321);
            label6.Name = "label6";
            label6.Size = new Size(83, 23);
            label6.TabIndex = 5;
            label6.Text = "Telefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label5.Location = new Point(271, 220);
            label5.Name = "label5";
            label5.Size = new Size(105, 23);
            label5.TabIndex = 4;
            label5.Text = "Documento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label4.Location = new Point(271, 133);
            label4.Name = "label4";
            label4.Size = new Size(79, 23);
            label4.TabIndex = 3;
            label4.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label3.Location = new Point(271, 36);
            label3.Name = "label3";
            label3.Size = new Size(77, 23);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.Location = new Point(29, 133);
            label2.Name = "label2";
            label2.Size = new Size(73, 23);
            label2.TabIndex = 1;
            label2.Text = "Modelo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(32, 36);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 0;
            label1.Text = "Marca";
            // 
            // IngresoDis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 547);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "IngresoDis";
            StartPosition = FormStartPosition.CenterParent;
            Text = "IngresoDis";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox btnCerrar;
        private Panel panel2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAgregarMarca;
        private ComboBox cmbMarca;
        private TextBox txtTelefono;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TextBox txtModelo;
        private Button btnIngresarDis;
    }
}