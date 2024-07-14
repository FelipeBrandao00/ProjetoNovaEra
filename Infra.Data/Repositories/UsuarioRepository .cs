using System.Security.Cryptography;
using System.Text;
using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;
public class UsuarioRepository(ApplicationDbContext userContext) : IUsuarioRepository {


    public async Task<Usuario> AddUsuario(Usuario usuario)
    {
        usuario.dsSenha = EncodePassword(usuario.dsSenha);
        userContext.Usuarios.Add(usuario);
        await userContext.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario?> GetUsuarioByCpf(string cpf) {
        return await userContext.Usuarios.SingleOrDefaultAsync(x => x.dsCPF == cpf);
    }

    public async Task<IEnumerable<Usuario>> GetUsuarios() {
        return await userContext.Usuarios.ToListAsync();
    }

    public async Task<Usuario?> Authenticate(string email, string password)
    {
        var result = await  userContext.Usuarios
            .Where(x => x.dsEmail == email && x.dsSenha == EncodePassword(password))
            .FirstOrDefaultAsync();
        return result;
    }

    public async Task<Usuario> UpdateUsuario(Usuario usuario) {
        userContext.Usuarios.Update(usuario);
        await userContext.SaveChangesAsync();
        return usuario;
    }



    private string EncodePassword(string password)
    {
        byte[] bytes   = Encoding.Unicode.GetBytes(password);
        byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
        return Convert.ToBase64String(inArray);
    }
}
