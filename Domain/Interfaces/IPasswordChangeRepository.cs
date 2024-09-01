using Domain.Entities;

namespace Domain.Interfaces;

public interface IPasswordChangeRepository
{
    Task<RequestChangePassword> AddPasswordChange(RequestChangePassword passwordChange);
    Task<RequestChangePassword> VerifyPasswordChangeCode(Guid cdUsuario, string dsToken);
}