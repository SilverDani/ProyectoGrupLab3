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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService ClienteServ;
        private readonly ServiceContext con;
        public ClienteController(IClienteService ClienteServicio, ServiceContext context)
        {
            ClienteServ = ClienteServicio;
            con = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await con.Clientes
                .Include(c => c.Persona)
                .Select(c => new ClienteResumenDTO
                {
                    IDCliente = c.IDCliente,
                    NombreCompleto = c.Persona.Nombre + " " + c.Persona.Apellido,
                    Documento = c.Persona.Documento,
                    Telefono = c.Telefono
                })
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await con.Clientes
        .Include(c => c.Persona)
        .FirstOrDefaultAsync(c => c.IDCliente == id);

            if (cliente == null)
                return NotFound();

            var dto = new ClienteDetalleDTO
            {
                IDCliente = cliente.IDCliente,
                IDPersona = cliente.IDPersona,
                Nombre = cliente.Persona.Nombre,
                Apellido = cliente.Persona.Apellido,
                Documento = cliente.Persona.Documento,
                Telefono = cliente.Telefono
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearClienteDTO dto)
        {
            var nuevaCliente = new Cliente
            {

                IDPersona = dto.IDPersona,
                Telefono = dto.Telefono
            };

            await ClienteServ.AddAsync(nuevaCliente);

            return CreatedAtAction(nameof(GetById), new { id = nuevaCliente.IDCliente }, nuevaCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarClienteDTO dto)
        {
            if (id != dto.IDCliente)
            {
                return BadRequest();
            }

            var updateCliente = new Cliente
            {
                IDCliente = dto.IDCliente,
                IDPersona = dto.IDPersona,
                Telefono = dto.Telefono
            };

            await ClienteServ.UpdateAsync(updateCliente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await con.Clientes
        .Include(c => c.Ingreso)
        .FirstOrDefaultAsync(c => c.IDCliente == id);

            if (cliente == null) return NotFound();

            if (cliente.Ingreso.Any())
                return BadRequest("No se puede eliminar el cliente porque tiene ingresos asociados.");

            con.Clientes.Remove(cliente);
            await con.SaveChangesAsync();

            return NoContent();
        }


        //=========================================
    }
}
