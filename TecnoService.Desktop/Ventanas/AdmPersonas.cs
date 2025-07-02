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
using TecnoService.Core.DTOs.GetById;
using TecnoService.Core.Models;

namespace TecnoService.Desktop.Ventanas
{
    public partial class AdmPersonas : Form
    {
        public AdmPersonas()
        {
            InitializeComponent();
            this.Load += AdmPersona_Load;
        }

        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7089/")
        };

        private PersonaDetalleDTO personaSeleccionada;

        private async void AdmPersona_Load(object sender, EventArgs e)
        {
            await CargarPersonas();
        }

        private async Task CargarPersonas()
        {
            try
            {
                var personas = await httpClient.GetFromJsonAsync<List<PersonaDetalleDTO>>("api/persona");
                dgvPersona.AutoGenerateColumns = true;
                dgvPersona.DataSource = personas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPersona_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            personaSeleccionada = (PersonaDetalleDTO)dgvPersona.CurrentRow.DataBoundItem;
            txtNombre.Text = personaSeleccionada.Nombre;
            txtApellido.Text = personaSeleccionada.Apellido;
            txtDocumento.Text = personaSeleccionada.Documento;
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            var dto = new CrearPersonaDTO
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Documento = txtDocumento.Text.Trim()
            };

            try
            {
                var response = await httpClient.PostAsJsonAsync("api/persona", dto);
                if (response.IsSuccessStatusCode)
                {
                    LimpiarCampos();
                    await CargarPersonas();
                }
                else
                {
                    MessageBox.Show("Error al crear persona.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (personaSeleccionada == null) return;

            var dto = new ActualizarPersonaDTO
            {
                IDPersona = personaSeleccionada.IDPersona,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Documento = txtDocumento.Text.Trim()
            };

            try
            {
                var response = await httpClient.PutAsJsonAsync($"api/persona/{dto.IDPersona}", dto);
                if (response.IsSuccessStatusCode)
                {
                    LimpiarCampos();
                    await CargarPersonas();
                }
                else
                {
                    MessageBox.Show("Error al modificar persona.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (personaSeleccionada == null) return;

            var result = MessageBox.Show("¿Seguro que desea eliminar esta persona?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            try
            {
                var response = await httpClient.DeleteAsync($"api/persona/{personaSeleccionada.IDPersona}");
                if (response.IsSuccessStatusCode)
                {
                    LimpiarCampos();
                    await CargarPersonas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la persona.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            personaSeleccionada = null;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
