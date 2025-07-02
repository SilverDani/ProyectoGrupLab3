using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoService.Core.DTOs.GetById
{
    public class DispositivoDetalleDTO
    {
        public int IDDispositivo { get; set; }
        public int IDMarca { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }
}
