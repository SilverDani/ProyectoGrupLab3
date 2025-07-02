using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoService.Core.DTOs;
using TecnoService.Core.DTOs.GetAll;
using TecnoService.Core.Models;

namespace TecnoService.Desktop.Ventanas
{
    public partial class AdmMarcas : Form
    {
        public AdmMarcas()
        {
            InitializeComponent();
            this.Load += AdmMarca_Load;
        }

        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7089/")
        };

        private MarcaResumenDTO marcaSeleccionada;

        private async void AdmMarca_Load(object sender, EventArgs e)
        {
            await CargarMarcas();
        }

        private async Task CargarMarcas()
        {
            try
            {
                var marcas = await httpClient.GetFromJsonAsync<List<MarcaResumenDTO>>("api/marca");
                dgvMarcas.AutoGenerateColumns = true;
                dgvMarcas.DataSource = marcas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar marcas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                marcaSeleccionada = (MarcaResumenDTO)dgvMarcas.Rows[e.RowIndex].DataBoundItem;
                txtMarca.Text = marcaSeleccionada.Nombre;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            var nueva = new CrearMarcaDTO { Nombre = txtMarca.Text };

            var response = await httpClient.PostAsJsonAsync("api/marca", nueva);

            if (response.IsSuccessStatusCode)
            {
                txtMarca.Clear();
                await CargarMarcas();
            }
            else
            {
                MessageBox.Show("Error al crear la marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (marcaSeleccionada == null) return;

            var dto = new ActualizarMarcaDTO
            {
                IDMarca = marcaSeleccionada.IDMarca,
                Nombre = txtMarca.Text
            };

            var response = await httpClient.PutAsJsonAsync($"api/marca/{dto.IDMarca}", dto);

            if (response.IsSuccessStatusCode)
            {
                txtMarca.Clear();
                await CargarMarcas();
            }
            else
            {
                MessageBox.Show("Error al modificar la marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (marcaSeleccionada == null) return;

            var result = MessageBox.Show("¿Está seguro que desea eliminar esta marca?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            var response = await httpClient.DeleteAsync($"api/marca/{marcaSeleccionada.IDMarca}");

            if (response.IsSuccessStatusCode)
            {
                txtMarca.Clear();
                await CargarMarcas();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la marca. Asegúrese de que no tenga dispositivos asociados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
