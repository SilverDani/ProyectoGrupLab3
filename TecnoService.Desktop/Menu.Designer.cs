namespace TecnoService.Desktop
{
    partial class Menu
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
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            adminstrarPersonasToolStripMenuItem = new ToolStripMenuItem();
            btnAdmMarcas = new ToolStripMenuItem();
            btnInDis = new ToolStripMenuItem();
            btnFacturar = new ToolStripMenuItem();
            btnAdmPersonas = new ToolStripMenuItem();
            btnAdmTrabajadores = new ToolStripMenuItem();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Coral;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1382, 30);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(18, 87);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 125);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HotTrack;
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 30);
            panel3.Name = "panel3";
            panel3.Size = new Size(1382, 823);
            panel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.TecnoService_Logo;
            pictureBox1.Location = new Point(346, 93);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(710, 439);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminstrarPersonasToolStripMenuItem, btnAdmMarcas, btnInDis, btnFacturar });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1382, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // adminstrarPersonasToolStripMenuItem
            // 
            adminstrarPersonasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnAdmPersonas, btnAdmTrabajadores });
            adminstrarPersonasToolStripMenuItem.Name = "adminstrarPersonasToolStripMenuItem";
            adminstrarPersonasToolStripMenuItem.Size = new Size(157, 24);
            adminstrarPersonasToolStripMenuItem.Text = "Adminstrar Personas";
            // 
            // btnAdmMarcas
            // 
            btnAdmMarcas.Name = "btnAdmMarcas";
            btnAdmMarcas.Size = new Size(151, 24);
            btnAdmMarcas.Text = "Administrar Marcas";
            btnAdmMarcas.Click += btnAdmMarcas_Click;
            // 
            // btnInDis
            // 
            btnInDis.Name = "btnInDis";
            btnInDis.Size = new Size(154, 24);
            btnInDis.Text = "Ingresar Dispositivo";
            btnInDis.Click += btnInDis_Click;
            // 
            // btnFacturar
            // 
            btnFacturar.Name = "btnFacturar";
            btnFacturar.Size = new Size(75, 24);
            btnFacturar.Text = "Facturar";
            btnFacturar.Click += btnFacturar_Click;
            // 
            // btnAdmPersonas
            // 
            btnAdmPersonas.Name = "btnAdmPersonas";
            btnAdmPersonas.Size = new Size(178, 26);
            btnAdmPersonas.Text = "Persona";
            btnAdmPersonas.Click += btnAdmPersonas_Click;
            // 
            // btnAdmTrabajadores
            // 
            btnAdmTrabajadores.Name = "btnAdmTrabajadores";
            btnAdmTrabajadores.Size = new Size(178, 26);
            btnAdmTrabajadores.Text = "Trabajadores";
            btnAdmTrabajadores.Click += btnAdmTrabajadores_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 853);
            Controls.Add(panel3);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem adminstrarPersonasToolStripMenuItem;
        private ToolStripMenuItem btnAdmMarcas;
        private ToolStripMenuItem btnInDis;
        private Panel panel3;
        private PictureBox pictureBox1;
        private ToolStripMenuItem btnAdmPersonas;
        private ToolStripMenuItem btnAdmTrabajadores;
        private ToolStripMenuItem btnFacturar;
    }
}