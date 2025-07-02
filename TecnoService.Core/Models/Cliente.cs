using System.ComponentModel.DataAnnotations;

namespace TecnoService.Core.Models
{
    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; }
        public int IDPersona { get; set; }
        public string Telefono { get; set; }

        public Persona Persona { get; set; }
        public ICollection<InDis> Ingreso { get; set; }
    }
}
