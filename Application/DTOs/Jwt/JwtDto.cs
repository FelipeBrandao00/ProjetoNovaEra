using Domain.Entities;

namespace Application.DTOs.Jwt;

public record JwtDto(string NmUsuario, string DsEmail, string DsCPF,ICollection<Cargo_Usuario> CargoUsuario);