using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Amazon_Core.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon_EF.Data;
using System.Collections;
namespace Amazon_EF.SqlRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _dbContext;
        //private Dictionary<string, GenericRepository<BaseEntity>> _reopsitory;
        private Hashtable _reopsitory;

        //public IGenericRepository<Product> product { get; set; } = null!;
        //public IGenericRepository<ProductBrand> productBrand { get; set; } = null!;
        //public IGenericRepository<ProductCategory> productCategory { get; set; } = null!;
        //public IGenericRepository<Order> order { get; set; } = null!;
        //public IGenericRepository<OrderItem> orderItem { get; set; } = null!;
        //public IGenericRepository<DeliveryMethod> deliveryMethod { get; set; } = null!;

        //But We can be Methode To be Code Better 
        //Path SortContext For Constructor 
        public UnitOfWork(StoreContext dbContext)
        {
            _dbContext = dbContext;
            //_reopsitory = new Dictionary<string, GenericRepository<BaseEntity>>();
            _reopsitory = new Hashtable();

            // product = new GenericRepository<Product>(_dbContext);
            // productBrand = new GenericRepository<ProductBrand>(_dbContext);
            // order = new GenericRepository<Order>(_dbContext);
            // orderItem = new GenericRepository<OrderItem>(_dbContext);
            // deliveryMethod = new GenericRepository<DeliveryMethod>(_dbContext);

        }
        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            //I can path the object and equal it there but that will make me add for every object and make equal in the Feuture So i will using Dictionary 
            

            //I need to get the key and Value
            var key = typeof(T).Name;

            if(!_reopsitory.ContainsKey(key))
            {
                //var value = new GenericRepository<T>(_dbContext) as GenericRepository<BaseEntity>;
                var value = new GenericRepository<T>(_dbContext);

                _reopsitory.Add(key , value);
            }

            return _reopsitory[key] as IGenericRepository<T>;
            
            //but i can use HashTable Foe make key object and value object 

        }

        public async Task<int> CompleteAsync()
         => await _dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync()
         => await _dbContext.DisposeAsync();




    }
}
