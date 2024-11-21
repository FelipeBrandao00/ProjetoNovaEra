namespace Application.Responses;

public class ResponseModelTurmaAluno {
    public Guid CdAluno { get; init; }
    public int CdTurma { get; init; }
    public bool? IcAprovado { get; init; }
    public string? NmTurma { get; init; }
    public int? CdCurso { get; init; }
    public string? NmCurso { get; init; }
}