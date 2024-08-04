using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class CargoUsuarioRepository(ApplicationDbContext CargoUsuarioContext) : ICargoUsuarioRepository
{
    public async Task<Cargo_Usuario> AddCargoUsuario(Cargo_Usuario cargoUsuario)
    {
        CargoUsuarioContext.Cargo_Usuarios.Add(cargoUsuario);
        await CargoUsuarioContext.SaveChangesAsync();
        return cargoUsuario;
    }

    public async Task<Cargo_Usuario> DeleteCargoUsuario(Cargo_Usuario cargoUsuario)
    {
        CargoUsuarioContext.Cargo_Usuarios.Remove(cargoUsuario);
        await CargoUsuarioContext.SaveChangesAsync();
        return cargoUsuario;
    }

    public async Task<List<Cargo_Usuario>> GetCargosByUserId(Guid cdUsuario)
    {
        return await CargoUsuarioContext.Cargo_Usuarios
            .Where(x => x.cdUsuario == cdUsuario)
            .Include(x => x.Cargo)
            .ToListAsync();
    }
}