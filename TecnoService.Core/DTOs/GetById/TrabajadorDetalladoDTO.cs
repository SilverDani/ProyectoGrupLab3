﻿namespace TecnoService.Core.DTOs.GetById
{
    public class TrabajadorDetalleDTO
    {
        public int IDTrabajador { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
