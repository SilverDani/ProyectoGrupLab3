using TecnoService.Core.Interfaces.Repository;
using TecnoService.Core.Interfaces.Service;

namespace TecnoService.Infraestructure.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {

        private readonly IRepositoryBase<T> RepBase;
        public ServiceBase(IRepositoryBase<T> repBase)
        {
            RepBase = repBase;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await RepBase.GetAllAsync();
        }

        public async Task<T?> GetByIdAsync(int ID)
        {
            return await RepBase.GetByIdAsync(ID);
        }

        public async Task AddAsync(T entity)
        {
            await RepBase.AddAsync(entity);
            await RepBase.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            RepBase.Update(entity);
            await RepBase.SaveChangesAsync();
        }

        public async Task DeleteAsync(int ID)
        {
            var entity = await RepBase.GetByIdAsync(ID);
            if (entity != null)
            {
                RepBase.Delete(entity);
                await RepBase.SaveChangesAsync();
            }
        }



        //===================================
    }
}
