using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Application.DTOs.Usuario;

public class UsuarioDto(Guid CdUsuario,string NmUsuario, string DsEmail, string DsCpf,string? DsTelefone, Genero? DsGenero,DateTime? DtNascimento,byte[]? DsFoto)
{
    public Guid CdUsuario { get; init; } = CdUsuario;
    public string NmUsuario { get; init; } = NmUsuario;
    public string DsEmail { get; init; } = DsEmail;
    public string DsCpf { get; init; } = DsCpf;
    public string? DsTelefone { get; init; } = DsTelefone;
    public Genero? DsGenero { get; init; } = DsGenero;
    public string StrDsGenero { get; init; } = DsGenero?.ToString();
    public DateTime? DtNascimento { get; init; } = DtNascimento;
    public byte[]? DsFoto { get; set; }
}