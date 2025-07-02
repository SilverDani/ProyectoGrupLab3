using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoService.Core.DTOs;

namespace TecnoService.Desktop.Ventanas
{
    public partial class agregarMarca : Form
    {
        public agregarMarca()
        {
            InitializeComponent();
        }

        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7089/")
        };

        private async void btnMarca_Click(object sender, EventArgs e)
        {
            var nueva = new CrearMarcaDTO { Nombre = txtMarca.Text };
            await httpClient.PostAsJsonAsync("https://localhost:7089/api/marca", nueva);
            MessageBox.Show("Marca agregada correctamente.");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
