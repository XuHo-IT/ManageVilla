using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VillaManage_VillaAPI.Data;
using VillaManage_VillaAPI.Model;
using VillaManage_VillaAPI.Repository.IRepository;

namespace VillaManage_VillaAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet =_context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);/* _context.Villas.AddAsync(entity); without using generic repository*/
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter == null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await SaveAsync();
        }
    }
}
