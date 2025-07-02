using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoService.Core.DTOs.GetAll
{
    public class ClienteResumenDTO
    {
        public int IDCliente { get; set; }
        public string NombreCompleto { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
    }
}
