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

    public async Task<List<Permissao_Cargos>> AddPermissoesCargo(List<Permissao_Cargos> permissaoCargo) {
        _context.Permissao_Cargos.RemoveRange(_context.Permissao_Cargos.Where(x => x.CdCargo == permissaoCargo[0].CdCargo));

        foreach (var permissao in permissaoCargo) {
            _context.Permissao_Cargos.Add(permissao);
        }
        await _context.SaveChangesAsync();
        return await GetPermissoesByCargoId(permissaoCargo[0].CdCargo);
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