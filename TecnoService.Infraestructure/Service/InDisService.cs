using TecnoService.Core.Interfaces.Repository;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Infraestructure.Services
{
    public class InDisService : ServiceBase<InDis>, IInDisService
    {
        public InDisService(IInDisRepository repInDis) : base(repInDis)
        {

        }
    }
}
