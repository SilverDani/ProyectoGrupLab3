using System.ComponentModel.DataAnnotations;

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
