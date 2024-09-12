using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class CargoRepository(ApplicationDbContext _context) : ICargoRepository
{
    public async Task<List<Cargo>> GetCargos()
    {
        return await _context.Cargos.ToListAsync();
    }
}