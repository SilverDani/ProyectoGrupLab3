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
using TecnoService.Core.DTOs.GetAll;
using TecnoService.Core.DTOs.GetById;
using TecnoService.Core.Models;

namespace TecnoService.Desktop.Ventanas
{
    public partial class AdmTrabajadores : Form
    {
        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7089/")
        };

        private int? idPersonaSeleccionada = null;
        private int? idTrabajadorSeleccionado = null;

        public AdmTrabajadores()
        {
            InitializeComponent();
            this.Load += AdmTrabajadores_Load;
        }

        private async void AdmTrabajadores_Load(object sender, EventArgs e)
        {
            await CargarPersonasDisponibles();
            await CargarTrabajadores();
        }

        private async Task CargarPersonasDisponibles()
        {
            try
            {
                var personas = await httpClient.GetFromJsonAsync<List<PersonaDetalleDTO>>("api/persona/disponibles");
                dgvPersonas.AutoGenerateColumns = true;
                dgvPersonas.DataSource = personas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar personas disponibles: {ex.Message}");
            }
        }

        private async Task CargarTrabajadores()
        {
            try
            {
                var trabajadores = await httpClient.GetFromJsonAsync<List<TrabajadorResumenDTO>>("api/trabajador/resumen");
                dgvTrabajadores.AutoGenerateColumns = true;
                dgvTrabajadores.DataSource = trabajadores;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar trabajadores: {ex.Message}");
            }
        }

        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var persona = (PersonaDetalleDTO)dgvPersonas.Rows[e.RowIndex].DataBoundItem;
                idPersonaSeleccionada = persona.IDPersona;


                txtNombre.Text = persona.Nombre ?? "";
                txtApellido.Text = persona.Apellido ?? "";
                txtDocumento.Text = persona.Documento ?? "";

                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtDocumento.Enabled = false;
            }
        }

        private async void dgvTrabajadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var seleccionado = (TrabajadorResumenDTO)dgvTrabajadores.Rows[e.RowIndex].DataBoundItem;
                idTrabajadorSeleccionado = seleccionado.IDTrabajador;

                var trabajador = await httpClient.GetFromJsonAsync<TrabajadorDetalleDTO>($"api/trabajador/{idTrabajadorSeleccionado}");

                txtCorreo.Text = trabajador.Email;
                txtDireccion.Text = trabajador.Telefono;
                dtpFechaNac.Value = trabajador.FechaNacimiento;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            if (idPersonaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una persona disponible.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Debe completar el correo y el teléfono.");
                return;
            }

            var nuevo = new CrearTrabajadorDTO
            {
                IDPersona = idPersonaSeleccionada.Value,
                Email = txtCorreo.Text.Trim(),
                Telefono = txtDireccion.Text.Trim(),
                FechaNacimiento = dtpFechaNac.Value
            };

            try
            {
                var res = await httpClient.PostAsJsonAsync("api/trabajador", nuevo);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Trabajador creado.");
                    LimpiarCampos();
                    await CargarPersonasDisponibles();
                    await CargarTrabajadores();
                }
                else
                {
                    MessageBox.Show("Error al crear trabajador.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}");
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (idTrabajadorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un trabajador para modificar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Debe completar el correo y el teléfono.");
                return;
            }

            var actualizar = new ActualizarTrabajadorDTO
            {
                IDTrabajador = idTrabajadorSeleccionado.Value,
                Email = txtCorreo.Text.Trim(),
                Telefono = txtDireccion.Text.Trim(),
                FechaNacimiento = dtpFechaNac.Value
            };

            try
            {
                var res = await httpClient.PutAsJsonAsync($"api/trabajador/{actualizar.IDTrabajador}", actualizar);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Trabajador actualizado.");
                    LimpiarCampos();
                    await CargarTrabajadores();
                }
                else
                {
                    MessageBox.Show("Error al actualizar trabajador.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idTrabajadorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un trabajador para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar al trabajador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            var res = await httpClient.DeleteAsync($"api/trabajador/{idTrabajadorSeleccionado}");

            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Trabajador eliminado.");
                LimpiarCampos();
                await CargarTrabajadores();
                await CargarPersonasDisponibles();
            }
            else
            {
                MessageBox.Show("Error al eliminar trabajador.");
            }
        }

        private void LimpiarCampos()
        {
            idTrabajadorSeleccionado = null;
            idPersonaSeleccionada = null;

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";

            txtCorreo.Text = "";
            txtDireccion.Text = "";
            dtpFechaNac.Value = DateTime.Now;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
