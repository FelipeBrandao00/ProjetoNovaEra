namespace Application.DTOs.Token;

public class tokenDto(string token, DateTime validoAte)
{
    public string Token { get; set; } = token;
    public string Tipo { get; set; } = "Bearer";
    public DateTime ValidoAte { get; set; } = validoAte;
}