using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Amazon_Core.Specifications.ProductSpec;
using AutoMapper;
using Amazon_Api.Dtos;
using Amazon_Api.Helpers;
using Microsoft.AspNetCore.Authorization;
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

        //(AuthenticationSchemes = "Bearer") He give Invalid Opearations Error 
        //And if i dont right (AuthenticationSchemes = "Bearer")] He give me Not Found Becuse He can't knwo the Schema 
        //(AuthenticationSchemes = "Bearer") We Remove this Because its coming From Chalnge Schema 
        [Authorize]
        [HttpGet]
        //Error 415 is becuse the parameter coming from empty body when using propert parameter from object 
        public async Task<ActionResult<Pagination<ProductRetuenDto>>> GetAllAsync([FromQuery] ProductSpecParameter specParameter)
        {
            //Sorting Start By Path Parameter To ProductWithPrandAndCategory to make Functionalty 
           
            var ProductsBySpec = new ProductWithPrandAndCategory(specParameter);
            var products = await _Products.GetAllAsyncWithSpec(ProductsBySpec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductRetuenDto>>(products);
            //I have here send ProductsBySpec but i dont nedd all this i just need critaria What return ==> Create New Class 
            var coundData = new ProductsWithFiltrationForCountSpec(specParameter);
            var count = await _Products.GetCountAsync(coundData);
            //I will return the Paginations contain List Of(T) From Data 
            return Ok(new Pagination<ProductRetuenDto>(specParameter.PageSize , specParameter.PageIndex , data ,count));
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
