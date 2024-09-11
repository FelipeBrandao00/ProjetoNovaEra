namespace Application.Requests.Usuarios;

public class UpdateUsuarioPasswordRequest
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
}