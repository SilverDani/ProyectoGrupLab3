namespace TecnoService.Desktop.Ventanas
{
    partial class AdmMarcas
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
            txtMarca = new TextBox();
            label1 = new Label();
            dgvMarcas = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(btnCerrar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 30);
            panel1.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.cerrar_ventana;
            btnCerrar.Location = new Point(670, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(30, 30);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 0;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(btnEliminar);
            panel2.Controls.Add(btnModificar);
            panel2.Controls.Add(btnNuevo);
            panel2.Controls.Add(txtMarca);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dgvMarcas);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(700, 670);
            panel2.TabIndex = 1;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Times New Roman", 12F);
            btnEliminar.Location = new Point(410, 446);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(125, 43);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Times New Roman", 12F);
            btnModificar.Location = new Point(410, 374);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(125, 43);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Times New Roman", 12F);
            btnNuevo.Location = new Point(411, 310);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(122, 43);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // txtMarca
            // 
            txtMarca.Font = new Font("Times New Roman", 12F);
            txtMarca.Location = new Point(381, 203);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(182, 30);
            txtMarca.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(381, 134);
            label1.Name = "label1";
            label1.Size = new Size(182, 23);
            label1.TabIndex = 1;
            label1.Text = "Nombre de la Marca";
            // 
            // dgvMarcas
            // 
            dgvMarcas.AllowUserToAddRows = false;
            dgvMarcas.AllowUserToDeleteRows = false;
            dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarcas.Location = new Point(3, 3);
            dgvMarcas.Name = "dgvMarcas";
            dgvMarcas.ReadOnly = true;
            dgvMarcas.RowHeadersWidth = 51;
            dgvMarcas.Size = new Size(300, 664);
            dgvMarcas.TabIndex = 0;
            dgvMarcas.CellDoubleClick += dgvMarcas_CellDoubleClick;
            // 
            // AdmMarcas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 700);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdmMarcas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AdmMarcas";
            Load += AdmMarca_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox btnCerrar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnNuevo;
        private TextBox txtMarca;
        private Label label1;
        private DataGridView dgvMarcas;
    }
}