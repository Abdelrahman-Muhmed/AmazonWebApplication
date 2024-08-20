using Amazon_Core.Model;
using Amazon_Core.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.IRepository
{
    public interface IUnitOfWork: IAsyncDisposable 
    {
        //I will Create Prop Signture For Every Table From IGenaric 

        //IGenericRepository<Product> product { get; set; }
        //IGenericRepository<ProductBrand> productBrand { get; set; }
        //IGenericRepository<ProductCategory> productCategory { get; set; }
        //IGenericRepository<Order> order { get; set; }
        //IGenericRepository<OrderItem> orderItem { get; set; }
        //IGenericRepository<DeliveryMethod> deliveryMethod { get; set; }

        //Make This prop as a Methode 
        IGenericRepository<T>  Repository<T>() where T : BaseEntity;  // So when i path any Table here he will create The Object What i need When i ask 
        Task<int> CompleteAsync();
         
    }
}
