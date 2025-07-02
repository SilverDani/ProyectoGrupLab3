namespace TecnoService.Core.DTOs.GetAll
{
    public class FacturaResumenDTO
    {
        public int IDFactura { get; set; }
        public string Cliente { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Tecnico { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaRetiro { get; set; }
    }
}
