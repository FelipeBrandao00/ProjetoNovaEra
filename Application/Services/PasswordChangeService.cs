using Application.DTOs.PasswordChange;
using Application.Interfaces;
using Application.Requests.PasswordChange;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class PasswordChangeService(IPasswordChangeRepository passwordChangeRepository, IMapper mapper,IUsuarioRepository usuarioRepository) : IPasswordChangeService
{
    public async Task<Response<PasswordChangeDto>> AddPasswordChange(AddPasswordChangeRequest request)
    {
        try
        {
            var entity = mapper.Map<RequestChangePassword>(request);
            var result = await passwordChangeRepository.AddPasswordChange(entity);
            var response = new PasswordChangeDto(result != null);
            return new Response<PasswordChangeDto>(response, 200, "Cadastro de token bem sucedido");
        }
        catch (Exception e)
        {
            return new Response<PasswordChangeDto>(null, 500, "Não foi possível adicionar o token.");
        }
    }

    public async Task<Response<PasswordChangeDto>> VerifyPasswordChangeCode(VerifyPasswordChangeCodeRequest request)
    {
        try
        {
            var usuario = await usuarioRepository.GetUsuarioByEmail(request.Email);
            if (usuario is null) throw new Exception("Usuario nao encontrado");
            var result = await passwordChangeRepository.VerifyPasswordChangeCode(usuario.CdUsuario,request.DsToken);
            var response = new PasswordChangeDto(result != null);
            return new Response<PasswordChangeDto>(response, 200, "Consulta de token bem sucedida");
        }
        catch (Exception e)
        {
            return new Response<PasswordChangeDto>(null, 500, "Não foi possível validar o token.");
        }
    }
}