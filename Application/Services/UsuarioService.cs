using Application.DTOs;
using Application.DTOs.Jwt;
using Application.DTOs.Usuario;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.Requests.Usuarios;
using Application.Responses;

namespace Application.Services;

public class UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper) : IUsuarioService
{
    public async Task<Response<UsuarioDto>> AddUsuario(CreateUsuarioRequest request)
    {
        try
        {
            var usuarioEntity = mapper.Map<Usuario>(request);
            var retorno =  await usuarioRepository.AddUsuario(usuarioEntity);
            return new Response<UsuarioDto>(
                mapper.Map<UsuarioDto>(retorno), 
                201, 
                "Usuário criado com sucesso!");
        }
        catch (Exception e)
        {
            return new Response<UsuarioDto>(
                null, 
                500, 
                "Não foi possível criar o usuário");
        }
    }

    public async Task<Response<UsuarioDto>> UpdateUsuario(UpdateUsuarioRequest request)
    {
        try
        {
            var usuario = mapper.Map<Usuario>(request);
            var result = await usuarioRepository.UpdateUsuario(usuario);
            return new Response<UsuarioDto>(mapper.Map<UsuarioDto>(result), 200, "Usuário atualizado com sucesso!");            
        }
        catch (Exception e)
        {
            return new Response<UsuarioDto>(null, 500, "Não foi possível atualizar o usuário.");
        }
    }

    public async Task<Response<UsuarioDto>> GetUsuarioByCpf(GetUsuarioByCpfRequest request)
    { 
        try
        {
            var result = mapper.Map<UsuarioDto>(await usuarioRepository.GetUsuarioByCpf(request.Cpf));
            return new Response<UsuarioDto>(result, 200, "Usuário encontrado!");
        }
        catch (Exception e)
        {
            return new Response<UsuarioDto>(null, 500, "Algo deu errado tentando buscar o usuário.");

        }
    }

    public async Task<PagedResponse<List<UsuarioDto>>> GetUsuarios(GetAllUsuariosRequest request)
    {
        try
        {
            List<Usuario> query = await usuarioRepository.GetUsuarios();
            
            var usuarios =query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
            
            List<UsuarioDto> result = new();
            foreach (var usuario in usuarios)
            {
                result.Add(mapper.Map<UsuarioDto>(usuario));
            }

            return new PagedResponse<List<UsuarioDto>>(
                result,
                query.Count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e)
        {
            return new PagedResponse<List<UsuarioDto>>(null, 500, "Não foi possível consultar os usuarios");
        }
    }

    public async Task<PagedResponse<List<UsuarioDto>>> GetUsuariosByCargo(GetAllUsuariosByCargoRequest request)
    {
        try
        {
            List<Usuario> query = await usuarioRepository.GetUsuariosByCargo(request.CdCargo);
            
            var usuarios =query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
            
            List<UsuarioDto> result = new();
            foreach (var usuario in usuarios)
            {
                result.Add(mapper.Map<UsuarioDto>(usuario));
            }

            return new PagedResponse<List<UsuarioDto>>(
                result,
                query.Count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e)
        {
            return new PagedResponse<List<UsuarioDto>>(null, 500, "Não foi possível consultar os usuarios");
        }
    }

    public async Task<Response<UsuarioDto>> GetUsuarioByEmail(GetUsuarioByEmailRequest request)
    {
        try
        {
            var result = mapper.Map<UsuarioDto>(await usuarioRepository.GetUsuarioByEmail(request.Email));
            return new Response<UsuarioDto>(result, 200, "Usuário encontrado!");
        }
        catch (Exception e)
        {
            return new Response<UsuarioDto>(null, 500, "Algo deu errado tentando buscar o usuário.");

        } 
    }

    public async Task<Response<UsuarioDto>> UpdatePasswordUsuario(UpdateUsuarioPasswordRequest request)
    {
        try
        {
            var result = await usuarioRepository.UpdatePasswordUsuario(request.CdUsuario, request.NewPassword);
            return new Response<UsuarioDto>(mapper.Map<UsuarioDto>(result), 200, "Senha do usuário atualizada com sucesso!");            
        }
        catch (Exception e)
        {
            return new Response<UsuarioDto>(null, 500, "Não foi possível atualizar a senha do usuário.");
        }
    }
}