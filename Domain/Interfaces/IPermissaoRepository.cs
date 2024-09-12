using Domain.Entities;

namespace Domain.Interfaces;

public interface IPermissaoRepository
{
    Task<List<Permissao>> GetPermissoes();
}