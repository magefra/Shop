
namespace Shop.Web.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {

        private readonly DataContext Context;

        public GenericRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await this.Context.Set<T>().AddAsync(entity);
            await SaveAllAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            this.Context.Set<T>().Remove(entity);
            await SaveAllAsync();
        }


        public async Task<bool> ExistAsync(int id)
        {
            return await this.Context.Set<T>().AnyAsync(e => e.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return this.Context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.Context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            this.Context.Set<T>().Update(entity);
            await SaveAllAsync();
        }


        private async Task<bool> SaveAllAsync()
        {
            return await this.Context.SaveChangesAsync() > 0;
        }
    }
}
