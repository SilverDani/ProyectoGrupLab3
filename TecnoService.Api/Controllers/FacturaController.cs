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
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService FacturaServ;
        private readonly ServiceContext con;
        public FacturaController(IFacturaService facturaServicio, ServiceContext context)
        {
            FacturaServ = facturaServicio;
            con = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var facturas = await con.Facturas
        .Include(f => f.ingreso)
            .ThenInclude(i => i.Cliente)
                .ThenInclude(c => c.Persona)
        .Include(f => f.ingreso)
            .ThenInclude(i => i.Dispositivo)
                .ThenInclude(d => d.Marca)
        .Include(f => f.Trabajador)
            .ThenInclude(t => t.Persona)
        .Select(f => new FacturaResumenDTO
        {
            IDFactura = f.IDFactura,
            Cliente = f.ingreso.Cliente.Persona.Nombre + " " + f.ingreso.Cliente.Persona.Apellido,
            Modelo = f.ingreso.Dispositivo.Modelo,
            Marca = f.ingreso.Dispositivo.Marca.Nombre,
            Tecnico = f.Trabajador.Persona.Nombre + " " + f.Trabajador.Persona.Apellido,
            Monto = f.Monto,
            FechaRetiro = f.FechaRetiro
        })
        .ToListAsync();

            return Ok(facturas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var f = await con.Facturas
        .Include(x => x.ingreso)
            .ThenInclude(i => i.Cliente)
                .ThenInclude(c => c.Persona)
        .Include(x => x.ingreso)
            .ThenInclude(i => i.Dispositivo)
                .ThenInclude(d => d.Marca)
        .Include(x => x.Trabajador)
            .ThenInclude(t => t.Persona)
        .FirstOrDefaultAsync(x => x.IDFactura == id);

            if (f == null) return NotFound();

            var dto = new FacturaDetalleDTO
            {
                IDFactura = f.IDFactura,
                IDInDis = f.IDInDis,
                IDTrabajador = f.IDTrabajador,

                ClienteNombre = f.ingreso.Cliente.Persona.Nombre,
                ClienteApellido = f.ingreso.Cliente.Persona.Apellido,
                DocumentoCliente = f.ingreso.Cliente.Persona.Documento,

                Modelo = f.ingreso.Dispositivo.Modelo,
                Marca = f.ingreso.Dispositivo.Marca.Nombre,

                Tecnico = f.Trabajador.Persona.Nombre + " " + f.Trabajador.Persona.Apellido,

                Monto = f.Monto,
                DetalleArreglo = f.DetalleArreglo,
                FechaRetiro = f.FechaRetiro
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearFacturaDTO dto)
        {
            var nuevaFactura = new Factura
            {
                IDInDis = dto.IDInDis,
                IDTrabajador = dto.IDTrabajador,
                Monto = dto.Monto,
                DetalleArreglo = dto.DetalleArreglo,
                FechaRetiro = dto.FechaRetiro
            };

            con.Facturas.Add(nuevaFactura);
            await con.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = nuevaFactura.IDFactura }, nuevaFactura);
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
            var factura = await con.Facturas.FindAsync(id);
            if (factura == null)
                return NotFound();

            con.Facturas.Remove(factura);
            await con.SaveChangesAsync();

            return NoContent();
        }




        //===========================================
    }
}
