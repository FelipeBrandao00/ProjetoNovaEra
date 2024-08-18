using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs.Jwt;
using Application.DTOs.Token;
using Application.Interfaces;
using Application.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class JwtService : IJwtService
{
    private readonly string _secretKey;

    public JwtService(IConfiguration configuration)
    {
        _secretKey = configuration["Jwt:SecretKey"] ?? throw new Exception("Chave de autenticação inválida!");
    }
    
    public Response<tokenDto> GerarToken(JwtDto jwtDto)
    {
        try
        {
            var hadler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var validade = DateTime.UtcNow.AddDays(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = validade,
                Subject = GetClaimsIdentity(jwtDto),
            };
            var token = hadler.CreateToken(tokenDescriptor);
            var strToken = hadler.WriteToken(token);
            return new Response<tokenDto>(new tokenDto(strToken, validade));
        }
        catch (Exception e)
        {
            return new Response<tokenDto>(null, 500, "Algo deu errado tentando gerar o token.");
        }
    }
    
    private ClaimsIdentity GetClaimsIdentity(JwtDto jwtDto) {
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, jwtDto.DsEmail));
        foreach (var cargoUsuario in jwtDto.CargoUsuario)
        {
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, cargoUsuario.Cargo.DsCargo));
        }
        return claimsIdentity;
    }
}