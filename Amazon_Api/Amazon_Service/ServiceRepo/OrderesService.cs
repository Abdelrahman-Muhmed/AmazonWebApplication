using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Amazon_Core.Model.OrderModel;
using Amazon_Core.Service;
using Amazon_Core.Specifications.OrderSpec;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Stripe;
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
        //private readonly IGenericRepository<Product> _dbContextProduct;
        //private readonly IGenericRepository<DeliveryMethod> _dbContextDelivery;
        //private readonly IGenericRepository<Order> _dbContextOrder; 

        //Replace This IGenericRepository 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;

        public OrderesService(
            IBasketRepository basketRepository,
            //IGenericRepository<Product> dbContextProduct, 
            //IGenericRepository<DeliveryMethod> dbContextDelivery,
            //IGenericRepository<Order> dbContextOrder,
            IUnitOfWork unitOfWork,
            IPaymentService paymentService

            )
        {
            _basketRepository = basketRepository;
            //_dbContextProduct = dbContextProduct;
            //_dbContextDelivery = dbContextDelivery;
            //_dbContextOrder = dbContextOrder;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }
        public async Task<Order> CreatOrderAsync(string byerEmail, string basketId, int deliveryMethodId, AdressModel adress)
        {
            //1- Get Basket From Baskets Repo
            var basket = await _basketRepository.GetAsync(basketId);

            //2- Get Selected Items at Basket From Products Repo
            var listOrderItem = new List<OrderItem>();

            if(basket?.basketItem?.Count() > 0)
            {
                foreach(var item in basket.basketItem)
                {
                    var product = await _unitOfWork.Repository<Products>().GetAsync(item.Id);
                    //var product = await _dbContextProduct.GetAsync(item.Id);


                    var productItemOreder = new productItemOreder(item.Id, product.Name , product.PictureUrl);

                    var orderItem = new OrderItem(product.Price , item.Quantity , productItemOreder);

                    listOrderItem.Add(orderItem);

                }
            }

            //3- Calculate SubTotal
            var subTotal = listOrderItem.Sum(item => item.price *  item.quantity);

            //4- Get Delivery Method From DeliveryMethods Repo
            var DeliveryMethode = await _unitOfWork.Repository<DeliveryMethod>().GetAsync(deliveryMethodId);
            //var DeliveryMethode = _dbContextDelivery.GetAsync(deliveryMethodId);

            var orderRepo = _unitOfWork.Repository<Order>();
            //i Will make check if the order found in the same paymentIntent Or not 
            var spec = new orderWithPaymentIntentSpec(basket?.PaymentId);
            var checkOrderForPaymnet = await orderRepo.GetAsyncWithSpec(spec);

            if (checkOrderForPaymnet != null)
            {
                orderRepo.Delete(checkOrderForPaymnet);
                await _paymentService.CreateOrUpdatePaymentIntent(basketId);
            }

            //5- Create Order
            var order = new Order(
                ByerEmailP: byerEmail,
                adressP: adress,
                deliveryMethodIdP: deliveryMethodId,
                itemsP: listOrderItem,
                subTotalP: subTotal,
                paymentIntentP: basket?.PaymentId ?? ""
                );


             orderRepo.Add(order);
            //_dbContextOrder.Add(order);

        
            //6- Now i have SaveChange in database So i will Use UnitOfWork 

             await _unitOfWork.CompleteAsync();
            return order;

        }
        public Task<IReadOnlyList<Order>> GetOrderesAsync(string byerEmail)
        {
           var order = _unitOfWork.Repository<Order>();
           var spec = new OrdersForUser(byerEmail);
           var orederGenaric = order.GetAllAsyncWithSpec(spec);
           return orederGenaric;

        }

        public Task<Order> GetOrdereAsync(string byerEmail, int orderId)
        {
            var order = _unitOfWork.Repository<Order>();
            var spec = new OrdersForUser(byerEmail , orderId);
            var orederGenaric = order.GetAsyncWithSpec(spec);
            return orederGenaric;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync()
        {
            var DeliveryMethod = _unitOfWork.Repository<DeliveryMethod>();
            var getDeliveryMethod = DeliveryMethod.GetAllAsync();

            return getDeliveryMethod;
        }

       
    }
}
