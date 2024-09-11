using Application.DTOs.Permissao;
using Application.Interfaces;
using Application.Requests.Permissao;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class PermissaoService(IPermissaoRepository permissaoRepository, IMapper mapper) : IPermissaoService
{
    public async Task<PagedResponse<List<PermissaoDto>>> GetPermissoes(GetAllPermissoesRequest request)
    {
        try
        {
            List<Permissao> query = await permissaoRepository.GetPermissoes();
            
            var permissoes =query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
            
            List<PermissaoDto> result = new();
            foreach (var permissao in permissoes)
            {
                result.Add(mapper.Map<PermissaoDto>(permissao));
            }

            return new PagedResponse<List<PermissaoDto>>(
                result,
                query.Count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e)
        {
            return new PagedResponse<List<PermissaoDto>>(null, 500, "Não foi possível consultar as permissões.");

        }
    }
}