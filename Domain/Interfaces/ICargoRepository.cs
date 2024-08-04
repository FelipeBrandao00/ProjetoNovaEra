using Domain.Entities;

namespace Domain.Interfaces;

public interface ICargoRepository
{
    Task<List<Cargo>> GetCargos();
}