using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class PermissaoRepository(ApplicationDbContext _context) : IPermissaoRepository
{
    public async Task<List<Permissao>> GetPermissoes()
    {
        return await _context.Permissoes.ToListAsync();
    }
}