using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Amazon_Core.Specifications;
using Amazon_EF.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Amazon_EF.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;
        private readonly IMapper _mapper;

        //Pagination Implemnt(Automatic Prop)
        public int? Take { get; set; }
        public int? Skipe { get; set; }
        public bool isPaginationEnable { get; set; }

        public GenericRepository(StoreContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            //For Include Category and Product Name <===
            //if (typeof(T) == typeof(Product))
            //    return (IEnumerable<T>) await _dbContext.Set<Product>().Include(p => p.ProductBrand).Include(p => p.CategoryName).ToListAsync();
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            //if (typeof(T) == typeof(Product))
            //    return await _dbContext.Set<Product>().Where(p => p.id == id).Include(p => p.ProductBrand).Include(p => p.CategoryName).FirstOrDefaultAsync() as T;
            return await _dbContext.Set<T>().FindAsync(id);
        }



        public async Task<IReadOnlyList<T>> GetAllAsyncWithSpec(ISpecifictations<T> Spec)
        {
            return await GetSpecQuery(Spec).AsNoTracking().ToListAsync();
        }
        public async Task<T?> GetAsyncWithSpec(ISpecifictations<T> Spec)
        {
            return await GetSpecQuery(Spec).FirstOrDefaultAsync();

        }

        private IQueryable<T> GetSpecQuery(ISpecifictations<T> Spec)
        {
            return SpecificationsEvaluator<T>.getQuery(_dbContext.Set<T>(), Spec);
        }


        public async Task<int> GetCountAsync(ISpecifictations<T> Spec)
        {
            return await GetSpecQuery(Spec).CountAsync();
        }
      
    }
}
