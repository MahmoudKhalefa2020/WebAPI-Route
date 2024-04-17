using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.ProductSpecs
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecifications()
            : base()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);

        }

        public ProductWithBrandAndCategorySpecifications(int id)
            : base(p => p.Id == id)
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }


    }
}
