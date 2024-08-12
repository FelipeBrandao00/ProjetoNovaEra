namespace Application.Requests.Usuarios;

public class CreateUsuarioRequest
{
    public string NmUsuario { get; set; }
    public string DsEmail { get; set; }
    public string DsSenha { get; set; }
    public string DsCpf { get; set; }
    public int DsGenero { get; set; }
    public DateTime? DtNascimento { get; set; }
    public bool? IcHabilitadoTurma { get; set; }
}