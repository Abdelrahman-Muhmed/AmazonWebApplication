using Amazon_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Specifications.ProductSpec
{
    public class ProductsWithFiltrationForCountSpec : BaseSpecification<Product>
    {
        public ProductsWithFiltrationForCountSpec(ProductSpecParameter specParameter)

          : base(
                p =>
                (string.IsNullOrEmpty(specParameter.Search) || p.Name.ToLower().Contains(specParameter.Search.ToLower())) &&
                (!specParameter.brandId.HasValue || p.BrandId == specParameter.brandId.Value) &&
                (!specParameter.categoryId.HasValue || p.CategoryId == specParameter.categoryId.Value)

                )


        {

        }
    }
}