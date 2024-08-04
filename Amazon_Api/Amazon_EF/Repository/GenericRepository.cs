using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Amazon_EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Amazon_EF.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;
        public GenericRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //For Include Category and Product Name <===
            if (typeof(T) == typeof(Product))
                return (IEnumerable<T>) await _dbContext.Set<Product>().Include(p => p.ProductBrand).Include(p => p.CategoryName).ToListAsync();
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            if (typeof(T) == typeof(Product))
                return await _dbContext.Set<Product>().Where(p => p.id == id).Include(p => p.ProductBrand).Include(p => p.CategoryName).FirstOrDefaultAsync() as T;
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
