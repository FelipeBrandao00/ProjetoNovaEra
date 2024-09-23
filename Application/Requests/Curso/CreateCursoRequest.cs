namespace Application.Requests.Curso;

public class CreateCursoRequest
{
    public required string NmCurso { get; set; }
    public required string DsCurso { get; set; }
    public DateTime DtCriacao { get; set; }
}