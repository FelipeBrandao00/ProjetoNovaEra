using System.Security.Cryptography;
using System.Text;
using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Encode;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class AuthenticateRepository(ApplicationDbContext authContext) : IAuthenticateRepository
{
    public async Task<Usuario?> Authenticate(string email, string password)
    {
        var result = await  authContext.Usuarios
            .Where(x => x.dsEmail == email && x.dsSenha == Password.EncodePassword(password))
            .Include(u => u.CargoUsuario)
            .ThenInclude(cargoUser => cargoUser.Cargo) 
            .FirstOrDefaultAsync();
        return result;
    }
}