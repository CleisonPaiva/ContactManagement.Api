using ContactManagement.Api.Core.Dtos.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Api.Core.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedResponseDto<T>> ToPagedResponseAsync<T>(
        this IQueryable<T> query, int page, int pageSize)
    {
        var total = await query.CountAsync();
        var data = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResponseDto<T>
        {
            Data = data,
            TotalRecords = total,
            TotalPages = (int)Math.Ceiling(total / (double)pageSize),
            CurrentPage = page
        };
    }
}
