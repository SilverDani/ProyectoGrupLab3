using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoService.Core.DTOs.GetById
{
    public class FacturaDetalleDTO
    {
        public int IDFactura { get; set; }
        public int IDInDis { get; set; }
        public int IDTrabajador { get; set; }

        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string DocumentoCliente { get; set; }

        public string Modelo { get; set; }
        public string Marca { get; set; }

        public string Tecnico { get; set; }

        public decimal Monto { get; set; }
        public string DetalleArreglo { get; set; }
        public DateTime FechaRetiro { get; set; }
    }
}
