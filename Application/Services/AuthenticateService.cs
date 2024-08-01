using Application.DTOs.Jwt;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services;

public class AuthenticateService(IMapper mapper, IAuthenticateRepository authenticateRepository) : IAuthenticateService
{
    public async Task<JwtDto?> Authenticate(string email, string password)
    {
        var usuarioEntity =  await authenticateRepository.Authenticate(email, password);
        var result = mapper.Map<JwtDto>(usuarioEntity);
        return result;
    }
}