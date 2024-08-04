using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class CargoRepository(ApplicationDbContext cargoContext) : ICargoRepository
{
    public async Task<List<Cargo>> GetCargos()
    {
        return await cargoContext.Cargos.ToListAsync();
    }
}