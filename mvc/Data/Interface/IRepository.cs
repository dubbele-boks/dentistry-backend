using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    /// <summary>
    /// Generic interface which enforces default crud operations
    /// </summary>
    /// <typeparam name="T">refrences database entity</typeparam>
    public interface IRepository<T> where T : class
    {
        public IQueryable<T> Get();
        public bool Delete(T model);
        public Task<bool> Add(T model);
    }
}
