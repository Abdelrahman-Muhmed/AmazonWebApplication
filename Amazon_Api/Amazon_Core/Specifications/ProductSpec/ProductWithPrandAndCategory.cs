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
        public ProductWithPrandAndCategory(ProductSpecParameter specParameter)
            : base(
                  p  =>
                  (!string.IsNullOrEmpty(specParameter.Search) || p.Name.ToLower().Contains(specParameter.Search.ToLower())) &&
                  (!specParameter.brandId.HasValue || p.BrandId == specParameter.brandId.Value) && 
                  (!specParameter.categoryId.HasValue || p.CategoryId == specParameter.categoryId.Value) 
                  
                  
                  )

        {

            //The Pagination Work by Take And Skipe  ==> iGenricInterface 


            Include.Add(p => p.ProductBrand);
            Include.Add(p => p.CategoryName);

            //Check on the sorting if null or not 
            if(!string.IsNullOrEmpty(specParameter.sorting))
            {
                switch(specParameter.sorting)
                {
                    case "PricAse":
                        //orderBy = p => p.Price;
                        AddOrderBy(p => p.Price);
                        break;
                    case "PricDes":
                        //orderByDes = p => p.Price;
                        AddOrderByDes(p => p.Price);
                        break;
                    default:
                        orderBy = p => p.Name;
                        break;
        
                }
            }
            else
            {
                AddOrderBy(p => p.Name);
            }


            /*
             -totalProducts = 18 ~ 20
             -PageSize = 5 
             -PageIndex = 4
             
             */
            //Handle Paination 
            ApplyPagination((specParameter.PageIndex - 1) * specParameter.PageSize, specParameter.PageSize);
               
        }

        public ProductWithPrandAndCategory(int id) : base(p => p.id == id)
        {
            Include.Add(p => p.ProductBrand);
            Include.Add(p => p.CategoryName);
        }


        
    }
}
