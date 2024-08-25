using Amazon_Core.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Specifications.OrderSpec
{
    public class orderWithPaymentIntentSpec : BaseSpecification<Order>
    {
        public orderWithPaymentIntentSpec(string paymentIntentId)
            :base(item => item.paymentIntedId == paymentIntentId) 
        {
            
        }

    }
}
