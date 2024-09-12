using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class PermissaoCargoRepository(ApplicationDbContext _context) : IPermissaoCargoRepository
{
    public async Task<Permissao_Cargos> AddPermissaoCargo(Permissao_Cargos permissaoCargo)
    {
        _context.Permissao_Cargos.Add(permissaoCargo);
        await _context.SaveChangesAsync();
        return permissaoCargo;
    }

    public async Task<Permissao_Cargos> DeletePermissaoCargo(Permissao_Cargos permissaoCargo)
    {
        _context.Permissao_Cargos.Remove(permissaoCargo);
        await _context.SaveChangesAsync();
        return permissaoCargo;
    }

    public async Task<List<Permissao_Cargos>> GetPermissoesByCargoId(int cdCargo)
    {
        return await _context.Permissao_Cargos
            .Where(x => x.CdCargo == cdCargo)
            .Include(x => x.Permissao)
            .ToListAsync();
    }
}