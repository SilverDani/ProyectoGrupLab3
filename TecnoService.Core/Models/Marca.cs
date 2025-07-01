using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
