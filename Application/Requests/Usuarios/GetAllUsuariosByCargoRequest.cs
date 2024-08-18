namespace Application.Requests.Usuarios;

public class GetAllUsuariosByCargoRequest : PagedRequest
{
    public GetAllUsuariosByCargoRequest(int cdCargo,int? pageNumber, int? pageSize) : base(pageNumber, pageSize)
    {
        CdCargo = cdCargo;
    }
    public int CdCargo { get; set; }

}