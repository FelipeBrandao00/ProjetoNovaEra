namespace Application.Requests.PasswordChange;

public class AddPasswordChangeRequest
{
    public Guid CdUsuario { get; set; }
    public string DsCodigoRedefinicao { get; set; }
    public DateTime DtValidade { get; set; }
}