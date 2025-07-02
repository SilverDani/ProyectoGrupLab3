using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoService.Core.DTOs.GetAll
{
    public class PersonaDisponibleDTO
    {
        public int IDPersona { get; set; }
        public string NombreCompleto { get; set; }
        public string Documento { get; set; }
    }
}
