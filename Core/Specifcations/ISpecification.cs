
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
    public Expression<Func<T, object>> OrderBy {get;  set;} 
    public Expression<Func<T, object>> OrderByDesc {get; set;}
    public List<Expression<Func<T, object>>> Includes { get; }
    public int Skip { get; set; }
    public int Take { get; set; }
    public Boolean IsPageEnabled { get; set; }

}