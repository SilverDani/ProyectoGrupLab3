using Microsoft.AspNetCore.Mvc;
using TecnoService.Core.DTOs;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class TrabajadorController : ControllerBase
    {
        private readonly ITrabajadorService TrabajadorServ;
        public TrabajadorController(ITrabajadorService TrabajadorServicio)
        {
            TrabajadorServ = TrabajadorServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Trabajadors = await TrabajadorServ.GetAllAsync();
            return Ok(Trabajadors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Trabajador = await TrabajadorServ.GetByIdAsync(id);
            if (Trabajador == null)
            {
                return NotFound();
            }

            return Ok(Trabajador);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearTrabajadorDTO dto)
        {
            var crearTrabajador = new Trabajador
            {
                IDPersona = dto.IDPersona,
                Email = dto.Email,
                Telefono = dto.Telefono,
                FechaNacimiento = dto.FechaNacimiento
            };
            await TrabajadorServ.AddAsync(crearTrabajador);

            return CreatedAtAction(nameof(GetById), new { id = crearTrabajador.IDTrabajador }, crearTrabajador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarTrabajadorDTO dto)
        {
            if (id != dto.IDTrabajador)
            {
                return BadRequest();
            }

            var updateTrabajador = new Trabajador
            {
                IDTrabajador = dto.IDTrabajador,
                IDPersona = dto.IDPersona,
                Email = dto.Email,
                Telefono = dto.Telefono,
                FechaNacimiento = dto.FechaNacimiento
            };

            await TrabajadorServ.UpdateAsync(updateTrabajador);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await TrabajadorServ.DeleteAsync(id);

            return NoContent();
        }


        //=========================================
    }
}
