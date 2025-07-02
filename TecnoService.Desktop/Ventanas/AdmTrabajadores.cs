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

namespace TecnoService.Desktop.Ventanas
{
    public partial class AdmTrabajadores : Form
    {
        public AdmTrabajadores()
        {
            InitializeComponent();
        }

        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7151/")
        };

        private Persona personaSeleccionada;
        private Trabajador trabajadorSeleccionado;

        private async void AdmTrabajadores_Load(object sender, EventArgs e)
        {
            await CargarPersonas();
            await CargarTrabajadores();
        }

        private async Task CargarPersonas()
        {
            var personas = await httpClient.GetFromJsonAsync<List<Persona>>("https://localhost:7151/api/persona");
            dgvPersonas.DataSource = personas;
        }

        private async Task CargarTrabajadores()
        {
            var trabajadores = await httpClient.GetFromJsonAsync<List<Trabajador>>("https://localhost:7151/api/trabajador");
            dgvTrabajadores.DataSource = trabajadores;
        }

        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            personaSeleccionada = (Persona)dgvPersonas.CurrentRow.DataBoundItem;
            txtNombre.Text = personaSeleccionada.Nombre;
            txtApellido.Text = personaSeleccionada.Apellido;
            txtDocumento.Text = personaSeleccionada.Documento;
        }

        private void dgvTrabajadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            trabajadorSeleccionado = (Trabajador)dgvTrabajadores.CurrentRow.DataBoundItem;
            txtCorreo.Text = trabajadorSeleccionado.Email;
            txtDireccion.Text = trabajadorSeleccionado.Telefono;
            dtpFechaNac.Value = trabajadorSeleccionado.FechaNacimiento;
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            if (personaSeleccionada == null) return;

            var dto = new CrearTrabajadorDTO
            {
                IDPersona = personaSeleccionada.IDPersona,
                Email = txtCorreo.Text,
                Telefono = txtDireccion.Text,
                FechaNacimiento = dtpFechaNac.Value
            };

            await httpClient.PostAsJsonAsync("https://localhost:7151/api/trabajador", dto);
            await CargarTrabajadores();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (trabajadorSeleccionado == null) return;

            var dto = new ActualizarTrabajadorDTO
            {
                IDTrabajador = trabajadorSeleccionado.IDTrabajador,
                IDPersona = trabajadorSeleccionado.IDPersona,
                Email = txtCorreo.Text,
                Telefono = txtDireccion.Text,
                FechaNacimiento = trabajadorSeleccionado.FechaNacimiento
            };

            await httpClient.PutAsJsonAsync($"https://localhost:7151/api/trabajador/{dto.IDTrabajador}", dto);
            await CargarTrabajadores();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (trabajadorSeleccionado == null) return;

            await httpClient.DeleteAsync($"https://localhost:7151/api/trabajador/{trabajadorSeleccionado.IDTrabajador}");
            await CargarTrabajadores();
        }





    }
}
