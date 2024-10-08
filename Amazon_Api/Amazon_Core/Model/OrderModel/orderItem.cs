﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Model.OrderModel
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
            
        }

        public OrderItem(decimal priceP , int quantityP , productItemOreder productItemOrederP)
        {
            price = priceP;
            quantity = quantityP;
            productItemOreder = productItemOrederP;
        }
        public decimal price { get; set; }

        public int quantity { get; set; }

        public productItemOreder productItemOreder { get; set; } = null!;
    }
}
