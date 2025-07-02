namespace TecnoService.Desktop.Ventanas
{
    partial class Facturar
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
            btnFacturar = new Button();
            txtDetalle = new TextBox();
            txtMonto = new TextBox();
            txtTecnico = new TextBox();
            txtNombreCliente = new TextBox();
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            label7 = new Label();
            dgvTecnicos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            dgvDisIngresados = new DataGridView();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDisIngresados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(btnCerrar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(988, 30);
            panel1.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.cerrar_ventana;
            btnCerrar.Location = new Point(955, 0);
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
            panel2.Controls.Add(btnFacturar);
            panel2.Controls.Add(txtDetalle);
            panel2.Controls.Add(txtMonto);
            panel2.Controls.Add(txtTecnico);
            panel2.Controls.Add(txtNombreCliente);
            panel2.Controls.Add(txtModelo);
            panel2.Controls.Add(txtMarca);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(dgvTecnicos);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(dgvDisIngresados);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(988, 680);
            panel2.TabIndex = 1;
            // 
            // btnFacturar
            // 
            btnFacturar.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnFacturar.Location = new Point(585, 613);
            btnFacturar.Name = "btnFacturar";
            btnFacturar.Size = new Size(253, 64);
            btnFacturar.TabIndex = 16;
            btnFacturar.Text = "Facturar";
            btnFacturar.UseVisualStyleBackColor = true;
            btnFacturar.Click += btnFacturar_Click;
            // 
            // txtDetalle
            // 
            txtDetalle.Font = new Font("Times New Roman", 12F);
            txtDetalle.Location = new Point(436, 432);
            txtDetalle.Multiline = true;
            txtDetalle.Name = "txtDetalle";
            txtDetalle.Size = new Size(540, 175);
            txtDetalle.TabIndex = 15;
            // 
            // txtMonto
            // 
            txtMonto.Font = new Font("Times New Roman", 12F);
            txtMonto.Location = new Point(436, 362);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(243, 30);
            txtMonto.TabIndex = 14;
            // 
            // txtTecnico
            // 
            txtTecnico.Font = new Font("Times New Roman", 12F);
            txtTecnico.Location = new Point(436, 287);
            txtTecnico.Name = "txtTecnico";
            txtTecnico.Size = new Size(243, 30);
            txtTecnico.TabIndex = 13;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Font = new Font("Times New Roman", 12F);
            txtNombreCliente.Location = new Point(436, 212);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(243, 30);
            txtNombreCliente.TabIndex = 12;
            // 
            // txtModelo
            // 
            txtModelo.Font = new Font("Times New Roman", 12F);
            txtModelo.Location = new Point(436, 126);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(243, 30);
            txtModelo.TabIndex = 11;
            // 
            // txtMarca
            // 
            txtMarca.Font = new Font("Times New Roman", 12F);
            txtMarca.Location = new Point(436, 55);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(243, 30);
            txtMarca.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label7.Location = new Point(436, 250);
            label7.Name = "label7";
            label7.Size = new Size(75, 23);
            label7.TabIndex = 9;
            label7.Text = "Técnico";
            // 
            // dgvTecnicos
            // 
            dgvTecnicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTecnicos.Location = new Point(685, 55);
            dgvTecnicos.Name = "dgvTecnicos";
            dgvTecnicos.RowHeadersWidth = 51;
            dgvTecnicos.Size = new Size(300, 332);
            dgvTecnicos.TabIndex = 8;
            dgvTecnicos.CellDoubleClick += dgvTecnicos_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(436, 328);
            label1.Name = "label1";
            label1.Size = new Size(167, 23);
            label1.TabIndex = 2;
            label1.Text = "Monto del Trabajo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.Location = new Point(436, 402);
            label2.Name = "label2";
            label2.Size = new Size(170, 23);
            label2.TabIndex = 3;
            label2.Text = "Detalle del Arreglo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label3.Location = new Point(728, 29);
            label3.Name = "label3";
            label3.Size = new Size(238, 23);
            label3.TabIndex = 4;
            label3.Text = "Tecnico que hizo el Arreglo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label5.Location = new Point(436, 95);
            label5.Name = "label5";
            label5.Size = new Size(73, 23);
            label5.TabIndex = 6;
            label5.Text = "Modelo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label6.Location = new Point(436, 180);
            label6.Name = "label6";
            label6.Size = new Size(173, 23);
            label6.TabIndex = 7;
            label6.Text = "Nombre del Cliente";
            // 
            // dgvDisIngresados
            // 
            dgvDisIngresados.AllowUserToAddRows = false;
            dgvDisIngresados.AllowUserToDeleteRows = false;
            dgvDisIngresados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDisIngresados.Location = new Point(3, 6);
            dgvDisIngresados.Name = "dgvDisIngresados";
            dgvDisIngresados.ReadOnly = true;
            dgvDisIngresados.RowHeadersWidth = 51;
            dgvDisIngresados.Size = new Size(415, 662);
            dgvDisIngresados.TabIndex = 0;
            dgvDisIngresados.CellDoubleClick += dgvDisIngresados_CellDoubleClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label4.Location = new Point(436, 20);
            label4.Name = "label4";
            label4.Size = new Size(65, 23);
            label4.TabIndex = 5;
            label4.Text = "Marca";
            // 
            // Facturar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 710);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Facturar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Facturar";
            Load += Facturar_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDisIngresados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox btnCerrar;
        private DataGridView dgvDisIngresados;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label4;
        private TextBox txtDetalle;
        private TextBox txtMonto;
        private TextBox txtTecnico;
        private TextBox txtNombreCliente;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private Label label7;
        private DataGridView dgvTecnicos;
        private Button btnFacturar;
    }
}