using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TecnoService.Desktop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnAdmPersonas_Click(object sender, EventArgs e)
        {
            new Ventanas.AdmPersonas().ShowDialog(this);
        }

        private void btnAdmTrabajadores_Click(object sender, EventArgs e)
        {
            new Ventanas.AdmTrabajadores().ShowDialog(this);
        }

        private void btnAdmMarcas_Click(object sender, EventArgs e)
        {
            new Ventanas.AdmMarcas().ShowDialog(this);

        }

        private void btnInDis_Click(object sender, EventArgs e)
        {
            new Ventanas.IngresoDis().ShowDialog(this);
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            new Ventanas.Facturar().ShowDialog(this);
        }
    }
}
