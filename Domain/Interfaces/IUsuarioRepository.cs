using Domain.Entities;

namespace Domain.Interfaces {
    public interface IUsuarioRepository {

        Task<Usuario> AddUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<Usuario?> GetUsuarioByCpf(string cpf);
        Task<List<Usuario>> GetUsuarios();
        Task<List<Usuario>> GetUsuariosByCargo(int cdCargo);
        Task<Usuario?> GetUsuarioByEmail(string email);
        Task<Usuario?> UpdatePasswordUsuario(Guid cdUsuario, string newPassword);
    }
}
