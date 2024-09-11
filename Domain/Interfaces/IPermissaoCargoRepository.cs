using Domain.Entities;

namespace Domain.Interfaces;

public interface IPermissaoCargoRepository
{
    Task<Permissao_Cargos> AddPermissaoCargo(Permissao_Cargos permissaoCargo);
    Task<Permissao_Cargos> DeletePermissaoCargo(Permissao_Cargos permissaoCargo);
    Task<List<Permissao_Cargos>> GetPermissoesByCargoId(int cdCargo);
}