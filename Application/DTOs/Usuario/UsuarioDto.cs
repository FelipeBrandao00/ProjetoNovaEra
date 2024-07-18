using Domain.Entities;

namespace Application.DTOs;

public record UsuarioDto(string nmUsuario, string dsEmail, string dsCPF, ICollection<Cargo_Usuario> CargoUsuario);