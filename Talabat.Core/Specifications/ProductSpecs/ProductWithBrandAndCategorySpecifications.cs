using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.ProductSpecs
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecifications(ProductSpecParams productParams)
            : base(
                    p => (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) &&
                         (!productParams.BrandId.HasValue || p.BrandId == productParams.BrandId) &&
                         (!productParams.CategoryId.HasValue || p.CategoryId == productParams.CategoryId)
                  )
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
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
            //product = 18 ~ 20
            // page size = 5
            //page index = 3

            ApplyPagination((productParams.PageIndex - 1) * productParams.PageSize, productParams.PageSize);

        }

        public ProductWithBrandAndCategorySpecifications(int id)
            : base(p => p.Id == id)
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }


    }
}
