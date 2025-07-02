using System.ComponentModel.DataAnnotations;

namespace TecnoService.Core.Models
{
    public class Marca
    {
        [Key]
        public int IDMarca { get; set; }
        public string Nombre { get; set; }

        public ICollection<Dispositivo> Dispositivos { get; set; }
    }
}
