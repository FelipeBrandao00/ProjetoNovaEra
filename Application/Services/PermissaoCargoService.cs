using Application.DTOs.Cargo;
using Application.DTOs.Permissao;
using Application.DTOs.PermissaoCargo;
using Application.Interfaces;
using Application.Requests;
using Application.Requests.CargoUsuario;
using Application.Requests.PermissaoCargo;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class PermissaoCargoService(IPermissaoCargoRepository permissaoCargoRepository, IMapper mapper) : IPermissaoCargoService
{
    public async Task<Response<PermissaoCargoDto>> AddPermissaoCargo(CreatePermissaoCargoRequest request)
    {
        try
        {
            var entity = mapper.Map<Permissao_Cargos>(request);
            var retorno =  await permissaoCargoRepository.AddPermissaoCargo(entity);
            return new Response<PermissaoCargoDto>(
                mapper.Map<PermissaoCargoDto>(retorno), 
                201, 
                "Permissão vinculada com sucesso!");
        }
        catch (Exception e)
        {
            return new Response<PermissaoCargoDto>(
                null, 
                500, 
                "Não foi possível vincular a permissão.");
        }
    }

    public async Task<PagedResponse<List<PermissaoDto>>> AddPermissoesCargo(AddPermissoesCargoRequest request) {
        try {

            if (request.CdPermissoes.Length == 0) return new PagedResponse<List<PermissaoDto>>(null, 500, "Envie pelo menos 1 permissao para o cargo!");


            List<Permissao_Cargos> permissoes = new List<Permissao_Cargos>();

            foreach (var permissao in request.CdPermissoes) {
                var entity = mapper.Map<Permissao_Cargos>(new CreatePermissaoCargoRequest {  CdCargo = request.CdCargo, CdPermissao = permissao });
                permissoes.Add(entity);
            }

            var retorno = await permissaoCargoRepository.AddPermissoesCargo(permissoes);

            List<PermissaoDto> result = new();
            foreach (var permissao in retorno) {
                result.Add(mapper.Map<PermissaoDto>(permissao.Permissao));
            }

            return new PagedResponse<List<PermissaoDto>>(
                result,
                result.Count,
                1,
                result.Count);
        }
        catch (Exception e) {
            return new PagedResponse<List<PermissaoDto>>(null, 500, "Não foi possível vincular as permissões.");

        }
    }

    public async Task<Response<PermissaoCargoDto>> DeletePermissaoCargo(DeletePermissaoCargoRequest request)
    {
        try
        {
            var entity = mapper.Map<Permissao_Cargos>(request);
            var retorno =  await permissaoCargoRepository.DeletePermissaoCargo(entity);
            return new Response<PermissaoCargoDto>(
                mapper.Map<PermissaoCargoDto>(retorno), 
                201, 
                "Permissão desvinculada com sucesso!");
        }
        catch (Exception e)
        {
            return new Response<PermissaoCargoDto>(
                null, 
                500, 
                "Não foi possível desvincular a permissão.");
        }
    }

    public async Task<PagedResponse<List<PermissaoDto>>> GetPermissoesByCargoId(GetPermissoesByCargoIdRequest request)
    {
        try
        {
            List<Permissao_Cargos> query = await permissaoCargoRepository.GetPermissoesByCargoId(request.CdCargo);
            
            var permissaoCargos =query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
            
            List<PermissaoDto> result = new();
            foreach (var permissao in permissaoCargos)
            {
                result.Add(mapper.Map<PermissaoDto>(permissao.Permissao));
            }

            return new PagedResponse<List<PermissaoDto>>(
                result,
                query.Count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e)
        {
            return new PagedResponse<List<PermissaoDto>>(null, 500, "Não foi possível consultar os cargos do usuario");
        }
    }
}