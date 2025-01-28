
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly SkinetContext _skinetContext;

    public GenericRepository(SkinetContext skinetContext)
    {
        _skinetContext = skinetContext;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _skinetContext.Set<T>().ToListAsync();
    }

    public Task<List<T>> GetAllBySpecification(ISpecification<T> specification)
    {
       return ApplySpecification(specification).ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _skinetContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> GetProductBySpecification(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync();
    }

    // public async Task<List<T>> GetAllBySpecification(ISpecification<T> specification)
    // {
    //     return await AddSpecification(specification).ToListAsync();
    // }

    // private IQueryable<T> AddSpecification(ISpecification<T> specification)
    // {
    //     return SpecificationEvaluator<T>.GetIQuery(_skinetContext.Set<T>().AsQueryable(), specification);
    // }



    private IQueryable<T> ApplySpecification(ISpecification<T>  specification) {
        return SpecificationEvaluator<T>.GetIQuery(_skinetContext.Set<T>().AsQueryable(), specification);
    }

}
