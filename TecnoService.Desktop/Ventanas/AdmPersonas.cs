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
using TecnoService.Core.Models;

namespace TecnoService.Desktop.Ventanas
{
    public partial class AdmPersonas : Form
    {
        public AdmPersonas()
        {
            InitializeComponent();
        }

        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7089/")
        };

        private Persona personaSeleccionada;

        private async void AdmPersona_Load(object sender, EventArgs e)
        {
            await CargarPersonas();
        }

        private async Task CargarPersonas()
        {
            var personas = await httpClient.GetFromJsonAsync<List<Persona>>("https://localhost:7089/api/persona");
            dgvPersona.DataSource = personas;
        }

        private void dgvPersona_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            personaSeleccionada = (Persona)dgvPersona.CurrentRow.DataBoundItem;
            txtNombre.Text = personaSeleccionada.Nombre;
            txtApellido.Text = personaSeleccionada.Apellido;
            txtDocumento.Text = personaSeleccionada.Documento;
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            var dto = new CrearPersonaDTO
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Documento = txtDocumento.Text
            };
            await httpClient.PostAsJsonAsync("https://localhost:7089/api/persona", dto);
            await CargarPersonas();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (personaSeleccionada == null) return;

            var dto = new ActualizarPersonaDTO
            {
                IDPersona = personaSeleccionada.IDPersona,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Documento = txtDocumento.Text
            };
            await httpClient.PutAsJsonAsync($"https://localhost:7089/api/persona/{dto.IDPersona}", dto);
            await CargarPersonas();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (personaSeleccionada == null) return;

            await httpClient.DeleteAsync($"https://localhost:7089/api/persona/{personaSeleccionada.IDPersona}");
            await CargarPersonas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
