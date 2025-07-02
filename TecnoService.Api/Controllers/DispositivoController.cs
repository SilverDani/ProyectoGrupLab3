using Microsoft.AspNetCore.Mvc;
using TecnoService.Core.DTOs;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DispositivoController : ControllerBase
    {
        private readonly IDispositivoService dispositivoServ;
        public DispositivoController(IDispositivoService dispositivoServicio)
        {
            dispositivoServ = dispositivoServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dispo = await dispositivoServ.GetAllAsync();
            return Ok(dispo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dispo = await dispositivoServ.GetByIdAsync(id);

            if (dispo == null)
            {
                return NotFound();
            }
            return Ok(dispo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearDispositivoDTO dto)
        {
            var nuevoDispositivo = new Dispositivo
            {
                IDMarca = dto.IDMarca,
                Modelo = dto.Modelo
            };

            await dispositivoServ.AddAsync(nuevoDispositivo);

            return CreatedAtAction(nameof(GetById), new { id = nuevoDispositivo.IDDispositivo }, nuevoDispositivo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarDispositivoDTO dto)
        {
            if (id != dto.IDDispositivo)
            {
                return BadRequest();
            }

            var updateDispo = new Dispositivo
            {
                IDDispositivo = dto.IDDispositivo,
                IDMarca = dto.IDMarca,
                Modelo = dto.Modelo
            };

            await dispositivoServ.UpdateAsync(updateDispo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await dispositivoServ.DeleteAsync(id);
            return NoContent();
        }



        //==================================================
    }
}
