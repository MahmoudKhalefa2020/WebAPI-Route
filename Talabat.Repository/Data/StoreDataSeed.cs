using System.Text.Json;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class StoreDataSeed
    {
        public async static Task DataSeedAsync(StoreContext storeContext)
        {
            if (storeContext.ProductBrands.Count() == 0)
            {
                var brandData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                if (brands?.Count() > 0)
                {
                    //brands = brands.Select(b => new ProductBrand()
                    //{
                    //    Name = b.Name
                    //}).ToList();

                    foreach (var brand in brands)
                    {
                        storeContext.Set<ProductBrand>().Add(brand);
                    }
                    await storeContext.SaveChangesAsync();
                }
            }
            if (storeContext.ProductCategories.Count() == 0)
            {
                var categoryData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductBrand>>(categoryData);
                if (categories?.Count() > 0)
                {
                    //brands = brands.Select(b => new ProductBrand()
                    //{
                    //    Name = b.Name
                    //}).ToList();

                    foreach (var category in categories)
                    {
                        storeContext.Set<ProductBrand>().Add(category);
                    }
                    await storeContext.SaveChangesAsync();
                }
            }
            if (storeContext.Products.Count() == 0)
            {
                var productData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/products.json");
                var products = JsonSerializer.Deserialize<List<ProductBrand>>(productData);
                if (products?.Count() > 0)
                {
                    //brands = brands.Select(b => new ProductBrand()
                    //{
                    //    Name = b.Name
                    //}).ToList();

                    foreach (var product in products)
                    {
                        storeContext.Set<ProductBrand>().Add(product);
                    }
                    await storeContext.SaveChangesAsync();
                }
            }

        }
    }
}
