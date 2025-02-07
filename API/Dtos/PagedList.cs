

using Microsoft.EntityFrameworkCore;

public class PagedList<T> : List<T>
{
    public PagedList(List<T> items, int pageNumber, int pageSize, int count)
    {
        PaginationMetaData = new PaginationMetaData {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = count, 
            TotalPages = (int) Math.Round(count / (double) pageSize),
        };

        AddRange(items);
    }

    public PaginationMetaData PaginationMetaData { get; set; }

    public static async Task<PagedList<T>> ToPagedList(IQueryable<T> query, int pageNumber, int pageSize) 
    {
        int count = query.Count();
        List<T> items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new PagedList<T>(items, pageNumber, pageSize, count);
    }
}

