using Application.DTOs.Cargo;
using Application.DTOs.CargoUsuario;
using Application.DTOs.Permissao;
using Application.DTOs.PermissaoCargo;
using Application.Requests;
using Application.Requests.CargoUsuario;
using Application.Requests.PermissaoCargo;
using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPermissaoCargoService
{
    Task<Response<PermissaoCargoDto>> AddPermissaoCargo(CreatePermissaoCargoRequest request);
    Task<Response<PermissaoCargoDto>> DeletePermissaoCargo(DeletePermissaoCargoRequest request);
    Task<PagedResponse<List<PermissaoDto>>> GetPermissoesByCargoId(GetPermissoesByCargoIdRequest request);
    Task<PagedResponse<List<PermissaoDto>>> AddPermissoesCargo(AddPermissoesCargoRequest request);

}