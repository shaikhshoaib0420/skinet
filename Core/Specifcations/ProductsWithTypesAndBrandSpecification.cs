
// public class ProductWithTypesAndBrandSpecification : BaseSpecification<Product> {
//     public ProductWithTypesAndBrandSpecification() 
//     {
//         AddInclude(x => x.ProductType);
//         AddInclude(x => x.ProductBrand);
//     }
// }




using System.Linq.Expressions;

public class ProductsWithBrandAndTypeSpecification<T> : BaseSpecification<Product> {
    public ProductsWithBrandAndTypeSpecification() {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }

    public ProductsWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }
}