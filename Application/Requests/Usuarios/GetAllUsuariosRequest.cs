namespace Application.Requests.Usuarios;

public class GetAllUsuariosRequest : PagedRequest
{
    public GetAllUsuariosRequest(int? pageNumber , int? pageSize ) : base(pageNumber,pageSize) { }
}