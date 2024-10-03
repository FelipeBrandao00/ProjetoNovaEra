namespace Application.Requests.Usuarios;

public class UpdateUsuarioRequest
{
    public Guid CdUsuario { get; set; }
    public string NmUsuario { get; set; }
    public string DsEmail { get; set; }
    public string DsCpf { get; set; }
    public int DsGenero { get; set; }
    public DateTime? DtNascimento { get; set; }
    public bool? IcHabilitadoTurma { get; set; } = null;
    public byte[]? DsFoto { get; set; }
    public string? DsTelefone { get; set; }
}