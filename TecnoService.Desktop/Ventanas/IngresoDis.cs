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
    public partial class IngresoDis : Form
    {
        public IngresoDis()
        {
            InitializeComponent();
        }

        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7089/")
        };

        private async void IngresoDis_Load(object sender, EventArgs e)
        {
            var marcas = await httpClient.GetFromJsonAsync<List<Marca>>("https://localhost:7089/api/marca");
            cmbMarca.DataSource = marcas;
            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.ValueMember = "IDMarca";
        }

        private async void btnIngresarDis_Click(object sender, EventArgs e)
        {
            var crearPersona = new CrearPersonaDTO
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Documento = txtDocumento.Text
            };
            var personaRes = await httpClient.PostAsJsonAsync("https://localhost:7089/api/persona", crearPersona);
            var persona = await personaRes.Content.ReadFromJsonAsync<Persona>();

            var clienteDto = new CrearClienteDTO
            {
                IDPersona = persona.IDPersona,
                Telefono = txtTelefono.Text
            };
            var clienteRes = await httpClient.PostAsJsonAsync("https://localhost:7089/api/cliente", clienteDto);
            var cliente = await clienteRes.Content.ReadFromJsonAsync<Cliente>();

            var dispoDto = new CrearDispositivoDTO
            {
                IDMarca = (int)cmbMarca.SelectedValue,
                Modelo = txtModelo.Text
            };
            var dispoRes = await httpClient.PostAsJsonAsync("https://localhost:7089/api/dispositivo", dispoDto);
            var dispositivo = await dispoRes.Content.ReadFromJsonAsync<Dispositivo>();

            var ingresoDto = new CrearInDisDTO
            {
                IDCliente = cliente.IDCliente,
                IDDispositivo = dispositivo.IDDispositivo,
                FechaIngreso = DateTime.Now
            };
            await httpClient.PostAsJsonAsync("https://localhost:7089/api/indis", ingresoDto);

            MessageBox.Show("Ingreso registrado correctamente.");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {

        }
    }
}
