
public interface IGenericRepository<T> where T: BaseEntity
{
    Task<T> GetByIdAsync(int id);

    Task<List<T>> GetAllAsync();

    // Task<List<T>> GetAllBySpecification(ISpecification<T> specification);


    Task<List<T>> GetAllBySpecification(ISpecification<T> specification);
    Task<T> GetProductBySpecification(ISpecification<T> specification);
}