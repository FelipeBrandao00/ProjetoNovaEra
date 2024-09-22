namespace Application.DTOs.TurmaAluno;

public class TurmaAlunoDto
{
    public Guid CdAluno { get; set; }
    public int CdTurma { get; set; }
    public bool? IcAprovado { get; set; }
}