using dentistry_backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Data access used to 
    /// </summary>
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        //TODO add models
        //public ICoverTypeRepository CoverType { get; private set; }
        public UnitOfWork(ApplicationDbContext context) {
            _context = context;
            //Category = new CategoryRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
