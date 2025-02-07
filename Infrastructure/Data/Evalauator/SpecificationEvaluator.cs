// using Microsoft.EntityFrameworkCore;

// public class SpecificationEvaluator<T> where T: BaseEntity {

//     public static IQueryable<T> GetIQuery(IQueryable<T> inputQuery, ISpecification<T> specification) 
//     {
//         var query = inputQuery;
//         if (specification.Criteria != null) {
//             query = query.Where(specification.Criteria);
//         }

//         query = specification.Includes.Aggregate(query
//         , (element, includeExpression) => element.Include(includeExpression));
//         return query;
//     }
// }

using Microsoft.EntityFrameworkCore;
public class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetIQuery(IQueryable<T> queryable, ISpecification<T> specification) {
        var query = queryable;
        if (specification.Criteria != null) {
            query = query.Where(specification.Criteria);
        }

        if (specification.OrderBy != null) 
        {
            query = query.OrderBy(specification.OrderBy);
        }

        if (specification.OrderByDesc != null)  
        {
            query = query.OrderByDescending(specification.OrderByDesc);
        }

        query = specification.Includes.Aggregate(query, 
        (element, expression) => element.Include(expression));

        // if (specification.IsPageEnabled) 
        // {
        //     query = query.Skip(specification.Skip)
        //                 .Take(specification.Take);
        // }

        return query;
    }
}