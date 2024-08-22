namespace Amazon_Api.Dtos
{
    public class OrderItemToReturnDto
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public string productName { get; set; } = null!;
        public string picturelUrl { get; set; } = null!;
        public decimal price { get; set; }

        public int quantity { get; set; }


    }
}
