using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class CargoUsuarioRepository(ApplicationDbContext _context) : ICargoUsuarioRepository
{
    public async Task<List<Cargo_Usuario>> AddCargosUsuario(List<Cargo_Usuario> cargosUsuario) {

        _context.Cargo_Usuarios.RemoveRange(_context.Cargo_Usuarios.Where(x => x.CdUsuario == cargosUsuario[0].CdUsuario));

        foreach (var cargoUsuario in cargosUsuario) {
            _context.Cargo_Usuarios.Add(cargoUsuario);
        }
        await _context.SaveChangesAsync();
        return await GetCargosByUserId(cargosUsuario[0].CdUsuario);
    } 

    public async Task<Cargo_Usuario> AddCargoUsuario(Cargo_Usuario cargoUsuario)
    {
        _context.Cargo_Usuarios.Add(cargoUsuario);
        await _context.SaveChangesAsync();
        return cargoUsuario;
    }

    public async Task<Cargo_Usuario> DeleteCargoUsuario(Cargo_Usuario cargoUsuario)
    {
        _context.Cargo_Usuarios.Remove(cargoUsuario);
        await _context.SaveChangesAsync();
        return cargoUsuario;
    }

    public async Task<List<Cargo_Usuario>> GetCargosByUserId(Guid cdUsuario)
    {
        return await _context.Cargo_Usuarios
            .Where(x => x.CdUsuario == cdUsuario)
            .Include(x => x.Cargo)
            .ToListAsync();
    }
}