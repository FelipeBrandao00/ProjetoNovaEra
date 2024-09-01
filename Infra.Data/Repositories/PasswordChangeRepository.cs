using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class PasswordChangeRepository(ApplicationDbContext passwordChangeContext) : IPasswordChangeRepository
{
    public async Task<RequestChangePassword> AddPasswordChange(RequestChangePassword passwordChange)
    { 
        passwordChangeContext.RequestsChangePassword.Add(passwordChange);
        passwordChangeContext.SaveChangesAsync();
        return passwordChange;

    }

    public async Task<RequestChangePassword> VerifyPasswordChangeCode(Guid cdUsuario, string dsToken)
    {
        return await passwordChangeContext.RequestsChangePassword.LastOrDefaultAsync(x => x.DtValidade >= DateTime.Now && x.CdUsuario == cdUsuario && x.DsCodigoRedefinicao == dsToken);
    }
}