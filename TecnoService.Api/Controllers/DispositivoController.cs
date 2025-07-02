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
    [Route("api/[controller]")]
    public class DispositivoController : ControllerBase
    {
        private readonly IDispositivoService dispositivoServ;
        private readonly ServiceContext con;
        public DispositivoController(IDispositivoService dispositivoServicio, ServiceContext context
            )
        {
            dispositivoServ = dispositivoServicio;
            con = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dispositivos = await con.Dispositivos
        .Include(d => d.Marca)
        .Select(d => new DispositivoResumenDTO
        {
            IDDispositivo = d.IDDispositivo,
            Modelo = d.Modelo,
            Marca = d.Marca.Nombre
        })
        .ToListAsync();

            return Ok(dispositivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var d = await con.Dispositivos
        .Include(x => x.Marca)
        .FirstOrDefaultAsync(x => x.IDDispositivo == id);

            if (d == null) return NotFound();

            var dto = new DispositivoDetalleDTO
            {
                IDDispositivo = d.IDDispositivo,
                IDMarca = d.IDMarca,
                Modelo = d.Modelo,
                Marca = d.Marca.Nombre
            };

            return Ok(dto);
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
