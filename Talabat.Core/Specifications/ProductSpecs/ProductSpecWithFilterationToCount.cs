using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.ProductSpecs
{
    public class ProductSpecWithFilterationToCount : BaseSpecifications<Product>

    {
        public ProductSpecWithFilterationToCount(ProductSpecParams productparams)
            : base(
                    p => (!productparams.BrandId.HasValue || p.BrandId == productparams.BrandId.Value)
                    &&
                    (!productparams.CategoryId.HasValue || p.CategoryId == productparams.CategoryId.Value)
                  )
        {

        }
    }
}
