using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Model.OrderModel
{
    public class orderStatus
    {
        public enum OrderStatus
        {
            pending,
            PaymentReceived,
            PaymentFaild 
        }
    }
}
