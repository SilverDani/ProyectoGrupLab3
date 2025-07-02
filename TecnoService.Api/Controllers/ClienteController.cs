using Microsoft.AspNetCore.Mvc;
using TecnoService.Core.DTOs;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService ClienteServ;
        public ClienteController(IClienteService ClienteServicio)
        {
            ClienteServ = ClienteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Clientes = await ClienteServ.GetAllAsync();
            return Ok(Clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Cliente = await ClienteServ.GetByIdAsync(id);
            if (Cliente == null)
            {
                return NotFound();
            }

            return Ok(Cliente);
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
            await ClienteServ.DeleteAsync(id);

            return NoContent();
        }


        //=========================================
    }
}
