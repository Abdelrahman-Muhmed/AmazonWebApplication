using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Model.OrderModel
{
    public class productItemOreder
    {
        public int productId { get; set; }
        public string productName { get; set; } = null!;
        public string picturelUrl { get; set; } = null!;

        public Order order { get; set; } = null!;
    }
}
