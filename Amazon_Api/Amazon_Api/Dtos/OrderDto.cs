using System.ComponentModel.DataAnnotations;

namespace Amazon_Api.Dtos
{
    public class OrderDto
    {
        [Required]
        public string? BuyerEmail { get; set; }

        [Required]
        public string BasketId { get; set; }

        [Required]
        public int DeliveryMethodId { get; set; }

        [Required]
        public AdressDto ShepingAdress { get; set; } 
    }
}
