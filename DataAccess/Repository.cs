using DataAccess.Interface;
using dentistry_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    /// <summary>
    /// Generic repository for data manipulation
    /// </summary>
    /// <typeparam name="T">Database entity</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        /// <summary>
        /// Dependency inject application dbcontext from MVC
        /// </summary>
        /// <param name="context"></param>
        public Repository(ApplicationDbContext context) {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public bool Delete(T model)
        {
            this.dbSet.Remove(model);
            return this._context.SaveChanges() > 0;
        }

        public IQueryable<T> Get()
        {
           return dbSet.AsQueryable();
        }

        async public Task<bool> Add(T model) { 
            await dbSet.AddAsync(model);
            return this._context.SaveChanges() > 0;
        }

    }
}
