
// public class ProductWithTypesAndBrandSpecification : BaseSpecification<Product> {
//     public ProductWithTypesAndBrandSpecification() 
//     {
//         AddInclude(x => x.ProductType);
//         AddInclude(x => x.ProductBrand);
//     }
// }




using System.Linq.Expressions;

public class ProductsWithBrandAndTypeSpecification<T> : BaseSpecification<Product> {
    public ProductsWithBrandAndTypeSpecification(ProductParams productParams) 
    : base
        ( 
            // p => 
            // (!brandId.HasValue || p.ProductBrandId == brandId )
            // && (!typeId.HasValue || p.ProductTypeId == typeId))

            p => (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId)
            && (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId)
        )
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);

        if (productParams.OrderBy != null) 
        {
            switch (productParams.OrderBy)
            {
            case "priceAsc": AddOrderBy(p => p.Price); 
            break;
            case "priceDesc": AddOrderByDesc(p => p.Price);
            break;
            default: AddOrderBy(p => p.Name);
            break;
            }
        }
    }

    public ProductsWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }
}