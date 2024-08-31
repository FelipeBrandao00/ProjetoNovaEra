using System.Security.Cryptography;
using System.Text;
using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Encode;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;
public class UsuarioRepository(ApplicationDbContext userContext) : IUsuarioRepository {


    public async Task<Usuario> AddUsuario(Usuario usuario)
    {
        usuario.DsSenha = Password.EncodePassword(usuario.DsSenha);
        userContext.Usuarios.Add(usuario);
        await userContext.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario?> GetUsuarioByCpf(string cpf) {
        return await userContext.Usuarios.SingleOrDefaultAsync(x => x.DsCpf == cpf);
    }

    public async Task<List<Usuario>> GetUsuarios() {
        return await userContext.Usuarios.ToListAsync();
    }

    public async Task<List<Usuario>> GetUsuariosByCargo(int cdCargo)
    {
        return await 
            (from u in userContext.Usuarios 
                join cu in userContext.Cargo_Usuarios on u.CdUsuario equals cu.CdUsuario
                join c in userContext.Cargos on cu.CdCargo equals c.CdCargo 
                where c.CdCargo == cdCargo
                select u)
            .ToListAsync();
    }

    public async Task<Usuario?> GetUsuarioByEmail(string email)
    {
        return await userContext.Usuarios.SingleOrDefaultAsync(x => x.DsEmail == email);
    }

    public async Task<Usuario?> UpdatePasswordUsuario(Guid cdUsuario, string newPassword)
    {
        var usuario = userContext.Usuarios.Where(x => x.CdUsuario == cdUsuario).FirstOrDefault();
        usuario.DsSenha = Password.EncodePassword(newPassword);
        userContext.SaveChangesAsync();
        return usuario; 
    }

    public async Task<Usuario> UpdateUsuario(Usuario usuario) {
        usuario.DsSenha = Password.EncodePassword(usuario.DsSenha);
        userContext.Entry(usuario).State = EntityState.Modified;
        await userContext.SaveChangesAsync();
        return usuario;
    }
}
