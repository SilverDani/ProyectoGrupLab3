namespace TecnoService.Desktop.Ventanas
{
    partial class AdmPersonas
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
            btnEliminar = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            txtDocumento = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvPersona = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersona).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(btnCerrar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1382, 30);
            panel1.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.cerrar_ventana;
            btnCerrar.Location = new Point(1349, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(30, 30);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 1;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.Controls.Add(btnEliminar);
            panel2.Controls.Add(btnModificar);
            panel2.Controls.Add(btnNuevo);
            panel2.Controls.Add(txtDocumento);
            panel2.Controls.Add(txtApellido);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dgvPersona);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(1382, 763);
            panel2.TabIndex = 1;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Times New Roman", 12F);
            btnEliminar.Location = new Point(1139, 648);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(208, 51);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Times New Roman", 12F);
            btnModificar.Location = new Point(1139, 575);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(208, 51);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Times New Roman", 12F);
            btnNuevo.Location = new Point(1139, 510);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(208, 51);
            btnNuevo.TabIndex = 7;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Times New Roman", 12F);
            txtDocumento.Location = new Point(844, 359);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(283, 30);
            txtDocumento.TabIndex = 6;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Times New Roman", 12F);
            txtApellido.Location = new Point(844, 241);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(283, 30);
            txtApellido.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Times New Roman", 12F);
            txtNombre.Location = new Point(844, 102);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(283, 30);
            txtNombre.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label3.Location = new Point(844, 333);
            label3.Name = "label3";
            label3.Size = new Size(105, 23);
            label3.TabIndex = 3;
            label3.Text = "Documento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.Location = new Point(844, 215);
            label2.Name = "label2";
            label2.Size = new Size(79, 23);
            label2.TabIndex = 2;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(844, 76);
            label1.Name = "label1";
            label1.Size = new Size(77, 23);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // dgvPersona
            // 
            dgvPersona.AllowUserToAddRows = false;
            dgvPersona.AllowUserToDeleteRows = false;
            dgvPersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersona.Location = new Point(3, 6);
            dgvPersona.Name = "dgvPersona";
            dgvPersona.ReadOnly = true;
            dgvPersona.RowHeadersWidth = 51;
            dgvPersona.Size = new Size(717, 745);
            dgvPersona.TabIndex = 0;
            // 
            // AdmPersonas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 793);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdmPersonas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AdmPersonas";
            Load += AdmPersona_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersona).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox btnCerrar;
        private Panel panel2;
        private DataGridView dgvPersona;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnNuevo;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}