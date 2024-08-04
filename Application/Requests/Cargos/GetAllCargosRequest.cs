namespace Application.Requests.Cargos;

public class GetAllCargosRequest : PagedRequest
{
    public GetAllCargosRequest(int? pageNumber, int? pageSize) : base(pageNumber, pageSize)
    {
    }
}