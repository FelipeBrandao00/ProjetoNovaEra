using Domain.Entities;

namespace Domain.Interfaces;

public interface IAuthenticateRepository
{
    Task<Usuario?> Authenticate(string email, string password);
}