namespace Application.Responses;

public class ResponseModelUsuario
{
    public Guid CdUsuario { get; init; }
    public string NmUsuario { get; init; }
    public string DsEmail { get; init; } 
    public string DsCpf { get; init; } 
    public string? DsTelefone { get; init; }
    public string StrDsGenero { get; init; }
    public DateTime? DtNascimento { get; init; }
    public byte[]? DsFoto { get; set; }
}