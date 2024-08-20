using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Model.OrderModel
{
    public class productItemOreder
    {
        public productItemOreder()
        {
            
        }

        public productItemOreder(int productIdP, string productNameP, string picturelUrlP)
        {
            productId = productIdP;
            productName = productNameP;
            picturelUrl = picturelUrlP;
           
        }
        public int productId { get; set; }
        public string productName { get; set; } = null!;
        public string picturelUrl { get; set; } = null!;
        public Order order { get; set; } = null!;

    
    }
}
