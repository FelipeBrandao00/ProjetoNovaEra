using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class PasswordChangeRepository(ApplicationDbContext passwordChangeContext) : IPasswordChangeRepository {
    public async Task<RequestChangePassword> AddPasswordChange(RequestChangePassword passwordChange) {
        passwordChangeContext.RequestsChangePassword.Add(passwordChange);
        await passwordChangeContext.SaveChangesAsync();
        return passwordChange;

    }

    public async Task<RequestChangePassword?> VerifyPasswordChangeCode(Guid cdUsuario, string dsToken) {
        var result =
            await passwordChangeContext.RequestsChangePassword.
            Where(x => x.DtValidade >= DateTime.Now && x.CdUsuario == cdUsuario && x.DsCodigoRedefinicao == dsToken && x.DtTrocaSenha == null).
            FirstOrDefaultAsync();
        if (result != null) await UpdateDataRequest(result.CdRequest);
        return result;
    }

    private async Task UpdateDataRequest(int cdRequest) {
        if (cdRequest == null) return;
        var entity = await passwordChangeContext.RequestsChangePassword.Where(x => x.CdRequest == cdRequest).FirstOrDefaultAsync();
        entity.DtTrocaSenha = DateTime.Now;
        await passwordChangeContext.SaveChangesAsync();
    }
}