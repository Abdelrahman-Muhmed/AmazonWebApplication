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

                (!specParameter.brandId.HasValue || p.BrandId == specParameter.brandId.Value) &&
                (!specParameter.categoryId.HasValue || p.CategoryId == specParameter.categoryId.Value)

                )


        {

        }
    }
}