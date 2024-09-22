namespace Application.Requests.Cargos;

public class GetAlunoByLikedNameRequest : PagedRequest
{
    public string NmUsuario { get; set; }

    public GetAlunoByLikedNameRequest(string nmUsuario,int? pageNumber, int? pageSize) : base(pageNumber, pageSize)
    {
        NmUsuario = nmUsuario;
    }
}