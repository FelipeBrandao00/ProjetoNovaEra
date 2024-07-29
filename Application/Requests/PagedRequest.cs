namespace Application.Requests;

public class PagedRequest
{
    public PagedRequest(int? pageNumber, int? pageSize )
    {
        PageSize = pageSize ?? Configuration.DefaultPageSize;
        PageNumber = pageNumber ?? Configuration.DefaultPageNumber;
    }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}