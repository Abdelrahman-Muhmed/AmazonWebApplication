using Amazon_Core.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Specifications.OrderSpec
{
    public class OrdersForUser : BaseSpecification<Order>
    {
        public OrdersForUser(string email) 
            :base(e => e.ByerEmail == email)
        {

            Include.Add(p => p.deliveryMethod);
            Include.Add(p => p.orderItem);

            AddOrderByDes(t => t.dateTime);
        }
        public OrdersForUser(string email , int orderId)
            :base(e => e.ByerEmail == email && e.id == orderId)
        {

            Include.Add(p => p.deliveryMethod);
            Include.Add(p => p.orderItem);

        }
    }
}
