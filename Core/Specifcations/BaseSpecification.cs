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

    public void AddInclude(Expression<Func<T, object>> include) {
        Includes.Add(include);
    }
}