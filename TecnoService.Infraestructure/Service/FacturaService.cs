using TecnoService.Core.Interfaces.Repository;
using TecnoService.Core.Interfaces.Service;
using TecnoService.Core.Models;

namespace TecnoService.Infraestructure.Services
{
    public class FacturaService : ServiceBase<Factura>, IFacturaService
    {
        public FacturaService(IFacturaRepository repFactura) : base(repFactura)
        {

        }
    }
}
