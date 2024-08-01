using Application.DTOs.Jwt;

namespace Application.Interfaces;

public interface IAuthenticateService
{
    Task<JwtDto?> Authenticate(string email, string password);
}