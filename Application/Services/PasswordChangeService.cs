using Application.DTOs.PasswordChange;
using Application.Interfaces;
using Application.Requests.PasswordChange;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class PasswordChangeService(IPasswordChangeRepository passwordChangeRepository, IMapper mapper) : IPasswordChangeService
{
    public async Task<Response<PasswordChangeDto>> AddPasswordChange(AddPasswordChangeRequest request)
    {
        try
        {
            var entity = mapper.Map<RequestChangePassword>(request);
            var result = mapper.Map<PasswordChangeDto>(await passwordChangeRepository.AddPasswordChange(entity));
            return new Response<PasswordChangeDto>(result, 200, "Cadastro de token bem sucedido");
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
            var result = mapper.Map<PasswordChangeDto>(await passwordChangeRepository.VerifyPasswordChangeCode(request.CdUsuario,request.DsToken));
            return new Response<PasswordChangeDto>(result, 200, "Consulta de token bem sucedida");
        }
        catch (Exception e)
        {
            return new Response<PasswordChangeDto>(null, 500, "Não foi possível validar o token.");
        }
    }
}