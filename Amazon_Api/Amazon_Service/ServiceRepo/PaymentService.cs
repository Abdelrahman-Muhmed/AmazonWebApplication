using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Amazon_Core.Model.BasketModel;
using Amazon_Core.Model.OrderModel;
using Amazon_Core.Service;
using Amazon_Core.Specifications.ProductSpec;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Service.ServiceRepo
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;


        public PaymentService(IConfiguration configuration, IUnitOfWork unitOfWork, IBasketRepository basketRepository)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
        }
        public async Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId)
        {
            var shippingPrice = 0m;

            StripeConfiguration.ApiKey = _configuration["stripPaymentKey:Secretkey"];
            var getBasketById = await _basketRepository.GetAsync(basketId);

            if (getBasketById.basketItem == null)
                return null;


            if (getBasketById.basketItem.Count() > 0)
            {
                //Make Compare with basketItemPrice and ProductsPrice 
                foreach (var item in getBasketById.basketItem) 
                {
                   var getProducts = await _unitOfWork.Repository<Products>().GetAsync(item.Id);

                    if(item.Price != getProducts.Price)
                        item.Price = getProducts.Price;
                
                }
                
            }

            //Get DeliveryMethode 
            if(getBasketById.DeliveryMethodId.HasValue)
            {
                var getDeliveryMethode = await _unitOfWork.Repository<DeliveryMethod>().GetAsync(getBasketById.DeliveryMethodId.Value);
                shippingPrice = getDeliveryMethode.cost;
            }

            //Create PaymentIntent 
            PaymentIntent paymentIntent;
            PaymentIntentService paymentIntentService = new PaymentIntentService();

            if(string.IsNullOrEmpty(getBasketById.PaymentId))
            {
                var option = new PaymentIntentCreateOptions()
                {
                    Amount = (long)getBasketById.basketItem.Sum(item => item.Price * 100 * item.Quantity) + (long)shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string>() { "card" }
                };

                paymentIntent = await paymentIntentService.CreateAsync(option);

                getBasketById.PaymentId = paymentIntent.Id;
                getBasketById.ClientSecret = paymentIntent.ClientSecret;



            }

            else
            {
                var option = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)getBasketById.basketItem.Sum(item => item.Price * 100 * item.Quantity) + (long)shippingPrice * 100,
                   
                };

                await paymentIntentService.UpdateAsync(getBasketById.Id, option);
            }
            await _basketRepository.CreateOrUpdateAsync(getBasketById);

            return getBasketById;



        }
    }
}
