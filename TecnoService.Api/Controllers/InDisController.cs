using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoService.Core.DTOs;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;
using TecnoService.Infraestructure.Data;

namespace TecnoService.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class InDisController : ControllerBase
    {
        private readonly IInDisService InDisServ;
        private readonly ServiceContext con;
        public InDisController(IInDisService InDisServicio, ServiceContext context)
        {
            InDisServ = InDisServicio;
            con = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var InDiss = await InDisServ.GetAllAsync();
            return Ok(InDiss);
        }

        [HttpGet("detalle")]
        public async Task<IActionResult> GetConDetalle()
        {
            var indis = await con.Ingreso
                .Include(i => i.Dispositivo)
                    .ThenInclude(d => d.Marca)
                .Include(i => i.Cliente)
                    .ThenInclude(c => c.Persona)
                .ToListAsync();

            return Ok(indis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var InDis = await InDisServ.GetByIdAsync(id);
            if (InDis == null)
            {
                return NotFound();
            }

            return Ok(InDis);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearInDisDTO dto
            )
        {
            var crearInDis = new InDis
            {
                IDDispositivo = dto.IDDispositivo,
                IDCliente = dto.IDCliente,
                FechaIngreso = dto.FechaIngreso
            };
            await InDisServ.AddAsync(crearInDis);

            return CreatedAtAction(nameof(GetById), new { id = crearInDis.IDInDis }, crearInDis);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarInDisDTO dto
            )
        {
            if (id != dto.IDInDis)
            {
                return BadRequest();
            }
            var updateInDis = new InDis
            {
                IDInDis = dto.IDInDis,
                IDDispositivo = dto.IDDispositivo,
                IDCliente = dto.IDCliente,
                FechaIngreso = dto.FechaIngreso
            };

            await InDisServ.UpdateAsync(updateInDis);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await InDisServ.DeleteAsync(id);

            return NoContent();
        }


        //=========================================
    }
}
