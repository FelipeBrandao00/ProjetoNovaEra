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

        public async Task<Aula?> GetAulaById(int aulaId) {
            return await _context.Aulas.Where(x => x.CdAula == aulaId).FirstOrDefaultAsync();
        }

        public async Task<List<Aula>> GetAulasByTurmaId(int turmaId) {
            return await _context.Aulas.Where(x => x.CdTurma == turmaId).ToListAsync(); 
        }

        public async Task<Aula> UpdateAula(Aula aula) {
            _context.Aulas.Update(aula);
            await _context.SaveChangesAsync();
            return aula;
        }
    }
}
