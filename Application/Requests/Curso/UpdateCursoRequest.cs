namespace Application.Requests.Curso;

public class UpdateCursoRequest {
    public int CdCurso { get; set; }
    public required string NmCurso { get; set; }
    public required string DsCurso { get; set; }
    public DateTime DtCriacao { get; set; }
    public DateTime? DtFinalizacao { get; set; }
}