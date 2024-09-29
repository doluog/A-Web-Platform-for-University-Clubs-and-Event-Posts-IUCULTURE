using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using IUCULTURE.Back.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IUCULTURE.Back.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly IUCULTUREContext IIUCULTUREContext;

        public Repository(IUCULTUREContext IIUCULTUREContext)
        {
            this.IIUCULTUREContext = IIUCULTUREContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this.IIUCULTUREContext.Set<T>().AddAsync(entity);
            await this.IIUCULTUREContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.IIUCULTUREContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this.IIUCULTUREContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);

        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await this.IIUCULTUREContext.Set<T>().FindAsync(id);
        }


        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return this.IIUCULTUREContext.Set<T>().Where(filter).ToList();
        }

        public async Task RemoveAsync(T entity)
        {
            this.IIUCULTUREContext.Set<T>().Remove(entity);
            await this.IIUCULTUREContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.IIUCULTUREContext.Set<T>().Update(entity);
            await this.IIUCULTUREContext.SaveChangesAsync();
        }

    }
}
