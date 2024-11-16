using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories {
    public class AulaRepository(ApplicationDbContext _context) : IAulaRepository {
        public async Task<Aula> AddAula(Aula aula) {
            _context.Aulas.Add(aula);
            await _context.SaveChangesAsync();
            return aula;
        }

        public async Task<Aula> DeleteAula(Aula aula) {
            _context.Aulas.Remove(aula);
            await _context.SaveChangesAsync();
            return aula;
        }

        public async Task<Aula?> EfetuarChamada(int aulaId) {
            var aula = await GetAulaById(aulaId);

            if (aula == null) { return null; }
            aula.IsChamada = true;
            await _context.SaveChangesAsync();
            return aula;
        }

        public async Task<Aula?> GetAulaById(int aulaId) {
            return await _context.Aulas.Where(x => x.CdAula == aulaId).FirstOrDefaultAsync();
        }

        public async Task<List<Aula>> GetAulasByTurmaId(int turmaId, bool? icChamada) {
            if (icChamada == true) {
                return await _context.Aulas.Where(x => x.IsChamada == true && x.CdTurma == turmaId).ToListAsync();
            }

            if (icChamada == false) {
                return await _context.Aulas.Where(x => x.IsChamada == false && x.CdTurma == turmaId).ToListAsync();
            }

            return await _context.Aulas.Where(x => x.CdTurma == turmaId).ToListAsync(); 
        }

        public async Task<int> GetTotalPresencasAulaById(int aulaId) {

            var aula = await GetAulaById(aulaId);
            var totalAlunos = _context.Turma_Alunos.Where(x => x.CdTurma == aula.CdTurma).Count();
            var totalFaltas = _context.Frequencias.Where(x => x.CdAula == aula.CdAula).Count();

            return totalAlunos - totalFaltas;
        }

        public async Task<Aula> UpdateAula(Aula aula) {
            _context.Aulas.Update(aula);
            await _context.SaveChangesAsync();
            return aula;
        }
    }
}
