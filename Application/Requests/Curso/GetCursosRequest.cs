namespace Application.Requests.Curso;

public class GetCursosRequest : PagedRequest {
    public string Nome { get; set; }
    public DateTime? DtInicial { get; set; }
    public DateTime? DtFinal { get; set; }
    public bool? IcAndamento { get; set; }
    public bool? IcFinalizado { get; set; }
    public GetCursosRequest(string nome, int? pageNumber, int? pageSize, DateTime? dtInicial, DateTime? dtFinal, bool? icFinalizado) : base(pageNumber, pageSize) {
        Nome = nome.Trim();
        DtInicial = dtInicial;
        DtFinal = dtFinal;
        IcFinalizado = icFinalizado;
    }
}