using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.ProductSpecs
{
    public class ProductSpecWithFilterationToCount : BaseSpecifications<Product>

    {
        public ProductSpecWithFilterationToCount(ProductSpecParams productParams)
            : base(
                    p =>
                    (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) &&
                    (!productParams.BrandId.HasValue || p.BrandId == productParams.BrandId.Value)
                    &&
                    (!productParams.CategoryId.HasValue || p.CategoryId == productParams.CategoryId.Value)
                  )
        {

        }
    }
}
