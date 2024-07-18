using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class JwtService : IJwtService
{
    private readonly string _secretKey;

    public JwtService(IConfiguration configuration)
    {
        _secretKey = configuration["Jwt:SecretKey"];
    }
    
    public async Task<string> GerarToken(UsuarioDto user)
    {
        var hadler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddMinutes(10),
            Subject = GetClaimsIdentity(user),
        };
        var token = hadler.CreateToken(tokenDescriptor);
        var strToken = hadler.WriteToken(token);
        return strToken;
    }
    
    private ClaimsIdentity GetClaimsIdentity(UsuarioDto user) {
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.dsEmail));
        foreach (var cargoUsuario in user.CargoUsuario)
        {
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, cargoUsuario.Cargo.dsCargo));
        }
        return claimsIdentity;
    }
}