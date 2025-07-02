using System.ComponentModel.DataAnnotations;

namespace TecnoService.Core.Models
{
    public class Dispositivo
    {
        [Key]
        public int IDDispositivo { get; set; }
        public int IDMarca { get; set; }
        public string Modelo { get; set; }

        public Marca Marca { get; set; }
        public ICollection<InDis> Ingreso { get; set; }
    }
}
