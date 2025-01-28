
// using System.Linq.Expressions;

// public interface ISpecification<T> where T : BaseEntity
// {
//     public Expression<Func<T, bool>> Criteria { get; }
//     public List<Expression<Func<T, object>>> Includes { get; }
// }



using System.Linq.Expressions;

public interface ISpecification<T> 
{
    public Expression<Func<T, bool>> Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; }

}