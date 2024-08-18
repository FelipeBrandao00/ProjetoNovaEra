using Application.DTOs.Jwt;
using Application.DTOs.Token;
using Application.Responses;

namespace Application.Interfaces;

public interface IJwtService
{
    Response<tokenDto> GerarToken(JwtDto jwtDto);
}