using Application.DTOs;
using Application.DTOs.Usuario;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq;

namespace Application.Services;

public class UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper) : IUsuarioService
{
    public async Task<AddUsuarioResponseDto> AddUsuario(AddUsuarioRequestDto usuarioDto)
    {
        var usuarioEntity = mapper.Map<Usuario>(usuarioDto);
        var retorno =  await usuarioRepository.AddUsuario(usuarioEntity);

        return mapper.Map<AddUsuarioResponseDto>(retorno);
    }

    public Task<UsuarioDto> UpdateUsuario(UsuarioDto usuario)
    {
        throw new NotImplementedException();
    }

    public async Task<GetUsuarioResponseDto?> GetUsuarioByCpf(string cpf)
    { 
        return mapper.Map<GetUsuarioResponseDto>(await usuarioRepository.GetUsuarioByCpf(cpf));
    }

    public async Task<IEnumerable<GetUsuarioResponseDto>> GetUsuarios()
    {
        List<Usuario> listaUsuarios = await usuarioRepository.GetUsuarios();

        List<GetUsuarioResponseDto> result = new();

        foreach (var usuario in listaUsuarios)
        {
            result.Add(mapper.Map<GetUsuarioResponseDto>(usuario));
        }
                
        return result;
    }

    public async Task<UsuarioDto?> Authenticate(string email, string password)
    {
        var usuarioEntity =  await usuarioRepository.Authenticate(email, password);
        var result = mapper.Map<UsuarioDto>(usuarioEntity);
        return result;
    }
}