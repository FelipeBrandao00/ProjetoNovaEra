using Domain.Entities;

namespace Application.DTOs.TurmaAluno;

public class TurmaAlunoDto
{
    public Guid CdAluno { get; set; }
    public int? CdTurma { get; set; }
    public bool? IcAprovado { get; set; }
    public string? NmTurma { get; set; }
    public int? CdCurso { get; set; }
    public string? NmCurso { get; set; }
}