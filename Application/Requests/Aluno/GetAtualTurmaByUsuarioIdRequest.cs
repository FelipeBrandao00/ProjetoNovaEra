namespace Application.Requests.Cargos;

public class GetAtualTurmaByUsuarioIdRequest
{
    public Guid CdAluno { get; set; }

    public GetAtualTurmaByUsuarioIdRequest(Guid cdAluno)
    {
        CdAluno = cdAluno;
    }
}