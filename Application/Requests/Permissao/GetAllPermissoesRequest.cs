namespace Application.Requests.Permissao;

public class GetAllPermissoesRequest : PagedRequest
{
    public GetAllPermissoesRequest(int? pageNumber, int? pageSize) : base(pageNumber, pageSize)
    {
    }
}