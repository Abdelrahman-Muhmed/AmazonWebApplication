using Amazon_Core.Model;
using Amazon_Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.IRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public int? Take { get; set; }
        public int? Skipe { get; set; }
        public bool isPaginationEnable { get; set; }

        Task<T?> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAllAsyncWithSpec(ISpecifictations<T> Spec);

        Task<T?> GetAsyncWithSpec(ISpecifictations<T> Spec);

        Task<int> GetCountAsync(ISpecifictations<T> Spec);


        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);




    }
}
