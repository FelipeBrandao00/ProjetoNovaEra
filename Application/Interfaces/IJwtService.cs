using Application.DTOs;

namespace Application.Interfaces;

public interface IJwtService
{
    Task<string> GerarToken(UsuarioDto user);
}