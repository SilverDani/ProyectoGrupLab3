using Microsoft.AspNetCore.Mvc;
using TecnoService.Core.DTOs;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService PersonaServ;
        public PersonaController(IPersonaService PersonaServicio)
        {
            PersonaServ = PersonaServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Personas = await PersonaServ.GetAllAsync();
            return Ok(Personas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Persona = await PersonaServ.GetByIdAsync(id);
            if (Persona == null)
            {
                return NotFound();
            }

            return Ok(Persona);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearPersonaDTO dto)
        {
            var crearPersona = new Persona
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Documento = dto.Documento
            };
            await PersonaServ.AddAsync(crearPersona);

            return CreatedAtAction(nameof(GetById), new { id = crearPersona.IDPersona }, crearPersona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarPersonaDTO dto)
        {
            if (id != dto.IDPersona)
            {
                return BadRequest();
            }

            var updatePersona = new Persona
            {
                IDPersona = dto.IDPersona,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Documento = dto.Documento
            };

            await PersonaServ.UpdateAsync(updatePersona);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await PersonaServ.DeleteAsync(id);

            return NoContent();
        }


        //=========================================
    }
}
