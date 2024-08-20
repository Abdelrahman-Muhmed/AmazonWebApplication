using Amazon_Core.Model;
using Amazon_Core.Model.OrderModel;
using Amazon_EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Amazon_EF.OrderData
{
    public static class OrderDataSeeding
    {
      
        public async static Task seedAsync(StoreContext storeContext)
        {
            var Delivery = File.ReadAllText("../Amazon_EF/OrderData/DataSeedingFile/delivery.json");

            var deDelivery = JsonSerializer.Deserialize<List<DeliveryMethod>>(Delivery);

      


            if (storeContext.DeliveryMethods.Count() == 0)
            {
                if (deDelivery?.Count() > 0)
                {
                    foreach(var item in deDelivery)
                    {
                        storeContext.Set<DeliveryMethod>().Add(item);
                    }

                }

                await storeContext.SaveChangesAsync();
            }
          

        }
    }
}
