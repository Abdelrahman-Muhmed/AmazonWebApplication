
using Amazon_Core.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Service
{
    public interface IOrdersService
    {
        Task<Order> CreatOrderAsync (string byerEmail , string basketId , int deliveryMethod , AdressModel adress);

        Task<IReadOnlyList<Order>> GetOrderesAsync (string byerEmail);

        Task<Order> GetOrdereAsync (string byerEmail , int orderId);

        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync();

    }
}
