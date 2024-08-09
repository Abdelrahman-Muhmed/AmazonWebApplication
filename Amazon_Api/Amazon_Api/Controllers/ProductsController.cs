using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Amazon_Core.Specifications.ProductSpec;
using AutoMapper;
using Amazon_Api.Dtos;
namespace Amazon_Api.Controllers
{
   
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _Products;
        private readonly IGenericRepository<ProductBrand> _Brand;
        private readonly IGenericRepository<ProductCategory> _category;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> Products
            , IGenericRepository<ProductBrand> Brand
            , IGenericRepository<ProductCategory> category
            , IMapper mapper)
        {
            _Products = Products;
            _mapper = mapper;
            _Brand = Brand;
            _category = category;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRetuenDto>>> GetAllAsync()
        {
            var ProductsBySpec = new ProductWithPrandAndCategory();
            var products = await _Products.GetAllAsyncWithSpec(ProductsBySpec);
            var ProductMapp = _mapper.Map<IEnumerable<Product>,IEnumerable<ProductRetuenDto>>(products);
            return Ok(ProductMapp);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductRetuenDto>> GetProductAsync(int id)
        {
            var ProductsBySpec = new ProductWithPrandAndCategory(id);
            var product = await _Products.GetAsyncWithSpec(ProductsBySpec);
            if (product == null)
                return NotFound();
            var ProductMapp = _mapper.Map<Product, ProductRetuenDto>(product);
            return Ok(ProductMapp);

        }

        [HttpGet("getBrand")]
        public async Task<ActionResult<ProductBrand>> getProductPrand()
        {
            var brands = await _Brand.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("getCategory")]
        public async Task<ActionResult<ProductBrand>> getProductCategory()
        {
            var categors  = await _category.GetAllAsync();
            return Ok(categors);

        }

    }
}
