namespace Application.Requests.CargoUsuario;

public class GetCargosByUserIdRequest : PagedRequest
{
    public Guid CdUsuario { get; set; }
    public GetCargosByUserIdRequest(Guid cdUsuario,int? pageNumber, int? pageSize) : base(pageNumber, pageSize)
    {
        CdUsuario = cdUsuario;
    }
}