namespace Application.Requests.Curso;

public class GetCursosRequest : PagedRequest
{
    public DateTime? DtInicial { get; set; }
    public DateTime? DtFinal { get; set; } 
    public bool? IcAndamento { get; set; } 
    public bool? IcFinalizado { get; set; } 
    public GetCursosRequest(int? pageNumber, int? pageSize, DateTime? dtInicial, DateTime? dtFinal, bool? icAndamento, bool? icFinalizado) : base(pageNumber, pageSize)
    {
        DtInicial = dtInicial;
        DtFinal = dtFinal;
        IcAndamento = icAndamento ?? true;
        IcFinalizado = icFinalizado ?? true;
    }
}