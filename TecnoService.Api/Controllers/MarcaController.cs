using Microsoft.AspNetCore.Mvc;
using TecnoService.Core.DTOs;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService MarcaServ;
        public MarcaController(IMarcaService MarcaServicio)
        {
            MarcaServ = MarcaServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var marcas = await MarcaServ.GetAllAsync();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var marca = await MarcaServ.GetByIdAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearMarcaDTO dto)
        {
            var nuevaMarca = new Marca
            {

                Nombre = dto.Nombre
            };

            await MarcaServ.AddAsync(nuevaMarca);

            return CreatedAtAction(nameof(GetById), new { id = nuevaMarca.IDMarca }, nuevaMarca);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarMarcaDTO dto)
        {
            if (id != dto.IDMarca)
            {
                return BadRequest();
            }

            var updateMarca = new Marca
            {
                IDMarca = dto.IDMarca,
                Nombre = dto.Nombre
            };

            await MarcaServ.UpdateAsync(updateMarca);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await MarcaServ.DeleteAsync(id);

            return NoContent();
        }


        //=========================================
    }
}
