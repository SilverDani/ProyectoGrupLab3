namespace TecnoService.Core.DTOs.GetById
{
    public class InDisDetalleDTO
    {
        public int IDInDis { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string DocumentoCliente { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
