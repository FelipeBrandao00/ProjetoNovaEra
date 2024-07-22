using Application.DTOs;

namespace Application.Interfaces;

public interface IJwtService
{
    string GerarToken(UsuarioDto user);
}