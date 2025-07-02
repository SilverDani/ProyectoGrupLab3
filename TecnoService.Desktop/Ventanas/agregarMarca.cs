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

namespace TecnoService.Desktop.Ventanas
{
    public partial class agregarMarca : Form
    {
        public agregarMarca()
        {
            InitializeComponent();
        }

        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7089/")
        };

        private async void btnMarca_Click(object sender, EventArgs e)
        {
            var nombre = txtMarca.Text.Trim();

            
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Debe ingresar un nombre para la marca.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nueva = new CrearMarcaDTO { Nombre = nombre };

            try
            {
                var response = await httpClient.PostAsJsonAsync("api/marca", nueva); 

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Marca agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMarca.Clear(); 
                    txtMarca.Focus(); 
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar agregar la marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
