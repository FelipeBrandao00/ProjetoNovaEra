using Application.DTOs;
using Application.DTOs.Usuario;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces;

namespace Application.Services;

public class UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper) : IUsuarioService
{
    public async Task<UsuarioDto> AddUsuario(AddUsuarioDto usuarioDto)
    {
        var usuarioEntity = mapper.Map<Usuario>(usuarioDto);
        var retorno =  await usuarioRepository.AddUsuario(usuarioEntity);

        return mapper.Map<UsuarioDto>(retorno);
    }

    public Task<UsuarioDto> UpdateUsuario(UsuarioDto usuario)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioDto?> GetUsuarioByCpf(string cpf)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UsuarioDto>> GetUsuarios()
    {
        throw new NotImplementedException();
    }

    public async Task<UsuarioDto?> Authenticate(string email, string password)
    {
        var usuarioEntity =  await usuarioRepository.Authenticate(email, password);
        var result = mapper.Map<UsuarioDto>(usuarioEntity);
        return result;
    }
}