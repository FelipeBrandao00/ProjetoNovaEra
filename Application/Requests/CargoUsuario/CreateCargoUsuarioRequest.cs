namespace Application.Requests.CargoUsuario;

public class CreateCargoUsuarioRequest
{
    public Guid CdUsuario { get; set; }
    public int CdCargo { get; set; }
}