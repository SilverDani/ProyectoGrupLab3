using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoService.Core.DTOs;
using TecnoService.Core.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace TecnoService.Desktop.Ventanas
{
    public partial class AdmMarcas : Form
    {
        public AdmMarcas()
        {
            InitializeComponent();
        }

        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7151/")
        };

        private async void AdmMarca_Load(object sender, EventArgs e)
        {
            await CargarMarcas();
        }

        private async Task CargarMarcas()
        {
            var response = await httpClient.GetAsync("https://localhost:7151/api/marca");
            if (response.IsSuccessStatusCode)
            {
                var marcas = await response.Content.ReadFromJsonAsync<List<Marca>>();
                dgvMarcas.DataSource = marcas;
            }
        }

        private Marca marcaSeleccionada;

        private void dgvMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            marcaSeleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            txtMarca.Text = marcaSeleccionada.Nombre;
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            var nueva = new CrearMarcaDTO { Nombre = txtMarca.Text };
            await httpClient.PostAsJsonAsync("https://localhost:7151/api/marca", nueva);
            await CargarMarcas();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (marcaSeleccionada == null) return;

            var dto = new ActualizarMarcaDTO { IDMarca = marcaSeleccionada.IDMarca, Nombre = txtMarca.Text };
            await httpClient.PutAsJsonAsync($"https://localhost:7151/api/marca/{dto.IDMarca}", dto);
            await CargarMarcas();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (marcaSeleccionada == null) return;

            await httpClient.DeleteAsync($"https://localhost:7151/api/marca/{marcaSeleccionada.IDMarca}");
            await CargarMarcas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
