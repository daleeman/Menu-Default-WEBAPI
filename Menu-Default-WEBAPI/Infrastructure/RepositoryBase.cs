
using Menu_Default_WEBAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Menu_Default_WEBAPI.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly DbSet<T> dbset;
        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext?? throw new ArgumentException(nameof(dbContext));
            dbset = _dbcontext.Set<T>();
        }
        public async Task Add(T entity)
        {
            await dbset.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            dbset.Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return dbset.AsQueryable();
        }

        public async Task<T?> GetById(Guid Id)
        {
            return await dbset.FindAsync(Id);
        }

        public async Task Update(T entity)
        {
           dbset.Attach(entity);
           _dbcontext.Entry(entity).State = EntityState.Modified;
           await _dbcontext.SaveChangesAsync();
        }
    }
}
