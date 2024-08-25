using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Login;

public class LoginViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}