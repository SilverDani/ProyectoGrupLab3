using Microsoft.AspNetCore.Mvc;
using TecnoService.Core.DTOs;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService FacturaServ;
        public FacturaController(IFacturaService facturaServicio)
        {
            FacturaServ = facturaServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Factura = await FacturaServ.GetAllAsync();
            return Ok(Factura);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Factura = await FacturaServ.GetByIdAsync(id);
            if (Factura == null)
            {
                return NotFound();
            }
            return Ok(Factura);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearFacturaDTO dto)
        {
            var nuevaFactura = new Factura
            {
                IDInDis = dto.IDInDis,
                Monto = dto.Monto,
                DetalleArreglo = dto.DetalleArreglo,
                FechaRetiro = dto.FechaRetiro,
                IDTrabajador = dto.IDTrabajador
            };
            await FacturaServ.AddAsync(nuevaFactura);

            return CreatedAtAction(nameof(GetById
                ), nuevaFactura);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarFacturaDTO dto)
        {
            if (id != dto.IDFactura)
            {
                return BadRequest();
            }
            var actualizarFactura = new Factura
            {
                IDFactura = dto.IDFactura,
                IDInDis = dto.IDInDis,
                Monto = dto.Monto,
                DetalleArreglo = dto.DetalleArreglo,
                FechaRetiro = dto.FechaRetiro,
                IDTrabajador = dto.IDTrabajador
            };
            await FacturaServ.UpdateAsync(actualizarFactura);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await FacturaServ.DeleteAsync(id);

            return NoContent();
        }




        //===========================================
    }
}
