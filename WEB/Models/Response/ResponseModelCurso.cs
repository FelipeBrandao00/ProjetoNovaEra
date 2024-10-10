using System.ComponentModel.DataAnnotations;

namespace Application.Responses;

public class ResponseModelCurso
{
    public int CdCurso { get; init; }
    public string NmCurso { get; init; }
    public string DsCurso { get; init; }
    public DateTime? DtCriacao { get; init; }
    public DateTime? DtFinalizacao { get; init; }
}
