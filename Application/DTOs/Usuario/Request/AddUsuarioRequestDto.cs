namespace Application.DTOs.Usuario;

public record AddUsuarioRequestDto(string nmUsuario, string dsEmail, string dsSenha, string dsCPF,int dsGenero);
