using Application.DTOs.Permissao;
using Application.Requests.Permissao;
using Application.Responses;

namespace Application.Interfaces;

public interface IPermissaoService
{
    Task<PagedResponse<List<PermissaoDto>>> GetPermissoes(GetAllPermissoesRequest request);
}