using Application.DTOs;
using Application.DTOs.Usuario;

namespace Application.Interfaces {
    public interface IUsuarioService {
        Task<AddUsuarioResponseDto> AddUsuario(AddUsuarioRequestDto usuario);
        Task<UsuarioDto> UpdateUsuario(UsuarioDto defaultUsuario);
        Task<GetUsuarioResponseDto?> GetUsuarioByCpf(string cpf);
        Task<IEnumerable<GetUsuarioResponseDto>> GetUsuarios();
        Task<UsuarioDto?> Authenticate(string email, string password);
    }
}
