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
                .Include(aluno => aluno.Turma.Curso)
                .OrderByDescending(x => x.CdTurma)
                .FirstOrDefaultAsync();
    }

    public async Task<List<Usuario?>> GetAlunoByLikedName(string nmAluno)
    {
        var alunos =
            (from u in _context.Usuarios
                join cu in _context.Cargo_Usuarios on u.CdUsuario equals cu.CdUsuario
                join c in _context.Cargos on cu.CdCargo equals c.CdCargo
                where c.DsCargo == "Aluno"
                select u);

        if (!string.IsNullOrEmpty(nmAluno))
        {
            alunos = alunos.Where( x=>  x.NmUsuario.Contains(nmAluno));
        }

        return await alunos.ToListAsync();
    }
}