using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class PasswordChangeRepository(ApplicationDbContext _context) : IPasswordChangeRepository {
    public async Task<RequestChangePassword> AddPasswordChange(RequestChangePassword passwordChange) {
        _context.RequestsChangePassword.Add(passwordChange);
        await _context.SaveChangesAsync();
        return passwordChange;

    }

    public async Task<RequestChangePassword?> VerifyPasswordChangeCode(Guid cdUsuario, string dsToken) {
        var result =
            await _context.RequestsChangePassword.
            Where(x => x.DtValidade >= DateTime.Now && x.CdUsuario == cdUsuario && x.DsCodigoRedefinicao == dsToken && x.DtTrocaSenha == null).
            FirstOrDefaultAsync();
        if (result != null) await UpdateDataRequest(result.CdRequest);
        return result;
    }

    private async Task UpdateDataRequest(int cdRequest) {
        if (cdRequest == null) return;
        var entity = await _context.RequestsChangePassword.Where(x => x.CdRequest == cdRequest).FirstOrDefaultAsync();
        entity.DtTrocaSenha = DateTime.Now;
        await _context.SaveChangesAsync();
    }
}