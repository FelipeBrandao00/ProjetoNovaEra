using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class AlunoRepository(ApplicationDbContext _context) : IAlunoRepository
{
    public async Task<List<Turma_Aluno>> GetAllTurmasByUsuarioId(Guid cdUsuario)
    {
        return await 
            _context.Turma_Alunos
            .Where(x => x.CdAluno == cdUsuario)
            .Include(aluno => aluno.Turma)
            .ToListAsync();
        
    }

    public async Task<Turma_Aluno?> GetAtualTurmaByUsuarioId(Guid cdUsuario)
    {
        return await 
            _context.Turma_Alunos
                .Where(x => x.CdAluno == cdUsuario && x.IcAprovado == null)
                .Include(aluno => aluno.Turma)
                .OrderByDescending(x => x.CdTurma)
                .FirstOrDefaultAsync();
    }
}