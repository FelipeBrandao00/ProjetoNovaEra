using Application.DTOs.Jwt;

namespace Application.Interfaces;

public interface IJwtService
{
    string GerarToken(JwtDto jwtDto);
}