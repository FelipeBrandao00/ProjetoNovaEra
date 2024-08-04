using Domain.Entities;

namespace Domain.Interfaces;

public interface ICargoUsuarioRepository
{
    Task<Cargo_Usuario> AddCargoUsuario(Cargo_Usuario cargoUsuario);
    Task<Cargo_Usuario> DeleteCargoUsuario(Cargo_Usuario cargoUsuario);
    Task<List<Cargo_Usuario>> GetCargosByUserId(Guid cdUsuario);
}