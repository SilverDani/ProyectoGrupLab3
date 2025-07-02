using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoService.Core.DTOs;
using TecnoService.Core.DTOs.GetAll;
using TecnoService.Core.DTOs.GetById;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;
using TecnoService.Infraestructure.Data;

namespace TecnoService.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService PersonaServ;
        private readonly ServiceContext con;
        public PersonaController(IPersonaService PersonaServicio, ServiceContext context)
        {
            PersonaServ = PersonaServicio;
            con = context;
        }

        [HttpGet("disponibles")]
        public async Task<IActionResult> GetDisponibles()
        {
            var personas = await con.Personas
                .Where(p => p.Cliente == null && p.Trabajador == null)
                .Select(p => new PersonaDetalleDTO
        {
            IDPersona = p.IDPersona,
            Nombre = p.Nombre,
            Apellido = p.Apellido,
            Documento = p.Documento
        }).ToListAsync();

            return Ok(personas);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personas = await con.Personas
                .Select(p => new PersonaDetalleDTO
                {
                    IDPersona = p.IDPersona,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Documento = p.Documento
                })
                .ToListAsync();

            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await con.Personas.FindAsync(id);

            if (persona == null)
                return NotFound();

            var dto = new PersonaDetalleDTO
            {
                IDPersona = persona.IDPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Documento = persona.Documento
            };

            return Ok(dto);
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
