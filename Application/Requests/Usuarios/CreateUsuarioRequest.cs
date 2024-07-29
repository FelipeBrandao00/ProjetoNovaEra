namespace Application.Requests.Usuarios;

public class CreateUsuarioRequest
{
    public string nmUsuario { get; set; }
    public string dsEmail { get; set; }
    public string dsSenha { get; set; }
    public string dsCPF { get; set; }
    public int dsGenero { get; set; }
}