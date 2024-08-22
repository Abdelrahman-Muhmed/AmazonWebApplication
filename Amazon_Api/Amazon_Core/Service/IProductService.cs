using Amazon_Core.Model;
using Amazon_Core.Specifications.ProductSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Service
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAllProductAsync(ProductSpecParameter specParameter);
        Task<Product> GetProductAsync(int id);
        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
        Task<IReadOnlyList<ProductCategory>> GetProductCategoryAsync();

        Task<int> GetCountAsync(ProductSpecParameter specParameter);



    }
}
