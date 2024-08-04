using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon_Api.Controllers
{
   
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _Products;
        public ProductsController(IGenericRepository<Product> Products)
        {
            _Products = Products;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
        {
            var products = await _Products.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            var product = await _Products.GetAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);

        }
    
    }
}
