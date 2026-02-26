namespace ContactManagement.Api.Core.Dtos.Pagination;

public class PagedResponseDto<T>
{
    public IEnumerable<T> Data { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }

    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;
}
