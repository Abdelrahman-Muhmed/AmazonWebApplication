using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Amazon_Core.Model.OrderModel;
using Amazon_Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Service.ServiceRepo
{
    public class OrderesService : IOrdersService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IGenericRepository<Product> _dbContextProduct;
        private readonly IGenericRepository<DeliveryMethod> _dbContextDelivery;
        private readonly IGenericRepository<Order> _dbContextOrder;




        public OrderesService(IBasketRepository basketRepository ,
            IGenericRepository<Product> dbContextProduct , 
            IGenericRepository<DeliveryMethod> dbContextDelivery,
            IGenericRepository<Order> dbContextOrder)
        {
            _basketRepository = basketRepository;
            _dbContextProduct = dbContextProduct;
            _dbContextDelivery = dbContextDelivery;
            _dbContextOrder = dbContextOrder;
        }
        public async Task<Order> CreatOrderAsync(string byerEmail, string basketId, int deliveryMethodId, Adress adress)
        {
            //1- Get Basket From Baskets Repo
            var basket = await _basketRepository.GetAsync(basketId);

            //2- Get Selected Items at Basket From Products Repo
            var listOrderItem = new List<OrderItem>();

            if(basket?.basketItem?.Count() > 0)
            {
                foreach(var item in basket.basketItem)
                {
                    var product = await _dbContextProduct.GetAsync(item.Id);

                    var productItemOreder = new productItemOreder(product.id , product.Name , product.PictureUrl);

                    var orderItem = new OrderItem(product.Price , item.Quantity , productItemOreder);

                    listOrderItem.Add(orderItem);

                }
            }

            //3- Calculate SubTotal
            var subTotal = listOrderItem.Sum(item => item.price *  item.quantity);

            //4- Get Delivery Method From DeliveryMethods Repo
            var DeliveryMethode = _dbContextDelivery.GetAsync(deliveryMethodId);


            //5- Create Order
            var order = new Order(
                ByerEmailP: byerEmail,
                adressP: adress,
                deliveryMethodIdP: deliveryMethodId,
                itemsP: listOrderItem,
                subTotalP: subTotal
                );


            _dbContextOrder.Add(order);

            //6- Now i have SaveChange in database So i will Use UnitOfWork 
            return order;

        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrdereAsync(string byerEmail, int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrderesAsync(string byerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
