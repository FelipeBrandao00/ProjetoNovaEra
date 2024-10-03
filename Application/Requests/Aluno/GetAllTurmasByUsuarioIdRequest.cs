namespace Application.Requests.Cargos;

public class GetAllTurmasByUsuarioIdRequest : PagedRequest
{
    public Guid CdAluno { get; set; }
    public GetAllTurmasByUsuarioIdRequest(Guid cdAluno,int? pageNumber, int? pageSize) : base(pageNumber, pageSize)
    {
        CdAluno = cdAluno;
    }
}