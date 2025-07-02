using Microsoft.EntityFrameworkCore;
using TecnoService.Core.Interfaces.Repository;
using TecnoService.Infraestructure.Data;

namespace TecnoService.Infraestructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ServiceContext Con;
        protected readonly DbSet<T> values;

        public RepositoryBase(ServiceContext context)
        {
            Con = context;
            values = Con.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await values.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int ID)
        {
            return await values.FindAsync(ID);
        }

        public async Task AddAsync(T entity)
        {
            await values.AddAsync(entity);
        }

        public void Update(T entity)
        {
            values.Update(entity);
        }

        public void Delete(T entity)
        {
            values.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await Con.SaveChangesAsync();
        }

        //=====================================================================
    }
}
