using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Model.OrderModel
{
    public class DeliveryMethod : BaseEntity
    {
        public string shortName { get; set; } = null!;
        public string Descripation { get; set; } = null!;
        public decimal cost { get; set; }

        public string DeliveryTime { get; set; } = null!;





    }
}
