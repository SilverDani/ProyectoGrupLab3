using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoService.Core.Models
{
    public class Persona
    {
        [Key]
        public int IDPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }

        public Cliente Cliente { get; set; }
        public Trabajador Trabajador { get; set; }
    }
}
