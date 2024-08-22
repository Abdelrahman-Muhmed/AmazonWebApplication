
using Amazon_Core.Model.OrderModel;
using Microsoft.Extensions.Hosting;

namespace Amazon_Api.Dtos
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }

        public string ByerEmail { get; set; } = null!;
        public DateTimeOffset dateTime { get; set; } = DateTimeOffset.UtcNow;

        public string orderStatus { get; set; } = null!;    //Handle it in Configure

        //DeliveryMethode 
        public string DeliveryMethod { get; set; } = null!;
        public decimal cost { get; set; }

        public ICollection<OrderItemToReturnDto> orderItem { get; set; } = null!; //Handle it in Configure

        public decimal subTotal { get; set; }

        public decimal Total => subTotal + cost;

        //public decimal GetTotal() => subTotal + deliveryMethod.cost;

        public string paymentIntedId { get; set; } = string.Empty;

    }
}
