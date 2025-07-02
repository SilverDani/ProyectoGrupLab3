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
    public class TrabajadorController : ControllerBase
    {
        private readonly ITrabajadorService TrabajadorServ;
        private readonly ServiceContext con;
        public TrabajadorController(ITrabajadorService TrabajadorServicio, ServiceContext context)
        {
            TrabajadorServ = TrabajadorServicio;
            con = context;
        }

        
        [HttpGet("resumen")]
        public async Task<IActionResult> GetResumen()
        {
            var trabajadores = await con.Trabajadores
        .Include(t => t.Persona)
        .Select(t => new TrabajadorResumenDTO
        {
            IDTrabajador = t.IDTrabajador,
            NombreCompleto = t.Persona.Nombre + " " + t.Persona.Apellido
        })
        .ToListAsync();

            return Ok(trabajadores);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var t = await con.Trabajadores
        .Include(t => t.Persona)
        .FirstOrDefaultAsync(t => t.IDTrabajador == id);

            if (t == null) return NotFound();

            var dto = new TrabajadorDetalleDTO
            {
                IDTrabajador = t.IDTrabajador,
                Nombre = t.Persona.Nombre,
                Apellido = t.Persona.Apellido,
                Documento = t.Persona.Documento,
                Email = t.Email,
                Telefono = t.Telefono,
                FechaNacimiento = t.FechaNacimiento
            };

            return Ok(dto);
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
            var t = await con.Trabajadores
                .Include(t => t.Facturas)
                .FirstOrDefaultAsync(t => t.IDTrabajador == id);

            if (t == null) return NotFound();

            if (t.Facturas.Any())
                return BadRequest("No se puede eliminar el trabajador porque tiene facturas asociadas.");

            con.Trabajadores.Remove(t);
            await con.SaveChangesAsync();
            return NoContent();
        }


        //=========================================
    }
}
