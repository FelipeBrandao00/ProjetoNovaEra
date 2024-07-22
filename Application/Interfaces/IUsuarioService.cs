using Application.DTOs;
using Application.DTOs.Usuario;

namespace Application.Interfaces {
    public interface IUsuarioService {
        Task<RegisteredUsuarioDto> AddUsuario(AddUsuarioDto usuario);
        Task<UsuarioDto> UpdateUsuario(UsuarioDto usuario);
        Task<UsuarioDto?> GetUsuarioByCpf(string cpf);
        Task<IEnumerable<UsuarioDto>> GetUsuarios();
        Task<UsuarioDto?> Authenticate(string email, string password);
    }
}
