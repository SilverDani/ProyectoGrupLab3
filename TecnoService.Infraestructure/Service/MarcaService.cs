using TecnoService.Core.Interfaces.Repository;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Infraestructure.Services
{
    public class MarcaService : ServiceBase<Marca>, IMarcaService
    {
        public MarcaService(IMarcaRepository repMarca) : base(repMarca)
        {

        }
    }
}
