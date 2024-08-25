using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Amazon_Core.Service;
using Amazon_Core.Specifications.ProductSpec;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Service.ServiceRepo
{
    public class ProductServic : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductServic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IReadOnlyList<Products>> GetAllProductAsync(ProductSpecParameter specParameter)
        {
            var ProductsBySpec = new ProductWithPrandAndCategory(specParameter);
            var products = _unitOfWork.Repository<Products>().GetAllAsyncWithSpec(ProductsBySpec);

            return products;
            
        }

        public Task<int> GetCountAsync(ProductSpecParameter specParameter)
        {
            var coundData = new ProductsWithFiltrationForCountSpec(specParameter);
            var count = _unitOfWork.Repository<Products>().GetCountAsync(coundData);

            return count;

        }

        public Task<Products> GetProductAsync(int id)
        {
            var ProductsBySpec = new ProductWithPrandAndCategory(id);
            var product =  _unitOfWork.Repository<Products>().GetAsyncWithSpec(ProductsBySpec);

            return product;
        }

        public Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            var brands = _unitOfWork.Repository<ProductBrand>().GetAllAsync();
            return brands;
        }

        public Task<IReadOnlyList<ProductCategory>> GetProductCategoryAsync()
        {
            var categors = _unitOfWork.Repository<ProductCategory>().GetAllAsync();
            return categors;
        }
    }
}
