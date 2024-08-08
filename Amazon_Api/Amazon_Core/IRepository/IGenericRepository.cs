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
        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsyncWithSpec(ISpecifictations<T> Spec);

        Task<T?> GetAsyncWithSpec(ISpecifictations<T> Spec);
    }
}
