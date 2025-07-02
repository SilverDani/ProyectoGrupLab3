using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoService.Core.DTOs;
using TecnoService.Core.Models;
using TecnoService.Desktop.viewModel;

namespace TecnoService.Desktop.Ventanas
{
    public partial class Facturar : Form
    {
        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7151/")
        };

        private int? idInDisSeleccionado = null;
        private int? idTrabajadorSeleccionado = null;

        public Facturar()
        {
            InitializeComponent();
            this.Load += Facturar_Load;
        }

        private async void Facturar_Load(object sender, EventArgs e)
        {
            await CargarIngresos();
            await CargarTecnicos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDisIngresados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var seleccionado = (IngresoView)dgvDisIngresados.Rows[e.RowIndex].DataBoundItem;
                idInDisSeleccionado = seleccionado.IDInDis;

                txtMarca.Text = seleccionado.Marca;
                txtModelo.Text = seleccionado.Modelo;
                txtNombreCliente.Text = seleccionado.Cliente;
            }
        }

        private async Task CargarIngresos()
        {
            try
            {
                var ingresos = await httpClient.GetFromJsonAsync<List<InDis>>("api/indis");

                var vista = ingresos
                    .Where(i => i.Factura == null)
                    .Select(i => new IngresoView
                    {
                        IDInDis = i.IDInDis,
                        Marca = i.Dispositivo.Marca?.Nombre,
                        Modelo = i.Dispositivo.Modelo,
                        Cliente = $"{i.Cliente.Persona?.Nombre} {i.Cliente.Persona?.Apellido}"
                    }).ToList();

                dgvDisIngresados.DataSource = vista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ingresos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task CargarTecnicos()
        {
            try
            {
                var trabajadores = await httpClient.GetFromJsonAsync<List<Trabajador>>("api/trabajador");

                var lista = trabajadores.Select(t => new TrabajadorView
                {
                    IDTrabajador = t.IDTrabajador,
                    NombreCompleto = $"{t.Persona?.Nombre} {t.Persona?.Apellido}"
                }).ToList();

                dgvTecnicos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los tecnicos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvTecnicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var seleccionado = (TrabajadorView)dgvTecnicos.Rows[e.RowIndex].DataBoundItem;
                idTrabajadorSeleccionado = seleccionado.IDTrabajador;
                txtTecnico.Text = seleccionado.NombreCompleto;
            }
        }

        private async void btnFacturar_Click(object sender, EventArgs e)
        {
            if (idInDisSeleccionado == null)
            {
                MessageBox.Show("Seleccione un ingreso de dispositivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idTrabajadorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un técnico.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                MessageBox.Show("Ingrese el detalle del arreglo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var factura = new CrearFacturaDTO
            {
                IDInDis = idInDisSeleccionado.Value,
                IDTrabajador = idTrabajadorSeleccionado.Value,
                Monto = monto,
                DetalleArreglo = txtDetalle.Text.Trim(),
                FechaRetiro = DateTime.Now
            };

            var response = await httpClient.PostAsJsonAsync("api/factura", factura);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Factura registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al registrar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LimpiarCampos()
        {
            idInDisSeleccionado = null;
            idTrabajadorSeleccionado = null;

            txtMarca.Text = "";
            txtModelo.Text = "";
            txtNombreCliente.Text = "";
            txtTecnico.Text = "";

            txtMonto.Text = "";
            txtDetalle.Text = "";
        }

        //==================
    }
}
