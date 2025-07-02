using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoService.Core.DTOs;
using TecnoService.Core.DTOs.GetAll;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;
using TecnoService.Infraestructure.Data;

namespace TecnoService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService MarcaServ;
        private readonly ServiceContext con;
        public MarcaController(IMarcaService MarcaServicio, ServiceContext context)
        {
            MarcaServ = MarcaServicio;
            con=context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var marcas = await con.Marcas
        .Select(m => new MarcaResumenDTO
        {
            IDMarca = m.IDMarca,
            Nombre = m.Nombre
        })
        .ToListAsync();

            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var marca = await con.Marcas.FindAsync(id);

            if (marca == null) return NotFound();

            var dto = new MarcaResumenDTO 
            {
                IDMarca = marca.IDMarca,
                Nombre = marca.Nombre
            };

            return Ok(dto);
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
            var marca = await con.Marcas
                .Include(m => m.Dispositivos)
                .FirstOrDefaultAsync(m => m.IDMarca == id);

            if (marca == null) return NotFound();

            if (marca.Dispositivos.Any())
                return BadRequest("No se puede eliminar la marca porque tiene dispositivos asociados.");

            con.Marcas.Remove(marca);
            await con.SaveChangesAsync();

            return NoContent();
        }


        //=========================================
    }
}
