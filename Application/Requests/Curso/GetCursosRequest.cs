namespace Application.Requests.Curso;

public class GetCursosRequest : PagedRequest
{
    public GetCursosRequest(int? pageNumber, int? pageSize) : base(pageNumber, pageSize)
    {
    }
}