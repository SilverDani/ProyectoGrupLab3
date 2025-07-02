namespace TecnoService.Core.DTOs
{
    public class ActualizarFacturaDTO
    {
        public int IDFactura { get; set; }
        public int IDInDis { get; set; }
        public decimal Monto { get; set; }
        public string DetalleArreglo { get; set; }
        public DateTime FechaRetiro { get; set; }
        public int IDTrabajador { get; set; }
    }
}
