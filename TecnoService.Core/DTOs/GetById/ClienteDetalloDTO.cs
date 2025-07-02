namespace TecnoService.Core.DTOs.GetById
{
    public class ClienteDetalleDTO
    {
        public int IDCliente { get; set; }
        public int IDPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
    }
}
