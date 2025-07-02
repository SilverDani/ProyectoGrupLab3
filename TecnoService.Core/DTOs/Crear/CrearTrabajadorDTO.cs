namespace TecnoService.Core.DTOs
{
    public class CrearTrabajadorDTO
    {
        public int IDPersona { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
