using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoService.Core.Models
{
    public class Factura
    {
        [Key]
        public int IDFactura { get; set; }
        public int IDInDis { get; set; }
        public decimal Monto { get; set; }
        public string DetalleArreglo { get; set; }
        public DateTime FechaRetiro { get; set; }
        public int IDTrabajador { get; set; }

        public InDis ingreso { get; set; }
        public Trabajador Trabajador { get; set; }
    }
}
