using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.ProductSpecs
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecifications(string? sort, int? brandId, int? categoryId)
            : base(
                    p => (!brandId.HasValue || p.BrandId == brandId) &&
                         (!categoryId.HasValue || p.CategoryId == categoryId)
                  )
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;


                }
            }
            else
                AddOrderBy(p => p.Name);
        }

        public ProductWithBrandAndCategorySpecifications(int id)
            : base(p => p.Id == id)
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }


    }
}
