using System.Security.Cryptography;
using System.Text;
using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Encode;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;
public class UsuarioRepository(ApplicationDbContext _context) : IUsuarioRepository {


    public async Task<Usuario> AddUsuario(Usuario usuario)
    {
        usuario.DsSenha = Password.EncodePassword(usuario.DsSenha);
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario?> GetUsuarioByCpf(string cpf) {
        return await _context.Usuarios.FirstOrDefaultAsync(x => x.DsCpf == cpf);
    }

    public async Task<List<Usuario>> GetUsuarios() {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<List<Usuario>> GetUsuariosByCargo(int cdCargo)
    {
        return await 
            (from u in _context.Usuarios 
                join cu in _context.Cargo_Usuarios on u.CdUsuario equals cu.CdUsuario
                join c in _context.Cargos on cu.CdCargo equals c.CdCargo 
                where c.CdCargo == cdCargo
                select u)
            .ToListAsync();
    }

    public async Task<Usuario?> GetUsuarioByEmail(string email)
    {
        return await _context.Usuarios.SingleOrDefaultAsync(x => x.DsEmail == email);
    }

    public async Task<Usuario?> UpdatePasswordUsuario(Guid cdUsuario, string newPassword)
    {
        var usuario = _context.Usuarios.Where(x => x.CdUsuario == cdUsuario).FirstOrDefault();
        usuario.DsSenha = Password.EncodePassword(newPassword);
        _context.SaveChangesAsync();
        return usuario; 
    }

    public async Task<Usuario> UpdateUsuario(Usuario usuario) {
        var currentUserPassword = _context.Usuarios.Where(x => x.CdUsuario == usuario.CdUsuario).Select(x => x.DsSenha).FirstOrDefault();
        if (currentUserPassword == null) return null;
        usuario.DsSenha = currentUserPassword;
        _context.Entry(usuario).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<List<Usuario>> GetUsuariosByCargos(int[] cdCargos) {
        return await
                  (from u in _context.Usuarios
                   join cu in _context.Cargo_Usuarios on u.CdUsuario equals cu.CdUsuario
                   join c in _context.Cargos on cu.CdCargo equals c.CdCargo
                   where cdCargos.Contains(c.CdCargo)
                   select u)
                  .Distinct()
                  .ToListAsync();
    }
}
