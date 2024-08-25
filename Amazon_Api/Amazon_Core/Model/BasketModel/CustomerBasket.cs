using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Model.BasketModel
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public string? PaymentId { get; set; }
        public string? ClientSecret { get; set; }

        //For Update DelivreryMethode 
        public int? DeliveryMethodId { get; set; }

        //Show ShippingPrice
        public decimal shippingPriceBasket { get; set; }

        public List<BasketItem> basketItem { get; set; }
        public CustomerBasket(string id)
        {
            Id = id;
            
        }
    }
}
