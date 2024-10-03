namespace Application.Requests.Professor;

public class GetProfessoresRequest : PagedRequest
{
    public string NmProfessor { get; set; }
    public bool? IcHabilitadoTurma { get; set; }

    public GetProfessoresRequest(int? pageNumber, int? pageSize,string nmProfessor = "",bool? icHabilitadoTurma = null) : base(pageNumber, pageSize)
    {
        NmProfessor = nmProfessor;
        IcHabilitadoTurma = icHabilitadoTurma;
    }
}