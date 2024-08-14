using Amazon_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amazon_EF.SqlRepository.Data
{
    public static class DataSeeding
    {
        public async static Task seedAsync(StoreContext dbContext)
        {
            var brands = File.ReadAllText("../Amazon_EF/Data/DataSeedingFile/brands.json");
            var Category = File.ReadAllText("../Amazon_EF/Data/DataSeedingFile/categories.json");
            var Product = File.ReadAllText("../Amazon_EF/Data/DataSeedingFile/products.json");

            var brandsData = JsonSerializer.Deserialize<List<ProductBrand>>(brands);
            var CategoryData = JsonSerializer.Deserialize<List<ProductCategory>>(Category);
            var ProductData = JsonSerializer.Deserialize<List<Product>>(Product);


            if (dbContext.ProductBrand.Count() == 0)
            {
                if (brandsData?.Count() > 0)
                {
                    foreach (var brand in brandsData)
                    {
                        dbContext.Set<ProductBrand>().Add(brand);
                    }
                }

                await dbContext.SaveChangesAsync();
            }

            if (dbContext.ProductCategory.Count() == 0)
            {
                if (CategoryData?.Count() > 0)
                {
                    foreach (var category in CategoryData)
                    {
                        dbContext.Set<ProductCategory>().Add(category);


                    }
                }
                await dbContext.SaveChangesAsync();
            }

            if (dbContext.Product.Count() == 0)
            {
                if (ProductData?.Count() > 0)
                {
                    foreach (var product in ProductData)
                    {
                        dbContext.Set<Product>().Add(product);


                    }
                }
                await dbContext.SaveChangesAsync();
            }
        }
    }


}
