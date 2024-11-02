namespace Application.Responses;

public class ResponseModelTurma {
    public int CdTurma { get; init; }
    public string NmTurma { get; init; }
    public string DsTurma { get; init; }
    public DateTime DtInicio { get; init; }
    public DateTime? DtFim { get; init; }
    public int CdCurso { get; init; }
    public Guid CdProfessor { get; init; }
    public bool IcAbertaMatricula { get; init; }
}
