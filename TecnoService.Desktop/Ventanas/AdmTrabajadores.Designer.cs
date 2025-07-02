namespace TecnoService.Desktop.Ventanas
{
    partial class AdmTrabajadores
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
            dgvTrabajadores = new DataGridView();
            dgvPersonas = new DataGridView();
            label1 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtApellido = new TextBox();
            label3 = new Label();
            txtDocumento = new TextBox();
            label4 = new Label();
            txtCorreo = new TextBox();
            label5 = new Label();
            txtDireccion = new TextBox();
            label6 = new Label();
            dtpFechaNac = new DateTimePicker();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrabajadores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(btnCerrar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1039, 30);
            panel1.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.cerrar_ventana;
            btnCerrar.Location = new Point(1009, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(30, 30);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 1;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(btnEliminar);
            panel2.Controls.Add(btnModificar);
            panel2.Controls.Add(btnNuevo);
            panel2.Controls.Add(dtpFechaNac);
            panel2.Controls.Add(txtDocumento);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtDireccion);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtApellido);
            panel2.Controls.Add(txtCorreo);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dgvTrabajadores);
            panel2.Controls.Add(dgvPersonas);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(1039, 738);
            panel2.TabIndex = 1;
            // 
            // dgvTrabajadores
            // 
            dgvTrabajadores.AllowUserToAddRows = false;
            dgvTrabajadores.AllowUserToDeleteRows = false;
            dgvTrabajadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrabajadores.Location = new Point(3, 430);
            dgvTrabajadores.Name = "dgvTrabajadores";
            dgvTrabajadores.ReadOnly = true;
            dgvTrabajadores.RowHeadersWidth = 51;
            dgvTrabajadores.Size = new Size(1033, 305);
            dgvTrabajadores.TabIndex = 1;
            dgvTrabajadores.CellDoubleClick += dgvTrabajadores_CellDoubleClick;
            // 
            // dgvPersonas
            // 
            dgvPersonas.AllowUserToAddRows = false;
            dgvPersonas.AllowUserToDeleteRows = false;
            dgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonas.Location = new Point(4, 4);
            dgvPersonas.Name = "dgvPersonas";
            dgvPersonas.ReadOnly = true;
            dgvPersonas.RowHeadersWidth = 51;
            dgvPersonas.Size = new Size(393, 420);
            dgvPersonas.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(403, 24);
            label1.Name = "label1";
            label1.Size = new Size(77, 23);
            label1.TabIndex = 2;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Times New Roman", 12F);
            txtNombre.Location = new Point(403, 56);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(246, 30);
            txtNombre.TabIndex = 1;
            txtNombre.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.Location = new Point(403, 117);
            label2.Name = "label2";
            label2.Size = new Size(79, 23);
            label2.TabIndex = 2;
            label2.Text = "Apellido";
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Times New Roman", 12F);
            txtApellido.Location = new Point(403, 149);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(246, 30);
            txtApellido.TabIndex = 1;
            txtApellido.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label3.Location = new Point(403, 204);
            label3.Name = "label3";
            label3.Size = new Size(105, 23);
            label3.TabIndex = 2;
            label3.Text = "Documento";
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Times New Roman", 12F);
            txtDocumento.Location = new Point(403, 236);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(246, 30);
            txtDocumento.TabIndex = 1;
            txtDocumento.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label4.Location = new Point(655, 24);
            label4.Name = "label4";
            label4.Size = new Size(70, 23);
            label4.TabIndex = 2;
            label4.Text = "Correo";
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Times New Roman", 12F);
            txtCorreo.Location = new Point(655, 56);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(246, 30);
            txtCorreo.TabIndex = 1;
            txtCorreo.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label5.Location = new Point(655, 117);
            label5.Name = "label5";
            label5.Size = new Size(90, 23);
            label5.TabIndex = 2;
            label5.Text = "Dirección";
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Times New Roman", 12F);
            txtDireccion.Location = new Point(655, 149);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(246, 30);
            txtDireccion.TabIndex = 1;
            txtDireccion.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label6.Location = new Point(655, 208);
            label6.Name = "label6";
            label6.Size = new Size(185, 23);
            label6.TabIndex = 2;
            label6.Text = "Fecha de Nacimiento";
            // 
            // dtpFechaNac
            // 
            dtpFechaNac.Font = new Font("Times New Roman", 12F);
            dtpFechaNac.Location = new Point(655, 236);
            dtpFechaNac.Name = "dtpFechaNac";
            dtpFechaNac.Size = new Size(250, 30);
            dtpFechaNac.TabIndex = 3;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Times New Roman", 12F);
            btnNuevo.Location = new Point(445, 336);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(143, 46);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Times New Roman", 12F);
            btnModificar.Location = new Point(626, 336);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(143, 46);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Times New Roman", 12F);
            btnEliminar.Location = new Point(797, 336);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(143, 46);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // AdmTrabajadores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 768);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdmTrabajadores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AdmTrabajadores";
            Load += AdmTrabajadores_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrabajadores).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox btnCerrar;
        private Panel panel2;
        private DataGridView dgvTrabajadores;
        private DataGridView dgvPersonas;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnNuevo;
        private DateTimePicker dtpFechaNac;
        private TextBox txtDocumento;
        private Label label6;
        private Label label3;
        private TextBox txtDireccion;
        private Label label5;
        private TextBox txtApellido;
        private TextBox txtCorreo;
        private Label label2;
        private Label label4;
        private TextBox txtNombre;
        private Label label1;
    }
}