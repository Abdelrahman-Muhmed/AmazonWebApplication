using Amazon_Core.Model.OrderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static Amazon_Core.Model.OrderModel.orderStatus;

namespace Amazon_EF.Data.Config
{
    internal class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //1- RelationShip between Order Table and shippingAdress prop 
            builder.OwnsOne(order => order.shippingAdress, ship => ship.WithOwner());


            //2- For Status i will make convert From it to be string in database (both Way)
            builder.Property(order => order.orderStatus)
                .HasConversion(
                (onStatus) => onStatus.ToString(),
                (onStatus) => (OrderStatus)Enum.Parse(typeof(OrderStatus), onStatus)

                );

            //3- Make Edit on DataType SubTotal 
            builder.Property(order => order.subTotal)
                .HasColumnType("decimal(12,2)");
        }
    }
}
