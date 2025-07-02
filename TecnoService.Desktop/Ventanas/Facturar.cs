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
using TecnoService.Core.DTOs.GetAll;
using TecnoService.Core.Models;
using TecnoService.Desktop.viewModel;

namespace TecnoService.Desktop.Ventanas
{
    public partial class Facturar : Form
    {
        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7089/")
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

            txtMarca.ReadOnly = true;
            txtModelo.ReadOnly = true;
            txtNombreCliente.ReadOnly = true;
            txtTecnico.ReadOnly = true;
        }

        private async Task CargarIngresos()
        {
            try
            {
                var ingresos = await httpClient.GetFromJsonAsync<List<InDisResumenDTO>>("api/indis/resumen");

                dgvDisIngresados.AutoGenerateColumns = true;
                dgvDisIngresados.DataSource = ingresos;
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
                var tecnicos = await httpClient.GetFromJsonAsync<List<TrabajadorResumenDTO>>("api/trabajador/resumen");

                dgvTecnicos.AutoGenerateColumns = true;
                dgvTecnicos.DataSource = tecnicos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los técnicos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDisIngresados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var seleccionado = (InDisResumenDTO)dgvDisIngresados.Rows[e.RowIndex].DataBoundItem;

                idInDisSeleccionado = seleccionado.IDInDis;
                txtMarca.Text = seleccionado.Marca;
                txtModelo.Text = seleccionado.Modelo;
                txtNombreCliente.Text = seleccionado.Cliente;
            }
        }

        private void dgvTecnicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var seleccionado = (TrabajadorResumenDTO)dgvTecnicos.CurrentRow.DataBoundItem;

                idTrabajadorSeleccionado = seleccionado.IDTrabajador;
                txtTecnico.Text = seleccionado.NombreCompleto;
            }
        }

        private async void btnFacturar_Click(object sender, EventArgs e)
        {
            if (idInDisSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un dispositivo a facturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idTrabajadorSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un técnico.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMonto.Text.Trim(), out decimal monto) || monto <= 0)
            {
                MessageBox.Show("El monto ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                MessageBox.Show("Debe ingresar un detalle del arreglo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try
            {
                var response = await httpClient.PostAsJsonAsync("api/factura", factura);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Factura registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    await CargarIngresos();
                }
                else
                {
                    MessageBox.Show("Error al registrar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al facturar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //==================
    }
}
