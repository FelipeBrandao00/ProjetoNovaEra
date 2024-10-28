using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories {
    public class TurmaAlunoRepository(ApplicationDbContext _context) : ITurmaAlunoRepository {
        public async Task<Turma_Aluno> AddTurmaAluno(Turma_Aluno turmaAluno) {
            _context.Turma_Alunos.Add(turmaAluno);
            await _context.SaveChangesAsync();
            return await GetTurmaAlunoByIds(turmaAluno.CdAluno, turmaAluno.CdTurma);
        }

        public async Task<Turma_Aluno> DeleteTurmaAluno(Turma_Aluno turmaAluno) {
            turmaAluno = await GetTurmaAlunoByIds(turmaAluno.CdAluno, turmaAluno.CdTurma);
            _context.Turma_Alunos.Remove(turmaAluno);
            await _context.SaveChangesAsync();
            return turmaAluno;
        }

        private async Task<Turma_Aluno> GetTurmaAlunoByIds(Guid cdAluno, int cdTurma) {
            return await _context.Turma_Alunos
                .Where(x => x.CdAluno == cdAluno && x.CdTurma == cdTurma)
                .Include(aluno => aluno.Turma)
                .ThenInclude(turma => turma.Curso)
                .OrderByDescending(x => x.CdTurma)
                .FirstAsync();
        }
    }
}
