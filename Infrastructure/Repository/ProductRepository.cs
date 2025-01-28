

using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly SkinetContext _skinetContext;

    public ProductRepository(SkinetContext skinetContext)
    {
        _skinetContext = skinetContext;
    }

    public async Task<Product> GetProductAsync(int productId)
    {
        return await _skinetContext.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _skinetContext.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .ToListAsync();
    }
}