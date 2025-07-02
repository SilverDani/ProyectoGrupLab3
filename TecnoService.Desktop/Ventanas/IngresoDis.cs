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
using TecnoService.Core.Models;

namespace TecnoService.Desktop.Ventanas
{
    public partial class IngresoDis : Form
    {
        public IngresoDis()
        {
            InitializeComponent();
            this.Load += IngresoDis_Load;
        }

        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7089/")
        };

        private async void IngresoDis_Load(object sender, EventArgs e)
        {
            await CargarMarcas();
        }

        private async Task CargarMarcas()
        {
            try
            {
                var marcas = await httpClient.GetFromJsonAsync<List<MarcaResumenDTO>>("api/marca");

                if (marcas != null && marcas.Any())
                {
                    cmbMarca.DataSource = marcas;
                    cmbMarca.DisplayMember = "Nombre";
                    cmbMarca.ValueMember = "IDMarca";
                }
                else
                {
                    MessageBox.Show("No se encontraron marcas en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar marcas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnIngresarDis_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtModelo.Text) ||
                cmbMarca.SelectedValue == null)
            {
                MessageBox.Show("Todos los campos deben estar completos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Crear Persona
                var crearPersona = new CrearPersonaDTO
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Documento = txtDocumento.Text.Trim()
                };
                var personaRes = await httpClient.PostAsJsonAsync("api/persona", crearPersona);
                if (!personaRes.IsSuccessStatusCode) throw new Exception("Error al registrar la persona.");
                var persona = await personaRes.Content.ReadFromJsonAsync<Persona>();

                // Crear Cliente
                var clienteDto = new CrearClienteDTO
                {
                    IDPersona = persona.IDPersona,
                    Telefono = txtTelefono.Text.Trim()
                };
                var clienteRes = await httpClient.PostAsJsonAsync("api/cliente", clienteDto);
                if (!clienteRes.IsSuccessStatusCode) throw new Exception("Error al registrar el cliente.");
                var cliente = await clienteRes.Content.ReadFromJsonAsync<Cliente>();

                // Crear Dispositivo
                var dispoDto = new CrearDispositivoDTO
                {
                    IDMarca = (int)cmbMarca.SelectedValue,
                    Modelo = txtModelo.Text.Trim()
                };
                var dispoRes = await httpClient.PostAsJsonAsync("api/dispositivo", dispoDto);
                if (!dispoRes.IsSuccessStatusCode) throw new Exception("Error al registrar el dispositivo.");
                var dispositivo = await dispoRes.Content.ReadFromJsonAsync<Dispositivo>();

                // Crear Ingreso
                var ingresoDto = new CrearInDisDTO
                {
                    IDCliente = cliente.IDCliente,
                    IDDispositivo = dispositivo.IDDispositivo,
                    FechaIngreso = DateTime.Now
                };
                var ingresoRes = await httpClient.PostAsJsonAsync("api/indis", ingresoDto);
                if (!ingresoRes.IsSuccessStatusCode) throw new Exception("Error al registrar el ingreso.");

                MessageBox.Show("Ingreso registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            txtTelefono.Text = "";
            txtModelo.Text = "";
            cmbMarca.SelectedIndex = -1;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            new Ventanas.agregarMarca().ShowDialog(this);
            CargarMarcas();

        }
    }
}
