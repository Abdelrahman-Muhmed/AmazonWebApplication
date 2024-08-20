using Amazon_Core.Model.OrderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_EF.OrderData.Config
{
    internal class OrderItemConfigruations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            //1- RelationShip between Order Table and shippingAdress prop 
            builder.OwnsOne(orderItem => orderItem.productItemOreder, ship => ship.WithOwner());

            //3- Make Edit on DataType Price 
            builder.Property(order => order.price)
                .HasColumnType("decimal(12,2)");
        }
    }
    
}
