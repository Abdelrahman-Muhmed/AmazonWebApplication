using Amazon_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Specifications.ProductSpec
{
    public class ProductWithPrandAndCategory : BaseSpecification<Product>
    {
        public ProductWithPrandAndCategory() : base()
        {
            Include.Add(p => p.ProductBrand);
            Include.Add(p => p.CategoryName);
        }

        public ProductWithPrandAndCategory(int id) : base(p => p.id == id)
        {
            Include.Add(p => p.ProductBrand);
            Include.Add(p => p.CategoryName);
        }
    }
}
