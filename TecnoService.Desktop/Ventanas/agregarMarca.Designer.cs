namespace TecnoService.Desktop.Ventanas
{
    partial class agregarMarca
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
            btnAgregar = new Button();
            txtMarca = new TextBox();
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
            panel1.Size = new Size(800, 30);
            panel1.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.cerrar_ventana;
            btnCerrar.Location = new Point(770, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(30, 30);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 3;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(btnAgregar);
            panel2.Controls.Add(txtMarca);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 420);
            panel2.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Times New Roman", 12F);
            btnAgregar.Location = new Point(281, 234);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(170, 60);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnMarca_Click;
            // 
            // txtMarca
            // 
            txtMarca.Font = new Font("Times New Roman", 12F);
            txtMarca.Location = new Point(232, 154);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(269, 30);
            txtMarca.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(301, 92);
            label1.Name = "label1";
            label1.Size = new Size(140, 23);
            label1.TabIndex = 0;
            label1.Text = "Agregar Marca";
            // 
            // agregarMarca
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "agregarMarca";
            StartPosition = FormStartPosition.CenterParent;
            Text = "agregarMarca";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Button btnAgregar;
        private TextBox txtMarca;
        private PictureBox btnCerrar;
    }
}