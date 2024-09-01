namespace Application.Requests.PasswordChange;

public class VerifyPasswordChangeCodeRequest
{
    public Guid CdUsuario { get; set; }
    public string DsToken { get; set; }
}