using System.ComponentModel.DataAnnotations;

namespace TecnoService.Core.Models
{
    public class InDis
    {
        [Key]
        public int IDInDis { get; set; }
        public int IDDispositivo { get; set; }
        public int IDCliente { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Dispositivo Dispositivo { get; set; }
        public Cliente Cliente { get; set; }
        public Factura Factura { get; set; }

    }
}
