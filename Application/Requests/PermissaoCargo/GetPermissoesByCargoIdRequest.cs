namespace Application.Requests;

public class GetPermissoesByCargoIdRequest : PagedRequest
{
    public int CdCargo { get; set; }
    public GetPermissoesByCargoIdRequest(int cdCargo, int? pageNumber, int? pageSize) : base(pageNumber, pageSize)
    {
        CdCargo = cdCargo;
    }
}