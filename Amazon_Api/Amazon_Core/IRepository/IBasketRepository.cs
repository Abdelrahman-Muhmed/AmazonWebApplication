using Amazon_Core.Model.BasketModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.IRepository
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetAsync(string id);

        Task<CustomerBasket> CreateOrUpdateAsync(CustomerBasket basket);

        Task<bool> DeleteAsync(string id);



    }
}
