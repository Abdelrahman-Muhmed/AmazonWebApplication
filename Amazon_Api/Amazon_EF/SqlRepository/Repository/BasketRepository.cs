using Amazon_Core.IRepository;
using Amazon_Core.Model.BasketModel;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Amazon_EF.SqlRepository.Repository
{
    
    public class BasketRepository : IBasketRepository
    {
        private readonly IConnectionMultiplexer _Basketrepository;
        public BasketRepository(IConnectionMultiplexer Basketrepository)
        {
            _Basketrepository = Basketrepository;
        }
        public async Task<CustomerBasket?> GetAsync(string id)
        {
            var BasketItem = await _Basketrepository.GetDatabase().StringGetAsync(id);

            //Transform from json to object 
            return BasketItem.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<CustomerBasket>(BasketItem);
        }
        public async Task<CustomerBasket?> CreateOrUpdateAsync(CustomerBasket basket)
        {
            var convertFromObjectToJson = JsonConvert.SerializeObject(basket);
            var createOrUpdateBasketItem = await _Basketrepository.GetDatabase().StringSetAsync(basket.Id , convertFromObjectToJson , TimeSpan.FromDays(10));
            if (!createOrUpdateBasketItem)
                return null;
            return await GetAsync(basket.Id);

        }

        public async Task<bool> DeleteAsync(string id)
        {
            var BasketItemDelete = await _Basketrepository.GetDatabase().KeyDeleteAsync(id);
            return BasketItemDelete;
        }

      
    }
}
