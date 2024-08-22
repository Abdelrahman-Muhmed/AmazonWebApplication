using Amazon_Core.Model.OrderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_EF.Data.Config
{
    internal class DeliveryMethodConfigurations : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            //3- Make Edit on DataType cost 
            builder.Property(order => order.cost)
                .HasColumnType("decimal(12,2)");
        }
    }
}
