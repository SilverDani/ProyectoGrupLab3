using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
