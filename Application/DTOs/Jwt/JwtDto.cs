using Domain.Entities;

namespace Application.DTOs.Jwt;

public record JwtDto(string nmUsuario, string dsEmail, string dsCPF,ICollection<Cargo_Usuario> CargoUsuario);