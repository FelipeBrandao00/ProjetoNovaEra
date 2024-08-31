namespace Application.Requests.Usuarios;

public class UpdateUsuarioPasswordRequest
{
    public Guid CdUsuario { get; set; }
    public string NewPassword { get; set; }
}