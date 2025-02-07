// using System.Linq.Expressions;

// public class BaseSpecification<T> : ISpecification<T> where T: BaseEntity
// {
//     public BaseSpecification() {

//     }
//     public BaseSpecification(Expression<Func<T, bool>> criteria)
//     {
//         Criteria = criteria;
//     }

//     public Expression<Func<T, bool>> Criteria {get;}

//     public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>();

//     protected void AddInclude(Expression<Func<T, object>> expression) {
//         Includes.Add(expression);
//     }

// }



// // using System.Linq.Expressions;

// // public class BaseSpecification<T> : ISpecification<T> where T: BaseEntity
// // {
// //     public BaseSpecification(Expression<Func<T, bool>> criteria)
// //     {
// //         Criteria = criteria;
// //     }

// //     public Expression<Func<T, bool>> Criteria { get;}
// //     public List<Expression<Func<T, object>>> Include { get; } =
// //         new List<Expression<Func<T, object>>>();

// //     public void AddInclude(Expression<Func<T, object>> include) {
// //         Include.Add(include);
// //     }
// //  }


using System.Linq.Expressions;

public class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification() {}
    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }

    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T,object>>>();
    public Expression<Func<T, object>> OrderBy { get ; set ; }
    public Expression<Func<T, object>> OrderByDesc { get ; set ; }
    public int Skip { get ; set; }
    public int Take { get; set ; }
    public bool IsPageEnabled { get; set; }

    public void AddInclude(Expression<Func<T, object>> include) {
        Includes.Add(include);
    }

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDesc = orderByDescExpression;
    }

    protected void AddPaginationParams(int skip, int take) 
    {
        Skip = skip;
        Take = take;
        IsPageEnabled = true;
    } 
}