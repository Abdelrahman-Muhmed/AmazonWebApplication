﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Amazon_Core.Model.OrderModel.orderStatus;

namespace Amazon_Core.Model.OrderModel
{
    public class Order : BaseEntity
    {
        public string ByerEmail { get; set; } = null!;
        public DateTimeOffset dateTime { get; set; } = DateTimeOffset.UtcNow;

        public OrderStatus orderStatus { get; set; } = OrderStatus.pending;

        public Adress shippingAdress { get; set; } = null!;   //one to one between Order and Adress (shippingAdress)

        public int deliveryMethodId { get; set; } //Forign Key 
        public DeliveryMethod deliveryMethod { get; set; } = null!; //Nav Prop 

        public ICollection<orderItem> orderItem { get; set; } = new HashSet<orderItem>();    //Nav Prop 


        public decimal subTotal { get; set; }

        [NotMapped]
        public decimal Total => subTotal + deliveryMethod.cost;
        //public decimal GetTotal() => subTotal + deliveryMethod.cost;

        public string paymentIntedId { get; set; } = string.Empty;


    }
}
