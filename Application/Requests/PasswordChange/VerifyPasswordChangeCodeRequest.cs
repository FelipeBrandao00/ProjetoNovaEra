namespace Application.Requests.PasswordChange;

public class VerifyPasswordChangeCodeRequest
{
    public string Email { get; set; }
    public string DsToken { get; set; }
}