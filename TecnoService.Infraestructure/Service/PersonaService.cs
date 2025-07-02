using TecnoService.Core.Interfaces.Repository;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Infraestructure.Services
{
    public class PersonaService : ServiceBase<Persona>, IPersonaService
    {
        public PersonaService(IPersonaRepository repPersona) : base(repPersona)
        {

        }
    }
}
