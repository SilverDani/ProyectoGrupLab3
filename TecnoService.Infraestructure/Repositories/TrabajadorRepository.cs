using TecnoService.Core.Interfaces.Repository;
using TecnoService.Core.Models;
using TecnoService.Infraestructure.Data;

namespace TecnoService.Infraestructure.Repositories
{
    public class TrabajadorRepository : RepositoryBase<Trabajador>, ITrabajadorRepository
    {
        public TrabajadorRepository(ServiceContext ConTrabajador) : base(ConTrabajador)
        {

        }
    }
}
