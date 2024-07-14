using Domain.Entities;

namespace Domain.Interfaces {
    public interface IUsuarioRepository {

        Task<Usuario> AddUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<Usuario?> GetUsuarioByCpf(string cpf);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario?> Authenticate(string email, string password);
    }
}
