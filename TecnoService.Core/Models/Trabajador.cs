using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoService.Core.Models
{
    public class Trabajador
    {
        [Key]
        public int IDTrabajador { get; set; }
        public int IDPersona { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Persona Persona { get; set; }
        public ICollection<Factura> Facturas { get; set; }
    }
}
