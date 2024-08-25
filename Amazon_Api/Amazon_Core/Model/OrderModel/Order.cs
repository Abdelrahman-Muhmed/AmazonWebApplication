using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Amazon_Core.Model.OrderModel.orderStatus;

namespace Amazon_Core.Model.OrderModel
{
    public class Order : BaseEntity
    {
        public Order()
        {
            
        }

        public Order(string ByerEmailP , AdressModel adressP , int deliveryMethodIdP , ICollection<OrderItem> itemsP , decimal subTotalP, string paymentIntentP)
        {
            ByerEmail = ByerEmailP;
            shippingAdress = adressP;
            deliveryMethodId = deliveryMethodIdP;
            orderItem = itemsP;
            subTotal = subTotalP;
            paymentIntedId = paymentIntentP;
        }

        public string ByerEmail { get; set; } = null!;
        public DateTimeOffset dateTime { get; set; } = DateTimeOffset.UtcNow;

        public OrderStatus orderStatus { get; set; } = OrderStatus.pending;

        public AdressModel shippingAdress { get; set; } = null!;   //one to one between Order and Adress (shippingAdress)

        public int deliveryMethodId { get; set; } //Forign Key 
        public DeliveryMethod deliveryMethod { get; set; } = null!; //Nav Prop 

        public ICollection<OrderItem> orderItem { get; set; } = new HashSet<OrderItem>();    //Nav Prop 

        public decimal subTotal { get; set; }

        [NotMapped]
        public decimal Total => subTotal + deliveryMethod.cost;

        //public decimal GetTotal() => subTotal + deliveryMethod.cost;

        public string paymentIntedId { get; set; }


    }
}
