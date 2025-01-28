public interface IProductRepository {
    Task<Product> GetProductAsync(int productId);

    Task<List<Product>> GetProductsAsync();
}