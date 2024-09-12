using System.Security.Cryptography;
using System.Text;
using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Encode;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class AuthenticateRepository(ApplicationDbContext _context) : IAuthenticateRepository
{
    public async Task<Usuario?> Authenticate(string email, string password)
    {
        var result = await  _context.Usuarios
            .Where(x => x.DsEmail == email && x.DsSenha == Password.EncodePassword(password))
            .Include(u => u.CargoUsuario)
            .ThenInclude(cargoUser => cargoUser.Cargo) 
            .FirstOrDefaultAsync();
        return result;
    }
}