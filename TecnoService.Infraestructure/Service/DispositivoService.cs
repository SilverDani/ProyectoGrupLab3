using TecnoService.Core.Interfaces.Repository;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Infraestructure.Services
{
    public class DispositivoService : ServiceBase<Dispositivo>, IDispositivoService
    {
        public DispositivoService(IDispositivoRepository repDis) : base(repDis)
        {

        }
    }
}
